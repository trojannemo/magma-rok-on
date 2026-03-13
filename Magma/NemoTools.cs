using MagmaRokOn.x360;
using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MagmaRokOn
{
    public class NemoTools
    {
        public string CurrentFolder = ""; //used throughout the program to maintain the current working folder
        private readonly int[] ALLOWED_KEYS_NOTES = { 60, 61, 62, 63, 64, 72, 73, 74, 75, 76, 84, 85, 86, 87, 88, 89, 90, 96, 97, 98, 99, 100, 101, 102, 103, 116, 120, 121, 122, 123, 124, 127 };
        private readonly int[] ALLOWED_PRO_KEYS_ANIM_NOTES = { 0, 2, 4, 5, 7, 9, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72 };
        private readonly int[] ALLOWED_PRO_KEYS_NOTES = { 0, 2, 4, 5, 7, 9, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 115, 116, 126, 127 };
        private readonly int[] ALLOWED_PRO_KEYS_X_NOTES = { 0, 2, 4, 5, 7, 9, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 115, 116, 120, 126, 127 };
        public int MIDI_ERRORS;
        public string MIDI_ERROR_MESSAGE;
        private long KEYS_BRE;
        private long PROKEYS_BRE;
        public string MIDI1X;
        public string MIDI2X;
        public List<TempoEvent> TempoEvents;
        public List<TimeSignature> TimeSignatures;
        private int TicksPerQuarter;
        private MidiFile songMidi;
        public int TextureSize = 512; //default value
        private const int FO_DELETE = 0x0003;
        private const int FOF_ALLOWUNDO = 0x0040;           // Preserve undo information, if possible.
        private const int FOF_NOCONFIRMATION = 0x0010;      // Show no confirmation dialog box to the user

        // Struct which contains information that the SHFileOperation function uses to perform file operations.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.U4)]
            public int wFunc;
            public string pFrom;
            public string pTo;
            public short fFlags;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            public string lpszProgressTitle;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern int SHFileOperation(ref SHFILEOPSTRUCT FileOp);

        
        /// <summary>
        /// Will send files or folders to Recycle Bin rather than delete from hard drive
        /// </summary>
        /// <param name="path">Full file / folder path to be recycled</param>
        /// <param name="isFolder">Whether path is to a folder rather than a file</param>
        public void SendtoTrash(string path, bool isFolder = false)
        {
            if (isFolder)
            {
                if (!Directory.Exists(path)) return;
            }
            else
            {
                if (!File.Exists(path)) return;
            }

            try
            {
                var fileop = new SHFILEOPSTRUCT
                {
                    wFunc = FO_DELETE,
                    pFrom = path + '\0' + '\0',
                    fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION
                };
                SHFileOperation(ref fileop);
            }
            catch (Exception)
            {
                //
            }
        }

        /// <summary>
        /// Returns color from RGB or HEX formatted color string (Transparent allowed)
        /// </summary>
        /// <param name="raw_line">Raw line from config file, may work with other files as long as color follows =</param>
        /// <returns>Color value of string, RED if failure</returns>
        public Color GetColorFromString(string raw_line)
        {
            Color color;      //return bright red if anything goes wrong
            var line = raw_line;

            if (line.Contains("="))
            {
                var index = line.IndexOf("=", StringComparison.Ordinal) + 1;
                line = line.Substring(index, line.Length - index);
            }

            line = line.Trim();

            if (line.ToLowerInvariant().Contains("transparent"))
            {
                color = Color.Transparent;
            }
            else if (line.Contains("#"))
            {
                try
                {
                    color = ColorTranslator.FromHtml(line);
                }
                catch (Exception)
                {
                    color = Color.Red;
                }
            }
            else
            {
                try
                {
                    var rgb = line.Split(',');
                    if (rgb.Count() == 3) //###,###,###
                    {
                        color = Color.FromArgb(Convert.ToInt16(rgb[0]), Convert.ToInt16(rgb[1]),
                                               Convert.ToInt16(rgb[2]));
                    }
                    else
                    {
                        color = Color.Red;
                    }
                }
                catch (Exception)
                {
                    color = Color.Red;
                }
            }

            return color;
        }

        /// <summary>
        /// Returns flatstyle for use in skinning
        /// </summary>
        /// <param name="raw_line">Raw line from the skin template</param>
        /// <returns></returns>
        public FlatStyle GetFlatStyle(string raw_line)
        {
            var flatstyle = FlatStyle.Standard;
            var line = raw_line;

            try
            {
                var index = line.IndexOf("=", StringComparison.Ordinal) + 1;
                var style = line.Substring(index, line.Length - index);
                style = style.Trim();

                switch (style.ToLowerInvariant())
                {
                    case "flat":
                        flatstyle = FlatStyle.Flat;
                        break;
                    case "standard":
                        flatstyle = FlatStyle.Standard;
                        break;
                    case "system":
                        flatstyle = FlatStyle.System;
                        break;
                }
            }
            catch (Exception)
            {
                flatstyle = FlatStyle.Standard;
            }

            return flatstyle;
        }
        
        /// <summary>
        /// Will safely try to move, and if fails, copy/delete a file
        /// </summary>
        /// <param name="input">Full starting path of the file</param>
        /// <param name="output">Full destination path of the file</param>
        public bool MoveFile(string input, string output)
        {
            try
            {
                DeleteFile(output);
                File.Move(input, output);
            }
            catch (Exception)
            {
                try
                {
                    File.Copy(input, output);
                    DeleteFile(input);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            //Application.DoEvents();
            return File.Exists(output);
        }

        /// <summary>
        /// Simple function to safely delete folders
        /// </summary>
        /// <param name="folder">Full path of folder to be deleted</param>
        /// <param name="delete_contents">Whether to delete folders that are not empty</param>
        public void DeleteFolder(string folder, bool delete_contents)
        {
            if (!Directory.Exists(folder)) return;

            try
            {
                if (delete_contents)
                {
                    Directory.Delete(folder, true);
                    return;
                }
                if (!Directory.GetFiles(folder).Any())
                {
                    Directory.Delete(folder);
                }
            }
            catch (Exception)
            {
                //
            }
        }

        /// <summary>
        /// Simple function to safely delete files
        /// </summary>
        /// <param name="file">Full path of file to be deleted</param>
        public void DeleteFile(string file)
        {
            if (file == "") return;
            if (!File.Exists(file)) return;

            try
            {
                File.Delete(file);
            }
            catch (Exception)
            {
                //
            }
        }

        /// <summary>
        /// Simple function to safely delete folders
        /// </summary>
        /// <param name="folder">Full path of folder to be deleted</param>
        public void DeleteFolder(string folder)
        {
            if (!Directory.Exists(folder)) return;
            DeleteFolder(folder, false);
        }
        
        /// <summary>
        /// Unlocks STFS package to show as a full song in game
        /// </summary>
        /// <param name="file_path">Full path to the CON or LIVE file</param>
        /// <returns></returns>
        public bool UnlockCON(string file_path)
        {
            //open and unlock CON/LIVE package
            try
            {
                var bw = new BinaryWriter(File.Open(file_path, FileMode.Open, FileAccess.ReadWrite));
                bw.BaseStream.Seek(567L, SeekOrigin.Begin);
                bw.Write(0x01);
                bw.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Signs STFS file as CON for use in retail Xboxes
        /// </summary>
        /// <param name="file_path">Full path to the STFS file to sign</param>
        /// <returns></returns>
        public bool SignCON(string file_path)
        {
            var xPackage = new STFSPackage(file_path);
            if (!xPackage.ParseSuccess)
            {
                return false;
            }
            try
            {
                var kv = new RSAParams(Application.StartupPath + "\\bin\\KV.bin");
                if (kv.Valid)
                {
                    xPackage.FlushPackage(kv);
                    xPackage.UpdateHeader(kv);
                    xPackage.CloseIO();
                    return true;
                }
                xPackage.CloseIO();
                return false;
            }
            catch
            {
                xPackage.CloseIO();
                return false;
            }
        }
        
        /// <summary>
        /// Returns byte array in hex value
        /// </summary>
        /// <param name="xIn">String value to be converted to hex</param>
        /// <returns></returns>
        public byte[] ToHex(string xIn)
        {
            for (var i = 0; i < (xIn.Length % 2); i++)
                xIn = "0" + xIn;
            var xReturn = new List<byte>();
            for (var i = 0; i < (xIn.Length / 2); i++)
                xReturn.Add(Convert.ToByte(xIn.Substring(i * 2, 2), 16));
            return xReturn.ToArray();
        }
        
        /// <summary>
        /// Returns clean Track Name from MIDI event string
        /// </summary>
        /// <param name="raw_event">The raw ToString value of the MIDI event</param>
        /// <returns></returns>
        public string GetMidiTrackName(string raw_event)
        {
            var name = raw_event;
            name = name.Substring(2, name.Length - 2); //remove track number
            name = name.Replace("SequenceTrackName", "");
            name = name.TrimStart();
            name = name.TrimEnd();
            return name;
        }
        
        /// <summary>
        /// Returns true if the package description suggests a pack
        /// </summary>
        /// <param name="desc">Package description</param>
        /// <param name="disp">Package display</param>
        /// <returns></returns>
        public bool DescribesPack(string desc, string disp)
        {
            var description = desc.ToLowerInvariant();
            var display = disp.ToLowerInvariant();

            return (display.Contains("pro upgrade") || description.Contains("pro upgrade") ||
                   description.Contains("(pro)") || description.Contains("(upgrade)") ||
                   display.Contains("(pro)") || display.Contains("(upgrade)") ||
                   display.Contains("album") || description.Contains("album") ||
                   display.Contains("export") || description.Contains("export")) &&
                   !description.Contains("depacked") && !display.Contains("depacked");
        }

        /// <summary>
        /// Returns cleaned string for file names, etc
        /// </summary>
        /// <param name="raw_string">Raw string from the songs.dta file</param>
        /// <param name="removeDash">Whether to remove dashes from the string</param>
        /// <returns></returns>
        public string CleanString(string raw_string, Boolean removeDash)
        {
            var mystring = raw_string;

            //remove forbidden characters if present
            mystring = mystring.Replace("\"", "");
            mystring = mystring.Replace(">", " ");
            mystring = mystring.Replace("<", " ");
            mystring = mystring.Replace(":", " ");
            mystring = mystring.Replace("|", " ");
            mystring = mystring.Replace("?", " ");
            mystring = mystring.Replace("*", " ");
            mystring = mystring.Replace("&#8217;", "'"); //Don't Speak
            mystring = mystring.Replace("   ", " ");
            mystring = mystring.Replace("  ", " ");
            mystring = FixBadChars(mystring);

            mystring = mystring.TrimEnd(); //remove trailing empty spaces
            mystring = mystring.TrimStart(); //remove leading empty spaces

            if (removeDash)
            {
                if (mystring.Substring(0, 1) == "-") //if starts with -
                {
                    mystring = mystring.Substring(1, mystring.Length - 1);
                }
                if (mystring.Substring(mystring.Length - 1, 1) == "-") //if ends with -
                {
                    mystring = mystring.Substring(0, mystring.Length - 1);
                }

                mystring = mystring.TrimEnd(); //remove trailing empty spaces
                mystring = mystring.TrimStart(); //remove leading empty spaces
            }

            if (mystring.EndsWith(".", StringComparison.Ordinal)) //can't have files like Y.M.C.A.
            {
                mystring = mystring.Substring(0, mystring.Length - 1);
            }

            mystring = mystring.Replace("\\", mystring != "AC/DC" ? " " : "");
            mystring = mystring.Replace("/", mystring != "AC/DC" ? " " : "");

            return mystring;
        }
        
        /// <summary>
        /// Returns string with correctly formatted characters
        /// </summary>
        /// <param name="raw_line">Raw line from songs.dta file</param>
        /// <returns></returns>
        public string FixBadChars(string raw_line)
        {
            var line = raw_line.Replace("Ã¡", "á");
            line = line.Replace("Ã©", "é");
            line = line.Replace("Ã¨", "è");
            line = line.Replace("ÃŠ", "Ê");
            line = line.Replace("Ã¬", "ì");
            line = line.Replace("Ã­­­", "í");
            line = line.Replace("Ã¯", "ï");
            line = line.Replace("Ã–", "Ö");
            line = line.Replace("Ã¶", "ö");
            line = line.Replace("Ã³", "ó");
            line = line.Replace("Ã²", "ò");
            line = line.Replace("Ãœ", "Ü");
            line = line.Replace("Ã¼", "ü");
            line = line.Replace("Ã¹", "ù");
            line = line.Replace("Ãº", "ú");
            line = line.Replace("Ã¿", "ÿ");
            line = line.Replace("Ã±", "ñ");
            line = line.Replace("ï¿½", "");
            line = line.Replace("�", "");
            line = line.Replace("E½", "");
            return line;
        }
        
        /// <summary>
        /// Returns whether the MIDI has EMH charted by counting and comparing number of notes
        /// </summary>
        /// <param name="track">Midi track to process (i.e. drums, keys)</param>
        /// <param name="ExpertLow">Lower value cutoff for Expert Difficulty</param>
        /// <param name="ExpertHigh">Higher value cutoff for Expert Difficulty</param>
        /// <param name="HardLow">Lower value cutoff for Hard Difficulty</param>
        /// <param name="HardHigh">Higher value cutoff for Hard Difficulty</param>
        /// <param name="MediumLow">Lower value cutoff for Medium Difficulty</param>
        /// <param name="MediumHigh">Higher value cutoff for Medium Difficulty</param>
        /// <param name="EasyLow">Lower value cutoff for Easy Difficulty</param>
        /// <param name="EasyHigh">Higher value cutoff for Easy Difficulty</param>
        /// <param name="OnlyCheckForEMH">True if you only care whether EMH has ANYTHING charted</param>
        /// <returns></returns>
        private int CheckTrackForEMH(IList<MidiEvent> track, int ExpertLow, int ExpertHigh, int HardLow, int HardHigh, int MediumLow, int MediumHigh, int EasyLow, int EasyHigh, bool OnlyCheckForEMH = false)
        {
            var Expert = new List<MidiEvent>();
            var Hard = new List<MidiEvent>();
            var Medium = new List<MidiEvent>();
            var Easy = new List<MidiEvent>();
            var trackname = GetMidiTrackName(track[0].ToString());
            var x_only = 0;
            try
            {
                foreach (var notes in track)
                {
                    if (notes.CommandCode != MidiCommandCode.NoteOn) continue;
                    var note = (NoteOnEvent)notes;
                    if (note.NoteNumber >= ExpertLow && note.NoteNumber <= ExpertHigh)
                    {
                        Expert.Add(notes);
                    }
                    else if (note.NoteNumber >= HardLow && note.NoteNumber <= HardHigh)
                    {
                        Hard.Add(notes);
                    }
                    else if (note.NoteNumber >= MediumLow && note.NoteNumber <= MediumHigh)
                    {
                        Medium.Add(notes);
                    }
                    else if (note.NoteNumber >= EasyLow && note.NoteNumber <= EasyHigh)
                    {
                        Easy.Add(notes);
                    }
                }
                if (Hard.Count() >= Expert.Count() && !OnlyCheckForEMH)
                {
                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nWARNING: " + trackname + " Hard has " + (!Hard.Any() ? "0 notes" : "the same amount or more notes than Expert.");
                    x_only++;
                }
                else if (Hard.Count() < 10 && Expert.Count() > 10)
                {
                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nWARNING: " + trackname + " Hard " + (Hard.Any() ? "only has " + Hard.Count() + " notes but Expert has " + Expert.Count + " notes" : "has 0 notes.");
                    x_only++;
                }
                if (Medium.Count() >= Hard.Count() && !OnlyCheckForEMH)
                {
                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nWARNING: " + trackname + " Medium has " + (!Medium.Any() ? "0 notes" : "the same amount or more notes than Hard.");
                    x_only++;
                }
                else if (Medium.Count() < 10 && Expert.Count() > 10)
                {
                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nWARNING: " + trackname + " Medium " + (Medium.Any() ? "only has " + Medium.Count() + " notes but Expert has " + Expert.Count + " notes" : "has 0 notes.");
                    x_only++;
                }
                if (Easy.Count() >= Medium.Count() && !OnlyCheckForEMH)
                {
                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nWARNING: " + trackname + " Easy has " + (!Easy.Any() ? "0 notes" : "the same amount or more notes than Medium.");
                    x_only++;
                }
                else if (Easy.Count() < 10 && Expert.Count() > 10)
                {
                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nWARNING: " + trackname + " Easy " + (Easy.Any() ? "only has " + Easy.Count() + " notes but Expert has " + Expert.Count + " notes" : "has 0 notes.");
                    x_only++;
                }
            }
            catch (Exception)
            {
                MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nERROR reading MIDI file to check if " + trackname + " has lower difficulties.";
            }
            return x_only;
        }

        public MidiFile NemoLoadMIDI(string midi_in)
        {
            //NAudio is limited in its ability to read some non-standard MIDIs
            //before this step was added, 3 different errors would prevent this program from reading
            //MIDIs with those situations
            //thanks raynebc we can fix them first and load the fixed MIDIs
            var midishrink = Application.StartupPath + "\\bin\\midishrink.exe";
            if (!File.Exists(midishrink)) return null;
            var midi_out = Application.StartupPath + "\\bin\\temp.mid";
            DeleteFile(midi_out);
            MidiFile MIDI;
            try
            {
                MIDI = new MidiFile(midi_in, false);
            }
            catch (Exception)
            {
                var folder = Path.GetDirectoryName(midi_in) ?? Environment.CurrentDirectory;
                var startInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    FileName = Application.StartupPath + "\\bin\\midishrink.exe",
                    Arguments = "\"" + midi_in + "\" \"" + midi_out + "\"",
                    WorkingDirectory = folder
                };
                var start = (DateTime.Now.Minute * 60) + DateTime.Now.Second;
                var process = Process.Start(startInfo);
                do
                {
                    //this code checks for possible memory leak in midishrink
                    //typical usage outputs a fixed file in 1 second or less, at 15 seconds there's a problem
                    if ((DateTime.Now.Minute * 60) + DateTime.Now.Second - start < 15) continue;
                    break;

                } while (!process.HasExited);
                if (!process.HasExited)
                {
                    process.Kill();
                    process.Dispose();
                }
                if (File.Exists(midi_out))
                {
                    try
                    {
                        MIDI = new MidiFile(midi_out, false);
                    }
                    catch (Exception)
                    {
                        MIDI = null;
                    }
                }
                else
                {
                    MIDI = null;
                }
            }
            DeleteFile(midi_out);  //the file created in the loop is useless, delete it
            return MIDI;
        }

        public bool DoesMidiHaveEMH(string midifile, bool pro_keys_enabled = true)
        {
            MIDI_ERROR_MESSAGE = "Starting Basic EMH Check..";
            var Expert = new List<MidiEvent>();
            var Hard = new List<MidiEvent>();
            var Medium = new List<MidiEvent>();
            var Easy = new List<MidiEvent>();
            var x_only = 0;

            try
            {
                songMidi = NemoLoadMIDI(midifile);
                if (songMidi == null)
                {
                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nERROR: Could not load MIDI file to check if charts have lower difficulties.";
                    return false;
                }
                for (var i = 0; i < songMidi.Events.Tracks; i++)
                {
                    if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("part drums"))
                    {
                        x_only = x_only + CheckTrackForEMH(songMidi.Events[i], 96, 100, 84, 88, 72, 76, 60, 64);
                    }
                    else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("part bass"))
                    {
                        x_only = x_only + CheckTrackForEMH(songMidi.Events[i], 96, 100, 84, 88, 72, 76, 60, 64);
                    }
                    else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("part guitar"))
                    {
                        x_only = x_only + CheckTrackForEMH(songMidi.Events[i], 96, 100, 84, 88, 72, 76, 60, 64);
                    }
                    else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("part keys") && !songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("anim"))
                    {
                        x_only = x_only + CheckTrackForEMH(songMidi.Events[i], 96, 100, 84, 88, 72, 76, 60, 64);
                    }
                    else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("real_bass"))
                    {
                        x_only = x_only + CheckTrackForEMH(songMidi.Events[i], 96, 99, 72, 75, 48, 51, 24, 27);
                    }
                    else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("real_guitar"))
                    {
                        x_only = x_only + CheckTrackForEMH(songMidi.Events[i], 96, 101, 72, 77, 48, 53, 24, 29);
                    }
                    else if (songMidi.Events[i][0].ToString().ToLowerInvariant().Contains("real_keys") && pro_keys_enabled)
                    {
                        var track = GetMidiTrackName(songMidi.Events[i][0].ToString());
                        foreach (var notes in from notes in songMidi.Events[i] where notes.CommandCode == MidiCommandCode.NoteOn let note = (NoteOnEvent)notes where note.NoteNumber >= 48 && note.NoteNumber <= 72 select notes)
                        {
                            if (track.ToLowerInvariant().Contains("keys_x"))
                            {
                                Expert.Add(notes);
                            }
                            else if (track.ToLowerInvariant().Contains("keys_h"))
                            {
                                Hard.Add(notes);
                            }
                            else if (track.ToLowerInvariant().Contains("keys_m"))
                            {
                                Medium.Add(notes);
                            }
                            else if (track.ToLowerInvariant().Contains("keys_e"))
                            {
                                Easy.Add(notes);
                            }
                        }
                    }
                }

                if (Expert.Any())
                {
                    if (Hard.Count() >= Expert.Count())
                    {
                        MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nWARNING: PART REAL_KEYS_H has " + (!Hard.Any() ? "0 notes" : "the same amount or more notes than Expert.");
                        x_only++;
                    }
                    else if (Hard.Count() < 10 && Expert.Count() > 10)
                    {
                        MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nWARNING: PART REAL_KEYS_H " + (Hard.Any() ? "only has " + Hard.Count() + " notes but Expert has " + Expert.Count + " notes" : "has 0 notes.");
                        x_only++;
                    }
                    if (Medium.Count() >= Hard.Count())
                    {
                        MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nWARNING: PART REAL_KEYS_M has " + (!Medium.Any() ? "0 notes" : "the same amount or more notes than Hard.");
                        x_only++;
                    }
                    else if (Medium.Count() < 10 && Expert.Count() > 10)
                    {
                        MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nWARNING: PART REAL_KEYS_M " + (Medium.Any() ? "only has " + Medium.Count() + " notes but Expert has " + Expert.Count + " notes" : "has 0 notes.");
                        x_only++;
                    }
                    if (Easy.Count() >= Medium.Count())
                    {
                        MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nWARNING: PART REAL_KEYS_E has " + (!Easy.Any() ? "0 notes" : "the same amount or more notes than Medium.");
                        x_only++;
                    }
                    else if (Easy.Count() < 10 && Expert.Count() > 10)
                    {
                        MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nWARNING: PART REAL_KEYS_E " + (Easy.Any() ? "only has " + Easy.Count() + " notes but Expert has " + Expert.Count + " notes" : "has 0 notes.");
                        x_only++;
                    }
                }
            }
            catch (Exception)
            {
                MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nERROR: Could not load MIDI file to check if charts have lower difficulties.";
                return false;
            }
            if (x_only == 0)
            {
                MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nMIDI passed Basic EMH Check without reporting any problems\nThis means the charts most likely have reductions charted.";
                return true;
            }
            if (x_only > 0 && x_only < 4)
            {
                MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nThere " + (x_only == 1 ? "was" : "were") + " only " + x_only + (x_only == 1 ? " problem" : " problems") + " reported\nThis means the charts most likely have reductions charted except where reported in the log.";
                return true;
            }
            MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nMIDI failed Basic EMH Check. This means the charts are most likely expert only\nRefer to the log to see which chart(s) reported problems.";
            return false;
        }

        /// <summary>
        /// Use to quickly grab value on right side of = in options/fix files
        /// </summary>
        /// <param name="raw_line">Raw line from the file</param>
        /// <returns></returns>
        public string GetConfigString(string raw_line)
        {
            var line = raw_line;
            var index = line.IndexOf("=", StringComparison.Ordinal) + 1;
            try
            {
                line = line.Substring(index, line.Length - index);
            }
            catch (Exception)
            {
                line = "";
            }
            return line.Trim();
        }
        
        // // // // // // // // // // // // // // // 
        //MAGMA ONLY STUFF       MAGMA ONLY STUFF // 
        // // // // // // // // // // // // // // // 

        /// <summary>
        /// Autogenerates fake pro keys, keys animation or adds drum mix events to MIDI file
        /// </summary>
        /// <param name="MIDIfile">Source MIDI file to modify</param>
        /// <param name="drums_mix_Text">The correctly formatted drums mix text</param>
        /// <param name="doKeysAnim">Whether to generate keys animations</param>
        /// <param name="doProKeys">Whether to generate fake pro keys</param>
        /// <param name="doDrumsMix">Whether to add the drum mix events to the MIDI</param>
        /// <returns>Returns process log in string format</returns>
        public string MIDIAutoGen(string MIDIfile, string drums_mix_Text, bool doKeysAnim, bool doProKeys,bool doDrumsMix)
        {
            return MIDIAutoGen(MIDIfile, drums_mix_Text, doKeysAnim, doProKeys, doDrumsMix, false);
        }

        /// <summary>
        /// Autogenerates fake pro keys, keys animation or adds drum mix events to MIDI file
        /// </summary>
        /// <param name="MIDIfile">Source MIDI file to modify</param>
        /// <param name="drums_mix_Text">The correctly formatted drums mix text</param>
        /// <param name="doKeysAnim">Whether to generate keys animations</param>
        /// <param name="doProKeys">Whether to generate fake pro keys</param>
        /// <param name="doDrumsMix">Whether to add the drum mix events to the MIDI</param>
        /// <param name="clean_events">Whether to clean events track by replacing section with prc_</param>
        /// <returns>Returns process log in string format</returns>
        public string MIDIAutoGen(string MIDIfile, string drums_mix_Text, bool doKeysAnim, bool doProKeys, bool doDrumsMix, bool clean_events)
        {
            //MidiFile workingMidi = null;
            var PartKeys = -1;
            var TracksToRemove = new List<int>();
            var MIDIpath = MIDIfile;
            var MIDIbackup = Path.GetDirectoryName(MIDIpath) + "\\" + Path.GetFileNameWithoutExtension(MIDIpath) + "_backup.mid";
            var log = "\nNemo's MIDI AutoGen process started.";
            DeleteFile(MIDIbackup);
            try
            {
                File.Copy(MIDIpath, MIDIbackup);
            }
            catch (Exception ex)
            {
                log = log + "\nThere was a error creating a backup of the MIDI file.";
                log = log + "\nThe error says: " + ex.Message;
            }
            var error = false;
            songMidi = NemoLoadMIDI(MIDIpath);
            if (songMidi == null)
            {
                error = true;
            }
            if (error)
            {
                log = log + "\nThere was an error loading MIDI file " + Path.GetFileName(MIDIpath) + " into memory.";
                log = log + "\nCan't continue without the MIDI. Stopping here.";
                log = log + "\nNemo's MIDI AutoGen process stopped.";
                log = log + "\nMagmaCompiler may get a bit upset about this...";
                return log;
            }
            var ticks = songMidi.DeltaTicksPerQuarterNote / 4; //1/16th note
            try
            {
                var doDrums = doDrumsMix;
                for (var i = 0; i < songMidi.Events.Tracks; i++)
                {
                    var trackname = GetMidiTrackName(songMidi.Events[i][0].ToString());
                    if (trackname.Contains("PART DRUMS") && doDrums)
                    {
                        if (drums_mix_Text == "Unsupported")
                        {
                            log = log + "\nFound PART DRUMS and you have enabled the 'Add to MIDI' option\nHowever, the current suggested drum mix event is unsupported\nNothing is being changed in the drums track.";
                        }
                        else
                        {
                            var removemixes = new List<MidiEvent>();
                            var newmixes = new List<MidiEvent>();
                            foreach (var notes in songMidi.Events[i])
                            {
                                if (notes.CommandCode != MidiCommandCode.MetaEvent) continue;
                                var mixevent = (MetaEvent)notes;
                                if (!mixevent.ToString().Contains("mix") || !mixevent.ToString().Contains("drums")) continue;
                                var index = mixevent.ToString().IndexOf("[", StringComparison.Ordinal);
                                var mix = mixevent.ToString().Substring(index, mixevent.ToString().Length - index);
                                mix = mix.Replace("easy", ""); //old drum mix no longer used
                                mix = mix.Replace("nokick", ""); //old drum mix no longer used

                                //remove the 3] from the end
                                var newmix = mix.Substring(0, mix.Length - 2);
                                var disco = "";
                                var noflip = "";
                                if (mix.EndsWith("d]", StringComparison.Ordinal)) // conventional disco flip
                                {
                                    newmix = mix.Substring(0, mix.Length - 3); //disco flip, remove the 3d] from the end
                                    disco = "d";
                                }
                                else if (mix.EndsWith("noflip]", StringComparison.Ordinal)) // disco flip but no flip for pro drums
                                {
                                    newmix = mix.Substring(0, mix.Length - 9); //remove the 3dnoflip] from the end
                                    disco = "d";
                                    noflip = "noflip";
                                }
                                else if (mix.EndsWith("a]", StringComparison.Ordinal)) //found in some HMX-authored songs (Fly Like an Eagle)
                                {
                                    newmix = mix.Substring(0, mix.Length - 3); //remove the 3a] from the end
                                    disco = "";
                                }
                                //messy but this way don't have to re-do how this gets called
                                newmix = newmix + drums_mix_Text.Substring(drums_mix_Text.Length - 2, 1) + disco + noflip + "]";
                                newmixes.Add(new TextEvent(newmix, MetaEventType.TextEvent, mixevent.AbsoluteTime));
                                removemixes.Add(notes);
                            }
                            foreach (var remove in removemixes)
                            {
                                songMidi.Events[i].Remove(remove);
                            }
                            if (newmixes.Count < 4) //in case they left the drums track without any mix events
                            {
                                newmixes.Add(new TextEvent(drums_mix_Text.Replace("#", "0"), MetaEventType.TextEvent, ticks));
                                newmixes.Add(new TextEvent(drums_mix_Text.Replace("#", "1"), MetaEventType.TextEvent, ticks * 2));
                                newmixes.Add(new TextEvent(drums_mix_Text.Replace("#", "2"), MetaEventType.TextEvent, ticks * 3));
                                newmixes.Add(new TextEvent(drums_mix_Text.Replace("#", "3"), MetaEventType.TextEvent, ticks * 4));
                            }
                            foreach (var mix in newmixes)
                            {
                                songMidi.Events[i].Add(mix);
                            }
                        }
                        log = log + "\nAdded drum mix events successfully.";
                        doDrums = false;
                    }
                    else if (trackname.Contains("EVENTS") && clean_events)
                    {
                        var old_sections = new List<MidiEvent>();
                        var new_sections = new List<MidiEvent>();
                        foreach (var notes in songMidi.Events[i])
                        {
                            if (notes.CommandCode != MidiCommandCode.MetaEvent) continue;
                            var sectionevent = (MetaEvent)notes;
                            if (!sectionevent.ToString().Contains("[section ")) continue;
                            var index = sectionevent.ToString().IndexOf("[", StringComparison.Ordinal);
                            var old_section = sectionevent.ToString().Substring(index, sectionevent.ToString().Length - index);
                            var new_section = old_section.Replace("section ", "prc_");
                            new_sections.Add(new TextEvent(new_section, MetaEventType.TextEvent, sectionevent.AbsoluteTime));
                            old_sections.Add(notes);
                        }
                        if (!old_sections.Any()) continue;
                        foreach (var remove in old_sections)
                        {
                            songMidi.Events[i].Remove(remove);
                        }
                        foreach (var section in new_sections)
                        {
                            songMidi.Events[i].Add(section);
                        }
                    }
                    else if (trackname.Contains("PART KEYS_ANIM_") && doKeysAnim)
                    {
                        TracksToRemove.Add(i);
                    }
                    else if (trackname.Contains("PART REAL_KEYS_") && doProKeys)
                    {
                        TracksToRemove.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                log = log + "\nThere was an error, sorry.";
                log = log + "\nThe error says: " + ex.Message;
                log = log + "\nNemo's MIDI AutoGen process stopped.";
                log = log + "\nMagmaCompiler may get a bit upset about this...";
                return log;
            }
            if (!doKeysAnim && !doProKeys)
            {
                try
                {
                    DeleteFile(MIDIpath);
                    MidiFile.Export(MIDIpath, songMidi.Events);
                    log = log + "\nNemo's MIDI AutoGen process completed.";
                    DeleteFile(MIDIbackup);
                    return log;
                }
                catch (Exception ex)
                {
                    if (!File.Exists(MIDIpath))
                    {
                        MoveFile(MIDIbackup, MIDIpath);
                    }
                    log = log + "\nThere was an error exporting the new MIDI file.";
                    log = log + "\nThe error says: " + ex.Message;
                    log = log + "\nI restored the backup MIDI file, which means nothing changed.";
                    log = log + "\nNemo's MIDI AutoGen process stopped.";
                    log = log + "\nMagmaCompiler may get a bit upset about this...";
                    return log;
                }
            }
            if (TracksToRemove.Any())
            {
                TracksToRemove.Sort();
                for (var i = TracksToRemove.Count - 1; i >= 0; i--)
                {
                    songMidi.Events.RemoveTrack(TracksToRemove[i]);
                }
            }
            if (doProKeys || doKeysAnim)
            {
                //let the above finish and re-run through the tracks to make sure keys is in the right index
                for (var i = 0; i < songMidi.Events.Tracks; i++)
                {
                    var trackname = GetMidiTrackName(songMidi.Events[i][0].ToString());
                    if (!trackname.Contains("PART KEYS") || trackname.Contains("ANIM")) continue;
                    PartKeys = i;
                    break;
                }
            }
            if (PartKeys == -1)
            {
                log = log + "\nCould not find a Part Keys track ... can't generate pro keys or keys animations without it.";
                log = log + "\nNemo's MIDI AutoGen process stopped.";
                log = log + "\nMagmaCompiler may get a bit upset about this...";
                return log;
            }
            var RangeMarkerOn = new NoteOnEvent(0, 1, 9, 96, ticks); //A2-C4 marker
            var RangeMarkerOff = new NoteEvent(ticks, 1, MidiCommandCode.NoteOff, 9, 96);
            var ProKeysX = new List<MidiEvent>
            {
                new TextEvent("PART REAL_KEYS_X", MetaEventType.SequenceTrackName, 0),
                RangeMarkerOn, RangeMarkerOff
            };
            var ProKeysH = new List<MidiEvent>
            {
                new TextEvent("PART REAL_KEYS_H", MetaEventType.SequenceTrackName, 0),
                RangeMarkerOn, RangeMarkerOff
            };
           var ProKeysM = new List<MidiEvent>
            {
                new TextEvent("PART REAL_KEYS_M", MetaEventType.SequenceTrackName, 0),
                RangeMarkerOn, RangeMarkerOff
            };
            var ProKeysE = new List<MidiEvent>
            {
                new TextEvent("PART REAL_KEYS_E", MetaEventType.SequenceTrackName, 0),
                RangeMarkerOn, RangeMarkerOff
            };
            var KeysAnimation = new List<MidiEvent>
            {
                new TextEvent("PART KEYS_ANIM_RH", MetaEventType.SequenceTrackName, 0)
            };
            try
            {
                //only add the valid notes, ignore everything else
                foreach (var notes in songMidi.Events[PartKeys])
                {
                    switch (notes.CommandCode)
                    {
                        case MidiCommandCode.NoteOn:
                            var note = (NoteOnEvent) notes;
                            var newNoteOn = note.Velocity > 0 ? 
                                new NoteOnEvent(note.AbsoluteTime, note.Channel, GetNewNoteNumber(note.NoteNumber), note.Velocity, note.NoteLength) :
                                new NoteEvent(note.AbsoluteTime, note.Channel, MidiCommandCode.NoteOff, GetNewNoteNumber(note.NoteNumber), note.Velocity);
                            switch (note.NoteNumber)
                            {
                                case 96:
                                case 97:
                                case 98:
                                case 99:
                                case 100:
                                    KeysAnimation.Add(newNoteOn);
                                    ProKeysX.Add(newNoteOn);
                                    ProKeysH.Add(newNoteOn);
                                    ProKeysM.Add(newNoteOn);
                                    ProKeysE.Add(newNoteOn);
                                    break;
                                case 103:
                                case 116:
                                case 120:
                                case 127:
                                    ProKeysX.Add(newNoteOn);
                                    break;
                            }
                            break;
                        case MidiCommandCode.NoteOff:
                            var noteOff = (NoteEvent) notes;
                            var newNoteOff = new NoteEvent(noteOff.AbsoluteTime, noteOff.Channel,MidiCommandCode.NoteOff, GetNewNoteNumber(noteOff.NoteNumber),noteOff.Velocity);
                            switch (noteOff.NoteNumber)
                            {
                                case 96:
                                case 97:
                                case 98:
                                case 99:
                                case 100:
                                    KeysAnimation.Add(newNoteOff);
                                    ProKeysX.Add(newNoteOff);
                                    ProKeysH.Add(newNoteOff);
                                    ProKeysM.Add(newNoteOff);
                                    ProKeysE.Add(newNoteOff);
                                    break;
                                case 103:
                                case 116:
                                case 120:
                                case 127:
                                    ProKeysX.Add(newNoteOff);
                                    break;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                log = log + "\nThere was an error autogenerating keys tracks!";
                log = log + "\nThe error says: " + ex.Message;
                log = log + "\nCan't continue. Stopping here.";
                log = log + "\nNemo's MIDI AutoGen process stopped.";
                log = log + "\nMagmaCompiler may get a bit upset about this...";
                return log;
            }
            var end_event = songMidi.Events[PartKeys][songMidi.Events[PartKeys].Count - 1];
            if (end_event.CommandCode == MidiCommandCode.MetaEvent &&
                ((MetaEvent) end_event).MetaEventType == MetaEventType.EndTrack)
            {
                ProKeysX.Add(songMidi.Events[PartKeys][songMidi.Events[PartKeys].Count - 1]);
                ProKeysH.Add(songMidi.Events[PartKeys][songMidi.Events[PartKeys].Count - 1]);
                ProKeysM.Add(songMidi.Events[PartKeys][songMidi.Events[PartKeys].Count - 1]);
                ProKeysE.Add(songMidi.Events[PartKeys][songMidi.Events[PartKeys].Count - 1]);
                KeysAnimation.Add(songMidi.Events[PartKeys][songMidi.Events[PartKeys].Count - 1]);
            }
            if (doProKeys)
            {
                try
                {
                    songMidi.Events.AddTrack(ProKeysX);
                    songMidi.Events.AddTrack(ProKeysH);
                    songMidi.Events.AddTrack(ProKeysM);
                    songMidi.Events.AddTrack(ProKeysE);
                    log = log + "\nGenerated fake pro keys tracks successfully.";
                }
                catch (Exception ex)
                {
                    log = log + "\nFailed at adding fake pro keys track to the MIDI.";
                    log = log + "\nThe error says: " + ex.Message;
                    log = log + "\nThis means the process failed. Sorry.";
                    log = log + "\nNemo's MIDI AutoGen process stopped.";
                    log = log + "\nMagmaCompiler may get a bit upset about this...";
                    return log;
                }
            }
            if (doKeysAnim)
            {
                try
                {
                    songMidi.Events.AddTrack(KeysAnimation);
                    log = log + "\nGenerated keys animation track successfully.";
                }
                catch (Exception ex)
                {
                    log = log + "\nFailed at adding the new animation track to the MIDI.";
                    log = log + "\nThe error says: " + ex.Message;
                    log = log + "\nThis means the process failed. Sorry.";
                    log = log + "\nNemo's MIDI AutoGen process stopped.";
                    log = log + "\nMagmaCompiler may get a bit upset about this...";
                    return log;
                }
            }
            DeleteFile(MIDIpath);
            try
            {
                MidiFile.Export(MIDIpath, songMidi.Events);
                log = log + "\nExported modified MIDI file successfully. All done.";
                DeleteFile(MIDIbackup);
            }
            catch (Exception ex)
            {
                if (!File.Exists(MIDIpath))
                {
                    MoveFile(MIDIbackup, MIDIpath);
                }
                log = log + "\nThere was an error exporting the new MIDI file.";
                log = log + "\nThe error says: " + ex.Message;
                log = log + "\nI restored the backup MIDI file, which means nothing changed.";
            }
            log = log + "\nNemo's MIDI AutoGen process completed.";
            return log;
        }

        private static int GetNewNoteNumber(int number)
        {
            switch (number)
            {
                case 96:
                    return 60;
                case 97:
                    return 62;
                case 98:
                    return 64;
                case 99:
                    return 65;
                case 100:
                    return 67;
                case 103:
                    return 115; //solo marker
                default:
                    return number;
            }
        }

        public bool MidiIsClean(string MIDIfile, bool has_keys)
        {
            return MidiIsClean(MIDIfile, has_keys, false);
        }

        public bool MidiIsClean(string MIDIfile, bool has_keys, bool has_pro)
        {
            var MIDIpath = MIDIfile;
            MIDI_ERRORS = 0;
            MIDI_ERROR_MESSAGE = "";
            KEYS_BRE = 0;
            PROKEYS_BRE = 0;
            try
            {
                songMidi = NemoLoadMIDI(MIDIpath);
                if (songMidi == null)
                {
                    return true; //let it compile and MagmaCompiler will crash later
                }
                TicksPerQuarter = songMidi.DeltaTicksPerQuarterNote;
                BuildTempoList();
                BuildTimeSignatureList();
                for (var i = 0; i < songMidi.Events.Tracks; i++)
                {
                    var track = GetMidiTrackName(songMidi.Events[i][0].ToString());
                    if (!track.Contains("VOCALS") && !track.Contains("HARM")) continue;
                    if (track.Contains("PART HARM"))
                    {
                        MIDI_ERRORS++;
                        MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\n" + (track + ": this track name is no longer used, please change track name to " + track.Replace("PART ", "") + ".");
                    }
                    foreach (var notes in songMidi.Events[i])
                    {
                        var message = "";
                        switch (notes.CommandCode)
                        {
                            case MidiCommandCode.MetaEvent:
                                var vocal_event = (MetaEvent) notes;
                                if (vocal_event.ToString().Contains("range") && vocal_event.ToString().Contains("shift"))
                                {
                                    MIDI_ERRORS++;
                                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\n" + (track + ": range shift event at " + GetMBT(vocal_event.AbsoluteTime) + " is not allowed.");
                                }
                                else if (vocal_event.ToString().Contains("lyric") && vocal_event.ToString().Contains("shift"))
                                {
                                    MIDI_ERRORS++;
                                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\n" + (track + ": lyric shift event at " + GetMBT(vocal_event.AbsoluteTime) + " is not allowed.");
                                }
                                break;
                            case MidiCommandCode.NoteOn:
                                var note = (NoteOnEvent) notes;
                                switch (note.NoteNumber)
                                {
                                    case 0:
                                        message = message + track + ": note " + note.NoteNumber + " at " + GetMBT(note.AbsoluteTime) + " is used for range shifting only, if this is an old MIDI this may be a tonic note indicator.\n";
                                        break;
                                    case 1:
                                        message = message + track + ": note " + note.NoteNumber + " at " + GetMBT(note.AbsoluteTime) + " is used for lyric shifting only, if this is an old MIDI this may be a tonic note indicator.\n";
                                        break;
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:
                                    case 7:
                                    case 8:
                                    case 9:
                                    case 10:
                                    case 11:
                                        message = message + track + ": note " + note.NoteNumber + " at " + GetMBT(note.AbsoluteTime) + " is a tonic note indicator and not used in RB3\n";
                                        MIDI_ERRORS++;
                                        break;
                                }
                                if (message != "")
                                {
                                    message = "\n" + message + "Remove this note and use tonic note value " + note.NoteNumber +" in Magma: Rok On Edition";
                                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + message;
                                }
                                break;
                        }
                    }
                }
                if (has_pro)
                {
                    for (var i = 0; i < songMidi.Events.Tracks; i++)
                    {
                        if (songMidi.Events[i][0].ToString().Contains("REAL_BASS"))
                        {
                            CheckTrackForEMH(songMidi.Events[i], 96, 99, 72, 75, 48, 51, 24, 27, true);
                            ValidateProVelocities(songMidi.Events[i]);
                        }
                        else if (songMidi.Events[i][0].ToString().Contains("REAL_GUITAR"))
                        {
                            CheckTrackForEMH(songMidi.Events[i], 96, 101, 72, 77, 48, 53, 24, 29, true);
                            ValidateProVelocities(songMidi.Events[i]);
                        }
                    }
                }
                if (has_keys)
                {
                    for (var i = 0; i < songMidi.Events.Tracks; i++)
                    {
                        if (songMidi.Events[i][0].ToString().Contains("PART KEYS_ANIM_"))
                        {
                            ValidateMidiTrack(songMidi.Events[i], ALLOWED_PRO_KEYS_ANIM_NOTES);
                        }
                        else if (songMidi.Events[i][0].ToString().Contains("PART REAL_KEYS"))
                        {
                            if (songMidi.Events[i][0].ToString().Contains("X"))
                            {
                                ValidateMidiTrack(songMidi.Events[i], ALLOWED_PRO_KEYS_X_NOTES,2);
                            }
                            else
                            {
                                ValidateMidiTrack(songMidi.Events[i], ALLOWED_PRO_KEYS_NOTES);
                            }
                        }
                        else if (songMidi.Events[i][0].ToString().Contains("PART KEYS") &&
                            !songMidi.Events[i][0].ToString().Contains("PART KEYS_ANIM_"))
                        {
                            ValidateMidiTrack(songMidi.Events[i], ALLOWED_KEYS_NOTES,1);
                        }
                    }
                }
                if (KEYS_BRE != 0 && PROKEYS_BRE == 0)
                {
                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nBig Rock Ending markers found for Standard Keys at " + GetMBT(KEYS_BRE) + " but not for Pro Keys.";
                    MIDI_ERRORS++;
                }
                else if (KEYS_BRE == 0 && PROKEYS_BRE != 0)
                {
                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nBig Rock Ending marker found for Pro Keys at " + GetMBT(PROKEYS_BRE) + " but not for Standard Keys.";
                    MIDI_ERRORS++;
                }
                else if (KEYS_BRE != 0 && PROKEYS_BRE != 0 && KEYS_BRE != PROKEYS_BRE)
                {
                    MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\nBig Rock Ending markers for Standard Keys are at " + GetMBT(KEYS_BRE) + " but the Big Rock Ending marker for Pro Keys is at " + GetMBT(PROKEYS_BRE) + " \nBig Rock Endings must start at the same time.";
                    MIDI_ERRORS++;
                }
            }
            catch (Exception){}
            return MIDI_ERRORS <= 0;
        }

        private void ValidateProVelocities(IList<MidiEvent> track)
        {
            var trackname = GetMidiTrackName(track[0].ToString());
            var allowed = new List<int> { 24, 25, 26, 27, 28, 29, 31, 48, 49, 50, 51, 52, 53, 55, 72, 73, 74, 75, 76, 77, 79, 96, 97, 98, 99, 100, 101, 103, 108};
            const int min_velocity = 100;
            var max_velocity = 117;
            if (trackname.Contains("22"))
            {
                max_velocity = 127;
            }
            foreach (var note in track.Where(notes => notes.CommandCode == MidiCommandCode.NoteOn).Cast<NoteOnEvent>().Where(note => allowed.Contains(note.NoteNumber)).Where(note => note.Velocity < min_velocity || note.Velocity > max_velocity).Where(note => note.Velocity != 0))
            {
                MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\n" + (trackname + ": MIDI note " + note.NoteNumber + " at " + GetMBT(note.AbsoluteTime) + " has invalid velocity " + note.Velocity + ".");
                MIDI_ERRORS++;
            }
        }

        private void ValidateMidiTrack(IList<MidiEvent> track, int[] allowed_notes, int type = 0)
        {
            var trackname = GetMidiTrackName(track[0].ToString());
            var keys_chart = track;
            foreach (var notes in keys_chart)
            {
                if (notes.CommandCode != MidiCommandCode.NoteOn) continue;
                var note = (NoteOnEvent)notes;
                var allowed = allowed_notes.Any(keynote => note.NoteNumber == keynote);
                if (note.NoteNumber == 120) //BRE note for both 5 Lane and Pro-Keys
                {
                    switch (type)
                    {
                        case 1:
                            KEYS_BRE = note.AbsoluteTime;
                            break;
                        case 2:
                            PROKEYS_BRE = note.AbsoluteTime;
                            break;
                    }
                }
                if (allowed) continue;
                MIDI_ERROR_MESSAGE = MIDI_ERROR_MESSAGE + "\n" + (trackname + ": MIDI note " + note.NoteNumber + " at " + GetMBT(note.AbsoluteTime) + " is not allowed.");
                MIDI_ERRORS++;
            }
        }
        
        public bool CheckMIDIFor2X(string MIDI)
        {
            try
            {
                songMidi = NemoLoadMIDI(MIDI);
                if (songMidi == null) return false;
                var trackname = "";
                for (var i = 0; i < songMidi.Events.Tracks; i++)
                {
                    foreach (var track in songMidi.Events[i].Where(name => name.CommandCode == MidiCommandCode.MetaEvent).Select(name => (MetaEvent) name).Where(track => track.MetaEventType == MetaEventType.SequenceTrackName))
                    {
                        trackname = GetMidiTrackName(track.ToString()).ToLowerInvariant();
                        break;
                    }
                    if (trackname.Contains("drums") && trackname.Contains("2x")) return true;
                }
            }
            catch (Exception) {}
            return false;
        }

        public bool RemovePSDrumsXNotes(string MIDI)
        {
            try
            {
                songMidi = NemoLoadMIDI(MIDI);
                if (songMidi == null) return false;
                var cleaned = false;
                var trackname = "";
                for (var i = 0; i < songMidi.Events.Tracks; i++)
                {
                    foreach (var track in songMidi.Events[i].Where(name => name.CommandCode == MidiCommandCode.MetaEvent).Select(name => (MetaEvent)name).Where(track => track.MetaEventType == MetaEventType.SequenceTrackName))
                    {
                        trackname = GetMidiTrackName(track.ToString()).ToLowerInvariant();
                        break;
                    }
                    if (!trackname.Contains("drums")) continue;
                    var to_remove = new List<MidiEvent>();
                    for (var z = 0; z < songMidi.Events[i].Count; z++)
                    {
                        var notes = songMidi.Events[i][z];
                        switch (notes.CommandCode)
                        {
                            case MidiCommandCode.NoteOn:
                            {
                                var note = (NoteOnEvent) notes;
                                if (note.NoteNumber == 95)
                                {
                                    to_remove.Add(note);
                                }
                            }
                            break;
                            case MidiCommandCode.NoteOff:
                            {
                                var note = (NoteEvent)notes;
                                if (note.NoteNumber == 95)
                                {
                                    to_remove.Add(note);
                                }
                            }
                            break;
                        }
                    }
                    if (!to_remove.Any()) continue;
                    cleaned = true;
                    foreach (var remove in to_remove)
                    {
                        songMidi.Events[i].Remove(remove);
                    }
                    break;
                }
                if (!cleaned) return true;
                MidiFile.Export(MIDI, songMidi.Events);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Separate2XMidi(string MIDI)
        {
            MIDI1X = Path.GetDirectoryName(MIDI) + "\\" + Path.GetFileNameWithoutExtension(MIDI) + "1x.mid";
            MIDI2X = Path.GetDirectoryName(MIDI) + "\\" + Path.GetFileNameWithoutExtension(MIDI) + "2x.mid";
            var temp = Path.GetDirectoryName(MIDI) + "\\" + Path.GetFileNameWithoutExtension(MIDI) + "_temp.mid";
            DeleteFile(MIDI1X);
            DeleteFile(MIDI2X);
            DeleteFile(temp);
            try
            {
                File.Copy(MIDI, temp);
                songMidi = NemoLoadMIDI(temp);
                if (songMidi == null) return false;
                var trackname = "";

                for (var i = 0; i < songMidi.Events.Tracks; i++)
                {
                    foreach (var track in songMidi.Events[i].Where(name => name.CommandCode == MidiCommandCode.MetaEvent).Select(name => (MetaEvent)name).Where(track => track.MetaEventType == MetaEventType.SequenceTrackName))
                    {
                        trackname = GetMidiTrackName(track.ToString()).ToLowerInvariant();
                        break;
                    }

                    if (!trackname.Contains("drums") || !trackname.Contains("2x")) continue;
                    songMidi.Events.RemoveTrack(i);
                    break;
                }
                MidiFile.Export(MIDI1X, songMidi.Events);
                DeleteFile(temp);
                File.Copy(MIDI, temp);
                songMidi = NemoLoadMIDI(temp);
                if (songMidi == null) return false;
                var removename = -1;
                var removetrack = -1;

                for (var i = 0; i < songMidi.Events.Tracks; i++)
                {
                    for (var z = 0; z < songMidi.Events[i].Count; z++ )
                    {
                        var name = songMidi.Events[i][z];

                        if (name.CommandCode != MidiCommandCode.MetaEvent) continue;
                        var track = (MetaEvent)name;
                        if (track.MetaEventType != MetaEventType.SequenceTrackName) continue;
                        trackname = GetMidiTrackName(track.ToString()).ToLowerInvariant();
                        removename = z;
                        break;
                    }
                    if (trackname.Contains("drums") && trackname.Contains("2x"))
                    {
                        songMidi.Events[i].RemoveAt(removename);
                        songMidi.Events[i].Add(new TextEvent("PART DRUMS", MetaEventType.SequenceTrackName, 0));
                    }
                    else if (trackname.Contains("drums") && !trackname.Contains("2x"))
                    {
                        removetrack = i;
                    }
                }

                if (removetrack > -1)
                {
                    songMidi.Events.RemoveTrack(removetrack);
                }
                MidiFile.Export(MIDI2X, songMidi.Events);
                DeleteFile(temp);
                return true;
            }
            catch (Exception){}
            return false;
        }

        public ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            var encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        /// <summary>
        /// Loads image and unlocks file for uses elsewhere. USE THIS!
        /// </summary>
        /// <param name="file">Full path to the image file</param>
        /// <returns></returns>
        public Image NemoLoadImage(string file)
        {
            if (!File.Exists(file))
            {
                return null;
            }
            Image img;
            using (var bmpTemp = new Bitmap(file))
            {
                img = new Bitmap(bmpTemp);
            }
            return img;
        }

        private string GetMBT(long absdelta)
        {
            var time_sig = 4;
            var time_division = 4;
            var totalmeasures = 0;
            long beats_counter = 0;
            var beat_length = TicksPerQuarter;

            long i = 0;
            while (i <= absdelta)
            {
                beats_counter = absdelta - i;
                var i1 = i;
                foreach (var signature in TimeSignatures.TakeWhile(signature => signature.AbsoluteTime <= i1))
                {
                    time_sig = signature.Numerator;
                    time_division = signature.Denominator;
                }
                totalmeasures++;
                beat_length = TicksPerQuarter / (time_division / 4);
                i += beat_length * time_sig;
            }

            var totalbeats = beats_counter == 0 ? 1 : 1 + ((int)(beats_counter / beat_length)); //beat count starts at 1
            var totalticks = beats_counter - ((totalbeats - 1) * beat_length);

            //let's format the ticks values for a nice string
            var tick = "00";
            if (totalticks <= 0) return ("[" + totalmeasures + ":" + totalbeats + ":" + tick + "]");
            var ticker = Math.Round((Double)totalticks / beat_length, 2);
            tick = ticker.ToString(CultureInfo.InvariantCulture);
            tick = tick.Substring(tick.IndexOf(".", StringComparison.Ordinal) + 1); //we only want the decimal portion
            tick = (tick + "0").Substring(0, 2); //this always returns a 2 digit number

            return ("[" + totalmeasures + ":" + totalbeats + ":" + tick + "]");
        }

        private void BuildTempoList()
        {
            //code provided by raynebc
            //Build tempo list
            var currentbpm = 120.00;
            var realtime = 0.0;
            var reldelta = 0;   //The number of delta ticks since the last tempo change
            TempoEvents = new List<TempoEvent>();
            foreach (var ev in songMidi.Events[0])
            {
                reldelta += ev.DeltaTime;
                if (ev.CommandCode != MidiCommandCode.MetaEvent) continue;
                var tempo = (MetaEvent)ev;
                if (tempo.MetaEventType != MetaEventType.SetTempo) continue;
                var relativetime = (double)reldelta / TicksPerQuarter * (60000.0 / currentbpm);
                var index1 = tempo.ToString().IndexOf("SetTempo", StringComparison.Ordinal) + 9;
                var index2 = tempo.ToString().IndexOf("bpm", StringComparison.Ordinal);
                var bpm = tempo.ToString().Substring(index1, index2 - index1);
                currentbpm = Convert.ToDouble(bpm);   //As per the MIDI specification, until a tempo change is reached, 120BPM is assumed
                realtime += relativetime;   //Add that to the ongoing current real time of the MIDI
                reldelta = 0;
                var tempo_event = new TempoEvent
                {
                    AbsoluteTime = tempo.AbsoluteTime,
                    RealTime = realtime,
                    BPM = currentbpm
                };
                TempoEvents.Add(tempo_event);
            }
        }

        private void BuildTimeSignatureList()
        {
            TimeSignatures = new List<TimeSignature>();
            foreach (var ev in songMidi.Events[0])
            {
                if (ev.CommandCode != MidiCommandCode.MetaEvent) continue;
                var signature = (MetaEvent)ev;
                if (signature.MetaEventType != MetaEventType.TimeSignature) continue;
                //Track the time signature change
                var index1 = signature.ToString().IndexOf(" ", signature.ToString().IndexOf("TimeSignature", StringComparison.Ordinal), StringComparison.Ordinal) + 1;
                var index2 = signature.ToString().IndexOf("/", StringComparison.Ordinal);
                var numerator = Convert.ToInt16(signature.ToString().Substring(index1, index2 - index1));
                //Track the time signature change
                index1 = signature.ToString().IndexOf("/", StringComparison.Ordinal) + 1;
                index2 = signature.ToString().IndexOf(" ", signature.ToString().IndexOf("/", StringComparison.Ordinal), StringComparison.Ordinal);
                var denominator = Convert.ToInt16(signature.ToString().Substring(index1, index2 - index1));
                var time_sig = new TimeSignature
                {
                    AbsoluteTime = ev.AbsoluteTime,
                    Numerator = numerator,
                    Denominator = denominator
                };
                TimeSignatures.Add(time_sig);
            }
        }
        
        private static byte[] BuildDDSHeader(string format, int width, int height)
        {
            var dds = new byte[] //512x512 DXT5
                {
                    0x44, 0x44, 0x53, 0x20, 0x7C, 0x00, 0x00, 0x00, 0x07, 0x10, 0x0A, 0x00, 0x00, 0x02, 0x00, 0x00, 
                    0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                    0x00, 0x00, 0x00, 0x00, 0x4E, 0x45, 0x4D, 0x4F, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 
                    0x04, 0x00, 0x00, 0x00, 0x44, 0x58, 0x54, 0x35, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
                };

            switch (format.ToLowerInvariant())
            {
                case "dxt1":
                    dds[87] = 0x31;
                    break;
            }

            switch (height)
            {
                case 256:
                    dds[13] = 0x01;
                    break;
                case 1024:
                    dds[13] = 0x04;
                    break;
                case 2048:
                    dds[13] = 0x08;
                    break;
            }

            switch (width)
            {
                case 256:
                    dds[17] = 0x01;
                    break;
                case 1024:
                    dds[17] = 0x04;
                    break;
                case 2048:
                    dds[17] = 0x08;
                    break;
            }
            return dds;
        }

        /// <summary>
        /// Figure out right DDS header to go with HMX texture
        /// </summary>
        /// <param name="full_header">First 16 bytes of the png_xbox/png_ps3 file</param>
        /// <param name="short_header">Bytes 5-16 of the png_xbox/png_ps3 file</param>
        /// <returns></returns>
        private static byte[] GetDDSHeader(IEnumerable<byte> full_header, IEnumerable<byte> short_header)
        {
            //official album art header, most likely to be the one being requested
            var header = BuildDDSHeader("dxt1", 256, 256);
            var headers = Directory.GetFiles(Application.StartupPath + "\\bin\\headers\\", "*.header");

            foreach (var head in from head in headers let header_bytes = File.ReadAllBytes(head) where full_header.SequenceEqual(header_bytes) || short_header.SequenceEqual(header_bytes) select head)
            {
                var head_name = Path.GetFileNameWithoutExtension(head).ToLowerInvariant();
                var format = head_name.Contains("dxt1") ? "dxt1" : "dxt5";

                var index1 = head_name.IndexOf("_", StringComparison.Ordinal) + 1;
                var index2 = head_name.IndexOf("x", StringComparison.Ordinal);
                var width = Convert.ToInt16(head_name.Substring(index1, index2 - index1));
                index1 = head_name.IndexOf("_", index2, StringComparison.Ordinal);
                index2++;
                var height = Convert.ToInt16(head_name.Substring(index2, index1 - index2));

                header = BuildDDSHeader(format, width, height);
                break;
            }
            
            return header;
        }

        /// <summary>
        /// Converts png_xbox files to png format
        /// </summary>
        /// <param name="rb_image">Full path to the png_xbox / dds file</param>
        /// <param name="output_path">Full path you'd like to save the converted image</param>
        /// <param name="delete_original">True: delete | False: keep (default)</param>
        /// <returns></returns>
        public bool ConvertRBImage(string rb_image, string output_path, bool delete_original = false)
        {
            var ddsfile = Path.GetDirectoryName(output_path) + "\\" + Path.GetFileNameWithoutExtension(output_path) + ".dds";
            var tgafile = ddsfile.Replace(".dds", ".tga");

            TextureSize = 256; //default size album art
            
            var nv_tool = Application.StartupPath + "\\bin\\nvdecompress.exe";
            if (!File.Exists(nv_tool))
            {
                MessageBox.Show("nvdecompress.exe is missing and is required\nProcess aborted", "Nemo Tools", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                if (ddsfile != rb_image)
                {
                    DeleteFile(ddsfile);
                }
                DeleteFile(tgafile);

                //read raw file bytes
                var ddsbytes = File.ReadAllBytes(rb_image);

                if (!rb_image.EndsWith(".dds", StringComparison.Ordinal))
                {
                    var buffer = new byte[4];
                    var swap = new byte[4];

                    //get filesize / 4 for number of times to loop
                    //32 is the size of the HMX header to skip
                    var loop = (ddsbytes.Length - 32) / 4;

                    //skip the HMX header
                    var input = new MemoryStream(ddsbytes, 32, ddsbytes.Length - 32);

                    //grab HMX header to compare against known headers
                    var full_header = new byte[16];
                    var file_header = new MemoryStream(ddsbytes, 0, 16);
                    file_header.Read(full_header, 0, 16);
                    file_header.Dispose();

                    //some games have a bunch of headers for the same files, so let's skip the varying portion and just
                    //grab the part that tells us the dimensions and image format
                    var short_header = new byte[11];
                    file_header = new MemoryStream(ddsbytes, 5, 11);
                    file_header.Read(short_header, 0, 11);
                    file_header.Dispose();

                    //create dds file
                    var output = new FileStream(ddsfile, FileMode.Create);
                    var header = GetDDSHeader(full_header, short_header);
                    output.Write(header, 0, header.Length);

                    //here we go
                    for (var x = 0; x <= loop; x++)
                    {
                        input.Read(buffer, 0, 4);

                        //XBOX images are byte swapped, so we gotta return it
                        swap[0] = buffer[1];
                        swap[1] = buffer[0];
                        swap[2] = buffer[3];
                        swap[3] = buffer[2];
                        output.Write(swap, 0, 4);
                    }
                    input.Dispose();
                    output.Dispose();
                }
                else
                {
                    ddsfile = rb_image;
                }

                //read raw dds bytes
                ddsbytes = File.ReadAllBytes(ddsfile);

                //grab relevant part of dds header
                var header_stream = new MemoryStream(ddsbytes, 0, 32);
                var size = new byte[32];
                header_stream.Read(size, 0, 32);
                header_stream.Dispose();

                //default to 256x256
                var width = 256;
                var height = 256;

                //get dds dimensions from header
                switch (size[17]) //width byte
                {
                    case 0x02:
                        width = 512;
                        break;
                    case 0x04:
                        width = 1024;
                        break;
                    case 0x08:
                        width = 2048;
                        break;
                }
                switch (size[13]) //height byte
                {
                    case 0x02:
                        height = 512;
                        break;
                    case 0x04:
                        height = 1024;
                        break;
                    case 0x08:
                        height = 2048;
                        break;
                }

                TextureSize = width;
                if (height > width)
                {
                    TextureSize = height;
                }

                var arg = "\"" + ddsfile + "\"";
                var startInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    FileName = nv_tool,
                    Arguments = arg,
                    WorkingDirectory = Application.StartupPath + "\\bin\\"
                };
                var process = Process.Start(startInfo);
                do
                {
                    //
                } while (!process.HasExited);
                process.Dispose();

                if (!ResizeImage(tgafile, TextureSize, ".png", output_path))
                {
                    DeleteFile(tgafile);
                    return false;
                }
                if (!rb_image.EndsWith(".dds", StringComparison.Ordinal))
                {
                    DeleteFile(ddsfile);
                }
                DeleteFile(tgafile);
                if (delete_original)
                {
                    SendtoTrash(rb_image);
                }
                return true;
            }
            catch (Exception)
            {
                if (!rb_image.EndsWith(".dds", StringComparison.Ordinal))
                {
                    DeleteFile(ddsfile);
                }
                return false;
            }
        }
        
        /// <summary>
        /// Returns true after successful conversion to png_xbox format
        /// </summary>
        /// <param name="image_path">Full path to original image</param>
        /// <param name="output_path">Full path of output png_xbox file</param>
        /// <param name="delete_original">True to delete original image | False to keep original image</param>
        /// <returns></returns>
        public bool ConvertImagetoRB(string image_path, string output_path, bool delete_original = false)
        {
            var ddsfile = Path.GetDirectoryName(image_path) + "\\" + Path.GetFileNameWithoutExtension(image_path) + ".dds";
            var outputfile = Path.GetDirectoryName(output_path) + "\\" + Path.GetFileNameWithoutExtension(output_path) + ".png_xbox";
            var tgafile = Application.StartupPath + "\\bin\\temp.tga";
            var Headers = new ImageHeaders();

            var nv_tool = Application.StartupPath + "\\bin\\nvcompress.exe";
            if (!File.Exists(nv_tool))
            {
                MessageBox.Show("nvcompress.exe is missing and is required\nProcess aborted", "Nemo Tools", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                if (ddsfile != image_path)
                {
                    DeleteFile(ddsfile);
                }
                DeleteFile(outputfile);
                DeleteFile(tgafile);

                if (!image_path.EndsWith(".dds", StringComparison.Ordinal)) //allow for .dds input image for superior quality
                {
                    if (!ResizeImage(image_path, TextureSize, "tga", tgafile))
                    {
                        return false;
                    }

                    try
                    {
                        //save as 512x512 / 1024x1024 DXT5 textures - first time ever in RB3 customs @ TrojanNemo 2014 bitches
                        var arg = "-nocuda -bc3 \"" + tgafile + "\" \"" + ddsfile + "\"";
                        var startInfo = new ProcessStartInfo
                        {
                            CreateNoWindow = true,
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            FileName = nv_tool,
                            Arguments = arg,
                            WorkingDirectory = Application.StartupPath + "\\bin\\"
                        };
                        var process = Process.Start(startInfo);
                        do
                        {
                            //
                        } while (!process.HasExited);
                        //Application.DoEvents();
                        process.Dispose();

                        if (!File.Exists(ddsfile))
                        {
                            return false;
                        }
                        DeleteFile(tgafile);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                else
                {
                    ddsfile = image_path;
                }

                //read all raw bytes
                var ddsbytes = File.ReadAllBytes(ddsfile);
                var buffer = new byte[4];
                var swap = new byte[4];

                //default header
                var header = Headers.RB3_512x512_DXT5;
                switch (TextureSize)
                {
                    case 256:
                        header = Headers.RB3_256x256_DXT5;
                        break;
                    case 1024:
                        header = Headers.NEMO_1024x1024_DXT5;
                        break;
                    case 2048:
                        header = Headers.NEMO_2048x2048_DXT5;
                        break;
                }

                //get filesize / 4 for number of times to loop
                //128 is size of dds header we have to skip
                var loop = (ddsbytes.Length - 128) / 4;

                //skip the first dds header
                var input = new MemoryStream(ddsbytes, 128, ddsbytes.Length - 128);
                var output = new FileStream(outputfile, FileMode.Create);

                //write HMX header
                output.Write(header, 0, header.Length);

                //here we go
                for (var x = 0; x <= loop; x++)
                {
                    input.Read(buffer, 0, 4);
                    //png_xbox are byte swapped, so got to change it here
                    swap[0] = buffer[1];
                    swap[1] = buffer[0];
                    swap[2] = buffer[3];
                    swap[3] = buffer[2];
                    output.Write(swap, 0, 4);
                }
                input.Dispose();
                output.Dispose();

                //clean up temporary file silently
                if (!image_path.EndsWith(".dds", StringComparison.Ordinal))
                {
                    DeleteFile(ddsfile);
                }
                if (delete_original)
                {
                    SendtoTrash(image_path);
                }
                if (File.Exists(outputfile))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                if (!image_path.EndsWith(".dds", StringComparison.Ordinal))
                {
                    DeleteFile(ddsfile);
                }
                DeleteFile(tgafile);
                return false;
            }
            return false;
        }
        
        /// <summary>
        /// Use to resize images up or down or convert across BMP/JPG/PNG/TIF
        /// </summary>
        /// <param name="image_path">Full file path to source image</param>
        /// <param name="image_size">Integer for image size, can be smaller or bigger than source image</param>
        /// <param name="format">Format to save the image in: BMP | JPG | TIF | PNG (default)</param>
        /// <param name="output_path">Full file path to output image</param>
        /// <returns></returns>
        public bool ResizeImage(string image_path, int image_size, string format, string output_path)
        {
            try
            {
                var newimage = Path.GetDirectoryName(output_path) + "\\" + Path.GetFileNameWithoutExtension(output_path);

                Il.ilInit();
                Ilu.iluInit();

                var imageId = new int[10];

                // Generate the main image name to use
                Il.ilGenImages(1, imageId);

                // Bind this image name
                Il.ilBindImage(imageId[0]);

                // Loads the image into the imageId
                if (!Il.ilLoadImage(image_path))
                {
                    return false;
                }
                // Enable overwriting destination file
                Il.ilEnable(Il.IL_FILE_OVERWRITE);

                //assume we're downscaling, this is better filter
                const int scaler = Ilu.ILU_BILINEAR;

                //resize image
                Ilu.iluImageParameter(Ilu.ILU_FILTER, scaler);
                Ilu.iluScale(image_size, image_size, 1);

                if (format.ToLowerInvariant().Contains("bmp"))
                {
                    //disable compression
                    Il.ilSetInteger(Il.IL_BMP_RLE, 0);
                    newimage = newimage + ".bmp";
                }
                else if (format.ToLowerInvariant().Contains("jpg") || format.ToLowerInvariant().Contains("jpeg"))
                {
                    Il.ilSetInteger(Il.IL_JPG_QUALITY, 99);
                    newimage = newimage + ".jpg";
                }
                else if (format.ToLowerInvariant().Contains("tif"))
                {
                    newimage = newimage + ".tif";
                }
                else if (format.ToLowerInvariant().Contains("tga"))
                {
                    Il.ilSetInteger(Il.IL_TGA_RLE, 0);
                    newimage = newimage + ".tga";
                }
                else
                {
                    Il.ilSetInteger(Il.IL_PNG_INTERLACE, 0);
                    newimage = newimage + ".png";
                }

                if (!Il.ilSaveImage(newimage))
                {
                    return false;
                }

                // Done with the imageId, so let's delete it
                Il.ilDeleteImages(1, imageId);

                if (Path.GetExtension(newimage) == ".bmp")
                {
                    CreateAlbumArt(newimage, newimage);
                }

                return File.Exists(newimage);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateAlbumArt(string image, string bmp)
        {
            var img = NemoLoadImage(image);
            var albumart = new Bitmap(256, 256, PixelFormat.Format32bppArgb);
            albumart.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            using (var graphics = Graphics.FromImage(albumart))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(img, 0, 0, albumart.Width, albumart.Height);
            }

            DeleteFile(bmp);
            SaveBmpInfoHeader32bpp(bmp, albumart);

            albumart.Dispose();
            img.Dispose();

            return File.Exists(bmp);
        }

        public static void SaveBmpInfoHeader32bpp(string path, Bitmap bmp)
        {
            if (bmp == null) throw new ArgumentNullException(nameof(bmp));

            // Force a known pixel format to avoid surprises
            Bitmap src = bmp;
            Bitmap converted = null;
            if (bmp.PixelFormat != PixelFormat.Format32bppArgb && bmp.PixelFormat != PixelFormat.Format32bppPArgb)
            {
                converted = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppArgb);
                using (var g = Graphics.FromImage(converted))
                    g.DrawImageUnscaled(bmp, 0, 0);
                src = converted;
            }

            var rect = new Rectangle(0, 0, src.Width, src.Height);
            var data = src.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                int w = src.Width;
                int h = src.Height;

                // BMP rows are padded to 4 bytes; for 32bpp, stride is already multiple of 4
                int stride = data.Stride;
                int imageSize = stride * h;

                // File header (14) + info header (40) = 54
                const int fileHeaderSize = 14;
                const int infoHeaderSize = 40;
                int offBits = fileHeaderSize + infoHeaderSize;
                int fileSize = offBits + imageSize;

                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
                using (var bw = new BinaryWriter(fs))
                {
                    // BITMAPFILEHEADER
                    bw.Write((ushort)0x4D42);      // 'BM'
                    bw.Write(fileSize);
                    bw.Write((ushort)0);           // bfReserved1
                    bw.Write((ushort)0);           // bfReserved2
                    bw.Write(offBits);             // bfOffBits

                    // BITMAPINFOHEADER (40 bytes)
                    bw.Write(infoHeaderSize);      // biSize
                    bw.Write(w);                   // biWidth
                    bw.Write(h);                   // biHeight (positive => bottom-up)
                    bw.Write((ushort)1);           // biPlanes
                    bw.Write((ushort)32);          // biBitCount
                    bw.Write(0);                   // biCompression = BI_RGB
                    bw.Write(imageSize);           // biSizeImage
                    bw.Write((int)(src.HorizontalResolution * 39.3701)); // biXPelsPerMeter (approx)
                    bw.Write((int)(src.VerticalResolution * 39.3701));   // biYPelsPerMeter
                    bw.Write(0);                   // biClrUsed
                    bw.Write(0);                   // biClrImportant

                    // Pixel data: must be bottom-up for positive height
                    // data.Scan0 is top-down in memory, so write rows in reverse order.
                    byte[] row = new byte[stride];
                    for (int y = h - 1; y >= 0; y--)
                    {
                        IntPtr rowPtr = IntPtr.Add(data.Scan0, y * stride);
                        Marshal.Copy(rowPtr, row, 0, stride);
                        bw.Write(row);
                    }
                }
            }
            finally
            {
                src.UnlockBits(data);
                converted?.Dispose();
            }
        }


        /// <summary>
        /// Loads and formats help file for display on the HelpForm
        /// </summary>
        /// <param name="file">Name of the file, path assumed to be \bin\help/</param>
        /// <returns></returns>
        public string ReadHelpFile(string file)
        {
            var message = "";
            var helpfile = Application.StartupPath + "\\bin\\help\\" + file;
            if (File.Exists(helpfile))
            {
                var sr = new StreamReader(helpfile);
                while (sr.Peek() > 0)
                {
                    var line = sr.ReadLine();
                    message = message == "" ? line : message + "\r\n" + line;
                }
                sr.Dispose();
            }
            else
            {
                message = "Could not find help file, please redownload this program and DO NOT delete any files";
            }

            return message;
        }

        #region Mogg Stuff
        public void ReleaseStreamHandle()
        {
            try
            {
                PlayingOggStreamHandle.Free();
            }
            catch (Exception)
            { }
        }

        public IntPtr GetOggStreamIntPtr()
        {
            ReleaseStreamHandle();
            PlayingOggStreamHandle = GCHandle.Alloc(PlayingSongOggData, GCHandleType.Pinned);
            return PlayingOggStreamHandle.AddrOfPinnedObject();
        }        

        private GCHandle PlayingOggStreamHandle;
        public byte[] PlayingSongOggData;
        public byte[] NextSongOggData;
        
        #endregion
    }

    public class TempoEvent
    {
        public long AbsoluteTime { get; set; }
        public double RealTime { get; set; }
        public double BPM { get; set; }
    }

    public class TimeSignature
    {
        public long AbsoluteTime { get; set; }
        public int Numerator { get; set; }
        public int Denominator { get; set; }
    }
}
