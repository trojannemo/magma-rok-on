using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MagmaRokOn.Properties;
using NAudio.Midi;

namespace MagmaRokOn
{
    public partial class MidiTester : Form
    {
        private readonly MainForm mMainForm;
        public ProjectFile ProjectFile { get; private set; }
        private readonly string SilenceStereo44;
        private readonly string BlankDryvox;
        private readonly string BlankBacking44;
        private bool StopWork;
        private readonly NemoTools Tools;
        private string testfolder = "";
        private string MIDIfile = "";
        private DateTime endTime;
        private DateTime startTime;
        private bool HasProGuitar;
        private bool HasProBass;
        private string originalpath;

        public MidiTester(MainForm mainform, string MIDI)
        {
            InitializeComponent();
            mMainForm = mainform;
            var skin = mMainForm == null ? "" : mMainForm.ActiveSkin;
            switch (skin)
            {                
                case "custom":
                    SkinDefaults();
                    SkinButtonStyles(mMainForm.SkinButtonStyle);
                    SkinButtonText(mMainForm.SkinButtonTextColor);
                    btnOpen.BackColor = mMainForm.SkinButtonBackgroundColor;
                    btnCleaner.BackColor = mMainForm.SkinButtonBackgroundColor;
                    btnClipboard.BackColor = mMainForm.SkinButtonBackgroundColor;
                    btnClose.BackColor = mMainForm.SkinButtonBackgroundColor;
                    break;
            }
            Tools = new NemoTools();
            SilenceStereo44 = Application.StartupPath + "\\audio\\stereo44.wav";
            BlankDryvox = Application.StartupPath + "\\audio\\blank_dryvox.wav";
            BlankBacking44 = Application.StartupPath + "\\audio\\blank_backing44.wav";
            MIDIfile = MIDI;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Tools.DeleteFolder(testfolder, true);
            Close();
        }

