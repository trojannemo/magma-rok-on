using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MagmaRokOn
{
    //this is mostly untouched HMX code and/or code that does not need much attention, if any
    //each one of these classes or enums were on their own .cs file! 
    //consolidated here for neater workspace

    public static class Wrapper
    {
        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Init(string strCommandLine, string strConfig);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus GetSystemConfig(string strTag, out IntPtr dataArray);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus CloneDataTemplate(string strTemplateSymbol, out IntPtr dataArray);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SafeRelease(ref IntPtr dataArray);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FileStatus ReadDtaFile(string strFilename, out IntPtr dataArray);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FileStatus WriteDtaFile(string strFilename, IntPtr dataArray);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus FindTagArray(IntPtr pData, string strTag, out IntPtr ppDataOut);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus FindTagStr(IntPtr pData, string strTag, StringBuilder strOut, int maxLen);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus FindTagSym(IntPtr pData, string strTag, StringBuilder strOut, int maxLen);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus FindTagInt(IntPtr data, string strTag, out int n);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus FindTagFloat(IntPtr data, string strTag, out float n);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus GetSize(IntPtr data, out uint pSize);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus GetArray(IntPtr data, uint index, out IntPtr dataOut);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus GetString(IntPtr data, uint index, StringBuilder strOut, int maxLen);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus GetSym(IntPtr data, uint index, StringBuilder strOut, int maxLen);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus GetInt(IntPtr data, uint index, out int n);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus GetFloat(IntPtr data, uint index, out float n);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus SetTagStr(IntPtr data, string strTag, string strValue);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus SetTagSym(IntPtr data, string strTag, string strValue);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus ForceTagSym(IntPtr data, string strTag, string strValue);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus SetTagInt(IntPtr data, string strTag, int n);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus SetTagFloat(IntPtr data, string strTag, float n);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus InsertArrayAtEnd(IntPtr data, out IntPtr dataOut);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus InsertTagArrayAtEnd(IntPtr data, string strTag, out IntPtr dataOut);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus InsertTagStrAtEnd(IntPtr data, string strTag, string strValue);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus InsertTagSymAtEnd(IntPtr data, string strTag, string strValue);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus InsertTagIntAtEnd(IntPtr data, string strTag, int n);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus AddTagFloatAtEnd(IntPtr data, string strTag, float n);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus SetOrInsertTagStrAtStart(IntPtr data, string strTag, string strValue);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus SetOrInsertTagIntAtStart(IntPtr data, string strTag, int n);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus RemoveTagArray(IntPtr data, string strTag);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern DataStatus ReleaseContents(IntPtr data);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Localize(string strToken, StringBuilder strOut, int maxLen);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FileStatus GetWaveInfo(string strFilename, WaveInfo waveInfo);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsBMPCompilable(string strFilename);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetLockNameFromPathStr(string strPath, StringBuilder strOut, int maxLen);

        [DllImport("MagmaCore.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CanLoadGFWLDll();

        [StructLayout(LayoutKind.Sequential)]
        public class WaveInfo
        {
            public int mIsCompressed;
            public int mNumChannels;
            public int mSampleRate;
            public int mNumSamples;
            public int mBitsPerSample;
        }
    }

    public static class WavUtl
    {
        public static int GetWavLength(Wrapper.WaveInfo w)
        {
            return w.mSampleRate == 0 ? 0 : Convert.ToInt32(w.mNumSamples / w.mSampleRate);
        }
    }

    public static class UiUtl
    {
        public static void SetLocalizedComboBoxValue(ComboBox cb, string value, string[] symbols)
        {
            if (symbols == null)
                throw new MagmaException("No options found for " + Convert.ToString(cb.Tag));

            for (var index = 0; index < symbols.Length; index++)
            {
                if (symbols[index] != value) continue;
                cb.SelectedIndex = index;
                return;
            }
        }

        public static void SetLocalizedComboBoxValue(ComboBox cb, int value, int[] symbols)
        {
            if (symbols == null)
                throw new MagmaException("No options found for " + Convert.ToString(cb.Tag));
            var flag = false;
            int index;
            for (index = 0; index < symbols.Length; ++index)
            {
                if (symbols[index] != value) continue;
                flag = true;
                break;
            }
            if (index < symbols.Length)
                cb.SelectedIndex = index;
            if (!flag)
                throw new MagmaException("Invalid option set for " + Convert.ToString(cb.Tag));
        }

        public static void SetComboBoxValue(ComboBox cb, string value)
        {
            var strArray = (string[])cb.DataSource;
            if (strArray == null)
                throw new MagmaException("No options found for " + Convert.ToString(cb.Tag));
            var flag = false;
            int index;
            for (index = 0; index < strArray.Length; ++index)
            {
                if (strArray[index] != value) continue;
                flag = true;
                break;
            }
            if (index < strArray.Length)
                cb.SelectedIndex = index;
            if (!flag)
                throw new MagmaException("Invalid option set for " + Convert.ToString(cb.Tag));
        }

        public static void SetComboBoxValue(ComboBox cb, int value)
        {
            var numArray = (int[])cb.DataSource;
            if (numArray == null)
                throw new MagmaException("No options found for " + Convert.ToString(cb.Tag));
            var flag = false;
            int index;
            for (index = 0; index < numArray.Length; ++index)
            {
                if (numArray[index] != value) continue;
                flag = true;
                break;
            }
            if (index < numArray.Length)
                cb.SelectedIndex = index;
            if (!flag)
                throw new MagmaException("Invalid option set for " + Convert.ToString(cb.Tag));
        }
    }

    public static class UGCDebug
    {

        public static void Notify(string strMsg)
        {
            MessageBox.Show("Warning: " + strMsg, "Magma: Rok On Edition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void Fail(string strMsg)
        {
            throw new MagmaException(strMsg);
        }

        public static void ShowStopMsgBox(string strMsg)
        {
            MessageBox.Show(strMsg, "Magma: Rok On Edition", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static void ShowOKMsgBox(IWin32Window owner, string strMsg)
        {
            MessageBox.Show(owner, strMsg, "Magma: Rok On Edition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static DialogResult ShowOKCancelMsgBox(IWin32Window owner, string strMsg)
        {
            return MessageBox.Show(owner, strMsg, "Magma: Rok On Edition", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        }

        public static DialogResult ShowYesNoMsgBox(IWin32Window owner, string strMsg)
        {
            return MessageBox.Show(owner, strMsg, "Magma: Rok On Edition", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowYesNoCancelMsgBox(IWin32Window owner, string strMsg)
        {
            return MessageBox.Show(owner, strMsg, "Magma: Rok On Edition", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }

    public class ThreadSafeStringList
    {
        private readonly LinkedList<string> mStringList;

        public const string xmas_msg = "Hello #AUTHOR,\r\n\r\nMerry Christmas, Happy Hanukkah, Happy Kwanzaa, Festivus For The Rest Of Us, " +
                                       "and Happy Holidays!\r\n\r\n#WHEN I (Nemo) sat down to prepare what I expected would be the final " +
                                       "release of Magma: Rok On Edition, I knew I had to think of a way to thank you all for your part in " +
                                       "making C3 the huge success that it is as of today.\r\n\r\nIf you're seeing this message, let me be the " +
                                       "first to tell you that you are a nerd!\r\nYou either looked at the source code, messed with your computer's " +
                                       "clock or are actually working on customs on December #DAYth.\r\nEither way, I think I speak for all other " +
                                       "C3 admins when I say we love you for being the right kind of nerd ... our kind of nerd!\r\n\r\nAs of the " +
                                       "time of this writing, C3 is composed of authors and admins from across the world, so chances are you " +
                                       "celebrate some sort of festivities during this time of year.\r\nIf so, enjoy your holidays! If not, don't feel " +
                                       "left out - you can rejoice in knowing that you are part of the C3 family.\r\n\r\nWhen we launched C3 we were " +
                                       "only a few eager people hoping to extend the life of RB3 for a few more months. We were worried about even " +
                                       "having three new songs every week.\r\nNever did we imagine that we would have 500 songs released in our first " +
                                       "six months, or that we would receive such a warm response from the community, or that we would change the " +
                                       "face of customs authoring forever with our tools and tutorials, and much less that we would be so lucky to " +
                                       "have as many great authors join our ranks as we have.\r\n\r\nNow, this isn't a magic trick, so I can't predict " +
                                       "who you are or what your particular contributions to this project are. But if you're using Magma: Rok On Edition, " +
                                       "you are most definitely a part of the C3 family, in one form or another.\r\n\r\nThank you for your support, " +
                                       "thank you for your contribution, and thank you for helping us keep this great game alive.\r\n\r\nKeep on " +
                                       "rocking.\r\n\r\nNemo, October 25 2013";

        public ThreadSafeStringList()
        {
            mStringList = new LinkedList<string>();
        }

        public void AddString(string str)
        {
            if (str == null)
                return;
            lock (mStringList)
                mStringList.AddLast(str);
        }

        public bool HasString()
        {
            lock (mStringList)
                return mStringList.Count > 0;
        }

        public string GetString()
        {
            var str = "";
            lock (mStringList)
            {
                if (mStringList.Count <= 0) return str;
                str = mStringList.First.Value;
                mStringList.RemoveFirst();
            }
            return str;
        }

        public string[] GetStrings()
        {
            var count = mStringList.Count;
            var strArray = new string[count];
            lock (mStringList)
            {
                for (var local_2 = 0; local_2 < count; ++local_2)
                {
                    strArray[local_2] = mStringList.First.Value;
                    mStringList.RemoveFirst();
                }
            }
            return strArray;
        }

        public void Clear()
        {
            lock (mStringList)
                mStringList.Clear();
        }
    }

    public class ThreadRunner
    {
        private ThreadSafeStringList mList;
        private Thread mThread;
        private string mWorkingDirectory;
        private string mStrApp;
        private string mStrArgs;
        private int mExitCode;
        private NamedMutex mNamedMutex;

        public bool IsRunning { get; private set; }

        public ThreadRunner()
        {
            mList = null;
            mThread = null;
            mWorkingDirectory = null;
            mExitCode = -1;
            IsRunning = false;
            mNamedMutex = null;
        }

        public int GetExitCode()
        {
            return mExitCode;
        }

        public void Poll()
        {
            IsRunning = false;
            if (mThread != null)
                IsRunning = mThread.IsAlive;
            if (IsRunning || mNamedMutex == null || !mNamedMutex.HasMutex)
                return;
            mNamedMutex.ReleaseMutex();
        }

        public void SetStringList(ThreadSafeStringList list)
        {
            if (IsRunning)
                UGCDebug.Fail("Can't call SetStringList() while thread is running");
            mList = list;
        }

        public void SetWorkingDirectory(string strWorkingDirectory)
        {
            if (IsRunning)
                UGCDebug.Fail("Can't call SetWorkingDirectory() while thread is running");
            mWorkingDirectory = strWorkingDirectory;
        }

        public void SetAppName(string strApp)
        {
            if (IsRunning)
                UGCDebug.Fail("Can't call SetAppName() while thread is running");
            mStrApp = strApp;
        }

        public void AddAppArgs(string strArgs)
        {
            if (IsRunning)
                UGCDebug.Fail("Can't call SetAppArgs() while thread is running");
            var threadRunner = this;
            var str = threadRunner.mStrArgs + " " + strArgs.Trim();
            threadRunner.mStrArgs = str;
        }

        public void EnableMutexBreak()
        {
            if (IsRunning)
                UGCDebug.Fail("Can't call EnableMutexBreak() while thread is running");
            if (mNamedMutex != null)
            {
                UGCDebug.Fail("Can't call EnableMutexBreak() more than once");
            }
            else
            {
                var cryptoServiceProvider = new RNGCryptoServiceProvider();
                var data = new byte[8];
                cryptoServiceProvider.GetBytes(data);
                mNamedMutex = new NamedMutex("HMX_Magma_" + data[0].ToString(CultureInfo.InvariantCulture) + data[1].ToString(CultureInfo.InvariantCulture) + data[2].ToString(CultureInfo.InvariantCulture) + data[3].ToString(CultureInfo.InvariantCulture) + data[4].ToString(CultureInfo.InvariantCulture) + data[5].ToString(CultureInfo.InvariantCulture) + data[6].ToString(CultureInfo.InvariantCulture) + data[7].ToString(CultureInfo.InvariantCulture));
                AddAppArgs("-mutex " + mNamedMutex.Name);
            }
        }

        public void Start()
        {
            if (IsRunning)
                UGCDebug.Fail("ThreadRunner can only start one instance at a time.");
            if (mNamedMutex != null)
            {
                mNamedMutex.RequestMutex();
                if (!mNamedMutex.HasMutex)
                    UGCDebug.Notify("Unable to secure the Mutex.  The operation will be unable to cancel.");
            }
            mThread = new Thread(Thread_Start);
            mThread.Start();
        }

        public void SendMutexBreak()
        {
            if (!IsRunning || mNamedMutex == null || !mNamedMutex.HasMutex)
                return;
            mNamedMutex.ReleaseMutex();
        }

        protected void Thread_Start()
        {
            var startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                FileName = mStrApp,
                Arguments = mStrArgs
            };
            if (mWorkingDirectory != null)
                startInfo.WorkingDirectory = mWorkingDirectory;
            var process = Process.Start(startInfo);
            var standardOutput = process.StandardOutput;
            do
            {
                mList.AddString(standardOutput.ReadLine());
            }
            while (!process.HasExited);
            mExitCode = process.ExitCode;
        }
    }

    public static class SystemUtl
    {
        public static string GetBuildVersion()
        {
            var tagStr = DataArrayUtl.FindTagStr(DataArrayUtl.SystemConfig("ugc"), "version");
            return tagStr.Substring(0, 7).Equals("Build: ", StringComparison.Ordinal) ? tagStr.Substring(7) : tagStr;
        }

        public static string GetAppVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }

    public enum SaveStatus
    {
        kNoData,
        kUnsavedNoFilename,
        kUnsaved,
        kSaved,
    }

    public static class PathUtl
    {
        public static string GetDirectoryName(string strPath)
        {
            string directoryName;
            try
            {
                directoryName = Path.GetDirectoryName(strPath);
                if (directoryName != null && directoryName.Length > 250)
                    throw new PathTooLongException();
            }
            catch (PathTooLongException)
            {
                try
                {
                    directoryName = Path.GetDirectoryName(strPath.Substring(0, 250));
                }
                catch (PathTooLongException)
                {
                    directoryName = Path.GetDirectoryName(strPath.Substring(0, 247));
                }
            }
            return directoryName;
        }

        public static string ConvertPathToRelative(string strAbsPath, string strRootPath)
        {
            if (!Path.IsPathRooted(strAbsPath) || !Path.IsPathRooted(strRootPath))
                return strAbsPath;
            var uri1 = new Uri(strAbsPath);
            var uri2 = new Uri(strRootPath);
            var str = strAbsPath;
            try
            {
                str = uri2.MakeRelativeUri(uri1).ToString();
                str = str.Replace("file://", "\\\\");
                str = str.Replace("/", "\\");
                str = str.Replace("%20", " ");
            }
            catch (Exception)
            {
            }
            return str;
        }

        public static string GetFileName(string strFilePath)
        {
            string fileName;
            try
            {
                fileName = Path.GetFileName(strFilePath);
                if (fileName != null && fileName.Length > 250)
                    throw new PathTooLongException();
            }
            catch (PathTooLongException)
            {
                fileName = Path.GetFileName(strFilePath.Substring(0, 250));
            }
            return fileName;
        }

        public static string GetFileNameWithoutExtension(string strFilePath)
        {
            string withoutExtension;
            try
            {
                withoutExtension = Path.GetFileNameWithoutExtension(strFilePath);
                if (withoutExtension != null && withoutExtension.Length > 250)
                    throw new PathTooLongException();
            }
            catch (PathTooLongException)
            {
                withoutExtension = Path.GetFileNameWithoutExtension(strFilePath.Substring(0, 250));
            }
            return withoutExtension;
        }

        public static bool HasExtension(string strPath, string strExt)
        {
            strExt = strExt.Trim();
            if (strExt.Length <= 0)
                return false;
            if (strExt[0] != 46)
                strExt = (string)(object)'.' + (object)strExt;
            return strPath.EndsWith(strExt, StringComparison.CurrentCultureIgnoreCase);
        }

        public static string EnsureExtension(string strFilePath, string strExt)
        {
            var str = strFilePath;
            if (str.Length > 250)
                str = str.Substring(0, 250);
            if (str.EndsWith(strExt, StringComparison.CurrentCultureIgnoreCase))
                return str;
            var length = 250 - strExt.Length;
            if (str.Length > length)
                str = str.Substring(0, length);
            return str + strExt;
        }

        public static bool IsPathClean(string strPath, out string strErr)
        {
            strErr = "";
            strPath = strPath.Trim();
            if (strPath == "")
                return true;
            if (strPath.EndsWith("/", StringComparison.Ordinal) || strPath.EndsWith("\\", StringComparison.Ordinal) ||
                strPath.EndsWith(":", StringComparison.Ordinal))
            {
                strErr = "File names cannot end with '" + strPath[strPath.Length - 1] + "'.";
                return false;
            }
            if (strPath.Length > 250)
            {
                strErr = "File paths cannot be longer than " + 250 + " characters.";
                return false;
            }
            if (strPath.Split(new[]
                {
                    ':'
                }).Length > 2)
            {
                strErr = "A path can't have more than one colon (:).";
                return false;
            }
            var str =
                Path.GetInvalidPathChars()
                    .Where(ch => strPath.Contains(ch.ToString(CultureInfo.InvariantCulture)))
                    .Aggregate("", (current, ch) => current + ch);
            if (str == "")
                return true;
            strErr = "Illegal Characters: " + str;
            return false;
        }

        public static bool ValidateDirectory(ref string strIn, string strRelPath, string extension, out string strErr)
        {
            strErr =
                "This is not a valid file path. Make sure that the path exists, there are no invalid characters in the path, and that Magma has permission to write a file here.";
            strIn = strIn.Trim();
            if (strIn == "")
            {
                strErr = "";
                return true;
            }
            try
            {
                try
                {
                    if (!Path.IsPathRooted(strIn))
                    {
                        if (strRelPath == "")
                        {
                            strErr = "The specified path is either invalid or is not a full path.";
                            return false;
                        }
                        strIn = Path.Combine(strRelPath, strIn);
                    }
                    var directoryName = Path.GetDirectoryName(strIn);
                    if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
                    {
                        strErr = "The directory \"" + directoryName + "\"does not exist.";
                        return false;
                    }
                    if (strIn.EndsWith("/", StringComparison.Ordinal) || strIn.EndsWith("\\", StringComparison.Ordinal) ||
                        strIn.EndsWith(":", StringComparison.Ordinal))
                    {
                        strErr = "File names cannot end with '" + strIn[strIn.Length - 1] + "'.";
                        return false;
                    }
                    if (strIn.Length > 250)
                        throw new PathTooLongException();
                }
                catch (ArgumentException ex)
                {
                    var str = "";
                    foreach (var ch in Path.GetInvalidPathChars())
                    {
                        if (strIn.Contains(ch.ToString(CultureInfo.InvariantCulture)))
                            str = str + ch;
                    }
                    strErr = str == "" ? ex.Message : "Illegal Characters: " + str;
                    return false;
                }
                catch (PathTooLongException)
                {
                    strErr = "File paths cannot be longer than " + 250 + " characters.";
                    return false;
                }
                if (Directory.Exists(strIn))
                {
                    strErr = "This is an existing directory, and thus cannot be used as a filename.";
                    return false;
                }
                new FileIOPermission(PermissionState.None)
                {
                    AllFiles = FileIOPermissionAccess.PathDiscovery
                }.Assert();
                strIn = Path.GetFullPath(strIn);
                new FileIOPermission(FileIOPermissionAccess.AllAccess, strIn).Demand();
            }
            catch (NotSupportedException ex)
            {
                var str = strIn;
                var chArray = new[]
                    {
                        ':'
                    };
                strErr = str.Split(chArray).Length <= 2 ? ex.Message : "A path can't have more than one colon (:).";
                return false;
            }
            catch
            {
                return false;
            }
            strErr = "";
            return true;
        }
    }

    public static class NetUtl
    {
        private static readonly MsgEntry[] msgLookup =
        {
            new MsgEntry(MsgType.kFail, "F"),
            new MsgEntry(MsgType.kInfo, "I"),
            new MsgEntry(MsgType.kSuccess, "S")
        };
        private static readonly MsgContentsEntry[] msgContentsLookup =
        {
            new MsgContentsEntry(MsgContentsType.kBusy, "BUSY"),
            new MsgContentsEntry(MsgContentsType.kConnected, "CONNECTED"),
            new MsgContentsEntry(MsgContentsType.kConnecting, "CONNECTING"),
            new MsgContentsEntry(MsgContentsType.kConnTimedOut, "CONNTIMEDOUT"),
            new MsgContentsEntry(MsgContentsType.kDropped, "DROPPED"),
            new MsgContentsEntry(MsgContentsType.kFileNotFound, "FILENOTFOUND"),
            new MsgContentsEntry(MsgContentsType.kFound, "FOUND"),
            new MsgContentsEntry(MsgContentsType.kInit, "INIT"),
            new MsgContentsEntry(MsgContentsType.kLoad, "LOAD"),
            new MsgContentsEntry(MsgContentsType.kLockFail, "LOCKFAIL"),
            new MsgContentsEntry(MsgContentsType.kNet, "NET"),
            new MsgContentsEntry(MsgContentsType.kNetInit, "NETINIT"),
            new MsgContentsEntry(MsgContentsType.kPoll, "POLL"),
            new MsgContentsEntry(MsgContentsType.kSearch, "SEARCH"),
            new MsgContentsEntry(MsgContentsType.kTimedOut, "TIMEDOUT"),
            new MsgContentsEntry(MsgContentsType.kUnhandled, "UNHANDLED"),
            new MsgContentsEntry(MsgContentsType.kXLiveAuth, "XLIVEAUTH"),
            new MsgContentsEntry(MsgContentsType.kXLiveErr, "XLIVE"),
            new MsgContentsEntry(MsgContentsType.kXLiveInUse, "XLIVEINUSE"),
            new MsgContentsEntry(MsgContentsType.kXfer, "XFER"),
            new MsgContentsEntry(MsgContentsType.kXferDenied, "XFERDENIED"),
            new MsgContentsEntry(MsgContentsType.kXferred, "XFERRED")
        };

        static NetUtl()
        {
        }

        public static void ThrowMsg(Msg msg)
        {
            throw new MagmaException("Msg: " + msg.Type + ", " + msg.ContentsType + ", " + msg.StrInfo);
        }

        public static Msg GetMsgFromString(string strSingleLine)
        {
            if (string.IsNullOrEmpty(strSingleLine))
                return null;
            var num1 = strSingleLine.IndexOf("[@[", StringComparison.Ordinal);
            if (num1 == -1)
                return null;
            var startIndex1 = num1 + "[@[".Length;
            var num2 = strSingleLine.IndexOf("]@]", startIndex1, StringComparison.Ordinal);
            if (num2 == -1)
                return null;
            var num3 = strSingleLine.IndexOf(":", startIndex1, StringComparison.Ordinal);
            if (num3 == -1)
                return null;
            var str1 = strSingleLine.Substring(startIndex1, num3 - startIndex1);
            var msgType = (from msgEntry in msgLookup where msgEntry.mStrToken.Equals(str1, StringComparison.CurrentCultureIgnoreCase) select msgEntry.mMsgType).FirstOrDefault();
            if (msgType == MsgType.kUnknown)
                return null;
            var startIndex2 = num3 + ":".Length;
            var num4 = num2;
            var str2 = strSingleLine.Substring(startIndex2, num4 - startIndex2);
            var strInfo = "";
            var length = str2.IndexOf(":", StringComparison.Ordinal);
            if (length != -1)
            {
                var startIndex3 = length + ":".Length;
                strInfo = str2.Substring(startIndex3);
                str2 = str2.Substring(0, length);
            }
            var msgContentsType = (from msgContentsEntry in msgContentsLookup where msgContentsEntry.mStrToken.Equals(str2, StringComparison.CurrentCultureIgnoreCase) select msgContentsEntry.mMsgContentsType).FirstOrDefault();
            return new Msg(msgType, msgContentsType, strInfo);
        }

        public enum MsgType
        {
            kUnknown,
            kFail,
            kInfo,
            kSuccess,
        }

        private sealed class MsgEntry
        {
            public readonly MsgType mMsgType;
            public readonly string mStrToken;

            public MsgEntry(MsgType msgType, string strToken)
            {
                mMsgType = msgType;
                mStrToken = strToken;
            }
        }

        public enum MsgContentsType
        {
            kUnknown,
            kBusy,
            kConnected,
            kConnecting,
            kConnTimedOut,
            kDropped,
            kFileNotFound,
            kFound,
            kInit,
            kLoad,
            kLockFail,
            kNet,
            kNetInit,
            kPoll,
            kSearch,
            kTimedOut,
            kUnhandled,
            kXLiveAuth,
            kXLiveErr,
            kXLiveInUse,
            kXfer,
            kXferDenied,
            kXferred,
        }

        private sealed class MsgContentsEntry
        {
            public readonly MsgContentsType mMsgContentsType;
            public readonly string mStrToken;

            public MsgContentsEntry(MsgContentsType msgContentsType, string strToken)
            {
                mMsgContentsType = msgContentsType;
                mStrToken = strToken;
            }
        }

        public class Msg
        {
            private readonly MsgType mMsgType;
            private readonly MsgContentsType mMsgContentsType;
            private readonly string mStrInfo;

            public MsgType Type
            {
                get
                {
                    return mMsgType;
                }
            }

            public MsgContentsType ContentsType
            {
                get
                {
                    return mMsgContentsType;
                }
            }

            public string StrInfo
            {
                get
                {
                    return mStrInfo;
                }
            }

            public Msg()
                : this(MsgType.kUnknown, MsgContentsType.kUnknown, "")
            {
            }

            public Msg(MsgType msgType)
                : this(msgType, MsgContentsType.kUnknown, "")
            {
            }

            public Msg(MsgType msgType, MsgContentsType msgContentsType)
                : this(msgType, msgContentsType, "")
            {
            }

            public Msg(MsgType msgType, MsgContentsType msgContentsType, string strInfo)
            {
                mMsgType = msgType;
                mMsgContentsType = msgContentsType;
                mStrInfo = strInfo;
            }
        }
    }

    public class NamedMutex : IDisposable
    {
        private Mutex mMutex;

        public string Name { get; private set; }

        public bool HasMutex { get; private set; }

        public NamedMutex(string strMutexName)
        {
            Name = strMutexName;
            mMutex = new Mutex(false, Name);
            HasMutex = false;
        }

        public void RequestMutex()
        {
            if (HasMutex)
                return;
            try
            {
                if (!mMutex.WaitOne(0, false))
                    return;
                HasMutex = true;
            }
            catch (AbandonedMutexException)
            {
                HasMutex = true;
            }
        }

        public void GetMutex()
        {
            RequestMutex();
            if (!HasMutex)
                throw new MagmaException("Unable to get named mutex " + Name + ".");
        }

        public void ReleaseMutex()
        {
            if (!HasMutex)
                return;
            mMutex.ReleaseMutex();
            HasMutex = false;
        }

        public virtual void Dispose()
        {
            if (mMutex == null)
                return;
            ReleaseMutex();
            mMutex = null;
            Name = null;
        }
    }

    public enum MagmaTransferState
    {
        kMTSIdle,
        kMTSSearching,
        kMTSTransferring,
        kMTSCheckingForUpdate,
    }

    public class MagmaFileLock : IDisposable
    {
        private FileLockStatus mStatus;
        private readonly string mName;
        private Mutex mMutex;
        private bool mIsDisposed;

        public MagmaFileLock(string path)
        {
            mStatus = FileLockStatus.kMFL_Init;
            mMutex = null;
            mName = GetLockNameFromPath(path);
            mIsDisposed = false;
            mMutex = new Mutex(false, mName);
            if (mMutex == null)
            {
                mStatus = FileLockStatus.kMFL_MutexCreateFailed;
            }
            else
            {
                mStatus = FileLockStatus.kMFL_MutexCreated;
                Acquire();
            }
        }

        ~MagmaFileLock()
        {
            Dispose(false);
        }

        public static string GetLockNameFromPath(string path)
        {
            var strOut = new StringBuilder(2048);
            Wrapper.GetLockNameFromPathStr(path, strOut, strOut.Capacity);
            return strOut.ToString();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!mIsDisposed && disposing)
                Close();
            mIsDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Close()
        {
            if (mMutex != null)
            {
                Release();
                mMutex.Dispose();
                mMutex = null;
            }
            mStatus = FileLockStatus.kMFL_Closed;
        }

        public FileLockStatus GetStatus()
        {
            return mStatus;
        }

        public string GetName()
        {
            return mName;
        }

        private void Acquire()
        {
            if (mStatus != FileLockStatus.kMFL_MutexCreated)
            {
                if (mStatus != FileLockStatus.kMFL_LockAbandoned)
                {
                    if (mStatus != FileLockStatus.kMFL_LockTimeout)
                    {
                        if (mStatus != FileLockStatus.kMFL_LockReleased)
                        {
                            mStatus = FileLockStatus.kMFL_UsageFailure;
                            return;
                        }
                    }
                }
            }
            try
            {
                mStatus = mMutex.WaitOne(0, false) ? FileLockStatus.kMFL_LockAcquired : FileLockStatus.kMFL_LockTimeout;
            }
            catch (AbandonedMutexException)
            {
                mStatus = mMutex.WaitOne(0, false) ? FileLockStatus.kMFL_LockAcquired : FileLockStatus.kMFL_LockTimeout;
            }
        }

        private void Release()
        {
            if (mStatus != FileLockStatus.kMFL_LockAcquired)
                return;
            mMutex.ReleaseMutex();
            mStatus = FileLockStatus.kMFL_LockReleased;
        }

        public enum FileLockStatus
        {
            kMFL_Init,
            kMFL_MutexCreated,
            kMFL_MutexCreateFailed,
            kMFL_LockAcquired,
            kMFL_LockAbandoned,
            kMFL_LockTimeout,
            kMFL_LockFailed,
            kMFL_LockReleased,
            kMFL_UsageFailure,
            kMFL_Closed,
        }
    }

    public class MagmaException : ApplicationException
    {
        public MagmaException()
        {
        }

        public MagmaException(string message)
            : base(message)
        {
        }

        public MagmaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected MagmaException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    public static class LocaleUtl
    {
        public static string Localize(string strTag)
        {
            var strOut = new StringBuilder(2048);
            Wrapper.Localize(strTag, strOut, strOut.Capacity);
            return strOut.ToString();
        }

        public static string[] Localize(string[] strTags)
        {
            var strArray = new string[strTags.Length];
            for (var index = 0; index < strTags.Length; ++index)
                strArray[index] = Localize(strTags[index]);
            return strArray;
        }

        public static string[] Localize(int[] intNumbers, string prefix)
        {
            var strArray = new string[intNumbers.Length];
            for (var index = 0; index < intNumbers.Length; ++index)
                strArray[index] = Localize(prefix + Convert.ToString(intNumbers[index]));
            return strArray;
        }
    }

    public static class Globals
    {
        public const int kStringBuilderDefaultSize = 2048;
        public const int kMaxPathLength = 250;
        public const int kMaxDirectoryLength = 247;
    }

    public enum FileStatus
    {
        kSuccess,
        kErrorUnknown,
        kErrorBadDataArrayPtr,
        kErrorBadOutPtr,
        kErrorFileNotFound,
        kErrorDuringParse,
    }

    public enum DataStatus
    {
        kSuccess,
        kErrorUnknown,
        kErrorBadDataArrayPtr,
        kErrorBadOutPtr,
        kErrorTagNotFound,
        kErrorTagHasNoValue,
        kErrorIndexOutOfRange,
        kErrorWrongType,
    }

    public static class DataArrayUtl
    {

        public static IntPtr SystemConfig(string strTag)
        {
            IntPtr dataArray;
            var systemConfig = Wrapper.GetSystemConfig(strTag, out dataArray);
            if (systemConfig == DataStatus.kSuccess)
                return dataArray;
            throw new MagmaException("GetSystemConfig(" + strTag + ") returned " + systemConfig + ".");
        }

        public static IntPtr FindTagArray(IntPtr data, string strTag)
        {
            IntPtr ppDataOut;
            var tagArray = Wrapper.FindTagArray(data, strTag, out ppDataOut);
            if (tagArray == DataStatus.kSuccess)
                return ppDataOut;
            throw new MagmaException("FindTagArray(" + strTag + ") returned " + tagArray + ".");
        }

        public static string FindTagStr(IntPtr data, string strTag)
        {
            var strOut = new StringBuilder(2048);
            var tagStr = Wrapper.FindTagStr(data, strTag, strOut, strOut.Capacity);
            if (tagStr == DataStatus.kSuccess)
                return strOut.ToString();
            throw new MagmaException("FindTagStr(" + strTag + ") returned " + tagStr + ".");
        }

        public static string FindTagSym(IntPtr data, string strTag)
        {
            var strOut = new StringBuilder(2048);
            var tagSym = Wrapper.FindTagSym(data, strTag, strOut, strOut.Capacity);
            if (tagSym == DataStatus.kSuccess)
                return strOut.ToString();
            throw new MagmaException("FindTagSym(" + strTag + ") returned " + tagSym + ".");
        }

        public static int FindTagInt(IntPtr data, string strTag)
        {
            int n;
            var tagInt = Wrapper.FindTagInt(data, strTag, out n);
            if (tagInt == DataStatus.kSuccess)
                return n;
            throw new MagmaException("FindTagInt(" + strTag + ") returned " + tagInt + ".");
        }

        public static float FindTagFloat(IntPtr data, string strTag)
        {
            float n;
            var tagFloat = Wrapper.FindTagFloat(data, strTag, out n);
            if (tagFloat == DataStatus.kSuccess)
                return n;
            throw new MagmaException("FindTagFloat(" + strTag + ") returned " + tagFloat + ".");
        }

        public static uint GetSize(IntPtr data)
        {
            uint pSize;
            var size = Wrapper.GetSize(data, out pSize);
            if (size != DataStatus.kSuccess)
                throw new MagmaException("GetSize() returned " + size + ".");
            return pSize;
        }

        public static IntPtr GetArray(IntPtr data, uint i)
        {
            IntPtr dataOut;
            var array = Wrapper.GetArray(data, i, out dataOut);
            if (array == DataStatus.kSuccess)
                return dataOut;
            throw new MagmaException("GetArray(" + i.ToString(CultureInfo.InvariantCulture) + ") returned " + array + ".");
        }

        public static float GetFloat(IntPtr data, uint i)
        {
            float n;
            var @float = Wrapper.GetFloat(data, i, out n);
            if (@float == DataStatus.kSuccess)
                return n;
            throw new MagmaException("GetFloat(" + i.ToString(CultureInfo.InvariantCulture) + ") returned " + @float + ".");
        }

        public static string GetSym(IntPtr data, uint i)
        {
            var strOut = new StringBuilder(2048);
            var sym = Wrapper.GetSym(data, i, strOut, strOut.Capacity);
            if (sym == DataStatus.kSuccess)
                return strOut.ToString();
            throw new MagmaException("GetSym(" + i.ToString(CultureInfo.InvariantCulture) + ") returned " + sym + ".");
        }

        public static void SetTagStr(IntPtr data, string strTag, string strValue)
        {
            var dataStatus = Wrapper.SetTagStr(data, strTag, strValue);
            if (dataStatus == DataStatus.kSuccess)
                return;
            throw new MagmaException("SetTagStr(" + strTag + ", " + strValue + ") returned " + dataStatus + ".");
        }

        public static void SetTagSym(IntPtr data, string strTag, string strValue)
        {
            var dataStatus = Wrapper.SetTagSym(data, strTag, strValue);
            if (dataStatus == DataStatus.kSuccess)
                return;
            throw new MagmaException("SetTagSym(" + strTag + ", " + strValue + ") returned " + dataStatus + ".");
        }

        public static void ForceTagSym(IntPtr data, string strTag, string strValue)
        {
            var dataStatus = Wrapper.ForceTagSym(data, strTag, strValue);
            if (dataStatus == DataStatus.kSuccess)
                return;
            throw new MagmaException("ForceTagSym(" + strTag + ", " + strValue + ") returned " + dataStatus + ".");
        }

        public static void SetTagInt(IntPtr data, string strTag, int nValue)
        {
            var dataStatus = Wrapper.SetTagInt(data, strTag, nValue);
            if (dataStatus == DataStatus.kSuccess)
                return;
            throw new MagmaException("SetTagInt(" + strTag + ", " + nValue.ToString(CultureInfo.InvariantCulture) + ") returned " + dataStatus + ".");
        }

        public static void SetTagFloat(IntPtr data, string strTag, float nValue)
        {
            var dataStatus = Wrapper.SetTagFloat(data, strTag, nValue);
            if (dataStatus == DataStatus.kSuccess)
                return;
            throw new MagmaException("SetTagFloat(" + strTag + ", " + nValue.ToString(CultureInfo.InvariantCulture) + ") returned " + dataStatus + ".");
        }

        public static IntPtr InsertArrayAtEnd(IntPtr data)
        {
            IntPtr dataOut;
            var dataStatus = Wrapper.InsertArrayAtEnd(data, out dataOut);
            if (dataStatus != DataStatus.kSuccess)
                throw new MagmaException("InsertArrayAtEnd() returned " + dataStatus + ".");
            return dataOut;
        }

        public static IntPtr InsertTagArrayAtEnd(IntPtr data, string strTag)
        {
            IntPtr dataOut;
            var dataStatus = Wrapper.InsertTagArrayAtEnd(data, strTag, out dataOut);
            if (dataStatus != DataStatus.kSuccess)
                throw new MagmaException("InsertTagArrayAtEnd() returned " + dataStatus + ".");
            return dataOut;
        }

        public static void RemoveTagArray(IntPtr data, string strTag)
        {
            var dataStatus = Wrapper.RemoveTagArray(data, strTag);
            if (dataStatus != DataStatus.kSuccess)
                throw new MagmaException("RemoveTagArray(" + strTag + dataStatus + ".");
        }

        public static void InsertTagStrAtEnd(IntPtr data, string strTag, string strValue)
        {
            var dataStatus = Wrapper.InsertTagStrAtEnd(data, strTag, strValue);
            if (dataStatus == DataStatus.kSuccess)
                return;
            throw new MagmaException("InsertTagStrAtEnd(" + strTag + ", " + strValue + ") returned " + dataStatus + ".");
        }

        public static void InsertTagSymAtEnd(IntPtr data, string strTag, string strValue)
        {
            var dataStatus = Wrapper.InsertTagSymAtEnd(data, strTag, strValue);
            if (dataStatus == DataStatus.kSuccess)
                return;
            throw new MagmaException("InsertTagSymAtEnd(" + strTag + ", " + strValue + ") returned " + dataStatus + ".");
        }

        public static void InsertTagIntAtEnd(IntPtr data, string strTag, int nValue)
        {
            var dataStatus = Wrapper.InsertTagIntAtEnd(data, strTag, nValue);
            if (dataStatus == DataStatus.kSuccess)
                return;
            throw new MagmaException("InsertTagIntAtEnd(" + strTag + ", " + nValue.ToString(CultureInfo.InvariantCulture) + ") returned " + dataStatus + ".");
        }

        public static void AddTagFloatAtEnd(IntPtr data, string strTag, float nValue)
        {
            var dataStatus = Wrapper.AddTagFloatAtEnd(data, strTag, nValue);
            if (dataStatus == DataStatus.kSuccess)
                return;
            throw new MagmaException("AddTagFloatAtEnd(" + strTag + ", " + nValue.ToString(CultureInfo.InvariantCulture) + ") returned " + dataStatus + ".");
        }

        public static void SetOrInsertTagStrAtStart(IntPtr data, string strTag, string strValue)
        {
            var dataStatus = Wrapper.SetOrInsertTagStrAtStart(data, strTag, strValue);
            if (dataStatus == DataStatus.kSuccess)
                return;
            throw new MagmaException("SetOrInsertTagStrAtStart(" + strTag + ", " + strValue + ") returned " + dataStatus + ".");
        }

        public static void SetOrInsertTagIntAtStart(IntPtr data, string strTag, int nValue)
        {
            var dataStatus = Wrapper.SetOrInsertTagIntAtStart(data, strTag, nValue);
            if (dataStatus == DataStatus.kSuccess)
                return;
            throw new MagmaException("SetOrInsertTagIntAtStart(" + strTag + ", " + nValue.ToString(CultureInfo.InvariantCulture) + ") returned " + dataStatus + ".");
        }

        public static string[] GetSymbolListHeadings(string strRoot, string strTag)
        {
            var tagArray = FindTagArray(SystemConfig(strRoot), strTag);
            var size = GetSize(tagArray);
            if (size <= 1U)
                return new string[0];
            var strArray = new string[(int)((IntPtr)(size - 1U))];
            var strOut = new StringBuilder(2048);
            for (var index = 1U; index < size; ++index)
            {
                IntPtr dataOut;
                var array = Wrapper.GetArray(tagArray, index, out dataOut);
                switch (array)
                {
                    case DataStatus.kSuccess:
                        var sym1 = Wrapper.GetSym(dataOut, 0U, strOut, strOut.Capacity);
                        if (sym1 != DataStatus.kSuccess)
                            throw new MagmaException("GetSym(0) returned " + sym1 + ".");
                        break;
                    case DataStatus.kErrorWrongType:
                        var sym2 = Wrapper.GetSym(tagArray, index, strOut, strOut.Capacity);
                        if (sym2 == DataStatus.kErrorWrongType)
                            throw new MagmaException("GetArray(" + strRoot + ", " + strTag + ", " + index.ToString(CultureInfo.InvariantCulture) + ") returned " + sym2 + ".");
                        break;
                    default:
                        throw new MagmaException("GetArray(" + strRoot + ", " + strTag + ", " + index.ToString(CultureInfo.InvariantCulture) + ") returned " + array + ".");
                }
                strArray[(int)(index - 1U)] = strOut.ToString();
            }
            return strArray;
        }

        public static int[] GetIntList(string strRoot, string strTag)
        {
            var tagArray = FindTagArray(SystemConfig(strRoot), strTag);
            var size = GetSize(tagArray);
            if (size <= 1U)
                return new int[0];
            var numArray = new int[(int)((IntPtr)(size - 1U))];
            for (var index = 1U; index < size; ++index)
            {
                int n;
                var @int = Wrapper.GetInt(tagArray, index, out n);
                if (@int != DataStatus.kSuccess)
                    throw new MagmaException("GetInt(" + strRoot + ", " + strTag + ", " + index.ToString(CultureInfo.InvariantCulture) + ") returned " + @int + ".");
                numArray[(int)(index - 1U)] = n;
            }
            return numArray;
        }

        public static string[] GetSymbolListContents(string strRoot, string strTag, string strTagSub)
        {
            var tagArray = FindTagArray(FindTagArray(SystemConfig(strRoot), strTag), strTagSub);
            var size = GetSize(tagArray);
            if (size <= 1U)
                return new string[0];
            var strArray = new string[(int)((IntPtr)(size - 1U))];
            var strOut = new StringBuilder(2048);
            for (var index = 1U; index < size; ++index)
            {
                var sym = Wrapper.GetSym(tagArray, index, strOut, strOut.Capacity);
                if (sym != DataStatus.kSuccess)
                    throw new MagmaException("GetSym(" + strRoot + ", " + strTag + ", " + strTagSub + ") returned " + sym + ".");
                strArray[(int)(index - 1U)] = strOut.ToString();
            }
            return strArray;
        }

        public static void ReleaseContents(IntPtr data)
        {
            var dataStatus = Wrapper.ReleaseContents(data);
            if (dataStatus != DataStatus.kSuccess)
                throw new MagmaException("ReleaseContents() returned " + dataStatus + ".");
        }
    }
}


    

