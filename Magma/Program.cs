using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Un4seen.Bass;

namespace MagmaRokOn
{
    static class Program
    {
        private static string mStrSavedDirectory = "";
        private static readonly Dictionary<string, string> mFileStartPaths = new Dictionary<string, string>();
        public const string kAppName = "Magma: Rok On Edition";
        private const string bKey = "2X14232420202322";
        private const string user = "nemo";
        private const string domain = "keepitfishy";

        public static string StartupDirectory { get; private set; }
        
        public static bool HasStartDirectory(string key)
        {
            return mFileStartPaths.ContainsKey(key);
        }

        public static string GetStartDirectory(string key)
        {
            return mFileStartPaths.ContainsKey(key) ? mFileStartPaths[key] : mFileStartPaths["default"];
        }

        public static void SetStartDirectory(string key, string value)
        {
            mFileStartPaths[key] = value;
        }

        public static void RestoreStartupDirectory()
        {
            Directory.SetCurrentDirectory(StartupDirectory);
        }

        public static void SaveCurrentDirectory()
        {
            mStrSavedDirectory = Directory.GetCurrentDirectory();
        }

        public static void RestoreCurrentDirectory()
        {
            if (mStrSavedDirectory.Length <= 0)
                return;
            Directory.SetCurrentDirectory(mStrSavedDirectory);
        }

        [STAThread]
        static void Main(string[] args)
        {
            BassNet.Registration(user + "@" + domain + ".com", bKey);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartupDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            RestoreStartupDirectory();
            SetStartDirectory("default", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            if (Application.StartupPath.Contains("Program Files"))
            {
                MessageBox.Show("I noticed that you are trying to run " + kAppName + " from the Program Files directory!\n\nInstallation instructions say not to do that, as it can cause permission errors...\n\nPlease move " + kAppName + " out of Program Files to another directory and try again.",
                    kAppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
            try
            {
                Wrapper.Init(Environment.CommandLine, "config/magma.dta");
            }
            catch (DllNotFoundException)
            {
                UGCDebug.ShowStopMsgBox(Environment.GetCommandLineArgs()[0] + " cannot run because MagmaCore.dll is missing.\n\nYour best bet is " +
                                        "to re-run the original installer, which will make sure all the files are in the right places.");
                return;
            }
            catch (Exception)
            {
                UGCDebug.ShowStopMsgBox(Environment.GetCommandLineArgs()[0] + " cannot run because something went wrong while loading " +
                                        "MagmaCore.dll.\n\nTry running the app again, and if it continues to happen, your best bet is to " +
                                        "re-download from https://github.com/trojannemo/magma-rok-on or from https://nemosnautilus.com/magma/, which will make sure all the files are in the right places.");
                return;
            }
            try
            {
                var arguments = (args.Aggregate("", (current, arg) => current + " " + arg)).ToLowerInvariant().Trim();
                if (arguments.Contains("-miditester") || arguments.Contains(".mid"))
                {
                    var MIDI = "";
                    var file = arguments.Replace("-miditester", "").Trim();
                    file = file.Replace("miditester", "").Trim(); //in case there's no -
                    if (file.EndsWith(".mid", StringComparison.Ordinal))
                    {
                        if (File.Exists(file))
                        {
                            MIDI = file;
                        }
                        else if (File.Exists(Application.StartupPath + "\\" + file))
                        {
                            MIDI = Application.StartupPath + "\\" + file;
                        }
                        else
                        {
                            MIDI = "";
                        }
                    }
                    var tester = new MidiTester(null, MIDI);
                    tester.Log("\n\nMIDI Tester initialized via command-line\nArguments: " + arguments);
                    if (MIDI == "" && arguments.Contains(".mid"))
                    {
                        tester.Log("Could not find that MIDI file, try adding it here manually\n");
                        tester.Log("Ready to begin....\n");
                    }
                    Application.Run(tester);
                }
                else
                {
                    if (arguments.StartsWith("-", StringComparison.Ordinal))
                    {
                        arguments = arguments.Substring(1, arguments.Length - 1);
                    }
                    Application.Run(new MainForm(arguments));
                }
            }
            catch (Exception ex)
            {
                UGCDebug.ShowStopMsgBox(Environment.GetCommandLineArgs()[0] + " just threw an unhandled exception!\nThat means that the programmer messed up, and now whatever you were working on is gone!\nMan, I hate programmers...\n\nHere's some info relating to what just happened:\n\n" + "Source: " + ex.Source + "\n\n" + "Message: " + ex.Message + "\n\n" + "StackTrace: " + ex.StackTrace);
                Environment.Exit(0);
            }
        }
    }
}