        private void btnClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtLog.Text);
            ShowToast("Copied log to clipboard");
        }

        private static void ShowToast(string message)
        {
            var toast = new frmToast(message, MousePosition);
            toast.Show();
        }

        private void SkinDefaults()
        {
            BackgroundImage = mMainForm.SkinBackgroundImage;
            BackColor = mMainForm.SkinFormBackgroundColor;
            btnOpen.BackgroundImage = null;
            btnCleaner.BackgroundImage = null;
            btnClose.BackgroundImage = null;
            btnClipboard.BackgroundImage = null;
            txtLog.BackColor = mMainForm.SkinTextBoxBackgroundColor;
            txtLog.ForeColor = mMainForm.SkinTextBoxTextColor;
        }

        private void SkinButtonStyles(FlatStyle style)
        {
            btnOpen.FlatStyle = style;
            btnCleaner.FlatStyle = style;
            btnClose.FlatStyle = style;
            btnClipboard.FlatStyle = style;
        }

        private void SkinButtonText(Color color)
        {
            btnOpen.ForeColor = color;
            btnCleaner.ForeColor = color;
            btnClose.ForeColor = color;
            btnClipboard.ForeColor = color;
        }

        private void txtLog_DragDrop(object sender, DragEventArgs e)
        {
            if (StopWork) return;
            var fileNames = ((string[])e.Data.GetData(DataFormats.FileDrop));
            foreach (var fileName in fileNames)
            {
                if (fileName.ToLowerInvariant().EndsWith(".mid", StringComparison.Ordinal))
                {
                    ReadMidi(fileName);
                }
                else
                {
                    Log("File " + Path.GetFileName(fileName) + " is not a valid MIDI file. Try again.");
                }
            }
        }

        private bool HasInstruments()
        {
            var instruments = false;
            if (ProjectFile.GetTrack("drum_kit").Enabled)
            {
                instruments = true;
            }
            else if (ProjectFile.GetTrack("guitar").Enabled)
            {
                instruments = true;
            }
            else if (ProjectFile.GetTrack("bass").Enabled)
            {
                instruments = true;
            }
            else if (ProjectFile.GetTrack("keys").Enabled)
            {
                instruments = true;
            }
            else if (ProjectFile.GetTrack("vocals").Enabled)
            {
                instruments = true;
            }
            return instruments;
        }

        private void ReadMidi(string file)
        {
            startTime = DateTime.Now;
            testfolder = Application.StartupPath + "\\test\\";
            originalpath = file;
            MIDIfile = testfolder + Path.GetFileName(file);
            btnCleaner.Visible = false;
            Tools.DeleteFolder(testfolder, true);
            if (!Directory.Exists(testfolder))
            {
                Directory.CreateDirectory(testfolder);
            }
            try
            {
                File.Copy(file,MIDIfile);
            }
            catch (Exception)
            {
                MIDIfile = file;
            }
            var songMidi = Tools.NemoLoadMIDI(MIDIfile);
            if (songMidi == null)
            {
                Log("Failed to load MIDI file " + Path.GetFileName(MIDIfile) + ".");
                EndProcess();
                return;
            }
            Log("\n");
            ProjectFile = new ProjectFile();
            ProjectDefaults();
            for (var i = 0; i < songMidi.Events.Tracks; i++)
            {
                if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("drums"))
                {
                    Log("Found " + Tools.GetMidiTrackName(songMidi.Events[i][0].ToString()) + "...");
                    if (!ProjectFile.GetTrack("drum_kit").Enabled)
                    {
                        var track = new TrackInfo(SilenceStereo44, "drum_kit", 0, 0, true);
                        ProjectFile.SetTrack(track);
                    }
                    foreach (var drummix in from notes in songMidi.Events[i] where notes.CommandCode == MidiCommandCode.MetaEvent select (MetaEvent)notes into mixevent where mixevent.ToString().Contains("mix") && mixevent.ToString().Contains("drums") select mixevent.ToString() into drummix select drummix.Substring(drummix.Length - 1, 1))
                    {
                        switch (drummix)
                        {
                            case "0":
                                Log("Found standard drum mix event.");
                                break;
                            case "1":
                            case "2":
                            case "3":
                                Log("Found non-standard drum mix event ... make sure you have the right audio files.");
                                break;
                        }
                        break;
                    }
                }
                else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("guitar"))
                {
                    Log("Found " + Tools.GetMidiTrackName(songMidi.Events[i][0].ToString()) + "...");
                    if (!ProjectFile.GetTrack("guitar").Enabled)
                    {
                        var track = new TrackInfo(SilenceStereo44, "guitar", 0, 0, true);
                        ProjectFile.SetTrack(track);
                    }
                    if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("real_guitar"))
                    {
                        HasProGuitar = true;
                    }
                }
                else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("bass"))
                {
                    Log("Found " + Tools.GetMidiTrackName(songMidi.Events[i][0].ToString()) + "...");
                    if (!ProjectFile.GetTrack("bass").Enabled)
                    {
                        var track = new TrackInfo(SilenceStereo44, "bass", 0, 0, true);
                        ProjectFile.SetTrack(track);
                    }
                    if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("real_bass"))
                    {
                        HasProBass = true;
                    }
                }
                else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("keys"))
                {
                    Log("Found " + Tools.GetMidiTrackName(songMidi.Events[i][0].ToString()) + "...");
                    if (ProjectFile.GetTrack("keys").Enabled) continue;
                    var track = new TrackInfo(SilenceStereo44, "keys", 0, 0, true);
                    ProjectFile.SetTrack(track);
                }
                else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("vocals"))
                {
                    Log("Found " + Tools.GetMidiTrackName(songMidi.Events[i][0].ToString()) + "...");
                    if (!ProjectFile.GetTrack("vocals").Enabled)
                    {
                        var track = new TrackInfo(SilenceStereo44, "vocals", 0, 0, true);
                        ProjectFile.SetTrack(track);
                    }
                    foreach (var vocal_event in songMidi.Events[i].Where(notes => notes.CommandCode == MidiCommandCode.MetaEvent).Cast<MetaEvent>())
                    {
                        if (vocal_event.ToString().Contains("[clap"))
                        {
                            ProjectFile.Percussion = "handclap";
                            Log("Found vocal percussion: hand clap.");
                            break;
                        }
                        if (vocal_event.ToString().Contains("[cowbell"))
                        {
                            ProjectFile.Percussion = "cowbell";
                            Log("Found vocal percussion: cowbell.");
                            break;
                        }
                        if (!vocal_event.ToString().Contains("[tambourine")) continue;
                        ProjectFile.Percussion = "tambourine";
                        Log("Found vocal percussion: tambourine.");
                        break;
                    }
                }
                else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("harm1"))
                {
                    Log("Found " + Tools.GetMidiTrackName(songMidi.Events[i][0].ToString()) + "...");
                    if (!ProjectFile.GetTrack("vocals").Enabled)
                    {
                        var track = new TrackInfo(SilenceStereo44, "vocals", 0, 0, true);
                        ProjectFile.SetTrack(track);
                    }
                    ProjectFile.DryVoxFile = BlankDryvox;
                }
                else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("harm2"))
                {
                    Log("Found " + Tools.GetMidiTrackName(songMidi.Events[i][0].ToString()) + "...");
                    if (!ProjectFile.GetTrack("vocals").Enabled)
                    {
                        var track = new TrackInfo(SilenceStereo44, "vocals", 0, 0, true);
                        ProjectFile.SetTrack(track);
                    }
                    ProjectFile.DryVoxHarmony2File = BlankDryvox;
                }
                else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("harm3"))
                {
                    Log("Found " + Tools.GetMidiTrackName(songMidi.Events[i][0].ToString()) + "...");
                    if (!ProjectFile.GetTrack("vocals").Enabled)
                    {
                        var track = new TrackInfo(SilenceStereo44, "vocals", 0, 0, true);
                        ProjectFile.SetTrack(track);
                    }
                    ProjectFile.DryVoxHarmony3File = BlankDryvox;
                }
            }
            if (!HasInstruments())
            {
                Log("No instrument charts were found in the MIDI file.");
                Log("Can't continue without at least one instrument chart.");
                Log("Stopping here.");
                EndProcess();
                return;
            }
            if (!Tools.MidiIsClean(ProjectFile.MidiFile, ProjectFile.GetTrack("keys").Enabled, HasProBass || HasProGuitar))
            {
                Log("\nFound errors in the MIDI file:");
                Log(Tools.MIDI_ERROR_MESSAGE.Substring(1,Tools.MIDI_ERROR_MESSAGE.Length - 1));
                btnCleaner.Visible = true;
                Log("Stopping here.");
                EndProcess();
                return;
            }
            Log(Tools.MIDIAutoGen(ProjectFile.MidiFile, "[mix # drums0]", false, false, ProjectFile.GetTrack("drum_kit").Enabled,true));
            Tools.DoesMidiHaveEMH(ProjectFile.MidiFile);
            Log(Tools.MIDI_ERROR_MESSAGE);
            Log("Ready to send files to MagmaCompiler ... hold on.");
            //Tools.RemovePSDrumsXNotes(ProjectFile.MidiFile);
            if (Tools.CheckMIDIFor2X(ProjectFile.MidiFile))
            {
                if (!Tools.Separate2XMidi(ProjectFile.MidiFile))
                {
                    SendtoCompiler();
                    return;
                }
                Log("MIDI file contains 2X Bass Pedal track.");
                Log("MIDI Will be tested twice, once with each drum track enabled.");
                Log("Testing standard MIDI...");
                ProjectFile.MidiFile = Tools.MIDI1X;
                SendtoCompiler();
                Log("Testing 2X Bass Pedal MIDI...");
                ProjectFile.MidiFile = Tools.MIDI2X;
                SendtoCompiler();
            }
            else
            {
                SendtoCompiler();
            }
            EndProcess();
        }

        private void EndProcess()
        {
            if (ProjectFile != null)
            {
                ProjectFile.Dispose();
            }
            txtLog.Cursor = Cursors.Default;
            endTime = DateTime.Now;
            var timeDiff = endTime - startTime;
            Log("\nProcess completed in " + timeDiff.Minutes + (timeDiff.Minutes == 1 ? " minute" : " minutes") + " and " + (timeDiff.Minutes == 0 && timeDiff.Seconds == 0 ? "1 second" : timeDiff.Seconds + " seconds") + ".");
            Log("You may drag another MIDI or just click Close to exit.");
        }

        private void SendtoCompiler()
        {
            ProjectFile.WriteFile(testfolder + "test.rbproj");
            Log("Output from MagmaCompiler follows:");
            
            var arg = " -have_lock -export_midi \"" + testfolder + "test.rbproj\" \"" + testfolder + "test_compiled.mid\"";
            var startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                FileName = Application.StartupPath + "\\MagmaCompilerC3.exe",
                Arguments = arg,
                WorkingDirectory = Application.StartupPath
            };
            ProjectFile.Unlock();

            var start = (DateTime.Now.Minute * 60) + DateTime.Now.Second;
            var process = Process.Start(startInfo);
            do
            {
                if ((DateTime.Now.Minute * 60) + DateTime.Now.Second - start < 30) continue; //30 sec difference 
                if (MessageBox.Show("It seems that MagmaCompiler is taking longer than is normal\nThis usually means that the MIDI itself is fine but MagmaCompiler has entered a loop (it's really difficult to control)\nDo you want to stop this process? Click NO if you want to wait a little bit longer", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                    DialogResult.Yes)
                {
                    break;
                }
                start = (DateTime.Now.Minute * 60) + DateTime.Now.Second;
            } while (!process.HasExited && process.Responding);

            if (!process.HasExited) //closed by user above
            {
                process.Kill();
                Log("SendToCompiler process aborted by user, there may not be any output from MagmaCompiler.");
            }
            try
            {
                var output = process.StandardOutput;
                while (output.Peek() > 0)
                {
                    var line = output.ReadLine();
                    Log(line);
                }
            }
            catch (Exception)
            {}
            if (process.ExitCode == 0)
            {
                Log("Seems this MIDI is in excellent condition. No errors reported by MagmaCompiler.");
            }
            else
            {
                Log("MagmaCompiler reported some errors. Please see the log for details on what must be fixed.");
                btnCleaner.Visible = true;
            }
            process.Dispose();
        }

        private void ProjectDefaults()
        {
            //default settings
            ProjectFile.SongName = "Test Song";
            ProjectFile.ArtistName = "Test Artist";
            ProjectFile.HasAlbum = false;
            ProjectFile.YearReleased = DateTime.Now.Year;
            ProjectFile.MidiFile = MIDIfile;
            ProjectFile.DestinationFile = testfolder + Path.GetFileNameWithoutExtension(MIDIfile) + ".rba";
            ProjectFile.PreviewStart = 15000;
            ProjectFile.AlbumArt = Application.StartupPath + "\\default.bmp";
            ProjectFile.Author = "MIDI Tester";
            ProjectFile.LangEnglish = true;
            ProjectFile.Country = "ugc_country_us";
            ProjectFile.Price = 80;
            ProjectFile.Genre = "other";
            ProjectFile.SubGenre = "subgenre_other";
            ProjectFile.Gender = "male";
            ProjectFile.TuningOffset = 0;
            ProjectFile.Tempo = 32;
            ProjectFile.ScrollSpeed = 2300;
            ProjectFile.GuidePitchVolume = -3;
            ProjectFile.AutogenTheme = "FeelGoodPopRock.rbtheme";
            HasProBass = false;
            HasProGuitar = false;
            Tools.MIDI1X = "";
            Tools.MIDI2X = "";

            var track = new TrackInfo(BlankBacking44, "backing", 0, 0, true);
            ProjectFile.SetTrack(track);
        }

        public void Log(string line)
        {
            if (line.Contains("src\\rbnvalidator")) return;
            if (line.Contains("SystemInit Params")) return;
            txtLog.Text = txtLog.Text + line.Replace("\n", "\r\n") + Environment.NewLine;
            if (line.Contains("Cannot parse event"))
            {
                txtLog.Text = txtLog.Text + "You can fix this by running the MIDI through Nautilus' MIDI " +
                                    "Cleaner or by using 'Remove invalid markers' in C3 Automation Tools from REAPER before " +
                                    "exporting your MIDI." + Environment.NewLine;
            }
            else if (line.Contains("less than 2 beats from the beginning"))
            {
                txtLog.Text = txtLog.Text + "Make sure you have notes for the entire BEAT track, not just at the beginning, " +
                                    "and that you have at least two notes in the BEAT track before this point." + Environment.NewLine;
            }
            else if (line.Contains("Confused by vocal phrase overlap"))
            {
                txtLog.Text = txtLog.Text + "This means you probably have a very short vocal phrase marker somewhere, zoom " +
                                    "in on your project and check all your vocal phrase markers." + Environment.NewLine;
            }
            else if (line.Contains("No gems between overdrive phrases"))
            {
                txtLog.Text = txtLog.Text + "You can't have an overdrive phrase followed by an overdrive phrase without any " +
                                    "playable notes in between, add some notes between the overdrive phrases listed above." + Environment.NewLine;
            }
            else if (line.Contains("mKeyboardRangeSecondPitch == -1"))
            {
                txtLog.Text = txtLog.Text + "This means you didn't author Pro Keys but left the track in the MIDI - you must mute " +
                                    "unauthored tracks in REAPER before exporting." + Environment.NewLine;
            }
            else if (line.Contains("drum mix") && line.Contains("supports exactly"))
            {
                txtLog.Text = txtLog.Text + "This happens when the drums mix events at the start of your drums chart don't match the " +
                                    "audio files you gave to Magma.  Either let Magma do this for you by enabling 'Add to MIDI' in the Recommended Drum " +
                                    "Mix section in the Audio Tab, or read the authoring documents for the correct drum mix. Most users should not modify " +
                                    "the default in the C3 template)." + Environment.NewLine;
            }
            else if (line.Contains("velocity <= 127"))
            {
                txtLog.Text = txtLog.Text + "This means you somehow changed the note velocities to a value that is not allowed. Change the note " +
                                    "velocities to a value like 96 or 100 in REAPER." + Environment.NewLine;
            }
            else if (line.Contains("Chord gems do not start simultaneously"))
            {
                txtLog.Text = txtLog.Text + "Rock Band 3 does not support broken chords like Guitar Hero. You either have chords with notes " +
                                    "starting at different times, or one note that runs too long and over the next note. Zoom in real close in REAPER and " +
                                    "you'll see it." + Environment.NewLine;
            }
            else if (line.Contains("Time division must be 480 ticks per quarter"))
            {
                txtLog.Text = txtLog.Text + "This is a setting in REAPER that you somehow changed. Install the RBN Authoring Tools and this will " +
                                    "reset the value in REAPER or find the setting manually and set it back to 480." + Environment.NewLine;
            }
            else if (line.Contains("Multiple tracks share the name"))
            {
                var index = line.IndexOf("PART", StringComparison.Ordinal);
                var name = line.Substring(index, line.Length - index).Trim();
                txtLog.Text = txtLog.Text + "Your MIDI file has more than one instance of the track name '" + name + "'. Yes, yes it does. Make " +
                                    "sure that the first event for each track is a TRACK NAME event and you don't have repeated names. You may have one " +
                                    "track on top of another and you can't tell, so move them around in REAPER to find the offending track. It's there. " +
                                    "Look for it. Trust me, I'm a computer program." + Environment.NewLine;
            }
            else if (line.Contains("Empty track found"))
            {
                var index1 = line.IndexOf("PART", StringComparison.Ordinal);
                var index2 = line.IndexOf(":", index1, StringComparison.Ordinal);
                var name = line.Substring(index1, index2 - index1);
                txtLog.Text = txtLog.Text + "This means that at least one of the difficulties for " + name + " has no notes charted - you have to add " +
                                    "something or MagmaCompiler will refuse to compile the song." + Environment.NewLine;
            }
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
        }

        private void MidiTester_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            var files = "";
            if (!File.Exists(SilenceStereo44))
            {
                StopWork = true;
                files = files + "\n" + SilenceStereo44;
            }
            if (!File.Exists(BlankDryvox))
            {
                StopWork = true;
                files = files + "\n" + BlankDryvox;
            }
            if (!File.Exists(BlankBacking44))
            {
                StopWork = true;
                files = files + "\n" + BlankBacking44;
            }
            if (StopWork)
            {
                Log("The following files are required for this process and was not found:");
                Log(files);
                Log("Please redownload this program and do not delete any files.");
            }
            else
            {
                if (MIDIfile == "") return;
                btnCleaner.Visible = false;
                ReadMidi(MIDIfile);
            }
        }

        private void txtLog_DragEnter(object sender, DragEventArgs e)
        {
            if (StopWork)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
                {
                    Filter = "MIDI File (*.mid)|*.mid",
                    InitialDirectory = Tools.CurrentFolder,
                    Title = "Select MIDI file(s) to test",
                    Multiselect = true,
                };

            if (ofd.ShowDialog() != DialogResult.OK) return;
            foreach (var file in ofd.FileNames)
            {
                MIDIfile = file;
                btnCleaner.Visible = false;
                ReadMidi(MIDIfile);
            }
        }

        private void btnCleaner_Click(object sender, EventArgs e)
        {
            if (mMainForm.nautilusPath != "" && File.Exists(mMainForm.nautilusPath))
            {
                Process.Start(mMainForm.nautilusPath, originalpath);
            }
            else
            {
                var fileDialog = new OpenFileDialog
                {
                    Filter = "Windows Executable (*.exe)|*.exe",
                    InitialDirectory = Application.StartupPath,
                    Title = "Select Nautilus Executable"
                };
                if (fileDialog.ShowDialog() == DialogResult.Cancel) return;
                if (fileDialog.FileName != "" && fileDialog.FileName.EndsWith(".exe", StringComparison.Ordinal))
                {
                    mMainForm.nautilusPath = fileDialog.FileName;
                    mMainForm.SaveOptions();
                }
                Process.Start(mMainForm.nautilusPath, originalpath);
            }
        }

        private void MidiTester_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mMainForm == null)
            {
                Environment.Exit(0);
            }
        }
    }
}
