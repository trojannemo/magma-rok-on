using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MagmaRokOn.x360;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Enc;
using Un4seen.Bass.AddOn.Fx;
using Un4seen.Bass.AddOn.Mix;
using NautilusFREE;

namespace MagmaRokOn
{
    class MoggSplitter
    {
        private NemoTools Tools;
        private DTAParser Parser;
        private List<int> Splits;
        private int SourceStream;
        public List<string> ErrorLog;
        private nTools nautilus;

        private void Initialize()
        {
            Splits = new List<int>();
            ErrorLog = new List<string>();
            nautilus = new nTools();
        }

        public bool ExtractDecryptMogg(string CON_file)
        {
            return ExtractDecryptMogg(CON_file, new NemoTools(), new DTAParser());
        }

        public bool ExtractDecryptMogg(string CON_file, NemoTools tools, DTAParser parser)
        {
            Initialize();
            Tools = tools;
            Parser = parser;
            Tools.ReleaseStreamHandle();
            var temp_dta = Path.GetTempPath() + "temp.dta";
            var temp_mogg = Path.GetTempPath() + "temp.mogg";
            Tools.DeleteFile(temp_dta);
            Tools.DeleteFile(temp_mogg);
            if (!Parser.ExtractDTA(CON_file, temp_dta))
            {
                ErrorLog.Add("Couldn't extract songs.dta file from that CON file");
                Tools.DeleteFile(temp_dta);
                return false;
            }
            if (!Parser.ReadDTA(temp_dta) || !Parser.Songs.Any())
            {
                ErrorLog.Add("Couldn't read that songs.dta file");
                Tools.DeleteFile(temp_dta);
                return false;
            }
            Tools.DeleteFile(temp_dta);
            if (Parser.Songs.Count > 1)
            {
                ErrorLog.Add("This feature does not support packs, only single songs\nUse the dePACK feature in Nautilus' Quick Pack Editor to split this pack into single songs and try again");
                return false;
            }
            var internal_name = Parser.Songs[0].InternalName;
            var xCON = new STFSPackage(CON_file);
            if (!xCON.ParseSuccess)
            {
                ErrorLog.Add("Couldn't parse that CON file");
                xCON.CloseIO();
                return false;
            }
            var xMogg = xCON.GetFile("songs/" + internal_name + "/" + internal_name + ".mogg");
            if (xMogg == null)
            {
                ErrorLog.Add("Couldn't find the mogg file inside that CON file");
                xCON.CloseIO();
                return false;
            }
            if (!xMogg.Extract(temp_mogg))
            {
                ErrorLog.Add("Couldn't extract the mogg file from that CON file");
                xCON.CloseIO();
                return false;
            }
            xCON.CloseIO();
            LoadLibraries();
            var success = nautilus.DecM(File.ReadAllBytes(temp_mogg), false, false, DecryptMode.ToMemory);
            return success;
        }

        private static void UnloadLibraries()
        {
            Bass.BASS_Free();
        }

        private static void LoadLibraries()
        {
            BassEnc.BASS_Encode_GetVersion();
            BassMix.BASS_Mixer_GetVersion();
            BassFx.BASS_FX_GetVersion();
            Bass.BASS_GetVersion();
        }

