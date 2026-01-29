using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using MagmaRokOn.x360;
using MagmaRokOn.Properties;

namespace MagmaRokOn
{
    public partial class BuildForm : Form
    {
        private readonly MainForm mMainForm;
        private readonly ThreadSafeStringList mList;
        private readonly Timer mTimer;
        private readonly NemoTools Tools;
        private ThreadRunner mRunner;
        private CloseButtonState mCloseButtonState;
        private int mLastExitCode;
        private string rba_file;
        private string con_file;
        private string extract_folder;
        private string originalMIDI;
        private string UniqueID;
        private string build_rba;
        public string ChosenFile;
        public string basesongname;
        public string songname;
        public string artist;
        private bool mInternalError;
        private bool UserCancelled;
        private bool doing2X;
        public bool BuiltCon = false;
        private string RBtoUSBArgs;

        public enum Convert_Option
        {
            CONVERT_RBA,
            CONVERT_FOLDER,
            CONVERT_UPGRADES,
            CONVERT_DISTRIBUTION,
            CONVERT_ZIP,
            CONVERT_PS
        };
        
        private void SkinDefaults()
        {
            BackgroundImage = mMainForm.SkinBackgroundImage;
            
            BackColor = mMainForm.SkinFormBackgroundColor;
            btnClipboard.BackgroundImage = null;
            btnNautilus.BackgroundImage = null;
            btnVisualize.BackgroundImage = null;
            ButtonClose.BackgroundImage = null;

            TextBoxBuild.BackColor = mMainForm.SkinTextBoxBackgroundColor;
            TextBoxBuild.ForeColor = mMainForm.SkinTextBoxTextColor;
        }

        private void SkinButtonStyles(FlatStyle style)
        {
            btnClipboard.FlatStyle = style;
            btnNautilus.FlatStyle = style;
            btnVisualize.FlatStyle = style;
            ButtonClose.FlatStyle = style;
        }

        private void SkinButtonText(Color color)
        {
            btnClipboard.ForeColor = color;
            btnNautilus.ForeColor = color;
            btnVisualize.ForeColor = color;
            ButtonClose.ForeColor = color;
        }

        public BuildForm(MainForm form)
        {
            InitializeComponent();
            mMainForm = form;
            
            Tools = new NemoTools();
            mInternalError = false;
            mLastExitCode = 0;
            mMainForm = form;
            mList = new ThreadSafeStringList();
            mRunner = null;
            mTimer = new Timer { Interval = 50 };
            mTimer.Tick += Timer_Tick;
            mCloseButtonState = CloseButtonState.kInvalid;
            SetCloseButtonState(CloseButtonState.kCancel);
            rba_file = mMainForm.ProjectFile.DestinationFile;
        }