        public bool DownmixMogg(string CON_file, string output, MoggSplitFormat format, bool doWii = false, double start = 0.0, double length = 0.0, double fadeIn = 0.0, double fadeOut = 0.0, double volume = 0.0)
        {
            if (!ExtractDecryptMogg(CON_file)) return false;
            try
            {
                if (!InitBass()) return false;
                var BassStream = Bass.BASS_StreamCreateFile(Tools.GetOggStreamIntPtr(), 0, Tools.PlayingSongOggData.Length, BASSFlag.BASS_STREAM_DECODE);
                var channel_info = Bass.BASS_ChannelGetInfo(BassStream);
                var BassMixer = BassMix.BASS_Mixer_StreamCreate(doWii ? 22050 : channel_info.freq, 2, BASSFlag.BASS_MIXER_END | BASSFlag.BASS_STREAM_DECODE);
                if (doWii)
                {
                    BassMix.BASS_Mixer_StreamAddChannelEx(BassMixer, BassStream, BASSFlag.BASS_MIXER_MATRIX, 0, Bass.BASS_ChannelSeconds2Bytes(BassMixer, length));
                    var track_vol = (float)Utils.DBToLevel(Convert.ToDouble(volume), 1.0);
                    Bass.BASS_ChannelSetPosition(BassStream, Bass.BASS_ChannelSeconds2Bytes(BassStream, start));
                    BASS_MIXER_NODE[] nodes = 
                    {
                        new BASS_MIXER_NODE(0, 0),
                        new BASS_MIXER_NODE(Bass.BASS_ChannelSeconds2Bytes(BassMixer, fadeIn), track_vol),
                        new BASS_MIXER_NODE(Bass.BASS_ChannelSeconds2Bytes(BassMixer, length - fadeOut), track_vol),
                        new BASS_MIXER_NODE(Bass.BASS_ChannelSeconds2Bytes(BassMixer, length), 0)
                    };
                    BassMix.BASS_Mixer_ChannelSetEnvelope(BassStream, BASSMIXEnvelope.BASS_MIXER_ENV_VOL, nodes, nodes.Count());
                }
                else
                {
                    BassMix.BASS_Mixer_StreamAddChannel(BassMixer, BassStream, BASSFlag.BASS_MIXER_MATRIX);
                }
                var matrix = GetChannelMatrix(Parser.Songs[0], channel_info.chans, "allstems");
                BassMix.BASS_Mixer_ChannelSetMatrix(BassStream, matrix);
                var output_file = output;
                if (string.IsNullOrEmpty(output))
                {
                    output_file = Path.GetDirectoryName(CON_file) + "\\" + Parser.Songs[0].InternalName + (format == MoggSplitFormat.WAV ? ".wav" : ".ogg");
                }
                var quality = "-q" + (doWii ? "3" : "5");
                if (format == MoggSplitFormat.OGG)
                {
                    var cmd = "bin\\oggenc2.exe " + quality + " - -o\"" + output_file + "\"";
                    BassEnc.BASS_Encode_Start(BassMixer, cmd, BASSEncode.BASS_ENCODE_FP_24BIT | BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
                }
                else
                {
                    BassEnc.BASS_Encode_Start(BassMixer, output_file, BASSEncode.BASS_ENCODE_PCM | BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
                }
                while (true)
                {
                    var buffer = new byte[20000];
                    var c = Bass.BASS_ChannelGetData(BassMixer, buffer, buffer.Length);
                    if (c < 0) break;
                }
                UnloadLibraries();
                Tools.ReleaseStreamHandle();
                return File.Exists(output_file);
            }
            catch (Exception ex)
            {
                ErrorLog.Add("Error downmixing mogg file:");
                ErrorLog.Add(ex.Message);
                UnloadLibraries();
                Tools.ReleaseStreamHandle();
                return false;
            }
        }

        public bool SplitMogg(string CON_file, string output_folder, string StemsToSplit, MoggSplitFormat format)
        {
            return ExtractDecryptMogg(CON_file) && DoSplitMogg(output_folder, StemsToSplit, format);
        }

        public enum MoggSplitFormat
        {
            OGG, WAV
        }

        private bool InitBass()
        {
            try
            {
                LoadLibraries();
                Bass.BASS_Free(); // safe to call even if not initialized

                bool ok = Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                var err = Bass.BASS_ErrorGetCode();

                ErrorLog.Add($"BASS_Init returned: {ok}, error: {err}");

                if (!ok)
                {
                    ErrorLog.Add("Error initializing BASS.NET");
                    Tools.ReleaseStreamHandle();
                    return false;
                }

                BASS_INFO info = new BASS_INFO();
                bool infoOk = Bass.BASS_GetInfo(info);
                ErrorLog.Add($"BASS_GetInfo returned: {infoOk}, error: {Bass.BASS_ErrorGetCode()}");

                if (!infoOk)
                {
                    ErrorLog.Add("BASS says init succeeded, but GetInfo failed. Likely DLL load/bitness issue.");
                    return false;
                }

                Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_BUFFER, 20000);
                return true;
            }
            catch (BadImageFormatException ex)
            {
                ErrorLog.Add("BadImageFormatException (x86/x64 mismatch).");
                ErrorLog.Add(ex.Message);
                return false;
            }
            catch (DllNotFoundException ex)
            {
                ErrorLog.Add("DllNotFoundException (bass.dll or dependency missing).");
                ErrorLog.Add(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                ErrorLog.Add("Error initializing BASS.NET");
                ErrorLog.Add(ex.ToString());
                return false;
            }
        }

        private bool InitBass1()
        {
            LoadLibraries();
            try
            {
                if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
                {
                    ErrorLog.Add("Error initializing BASS.NET");
                    ErrorLog.Add(Bass.BASS_ErrorGetCode().ToString());
                    ErrorLog.Add("Can't process that mogg file");
                    Tools.ReleaseStreamHandle();
                    return false;
                }
                Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_BUFFER, 20000);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.Add("Error initializing BASS.NET");
                ErrorLog.Add(ex.Message);
                ErrorLog.Add("Can't split the mogg file");
                return false;
            }
        }

        public int[] ArrangeStreamChannels(int totalChannels, bool isOgg)
        {
            var channels = new int[totalChannels];
            if (isOgg)
            {
                switch (totalChannels)
                {
                    case 3:
                        channels[0] = 0;
                        channels[1] = 2;
                        channels[2] = 1;
                        break;
                    case 5:
                        channels[0] = 0;
                        channels[1] = 2;
                        channels[2] = 1;
                        channels[3] = 3;
                        channels[4] = 4;
                        break;
                    case 6:
                        channels[0] = 0;
                        channels[1] = 2;
                        channels[2] = 1;
                        channels[3] = 4;
                        channels[4] = 5;
                        channels[5] = 3;
                        break;
                    case 7:
                        channels[0] = 0;
                        channels[1] = 2;
                        channels[2] = 1;
                        channels[3] = 4;
                        channels[4] = 5;
                        channels[5] = 6;
                        channels[6] = 3;
                        break;
                    case 8:
                        channels[0] = 0;
                        channels[1] = 2;
                        channels[2] = 1;
                        channels[3] = 4;
                        channels[4] = 5;
                        channels[5] = 6;
                        channels[6] = 7;
                        channels[7] = 3;
                        break;
                    default:
                        goto DoAllChannels;
                }
                return channels;
            }
        DoAllChannels:
            for (var i = 0; i < totalChannels; i++)
            {
                channels[i] = i;
            }
            return channels;
        }

        private bool DoSplitMogg(string folder, string StemsToSplit, MoggSplitFormat format)
        {
            var ext = "ogg";
            if (format == MoggSplitFormat.WAV)
            {
                ext = "wav";
            }
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var drums = folder + "drums." + ext;
            var drums1 = folder + "drums_1." + ext;
            var drums2 = folder + "drums_2." + ext;
            var drums3 = folder + "drums_3." + ext;
            var bass = folder + "bass." + ext;
            var rhythm = folder + "rhythm." + ext;
            var guitar = folder + "guitar." + ext;
            var keys = folder + "keys." + ext;
            var vocals = folder + "vocals." + ext;
            var backing = folder + "backing." + ext;
            var song = folder + "song." + ext;
            var crowd = folder + "crowd." + ext;
            var tracks = new List<string> { drums, drums1, drums2, drums3, bass, guitar, keys, vocals, backing, crowd };
            foreach (var track in tracks)
            {
                Tools.DeleteFile(track);
            }
            try
            {
                if (!InitBass()) return false;
                SourceStream = Bass.BASS_StreamCreateFile(nautilus.GetOggStreamIntPtr(), 0, nautilus.PlayingSongOggData.Length, BASSFlag.BASS_STREAM_DECODE);
                var info = Bass.BASS_ChannelGetInfo(SourceStream);
                var ArrangedChannels = ArrangeStreamChannels(info.chans, true);
                var isSlave = false;
                if (Parser.Songs[0].ChannelsDrums > 0 && (StemsToSplit.Contains("allstems") || StemsToSplit.Contains("drums")))
                {
                    switch (Parser.Songs[0].ChannelsDrums)
                    {
                        case 2:
                            PrepareChannelsToSplit(0, ArrangedChannels, 2, GetStemVolume(0), drums, format, false);
                            break;
                        case 3:
                            PrepareChannelsToSplit(0, ArrangedChannels, 1, GetStemVolume(0), drums1, format, false);
                            PrepareChannelsToSplit(1, ArrangedChannels, 2, GetStemVolume(1), drums2, format);
                            break;
                        case 4:
                            PrepareChannelsToSplit(0, ArrangedChannels, 1, GetStemVolume(0), drums1, format, false);
                            PrepareChannelsToSplit(1, ArrangedChannels, 1, GetStemVolume(1), drums2, format);
                            PrepareChannelsToSplit(2, ArrangedChannels, 2, GetStemVolume(2), drums3, format);
                            break;
                        case 5:
                            PrepareChannelsToSplit(0, ArrangedChannels, 1, GetStemVolume(0), drums1, format, false);
                            PrepareChannelsToSplit(1, ArrangedChannels, 2, GetStemVolume(1), drums2, format);
                            PrepareChannelsToSplit(3, ArrangedChannels, 2, GetStemVolume(3), drums3, format);
                            break;
                        case 6:
                            PrepareChannelsToSplit(0, ArrangedChannels, 2, GetStemVolume(0), drums1, format, false);
                            PrepareChannelsToSplit(2, ArrangedChannels, 2, GetStemVolume(2), drums2, format);
                            PrepareChannelsToSplit(4, ArrangedChannels, 2, GetStemVolume(4), drums3, format);
                            break;
                    }
                    isSlave = true;
                }
                var channel = Parser.Songs[0].ChannelsDrums;
                if (Parser.Songs[0].ChannelsBass > 0 && (StemsToSplit.Contains("allstems") || StemsToSplit.Contains("bass") || StemsToSplit.Contains("rhythm")))
                {
                    PrepareChannelsToSplit(channel, ArrangedChannels, Parser.Songs[0].ChannelsBass, GetStemVolume(channel), StemsToSplit.Contains("rhythm") ? rhythm : bass, format, isSlave);
                    isSlave = true;
                }
                channel += Parser.Songs[0].ChannelsBass;
                if (Parser.Songs[0].ChannelsGuitar > 0 && (StemsToSplit.Contains("allstems") || StemsToSplit.Contains("guitar")))
                {
                    PrepareChannelsToSplit(channel, ArrangedChannels, Parser.Songs[0].ChannelsGuitar, GetStemVolume(channel), guitar, format, isSlave);
                    isSlave = true;
                }
                channel += Parser.Songs[0].ChannelsGuitar;
                if (Parser.Songs[0].ChannelsVocals > 0 && (StemsToSplit.Contains("allstems") || StemsToSplit.Contains("vocals")))
                {
                    PrepareChannelsToSplit(channel, ArrangedChannels, Parser.Songs[0].ChannelsVocals, GetStemVolume(channel), vocals, format, isSlave);
                    isSlave = true;
                }
                channel += Parser.Songs[0].ChannelsVocals;
                if (Parser.Songs[0].ChannelsKeys > 0 && (StemsToSplit.Contains("allstems") || StemsToSplit.Contains("keys")))
                {
                    PrepareChannelsToSplit(channel, ArrangedChannels, Parser.Songs[0].ChannelsKeys, GetStemVolume(channel), keys, format, isSlave);
                    isSlave = true;
                }
                channel += Parser.Songs[0].ChannelsKeys;
                if (Parser.Songs[0].ChannelsBacking() > 0 && (StemsToSplit.Contains("allstems") || StemsToSplit.Contains("backing") || StemsToSplit.Contains("song")))
                {
                    PrepareChannelsToSplit(channel, ArrangedChannels, Parser.Songs[0].ChannelsBacking(), GetStemVolume(channel), StemsToSplit.Contains("song") ? song : backing, format, isSlave);
                    isSlave = true;
                }
                channel += Parser.Songs[0].ChannelsBacking();
                if (Parser.Songs[0].ChannelsCrowd > 0 && (StemsToSplit.Contains("allstems") || StemsToSplit.Contains("crowd")))
                {
                    PrepareChannelsToSplit(channel, ArrangedChannels, Parser.Songs[0].ChannelsCrowd, GetStemVolume(channel), crowd, format, isSlave);
                }
                while (true)
                {
                    var buffer = new byte[20000];
                    var c = Bass.BASS_ChannelGetData(Splits[0], buffer, buffer.Length);
                    if (c < 0) break;
                    for (var i = 1; i < Splits.Count; i++)
                    {
                        while (Bass.BASS_ChannelGetData(Splits[i], buffer, buffer.Length) > 0) { }
                    }
                }
                foreach (var split in Splits)
                {
                    Bass.BASS_StreamFree(split);
                }
                UnloadLibraries();
                Tools.ReleaseStreamHandle();
            }
            catch (Exception ex)
            {
                ErrorLog.Add("Error splitting mogg file:");
                ErrorLog.Add(ex.Message);
                foreach (var split in Splits)
                {
                    Bass.BASS_StreamFree(split);
                }
                UnloadLibraries();
                Tools.ReleaseStreamHandle();
                return false;
            }
            return true;
        }

        private void PrepareChannelsToSplit(int index, IList<int> ArrangedChannels, int channels, float vol, string file, MoggSplitFormat format, bool slave = true)
        {
            var channel_map = new int[channels == 2 ? 3 : 2];
            channel_map[0] = ArrangedChannels[index];
            channel_map[1] = channels == 2 ? ArrangedChannels[index + 1] : -1;
            if (channels == 2)
            {
                channel_map[2] = -1;
            }
            var flags = slave ? BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SPLIT_SLAVE : BASSFlag.BASS_STREAM_DECODE;
            var out_stream = BassMix.BASS_Split_StreamCreate(SourceStream, flags, channel_map);
            var volumeFX = Bass.BASS_ChannelSetFX(out_stream, BASSFXType.BASS_FX_BFX_VOLUME, 0);
            var volume = new BASS_BFX_VOLUME { lChannel = 0, fVolume = vol };
            Bass.BASS_FXSetParameters(volumeFX, volume);
            Splits.Add(out_stream);
            if (format == MoggSplitFormat.OGG)
            {
                var cmd = "bin\\oggenc2.exe -q5 - -o\"" + file + "\"";
                BassEnc.BASS_Encode_Start(out_stream, cmd, BASSEncode.BASS_ENCODE_FP_24BIT | BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
            }
            else
            {
                BassEnc.BASS_Encode_Start(out_stream, file, BASSEncode.BASS_ENCODE_PCM | BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
            }
        }

        private float GetStemVolume(int curr_channel)
        {
            const double max_dB = 1.0;
            var volumes = Parser.Songs[0].AttenuationValues.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            float vol;
            try
            {
                vol = (float)Utils.DBToLevel(Convert.ToDouble(volumes[curr_channel]), max_dB);
            }
            catch (Exception)
            {
                vol = (float)1.0;
            }
            return vol;
        }

        public float[,] GetChannelMatrix(SongData song, int chans, string stems)
        {
            //initialize matrix
            //matrix must be float[output_channels, intpu_channels]
            var matrix = new float[2, chans];
            var ArrangedChannels = ArrangeStreamChannels(chans, true);
            if (song.ChannelsDrums > 0 && (stems.Contains("drums") || stems.Contains("allstems")))
            {
                //for drums it's a bit tricky because of the possible combinations
                switch (song.ChannelsDrums)
                {
                    case 2:
                        //stereo kit
                        matrix = DoMatrixPanning(song, matrix, ArrangedChannels, 2, 0);
                        break;
                    case 3:
                        //mono kick
                        matrix = DoMatrixPanning(song, matrix, ArrangedChannels, 1, 0);
                        //stereo kit
                        matrix = DoMatrixPanning(song, matrix, ArrangedChannels, 2, 1);
                        break;
                    case 4:
                        //mono kick
                        matrix = DoMatrixPanning(song, matrix, ArrangedChannels, 1, 0);
                        //mono snare
                        matrix = DoMatrixPanning(song, matrix, ArrangedChannels, 1, 1);
                        //stereo kit
                        matrix = DoMatrixPanning(song, matrix, ArrangedChannels, 2, 2);
                        break;
                    case 5:
                        //mono kick
                        matrix = DoMatrixPanning(song, matrix, ArrangedChannels, 1, 0);
                        //stereo snare
                        matrix = DoMatrixPanning(song, matrix, ArrangedChannels, 2, 1);
                        //stereo kit
                        matrix = DoMatrixPanning(song, matrix, ArrangedChannels, 2, 3);
                        break;
                    case 6:
                        //stereo kick
                        matrix = DoMatrixPanning(song, matrix, ArrangedChannels, 2, 0);
                        //stereo snare
                        matrix = DoMatrixPanning(song, matrix, ArrangedChannels, 2, 2);
                        //stereo kit
                        matrix = DoMatrixPanning(song, matrix, ArrangedChannels, 2, 4);
                        break;
                }
            }
            var channel = song.ChannelsDrums;
            if (song.ChannelsBass > 0 && (stems.Contains("bass") || stems.Contains("allstems")))
            {
                matrix = DoMatrixPanning(song, matrix, ArrangedChannels, song.ChannelsBass, channel);
            }
            channel = channel + song.ChannelsBass;
            if (song.ChannelsGuitar > 0 && (stems.Contains("guitar") || stems.Contains("allstems")))
            {
                matrix = DoMatrixPanning(song, matrix, ArrangedChannels, song.ChannelsGuitar, channel);
            }
            channel = channel + song.ChannelsGuitar;
            if (song.ChannelsVocals > 0 && (stems.Contains("vocals") || stems.Contains("allstems")))
            {
                matrix = DoMatrixPanning(song, matrix, ArrangedChannels, song.ChannelsVocals, channel);
            }
            channel = channel + song.ChannelsVocals;
            if (song.ChannelsKeys > 0 && (stems.Contains("keys") || stems.Contains("allstems")))
            {
                matrix = DoMatrixPanning(song, matrix, ArrangedChannels, song.ChannelsKeys, channel);
            }
            channel = channel + song.ChannelsKeys;
            if (song.ChannelsBacking() > 0 && (stems.Contains("backing") || stems.Contains("allstems")))
            {
                matrix = DoMatrixPanning(song, matrix, ArrangedChannels, song.ChannelsBacking(), channel);
            }
            channel = channel + song.ChannelsBacking();
            if (song.ChannelsCrowd == 0 || (!stems.Contains("crowd") && !stems.Contains("allstems"))) return matrix;
            return DoMatrixPanning(song, matrix, ArrangedChannels, song.ChannelsCrowd, channel);
        }

        private static float[,] DoMatrixPanning(SongData song, float[,] in_matrix, IList<int> ArrangedChannels, int inst_channels, int curr_channel)
        {
            //by default matrix values will be 0 = 0 volume
            //if nothing is assigned here, it stays at 0 so that channel won't be played
            //otherwise we assign a volume level based on the dta volumes

            //initialize output matrix based on input matrix, just in case something fails there's something going out
            var matrix = in_matrix;

            //split attenuation and panning info from DTA file for index access
            var volumes = song.AttenuationValues.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var pans = song.PanningValues.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            //BASS.NET lets us specify maximum volume when converting dB to Level
            //in case we want to change this letter, it's only one value to change
            const double max_dB = 1.0;

            //technically we could do each channel, but Magma only allows us to specify volume per track, 
            //so both channels should have same volume, let's same a tiny bit of processing power
            float vol;
            try
            {
                vol = (float)Utils.DBToLevel(Convert.ToDouble(volumes[ArrangedChannels[curr_channel]]), max_dB);
            }
            catch (Exception)
            {
                vol = (float)1.0;
            }

            //assign volume level to channels in the matrix
            if (inst_channels == 2) //is it a stereo track
            {
                try
                {
                    //assign current channel (left) to left channel
                    matrix[0, ArrangedChannels[curr_channel]] = vol;
                }
                catch (Exception)
                { }
                try
                {
                    //assign next channel (right) to the right channel
                    matrix[1, ArrangedChannels[curr_channel + 1]] = vol;
                }
                catch (Exception)
                { }
            }
            else
            {
                //it's a mono track, let's assign based on the panning vaue
                double pan;
                try
                {
                    pan = Convert.ToDouble(pans[ArrangedChannels[curr_channel]]);
                }
                catch (Exception)
                {
                    pan = 0.0; // in case there's an error above, it gets centered
                }

                if (pan <= 0) //centered or left, assign it to the left channel
                {
                    matrix[0, ArrangedChannels[curr_channel]] = vol;
                }
                if (pan >= 0) //centered or right, assignt to the right channel
                {
                    matrix[1, ArrangedChannels[curr_channel]] = vol;
                }
            }
            return matrix;
        }

        public bool SeparateWithSoX(string mogg, SongData song)
        {
            Tools = new NemoTools();
            try
            {
                var ogg = Path.GetTempPath() + "o";
                nautilus.DecM(File.ReadAllBytes(mogg), false, false, DecryptMode.ToFile, ogg);
                var folder = Path.GetDirectoryName(mogg) + "\\";
                var bass = folder + "rhythm.ogg";
                var guitar = folder + "guitar.ogg";
                var keys = folder + "keys.ogg";
                var vocals = folder + "vocals.ogg";
                var backing = folder + "song.ogg";
                var crowd = folder + "crowd.ogg";
                var drums = folder + "drums.ogg";
                var drums1 = folder + "drums_1.ogg";
                var drums2 = folder + "drums_2.ogg";
                var drums3 = folder + "drums_3.ogg";
                if (song.ChannelsDrums > 0)
                {
                    switch (song.ChannelsDrums)
                    {
                        case 2:
                            SendToSox(ogg, drums, song.AttenuationValues, 1, true);
                            break;
                        case 3:
                            SendToSox(ogg, drums1, song.AttenuationValues, 1, false);
                            SendToSox(ogg, drums2, song.AttenuationValues, 2, true);
                            break;
                        case 4:
                            SendToSox(ogg, drums1, song.AttenuationValues, 1, false);
                            SendToSox(ogg, drums2, song.AttenuationValues, 2, false);
                            SendToSox(ogg, drums3, song.AttenuationValues, 3, true);
                            break;
                        case 5:
                            SendToSox(ogg, drums1, song.AttenuationValues, 1, false);
                            SendToSox(ogg, drums2, song.AttenuationValues, 2, true);
                            SendToSox(ogg, drums3, song.AttenuationValues, 4, true);
                            break;
                        case 6:
                            SendToSox(ogg, drums1, song.AttenuationValues, 1, true);
                            SendToSox(ogg, drums2, song.AttenuationValues, 3, true);
                            SendToSox(ogg, drums3, song.AttenuationValues, 5, true);
                            break;
                    }
                }
                var index = song.ChannelsDrums + 1;
                if (song.ChannelsBass > 0)
                {
                    SendToSox(ogg, bass, song.AttenuationValues, index, song.ChannelsBass == 2);
                }
                index += song.ChannelsBass;
                if (song.ChannelsGuitar > 0)
                {
                    SendToSox(ogg, guitar, song.AttenuationValues, index, song.ChannelsGuitar == 2);
                }
                index += song.ChannelsGuitar;
                if (song.ChannelsVocals > 0)
                {
                    SendToSox(ogg, vocals, song.AttenuationValues, index, song.ChannelsVocals == 2);
                }
                index += song.ChannelsVocals;
                if (song.ChannelsKeys > 0)
                {
                    SendToSox(ogg, keys, song.AttenuationValues, index, song.ChannelsKeys == 2);
                }
                index += song.ChannelsKeys;
                if (song.ChannelsBacking() > 0)
                {
                    SendToSox(ogg, backing, song.AttenuationValues, index, song.ChannelsBacking() == 2);
                }
                index += song.ChannelsBacking();
                if (song.ChannelsCrowd > 0)
                {
                    SendToSox(ogg, crowd, song.AttenuationValues, index, song.ChannelsCrowd == 2);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void SendToSox(string input, string output, string AttenuationValues, int index, bool stereo)
        {
            var sox = Application.StartupPath + "\\bin\\sox.exe";
            var attenuation = "";
            var volumes = Regex.Split(AttenuationValues, " ");
            if (volumes.Count() >= index)
            {
                attenuation = volumes[index - 1].Trim() == "" || volumes[index - 1].Trim() == "0.0" ? "" : " gain " + volumes[index - 1].Trim();
            }
            var channels = index + (stereo ? " " + (index + 1) : "");
            var folder = Path.GetDirectoryName(input);
            if (string.IsNullOrEmpty(folder))
            {
                folder = Environment.CurrentDirectory;
            }
            var arg = "\"" + input + "\" -C 5 \"" + output + "\" remix " + channels + attenuation;
            var export = new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                FileName = sox,
                Arguments = arg,
                WorkingDirectory = folder
            };
            var process = Process.Start(export);
            do
            {
                //wait
            } while (!process.HasExited);
            process.Dispose();
        }
    }
}