        public void doConvert()
        {
            var rba1x = rba_file.Contains("_rb3con.rba") ? rba_file.Replace("_rb3con.rba", "1x_rb3con.rba") : rba_file.Replace(".rba", "1x.rba");
            rba1x = rba1x.Replace("1x1x", "1x").Replace("2x", "");
            var rba2x = rba_file.Contains("_rb3con.rba") ? rba_file.Replace("_rb3con.rba", "2x_rb3con.rba") : rba_file.Replace(".rba", "2x.rba");
            rba2x = rba2x.Replace("2x2x", "2x").Replace("1x", "");
            var folder = Path.GetDirectoryName(rba_file) + "\\";
            var file = Path.GetFileNameWithoutExtension(rba_file);
            extract_folder = folder + file + "_extract\\";
            UniqueID = string.IsNullOrEmpty(mMainForm.UniqueNumericID) ? mMainForm.GetNumericID() : mMainForm.UniqueNumericID;
            RBtoUSBArgs = "MagmaFile:" + rba_file.Replace(".rba", "");

            if (string.IsNullOrEmpty(build_rba))
            {
                build_rba = rba_file;
            }

            try
            {
                var kv = new RSAParams(Application.StartupPath + "\\bin\\KV.bin");
                if (!kv.Valid)
                {
                    Log("ERROR: KV.bin must be in the \\bin subdirectory.");
                }
                else
                {
                    if (mMainForm.is2XMIDI && File.Exists(build_rba))
                    {
                        if (doing2X)
                        {
                            Tools.DeleteFile(rba2x);
                            File.Copy(build_rba, rba2x);
                            rba_file = rba2x;
                            UniqueID = mMainForm.UniqueNumericID2x;
                            RBtoUSBArgs = RBtoUSBArgs + "|" + rba_file.Replace(".rba", "");
                        }
                        else
                        {
                            Tools.DeleteFile(rba1x);
                            File.Copy(build_rba, rba1x);
                            rba_file = rba1x;
                        }
                    }
                    
                    if (!File.Exists(rba_file))
                    {
                        Log("ERROR: Could not find " + rba_file);
                        Log("Stopping build here...");
                    }
                    else
                    {
                        Tools.DeleteFolder(extract_folder, true);

                        if (!Directory.Exists(extract_folder))
                        {
                            Directory.CreateDirectory(extract_folder);
                        }

                        Log("Created RBA file successfully.");
                        var format = mMainForm.doLIVE ? "LIVE" : "CON";
                        Log("Starting RBA -> " + format + " conversion...");

                        makeCON();
                        
                        if (BuiltCon)
                        {
                            if (mMainForm.KeepSongsDTA)
                            {

                                if (File.Exists(extract_folder + "songs.dta"))
                                {
                                    if (File.Exists(folder + "songs.dta"))
                                    {
                                        if (MessageBox.Show("You told me to keep the new songs.dta but there is a songs.dta file already in your song's directory. Do you want me to overwrite it?",
                                                "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                                            DialogResult.Yes)
                                        {
                                            try
                                            {
                                                Tools.DeleteFile(folder + "songs.dta");
                                                Tools.MoveFile(extract_folder + "songs.dta", folder + "songs.dta");
                                            }
                                            catch
                                            {
                                                Log("ERROR: Could not delete old songs.dta, so can't save new one. Sorry.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!Tools.MoveFile(extract_folder + "songs.dta", folder + "songs.dta"))
                                        {
                                            Log("ERROR: Could not move songs.dta, sorry.");
                                        }
                                    }
                                }
                            }
                            
                            if (!mMainForm.KeepExtracted || (mMainForm.is2XMIDI && !doing2X))
                            {
                                Tools.DeleteFolder(extract_folder, true);
                            }
                            
                            if (!mMainForm.is2XMIDI || (mMainForm.is2XMIDI && doing2X))
                            {
                                mMainForm.UpdateVersion();
                            }

                            Log("Completed RBA -> " + format + " conversion successfully.");
                            Tools.DeleteFile(rba1x);
                            Tools.DeleteFile(rba2x);

                            if (mMainForm.is2XMIDI && (!mMainForm.is2XMIDI || !doing2X)) return;
                            if (mMainForm.deleteRBAFileAfterConverting)
                            {
                                Tools.DeleteFile(build_rba);
                            }

                            Log("You should be able to put it in your Xbox and start playing right away.");
                            if (mMainForm.doLIVE)
                            {
                                Log("You chose to sign the file in LIVE format.");
                                Log("Please remember this format will NOT work on a retail console.");
                            }
                            Log("Enjoy");

                            Tools.DeleteFile(Application.StartupPath + "\\oggenc.c3");

                            if (mMainForm.WiiMode)
                            {
                                btnNautilus.Text = "Send to &Wii Converter";
                            }
                            btnNautilus.Visible = true;
                            btnVisualize.Visible = true;
                        }
                        else
                        {
                            Log("Something went wrong converting your RBA to " + format + ".");
                            Log("Please read above for any error messages.");
                            Log("Your RBA file is fine, try converting it with Nautilus in the meantime.");
                            Tools.DeleteFolder(extract_folder);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Log("Error: " + e.Message);
                Tools.DeleteFolder(extract_folder);
            }
        }

        private void makeCON()
        {
            var bConvertFolder = false;
            con_file = rba_file.Replace(".rba", "");
            Tools.DeleteFile(con_file);

            var xsession = new CreateSTFS { HeaderData = { TitleID = 0x45410914 } };
            xsession.HeaderData.Title_Package = "Rock Band 3";

            xsession.HeaderData.SetLanguage(Languages.English);
            xsession.HeaderData.Publisher = "";
            xsession.STFSType = STFSType.Type0;
            xsession.HeaderData.ThisType = mMainForm.doLIVE ? PackageType.MarketPlace : PackageType.SavedGame;
            
            var bOk = RBAExtract();
            if (bOk)
            {
                bConvertFolder = true;
            }
            if (!bConvertFolder) return;
            bOk = PackageCheckFiles(xsession);
            if (bOk)
            {
                bOk = PackageImage(xsession);
            }
            if (bOk)
            {
                bOk = PackageCreate(xsession);
            }
            if (bOk)
            {
                bOk = Tools.UnlockCON(con_file);
            }
            if (bOk && !mMainForm.doLIVE)
            {
                bOk = Tools.SignCON(con_file);
            }
            if (!bOk) return;
            BuiltCon = true;
            TextBoxBuild.Cursor = Cursors.Default;
        }

        private bool PackageCreate(CreateSTFS xsession)
        {
            var xParams = new RSAParams(StrongSigned.LIVE);

            if (mMainForm.PackageDisplay != "")
            {
                xsession.HeaderData.Title_Display = mMainForm.PackageDisplay;

                if (mMainForm.is2XMIDI && !doing2X && xsession.HeaderData.Title_Display.Contains("2x Bass Pedal"))
                {
                    xsession.HeaderData.Title_Display = xsession.HeaderData.Title_Display.Replace("(2x Bass Pedal)", "").Replace("()", "").Replace("  ", " ");
                }
                else if (mMainForm.is2XMIDI && doing2X && !xsession.HeaderData.Title_Display.Contains("2x Bass Pedal"))
                {
                    xsession.HeaderData.Title_Display = xsession.HeaderData.Title_Display.Trim() + " 2x Bass Pedal";
                }
            }
            else
            {
                var songversions = "";
                if ((mMainForm.is2XMIDI && doing2X) || (!mMainForm.is2XMIDI && mMainForm.is2xBassPedal))
                {
                    songversions = songversions + " (2x Bass Pedal)";
                }
                if (mMainForm.isRhythmOnKeys || mMainForm.isRhythmonBass)
                {
                    songversions = songversions + " (Rhythm Version)";
                }
                songversions = songversions.TrimStart();
                songversions = songversions.TrimEnd();
                if (songversions != "")
                {
                    songversions = " " + songversions;
                }
                xsession.HeaderData.Title_Display = mMainForm.Artist + " - " + mMainForm.Song + songversions;
            }
            xsession.HeaderData.Description = mMainForm.PackageDescription;
            Log("Creating song file " + Path.GetFileName(con_file) + "...");
            var xy = new STFSPackage(xsession, xParams, con_file);
            xy.FlushPackage(xParams);
            xy.CloseIO();
            return true;
        }

        private bool PackageCheckFiles(CreateSTFS xsession)
        {
            var checkOk = true;
            var folder = mMainForm.ProjectFolder;
            string[] files;

            // \songs\songs.dta (song information)
            var fnamedta = extract_folder + "songs.dta";
            if (File.Exists(fnamedta))
            {
                xsession.AddFolder("songs");
                xsession.AddFolder("songs/" + basesongname);
                xsession.AddFolder("songs/" + basesongname + "/gen");
                if (!xsession.AddFile(fnamedta, "songs/songs.dta"))
                {
                    Log("ERROR: Could not add " + fnamedta + " to package");
                    checkOk = false;
                }
            }
            else
            {
                Log("FAIL: " + fnamedta + " is not present.");
                checkOk = false;
            }
            if (checkOk)
            {
                files = Directory.GetFiles(folder, "override.mid");
                if (files.Count() != 0 && mMainForm.OverrideMIDI)
                {
                    Log("Found override MIDI file, adding that to the package.");
                    if (!xsession.AddFile(files[0],"songs/" + basesongname + "/" + basesongname + ".mid"))
                    {
                        Log("ERROR: Could not add override MIDI file to package.");
                        checkOk = false;
                    }
                }
                else
                {
                    files = Directory.GetFiles(extract_folder, "*.mid");
                    if (files.Count() != 0)
                    {
                        if (!xsession.AddFile(files[0], "songs/" + basesongname + "/" + basesongname + ".mid"))
                        {
                            Log("ERROR: Could not add MIDI file to package.");
                            checkOk = false;
                        }
                    }
                }
            }

            if (checkOk)
            {
                files = Directory.GetFiles(folder, "*.mogg");
                if (files.Count() != 0 && mMainForm.OverrideMogg)
                {
                    if (files.Count() > 1)
                    {
                        var selector = new FileSelector(this, folder, ".mogg");
                        selector.ShowDialog();
                    }
                    else
                    {
                        ChosenFile = files[0];
                    }
                    Log("Found override *.mogg file, adding that to the package.");                    
                    if (!xsession.AddFile(ChosenFile, "songs/" + basesongname + "/" + basesongname + ".mogg"))
                    {
                        Log("ERROR: Could not add override mogg file to package.");
                        checkOk = false;
                    }
                }
                else
                {
                    files = Directory.GetFiles(extract_folder, "*.mogg");
                    if (files.Count() != 0)                    {
                        
                        if (!xsession.AddFile(files[0], "songs/" + basesongname + "/" + basesongname + ".mogg"))
                        {
                            Log("ERROR: Could not add mogg file to package.");
                            checkOk = false;
                        }
                    }
                }
            }

            if (checkOk)
            {
                files = Directory.GetFiles(folder, "*.milo_xbox");
                if (files.Count() != 0 && mMainForm.OverrideMilo)
                {
                    if (files.Count() > 1)
                    {
                        var selector = new FileSelector(this, folder, ".milo_xbox");
                        selector.ShowDialog();
                    }
                    else
                    {
                        ChosenFile = files[0];
                    }
                    Log("Found override *.milo_xbox file, adding that to the package.");
                    if (!xsession.AddFile(ChosenFile, "songs/" + basesongname + "/gen/" + basesongname + ".milo_xbox"))
                    {
                        Log("ERROR: Could not add override milo file to package.");
                        checkOk = false;
                    }
                }
                else
                {
                    files = Directory.GetFiles(extract_folder, "*.milo_xbox");
                    if (files.Count() != 0)
                    {
                        if (!xsession.AddFile(files[0], "songs/" + basesongname + "/gen/" + basesongname + ".milo_xbox"))
                        {
                            Log("ERROR: Could not add milo file to package.");
                            checkOk = false;
                        }
                    }
                }
            }

            if (!checkOk) return false;
            files = Directory.GetFiles(folder, "*.png_xbox");
            if (files.Count() != 0 && mMainForm.OverrideArt)
            {
                if (files.Count() > 1)
                {
                    var selector = new FileSelector(this, folder, ".png_xbox");
                    selector.ShowDialog();
                }
                else
                {
                    ChosenFile = files[0];
                }
                Log("Found override *.png_xbox file, adding that to the package.");
                if (xsession.AddFile(ChosenFile, "songs/" + basesongname + "/gen/" + basesongname + "_keep.png_xbox")) return true;
                Log("ERROR: Could not add override album art to package.");
               return false;
            }
            files = Directory.GetFiles(extract_folder, "*.png_xbox.");
            if (!files.Any()) return true;
            if (xsession.AddFile(files[0], "songs/" + basesongname + "/gen/" + basesongname + "_keep.png_xbox")) return true;
            Log("ERROR: Could not add album art to package.");
            return false;
        }

        private bool RBAExtract()
        {
            bool rc;
            var newrba = "";
            var folder = Path.GetDirectoryName(rba_file) + "\\";

            basesongname = Path.GetFileNameWithoutExtension(rba_file).Replace("_rb3con", "").Replace("v#", "").Trim().ToLowerInvariant();
            if (basesongname.Contains(" "))
            {
                basesongname = basesongname.Replace(" ", "");
                Log("ERROR: RBA file has one or more spaces in the name. We can't allow that.");
                Log("Trying to rename the RBA file to comply...");

                newrba = folder + basesongname;
                if (Tools.MoveFile(rba_file, newrba))
                {
                    Log("Renamed file successfully from: " + rba_file + " to " + newrba);
                }
                else
                {
                    Log("Failed to rename file, there may be errors...");
                    Log("Next time, name your project and RBA files without spaces!");
                    newrba = rba_file;
                }
            }
            try
            {
                rc = RBAExtractFiles();
                if (rc)
                {
                    rc = RBAPatchSongsDta();
                }
                if (rc)
                {
                    rc = RBABmpFix();
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Log("Error extracting RBA " + newrba + ": " + e.Message);
                Tools.DeleteFolder(extract_folder);
                rc = false;
            }
            return (rc);
        }

        private bool PackageImage(CreateSTFS xsession)
        {
            bool rc;
            try
            {
                byte[] i1;
                string thumb;
                if (mMainForm.PackageThumb != "")
                {
                    if (File.Exists(mMainForm.PackageThumb))
                    {
                        thumb = mMainForm.PackageThumb;
                    }
                    else if (
                        File.Exists(Path.GetDirectoryName(mMainForm.ProjectFile.GetFilename()) + "\\" +
                                    Path.GetFileName(mMainForm.PackageThumb)))
                    {
                        thumb = Path.GetDirectoryName(mMainForm.ProjectFile.GetFilename()) + "\\" +
                                Path.GetFileName(mMainForm.PackageThumb);
                    }
                    else
                    {
                        thumb = extract_folder + basesongname + ".png";
                    }
                }
                else
                {
                    thumb = extract_folder + basesongname + ".png";
                }
                if (mMainForm.PackageThumb == "rb3")
                {
                    i1 = Resources.ContentImage.ImageToBytes(ImageFormat.Png);
                }
                else if (thumb != "" && File.Exists(thumb))
                {
                    var pngbitmap = Tools.NemoLoadImage(thumb);
                    i1 = pngbitmap.ImageToBytes(ImageFormat.Png);
                }
                else
                {
                    // If there is no icon file, just use the stock RB3 icon
                    i1 = Resources.ContentImage.ImageToBytes(ImageFormat.Png);
                }    
                xsession.HeaderData.PackageImageBinary = i1;
                // Use the stock RB3 icon as the content image 
                xsession.HeaderData.ContentImageBinary = Resources.ContentImage.ImageToBytes(ImageFormat.Png);
                rc = true;
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Log("Error in PackageImage:" + e.Message);
                rc = false;
            }
            return rc;
        }

        private static void ShowToast(string message)
        {
            var toast = new frmToast(message, MousePosition);
            toast.Show();
        }

        private bool RBAPatchSongsDta()
        {
            bool rc;
            var fsongsraw = extract_folder + "songs.dta.raw";
            var fsongsdta = extract_folder + "songs.dta";

            try
            {
                // Create an instance of StreamReader to read from a file.
                using (var srSongsRaw = new StreamReader(fsongsraw, Encoding.Default))
                {
                    var swSongsDta = new StreamWriter(fsongsdta, false, mMainForm.FileEncoding);
                    using (swSongsDta)
                    {
                        // copy the first line
                        var line = srSongsRaw.ReadLine();
                        swSongsDta.WriteLine(line);
                        var songid = (mMainForm.useCustomID ? mMainForm.CustomID : mMainForm.SongID).Replace("_rb3con","");
                        if (string.IsNullOrEmpty(songid))
                        {
                            songid = basesongname;
                        }
                        if (mMainForm.is2XMIDI)
                        {
                            songid = songid + (doing2X ? "2x" : "1x");
                        }
                        if (mMainForm.appendVersiontoID)
                        {
                            songid = songid + "v" + mMainForm.SongVersion;
                        }
                        var newid2x = new SongIDCorrector();
                        // patch 'song' in the second line to be '<basename>'
                        line = srSongsRaw.ReadLine();
                        if (line != null && line.Contains("'song'"))
                        {
                            line = "   '" + songid + "'";
                            swSongsDta.WriteLine(line);
                        }

                        // Read and display lines from the file until the end of
                        // the file is reached.
                        while ((line = srSongsRaw.ReadLine()) != null)
                        {
                            if (line.Contains("'name'"))
                            {
                                swSongsDta.WriteLine(line);
                                line = srSongsRaw.ReadLine();

                                if (line != null && !line.Contains("songs/song/song"))
                                {
                                    if (mMainForm.is2xBassPedal || mMainForm.isRhythmOnKeys || mMainForm.isRhythmonBass)
                                    {
                                        line = "      \"" + mMainForm.Song.Replace("\"","\\q");
                                        
                                        if ((mMainForm.is2XMIDI && doing2X) || (!mMainForm.is2XMIDI && mMainForm.is2xBassPedal))
                                        {
                                            if (!line.Contains("2x Bass Pedal"))
                                            {
                                                line = line + " (2x Bass Pedal)";
                                            }
                                        }
                                        if (mMainForm.isRhythmOnKeys || mMainForm.isRhythmonBass)
                                        {
                                            line = line + " (Rhythm Version)";
                                        }

                                        line = line + "\"";
                                    }
                                    else
                                    {
                                        line = "      \"" + mMainForm.Song.Replace("\"", "\\q") + "\"";
                                    }
                                }
                                // -          "songs/song/song" => "songs/<basename>/<basename"
                                if (line != null && line.Contains("songs/song/song"))
                                {
                                    line = "         \"songs/" + basesongname + "/" + basesongname + "\"";
                                }

                                swSongsDta.WriteLine(line);
                                line = "";
                            }
                            else if (line.Contains("'artist'"))
                            {
                                swSongsDta.WriteLine(line);
                                srSongsRaw.ReadLine();
                                line = "      \"" + mMainForm.Artist.Replace("\"", "\\q") + "\"";
                                swSongsDta.WriteLine(line);
                                line = "";
                            }
                            else if (line.Contains("'album_name'"))
                            {
                                swSongsDta.WriteLine(line);
                                srSongsRaw.ReadLine();
                                line = "      \"" + mMainForm.Album.Replace("\"", "\\q") + "\"";
                                swSongsDta.WriteLine(line);
                                line = "";
                            }                            
                            else if (line.Contains("('song_id' 0)"))
                            {
                                //This is a check to generate it again based on the new shortname (2x)
                                if ((mMainForm.is2XMIDI && doing2X) || (!mMainForm.is2XMIDI && mMainForm.is2xBassPedal))
                                { 
                                    line = "   ('song_id' " + newid2x.ShortnameToSongID(songid) + ")";
                                }
                                else
                                    line = "   ('song_id' " + (mMainForm.useNumericID ? UniqueID.ToString() : songid) + ")";
                                if (!string.IsNullOrEmpty(mMainForm.InstrumentSolos))
                                {
                                    swSongsDta.WriteLine(line);
                                    line = "   " + mMainForm.InstrumentSolos;
                                }
                            }                            
                            else if (line.Contains("tracks_count") && mMainForm.CrowdAudio != "")
                            {
                                swSongsDta.WriteLine();
                                line = srSongsRaw.ReadLine();
                                line = line.Replace(")", " 2)");
                                swSongsDta.WriteLine(line);
                                line = "";
                            }
                            else if (line.Contains("sub_genre") && mMainForm.doRemoveSubgenre)
                            {
                                line = "";
                            }
                            else if (line.Contains("pans") && mMainForm.CrowdAudio != "")
                            {
                                swSongsDta.WriteLine(line);
                                line = srSongsRaw.ReadLine();
                                line = line.Replace(")", " -2.50 2.50)");
                                swSongsDta.WriteLine(line);
                                line = "";
                            }
                            else if (line.Contains("vols") && mMainForm.CrowdAudio != "")
                            {
                                swSongsDta.WriteLine(line);
                                line = srSongsRaw.ReadLine();
                                line = line.Replace(")", " " + Decimal.Round(mMainForm.CrowdVol,2) + " " + Decimal.Round(mMainForm.CrowdVol,2) + ")");
                                swSongsDta.WriteLine(line);
                                line = "";
                            }
                            else if (line.Contains("cores") && mMainForm.CrowdAudio != "")
                            {
                                swSongsDta.WriteLine(line);
                                line = srSongsRaw.ReadLine();
                                line = line.Replace(")", " -1 -1)");
                                var channels = line.Replace("(", "");
                                channels = channels.Replace(")", "");
                                channels = channels.Replace(" ", "");
                                channels = channels.Replace("-", "");
                                swSongsDta.WriteLine(line);
                                line = srSongsRaw.ReadLine();
                                swSongsDta.WriteLine(line);
                                swSongsDta.WriteLine("   ('crowd_channels' " + (channels.Count() - 2) + " " + (channels.Count() - 1) + ")");
                                line = "";
                            }
                            else if (line.Contains("'rank'"))
                            {
                                swSongsDta.WriteLine(line);
                                srSongsRaw.ReadLine();
                                swSongsDta.WriteLine("   ('drum' " + mMainForm.difficultyDrums + ")");
                                srSongsRaw.ReadLine();
                                swSongsDta.WriteLine("   ('guitar' " + mMainForm.difficultyGuitar + ")");
                                srSongsRaw.ReadLine();
                                swSongsDta.WriteLine("   ('bass' " + mMainForm.difficultyBass + ")");
                                srSongsRaw.ReadLine();
                                swSongsDta.WriteLine("   ('vocals' " + mMainForm.difficultyVocals + ")");
                                srSongsRaw.ReadLine();
                                swSongsDta.WriteLine("   ('keys' " + mMainForm.difficultyKeys + ")");
                                srSongsRaw.ReadLine();
                                swSongsDta.WriteLine("   ('real_keys' " + mMainForm.difficultyProKeys + ")");
                                srSongsRaw.ReadLine();
                                if (mMainForm.difficultyProGuitar > 0)
                                {
                                    swSongsDta.WriteLine("   ('real_guitar' " + mMainForm.difficultyProGuitar + ")");
                                }
                                srSongsRaw.ReadLine();
                                if (mMainForm.difficultyProBass > 0)
                                {
                                    swSongsDta.WriteLine("   ('real_bass' " + mMainForm.difficultyProBass + ")");
                                }
                                srSongsRaw.ReadLine();
                                swSongsDta.WriteLine("   ('band' " + mMainForm.difficultyBand + ")");
                                line = "";
                            }
                            else if (line.Contains("encoding"))
                            {
                                var bandFails = new List<string>()
                                {
                                    "band_fail_electro.cue", 
                                    "band_fail_electro_keys.cue", 
                                    "band_fail_heavy.cue",
                                    "band_fail_heavy_keys.cue", 
                                    "band_fail_rock.cue", 
                                    "band_fail_rock_keys.cue",
                                    "band_fail_vintage.cue", 
                                    "band_fail_vintage_keys.cue"
                                };
                                swSongsDta.WriteLine("   (band_fail_cue " + bandFails[mMainForm.bandFailIndex] + ")");
                                line = "   ('encoding' '" + mMainForm.Encoding + "')";
                            }                            
                            else if (line.Contains("'tuning_offset_cents' 0.00)"))
                            {
                                line = line.Replace("0.00", mMainForm.TuningCents.ToString(CultureInfo.InvariantCulture));
                            }
                            else if (line.Contains("('master' 1)") && mMainForm.IsMaster != 1)
                            {
                                line = line.Replace("1", "0");
                            }
                            else if (line.Contains("('rating' 4)") && mMainForm.SongRating != 4)
                            {
                                line = line.Replace("4", mMainForm.SongRating.ToString(CultureInfo.InvariantCulture));
                            }
                            else if (line.Contains("('year_released'") && mMainForm.isReRecord)
                            {
                                swSongsDta.WriteLine("   ('year_recorded' " + mMainForm.yearReRecord + ")");
                                swSongsDta.WriteLine(line);

                                line = "";     
                            }
                            else if (line.Contains("('anim_tempo'"))
                            {
                                switch (mMainForm.DrumSFX)
                                {
                                    case 0:
                                        swSongsDta.WriteLine("   (drum_bank sfx/kit01_bank.milo)"); //Hard Rock Kit (default)
                                        break;
                                    case 1:
                                        swSongsDta.WriteLine("   (drum_bank sfx/kit02_bank.milo)"); //Arena Kit
                                        break;
                                    case 2:
                                        swSongsDta.WriteLine("   (drum_bank sfx/kit03_bank.milo)"); //Vintage Kit
                                        break;
                                    case 3:
                                        swSongsDta.WriteLine("   (drum_bank sfx/kit04_bank.milo)"); //Trashy Kit
                                        break;
                                    case 4:
                                        swSongsDta.WriteLine("   (drum_bank sfx/kit05_bank.milo)"); //Electronic Kit
                                        break;
                                    default:
                                        swSongsDta.WriteLine("   (drum_bank sfx/kit01_bank.milo)");
                                        break;
                                }
                                swSongsDta.WriteLine("   ('anim_tempo' " + mMainForm.animTempo + ")");
                                line = "";
                            }
                            else if (line.Contains("'preview'") && mMainForm.SongPreview != 0)
                            {
                                line = "   ('preview' " + mMainForm.SongPreview + " " + mMainForm.PreviewEnd + ")";
                            }
                            else if (line.Contains("'drum_freestyle'"))
                            {
                                swSongsDta.WriteLine(line);
                                line = srSongsRaw.ReadLine();
                                swSongsDta.WriteLine(line);
                                line = srSongsRaw.ReadLine();
                                swSongsDta.WriteLine(line);
                                line = srSongsRaw.ReadLine();
                                swSongsDta.WriteLine(line);
                                line = srSongsRaw.ReadLine();
                                swSongsDta.WriteLine(line);
                                line = srSongsRaw.ReadLine();
                                swSongsDta.WriteLine(line);
                                swSongsDta.WriteLine("      (mute_volume " + mMainForm.MuteVol + ")");
                                swSongsDta.WriteLine("      (mute_volume_vocals " + mMainForm.VocalMuteVol + ")");
                                
                                int hopovalue;
                                switch (mMainForm.HopoValue)
                                {
                                    case 0:
                                        hopovalue = 90;
                                        break;
                                    case 1:
                                        hopovalue = 130;
                                        break;
                                    case 2:
                                        hopovalue = 170;
                                        break;
                                    case 3:
                                        hopovalue = 250;
                                        break;
                                    default:
                                        hopovalue = 170;
                                        break;
                                }
                                swSongsDta.WriteLine("      (hopo_threshold " + hopovalue + ")");
                                line = "";
                            }
                            else if (line == ")")
                            {
                                if (mMainForm.AuthorDTA && !string.IsNullOrEmpty(mMainForm.SongAuthor))
                                {
                                    swSongsDta.WriteLine("   (author \"" + mMainForm.SongAuthor + "\")");
                                }
                                if (mMainForm.EnableTonic && mMainForm.TonicNote != -1)
                                {
                                    swSongsDta.WriteLine("   (vocal_tonic_note " + mMainForm.TonicNote + ")");
                                    if (mMainForm.doTonality)
                                    {
                                        swSongsDta.WriteLine("   (song_tonality " + mMainForm.songTonality + ")");
                                    }
                                }
                                if (mMainForm.HasProGuitar && mMainForm.ProGuitarDiff != 0)
                                {
                                    swSongsDta.WriteLine("   " + mMainForm.GuitarTuning);
                                }
                                if (mMainForm.HasProBass && mMainForm.ProBassDiff != 0)
                                {
                                    swSongsDta.WriteLine("   " + mMainForm.BassTuning);
                                }
                                swSongsDta.WriteLine("");
                                swSongsDta.WriteLine(";DO NOT EDIT THE FOLLOWING LINES MANUALLY");
                                swSongsDta.WriteLine(";Created using " + mMainForm.mAppTitle + mMainForm.mAppVersion);
                                swSongsDta.WriteLine(";Song authored by " + mMainForm.SongAuthor);
                                swSongsDta.WriteLine(";Song=" + mMainForm.Song);
                                if (mMainForm.useCustomID)
                                {
                                    swSongsDta.WriteLine(";CustomID=" + mMainForm.CustomID);
                                }
                                swSongsDta.WriteLine(";Language(s)=" + mMainForm.Language);
                                swSongsDta.WriteLine(";Karaoke=" + Convert.ToInt16(mMainForm.isKaraoke));
                                swSongsDta.WriteLine(";Multitrack=" + Convert.ToInt16(mMainForm.isMultitrack));
                                swSongsDta.WriteLine(";DIYStems=" + Convert.ToInt16(mMainForm.isDIYStems));
                                swSongsDta.WriteLine(";PartialMultitrack=" + Convert.ToInt16(mMainForm.isPartialMultitrack));
                                swSongsDta.WriteLine(";UnpitchedVocals=" + Convert.ToInt16(mMainForm.isUnpitchedVocals));
                                swSongsDta.WriteLine(";Convert=" + Convert.ToInt16(mMainForm.isConvert));
                                swSongsDta.WriteLine(";2xBass=" + (Convert.ToInt16((mMainForm.is2xBassPedal && !mMainForm.is2XMIDI)|| (mMainForm.is2XMIDI && doing2X))));
                                swSongsDta.WriteLine(";RhythmKeys=" + Convert.ToInt16(mMainForm.isRhythmOnKeys));
                                swSongsDta.WriteLine(";RhythmBass=" + Convert.ToInt16(mMainForm.isRhythmonBass));
                                swSongsDta.WriteLine(";CATemh=" + Convert.ToInt16(mMainForm.isCATEMH));
                                swSongsDta.WriteLine(";ExpertOnly=" + Convert.ToInt16(mMainForm.isXOnly));
                                swSongsDta.WriteLine(")");
                                break;
                            }
                            else if (line.Contains("real_keys") && mMainForm.disableProKeys)
                            {
                                line = "      ('real_keys' 0)";
                            }
                            if (line != "")
                            {
                                swSongsDta.WriteLine(line);
                            }
                            if (srSongsRaw.EndOfStream)
                            {
                                break;
                            }
                        }
                    }
                    swSongsDta.Dispose();
                    srSongsRaw.Dispose();
                }
                rc = true;
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Log("Error patching songs.dta in " + extract_folder + ": " + e.Message);
                Tools.DeleteFolder(extract_folder);
                rc = false;
            }
            return (rc);
        }

        private bool RBAExtractFiles()
        {
            bool rc;
            var rbafilename = rba_file;
            try
            {
                using (var bReadRba = new BinaryReader(File.Open(rbafilename, FileMode.Open)))
                {
                    // Validate the RBA file header
                    var signature = bReadRba.ReadChars(4);
                    if ((signature[0] != 'R') ||
                        (signature[1] != 'B') ||
                        (signature[2] != 'S') ||
                        (signature[3] != 'F'))
                    {
                        Log("ERROR: RBA file " + rbafilename + " starts with an invalid signature.");
                    }
                    var rba_header_values = new int[(int)RBA_HEADER_INDEX.HEADER_INDEX_COUNT];
                    for (var i = 0; i < (int)RBA_HEADER_INDEX.HEADER_INDEX_COUNT; i++)
                    {
                        var v = bReadRba.ReadInt32();
                        rba_header_values[i] = v;
                    }
                    if (rba_header_values[(int)RBA_HEADER_INDEX.OFFSET_SONGS_DTA] != 0)
                    {
                        var offset = rba_header_values[(int)RBA_HEADER_INDEX.OFFSET_SONGS_DTA];
                        var len = rba_header_values[(int)RBA_HEADER_INDEX.LENGTH_SONGS_DTA];
                        bReadRba.BaseStream.Seek(offset, SeekOrigin.Begin);
                        var data = bReadRba.ReadBytes(len);
                        var fname = extract_folder + "songs.dta.raw";
                        using (var bWrite = new BinaryWriter(File.Open(fname, FileMode.Create)))
                        {
                            bWrite.Write(data);
                            bWrite.Dispose();
                        }
                    }
                    if (rba_header_values[(int)RBA_HEADER_INDEX.OFFSET_MID] != 0)
                    {
                        var offset = rba_header_values[(int)RBA_HEADER_INDEX.OFFSET_MID];
                        var len = rba_header_values[(int)RBA_HEADER_INDEX.LENGTH_MID];
                        bReadRba.BaseStream.Seek(offset, SeekOrigin.Begin);
                        var data = bReadRba.ReadBytes(len);
                        var fname = extract_folder + basesongname + ".mid";
                        using (var bWrite = new BinaryWriter(File.Open(fname, FileMode.Create)))
                        {
                            bWrite.Write(data);
                            bWrite.Dispose();
                        }
                    }
                    if (rba_header_values[(int)RBA_HEADER_INDEX.OFFSET_MOGG] != 0)
                    {
                        var offset = rba_header_values[(int)RBA_HEADER_INDEX.OFFSET_MOGG];
                        var len = rba_header_values[(int)RBA_HEADER_INDEX.LENGTH_MOGG];
                        bReadRba.BaseStream.Seek(offset, SeekOrigin.Begin);
                        var data = bReadRba.ReadBytes(len);
                        var fname = extract_folder + basesongname + ".mogg";
                        using (var bWrite = new BinaryWriter(File.Open(fname, FileMode.Create)))
                        {
                            bWrite.Write(data);
                            bWrite.Dispose();
                        }
                    }
                    if (rba_header_values[(int)RBA_HEADER_INDEX.OFFSET_MILO_XBOX] != 0)
                    {
                        var offset = rba_header_values[(int)RBA_HEADER_INDEX.OFFSET_MILO_XBOX];
                        var len = rba_header_values[(int)RBA_HEADER_INDEX.LENGTH_MILO_XBOX];
                        bReadRba.BaseStream.Seek(offset, SeekOrigin.Begin);
                        var data = bReadRba.ReadBytes(len);
                        var fname = extract_folder + basesongname + ".milo_xbox";
                        using (var bWrite = new BinaryWriter(File.Open(fname, FileMode.Create)))
                        {
                            bWrite.Write(data);
                            bWrite.Dispose();
                        }
                    }
                    if (rba_header_values[(int)RBA_HEADER_INDEX.OFFSET_BMP] != 0)
                    {
                        var offset = rba_header_values[(int)RBA_HEADER_INDEX.OFFSET_BMP];
                        var len = rba_header_values[(int)RBA_HEADER_INDEX.LENGTH_BMP];
                        bReadRba.BaseStream.Seek(offset, SeekOrigin.Begin);
                        var data = bReadRba.ReadBytes(len);
                        var fname = extract_folder + basesongname + ".bmp";
                        using (var bWrite = new BinaryWriter(File.Open(fname, FileMode.Create)))
                        {
                            bWrite.Write(data);
                            bWrite.Dispose();
                        }
                    }
                    bReadRba.Dispose();
                    rc = true;
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Log("Error extracting the RBA file: " + e.Message);
                Tools.DeleteFolder(extract_folder);
                rc = false;
            }
            return (rc);
        }

        private bool RBABmpFix()
        {
            var bmpfile = extract_folder + basesongname + ".bmp";
            var xboximagefile = extract_folder + basesongname + "_keep.png_xbox";
            //HAS to be 256x256 because that will always be the input from the RBA
            //hopefully they follow instructions and this won't be needed, and instead we use override 512x512 texture
            Tools.TextureSize = 256; 
            var rc = Tools.ConvertImagetoRB(bmpfile, xboximagefile);
            if (rc)
            {
                rc = Tools.ResizeImage(bmpfile, 64, "png", bmpfile);
            }
            return rc;
        }

        private void Log(string str)
        {
            if (str.Contains("src\\rbnvalidator")) return;
            if (str.Contains("SystemInit Params")) return;
            TextBoxBuild.Text = TextBoxBuild.Text + str.Replace("\n", "\r\n") + Environment.NewLine;
            if (str.Contains("Cannot parse event"))
            {
                TextBoxBuild.Text = TextBoxBuild.Text + "You can fix this by running the MIDI through Nautilus' MIDI " +
                                    "Cleaner or by using 'Remove invalid markers' in C3 Automation Tools from REAPER before " +
                                    "exporting your MIDI." + Environment.NewLine;
            }
            else if (str.Contains("less than 2 beats from the beginning"))
            {
                TextBoxBuild.Text = TextBoxBuild.Text + "Make sure you have notes for the entire BEAT track, not just at the beginning, " +
                                    "and that you have at least two notes in the BEAT track before this point." + Environment.NewLine;
            }
            else if (str.Contains("Confused by vocal phrase overlap"))
            {
                TextBoxBuild.Text = TextBoxBuild.Text + "This means you probably have a very short vocal phrase marker somewhere, zoom " +
                                    "in on your project and check all your vocal phrase markers." + Environment.NewLine;
            }
            else if (str.Contains("No gems between overdrive phrases"))
            {
                TextBoxBuild.Text = TextBoxBuild.Text + "You can't have an overdrive phrase followed by an overdrive phrase without any " +
                                    "playable notes in between, add some notes between the overdrive phrases listed above." + Environment.NewLine;
            }
            else if (str.Contains("mKeyboardRangeSecondPitch == -1"))
            {
                TextBoxBuild.Text = TextBoxBuild.Text + "This means you didn't author Pro Keys but left the track in the MIDI - you must mute " +
                                    "unauthored tracks in REAPER before exporting." + Environment.NewLine;
            }
            else if (str.Contains("drum mix") && str.Contains("supports exactly"))
            {
                TextBoxBuild.Text = TextBoxBuild.Text + "This happens when the drums mix events at the start of your drums chart don't match the " +
                                    "audio files you gave to Magma.  Either let Magma do this for you by enabling 'Add to MIDI' in the Recommended Drum " +
                                    "Mix section in the Audio Tab, or read the authoring documents for the correct drum mix. Most users should not modify " +
                                    "the default in the C3 template)." + Environment.NewLine;
            }
            else if (str.Contains("velocity <= 127"))
            {
                TextBoxBuild.Text = TextBoxBuild.Text + "This means you somehow changed the note velocities to a value that is not allowed. Change the note " +
                                    "velocities to a value like 96 or 100 in REAPER." + Environment.NewLine;
            }
            else if (str.Contains("Chord gems do not start simultaneously"))
            {
                TextBoxBuild.Text = TextBoxBuild.Text + "Rock Band 3 does not support broken chords like Guitar Hero. You either have chords with notes " +
                                    "starting at different times, or one note that runs too long and over the next note. Zoom in real close in REAPER and " +
                                    "you'll see it." + Environment.NewLine;  
            }
            else if (str.Contains("Time division must be 480 ticks per quarter"))
            {
                TextBoxBuild.Text = TextBoxBuild.Text + "This is a setting in REAPER that you somehow changed. Install the RBN Authoring Tools and this will " +
                                    "reset the value in REAPER or find the setting manually and set it back to 480." + Environment.NewLine; 
            }
            else if (str.Contains("Multiple tracks share the name"))
            {
                var index = str.IndexOf("PART", StringComparison.Ordinal);
                var name = str.Substring(index, str.Length - index).Trim();
                TextBoxBuild.Text = TextBoxBuild.Text + "Your MIDI file has more than one instance of the track name '" + name + "'. Yes, yes it does. Make " +
                                    "sure that the first event for each track is a TRACK NAME event and you don't have repeated names. You may have one " +
                                    "track on top of another and you can't tell, so move them around in REAPER to find the offending track. It's there. " +
                                    "Look for it. Trust me, I'm a computer program." + Environment.NewLine; 
            }
            else if (str.Contains("Empty track found"))
            {
                var index1 = str.IndexOf("PART", StringComparison.Ordinal);
                var index2 = str.IndexOf(":", index1, StringComparison.Ordinal);
                var name = str.Substring(index1, index2 - index1);
                TextBoxBuild.Text = TextBoxBuild.Text + "This means that at least one of the difficulties for " + name + " has no notes charted - you have to add " +
                                    "something or MagmaCompiler will refuse to compile the song." + Environment.NewLine;
            }
            TextBoxBuild.SelectionStart = TextBoxBuild.TextLength;
            TextBoxBuild.ScrollToCaret();
        }

        private void Log(IEnumerable<string> arrayStr)
        {
            foreach (var t in arrayStr)
            {
                Log(t);
            }
        }

        private void SetCloseButtonState(CloseButtonState state)
        {
            if (mCloseButtonState == state)
                return;
            mCloseButtonState = state;
            switch (mCloseButtonState)
            {
                case CloseButtonState.kClose:
                    if (mRunner != null && mRunner.IsRunning)
                    {
                        UGCDebug.Notify("Tried to change button to close state, but external app still running!");
                        break;
                    }
                    ButtonClose.Text = "CLOSE";
                    break;
                case CloseButtonState.kCancel:
                    ButtonClose.Text = "CANCEL";
                    break;
                default:
                    UGCDebug.Fail("SetCloseButtonState called with CloseButtonState of " + state);
                    break;
            }
            if (TextBoxBuild.Text.ToLowerInvariant().Contains("error"))
            {
                btnClipboard.Visible = true;
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            switch (mCloseButtonState)
            {
                case CloseButtonState.kClose:
                    var audio = Directory.GetFiles(Path.GetDirectoryName(rba_file), "*.rbdeps");
                    if (audio.Any())
                    {
                        Tools.DeleteFile(audio[0]);
                        Tools.DeleteFile(audio[0] + ".new");
                    }
                    Close();
                    break;
                case CloseButtonState.kCancel:
                    if (mRunner == null)
                        break;
                    mRunner.Poll();
                    if (!mRunner.IsRunning)
                        break;
                    Log("CANCELING BUILD...");
                    UserCancelled = true;
                    mRunner.SendMutexBreak();
                    Cursor = Cursors.WaitCursor;
                    TextBoxBuild.Cursor = Cursors.AppStarting;
                    break;
            }
        }

        private void StartBuild()
        {
            TextBoxBuild.Cursor = Cursors.WaitCursor;
            Log(mMainForm.mAppTitle + mMainForm.mAppVersion);
            Log("=============================");
            UserCancelled = false;

            SetCloseButtonState(CloseButtonState.kClose);
            if (!mMainForm.ProjectFile.HasFilename())
            {
                Log("You must save your project before you can build.");
                Log("Build aborted.");
                TextBoxBuild.Cursor = Cursors.Default;
                mInternalError = true;
            }
            else
            {
                var destinationFile = mMainForm.ProjectFile.DestinationFile;
                string strErr;
                if (!PathUtl.ValidateDirectory(ref destinationFile, "", "", out strErr))
                {
                    Log("Output file or path is invalid: " + strErr);
                    Log("Build aborted.");
                    TextBoxBuild.Cursor = Cursors.Default;
                    mInternalError = true;
                }
                else
                {
                    if (mMainForm.ProjectFile.HasUnsavedChanges())
                    {
                        try
                        {
                            Log("Saving unsaved changes before build.");
                            mMainForm.ProjectFile.WriteFile();
                            mMainForm.RefreshWindowTitle();
                        }
                        catch (MagmaException)
                        {
                            Log("Error saving unsaved changes, please make sure the file is not read-only.");
                            Log("Build aborted.");
                            TextBoxBuild.Cursor = Cursors.Default;
                            mInternalError = true;
                            return;
                        }
                    }
                    SetCloseButtonState(CloseButtonState.kCancel);
                    Log("Build started at " + DateTime.Now.ToShortTimeString());
                    mList.Clear();

                    if (mMainForm.EncodingQuality >= 1 && mMainForm.EncodingQuality <= 10)
                    {
                        //save encoding quality info
                        try
                        {
                            var sw = new StreamWriter(Application.StartupPath + "\\oggenc.c3", false, System.Text.Encoding.Default);
                            sw.WriteLine(mMainForm.EncodingQuality);

                            if (mMainForm.CrowdAudio!="")
                            {
                                sw.WriteLine(mMainForm.CrowdAudio);
                            }
                            sw.Dispose();
                        }
                        catch
                        {
                            Log("Error saving encoding quality indicator ... will use default (3).");
                        }
                    }

                    if (!mMainForm.BypassNemo)
                    {
                        Log("\nStarting Nemo's MIDI Validator...");
                        var success = Tools.MidiIsClean(mMainForm.ProjectFile.MidiFile,mMainForm.ProjectFile.RankProKeys > 1,mMainForm.HasProBass || mMainForm.HasProGuitar);
                        if (!success)
                        {
                            Log(Tools.MIDI_ERROR_MESSAGE.Substring(1, Tools.MIDI_ERROR_MESSAGE.Length - 1));
                            Log("There were errors found in the MIDI file ... stopping here.");
                            TextBoxBuild.Cursor = Cursors.Default;
                            mInternalError = true;
                            SetCloseButtonState(CloseButtonState.kClose);
                            return;
                        }
                        Log("Everything looks good, continuing...");
                    }
                    else
                    {
                        Log("Bypassing Nemo's MIDI Validator based on your settings.");
                        Log("You can enable the MIDI Validator under Options -> ADVANCED SETTINGS");
                    }

                    originalMIDI = "";
                    if (mMainForm.is2XMIDI)
                    {
                        if (Tools.Separate2XMidi(mMainForm.ProjectFile.MidiFile))
                        {
                            originalMIDI = mMainForm.ProjectFile.MidiFile;

                            Log("MIDI file contains 2X Bass Pedal track.");
                            Log("Two files will be created, one with each drum track enabled.");
                            doing2X = false;
                            Log("Compiling 1X Bass Pedal MIDI...");
                            mMainForm.ProjectFile.MidiFile = Tools.MIDI1X;
                            mMainForm.ProjectFile.WriteFile();
                            SendtoCompiler();
                        }
                        else
                        {
                            doing2X = false;
                            SendtoCompiler();
                        }
                    }
                    else
                    {
                        doing2X = false;
                        SendtoCompiler();
                    }
                }
            }
        }
        
        private void SendtoCompiler()
        {
            if (mMainForm.GenDrumsMix || mMainForm.GenKeysAnim || mMainForm.GenProKeys)
            {
                Log(Tools.MIDIAutoGen(mMainForm.ProjectFile.MidiFile, mMainForm.DrumMixText, mMainForm.GenKeysAnim, mMainForm.GenProKeys, mMainForm.GenDrumsMix));
            }
            Log("\nLoading " + mMainForm.ProjectCompiler + "...");

            mRunner = new ThreadRunner();
            mRunner.SetStringList(mList);
            mRunner.SetWorkingDirectory(Application.StartupPath);
            mRunner.SetAppName(Application.StartupPath + "\\" + mMainForm.ProjectCompiler);
            mRunner.AddAppArgs("-have_lock \"" + mMainForm.ProjectFile.GetFilename() + "\" \"" + mMainForm.ProjectFile.DestinationFile + "\"");
            mRunner.EnableMutexBreak();
            mMainForm.ProjectFile.Unlock();
            mRunner.Start();
            mTimer.Start();
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            Log(mList.GetStrings());
            mRunner.Poll();
            if (mRunner.IsRunning)
            {
                return;
            }
            mTimer.Stop();

            mLastExitCode = mRunner.GetExitCode();
            try
            {
                mMainForm.ProjectFile.Lock();
            }
            catch
            {
                UGCDebug.ShowOKMsgBox(this, "Magma lost it's lock on your project file. Further changes could result in loss of data. It is highly recommended that you close this project and re-open it");
            }
            Cursor = Cursors.Default;
            TextBoxBuild.Cursor = Cursors.Default;

            if (originalMIDI != "")
            {
                mMainForm.ProjectFile.MidiFile = originalMIDI;
                mMainForm.ProjectFile.WriteFile();
            }

            if (!FailedToBuild())
            {
                if (mLastExitCode == 0)
                {
                    doConvert();
                }
                else
                {
                    if (!UserCancelled)
                    {
                        Log("There was an error creating the RBA file.");
                        Log("Stopping here...");
                    }
                }
            }

            if (mMainForm.is2XMIDI && !doing2X)
            {
                Tools.DeleteFile(Tools.MIDI1X);

                doing2X = true;
                Log("Compiling 2X Bass Pedal MIDI...");
                mMainForm.ProjectFile.MidiFile = Tools.MIDI2X;
                mMainForm.ProjectFile.WriteFile();
                SendtoCompiler();
                return;
            }

            Tools.DeleteFile(Tools.MIDI2X);

            SetCloseButtonState(CloseButtonState.kClose);
        }

        public bool FailedToBuild()
        {
            if (!mInternalError)
                return mLastExitCode != 0;
            return true;
        }

        private enum CloseButtonState
        {
            kInvalid,
            kClose,
            kCancel,
        }

        enum RBA_HEADER_INDEX
        {
            HEADER_VALUE_UNKNOWN,
            OFFSET_SONGS_DTA,
            OFFSET_MID,
            OFFSET_MOGG,
            OFFSET_MILO_XBOX,
            OFFSET_BMP,
            OFFSET_WEIGHTS,
            OFFSET_BACKEND,
            LENGTH_SONGS_DTA,
            LENGTH_MID,
            LENGTH_MOGG,
            LENGTH_MILO_XBOX,
            LENGTH_BMP,
            LENGTH_WEIGHTS,
            LENGTH_BACKEND,
            HEADER_INDEX_COUNT
        };
        
        private void sendToC3Tools(string arg = "")
        {
            string argument;
            if (mMainForm.WiiMode && arg == "")
            {
                argument = "-wii -" + Path.GetDirectoryName(con_file);
            }
            else if (arg == "")
            {
                Clipboard.SetText(RBtoUSBArgs);
                argument = "-usb";
            }
            else
            {
                argument = arg;
            }
            if (mMainForm.nautilusPath != "" && File.Exists(mMainForm.nautilusPath))
            {
                Process.Start(mMainForm.nautilusPath, argument);
            }
            else
            {
                var fileDialog = new OpenFileDialog
                {
                    Filter = "Windows Executable (*.exe)|*.exe",
                    InitialDirectory = Application.StartupPath,
                    Title = "Select Nautilus Executable"
                };
                if (fileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                if (fileDialog.FileName != "" && fileDialog.FileName.EndsWith(".exe", StringComparison.Ordinal))
                {
                    mMainForm.nautilusPath = fileDialog.FileName;
                    mMainForm.SaveOptions();
                }
                Process.Start(mMainForm.nautilusPath, argument);
            }
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            sendToC3Tools("-visualizer -" + con_file);
        }

        private void btnClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TextBoxBuild.Text);
            ShowToast("Log copied to clipboard successfully.");
        }

        private void TextBoxBuild_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                TextBoxBuild.SelectAll();
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetText(TextBoxBuild.Text);
            }
        }

        private void BuildForm_Shown(object sender, EventArgs e)
        {
            switch (mMainForm.ActiveSkin)
            {
                case "fire":
                    btnClipboard.BackgroundImage = Resources.btn_xlarge_lava;
                    btnVisualize.BackgroundImage = Resources.btn_xlarge_lava;
                    btnNautilus.BackgroundImage = Resources.btn_xlarge_lava;
                    ButtonClose.BackgroundImage = Resources.btn_large_lava;
                    break;
               case "colorful":
                    SkinDefaults();
                    SkinButtonStyles(FlatStyle.Flat);
                    SkinButtonText(Color.White);
                    btnClipboard.BackColor = Color.FromArgb(27, 178, 37);
                    btnVisualize.BackColor = Color.FromArgb(196, 33, 34);
                    btnNautilus.BackColor = Color.FromArgb(230, 216, 0);
                    ButtonClose.BackColor = Color.FromArgb(39, 85, 196);
                    break;
               case "custom":
                    SkinDefaults();
                    SkinButtonStyles(mMainForm.SkinButtonStyle);
                    SkinButtonText(mMainForm.SkinButtonTextColor);
                    btnClipboard.BackColor = mMainForm.SkinButtonBackgroundColor;
                    btnVisualize.BackColor = mMainForm.SkinButtonBackgroundColor;
                    btnNautilus.BackColor = mMainForm.SkinButtonBackgroundColor;
                    ButtonClose.BackColor = mMainForm.SkinButtonBackgroundColor;
                    break;
            }
            StartBuild();
        }

        private void btnNautilus_Click(object sender, EventArgs e)
        {
            sendToC3Tools();
        }
    }
}
