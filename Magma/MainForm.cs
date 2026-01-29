using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using MagmaRokOn.Properties;
using MagmaRokOn.x360;
using NAudio.Midi;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Enc;
using Un4seen.Bass.AddOn.Flac;
using Un4seen.Bass.AddOn.Mix;
using Un4seen.Bass.Misc;
using SearchOption = System.IO.SearchOption;
using NautilusFREE;

namespace MagmaRokOn
{
    public partial class MainForm : Form
    {
        public string mAppTitle = "Magma: Rok On Edition v4";
        public string mAppVersion = ".0.4";
        public string mDefaultAlbumArtPath;
        public string ProjectFolder;
        public string GuitarTuning = "(real_guitar_tuning (0 0 0 0 0 0))";
        public string BassTuning = "(real_bass_tuning (0 0 0 0))";
        public string Artist;
        public string Song;
        public string Album;
        public string SongAuthor;
        public string CustomID;
        public string SongID;
        public string CrowdAudio;
        public string ProjectCompiler = "MagmaCompilerC3.exe";
        public string PackageDisplay = "";
        public string PackageDescription = "Created with Magma: Rok On Edition.";
        public string PackageThumb = "";
        public string AudacityPath = "";
        public string nautilusPath = "";
        public string Encoding;
        public string Language = "English,";
        public string DefaultAuthor = "";
        public string DrumMixText;
        public string ActiveSkin = "dark";
        public string InstrumentSolos;
        public string SKIN_PATH;
        public string UniqueNumericID;
        public string UniqueNumericID2x;

        private string ProjDir = "";
        private string sample48 = "";
        private string sample44 = "";
        private string notSupported = "";
        private string originalMIDI;
        private string exportedMIDI;
        private string SongAlbumArt;
        
        private readonly string mStartupPath;
        private readonly string SilenceMono44;
        private readonly string SilenceMono48;
        private readonly string SilenceStereo44;
        private readonly string SilenceStereo48;
        private readonly string SilenceMono44_24;
        private readonly string SilenceMono48_24;
        private readonly string SilenceStereo44_24;
        private readonly string SilenceStereo48_24;
        private readonly string BlankDryvox;
        private readonly string data_folder;
        private readonly string config_file;
        
        public readonly string arguments;
        private const string DrumMix = "[mix # drums";
        private readonly string[] ToDoDescription = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

        private string[] mGenreSymbols;
        private string[] mSubGenreSymbols;
        private string[] mGenderSymbols;
        private string[] mPercussionSymbols;
        private string[] mDrumLayoutSymbols;
        private string[] mAutogenThemeFileNames;
        
        //private int[] mAnimationSpeeds;

        private const int WIDTH_EXPANDED = 1030;
        private const int WIDTH_COMPACT = 762;

        private int mSongLength;
        private int workingsample;
        private int workingBits;
        private int RankProGuitar = 1;
        private int RankProBass = 1;
        private int ActiveItem;
        private int BassMixer;
        private int BassStream;

        public int ProGuitarDiff = 0;
        public int ProBassDiff = 0;
        public int IsMaster = 1; //default to being a master
        public int SongRating = 4; //default to Unrated
        public int TonicNote = 0;
        public int yearReRecord;
        public int DrumSFX;
        public int HopoValue;
        public int TuningCents = 0;
        public int EncodingQuality = 5; //default (is higher than HMX's standard of 3)
        public int CrowdSampleRate;
        public int SongVersion = 1;
        public int MuteVol = -96;
        public int VocalMuteVol = -12;
        public int animTempo = 32;
        
        private static Color mMenuHighlight = Color.FromArgb(135, 0, 0);
        private static Color mMenuBackground = Color.Black;
        private static Color mMenuText = Color.Gray;
        private static Color mMenuBorder = Color.WhiteSmoke;
        private readonly Color ChartOrange = Color.FromArgb(255, 126, 0);
        private readonly Color ChartBlue = Color.FromArgb(0, 0, 255);
        private readonly Color ChartYellow = Color.FromArgb(242, 226, 0);
        private readonly Color ChartRed = Color.FromArgb(255, 0, 0);
        private readonly Color ChartGreen = Color.FromArgb(0, 255, 0);

        private Color mTabOnColor;
        private Color mTabOffColor;
        private Color mTabHoverColor;
        private Color mTextBoxEnabledBackColor;
        private Color mTextBoxDisabledBackColor;
        private Color ToDoBackColor = Color.Black;
        private Color ToDoForeColor = Color.White;
        
        public Color SkinTextBoxBackgroundColor;
        public Color SkinTextBoxTextColor;
        public Color SkinFormBackgroundColor;
        public Image SkinBackgroundImage;
        public Color SkinButtonBackgroundColor;
        public Color SkinButtonTextColor;

        private bool starting;
        private bool valid = true;
        private bool dispDefault = true;
        private bool dispDLC;
        private bool refreshing;
        private bool DoDrumMixes = true;
        private bool WiiWarning;
        private bool Importing;
        private bool showMessage;
        public bool AuthorDTA = true;
        public bool doRemoveSubgenre;

        public bool HasProGuitar = false;
        public bool HasProBass = false;
        public bool EnableTonic = false;
        public bool disableProKeys = false;
        public bool isReRecord = false;
        public bool KeepSongsDTA = false;
        public bool KeepExtracted = false;
        public bool isRhythmOnKeys = false;
        public bool isRhythmonBass = false;
        public bool is2xBassPedal = false;
        public bool isKaraoke = false;
        public bool isMultitrack = false;
        public bool isDIYStems = false;
        public bool isPartialMultitrack = false;
        public bool isUnpitchedVocals = false;
        public bool isConvert = false;
        public bool isXOnly = false;
        public bool isCATEMH = false;
        public bool useCustomID = false;
        public bool deleteRBAFileAfterConverting = true;
        public bool appendVersiontoID = true;
        public bool OverrideArt;
        public bool OverrideMilo;
        public bool OverrideMIDI;
        public bool OverrideMogg;
        public bool WiiMode = false;
        public bool GenKeysAnim;
        public bool GenProKeys;
        public bool GenDrumsMix;
        public bool is2XMIDI;
        public bool BypassNemo;
        public bool doLIVE;
        public bool useNumericID;
        public bool isBusy;

        public int difficultyDrums;
        public int difficultyBass;
        public int difficultyProBass;
        public int difficultyGuitar;
        public int difficultyProGuitar;
        public int difficultyVocals;
        public int difficultyKeys;
        public int difficultyProKeys;
        public int difficultyBand;

        private readonly bool[] ToDoImportant = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        private readonly bool[] ToDoCompleted = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        
        private Bitmap PipDevil;
        private Bitmap PipDevilOff;
        private Bitmap PipOn;
        private Bitmap PipOff;
        private Bitmap PipDisabledOn;
        private Bitmap PipDisabledOff;
        private Bitmap ToDoImgDone;
        private Bitmap ToDoImgNotDone;
        private Bitmap ToDoImgImportant;
        private Bitmap ToDoImgNotImportant;

        public Decimal CrowdVol = -5;
        public long SongPreview;
        public long PreviewEnd;
        public System.Text.Encoding FileEncoding;
        private readonly NemoTools Tools;
        private readonly DTAParser Parser;
        public ProjectFile ProjectFile { get; private set; }
        public FlatStyle SkinButtonStyle;
        private readonly Control[] mValidatedControls;
        private TransferProgressForm mTransferProgressForm;
        private Timer mTimer;
        private ThreadRunner mRunner;
        private ThreadSafeStringList mList;
        private PictureBox[] difficultyboxes;
        private TextBox ActiveTextBox;        
        public int bandFailIndex;

        public bool doTonality;
        public int songTonality;

        private readonly nTools nautilus;

        private sealed class DarkRenderer : ToolStripProfessionalRenderer
        {
            public DarkRenderer() : base(new DarkColors()) { }
        }
        
        private sealed class DarkColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return mMenuHighlight; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return mMenuHighlight; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return mMenuHighlight; }
            }
            public override Color MenuBorder
            {
                get { return mMenuBorder; }
            }
            public override Color MenuItemBorder
            {
                get { return mMenuBorder; }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get { return mMenuHighlight; }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return mMenuHighlight; }
            }
            public override Color MenuItemPressedGradientMiddle
            {
                get { return mMenuHighlight; }
            }
            public override Color CheckBackground
            {
                get { return mMenuHighlight; }
            }
            public override Color CheckPressedBackground
            {
                get { return mMenuHighlight; }
            }
            public override Color CheckSelectedBackground
            {
                get { return mMenuHighlight; }
            }
            public override Color ButtonSelectedBorder
            {
                get { return mMenuHighlight; }
            }
            public override Color SeparatorDark
            {
                get { return mMenuText; }
            }
            public override Color SeparatorLight
            {
                get { return mMenuText; }
            }
            public override Color ImageMarginGradientBegin
            {
                get { return mMenuBackground; }
            }
            public override Color ImageMarginGradientEnd
            {
                get { return mMenuBackground; }
            }
            public override Color ImageMarginGradientMiddle
            {
                get { return mMenuBackground; }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return mMenuBackground; }
            }
        }

        public MainForm(string args)
        {
            CheckForIllegalCrossThreadCalls = true;
            InitializeComponent();
            starting = true;
            Width = WIDTH_COMPACT;
            mStartupPath = Application.StartupPath;
            mTabOnColor = Color.WhiteSmoke;
            mTabOffColor = Color.LightGray;
            mTabHoverColor = Color.FromArgb(135, 0, 0);
            mTextBoxEnabledBackColor = Color.White;
            mTextBoxDisabledBackColor = Color.LightGray;
            PictureBoxAlbumArt.AllowDrop = true;
            picThumb.AllowDrop = true;

            nautilus = new nTools();
            data_folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\magma\\";
            var nautilusFile = data_folder + "nautilus";
            if (File.Exists(nautilusFile))
            {
                var sr = new StreamReader(nautilusFile);
                var line = sr.ReadLine();
                if (!string.IsNullOrEmpty(line) && File.Exists(line))
                {
                    nautilusPath = line;
                }
                sr.Dispose();
            }
            try
            {
                var sw = new StreamWriter(data_folder + "MagmaRokOn", false);
                sw.WriteLine(Application.StartupPath + "\\MagmaRokOn.exe");
                sw.Dispose();
            }
            catch (Exception)
            {
                //
            }

            menuStrip1.Renderer = new DarkRenderer();
            contextMenuStrip1.Renderer = new DarkRenderer();
            contextMenuStrip2.Renderer = new DarkRenderer();
            contextMenuStrip3.Renderer = new DarkRenderer();
            contextMenuStrip4.Renderer = new DarkRenderer();
            SkinMenuSkinChoices();

            arguments = args;
            Tools = new NemoTools();
            Parser = new DTAParser();

            PipDevil = Resources.skull_sm;
            PipDevilOff = Resources.skull_disabled_sm;
            PipOn = Resources.difficulty_button_ON;
            PipOff = Resources.difficulty_button_off;
            PipDisabledOn = Resources.difficulty_button_on_disabled;
            PipDisabledOff = Resources.difficulty_button_off_disabled;
            
            mValidatedControls = new Control[]
                {
                    TextBoxSongName,
                    TextBoxArtistName,
                    TextBoxAlbumName,
                    TextBoxAuthor,
                    TextBoxMidiFile,
                    TextBoxDrumKit,
                    TextBoxDrumKick,
                    TextBoxDrumSnare,
                    TextBoxBass,
                    TextBoxGuitar,
                    TextBoxVocals,
                    TextBoxDryVocals,
                    TextBoxDryVocalsHarmony2,
                    TextBoxDryVocalsHarmony3,
                    TextBoxBacking,
                    TextBoxKeys,     
                    TextBoxCrowd
                };

            // these string manipulations shouldn't be necessary, but they are for me to get the paths to the silent files to show up correctly
            // is there a null byte somewhere mucking things up?

            string tempString = Application.StartupPath + Application.StartupPath;
            SilenceMono44 = Application.StartupPath + "\\audio\\mono44.wav";
            SilenceMono48 = Application.StartupPath + "\\audio\\mono48.wav";
            SilenceStereo44 = Application.StartupPath + "\\audio\\stereo44.wav";
            SilenceStereo48 = Application.StartupPath + "\\audio\\stereo48.wav";
            SilenceMono44_24 = Application.StartupPath + "\\audio\\mono44_24.wav";
            SilenceMono48_24 = Application.StartupPath + "\\audio\\mono48_24.wav";
            SilenceStereo44_24 = Application.StartupPath + "\\audio\\stereo44_24.wav";
            SilenceStereo48_24 = Application.StartupPath + "\\audio\\stereo48_24.wav";
            BlankDryvox = Application.StartupPath + "\\audio\\blank_dryvox.wav";

            config_file = Application.StartupPath + "\\bin\\main4.config";
            
            ProjectFile = new ProjectFile();
            InitAllData();
            LoadOptions();
            
            RefreshAllData();
            if (File.Exists(Application.StartupPath + "\\default_template.todo"))
            {
                LoadTemplate(Application.StartupPath + "\\default_template.todo");
            }
            setNemoDefaults();
            
            if (!File.Exists(Application.StartupPath + "\\" + ProjectCompiler))
            {
                var alt_compiler = ProjectCompiler.ToLowerInvariant().Contains("c3") ? "MagmaCompiler.exe" : "MagmaCompilerC3.exe";
                if (File.Exists(Application.StartupPath + "\\" + alt_compiler))
                {
                    ProjectCompiler = alt_compiler;
                }
                else
                {
                    MessageBox.Show("I can't find either MagmaCompiler.exe or MagmaCompilerC3.exe\nI need the compiler to work, please copy it to the same folder where MagmaRokOn.exe is located, then choose the executable in the next screen",
                        mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var fileDialog = new OpenFileDialog
                    {
                        Filter = "Windows Executable (*.exe)|*.exe",
                        InitialDirectory = Application.StartupPath,
                        Title = "Choose Magma Compiler executable"
                    };

                    fileDialog.ShowDialog();

                    if (fileDialog.FileName != "" && fileDialog.FileName.Substring(fileDialog.FileName.Length - 4, 4) == ".exe")
                    {
                        ProjectCompiler = Path.GetFileName(fileDialog.FileName);
                        changeCompilerExecutable.Text = "Change compiler executable (currently using '" + ProjectCompiler + "')";
                    }
                    else
                    {
                        MessageBox.Show("That's not a valid selection\nI can't work in these stressful conditions!\nShutting down for now ... try again later when you can follow directions!",
                            mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                }
            }
            
            changeCompilerExecutable.Text = "Change compiler executable (currently using '" + Path.GetFileName(ProjectCompiler) + "')";
            
            if (args.EndsWith(".rbproj", StringComparison.Ordinal) && File.Exists(args))
            {
                if (!OpenRbprojFile(args))
                {
                    Environment.Exit(0);
                }
            }

            doToolTipBoxes(PictureDrumDifficulty1);
            doToolTipBoxes(PictureBassDifficulty1);
            doToolTipBoxes(PictureProBassDifficulty1);
            doToolTipBoxes(PictureGuitarDifficulty1);
            doToolTipBoxes(PictureProGuitarDifficulty1);
            doToolTipBoxes(PictureVocalDifficulty1);
            doToolTipBoxes(PictureKeysDifficulty1);
            doToolTipBoxes(PictureProKeysDifficulty1);
            doToolTipBoxes(PictureBandDifficulty1);

            RefreshWindowTitle(true);
            starting = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void doToolTipBoxes(object sender)
        {
            if (!GetDifficultyBoxes(sender)) return;

            ToolTip.SetToolTip(difficultyboxes[6], "Impossible");
            ToolTip.SetToolTip(difficultyboxes[5], "Nightmare");
            ToolTip.SetToolTip(difficultyboxes[4], "Challenging");
            ToolTip.SetToolTip(difficultyboxes[3], "Moderate");
            ToolTip.SetToolTip(difficultyboxes[2], "Solid");
            ToolTip.SetToolTip(difficultyboxes[1], "Apprentice");
            ToolTip.SetToolTip(difficultyboxes[0], "Warmup");
        }
        
        protected void GetControls(Control parent, ref List<Control> allControls)
        {
            allControls.Add(parent);
            foreach (Control parent1 in (ArrangedElementCollection)parent.Controls)
                GetControls(parent1, ref allControls);
        }

        protected void InitAllData()
        {
            ButtonInformationTab.ForeColor = mTabOnColor;
            mGenreSymbols = DataArrayUtl.GetSymbolListHeadings("ugc", "genres");
            mGenderSymbols = DataArrayUtl.GetSymbolListHeadings("ugc", "vocal_genders");
            mPercussionSymbols = DataArrayUtl.GetSymbolListHeadings("ugc", "vocal_percussion_types");
            //mDrumLayoutSymbols = DataArrayUtl.GetSymbolListHeadings("ugc", "drum_layouts");
            mDrumLayoutSymbols = new string[3] { "drum_layout_kit", "drum_layout_kit_kick", "drum_layout_kit_kick_snare" };
            var files = new DirectoryInfo(Application.StartupPath + "\\themes\\").GetFiles("*.rbtheme");
            var strArray = new string[files.Length + 1];
            strArray[0] = "Default";
            if (files.Length > 0)
            {
                var index = 1;
                foreach (var theme in files.Select(fileInfo => fileInfo.Name.Substring(0,fileInfo.Name.Length - 8)).Select(theme => Regex.Replace(theme, "([a-z])([A-Z])", "$1 $2")))
                {
                    strArray[index] = theme;
                    ++index;
                }
            }
            mAutogenThemeFileNames = strArray;
            ComboBoxAutogenTheme.DataSource = LocaleUtl.Localize(mAutogenThemeFileNames);
            ComboBoxGenre.DataSource = LocaleUtl.Localize(mGenreSymbols);
            ComboVocalGender.DataSource = LocaleUtl.Localize(mGenderSymbols);
            ComboVocalPercussion.DataSource = LocaleUtl.Localize(mPercussionSymbols);
            //ComboDrums.DataSource = LocaleUtl.Localize(mDrumLayoutSymbols);
            NumericUpDownYear.Minimum = new Decimal(1000);
            NumericUpDownYear.Maximum = 2112;
            NumericUpDownYear.Value = DateTime.Now.Year;
            NumericPreviewMins.Value = new Decimal(0);
            DomainPreviewSecs.SelectedItem = "30";
            //mAnimationSpeeds = DataArrayUtl.GetIntList("ugc", "anim_tempos");
            //ComboAnimationSpeed.DataSource = LocaleUtl.Localize(mAnimationSpeeds, "animation_speed_");
            ComboVocalScroll.Items.Clear();
            ComboVocalScroll.Items.Add("Comatose - 3000");
            ComboVocalScroll.Items.Add("Slower - 2750");
            ComboVocalScroll.Items.Add("Slow - 2600");
            ComboVocalScroll.Items.Add("Medium Slow - 2450"); 
            ComboVocalScroll.Items.Add("Normal - 2300"); 
            ComboVocalScroll.Items.Add("Medium Fast - 2150");
            ComboVocalScroll.Items.Add("Fast - 2000"); 
            ComboVocalScroll.Items.Add("Faster - 1850");
            ComboVocalScroll.Items.Add("Crazy - 1700");
            mDefaultAlbumArtPath = mStartupPath + "\\" + "default.bmp";
            if (!File.Exists(mDefaultAlbumArtPath))
            {
                MessageBox.Show("Default album art file is missing!\nThis will cause problems, so please re-download Magma: Rok On Edition and do not delete any files",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void RefreshGenres()
        {
            var genre = ProjectFile.Genre;
            mSubGenreSymbols = DataArrayUtl.GetSymbolListContents("ugc", "genres", genre);

            var subgenre = ProjectFile.SubGenre;
            ComboBoxSubGenre.DataSource = LocaleUtl.Localize(mSubGenreSymbols);
            UiUtl.SetLocalizedComboBoxValue(ComboBoxSubGenre, subgenre, mSubGenreSymbols);
        }
        
        protected void  RefreshAllData()
        {
            refreshing = true;
            ErrorProviderCharCheck.Clear();
            useCustomID = false;
            
            try
            {
                TextBoxSongName.Text = ProjectFile.SongName;
                TextBoxArtistName.Text = ProjectFile.ArtistName;
                CheckBoxFromAlbum.Checked = ProjectFile.HasAlbum;
                TextBoxAlbumName.Text = ProjectFile.AlbumName;
                TextBoxBuildDestination.Text = ProjectFile.DestinationFile.Replace(".rba", "");
                NumericUpDownYear.Value = ProjectFile.YearReleased;
                NumericTrackNumber.Value = ProjectFile.TrackNumber;

                if (overrideProjectFileAuthor.Checked && DefaultAuthor != "")
                {
                    TextBoxAuthor.Text = DefaultAuthor;
                }
                else
                {
                    TextBoxAuthor.Text = ProjectFile.Author;
                }
                
                UiUtl.SetLocalizedComboBoxValue(ComboBoxGenre, ProjectFile.Genre, mGenreSymbols);
                RefreshGenres();
                
                ProjectFile.Country = "ugc_country_us"; //always use US
                CheckBoxLangEnglish.Checked = ProjectFile.LangEnglish;
                CheckBoxLangFrench.Checked = ProjectFile.LangFrench;
                CheckBoxLangItalian.Checked = ProjectFile.LangItalian;
                CheckBoxLangSpanish.Checked = ProjectFile.LangSpanish;
                CheckBoxLangGerman.Checked = ProjectFile.LangGerman;
                CheckBoxLangJapanese.Checked = ProjectFile.LangJapanese;

                if (ProjectFile.AutogenTheme.Length == 0)
                {
                    UiUtl.SetComboBoxValue(ComboBoxAutogenTheme, "Arena Rock");
                }
                else
                {
                    try
                    {
                        for (var index = 0; index < ComboBoxAutogenTheme.Items.Count; index++) //find preset AutogenTheme and select
                        {
                            if (ProjectFile.AutogenTheme == ComboBoxAutogenTheme.Items[index].ToString().Replace(" ", string.Empty) + ".rbtheme")
                            {
                                ComboBoxAutogenTheme.SelectedIndex = index;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("The theme '" + ProjectFile.AutogenTheme + "' cannot be found, perhaps you deleted it?\nResetting your project to use the default theme.", "Autogeneration Theme Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        UiUtl.SetComboBoxValue(ComboBoxAutogenTheme, "Arena Rock");
                    }
                }
                NumericGuidePitchAttenuation.Value = (Decimal)ProjectFile.GuidePitchVolume;
                TextBoxMidiFile.Text = ProjectFile.MidiFile;
                //UiUtl.SetLocalizedComboBoxValue(ComboAnimationSpeed, ProjectFile.Tempo, mAnimationSpeeds);
                
                if (ProjectFile.PreviewStart > 0 && ProjectFile.PreviewStart <= 570000)
                {
                    var num1 = ProjectFile.PreviewStart / 1000;
                    var num2 = (int)Math.Floor((Decimal)(num1 / 60));
                    var num3 = num1 - num2 * 60;
                    NumericPreviewMins.Value = num2;
                    var str = Convert.ToString(num3);
                    if (str.Length == 1)
                        str = "0" + str;
                    DomainPreviewSecs.SelectedItem = str;
                    numericMilliseconds.Value = ProjectFile.PreviewStart - ((ProjectFile.PreviewStart/1000)*1000);
                }
                else
                {
                    if (ProjectFile.PreviewStart != 0)
                        MessageBox.Show("Preview start time is invalid. ");
                    NumericPreviewMins.Value = 0;
                    DomainPreviewSecs.SelectedItem = "30";
                    numericMilliseconds.Value = 0;
                    ProjectFile.PreviewStart = 30000;
                }
                UpdateSongLength();

                var track = ProjectFile.GetTrack("guitar");
                CheckGuitar.Checked = track.Enabled;
                NumericGuitarAttenuation.Value = (Decimal) track.VolLeft; 
                TextBoxGuitar.Text = track.Filename;

                track = ProjectFile.GetTrack("bass");
                CheckBass.Checked = track.Enabled;
                NumericBassAttenuation.Value =  (Decimal)track.VolLeft;
                TextBoxBass.Text = track.Filename;

                track = ProjectFile.GetTrack("vocals");
                CheckVocals.Checked = track.Enabled;
                NumericVocalAttenuation.Value =  (Decimal)track.VolLeft;
                TextBoxVocals.Text = track.Filename;

                track = ProjectFile.GetTrack("backing");
                CheckBacking.Checked = track.Enabled;
                NumericBackingAttenuation.Value =  (Decimal)track.VolLeft;
                TextBoxBacking.Text = track.Filename;

                track = ProjectFile.GetTrack("keys");
                CheckKeys.Checked = track.Enabled;
                NumericKeysAttenuation.Value =  (Decimal)track.VolLeft;
                TextBoxKeys.Text = track.Filename;

                TextBoxDryVocals.Text = ProjectFile.DryVoxFile;
                CheckHarmonyVocals2.Checked = ProjectFile.DryVoxHarmony2Enabled;
                CheckHarmonyVocals3.Checked = ProjectFile.DryVoxHarmony3Enabled;
                TextBoxDryVocalsHarmony2.Text = ProjectFile.DryVoxHarmony2File;
                TextBoxDryVocalsHarmony3.Text = ProjectFile.DryVoxHarmony3File;
                
                CheckDrums.Checked = ProjectFile.GetTrack("drum_kit").Enabled;
                UiUtl.SetLocalizedComboBoxValue(ComboDrums, ProjectFile.DrumLayout, mDrumLayoutSymbols);

                track = ProjectFile.GetTrack("drum_kick");
                NumericDrumKickAttenuation.Value =  (Decimal)track.VolLeft;
                TextBoxDrumKick.Text = track.Filename;

                track = ProjectFile.GetTrack("drum_snare");
                NumericDrumSnareAttenuation.Value =  (Decimal)track.VolLeft;
                TextBoxDrumSnare.Text = track.Filename;

                track = ProjectFile.GetTrack("drum_kit");
                NumericDrumKitAttenuation.Value =  (Decimal)track.VolLeft;
                TextBoxDrumKit.Text = track.Filename;

                UiUtl.SetLocalizedComboBoxValue(ComboVocalGender, ProjectFile.Gender, mGenderSymbols);
                UiUtl.SetLocalizedComboBoxValue(ComboVocalPercussion, ProjectFile.Percussion, mPercussionSymbols);
                
                ComboVocalScroll.Items.Clear();
                ComboVocalScroll.Items.Add("Comatose - 3000");
                ComboVocalScroll.Items.Add("Slower - 2750");
                ComboVocalScroll.Items.Add("Slow - 2600");
                ComboVocalScroll.Items.Add("Medium Slow - 2450");
                ComboVocalScroll.Items.Add("Normal - 2300");
                ComboVocalScroll.Items.Add("Medium Fast - 2150");
                ComboVocalScroll.Items.Add("Fast - 2000");
                ComboVocalScroll.Items.Add("Faster - 1850");
                ComboVocalScroll.Items.Add("Crazy - 1700");
                switch (ProjectFile.ScrollSpeed)
                {
                    case 3000:
                        ComboVocalScroll.SelectedIndex = 0;
                        break;
                    case 2750:
                        ComboVocalScroll.SelectedIndex = 1;
                        break;
                    case 2600:
                        ComboVocalScroll.SelectedIndex = 2;
                        break;
                    case 2450:
                        ComboVocalScroll.SelectedIndex = 3;
                        break;
                    case 2300:
                        ComboVocalScroll.SelectedIndex = 4;
                        break;
                    case 2150:
                        ComboVocalScroll.SelectedIndex = 5;
                        break;
                    case 2000:
                        ComboVocalScroll.SelectedIndex = 6;
                        break;
                    case 1850:
                        ComboVocalScroll.SelectedIndex = 7;
                        break;
                    case 1700:
                        ComboVocalScroll.SelectedIndex = 8;
                        break;
                    default:
                        ComboVocalScroll.SelectedIndex = 4;
                        break;
                }
                if (ProjectFile.RankBand < 1 || ProjectFile.RankBand > 7)
                {
                    ProjectFile.RankBand = 1;
                }
                UpdateDifficultyDisplayNEMO(PictureBandDifficulty1,ProjectFile.RankBand,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error reading the project file\nThe error says:\n" + ex.Message, mAppTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            doDrumMix();
            UpdateSkinnedPips();
            refreshing = false;
        }
        
        private void UpdateTrackDisplay(TrackInfo track)
        {
            var container1 = (PictureBox) null;
            var rank1 = 0;
            CheckBox checkBox;
            TextBox textBox;
            Label label;
            NumericUpDown control1;
            NumericUpDown control2;
            PictureBox container2;
            int rank2;
            switch (track.TrackType)
            {
                case "guitar":
                    checkBox = CheckGuitar;
                    textBox = TextBoxGuitar;
                    label = LabelGuitarPan;
                    control1 = NumericGuitarPan;
                    control2 = NumericGuitarAttenuation;
                    container2 = PictureGuitarDifficulty1;
                    rank2 = ProjectFile.RankGuitar;
                    break;
                case "keys":
                    checkBox = CheckKeys;
                    textBox = TextBoxKeys;
                    label = LabelKeysPan;
                    control1 = NumericKeysPan;
                    control2 = NumericKeysAttenuation;
                    container2 = PictureKeysDifficulty1;
                    rank2 = ProjectFile.RankKeys;
                    container1 = PictureProKeysDifficulty1;
                    rank1 = ProjectFile.RankProKeys;
                    break;
                case "bass":
                    checkBox = CheckBass;
                    textBox = TextBoxBass;
                    label = LabelBassPan;
                    control1 = NumericBassPan;
                    control2 = NumericBassAttenuation;
                    container2 = PictureBassDifficulty1;
                    rank2 = ProjectFile.RankBass;
                    break;
                case "vocals":
                    checkBox = CheckVocals;
                    textBox = TextBoxVocals;
                    label = LabelVocalPan;
                    control1 = NumericVocalPan;
                    control2 = NumericVocalAttenuation;
                    container2 = PictureVocalDifficulty1;
                    rank2 = ProjectFile.RankVocals;
                    break;
                case "drum_kit":
                    checkBox = null;
                    textBox = TextBoxDrumKit;
                    label = LabelDrumKitPan;
                    control1 = NumericDrumKitPan;
                    control2 = NumericDrumKitAttenuation;
                    container2 = PictureDrumDifficulty1;
                    rank2 = ProjectFile.RankDrum;
                    break;
                case "drum_kick":
                    checkBox = null;
                    textBox = TextBoxDrumKick;
                    label = LabelDrumKickPan;
                    control1 = NumericDrumKickPan;
                    control2 = NumericDrumKickAttenuation;
                    container2 = PictureDrumDifficulty1;
                    rank2 = ProjectFile.RankDrum;
                    break;
                case "drum_snare":
                    checkBox = null;
                    textBox = TextBoxDrumSnare;
                    label = LabelDrumSnarePan;
                    control1 = NumericDrumSnarePan;
                    control2 = NumericDrumSnareAttenuation;
                    container2 = PictureDrumDifficulty1;
                    rank2 = ProjectFile.RankDrum;
                    break;
                case "backing":
                    checkBox = CheckBacking;
                    textBox = TextBoxBacking;
                    label = LabelBackingPan;
                    control1 = NumericBackingPan;
                    control2 = NumericBackingAttenuation;
                    container2 = null;
                    rank2 = 1;
                    break;
                default:
                    MessageBox.Show("Invalid track type!\nCan't continue",mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            if (rank2 < 1 || rank2 > 7)
            {
                MessageBox.Show(rank2 + " is not a valid value for " + textBox.Tag + " difficulty",mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rank2 = 1;
            }
            if (track.PanLeft < -1.0 || track.PanLeft > 1.0 || track.PanRight < -1.0 || track.PanRight > 1.0)
            {
                MessageBox.Show("Invalid value found for " + textBox.Tag + " pan", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                track.PanLeft = (track.PanLeft < -1.0 || track.PanLeft > 1.0) ? (float)-1.0 : track.PanLeft;
                track.PanRight = (track.PanRight < -1.0 || track.PanRight > 1.0) ? (float)-1.0 : track.PanRight;
            }
            control1.Value = track.NumChannels == 1 ? (Decimal)track.PanLeft : new Decimal(0);
            control2.Value = (Decimal)track.VolLeft;
            switch (track.NumChannels)
            {
                case 2:
                    control1.Visible = false;
                    label.Visible = true;
                    control2.Visible = true;
                    break;
                case 1:
                    control1.Visible = true;
                    label.Visible = false;
                    control2.Visible = true;
                    break;
                default:
                    control1.Visible = false;
                    label.Visible = false;
                    control2.Visible = false;
                    break;
            }
            if (checkBox != null)
            {
                checkBox.Checked = track.Enabled;
            }
            if (container2 != null)
            {
                UpdateDifficultyDisplayNEMO(container2,rank2,track.Enabled);
            }
            if (container1 != null)
            {
                UpdateDifficultyDisplayNEMO(container1, rank1, track.Enabled);
            }
            UpdateSongLength();
        }

        private void UpdateSongLength()
        {
            LabelSongLength.Text = "0:00";
            mSongLength = 0;
            var strArray = new[]{"guitar","bass","vocals","drum_kit","drum_kick","drum_snare","backing"};
            foreach (var track in strArray.Select(trackType => ProjectFile.GetTrack(trackType)).Where(track => track.IsValid() && track.Length > mSongLength))
            {
                mSongLength = track.Length;
            }
            var num = (int)Math.Floor((Decimal)(mSongLength / 60));
            var str = Convert.ToString(mSongLength - num * 60);
            if (str.Length < 2)
            {
                str = "0" + str;
            }
            var duration = Convert.ToString(num) + ":" + str;
            if (duration != "0:01")  //using the included silence tracks would otherwise enable this
            {
                LabelSongLength.Text = duration;
            }
        }
        
        private void FileNewMenuItem_Click(object sender, EventArgs e)
        {
            if (ProjectFile.HasUnsavedChanges() && !Importing)
            {
                if (MessageBox.Show("You have unsaved changes\nAre you sure you want to do that?", mAppTitle,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            SuspendLayout();
            starting = true;
            StopBASS();
            ProjectFile.Dispose();
            ProjectFile = new ProjectFile();
            RefreshAllData();
            if (File.Exists(Application.StartupPath + "\\default_template.todo"))
            {
                LoadTemplate(Application.StartupPath + "\\default_template.todo");
            }
            setNemoDefaults();
            starting = false;
            ResumeLayout();
        }

        private void FileOpenMenuItem_Click(object sender, EventArgs e)
        {
            if (ProjectFile.HasUnsavedChanges())
            {
                if (MessageBox.Show("You have unsaved changes\nAre you sure you want to do that?", mAppTitle,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            
            var ofd = new OpenFileDialog
                {
                    Filter = "Magma: Rok On Edition Project File (*.rbproj)|*.rbproj",
                    InitialDirectory = Tools.CurrentFolder
                };
            if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
            {
                if (ofd.FileName.EndsWith(".rbproj", StringComparison.CurrentCultureIgnoreCase))
                {
                    OpenRbprojFile(ofd.FileName);
                    Tools.CurrentFolder = Path.GetDirectoryName(ofd.FileName) + "\\";
                }
                else
                {
                    MessageBox.Show("The selected file is not a valid Project file", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            RefreshWindowTitle(true);
        }

        private bool OpenRbprojFile(string filePath)
        {
            SuspendLayout();

            StopBASS();
            refreshing = true; //disable toast notifications while loading the file
            ProjectFile.Dispose();
            ProjectFile = new ProjectFile();
            setNemoDefaults();
            
            try
            {
                ProjDir = Path.GetDirectoryName(filePath) + "\\";
                Tools.CurrentFolder = ProjDir;
                if (!filePath.EndsWith(".rbproj", StringComparison.CurrentCultureIgnoreCase))
                    MessageBox.Show("The selected file is not a valid .rbproj file.");
                if (!string.IsNullOrEmpty(ProjDir))
                {
                    Directory.SetCurrentDirectory(ProjDir);
                }
                ProjectFile.Unlock();
                ProjectFile = new ProjectFile();
                ProjectFile.ReadFile(filePath);
            }
            catch (MagmaException ex)
            {
                UGCDebug.ShowOKMsgBox(this, ex.Message);
                ProjectFile = new ProjectFile();
                refreshing = false;
                return false;
            }
            
            RefreshAllData();
            refreshing = true;
            readFix(filePath);

            TextBoxAlbumArt.Text = TextBoxAlbumArt.Text.Replace(ProjDir, "");
            TextBoxBuildDestination.Text = TextBoxBuildDestination.Text.Replace(ProjDir, "");
            TextBoxMidiFile.Text = TextBoxMidiFile.Text.Replace(ProjDir, "");
            TextBoxDrumKick.Text = TextBoxDrumKick.Text.Replace(ProjDir, "");
            TextBoxDrumKit.Text = TextBoxDrumKit.Text.Replace(ProjDir, "");
            TextBoxDrumSnare.Text = TextBoxDrumSnare.Text.Replace(ProjDir, "");
            TextBoxGuitar.Text = TextBoxGuitar.Text.Replace(ProjDir, "");
            TextBoxBass.Text = TextBoxBass.Text.Replace(ProjDir, "");
            TextBoxKeys.Text = TextBoxKeys.Text.Replace(ProjDir, "");
            TextBoxVocals.Text = TextBoxVocals.Text.Replace(ProjDir, "");
            TextBoxBacking.Text = TextBoxBacking.Text.Replace(ProjDir, "");
            TextBoxCrowd.Text = TextBoxCrowd.Text.Replace(ProjDir, "");
            TextBoxDryVocals.Text = TextBoxDryVocals.Text.Replace(ProjDir, "");
            TextBoxDryVocalsHarmony2.Text = TextBoxDryVocalsHarmony2.Text.Replace(ProjDir, "");
            TextBoxDryVocalsHarmony3.Text = TextBoxDryVocalsHarmony3.Text.Replace(ProjDir, "");

            refreshing = false;
            RefreshWindowTitle(true);
            ResumeLayout();
            return true;
        }

        private void FileSaveMenuItem_Click(object sender, EventArgs e)
        {
            if (ProjectFile.HasFilename() && TextBoxBuildDestination.Text != "")
            {
                try
                {
                    if (string.IsNullOrEmpty(UniqueNumericID))
                    {
                        btnID_Click(null, null); //assign new ID if one hasn't been yet
                    }
                    ProjectFile.WriteFile();
                    saveFix(ProjectFile.GetFilename());
                    ProjDir = Path.GetDirectoryName(ProjectFile.GetFilename()) + "\\";
                    RefreshWindowTitle(true);
                }
                catch (MagmaException)
                {
                    UGCDebug.ShowOKMsgBox(this,"Unable to save your project file. Please make sure the location you are saving to is writeable and not full.");
                }
            }
            else
            {
                FileSaveAsMenuItem_Click(sender, e);
            }
        }

        private void FileSaveAsMenuItem_Click(object sender, EventArgs e)
        {
            LabelBuildTo.Focus();
            var sfd = new SaveFileDialog
                {
                    Filter = "Magma: Rok On Edition Project File (*.rbproj)|*.rbproj",
                    OverwritePrompt = true,
                    InitialDirectory = Tools.CurrentFolder
                };
            if (sfd.ShowDialog() != DialogResult.OK || String.IsNullOrEmpty(sfd.FileName))
            {
                return;
            }

            string fileName;
            try
            {
                fileName = Path.GetDirectoryName(sfd.FileName) + "\\" + Path.GetFileName(sfd.FileName).Replace(" ", "");
            }
            catch
            {
                fileName = sfd.FileName;
            }
            
            string strErr;
            if (!PathUtl.ValidateDirectory(ref fileName, "", ".rbproj", out strErr))
            {
                UGCDebug.ShowOKMsgBox(this, strErr);
            }
            else
            {
                try
                {
                    ProjectFile.WriteFile(fileName);
                    numVersion.Value = 1;
                    useCustomID = false;
                    CustomID = "";
                    UniqueNumericID = "";
                    UniqueNumericID2x = "";
                    txtSongID.Text = "";
                    ProjectFile.DestinationFile = CleanOutputFile(fileName.Replace(".rbproj",".rba"));
                    TextBoxBuildDestination.Text = ProjectFile.DestinationFile;
                    AppendStuffToFilename();
                    Tools.CurrentFolder = Path.GetDirectoryName(fileName);
                    btnID_Click(null, null); //assign new ID
                    ProjectFile.WriteFile();
                    saveFix(ProjectFile.GetFilename());
                    ProjDir = Path.GetDirectoryName(ProjectFile.GetFilename()) + "\\";
                    var boxes = new List<TextBox>
                    {
                        TextBoxAlbumArt,TextBoxBuildDestination,TextBoxDrumKick,TextBoxDrumKit,TextBoxDrumSnare,TextBoxBass,TextBoxGuitar,
                        TextBoxKeys,TextBoxVocals,TextBoxDryVocals,TextBoxDryVocalsHarmony2,TextBoxDryVocalsHarmony3,TextBoxBacking,
                        TextBoxCrowd,TextBoxMidiFile
                    };
                    foreach (var box in boxes.Where(box => box.Enabled && box.Text != ""))
                    {
                        box.Text = box.Text.Replace(ProjDir, "");
                    }
                    RefreshWindowTitle(true);
                }
                catch (MagmaException)
                {
                    UGCDebug.ShowOKMsgBox(this, "Unable to save your project file. Please make sure the location you are saving to is writeable and not full.");
                }
            }
        }

        private void setNemoDefaults()
        {
            starting = true;
            
            CheckBoxFromAlbum.Checked = true;
            NumericUpDownYear.Value = DateTime.Now.Year;
            numericReRecord.Value = NumericUpDownYear.Value;
            chkReRecord.Checked = false;
            chkMaster.Checked = true;
            ComboBoxGenre.SelectedIndex = ComboBoxGenre.Items.Count - 4; // default genre "Rock"
            ComboBoxSubGenre.SelectedIndex = ComboBoxSubGenre.Items.Count - 5; // default subgenre "Rock"
            ProjectFile.SubGenre = mSubGenreSymbols[ComboBoxSubGenre.SelectedIndex]; //force setting subgenre to proper value

            chkTonality.Checked = false;
            cboTonality.SelectedIndex = 0;
            ComboTonicNote.SelectedIndex = -1;
            chkTonicNote.Checked = false;
            CheckDrums.Checked = true;
            ComboDrums.SelectedIndex = 0;
            CheckBass.Checked = true;
            CheckGuitar.Checked = true;
            CheckVocals.Checked = true;
            CheckBacking.Checked = true;
            CheckKeys.Checked = false;
            chkProKeys.Checked = false;
            CheckCrowd.Checked = false;
            TextBoxCrowd.Text = "";
            TextBoxBacking.Text = "";
            CrowdAudio = "";
            numericCrowd.Value = -5;
            is2XMIDI = false;
            numericMilliseconds.Value = 0;
            prevEndMilliseconds.Value = 0;
            prevEndMinutes.Value = 1;
            prevEndSeconds.Text = "00";
            SongPreview = 0;
            PreviewEnd = 0;
            InstrumentSolos = "";
            chkSoloDrums.Checked = false;
            chkSoloGuitar.Checked = false;
            chkSoloBass.Checked = false;
            chkSoloKeys.Checked = false;
            chkSoloVocals.Checked = false;
            cboBandFail.SelectedIndex = 5;

            if (useSilenceTracksByDefault.Checked && use441KHzToolStripMenuItem.Checked)
            {
                TextBoxDrumKit.Text = SilenceStereo44;
                TextBoxBass.Text = SilenceStereo44;
                TextBoxGuitar.Text = SilenceStereo44;
                TextBoxVocals.Text = SilenceStereo44;
            }
            else if (useSilenceTracksByDefault.Checked && use48KHzToolStripMenuItem.Checked)
            {
                TextBoxDrumKit.Text = SilenceStereo48;
                TextBoxBass.Text = SilenceStereo48;
                TextBoxGuitar.Text = SilenceStereo48;
                TextBoxVocals.Text = SilenceStereo48;
            }
            else if (useSilenceTracksByDefault.Checked && use48KHz24bitToolStripMenuItem.Checked)
            {
                TextBoxDrumKit.Text = SilenceStereo48_24;
                TextBoxBass.Text = SilenceStereo48_24;
                TextBoxGuitar.Text = SilenceStereo48_24;
                TextBoxVocals.Text = SilenceStereo48_24;
            }
            else if (useSilenceTracksByDefault.Checked && use441KHz24bitToolStripMenuItem.Checked)
            {
                TextBoxDrumKit.Text = SilenceStereo44_24;
                TextBoxBass.Text = SilenceStereo44_24;
                TextBoxGuitar.Text = SilenceStereo44_24;
                TextBoxVocals.Text = SilenceStereo44_24;
            }
            
            ComboAnimationSpeed.SelectedIndex = 2; // 32

            txtSongID.Text = "";
            UniqueNumericID = "";
            UniqueNumericID2x = "";
            SongID = "";
            numVersion.Value = 1;
            ProjDir = "";
            
            PackageThumb = "";
            TextBoxAlbumArt.Text = mDefaultAlbumArtPath;
            SongAlbumArt = "";

            RankProGuitar = 1;
            UpdateDifficultyDisplayNEMO(PictureProGuitarDifficulty1,1,false);
            RankProBass = 1;
            UpdateDifficultyDisplayNEMO(PictureProBassDifficulty1,1,false);

            //set default to "Unrated"
            ComboRating.SelectedIndex = 3;

            //disable Tonic Note
            //chkTonicNote.Checked = false;

            //set drum kit sfx to default Arena Rock
            ComboDrumSFX.SelectedIndex = 0;

            //set hopo threshold to default 170
            ComboHopo.SelectedIndex = 2;

            //disable pro guitar and pro bass
            chkProBass.Checked = false;
            chkProGuitar.Checked = false;

            //find Arena Rock and set as default venue autogen theme
            for (var index = 0; index < ComboBoxAutogenTheme.Items.Count; index++)
            {
                if (ComboBoxAutogenTheme.Items[index].ToString() == "Arena Rock")
                {
                    ComboBoxAutogenTheme.SelectedIndex = index;
                }
            }

            chkRhythmBass.Checked = false;
            chkRhythmKeys.Checked = false;
            chk2xBass.Checked = false;
            chkKaraoke.Checked = false;
            chkMultitrack.Checked = false;
            chkConvert.Checked = false;
            chkXOnly.Checked = false;

            numericTuningCents.Value = 0;
            numericMuteVol.Value = -96;
            numericVocalMute.Value = -12;

            PackageDisplay = "";
            txtTitleDisplay.Text = PackageDisplay;
            PackageDescription = "Created with Magma: Rok On Edition.";
            txtDescription.Text = PackageDescription;
            dispDefault = true;
            dispDLC = false;

            if (DefaultAuthor != "")
            {
                TextBoxAuthor.Text = DefaultAuthor;
            }

            cboEncodingQuality.SelectedIndex = 2;// "03 (default)";
            EncodingQuality = 3;

            scrollDrums.Value = 1;
            scrollBass.Value = 1;
            scrollProBass.Value = 0;
            scrollGuitar.Value = 1;
            scrollProGuitar.Value = 0;
            scrollKeys.Value = 0;
            scrollProKeys.Value = 0;
            scrollVocals.Value = 1;
            scrollBand.Value = 1;

            chkTempo.Checked = !neverCheckForTempoMap.Checked;
            chkDrumsMix.Checked = true;
            ErrorProviderCharCheck.Clear();
            
            CustomID = "";
            ButtonExportMIDI.Enabled = TextBoxMidiFile.Text != "";
            doDrumMix();

            //overwrite initial "changes not saved" message, seems useless unless you actually change something
            ProjectFile.SetSaveStatus(SaveStatus.kSaved);
            Text = mAppTitle + (wiiConversion.Checked ? " (Wii Mode)" : "");

            starting = false;
        }
        
        private void FileExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void CheckDrums_CheckedChanged(object sender, EventArgs e)
        {
            var @checked = CheckDrums.Checked;
            scrollDrums.Enabled = @checked;
            ComboDrums.Enabled = CheckDrums.Checked;
            ComboDrumSFX.Enabled = CheckDrums.Checked;

            chkDrumsMix.Enabled = CheckDrums.Checked;

            numericMuteVol.Enabled = CheckDrums.Checked || CheckGuitar.Checked || CheckBass.Checked || CheckKeys.Checked;

            if (!CheckDrums.Checked)
            {
                EnableDisableTrack("drum_snare", false);
                SetTextBoxEnabledState(TextBoxDrumSnare, false);
                EnableDisableTrack("drum_kick", false);
                SetTextBoxEnabledState(TextBoxDrumKick, false);
                EnableDisableTrack("drum_kit", false);
                SetTextBoxEnabledState(TextBoxDrumKit, false);
                chkDrumsMix.Checked = false;
                lblDrumMix.Visible = false;
                chkSoloDrums.Checked = false;
            }
            else
            {
                EnableDisableTrack("drum_snare", ProjectFile.GetTrack("drum_snare").Enabled);
                SetTextBoxEnabledState(TextBoxDrumSnare, ProjectFile.GetTrack("drum_snare").Enabled);
                EnableDisableTrack("drum_kick", ProjectFile.GetTrack("drum_kick").Enabled);
                SetTextBoxEnabledState(TextBoxDrumKick, ProjectFile.GetTrack("drum_kick").Enabled);
                EnableDisableTrack("drum_kit", ProjectFile.GetTrack("drum_kit").Enabled);
                SetTextBoxEnabledState(TextBoxDrumKit, ProjectFile.GetTrack("drum_kit").Enabled);
                chkDrumsMix.Checked = DoDrumMixes;
            }

            scrollDrums.Value = @checked && scrollDrums.Value == 0 ? 1 : 0;
            chkSoloDrums.Enabled = @checked;
            PictureDrumDifficulty1.Enabled = @checked;
            PictureDrumDifficulty2.Enabled = @checked;
            PictureDrumDifficulty3.Enabled = @checked;
            PictureDrumDifficulty4.Enabled = @checked;
            PictureDrumDifficulty5.Enabled = @checked;
            PictureDrumDifficulty6.Enabled = @checked;
            PictureDrumDifficulty7.Enabled = @checked;
            UpdateDifficultyDisplayNEMO(PictureDrumDifficulty1, ProjectFile.RankDrum, @checked);
        }
        
        private void CheckBass_CheckedChanged(object sender, EventArgs e)
        {
            var @checked = ((CheckBox)sender).Checked;
            scrollBass.Enabled = @checked;
            EnableDisableTrack("bass", @checked);
            SetTextBoxEnabledState(TextBoxBass, @checked);

            ComboHopo.Enabled = CheckGuitar.Checked || CheckBass.Checked || CheckKeys.Checked;
            numericMuteVol.Enabled = CheckDrums.Checked || CheckGuitar.Checked || CheckBass.Checked || CheckKeys.Checked;

            scrollBass.Value = @checked && scrollBass.Value == 0 ? 1 : 0;

            PictureBassDifficulty1.Enabled = @checked;
            PictureBassDifficulty2.Enabled = @checked;
            PictureBassDifficulty3.Enabled = @checked;
            PictureBassDifficulty4.Enabled = @checked;
            PictureBassDifficulty5.Enabled = @checked;
            PictureBassDifficulty6.Enabled = @checked;
            PictureBassDifficulty7.Enabled = @checked;
            UpdateDifficultyDisplayNEMO(PictureBassDifficulty1, ProjectFile.RankBass, @checked);
            chkProBass.Enabled = @checked;
            chkProBass.Checked = false;
            
            chkSoloBass.Enabled = @checked;
            if (!@checked)
            {
                chkSoloBass.Checked = false;
            }
        }

        private void CheckKeys_CheckedChanged(object sender, EventArgs e)
        {
            var @checked = ((CheckBox)sender).Checked;
            scrollKeys.Enabled = @checked;
            EnableDisableTrack("keys", @checked);
            SetTextBoxEnabledState(TextBoxKeys, @checked);

            scrollKeys.Value = @checked && scrollKeys.Value == 0 ? 1 : 0;

            PictureKeysDifficulty1.Enabled = @checked;
            PictureKeysDifficulty2.Enabled = @checked;
            PictureKeysDifficulty3.Enabled = @checked;
            PictureKeysDifficulty4.Enabled = @checked;
            PictureKeysDifficulty5.Enabled = @checked;
            PictureKeysDifficulty6.Enabled = @checked;
            PictureKeysDifficulty7.Enabled = @checked;
            UpdateDifficultyDisplayNEMO(PictureKeysDifficulty1, ProjectFile.RankKeys, @checked);

            ComboHopo.Enabled = CheckGuitar.Checked || CheckBass.Checked || CheckKeys.Checked;
            numericMuteVol.Enabled = CheckDrums.Checked || CheckGuitar.Checked || CheckBass.Checked || CheckKeys.Checked;

            chkAutoKeys.Enabled = @checked;
            chkKeysAnim.Enabled = @checked;
            chkSoloKeys.Enabled = @checked;

            if (!@checked)
            {
                chkAutoKeys.Checked = false;
                chkKeysAnim.Checked = false;
                chkSoloKeys.Checked = false;
            }

            if (chkRhythmKeys.Checked) return;
            chkProKeys.Enabled = @checked;
            chkProKeys.Checked = @checked;
        }

        private void CheckGuitar_CheckedChanged(object sender, EventArgs e)
        {
            var @checked = ((CheckBox)sender).Checked;
            scrollGuitar.Enabled = @checked;
            EnableDisableTrack("guitar", @checked);
            SetTextBoxEnabledState(TextBoxGuitar, @checked);

            ComboHopo.Enabled = CheckGuitar.Checked || CheckBass.Checked || CheckKeys.Checked;
            numericMuteVol.Enabled = CheckDrums.Checked || CheckGuitar.Checked || CheckBass.Checked || CheckKeys.Checked;

            scrollGuitar.Value = @checked && scrollGuitar.Value == 0 ? 1 : 0;

            PictureGuitarDifficulty1.Enabled = @checked;
            PictureGuitarDifficulty2.Enabled = @checked;
            PictureGuitarDifficulty3.Enabled = @checked;
            PictureGuitarDifficulty4.Enabled = @checked;
            PictureGuitarDifficulty5.Enabled = @checked;
            PictureGuitarDifficulty6.Enabled = @checked;
            PictureGuitarDifficulty7.Enabled = @checked;
            UpdateDifficultyDisplayNEMO(PictureGuitarDifficulty1, ProjectFile.RankGuitar, @checked);
            chkProGuitar.Enabled = @checked;
            chkProGuitar.Checked = false;
            
            chkSoloGuitar.Enabled = @checked;
            if (!@checked)
            {
                chkSoloGuitar.Checked = false;
            }
        }

        private void CheckHarmonyVocals2_CheckedChanged(object sender, EventArgs e)
        {
            var enabled = CheckVocals.Checked && CheckHarmonyVocals2.Checked;
            ProjectFile.DryVoxHarmony2Enabled = enabled;
            CheckHarmonyVocals3.Enabled = enabled;
            if (!enabled)
            {
                CheckHarmonyVocals3.Checked = false;
            }
            SetTextBoxEnabledState(TextBoxDryVocalsHarmony2, enabled);
        }

        private void CheckHarmonyVocals3_CheckedChanged(object sender, EventArgs e)
        {
            var enabled = CheckVocals.Checked && CheckHarmonyVocals2.Checked && CheckHarmonyVocals3.Checked;
            ProjectFile.DryVoxHarmony3Enabled = enabled;
            SetTextBoxEnabledState(TextBoxDryVocalsHarmony3, enabled);
        }

        private void CheckVocals_CheckedChanged(object sender, EventArgs e)
        {
            var @checked = ((CheckBox)sender).Checked;
            scrollVocals.Enabled = @checked;
            EnableDisableTrack("vocals", @checked);
            SetTextBoxEnabledState(TextBoxVocals, @checked);
            SetTextBoxEnabledState(TextBoxDryVocals, @checked);
            numericVocalMute.Enabled = CheckVocals.Checked;

            ComboVocalScroll.Enabled = @checked;
            ComboVocalGender.Enabled = @checked;
            //chkTonicNote.Enabled = @checked;
            if (!@checked)
            {
                ComboTonicNote.Enabled = false;
                ComboTonicNote.SelectedIndex = -1;
                //chkTonicNote.Checked = false;
                chkSoloVocals.Checked = false;
            }
            numericTuningCents.Enabled = @checked;
            NumericGuidePitchAttenuation.Enabled = @checked;
            ComboVocalPercussion.Enabled = @checked;

            scrollVocals.Value = @checked && scrollVocals.Value == 0 ? 1 : 0;

            PictureVocalDifficulty1.Enabled = @checked;
            PictureVocalDifficulty2.Enabled = @checked;
            PictureVocalDifficulty3.Enabled = @checked;
            PictureVocalDifficulty4.Enabled = @checked;
            PictureVocalDifficulty5.Enabled = @checked;
            PictureVocalDifficulty6.Enabled = @checked;
            PictureVocalDifficulty7.Enabled = @checked;
            CheckHarmonyVocals2.Enabled = @checked;
            if (!@checked)
            {
                CheckHarmonyVocals2.Checked = false;
                CheckHarmonyVocals3.Checked = false;
            }
            CheckHarmonyVocals3.Enabled = CheckHarmonyVocals2.Checked;
            chkSoloVocals.Enabled = @checked;

            UpdateDifficultyDisplayNEMO(PictureVocalDifficulty1, ProjectFile.RankVocals, @checked);
        }

        private void EnableDisableTrack(string track_name, bool enabled)
        {
            var track = ProjectFile.GetTrack(track_name);
            if (track.Enabled != enabled)
            {
                track.Enabled = enabled;
                ProjectFile.SetTrack(track);
            }
            UpdateTrackDisplay(ProjectFile.GetTrack(track_name));
        }

        private void CheckBacking_CheckedChanged(object sender, EventArgs e)
        {
            var @checked = ((CheckBox) sender).Checked;
            EnableDisableTrack("backing", @checked);
            SetTextBoxEnabledState(TextBoxBacking, @checked);
        }

        private void ComboDrums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboDrums.SelectedIndex == -1)
            {
                return;
            }

            if (wiiConversion.Checked && !WiiWarning && ComboDrums.SelectedIndex != 0)
            {
                MessageBox.Show("You're currently using Wii Mode.\nDue to the Wii's limited memory, you are restricted to one stereo stem " +
                                "for the drums.\nIf the song has more than one audio stem for drums, use Audacity to merge them into a single stereo file.",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                WiiWarning = true;
                ComboDrums.SelectedIndex = 0;
                doDrumMix();
                return;
            }

            //WiiWarning = false;
            ProjectFile.DrumLayout = mDrumLayoutSymbols[ComboDrums.SelectedIndex];

            var kick = false;
            var snare = false;
            const bool kit = true;
            switch (ComboDrums.SelectedIndex)
            {
                case 1:
                    kick = true;
                    break;
                case 2:
                    snare = true;
                    kick = true;
                    break;
            }

            var store = starting;
            starting = true;
            EnableDisableTrack("drum_kick", kick);
            SetTextBoxEnabledState(TextBoxDrumKick, kick);
            EnableDisableTrack("drum_snare", snare);
            SetTextBoxEnabledState(TextBoxDrumSnare, snare);
            EnableDisableTrack("drum_kit", kit);
            SetTextBoxEnabledState(TextBoxDrumKit, kit);
            starting = store;

            if (!refreshing)
            {
                NumericDrumKickAttenuation.Value = 0;
                NumericDrumSnareAttenuation.Value = 0;
                NumericDrumKitAttenuation.Value = 0;
                SetTrackAttenuation("drum_kick", NumericDrumKickAttenuation);
                SetTrackAttenuation("drum_snare", NumericDrumSnareAttenuation);
                SetTrackAttenuation("drum_kit", NumericDrumKitAttenuation);
            }

            if (!kick)
            {
                TextBoxDrumKick.Text = "";
            }
            if (!snare)
            {
                TextBoxDrumSnare.Text = "";
            }
            
            PictureDrumDifficulty1.Enabled = true;
            PictureDrumDifficulty2.Enabled = true;
            PictureDrumDifficulty3.Enabled = true;
            PictureDrumDifficulty4.Enabled = true;
            PictureDrumDifficulty5.Enabled = true;
            PictureDrumDifficulty6.Enabled = true;
            PictureDrumDifficulty7.Enabled = true;
            UpdateDifficultyDisplayNEMO(PictureDrumDifficulty1, ProjectFile.RankDrum, true);

            doDrumMix();

            if (kick == true || snare == true)
            {
                if (EncodingQuality > 3)
                {
                    MessageBox.Show("You have selected a drum mix requiring multiple audio stems.\nAudio Quality 3 has been automatically selected" +
                                    "\ndue to known issues with playback on the PS3.", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboEncodingQuality.SelectedIndex = 2;// "3 (default)";
                    EncodingQuality = 3;
                }
            }
        }

        private void ButtonDrumKit_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(TextBoxDrumKit);
        }

        private void ButtonDrumKick_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(TextBoxDrumKick);
        }

        private void ButtonDrumSnare_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(TextBoxDrumSnare);
        }

        private void ButtonBass_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(TextBoxBass);
        }

        private void ButtonKeys_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(TextBoxKeys);
        }

        private void ButtonGuitar_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(TextBoxGuitar);
        }

        private void ButtonVocals_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(TextBoxVocals);
        }

        private void ButtonDryVocals_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(TextBoxDryVocals);
        }

        private void ButtonDryVocalsHarmony2_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(TextBoxDryVocalsHarmony2);
        }

        private void ButtonDryVocalsHarmony3_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(TextBoxDryVocalsHarmony3);
        }

        private void ButtonBacking_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(TextBoxBacking);
        }

        private void CheckMIDIFor2X(string MIDI, bool message = true)
        {
            if (!Tools.CheckMIDIFor2X(MIDI))
            {
                is2XMIDI = false;
                return;
            }
            if (!refreshing && message) //no notifications during loading of project file or if specified
            {
                MessageBox.Show("Found 2x Bass Pedal track in the MIDI file\nBoth versions will be built at once", mAppTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!chk2xBass.Checked)
                {
                    chk2xBass.Checked = true;
                }
            }
            is2XMIDI = true;
        }

        private void AnalyzeMIDIForContent(string midi)
        {
            var has_pro_keys = false;
            var has_pro_guitar = false;
            var has_pro_bass = false;
            try
            {
                var midifile = Tools.NemoLoadMIDI(midi);
                if (midifile == null)
                {
                    MessageBox.Show("Error analyzing MIDI file " + Path.GetFileName(midi), mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                for (var i = 0; i < midifile.Events.Tracks; i++)
                {
                    var trackname = midifile.Events[i][0].ToString();
                    if (trackname.Contains("DRUMS"))
                    {
                        CheckDrums.Checked = true;
                        chkSoloDrums.Checked = SearchMIDITrackForSolo(midifile.Events[i]);
                    }
                    else if (trackname.Contains("BASS") && !trackname.Contains("REAL"))
                    {
                        CheckBass.Checked = true;
                        chkSoloBass.Checked = SearchMIDITrackForSolo(midifile.Events[i]);
                    }
                    else if (trackname.Contains("BASS") && trackname.Contains("REAL"))
                    {
                        has_pro_bass = true;
                    }
                    else if (trackname.Contains("GUITAR") && !trackname.Contains("REAL"))
                    {
                        CheckGuitar.Checked = true;
                        chkSoloGuitar.Checked = SearchMIDITrackForSolo(midifile.Events[i]);
                    }
                    else if (trackname.Contains("GUITAR") && trackname.Contains("REAL"))
                    {
                        has_pro_guitar = true;
                    }
                    else if (trackname.Contains("KEYS") && !trackname.Contains("REAL") && !trackname.Contains("ANIM"))
                    {
                        CheckKeys.Checked = true;
                        chkSoloKeys.Checked = SearchMIDITrackForSolo(midifile.Events[i]);
                    }
                    else if (trackname.Contains("KEYS_X"))
                    {
                        has_pro_keys = true;
                    }
                    else if (trackname.Contains("VOCALS"))
                    {
                        CheckVocals.Checked = true;
                        chkSoloVocals.Checked = SearchMIDITrackForSolo(midifile.Events[i], true);
                    }
                    else if (trackname.Contains("HARM2"))
                    {
                        CheckHarmonyVocals2.Checked = true;
                    }
                    else if (trackname.Contains("HARM3"))
                    {
                        CheckHarmonyVocals3.Checked = true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error analyzing MIDI file " + Path.GetFileName(midi), mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            chkProKeys.Checked = has_pro_keys && CheckKeys.Checked;
            chkProBass.Checked = has_pro_bass && CheckBass.Checked;
            chkProGuitar.Checked = has_pro_guitar && CheckGuitar.Checked;
        }

        private bool SearchMIDITrackForSolo(IEnumerable<MidiEvent> track, bool is_vocals = false)
        {
            var has_solo = false;
            var found_perc = false;
            var solo_note = is_vocals ? 96 : 103;

            foreach (var notes in track)
            {
                switch (notes.CommandCode)
                {
                    case MidiCommandCode.MetaEvent:
                        if (found_perc) continue;
                        var vocal_event = (MetaEvent)notes;
                        if (vocal_event.ToString().Contains("[clap"))
                        {
                            ComboVocalPercussion.SelectedIndex = 2;
                            found_perc = true;
                        }
                        else if (vocal_event.ToString().Contains("[cowbell"))
                        {
                            ComboVocalPercussion.SelectedIndex = 1;
                            found_perc = true;
                        }
                        else if (vocal_event.ToString().Contains("[tambourine"))
                        {
                            ComboVocalPercussion.SelectedIndex = 0;
                            found_perc = true;
                        }
                        break;
                    case MidiCommandCode.NoteOn:
                        var note = (NoteOnEvent)notes;
                        if (note.Velocity <= 0 || note.NoteNumber != solo_note || has_solo) continue;
                        has_solo = true;
                        break;
                }
            }
            return has_solo;
        }

        private void GetMIDI(string str)
        {
            if (str == "")
            {
                ErrorProviderCharCheck.SetError(TextBoxMidiFile, "");
                ButtonExportMIDI.Enabled = false;
                return;
            }

            string str2;

            if (File.Exists(ProjDir + str))
            {
                str2 = ProjDir + str;
                ButtonExportMIDI.Enabled = true;
            }
            else if (File.Exists(str))
            {
                str2 = str;
                ButtonExportMIDI.Enabled = true;
            }
            else
            {
                ErrorProviderCharCheck.SetError(TextBoxMidiFile, "Can't find that MIDI file!");
                ButtonExportMIDI.Enabled = false;
                return;
            }

            ErrorProviderCharCheck.SetError(TextBoxMidiFile, "");
            Tools.CurrentFolder = Path.GetDirectoryName(str2) + "\\";
            ProjectFile.MidiFile = str2;
            CheckMIDIFor2X(str2);
            ValidateMidiFile(str2);
            str = str2;

            if (analyzeMIDIFileForContents.Checked)
            {
                AnalyzeMIDIForContent(str2);
            }
        
            var f = new FileInfo(str);
            var s1 = f.Length;
            const long MBinBytes = 1048576;
            var fixedMIDI = Path.GetDirectoryName(str) + "\\" + Path.GetFileNameWithoutExtension(str) + "_fixed.mid";
            if (s1 <= MBinBytes) return;
            if (File.Exists(Application.StartupPath + "\\bin\\midishrink.exe"))
            {
                var folder = Path.GetDirectoryName(str) ?? Tools.CurrentFolder;
                var startInfo = new ProcessStartInfo
                    {
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        FileName = Application.StartupPath + "\\bin\\midishrink.exe",
                        Arguments = "\"" + str + "\" \"" + fixedMIDI + "\"",
                        WorkingDirectory = folder
                    };
                var process = Process.Start(startInfo);
                do
                {
                    //wait until it's done
                } while (!process.HasExited);

                

                if (!File.Exists(fixedMIDI))
                {
                    MessageBox.Show("The MIDI file you selected was too big!\nI tried compressing it but something went wrong.\nNothing was changed in your project.\nTry again.",
                        mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    var n = new FileInfo(fixedMIDI);
                    var s2 = n.Length;

                    if (s2 < MBinBytes)
                    {
                        MessageBox.Show("Just wanted to let you know the MIDI file you selected was too big!\nIt was originally " +
                            s1 + " bytes but don't worry,\nI compressed the file for you and now it is only " + s2 +
                            " bytes\nThis should compile fine", mAppTitle, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        TextBoxMidiFile.Text = fixedMIDI;
                    }
                    else
                    {
                        MessageBox.Show("The MIDI file you selected is too big!\nIt was originally " + s1 +
                                        " bytes and after compressing now it is still " + s2 +
                                        " bytes\nThis is more than the maximum " + MBinBytes +
                                        " bytes size allowed\nMagmaCompiler will not be able to compile this song, sorry!",
                                        mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "Oh no, there's a problem\nThe MIDI is too big, and I was going to try to shrink it for you\nbut I can't find midishrink.exe in my program directory!\nI can't do anything about this, and MagmaCompiler won't accept your MIDI\nSorry",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonBrowseForMIDI_Click(object sender, EventArgs e)
        {
            var dir = ProjDir != "" ? ProjDir : Tools.CurrentFolder;

            var ofd = new OpenFileDialog
            {
                Filter = "MIDI File (*.mid)|*.mid",
                InitialDirectory = dir,
                Title = "Select MIDI File"
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            TextBoxMidiFile.Text = string.IsNullOrEmpty(ProjDir) ? ofd.FileName : ofd.FileName.Replace(ProjDir, "");
        }

        private void EnableDisable(bool enabled)
        {
            TabPageAudio.Enabled = enabled;
            TabPageGameData.Enabled = enabled;
            TabPageInformation.Enabled = enabled;
            menuStrip1.Enabled = enabled;
        }

        private void GetAudioFile(TextBoxBase tb)
        {
            try
            {
                if (!string.IsNullOrEmpty(ProjDir) && tb.Text.Contains(ProjDir))
                {
                    tb.Text = tb.Text.Replace(ProjDir, "");
                    return;
                }
                if (tb.Text.Contains(Application.StartupPath + "\\"))
                {
                   tb.Text = tb.Text.Replace(Application.StartupPath + "\\", "");
                }

                //work around issues when cut/pasting project folder to another directory
                if (tb.Text != "" && !File.Exists(tb.Text) && !Importing && !File.Exists(ProjDir + tb.Text) && !File.Exists(Application.StartupPath + "\\" + tb.Text))
                {
                    if (File.Exists(ProjDir + Path.GetFileName(tb.Text)))
                    {
                        tb.Text = Path.GetFileName(tb.Text);
                        return;
                    }
                    try
                    {
                        var folder = Path.GetDirectoryName(tb.Text);
                        if (!string.IsNullOrEmpty(folder))
                        {
                            var parent = Directory.GetParent(folder);
                            var subfolder = tb.Text.Replace(parent + "\\", "");
                            if (File.Exists(ProjDir + subfolder))
                            {
                                tb.Text = subfolder;
                                return;
                            }
                        }
                    }
                    catch (Exception)
                    {}
                }

                string str;
                tb.Select(tb.Text.Length, 0);

                if (!string.IsNullOrEmpty(ProjDir) && File.Exists(ProjDir + tb.Text)) // seems to throw a false positive when ProjDir is empty
                {
                    str = ProjDir + tb.Text;
                }
                else if (File.Exists(Application.StartupPath + "\\" + tb.Text))
                {
                    str = Application.StartupPath + "\\" + tb.Text;
                }
                else if (File.Exists(tb.Text))
                {
                    str = tb.Text;
                }
                else if (tb.Text == "")
                {
                    str = "";
                }
                else if (tb.Enabled)
                {
                    ErrorProviderCharCheck.SetError(tb, "Can't find that audio file!");
                    return;
                }
                else
                {
                    return;
                }

                var ext = Path.GetExtension(str).ToLowerInvariant();
                switch (ext)
                {
                    case ".ogg":
                    case ".mp3":
                    case ".flac":
                        var wav = Path.GetDirectoryName(str) + "\\" + Path.GetFileNameWithoutExtension(str) + ".wav";
                        if (File.Exists(wav))
                        {
                            tb.Text = wav;
                            return;
                        }
                        EnableDisable(false);
                        try
                        {
                            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                            Tools.PlayingSongOggData = File.ReadAllBytes(str);
                            var stream = ext == ".flac" ? BassFlac.BASS_FLAC_StreamCreateFile(Tools.GetOggStreamIntPtr(), 0, Tools.PlayingSongOggData.Length, BASSFlag.BASS_STREAM_DECODE) : 
                                Bass.BASS_StreamCreateFile(Tools.GetOggStreamIntPtr(), 0, Tools.PlayingSongOggData.Length, BASSFlag.BASS_STREAM_DECODE);
                            if (stream == 0)
                            {
                                EnableDisable(true);
                                MessageBox.Show("I wasn't able to read audio file '" + Path.GetFileName(str) + "' so I can't convert it to WAV, sorry", mAppTitle, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                                Bass.BASS_Free();
                            }
                            else
                            {
                                BassEnc.BASS_Encode_Start(stream, wav, BASSEncode.BASS_ENCODE_PCM | BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
                                while (true)
                                {
                                    var buffer = new byte[20000];
                                    var c = Bass.BASS_ChannelGetData(stream, buffer, buffer.Length);
                                    if (c < 0) break;
                                }
                                Tools.ReleaseStreamHandle();
                                Bass.BASS_Free();
                                if (File.Exists(wav))
                                {
                                    EnableDisable(true);
                                    tb.Text = wav;
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            EnableDisable(true);
                            MessageBox.Show("Error converting audio file '" + Path.GetFileName(str) + "' to WAV\nError: " + ex.Message, mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        try
                        {
                            Bass.BASS_Free();
                        }
                        catch (Exception)
                        { }
                        break;
                }

                ErrorProviderCharCheck.SetError(tb, "");
                TrackInfo track;
                switch (tb.Name)
                {
                    case "TextBoxVocals":
                        track = new TrackInfo(str, "vocals", (float)NumericVocalPan.Value, (float)NumericVocalAttenuation.Value, CheckVocals.Checked);
                        break;
                    case "TextBoxDrumKit":
                        track = new TrackInfo(str, "drum_kit", (float)NumericDrumKitPan.Value, (float)NumericDrumKitAttenuation.Value, CheckDrums.Checked);
                        break;
                    case "TextBoxDrumSnare":
                        track = new TrackInfo(str, "drum_snare", (float)NumericDrumSnarePan.Value, (float)NumericDrumSnareAttenuation.Value, CheckDrums.Checked);
                        break;
                    case "TextBoxDrumKick":
                        track = new TrackInfo(str, "drum_kick", (float)NumericDrumKickPan.Value, (float)NumericDrumKickAttenuation.Value, CheckDrums.Checked);
                        break;
                    case "TextBoxBass":
                        track = new TrackInfo(str, "bass", (float)NumericBassPan.Value, (float)NumericBassAttenuation.Value, CheckBass.Checked);
                        break;
                    case "TextBoxGuitar":
                        track = new TrackInfo(str, "guitar", (float)NumericGuitarPan.Value, (float)NumericGuitarAttenuation.Value, CheckGuitar.Checked);
                        break;
                    case "TextBoxKeys":
                        track = new TrackInfo(str, "keys", (float)NumericKeysPan.Value, (float)NumericKeysAttenuation.Value, CheckKeys.Checked);
                        break;
                    case "TextBoxBacking":
                        track = new TrackInfo(str, "backing", (float)NumericBackingPan.Value, (float)NumericBackingAttenuation.Value, CheckBacking.Checked);
                        break;
                    case "TextBoxDryVocals":
                        track = null;
                        ProjectFile.DryVoxFile = str;
                        break;
                    case "TextBoxDryVocalsHarmony2":
                        track = null;
                        ProjectFile.DryVoxHarmony2File = str;
                        break;
                    case "TextBoxDryVocalsHarmony3":
                        track = null;
                        ProjectFile.DryVoxHarmony3File = str;
                        break;
                    default:
                        track = null;
                        break;
                }

                if (!string.IsNullOrEmpty(str))
                {
                    ValidateTrack(tb, str);
                    UpdateSongLength();
                }

                if (track != null)
                {
                    ProjectFile.SetTrack(track);
                    UpdateTrackDisplay(track);
                }
                RefreshWindowTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error accessing that audio file\n\nThe error says:\n" + ex.Message + "\n\nTry again",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void GetFilePathForTextbox(Control tb)
        {
            var dir = ProjDir != "" ? ProjDir : Tools.CurrentFolder;
            var ofd = new OpenFileDialog
            {
                Title = "Select audio file to use",
                Filter = "Audio Files|*.wav;*.flac;*.ogg;*.mp3",
                InitialDirectory = dir
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tb.Text = string.IsNullOrEmpty(ProjDir) ? ofd.FileName : ofd.FileName.Replace(ProjDir, "");
            }
        }

        private static bool IsValidAlbumArt(string artPath)
        {
            if (!File.Exists(artPath))
                return false;
            try
            {
                return Wrapper.IsBMPCompilable(artPath);
            }
            catch
            {
                return false;
            }
        }

        private string FindFile(string file)
        {
            if (String.IsNullOrEmpty(file)) return null;
            if (File.Exists(ProjDir + file))
            {
                return ProjDir + file;
            }
            if (File.Exists(Application.StartupPath + "\\" + file))
            {
                return Application.StartupPath + "\\" + file;
            }
            return File.Exists(file) ? file : null;
        }

        private void checkSampleRates(Control tb, string track)
        {
            if (tb.Text == "" || !tb.Enabled)
            {
                return;
            }

            var wave = FindFile(tb.Text);
            if (wave == null)
            {
                notSupported = notSupported + track + " (Can't find file)";
                valid = false;
                return;
            }

            var stemInfo = new Wrapper.WaveInfo();
            Wrapper.GetWaveInfo(wave, stemInfo);

            if (workingsample == 0)
            {
                workingsample = stemInfo.mSampleRate;
            }
            if (workingBits == 0)
            {
                workingBits = stemInfo.mBitsPerSample;
            }
            if (stemInfo.mSampleRate != workingsample || stemInfo.mBitsPerSample != workingBits)
            {
                valid = false;
            }

            switch (stemInfo.mSampleRate)
            {
                case 44100:
                    sample44 = sample44 + track + " (" + stemInfo.mBitsPerSample + "-bit)";
                    break;
                case 48000:
                    sample48 = sample48 + track + " (" + stemInfo.mBitsPerSample + "-bit)";
                    break;
                default:
                    notSupported = notSupported + track + " - " + stemInfo.mSampleRate + "Hz" + " (" + stemInfo.mBitsPerSample + "-bit)";
                    valid = false;
                    ErrorProviderCharCheck.SetError(tb, "Not supported sample rate: " + stemInfo.mSampleRate);
                    break;
            }
        }
        
        private bool PassesAudioChecks()
        {
            workingsample = 0;
            sample44 = "";
            sample48 = "";
            notSupported = "";
            valid = true;

            checkSampleRates(TextBoxDrumKick, "\nDrum Kick");
            checkSampleRates(TextBoxDrumKit, "\nDrum Kit");
            checkSampleRates(TextBoxDrumSnare, "\nDrum Snare");
            checkSampleRates(TextBoxBass, "\nBass");
            checkSampleRates(TextBoxGuitar, "\nGuitar");
            checkSampleRates(TextBoxKeys, "\nKeys");
            checkSampleRates(TextBoxVocals, "\nVocals");
            checkSampleRates(TextBoxBacking, "\nBacking");
            checkSampleRates(TextBoxCrowd, "\nCrowd");
            if (!valid)
            {
                MessageBox.Show("You have audio stems with different sample rates and/or bits per sample\nAll audio stems must be either 44,100Hz or 48,000Hz, must be in the same sample rate, and must have matching bits per sample (16 bit or 24 bit only)\nRight now you have the following:\n\n44,100Hz:" +
                    sample44 + "\n\n48,000Hz:" + sample48 + "\n\nNot Supported:" + notSupported + "\n\nYou can't compile the song until all tracks match!\nTry again", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var tracks = 0;
            if (CheckDrums.Checked) tracks++;
            if (CheckGuitar.Checked) tracks++;
            if (CheckBass.Checked) tracks++;
            if (CheckKeys.Checked) tracks++;
            if (CheckVocals.Checked) tracks++;
            if (CheckBacking.Checked) tracks++;
            if (CheckCrowd.Checked) tracks++;
            if (tracks < 3)
            {
                if (MessageBox.Show("You seem to only have " + tracks + " audio " + (tracks == 1 ? "track" : "tracks") +
                                    " for this project\n\nMagmaCompiler may corrupt your resulting audio file unless you add another " +
                                    "audio track!\n\nIf you don't have any more instruments to author, you can try enabling Crowd Audio and " +
                                    "using a silent audio track to prevent this problem\n\nClick OK to continue and compile as is\nClick CANCEL to " +
                                    "cancel and modify your audio tracks", mAppTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                {
                    return false;
                }
            }
            var backing = FindFile(TextBoxBacking.Text);
            if (backing == null) return true;
            backing = Path.GetFileName(backing);
            var duplicates = 0;
            if (Path.GetFileName(FindFile(TextBoxDrumKit.Text)) == backing) duplicates++;
            if (Path.GetFileName(FindFile(TextBoxDrumKick.Text)) == backing) duplicates++;
            if (Path.GetFileName(FindFile(TextBoxDrumSnare.Text)) == backing) duplicates++;
            if (Path.GetFileName(FindFile(TextBoxBass.Text)) == backing) duplicates++;
            if (Path.GetFileName(FindFile(TextBoxGuitar.Text)) == backing) duplicates++;
            if (Path.GetFileName(FindFile(TextBoxKeys.Text)) == backing) duplicates++;
            if (Path.GetFileName(FindFile(TextBoxVocals.Text)) == backing) duplicates++;
            if (Path.GetFileName(FindFile(TextBoxCrowd.Text)) == backing) duplicates++;

            if (duplicates <= 0) return true;
            return MessageBox.Show("It looks like you're using the backing audio file '" + backing + "' multiple times!!!\nThis is " +
                                   "likely to cause audio distortion in game and is NOT how you create customs without audio stems\nYou " +
                                   "should use a blank or silence audio file for all instruments and the backing audio file alone in the backing " +
                                   "track\n\nClick OK to continue and compile as is\nClick CANCEL to cancel and modify your audio tracks", mAppTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel;
        }

        private bool CompletedTODO()
        {
            for (var i = 0; i < 15; i++)
            {
                if (!ToDoImportant[i] || ToDoCompleted[i]) continue;
                MessageBox.Show("The following To Do Item is marked as important but not completed:\n\n" +
                    (i + 1) + ". " + ToDoDescription[i] + "\n\nPlease complete this To Do item before continuing", mAppTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void ButtonBuildSong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectFile.GetFilename()))
            {
                MessageBox.Show("You must save the project at least once before you can compile a song", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (!PassesAudioChecks()) return;
            if (!doSongPreview(true)) return;
            if (!MidiIsClean()) return;
            if (!CompletedTODO()) return;

            if (!string.IsNullOrEmpty(ProjectFile.DestinationFile) && ProjectFile.DestinationFile.Contains("v#"))
            {
                ProjectFile.DestinationFile = ProjectFile.DestinationFile.Replace("v#", "v" + (int)numVersion.Value);
            } 
            
            var filename = Path.GetFileNameWithoutExtension(ProjectFile.DestinationFile);
            var max = 26 + (appendSongVersionToFileName.Checked ? 2 : 0) + (appendrb3conToFile.Checked ? 7 : 0);
            if (filename != null && filename.Length > max)
            {
                MessageBox.Show("Your filename is " + filename.Length + " characters long\nLong filenames like that can cause compatibility problems\nPlease try again with a shorter filename", mAppTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (!string.IsNullOrEmpty(ProjectFile.DestinationFile) && !ProjectFile.DestinationFile.EndsWith(".rba", StringComparison.Ordinal))
            {
                ProjectFile.DestinationFile = ProjectFile.DestinationFile + ".rba";
            }
            
            if (ProjDir != "" && Path.GetDirectoryName(ProjectFile.DestinationFile) + "\\" != ProjDir && !Directory.Exists(Path.GetDirectoryName(ProjectFile.DestinationFile) + "\\"))
            {
                ProjectFile.DestinationFile = ProjectFile.DestinationFile.Replace(Path.GetDirectoryName(ProjectFile.DestinationFile) + "\\", ProjDir);
                ProjectFile.WriteFile();
            }

            if (string.IsNullOrEmpty(UniqueNumericID))
            {
                btnID_Click(null, null);
            }

            GenKeysAnim = chkKeysAnim.Checked;
            GenDrumsMix = chkDrumsMix.Checked;
            GenProKeys = chkAutoKeys.Checked;
            DrumMixText = lblDrumMix.Text;
            appendVersiontoID = appendSongVersionToSongID.Checked;
            deleteRBAFileAfterConverting = deleteRBAFiles.Checked;
            KeepSongsDTA = keepSongsdtaFile.Checked;
            KeepExtracted = doNotDeleteExtractedFiles.Checked;
            WiiMode = wiiConversion.Checked;
            GetTextEncoding();

            valid = true;
            sample48 = "";
            sample44 = "";
            notSupported = "";
            workingsample = 0;
            workingBits = 0;
            
            SongRating = ComboRating.SelectedIndex + 1;
            isReRecord = chkReRecord.Checked;
            yearReRecord = (int)numericReRecord.Value;
            EnableTonic = chkTonicNote.Checked;
            TonicNote = ComboTonicNote.SelectedIndex;
            TuningCents = (int)numericTuningCents.Value;
            HasProBass = chkProBass.Checked;
            HasProGuitar = chkProGuitar.Checked;
            numericVocalMute.Value = (int) numericVocalMute.Value;
            numericMuteVol.Value = (int) numericMuteVol.Value;
            CrowdVol = numericCrowd.Value;
            
            isRhythmOnKeys = chkRhythmKeys.Checked;
            isRhythmonBass = chkRhythmBass.Checked;
            isMultitrack = chkMultitrack.Checked;
            isKaraoke = chkKaraoke.Checked;
            isDIYStems = chkDIYStems.Checked;
            isPartialMultitrack = chkPartial.Checked;
            isUnpitchedVocals = chkUnpitched.Checked;
            isXOnly = chkXOnly.Checked;
            isConvert = chkConvert.Checked;
            is2xBassPedal = chk2xBass.Checked;
            isCATEMH = chkCAT.Checked;
            doLIVE = signSongAsLIVE.Checked;
            useNumericID = useUniqueNumericSongID.Checked;

            difficultyDrums = scrollDrums.Value;
            difficultyBass = scrollBass.Value;
            difficultyProBass = scrollProBass.Value;
            difficultyGuitar = scrollGuitar.Value;
            difficultyProGuitar = scrollProGuitar.Value;
            difficultyVocals = scrollVocals.Value;
            difficultyKeys = scrollKeys.Value;
            difficultyProKeys = scrollProKeys.Value;
            difficultyBand = scrollBand.Value;

            OverrideArt = overrideAlbumArt.Checked;
            OverrideMilo = overrideMiloFile.Checked;
            OverrideMIDI = overrideMIDIFile.Checked;
            OverrideMogg = overrideAudioFile.Checked;
            BypassNemo = bypassNemosMIDIValidator.Checked;

            InstrumentSolos = (chkSoloDrums.Checked ? "drum" : "") + " " + (chkSoloGuitar.Checked ? "guitar" : "") + " " +
                              (chkSoloBass.Checked ? "bass" : "") + " " + (chkSoloKeys.Checked ? "keys" : "") + " " +
                              (chkSoloVocals.Checked ? "vocal_percussion" : "");
            InstrumentSolos = InstrumentSolos.Trim();
            if (!string.IsNullOrEmpty(InstrumentSolos))
            {
                InstrumentSolos = "(solo (" + InstrumentSolos + "))";
            }

            disableProKeys = CheckKeys.Checked && !chkProKeys.Checked;
            IsMaster = chkMaster.Checked ? 1 : 0;
            GetEncodingQuality(false);
            
            CheckMIDIFor2X(ProjectFile.MidiFile,false);
            if (is2XMIDI)
            {
                UniqueNumericID2x = GetNumericID();
                RefreshWindowTitle();
            }
            //Tools.RemovePSDrumsXNotes(ProjectFile.MidiFile);

            if (ProjectFile.GetSaveStatus() == SaveStatus.kUnsaved)
            {
                FileSaveMenuItem_Click(null, null);
            }
            ProjectFolder = Path.GetDirectoryName(ProjectFile.GetFilename()) + "\\";
            BuildSong();
        }

        private bool MidiIsClean()
        {
            if (bypassNemosMIDIValidator.Checked) return true;
            var MIDIpath = ProjectFile.MidiFile;
            var tempomarkers = 0;
            var vocalod = false;
            var drumod = 0;
            var proguitar = false;
            var proguitar22 = false;
            var probass = false;
            var probass22 = false;
            try
            {
                var songMidi = Tools.NemoLoadMIDI(MIDIpath);
                if (songMidi == null) return true;
                if (chkTempo.Checked && !wiiConversion.Checked)  //only bother checking if 'Check for tempo map' is checked, ignore for Wii conversions
                {
                    foreach (var marker in songMidi.Events[0].Where(tempo => tempo.CommandCode == MidiCommandCode.MetaEvent).Select(tempo => (MetaEvent)tempo).Where(marker => marker.MetaEventType == MetaEventType.SetTempo))
                    {
                        tempomarkers++;
                        if (tempomarkers >= 2) break;
                    }
                    if (tempomarkers < 2)
                    {
                        if (MessageBox.Show("I found " + tempomarkers + " tempo " + (tempomarkers == 1 ? "marker" : "markers") + "\nAre you sure this song has a fixed tempo?\n\nClick YES to continue\nClick NO to stop and fix the tempo map\n\nMake sure you to check 'Embed tempo map' in REAPER when exporting your MIDI",
                                "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }
                for (var i = 0; i < songMidi.Events.Tracks; i++)
                {
                    var trackname = songMidi.Events[i][0].ToString();
                    if (trackname.Contains("VOCALS"))
                    {
                        //check if there is at least one vocal overdrive marker
                        if ((from notes in songMidi.Events[i] where notes.CommandCode == MidiCommandCode.NoteOn select (NoteOnEvent)notes).Any(note => note.NoteNumber == 116))
                        {
                            vocalod = true;
                        }
                    }
                    else if (trackname.Contains("DRUMS"))
                    {
                        //check if there is at least one drums overdrive fill
                        foreach (var note in songMidi.Events[i].Where(notes => notes.CommandCode == MidiCommandCode.NoteOn).Select(notes => (NoteOnEvent)notes).Where(note => note.NoteNumber == 120))
                        {
                            drumod++;
                            if (drumod >= 2) break;
                        }
                    }
                    else if (trackname.Contains("REAL_GUITAR") && trackname.Contains("22"))
                    {
                        proguitar22 = true;
                    }
                    else if (trackname.Contains("REAL_GUITAR") && !trackname.Contains("22"))
                    {
                        proguitar = true;
                    }
                    else if (trackname.Contains("REAL_BASS") && trackname.Contains("22"))
                    {
                        probass22 = true;
                    }
                    else if (trackname.Contains("REAL_BASS") && !trackname.Contains("22"))
                    {
                        probass = true;
                    }
                    else if (trackname.Contains("EVENTS"))
                    {
                        if (!(from events in songMidi.Events[i]
                              where events.CommandCode == MidiCommandCode.MetaEvent
                              select (MetaEvent)events).Any(eve => eve.MetaEventType == MetaEventType.TextEvent &&
                                      eve.ToString().Contains("[music_start]") && eve.AbsoluteTime < (songMidi.DeltaTicksPerQuarterNote * 2))) continue;
                        MessageBox.Show("The [music_start] event in EVENTS track is too early in the track\nPlease move it to the appropriate place and try again\nThis causes MagmaCompiler to go crazy and give you nonsense errors",
                            mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (trackname.Contains("VENUE"))
                    {
                        var hasLightingIssue = (from events in songMidi.Events[i]
                                                where events.CommandCode == MidiCommandCode.MetaEvent
                                                select (MetaEvent)events).Any(eve => eve.MetaEventType == MetaEventType.TextEvent &&
                                                        eve.ToString().Contains("[lighting ()]"));
                        if (hasLightingIssue)
                        {
                            var answer = MessageBox.Show("Your MIDI file contains a [lighting ()] event in the VENUE track that will prevent" +
                                "Magma from autogenerating a venue for your song\nAre you sure you want to compile this MIDI?", Text,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (answer == DialogResult.No) return false;
                        }
                    }
                }
                if (drumod < 2 && CheckDrums.Checked)
                {
                    if (MessageBox.Show("No drums overdrive fills were detected!\nAre you sure you want to compile the song without them?",
                            "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return false;
                    }
                }
                if (!vocalod && CheckVocals.Checked)
                {
                    if (MessageBox.Show("No vocal overdrive markers were detected!\nAre you sure you want to compile the song without them?",
                            "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return false;
                    }
                }
                if (proguitar22 && !proguitar)
                {
                    if (MessageBox.Show("Found PART REAL_GUITAR_22 without a PART REAL_GUITAR\nAre you sure you want to compile the song without it?",
                            "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return false;
                    }
                }
                if (probass22 && !probass)
                {
                    if (MessageBox.Show("Found PART REAL_BASS_22 without a PART REAL_BASS\nAre you sure you want to compile the song without it?",
                            "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return false;
                    }
                }
            }
            catch (Exception){}
            return true; //let it compile and MagmaCompiler will complain later
        }
        
        private void BuildSong()
        {
            var str1 = "";
            if (!ProjectFile.HasFilename())
                str1 = str1 + Environment.NewLine + "You must save this project before building.";
            var str2 = str1 + GetFormErrors() + GetEmptyFields();
            if (TextBoxAlbumArt.Text.Length == 0)
            {
                TextBoxAlbumArt.Text = mDefaultAlbumArtPath;
            }
            if (!IsValidAlbumArt(ProjectFile.AlbumArt))
                str2 = str2 + Environment.NewLine + "Your album art is invalid.";
            if (CheckBoxFromAlbum.Checked && NumericTrackNumber.Value < new Decimal(1))
                str2 = str2 + Environment.NewLine + "Please set the track number for the album.";
            if (!CheckBoxLangEnglish.Checked && !CheckBoxLangFrench.Checked && (!CheckBoxLangItalian.Checked && !CheckBoxLangSpanish.Checked) && (!CheckBoxLangGerman.Checked && !CheckBoxLangJapanese.Checked))
                str2 = str2 + Environment.NewLine + "You must select at least one lyric language.";
            if (mSongLength - 30 < ProjectFile.PreviewStart / 1000)
                str2 = str2 + Environment.NewLine + "The song's preview start must be at least 30 seconds before the end of the song.";
            if (str2.Length > 0)
            {
                UGCDebug.ShowOKMsgBox(this, "Please fix the errors in the following fields before building: " + str2);
            }
            else
            {
                ProjectFile.DestinationFile = ProjectFile.DestinationFile.Trim();
                if (string.IsNullOrEmpty(ProjectFile.DestinationFile))
                {
                    if (UGCDebug.ShowYesNoCancelMsgBox(this, "Before you can build this project, you must first choose the output file name and path for the resulting local song pack.\n\nWould you like to do that now?") != DialogResult.Yes || !ChooseBuildToPath())
                        return;
                    while (ProjectFile.DestinationFile.Length > 250)
                    {
                        if (UGCDebug.ShowYesNoCancelMsgBox(this, "The path " + ProjectFile.DestinationFile + " is longer than the max path length of " + 250.ToString(CultureInfo.InvariantCulture) + ".  Before you can build this project, you must choose a shorter output file name and path.\n\nWould you like to do that now?") != DialogResult.Yes || !ChooseBuildToPath())
                            return;
                    }
                }
                var error = ErrorProviderCharCheck.GetError(TextBoxBuildDestination);
                if (error != "")
                {
                    UGCDebug.ShowOKMsgBox(this, "Please fix the following errors with the Build To field: " + Environment.NewLine + error);
                }
                else
                {
                    var magmaFileLock = new MagmaFileLock(ProjectFile.DestinationFile);
                    switch (magmaFileLock.GetStatus())
                    {
                        case MagmaFileLock.FileLockStatus.kMFL_LockAcquired:
                            new BuildForm(this).ShowDialog(this);
                            magmaFileLock.Dispose();
                            break;
                        case MagmaFileLock.FileLockStatus.kMFL_LockTimeout:
                            UGCDebug.ShowOKMsgBox(this, ProjectFile.DestinationFile + " is in-use by another process.");
                            break;
                        default:
                            UGCDebug.ShowOKMsgBox(this, "There was a problem obtaining a lock on " + (object)ProjectFile.DestinationFile + ".  [" + (string)(object)magmaFileLock.GetStatus() + "]");
                            break;
                    }
                }
            }
        }

        private string GetFormErrors()
        {
            var str = "";
            foreach (var control in mValidatedControls)
            {
                var textBox = (TextBox)control;
                var error = ErrorProviderCharCheck.GetError(control);
                if (textBox.Enabled && error != "")
                    str = str + (object)Environment.NewLine + (string)control.Tag + ": " + error;
            }
            return str;
        }

        private string GetEmptyFields()
        {
            return (from control in mValidatedControls let textBox = (TextBox) control where (textBox != TextBoxAlbumName || textBox.Enabled) && (textBox != TextBoxDryVocalsHarmony3 && textBox.Enabled && textBox.Text.Length == 0) select control).Aggregate("", (current, control) => string.Concat(new[]
                {
                    current, Environment.NewLine, control.Tag, " must not be empty."
                }));
        }

        private void ValidateTextBox(object sender)
        {
            if (starting & !Importing)
            {
                return;
            }

            var textBox = (TextBox)sender;
            var str = textBox.Text.Trim();

            if (str == "")
            {
                return;
            }

            var str1 = str.Select(ch => Convert.ToString(ch)).Where(str2 => !" ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#$%&'()*+,-./0123456789:;=>?@[]^_`{|}~¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõöøùúûüý!¡©®°ýÿŸÝ\"".Contains(str2)).Aggregate("", (current, str2) => current + str2);
            if (str1.Length > 0)
                ErrorProviderCharCheck.SetError(textBox, "Invalid characters: " + str1);
            else
            {
                ErrorProviderCharCheck.SetError(textBox, "");
            }

            var val = textBox.Text;
            var umlaut = false;

            const string funnyletters = "Ÿ©µ¿ÀÁÃÄÆÇÈÉËÌÍÏÑñÒÓÕÖÙÚÜÝàáäåæçèéëìíïòóõöùúüýÿ";

            for (var i = 0; i < val.Length; i++)
            {
                for (var b = 0; b < funnyletters.Length; b++)
                {
                    var funnyletter = funnyletters.Substring(b, 1);
                    if (!val.Substring(i, 1).Contains(funnyletter)) continue;
                    umlaut = true;
                    uTF8Menu.Checked = true;
                    aNSIMenu.Checked = false;
                }
            }

            if (umlaut || val.Contains("\""))
            {
                val = val.Replace("Ÿ", "Y");
                val = val.Replace("Ý", "Y");
                val = val.Replace("ÿ", "y");
                val = val.Replace("ý", "y");
                val = val.Replace("ä", "a");
                val = val.Replace("ü", "u");
                val = val.Replace("ë", "e");
                val = val.Replace("ï", "i");
                val = val.Replace("ö", "o");
                val = val.Replace("\"", "");
            }

            switch (textBox.Name)
            {
                case "TextBoxSongName":
                    ProjectFile.SongName = val;
                    break;
                case "TextBoxArtistName":
                    ProjectFile.ArtistName = val;
                    break;
                case "TextBoxAlbumName":
                    ProjectFile.AlbumName = val;
                    break;
            }
        }

        private void ValidateTrack(object sender, string path)
        {
            var textBox = (TextBox)sender;
            var trackInfo = new TrackInfo();
            trackInfo.InitFromFile(path, GetTrackNameFromControl(textBox));
            if (path.Length > 0) 
            {
                var str = "";
                if (!File.Exists(trackInfo.Filename))
                    str = "The file does not exist.";
                else if (trackInfo.SampleRate == 0)
                    str = str + "File does not seem to be a valid .wav.";
                else if (trackInfo.NumChannels == 1 && textBox.Name == "TextBoxDrumKit")
                {
                    str = str + "Drum Kit must always be stereo.";
                }
                else if (trackInfo.SampleRate != 44100 && trackInfo.SampleRate != 48000)
                {
                    if (textBox.Name != "TextBoxDryVocalsHarmony3" && textBox.Name != "TextBoxDryVocalsHarmony2" &&
                         textBox.Name != "TextBoxDryVocals")
                    {
                        str = str + "Track sample rate must be either 44.1kHz or 48kHz.";
                    }
                }
                else if (trackInfo.SampleRate != 16000)
                {
                    if (textBox.Name == "TextBoxDryVocalsHarmony3" || textBox.Name == "TextBoxDryVocalsHarmony2" ||
                         textBox.Name == "TextBoxDryVocals")
                    {
                        str = str + "Dry vocals tracks sample rate must be 16kHz.";
                    }
                }
                else if (trackInfo.BitsPerSample != 16 && trackInfo.BitsPerSample != 24)
                    str = str + "All audio tracks must be 16 bits or 24 bits per sample.";
                ErrorProviderCharCheck.SetError(textBox, str);
            }
            else
            {
                string strErr;
                ErrorProviderCharCheck.SetError(textBox,
                                                !PathUtl.IsPathClean(trackInfo.Filename, out strErr) ? strErr : "");
            }
        }

        public void UpdateVersion()
        {
            if (!string.IsNullOrEmpty(ProjectFile.DestinationFile) && ProjectFile.DestinationFile.Contains("v" + SongVersion))
            {
                ProjectFile.DestinationFile = ProjectFile.DestinationFile.Replace("v" + SongVersion, "v#");
            }
            if (increaseSongVersionAutomatically.Checked)
            {
                numVersion.Value = SongVersion + 1;
            }
            FileSaveMenuItem_Click(null, null);
        }

        private void ValidateMidiFile(string str)
        {
            string strErr;
            if (str.Length > 0 && !File.Exists(str))
            {
                ErrorProviderCharCheck.SetError(TextBoxMidiFile, "MIDI file does not exist!");
                ButtonExportMIDI.Enabled = false;
            }
            else if (!PathUtl.IsPathClean(str, out strErr))
            {
                ErrorProviderCharCheck.SetError(TextBoxMidiFile, strErr);
                ButtonExportMIDI.Enabled = false;
            }
            else
            {
                ErrorProviderCharCheck.SetError(TextBoxMidiFile, "");
                ButtonExportMIDI.Enabled = str.Length > 0;
            }
        }

        private static string GetTrackNameFromControl(Control c)
        {
            switch (c.Name)
            {
                case "TextBoxGuitar":
                    return "guitar";
                case "TextBoxBass":
                    return "bass";
                case "TextBoxKeys":
                    return "keys";
                case "TextBoxDrumKit":
                    return "drum_kit";
                case "TextBoxDrumKick":
                    return "drum_kick";
                case "TextBoxDrumSnare":
                    return "drum_snare";
                case "TextBoxVocals":
                    return "vocals";
                case "TextBoxBacking":
                    return "backing";
                case "TextBoxDryVocals":
                    return "dry_vocals";
                case "TextBoxDryVocalsHarmony2":
                    return "dry_vocals";
                case "TextBoxDryVocalsHarmony3":
                    return "dry_vocals";
            }
            return "";
        }

        private void DifficultyHover(object sender, EventArgs e)
        {
            var pictureBox = (PictureBox)sender;
            UpdateDifficultyDisplayNEMO(sender, Convert.ToInt32(pictureBox.Tag), true);
        }

        private void DifficultyLeave(object sender, EventArgs e)
        {
            var track = ((PictureBox)sender).Name.Replace("Picture", "");
            track = track.Substring(0, track.IndexOf("Difficulty", StringComparison.Ordinal));

            int difficulty;

            switch (track)
            {
                case "Drum":
                    difficulty = ProjectFile.RankDrum;
                    break;
                case "Bass":
                    difficulty = ProjectFile.RankBass;
                    break;
                case "ProBass":
                    difficulty = RankProBass;
                    break;
                case "Guitar":
                    difficulty = ProjectFile.RankGuitar;
                    break;
                case "ProGuitar":
                    difficulty = RankProGuitar;
                    break;
                case "Vocal":
                    difficulty = ProjectFile.RankVocals;
                    break;
                case "Keys":
                    difficulty = ProjectFile.RankKeys;
                    break;
                case "ProKeys":
                    difficulty = ProjectFile.RankProKeys;
                    break;
                case "Band":
                    difficulty = ProjectFile.RankBand;
                    break;
                default:
                    MessageBox.Show("I don't know what track you're trying to change the difficulty for, sorry\nTry again",
                        mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
            }
            
            UpdateDifficultyDisplayNEMO(sender, difficulty, true);
        }

        private bool GetDifficultyBoxes(object sender)
        {
            difficultyboxes = new PictureBox[7];

            try
            {
                var track = ((PictureBox)sender).Name.Replace("Picture", "");
                track = track.Substring(0, track.IndexOf("Difficulty", StringComparison.Ordinal));

                switch (track)
                {
                    case "Drum":
                        difficultyboxes[0] = PictureDrumDifficulty1;
                        difficultyboxes[1] = PictureDrumDifficulty2;
                        difficultyboxes[2] = PictureDrumDifficulty3;
                        difficultyboxes[3] = PictureDrumDifficulty4;
                        difficultyboxes[4] = PictureDrumDifficulty5;
                        difficultyboxes[5] = PictureDrumDifficulty6;
                        difficultyboxes[6] = PictureDrumDifficulty7;
                        break;
                    case "Bass":
                        difficultyboxes[0] = PictureBassDifficulty1;
                        difficultyboxes[1] = PictureBassDifficulty2;
                        difficultyboxes[2] = PictureBassDifficulty3;
                        difficultyboxes[3] = PictureBassDifficulty4;
                        difficultyboxes[4] = PictureBassDifficulty5;
                        difficultyboxes[5] = PictureBassDifficulty6;
                        difficultyboxes[6] = PictureBassDifficulty7;
                        break;
                    case "ProBass":
                        difficultyboxes[0] = PictureProBassDifficulty1;
                        difficultyboxes[1] = PictureProBassDifficulty2;
                        difficultyboxes[2] = PictureProBassDifficulty3;
                        difficultyboxes[3] = PictureProBassDifficulty4;
                        difficultyboxes[4] = PictureProBassDifficulty5;
                        difficultyboxes[5] = PictureProBassDifficulty6;
                        difficultyboxes[6] = PictureProBassDifficulty7;
                        break;
                    case "Guitar":
                        difficultyboxes[0] = PictureGuitarDifficulty1;
                        difficultyboxes[1] = PictureGuitarDifficulty2;
                        difficultyboxes[2] = PictureGuitarDifficulty3;
                        difficultyboxes[3] = PictureGuitarDifficulty4;
                        difficultyboxes[4] = PictureGuitarDifficulty5;
                        difficultyboxes[5] = PictureGuitarDifficulty6;
                        difficultyboxes[6] = PictureGuitarDifficulty7;
                        break;
                    case "ProGuitar":
                        difficultyboxes[0] = PictureProGuitarDifficulty1;
                        difficultyboxes[1] = PictureProGuitarDifficulty2;
                        difficultyboxes[2] = PictureProGuitarDifficulty3;
                        difficultyboxes[3] = PictureProGuitarDifficulty4;
                        difficultyboxes[4] = PictureProGuitarDifficulty5;
                        difficultyboxes[5] = PictureProGuitarDifficulty6;
                        difficultyboxes[6] = PictureProGuitarDifficulty7;
                        break;
                    case "Vocal":
                        difficultyboxes[0] = PictureVocalDifficulty1;
                        difficultyboxes[1] = PictureVocalDifficulty2;
                        difficultyboxes[2] = PictureVocalDifficulty3;
                        difficultyboxes[3] = PictureVocalDifficulty4;
                        difficultyboxes[4] = PictureVocalDifficulty5;
                        difficultyboxes[5] = PictureVocalDifficulty6;
                        difficultyboxes[6] = PictureVocalDifficulty7;
                        break;
                    case "Keys":
                        difficultyboxes[0] = PictureKeysDifficulty1;
                        difficultyboxes[1] = PictureKeysDifficulty2;
                        difficultyboxes[2] = PictureKeysDifficulty3;
                        difficultyboxes[3] = PictureKeysDifficulty4;
                        difficultyboxes[4] = PictureKeysDifficulty5;
                        difficultyboxes[5] = PictureKeysDifficulty6;
                        difficultyboxes[6] = PictureKeysDifficulty7;
                        break;
                    case "ProKeys":
                        difficultyboxes[0] = PictureProKeysDifficulty1;
                        difficultyboxes[1] = PictureProKeysDifficulty2;
                        difficultyboxes[2] = PictureProKeysDifficulty3;
                        difficultyboxes[3] = PictureProKeysDifficulty4;
                        difficultyboxes[4] = PictureProKeysDifficulty5;
                        difficultyboxes[5] = PictureProKeysDifficulty6;
                        difficultyboxes[6] = PictureProKeysDifficulty7;
                        break;
                    case "Band":
                        difficultyboxes[0] = PictureBandDifficulty1;
                        difficultyboxes[1] = PictureBandDifficulty2;
                        difficultyboxes[2] = PictureBandDifficulty3;
                        difficultyboxes[3] = PictureBandDifficulty4;
                        difficultyboxes[4] = PictureBandDifficulty5;
                        difficultyboxes[5] = PictureBandDifficulty6;
                        difficultyboxes[6] = PictureBandDifficulty7;
                        break;
                    default:
                        MessageBox.Show("I don't know what track you're trying to change the difficulty for, sorry\nTry again",
                            mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("I don't know what track you're trying to change the difficulty for, sorry\nTry again",
                             mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            return true;
        }

        private void UpdateDifficultyDisplayNEMO(object sender, int difficulty, bool enabled)
        {
            if (!GetDifficultyBoxes(sender)) return;

            //these two don't change look regardless of tier
            difficultyboxes[0].Image = enabled ? PipOff : PipDisabledOff;
            difficultyboxes[6].Image = enabled ? PipDevil : PipDevilOff;
            
            if (difficulty == 7)
            {
                for (var i = 1; i < 6; i++)
                {
                    difficultyboxes[i].Image = enabled ? PipDevil : PipDevilOff;
                }
            }
            else
            {
                for (var i = 1; i < 6; i++)
                {
                    if (i < difficulty)
                    {
                        difficultyboxes[i].Image = enabled ? PipOn : PipDisabledOn;
                    }
                    else
                    {
                        difficultyboxes[i].Image = enabled ? PipOff : PipDisabledOff;
                    }
                }
            }
        }
        
        private void ButtonClearAlbumArt_Click(object sender, EventArgs e)
        {
            TextBoxAlbumArt.Text = mDefaultAlbumArtPath;
        }

        private void PictureBoxAlbumArt_DragDrop(object sender, DragEventArgs e)
        {
            var file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            var extension = Path.GetExtension(file).ToLowerInvariant();
            var validExtensions = new List<string> {".jpg", ".png", ".bmp", ".tif", ".png_xbox"};
            if (validExtensions.Contains(extension))
            {
                TextBoxAlbumArt.Text = file;
            }
            else
            {
                MessageBox.Show("That's not a valid image format to drop here", mAppTitle, MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            Tools.CurrentFolder = Path.GetDirectoryName(file) + "\\";
       }

        private bool ChooseBuildToPath()
        {
            var dir = ProjDir != "" ? ProjDir : Tools.CurrentFolder;

            var sfd = new SaveFileDialog
                { OverwritePrompt = true,
                InitialDirectory = dir,
                Filter = "Rock Band Song File|*.*"};

            if (!string.IsNullOrEmpty(ProjectFile.DestinationFile))
            {
                sfd.FileName = Path.GetFileNameWithoutExtension(ProjectFile.DestinationFile);
                sfd.InitialDirectory = Path.GetDirectoryName(ProjectFile.DestinationFile) != "" ? Path.GetDirectoryName(ProjectFile.DestinationFile) : dir;
            }
            
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return false; 
            }

            TextBoxBuildDestination.Text = sfd.FileName;
            Tools.CurrentFolder = Path.GetDirectoryName(sfd.FileName) + "\\";
            AppendStuffToFilename();
            return true;
        }

        private void ButtonBuildTo_Click(object sender, EventArgs e)
        {
            ChooseBuildToPath();
        }

        private void ButtonExportMIDI_Click(object sender, EventArgs e)
        {
            if (ProjectFile.MidiFile == "")
            {
                MessageBox.Show("There doesn't seem to be a MIDI file attached to this project!\nCan't work without it, please try selecting your MIDI file again",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!File.Exists(ProjectFile.MidiFile))
            {
                MessageBox.Show("I can't find that MIDI file!\nCan't work without it, please try selecting your MIDI file again",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            FileSaveMenuItem_Click(null, null);
            
            if (ProjectFile.GetFilename() == "")
            {
                return;
            }
            
            if (!Tools.MidiIsClean(ProjectFile.MidiFile,CheckKeys.Checked))
            {
                var message = Tools.MIDI_ERROR_MESSAGE;
                var help = new HelpForm(this, mAppTitle, message);
                help.ShowDialog();
                return;
            }

            if (chkAutoKeys.Checked || chkKeysAnim.Checked || chkDrumsMix.Checked)
            {
                var error_message = Tools.MIDIAutoGen(ProjectFile.MidiFile, lblDrumMix.Text, chkKeysAnim.Checked,
                                              chkAutoKeys.Checked,
                                              chkDrumsMix.Checked);
                if (error_message.Contains("error"))
                {
                    if (MessageBox.Show("There was an error with the MIDI AutoGen\nMost likely you will not be able to compile your song\nDo you want to see the log?",
                        mAppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        var help = new HelpForm(this, "MIDI AutoGen Log", error_message);
                            help.ShowDialog();
                    }
                }
            }
            

            var str1 = Path.GetFullPath(ProjectFile.MidiFile);
            if (!Path.IsPathRooted(ProjectFile.MidiFile) && ProjectFile.HasFilename())
            {
                str1 = Path.GetDirectoryName(ProjectFile.GetFilename()) + "\\" + Path.GetFileName(ProjectFile.MidiFile);
            }
            else if (!Path.IsPathRooted(ProjectFile.MidiFile) && !ProjectFile.HasFilename())
            {
                UGCDebug.ShowOKMsgBox(this, "You must save your project file in order to export MIDI files from a relative path.");
                return;
            }
            var error = ErrorProviderCharCheck.GetError(TextBoxMidiFile);
            if (error != "")
            {
                UGCDebug.ShowOKMsgBox(this, "Please fix the following errors with the MIDI File field: " + Environment.NewLine + error);
            }
            else
            {
                var flag = false;
                exportedMIDI = "";
                do
                {
                    var sfd = new SaveFileDialog
                    {
                        Filter = "MIDI File (*.mid)|*.mid",
                        OverwritePrompt = true,
                        Title = "Select where to export new MIDI to",
                        InitialDirectory = Tools.CurrentFolder
                    };
                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;
                    exportedMIDI = Path.GetFullPath(sfd.FileName);
                    if (!exportedMIDI.ToLowerInvariant().EndsWith(".mid", StringComparison.CurrentCultureIgnoreCase))
                        exportedMIDI = exportedMIDI + ".mid";
                    if (Equals(exportedMIDI.ToLowerInvariant(), str1.ToLowerInvariant()))
                    {
                        if (UGCDebug.ShowOKCancelMsgBox(this, "The export path cannot be the same as the source MIDI file.\n\nPlease choose a new path.") != DialogResult.OK)
                            return;
                    }
                    else
                    {
                        string strErr;
                        if (!PathUtl.IsPathClean(exportedMIDI, out strErr))
                        {
                            if (UGCDebug.ShowOKCancelMsgBox(this, "There was a problem with the chosen path:\n" + strErr + "\n\nPlease choose another path.") != DialogResult.OK)
                                return;
                        }
                        else
                            flag = true;
                    }
                }
                while (!flag);

                originalMIDI = "";
                if (is2XMIDI && Tools.Separate2XMidi(ProjectFile.MidiFile))
                {
                    originalMIDI = ProjectFile.MidiFile;
                    ProjectFile.MidiFile = Tools.MIDI2X;
                    ProjectFile.WriteFile();
                }

                try
                {
                    var list = new List<string> { "-have_lock", "-export_midi", ProjectFile.GetFilename(), exportedMIDI };
                    var strArgs = list.Aggregate("", (current, str2) => current + " \"" + str2 + "\"");
                    mList = new ThreadSafeStringList();
                    mRunner = new ThreadRunner();
                    mRunner.SetStringList(mList);
                    mRunner.SetWorkingDirectory(Application.StartupPath);
                    mRunner.SetAppName(Application.StartupPath + "\\" + ProjectCompiler);
                    mRunner.AddAppArgs(strArgs);
                    mRunner.EnableMutexBreak();
                    ProjectFile.Unlock();
                    mRunner.Start();
                    mTimer = new Timer { Interval = 250 };
                    mTimer.Tick += MIDIExportTimerTick;
                    mTimer.Start();
                    mTransferProgressForm = new TransferProgressForm(this);
                    mTransferProgressForm.SetMIDIExportMode();
                    mTransferProgressForm.Show();
                }
                catch (Exception ex)
                {
                    UGCDebug.ShowOKMsgBox(this, ex.Message);
                    var strMsg = "An error occurred during export:";
                    while (mList.HasString())
                        strMsg = strMsg + Environment.NewLine + mList.GetString();
                    UGCDebug.ShowOKMsgBox(this, strMsg);
                }
            }
        }

        private void MergeMidis(string exported, string original)
        {
            var temp = Path.GetDirectoryName(exported) + "\\" + Path.GetFileNameWithoutExtension(exported) + "_temp.mid";

            try
            {
                Tools.MoveFile(exported, temp);

                var newMidi = new MidiFile(temp, false);
                var origMidi = new MidiFile(original, false);

                for (var i = 0; i < newMidi.Events.Tracks; i++)
                {
                    var trackname = Tools.GetMidiTrackName(newMidi.Events[i][0].ToString()).ToLowerInvariant();
                    if (!trackname.Contains("drums")) continue;
                    newMidi.Events[i].RemoveAt(0);
                    newMidi.Events[i].Add(new TextEvent("PART DRUMS_2X", MetaEventType.SequenceTrackName, 0));
                    break;
                }

                for (var i = 0; i < origMidi.Events.Tracks; i++)
                {
                    var trackname = Tools.GetMidiTrackName(origMidi.Events[i][0].ToString()).ToLowerInvariant();
                    if (!trackname.Contains("drums") || trackname.Contains("2x")) continue;
                    newMidi.Events.AddTrack(origMidi.Events[i]);
                    break;
                }

                MidiFile.Export(exported,newMidi.Events);
                Tools.DeleteFile(temp);
            }
            catch (Exception)
            {
                Tools.MoveFile(temp, exported);
            }
        }

        private void MIDIExportTimerTick(object sender, EventArgs e)
        {
            mRunner.Poll();
            if (mRunner.IsRunning)
                return;
            mTimer.Stop();
            try
            {
                ProjectFile.Lock();
            }
            catch
            {
                UGCDebug.ShowOKMsgBox(this, "Magma lost it's lock on your project file. Further changes could result in loss of data. It is highly recommended that you close this project and re-open it.");
            }
            mTransferProgressForm.Hide();
            if (mRunner.GetExitCode() == 0)
            {
                if (!string.IsNullOrEmpty(originalMIDI))
                {
                    ProjectFile.MidiFile = originalMIDI;
                    ProjectFile.WriteFile();
                    MergeMidis(exportedMIDI, Tools.MIDI1X);
                    Tools.DeleteFile(Tools.MIDI1X);
                    Tools.DeleteFile(Tools.MIDI2X);
                    Tools.MIDI1X = "";
                    Tools.MIDI2X = "";
                }
               MessageBox.Show("MIDI export complete",mAppTitle,MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                var str1 = "";
                var num = 0;
                while (mList.HasString())
                {
                    if (num >= 24)
                    {
                        str1 = str1 + "...[There is more output, but this message only shows the first " + 24.ToString(CultureInfo.InvariantCulture) + " lines]...";
                        break;
                    }
                    var str2 = mList.GetString();
                    if (str2.Length > 300)
                        str2 = str2.Substring(0, 297) + "...";
                    str1 = str1 + str2;
                    ++num;
                    if (mList.HasString())
                        str1 = str1 + Environment.NewLine;
                }
                if (str1 == "")
                    UGCDebug.ShowOKMsgBox(this, "MIDI export canceled or failed.");
                else
                    UGCDebug.ShowOKMsgBox(this, "MIDI export canceled or failed.  Output from the exporting process follows:\n\n" + str1);
            }
        }

        public void CancelMIDIExport()
        {
            mRunner.Poll();
            if (!mRunner.IsRunning)
                return;
            mRunner.SendMutexBreak();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isBusy)
            {
                MessageBox.Show("Please wait until the batch replacement process finishes", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
            
            if (ProjectFile.GetSaveStatus() == SaveStatus.kUnsaved)
            {
                if (MessageBox.Show("You have unsaved changes\nAre you sure you want to exit?", mAppTitle,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            StopBASS();
            SaveOptions();
            Dispose();
            Environment.Exit(0);
        }

        private void ChangeTab(object sender, EventArgs e)
        {
            StopBASS();
            ButtonInformationTab.ForeColor = mTabOffColor;
            ButtonAudioTab.ForeColor = mTabOffColor;
            ButtonGameDataTab.ForeColor = mTabOffColor;
            
            if (sender == ButtonInformationTab)
            {
                TopLevelTabs.SelectedIndex = 0;
                ButtonInformationTab.ForeColor = mTabOnColor;
            }
            else if (sender == ButtonAudioTab)
            {
                TopLevelTabs.SelectedIndex = 1;
                ButtonAudioTab.ForeColor = mTabOnColor;

                if (LabelKeysPan.Visible)
                {
                    NumericKeysPan.Visible = false;
                }
                if (LabelGuitarPan.Visible)
                {
                    NumericGuitarPan.Visible = false;
                }
                if (LabelBassPan.Visible)
                {
                    NumericBassPan.Visible = false;
                }
                if (LabelVocalPan.Visible)
                {
                    NumericVocalPan.Visible = false;
                }
                if (LabelBackingPan.Visible)
                {
                    NumericBackingPan.Visible = false;
                }
                if (LabelDrumSnarePan.Visible)
                {
                    NumericDrumSnarePan.Visible = false;
                }
                if (LabelDrumKitPan.Visible)
                {
                    NumericDrumKitPan.Visible = false;
                }
                if (LabelDrumKickPan.Visible)
                {
                    NumericDrumKickPan.Visible = false;
                }

                ZeroBacking.Visible = TextBoxBacking.Enabled && NumericBackingAttenuation.Value != 0;
                ZeroVocals.Visible = TextBoxVocals.Enabled && NumericVocalAttenuation.Value != 0;
                ZeroKeys.Visible = TextBoxKeys.Enabled && NumericKeysAttenuation.Value != 0;
                ZeroGuitar.Visible = TextBoxGuitar.Enabled && NumericGuitarAttenuation.Value != 0;
                ZeroBass.Visible = TextBoxBass.Enabled && NumericBassAttenuation.Value != 0;
                ZeroDrumSnare.Visible = TextBoxDrumSnare.Enabled && NumericDrumSnareAttenuation.Value != 0;
                ZeroDrumKick.Visible = TextBoxDrumKick.Enabled && NumericDrumKickAttenuation.Value != 0;
                ZeroDrumKit.Visible = TextBoxDrumKit.Enabled && NumericDrumKitAttenuation.Value != 0;
                ZeroCrowd.Visible = TextBoxCrowd.Enabled && numericCrowd.Value != 0;
            }
            else if (sender == ButtonGameDataTab)
            {
                TopLevelTabs.SelectedIndex = 2;
                ButtonGameDataTab.ForeColor = mTabOnColor;
            }
        }

        private void TabHover(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = mTabHoverColor;
        }

        private void TabEndHover(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var num = 0;
            if (sender == ButtonInformationTab)
            {
                num = 0;
            }
            else if (sender == ButtonAudioTab)
            {
                num = 1;
            }
            else if (sender == ButtonGameDataTab)
            {
                num = 2;
            }
            button.ForeColor = TopLevelTabs.SelectedIndex == num ? mTabOnColor : mTabOffColor;
        }

        private void SetTextBoxEnabledState(Control t, bool enabled)
        {
            t.Enabled = enabled;
            t.BackColor = enabled ? mTextBoxEnabledBackColor : mTextBoxDisabledBackColor;
        }
        
        private void HandleDragDrop(object sender, DragEventArgs e)
        {
            var fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            
            if (fileName.EndsWith(".rbproj", StringComparison.CurrentCultureIgnoreCase))
            {
                if (ProjectFile.HasUnsavedChanges())
                {
                    if (MessageBox.Show("You have unsaved changes in your current project\nOpening a new project will cause you to lose these changes\nAre you sure you want to do that?", mAppTitle,
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                OpenRbprojFile(fileName);
                ProjDir = Path.GetDirectoryName(fileName) + "\\";
                Tools.CurrentFolder = ProjDir;
            }
            else if (fileName.EndsWith(".skin", StringComparison.Ordinal))
            {
                LoadCustomSkin(fileName);
            }
            else if (fileName.EndsWith(".rok", StringComparison.CurrentCultureIgnoreCase) && Path.GetFileName(fileName) != "options.rok")
            {
                var project = fileName.Substring(0, fileName.Length - 2) + "rbproj";
                if (File.Exists(project))
                {
                    if (ProjectFile.HasUnsavedChanges())
                    {
                        if (MessageBox.Show("You have unsaved changes in your current project\nOpening a new project will cause you to lose these changes\nAre you sure you want to do that?", mAppTitle,
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    OpenRbprojFile(project);
                    ProjDir = Path.GetDirectoryName(fileName) + "\\";
                    Tools.CurrentFolder = ProjDir;
                }
                else
                {
                    MessageBox.Show("That's not a valid file to drop here", mAppTitle, MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            else switch (Path.GetFileName(fileName))
            {
                case "songs.dta":
                case "song.ini":
                    if (MessageBox.Show("Do you want to use the 'Import " + Path.GetFileName(fileName) + " file' function?", "Import " + Path.GetFileName(fileName) + "?",MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    if (ProjectFile.HasUnsavedChanges())
                    {
                        if (MessageBox.Show("You have unsaved changes in your current project\nOpening a new project will cause you to lose these changes\nAre you sure you want to do that?", mAppTitle,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    loadDTA(fileName, Path.GetFileName(fileName) == "song.ini");
                    break;
                default:
                    try
                    {
                        if (VariousFunctions.ReadFileType(fileName) == XboxFileType.STFS)
                        {
                            var temp = Application.StartupPath + "\\bin\\temp.dta";
                            if (!Parser.ExtractDTA(fileName, temp))
                            {
                                MessageBox.Show("That's not a valid CON or LIVE file", mAppTitle, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                                return;
                            }
                            if (!Parser.ReadDTA(temp) || !Parser.Songs.Any())
                            {
                                MessageBox.Show("There was an error reading the songs.dta file in that STFS package, I can't proceed without it",
                                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Tools.DeleteFile(temp);
                                return;
                            }
                            Tools.DeleteFile(temp);
                            if (Parser.Songs.Count > 1)
                            {
                                MessageBox.Show("That looks like a pack, can't import that, only single songs",mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            if (MessageBox.Show("That seems to be a valid Rock Band song file\nDo you want to use the 'Import CON file' function?",
                                "Import song?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                            {
                                return;
                            }
                            if (ProjectFile.HasUnsavedChanges())
                            {
                                if (MessageBox.Show("You have unsaved changes in your current project\nOpening a new project will cause you to lose these " +
                                                    "changes\nAre you sure you want to do that?",mAppTitle,MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    return;
                                }
                            }
                            importCON(fileName);
                            Tools.CurrentFolder = Path.GetDirectoryName(fileName) + "\\";
                        }
                        else
                        {
                            MessageBox.Show("That's not a valid file to drop here", mAppTitle, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error accessing that file\nThe error says:\n" + ex.Message, mAppTitle,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void chkTonicNote_CheckedChanged(object sender, EventArgs e)
        {
            ComboTonicNote.Enabled = chkTonicNote.Checked;
            if (!chkTonicNote.Checked)
            {
                chkTonality.Checked = false;
            }

            if (!chkTonicNote.Checked)
            {
                ComboTonicNote.SelectedIndex = -1;
                ErrorProviderCharCheck.SetError(ComboTonicNote, "");
            }
            else
            {
                if (ComboTonicNote.SelectedIndex == -1)
                {
                    ErrorProviderCharCheck.SetError(ComboTonicNote, "You must choose a vocal tonic note value");
                }
            }
            TonicNote = ComboTonicNote.SelectedIndex;
            DoShowToast("Vocal tonic note " + (chkTonicNote.Checked ? "enabled, please choose a value" : "disabled"));
            RefreshWindowTitle();
        }
        
        private void chkProBass_CheckedChanged(object sender, EventArgs e)
        {
            SetTextBoxEnabledState(BassTuning1, chkProBass.Checked);
            SetTextBoxEnabledState(BassTuning2, chkProBass.Checked);
            SetTextBoxEnabledState(BassTuning3, chkProBass.Checked);
            SetTextBoxEnabledState(BassTuning4, chkProBass.Checked);
            BassTuning1.Text = "0";
            BassTuning2.Text = "0";
            BassTuning3.Text = "0";
            BassTuning4.Text = "0";
            
            PictureProBassDifficulty1.Enabled = chkProBass.Checked;
            PictureProBassDifficulty2.Enabled = chkProBass.Checked;
            PictureProBassDifficulty3.Enabled = chkProBass.Checked;
            PictureProBassDifficulty4.Enabled = chkProBass.Checked;
            PictureProBassDifficulty5.Enabled = chkProBass.Checked;
            PictureProBassDifficulty6.Enabled = chkProBass.Checked;
            PictureProBassDifficulty7.Enabled = chkProBass.Checked;

            UpdateDifficultyDisplayNEMO(PictureProBassDifficulty1, RankProBass, chkProBass.Checked);
            scrollProBass.Enabled = chkProBass.Checked;
            DoShowToast("Pro Bass " + (chkProBass.Checked ? "enabled" : "disabled"));
            RefreshWindowTitle();
         }

        private void chkProGuitar_CheckedChanged(object sender, EventArgs e)
        {
            SetTextBoxEnabledState(GuitarTuning1, chkProGuitar.Checked);
            SetTextBoxEnabledState(GuitarTuning2, chkProGuitar.Checked);
            SetTextBoxEnabledState(GuitarTuning3, chkProGuitar.Checked);
            SetTextBoxEnabledState(GuitarTuning4, chkProGuitar.Checked);
            SetTextBoxEnabledState(GuitarTuning5, chkProGuitar.Checked);
            SetTextBoxEnabledState(GuitarTuning6, chkProGuitar.Checked);
            GuitarTuning1.Text = "0";
            GuitarTuning2.Text = "0";
            GuitarTuning3.Text = "0";
            GuitarTuning4.Text = "0";
            GuitarTuning5.Text = "0";
            GuitarTuning6.Text = "0";
            
            PictureProGuitarDifficulty1.Enabled = chkProGuitar.Checked;
            PictureProGuitarDifficulty2.Enabled = chkProGuitar.Checked;
            PictureProGuitarDifficulty3.Enabled = chkProGuitar.Checked;
            PictureProGuitarDifficulty4.Enabled = chkProGuitar.Checked;
            PictureProGuitarDifficulty5.Enabled = chkProGuitar.Checked;
            PictureProGuitarDifficulty6.Enabled = chkProGuitar.Checked;
            PictureProGuitarDifficulty7.Enabled = chkProGuitar.Checked;

            UpdateDifficultyDisplayNEMO(PictureProGuitarDifficulty1, RankProGuitar, chkProGuitar.Checked);
            scrollProGuitar.Enabled = chkProGuitar.Checked;
            DoShowToast("Pro Guitar " + (chkProGuitar.Checked ? "enabled" : "disabled"));
            RefreshWindowTitle();
        }

        private void ValidateTuning(object sender, EventArgs e)
        {
            var tuningbox = (TextBox) sender;
            
            try
            {
                //skip for some values
                if (tuningbox.Text == "-" || tuningbox.Text == "" || tuningbox.Text == "0.")
                {
                    return;
                }
                if (tuningbox.Text == ".")
                {
                    tuningbox.Text = "0."; //add leading zero
                    return;
                }
                //min value set to -9.9 and max value set to 9.9
                if (Convert.ToDecimal(tuningbox.Text) <= -10 || Convert.ToDecimal(tuningbox.Text) >= 10)
                {
                    if (!starting && !Importing)
                    {
                        MessageBox.Show("Ooops, you can only enter values from -9.9 to 9.9 for tuning.\nNo letters or funny symbols please.",
                            mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    tuningbox.Text = "0";
                    return;
                }

               //no letters allowed
                for (var i = 0; i < tuningbox.Text.Length; i++)
                {
                    if (!Char.IsLetter(tuningbox.Text, i)) continue;
                    if (!starting && !Importing)
                    {
                        MessageBox.Show("Ooops, you can only enter values from -9.9 to 9.9 for tuning.\nNo letters or funny symbols please.",
                            mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    tuningbox.Text = "0";
                    return;
                }
            }
            catch
            {
                if (!starting && !Importing)
                {
                    MessageBox.Show("Ooops, you can only enter values from -9.9 to 9.9 for tuning.\nNo letters or funny symbols please.",
                        mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                tuningbox.Text = "0";
            }

            GuitarTuning = "(real_guitar_tuning (" + GuitarTuning1.Text + " " + GuitarTuning2.Text + " " + GuitarTuning3.Text + " " + GuitarTuning4.Text + " " + GuitarTuning5.Text + " " + GuitarTuning6.Text + "))";
            BassTuning = "(real_bass_tuning (" + BassTuning1.Text + " " + BassTuning2.Text + " " + BassTuning3.Text + " " + BassTuning4.Text + "))";
            RefreshWindowTitle();
        }

        private void chkProKeys_CheckedChanged(object sender, EventArgs e)
        {
            //disabled per Linos' request - I don't recall why this was put in place to begin with - Nemo, 1/26/2025
            /*
            if (chkRhythmKeys.Checked && chkProKeys.Checked && !Importing)
            {
                if (MessageBox.Show("Hey there\n\nIt looks like you're trying to enable pro keys even though you told me this song had Rhythm on Keys!\n\nYou can't have both.\n\nClick Yes if you want to enable pro keys (and remove the Rhythm on Keys flag)\nClick No if you want to keep the Rhythm on Keys flag (pro keys will remain disabled)",
                        mAppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    chkRhythmKeys.Checked = false;
                }
                else
                {
                    chkProKeys.Checked = false;
                }
            }*/

            if (CheckKeys.Checked)
            {
                if (!chkProKeys.Checked)
                {
                    DoShowToast("Pro Keys disabled, won't show up in game");
                    chkAutoKeys.Enabled = true;
                    chkAutoKeys.Checked = true;
                    chkKeysAnim.Enabled = true;
                    chkKeysAnim.Checked = true;
                }
                else
                {
                    DoShowToast("Pro Keys enabled");
                    chkAutoKeys.Enabled = false;
                    chkAutoKeys.Checked = false;
                    chkKeysAnim.Enabled = false;
                    chkKeysAnim.Checked = false;
                }
            }
            
            PictureProKeysDifficulty1.Enabled = chkProKeys.Checked;
            PictureProKeysDifficulty2.Enabled = chkProKeys.Checked;
            PictureProKeysDifficulty3.Enabled = chkProKeys.Checked;
            PictureProKeysDifficulty4.Enabled = chkProKeys.Checked;
            PictureProKeysDifficulty5.Enabled = chkProKeys.Checked;
            PictureProKeysDifficulty6.Enabled = chkProKeys.Checked;
            PictureProKeysDifficulty7.Enabled = chkProKeys.Checked;

            UpdateDifficultyDisplayNEMO(PictureProKeysDifficulty1, ProjectFile.RankProKeys, chkProKeys.Checked);
            scrollProKeys.Enabled = chkProKeys.Checked;
            DoShowToast("Pro Keys " + (chkProKeys.Checked? "enabled!" : "disabled..."));
            RefreshWindowTitle();
        }
        
        private void GetTextEncoding()
        {
            if (aNSIMenu.Checked)
            {
                FileEncoding = System.Text.Encoding.GetEncoding(28591);
                Encoding = "latin1";
            }
            else
            {
                FileEncoding = System.Text.Encoding.UTF8;
                Encoding = "utf8";
            }
        }

       private void saveFix(string filename)
       {
           filename = Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + ".rok";
           Tools.DeleteFile(filename);
           GetTextEncoding();

           var sw = new StreamWriter(filename, false, FileEncoding);
           sw.WriteLine("//Created by " + mAppTitle + mAppVersion);
           sw.WriteLine("//DO NOT EDIT MANUALLY");
           sw.WriteLine("Song=" + Song);
           sw.WriteLine("Artist=" + Artist);
           sw.WriteLine("Album=" + Album);
           sw.WriteLine("CustomID=" + CustomID);
           sw.WriteLine("Version=" + SongVersion);
           sw.WriteLine("IsMaster=" + chkMaster.Checked);
           sw.WriteLine("EncodingQuality=" + EncodingQuality);
           if (CheckCrowd.Checked && TextBoxCrowd.Text!="")
           {
               sw.WriteLine("CrowdAudio=" + TextBoxCrowd.Text);
               sw.WriteLine("CrowdVol=" + numericCrowd.Value);
           }
           if (chkReRecord.Checked)
           {
               sw.WriteLine("ReRecordYear=" + numericReRecord.Value);
           }
           sw.WriteLine("2xBass=" + chk2xBass.Checked);
           sw.WriteLine("RhythmKeys=" + chkRhythmKeys.Checked);
           sw.WriteLine("RhythmBass=" + chkRhythmBass.Checked);
           sw.WriteLine("Karaoke=" + chkKaraoke.Checked);
           sw.WriteLine("Multitrack=" + chkMultitrack.Checked);
           sw.WriteLine("Convert=" + chkConvert.Checked);
           sw.WriteLine("ExpertOnly=" + chkXOnly.Checked);
           if (chkProBass.Checked)
           {
               // ugly kludge to get Pro to save properly
               if (ProBassDiff == 0) ProBassDiff = 1;
               sw.WriteLine("ProBassDiff=" + ProBassDiff);
               sw.WriteLine("ProBassTuning4=" + BassTuning);
           }
           if (chkProGuitar.Checked)
           {
               // ugly kludge to get Pro to save properly
               if (ProGuitarDiff == 0) ProGuitarDiff = 1;
               sw.WriteLine("ProGuitarDiff=" + ProGuitarDiff);
               sw.WriteLine("ProGuitarTuning=" + GuitarTuning);
           }
           sw.WriteLine("DisableProKeys=" + (CheckKeys.Checked && !chkProKeys.Checked));
           if (chkTonicNote.Checked && ComboTonicNote.SelectedIndex != -1)
           {
               sw.WriteLine("TonicNote=" + ComboTonicNote.SelectedIndex);
           }
           if (chkTonality.Checked && cboTonality.SelectedIndex != -1)
            {
                sw.WriteLine("Tonality=" + cboTonality.SelectedIndex);
            }
           sw.WriteLine("TuningCents=" + numericTuningCents.Value);
           sw.WriteLine("SongRating=" + (ComboRating.SelectedIndex + 1));
           sw.WriteLine("DrumKitSFX=" + ComboDrumSFX.SelectedIndex);
           sw.WriteLine("HopoTresholdIndex=" + ComboHopo.SelectedIndex);    
           sw.WriteLine("MuteVol=" + numericMuteVol.Value);
           sw.WriteLine("VocalMuteVol=" + numericVocalMute.Value);
           sw.WriteLine("SoloDrums=" + chkSoloDrums.Checked);
           sw.WriteLine("SoloGuitar=" + chkSoloGuitar.Checked);
           sw.WriteLine("SoloBass=" + chkSoloBass.Checked);
           sw.WriteLine("SoloKeys=" + chkSoloKeys.Checked);
           sw.WriteLine("SoloVocals=" + chkSoloVocals.Checked);
           if (SongPreview != 0)
           {
               sw.WriteLine("SongPreview=" + SongPreview);
                if (PreviewEnd == 0 || PreviewEnd <= SongPreview)
                {
                    PreviewEnd = SongPreview + 30000;
                }
               sw.WriteLine("SongPreviewEnd=" + PreviewEnd);
           }
           sw.WriteLine("CheckTempoMap=" + chkTempo.Checked);
           sw.WriteLine("WiiMode=" + wiiConversion.Checked);
           sw.WriteLine("DoDrumMixEvents=" + chkDrumsMix.Checked);
           DoDrumMixes = chkDrumsMix.Checked;
           sw.WriteLine("PackageDisplay=" + txtTitleDisplay.Text);
           sw.WriteLine("PackageDescription=" + txtDescription.Text);
           sw.WriteLine("SongAlbumArt=" + SongAlbumArt);
           sw.WriteLine("PackageThumb=" + PackageThumb);
           sw.WriteLine("EncodeANSI=" + aNSIMenu.Checked);
           sw.WriteLine("EncodeUTF8=" + uTF8Menu.Checked);
           sw.WriteLine("UseNumericID=" + useUniqueNumericSongID.Checked);
           sw.WriteLine("UniqueNumericID=" + UniqueNumericID);
           sw.WriteLine("UniqueNumericID2X=" + UniqueNumericID2x);
           sw.WriteLine("DIYStems=" + chkDIYStems.Checked);
            sw.WriteLine("drumsDifficulty=" + scrollDrums.Value);
            sw.WriteLine("bassDifficulty=" + scrollBass.Value);
            sw.WriteLine("proBassDifficulty=" + scrollProBass.Value);
            sw.WriteLine("guitarDifficulty=" + scrollGuitar.Value);
            sw.WriteLine("proGuitarDifficulty=" + scrollProGuitar.Value);
            sw.WriteLine("keysDifficulty=" + scrollKeys.Value);
            sw.WriteLine("proKeysDifficulty=" + scrollProKeys.Value);
            sw.WriteLine("vocalsDifficulty=" + scrollVocals.Value);
            sw.WriteLine("bandDifficulty=" + scrollBand.Value);
            sw.WriteLine("BandFailCueSFX=" + cboBandFail.SelectedIndex);
            sw.WriteLine("");
           sw.WriteLine("TO DO List Begin");

           for (var i = 0; i < 15; i++)
           {
               if (ToDoDescription[i] != "")
               {
                   sw.WriteLine("ToDo" + (i + 1) + "=" + ToDoDescription[i] + "," + ToDoImportant[i] + "," +
                                ToDoCompleted[i]);
               }
           }
           sw.WriteLine("TO DO List End");
           sw.Dispose();
       }

       private void readFix(string filename)
       {
           //READ THIS!
           //if you're inheriting this project, you should try to improve this section
           //most other parts were re-done to load files in a fixed format, but 
           //the C3 files exist in a huge variety of formats due to lack of vision on my part
           //and expecting a specific format will break compatibility with older versions
           //if you can figure it out in a better way than the mess below, awesome

            filename = Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + ".rok";
            var filenameC3 = filename.Replace(".rok", ".c3");
            var hasToDo = false;

            starting = true; //disable toast notifications while loading the file

            var fix = File.Exists(filename) ? filename : filenameC3;

           if (File.Exists(fix))
           {
               var sr = new StreamReader(fix, System.Text.Encoding.Default);
               while (!sr.EndOfStream)
               {
                   var line = sr.ReadLine();

                   if (line.Contains("IsMaster="))
                   {
                       chkMaster.Checked = line.Contains("1") || line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("EncodingQuality="))
                   {
                       cboEncodingQuality.SelectedIndex = Convert.ToInt16(Tools.GetConfigString(line)) - 1;
                       GetEncodingQuality();
                   }
                   else if (line.Contains("CrowdAudio="))
                   {
                       CrowdAudio = Tools.GetConfigString(line);

                       if (CrowdAudio != "")
                       {
                           CheckCrowd.Checked = true;
                           TextBoxCrowd.Text = CrowdAudio;
                       }
                   }
                   else if (line.Contains("CrowdVol="))
                   {
                       numericCrowd.Value = Convert.ToDecimal(Tools.GetConfigString(line));
                   }
                   else if (line.Contains("CheckTempoMap="))
                   {
                       chkTempo.Checked = line.Contains("1") || line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("WiiConvert=") || line.Contains("WiiMode="))
                   {
                       wiiConversion.Checked = line.Contains("1") || line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("DoDrumMixEvents="))
                   {
                       chkDrumsMix.Checked = line.Contains("1") || line.ToLowerInvariant().Contains("true");
                       DoDrumMixes = chkDrumsMix.Checked;
                   }
                   else if (line.Contains("PackageDisplay="))
                   {
                       txtTitleDisplay.Text = Tools.GetConfigString(line);
                   }
                   else if (line.Contains("PackageDescription="))
                   {
                       txtDescription.Text = Tools.GetConfigString(line);
                   }
                   else if (line.Contains("SongAlbumArt="))
                   {
                       SongAlbumArt = Tools.GetConfigString(line);
                   }
                   else if (line.Contains("PackageThumb="))
                   {
                       PackageThumb = Tools.GetConfigString(line);

                       if (PackageThumb == "rb3")
                       {
                           picThumb.Image = Resources.ContentImage;
                       }
                       else if (PackageThumb != "")
                       {
                           if (File.Exists(PackageThumb))
                           {
                               picThumb.Image = Tools.NemoLoadImage(PackageThumb);
                           }
                           else if (File.Exists(ProjDir + Path.GetFileName(PackageThumb)))
                           {
                               picThumb.Image = Tools.NemoLoadImage(ProjDir + Path.GetFileName(PackageThumb));
                           }
                       }
                   }
                   else if (line.Contains("SongRating=") && !line.Contains("-1"))
                   {
                       ComboRating.SelectedIndex = Convert.ToInt16(Tools.GetConfigString(line)) - 1;
                   }
                   else if (line.Contains("TonicNote=") && !line.Contains("-1"))
                   {
                        ComboTonicNote.SelectedIndex = Convert.ToInt16(Tools.GetConfigString(line));
                        chkTonicNote.Checked = true;
                        ComboTonicNote.Enabled = true;
                   }
                   else if (line.Contains("Tonality=") && !line.Contains("-1"))
                   {
                        cboTonality.SelectedIndex = Convert.ToInt16(Tools.GetConfigString(line));
                        chkTonality.Checked = true;
                        cboTonality.Enabled = true;
                   }
                   else if (line.Contains("RhythmBass="))
                   {
                       chkRhythmBass.Checked = line.Contains("1") || line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("RhythmKeys="))
                   {
                       chkRhythmKeys.Checked = line.Contains("1") || line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("2xBass="))
                   {
                       chk2xBass.Checked = line.Contains("1") || line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("Karaoke="))
                   {
                       chkKaraoke.Checked = line.Contains("1") || line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("Multitrack="))
                   {
                       chkMultitrack.Checked = line.Contains("1") || line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("DIYStems="))
                   {
                       chkDIYStems.Checked = line.Contains("1") || line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("Convert="))
                   {
                       chkConvert.Checked = line.Contains("1") || line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("DisableProKeys="))
                   {
                       chkProKeys.Checked = !(line.Contains("1") || line.ToLowerInvariant().Contains("true"));
                   }
                   else if (line.Contains("SoloDrums="))
                   {
                       chkSoloDrums.Checked = line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("SoloVocals="))
                   {
                       chkSoloVocals.Checked = line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("SoloGuitar="))
                   {
                       chkSoloGuitar.Checked = line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("SoloBass="))
                   {
                       chkSoloBass.Checked = line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("SoloKeys="))
                   {
                       chkSoloKeys.Checked = line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("ExpertOnly="))
                   {
                       chkXOnly.Checked = line.Contains("1") || line.ToLowerInvariant().Contains("true");
                   }
                   else if (line.Contains("EncodeANSI=1") || line.Contains("EncodeANSI=True"))
                   {
                       aNSIToolStripMenuItem_Click(null,null);
                   }
                   else if (line.Contains("EncodeUTF8=1") || line.Contains("EncodeUTF8=True"))
                   {
                       uTF8ToolStripMenuItem_Click(null,null);
                   }
                   else if (line.Contains("SongPreview="))
                   {
                       SongPreview = Convert.ToInt64(Tools.GetConfigString(line));
                       ProjectFile.PreviewStart = SongPreview > 570000 ? 570000 : (int)SongPreview;
                       UpdateSongPreview();
                   }
                   else if (line.Contains("SongPreviewEnd="))
                    {
                        PreviewEnd = Convert.ToInt64(Tools.GetConfigString(line));
                        UpdateSongPreview();
                    }
                   else if (line.Contains("Song="))
                   {
                       var song = Tools.GetConfigString(line);
                       if (!string.IsNullOrEmpty(song))
                       {
                           TextBoxSongName.Text = song;
                       }
                   }
                   else if (line.Contains("Artist="))
                   {
                       var artist = Tools.GetConfigString(line);
                       if (!string.IsNullOrEmpty(artist))
                       {
                           TextBoxArtistName.Text = artist;
                       }
                   }
                   else if (line.Contains("Album="))
                   {
                       var album = Tools.GetConfigString(line);
                       if (!string.IsNullOrEmpty(album))
                       {
                           TextBoxAlbumName.Text = album;
                       }
                   }
                   else if (line.Contains("CustomID="))
                   {
                       CustomID = Tools.GetConfigString(line);

                       if (CustomID != "")
                       {
                           useCustomID = true;
                           if (!useUniqueNumericSongID.Checked)
                           {
                               txtSongID.Text = CustomID;
                           }
                       }
                   }
                   else if (line.StartsWith("Version=", StringComparison.Ordinal))
                   {
                       try
                       {
                           numVersion.Value = Convert.ToInt16(Tools.GetConfigString(line));
                       }
                       catch (Exception)
                       {
                           numVersion.Value = 1;
                       }
                   }
                   else if (line.Contains("TuningCents="))
                   {
                       numericTuningCents.Value = Convert.ToInt16(Tools.GetConfigString(line));
                   }
                   else if (line.Contains("MuteVol=") && !line.Contains("VocalMuteVol"))
                   {
                       numericMuteVol.Value = Convert.ToInt16(Tools.GetConfigString(line));
                   }
                   else if (line.Contains("VocalMuteVol="))
                   {
                       numericVocalMute.Value = Convert.ToInt16(Tools.GetConfigString(line));
                   }
                   else if (line.Contains("ProBassDiff=") || line.Contains("ProBassTier="))
                   {
                       ProBassDiff = Convert.ToInt16(Tools.GetConfigString(line));
                       doProBassDiff(line);
                   }
                   else if (line.Contains("ProGuitarDiff=") || line.Contains("ProGuitarTier="))
                   {
                       ProGuitarDiff = Convert.ToInt16(Tools.GetConfigString(line));
                       doProGuitarDiff(line);
                   }
                   else if (line.Contains("BandFailCueSFX="))
                    {
                        cboBandFail.SelectedIndex = Convert.ToInt16(Tools.GetConfigString(line));
                    }
                   else if (line.Contains("ProGuitarTuning="))
                   {
                       const int index = 37; // 'ProGuitarTuning=(real_guitar_tuning ('
                       line = line.Substring(index, line.Length - index);
                       GuitarTuning1.Text = line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal));
                       line = line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1,
                                             line.Length - line.IndexOf(" ", StringComparison.Ordinal) - 1);
                       GuitarTuning2.Text = line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal));
                       line = line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1,
                                             line.Length - line.IndexOf(" ", StringComparison.Ordinal) - 1);
                       GuitarTuning3.Text = line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal));
                       line = line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1,
                                             line.Length - line.IndexOf(" ", StringComparison.Ordinal) - 1);
                       GuitarTuning4.Text = line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal));
                       line = line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1,
                                             line.Length - line.IndexOf(" ", StringComparison.Ordinal) - 1);
                       GuitarTuning5.Text = line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal));
                       line = line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1,
                                             line.Length - line.IndexOf(" ", StringComparison.Ordinal) - 1);
                       GuitarTuning6.Text = line.Substring(0, line.IndexOf(")", StringComparison.Ordinal));
                   }
                   else if (line.Contains("ProBassTuning4="))
                   {
                       const int index = 34; // 'ProBassTuning4=(real_bass_tuning ('
                       line = line.Substring(index, line.Length - index);
                       BassTuning1.Text = line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal));
                       line = line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1,
                                             line.Length - line.IndexOf(" ", StringComparison.Ordinal) - 1);
                       BassTuning2.Text = line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal));
                       line = line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1,
                                             line.Length - line.IndexOf(" ", StringComparison.Ordinal) - 1);
                       BassTuning3.Text = line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal));
                       line = line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1,
                                             line.Length - line.IndexOf(" ", StringComparison.Ordinal) - 1);
                       BassTuning4.Text = line.Substring(0, line.IndexOf(")", StringComparison.Ordinal));
                   }
                   else if (line.Contains("ProBassTuning6=")) //for old projects with invalid 6 string bass tuning
                   {
                       const int index = 34; // 'ProBassTuning6=(real_bass_tuning ('
                       line = line.Substring(index, line.Length - index);
                       BassTuning1.Text = line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal));
                       line = line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1,
                                             line.Length - line.IndexOf(" ", StringComparison.Ordinal) - 1);
                       BassTuning2.Text = line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal));
                       line = line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1,
                                             line.Length - line.IndexOf(" ", StringComparison.Ordinal) - 1);
                       BassTuning3.Text = line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal));
                       line = line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1,
                                             line.Length - line.IndexOf(" ", StringComparison.Ordinal) - 1);
                       BassTuning4.Text = line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal));
                       line = line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1,
                                             line.Length - line.IndexOf(" ", StringComparison.Ordinal) - 1);
                   }
                   else if (line.Contains("ReRecordYear="))
                   {
                       chkReRecord.Checked = true;
                       numericReRecord.Value = Convert.ToInt16(Tools.GetConfigString(line));
                   }
                   else if (line.Contains("DrumKitSFX=") && !line.Contains("-1"))
                   {
                       ComboDrumSFX.SelectedIndex = Convert.ToInt16(Tools.GetConfigString(line));
                   }
                   else if (line.Contains("HopoTresholdIndex=") && !line.Contains("-1"))
                   {
                       ComboHopo.SelectedIndex = Convert.ToInt16(Tools.GetConfigString(line));
                   }
                   else if (line.Contains("UseNumericID=True") && !useUniqueNumericSongID.Checked)
                   {
                       useUniqueNumericSongID.Checked = true;
                       useUniqueNumericSongID_Click(null, null);
                   }
                   else if (line.Contains("UniqueNumericID="))
                   {
                       UniqueNumericID = Tools.GetConfigString(line);
                       if (useUniqueNumericSongID.Checked)
                       {
                           txtSongID.Text = UniqueNumericID;
                       }
                   }
                   else if (line.Contains("UniqueNumericID2x="))
                   {
                       UniqueNumericID2x = Tools.GetConfigString(line);
                   }
                   else if (line.Contains("drumsDifficulty="))
                    {
                        scrollDrums.Value = Convert.ToInt16(Tools.GetConfigString(line));
                    }
                    else if (line.Contains("bassDifficulty="))
                    {
                        scrollBass.Value = Convert.ToInt16(Tools.GetConfigString(line));
                    }
                    else if (line.Contains("proBassDifficulty="))
                    {
                        scrollProBass.Value = Convert.ToInt16(Tools.GetConfigString(line));
                    }
                    else if (line.Contains("guitarDifficulty="))
                    {
                        scrollGuitar.Value = Convert.ToInt16(Tools.GetConfigString(line));
                    }
                    else if (line.Contains("proGuitarDifficulty="))
                    {
                        scrollProGuitar.Value = Convert.ToInt16(Tools.GetConfigString(line));
                    }
                    else if (line.Contains("keysDifficulty="))
                    {
                        scrollKeys.Value = Convert.ToInt16(Tools.GetConfigString(line));
                    }
                    else if (line.Contains("proKeysDifficulty="))
                    {
                        scrollProKeys.Value = Convert.ToInt16(Tools.GetConfigString(line));
                    }
                    else if (line.Contains("vocalsDifficulty="))
                    {
                        scrollVocals.Value = Convert.ToInt16(Tools.GetConfigString(line));
                    }
                    else if (line.Contains("bandDifficulty="))
                    {
                        scrollBand.Value = Convert.ToInt16(Tools.GetConfigString(line));
                    }

                    if (!line.Contains("TO DO List Begin")) continue;
                   hasToDo = true;
                   ClearToDoList();
                   do
                   {
                       line = sr.ReadLine();
                       GetToDoFromFile(line, false);

                   } while (!line.Contains("TO DO List End"));
               }
               sr.Dispose();
           }

           doUseNumericID(useUniqueNumericSongID.Checked);

           if (!hasToDo && File.Exists(Application.StartupPath + "\\default_template.todo"))
           {
               LoadTemplate(Application.StartupPath + "\\default_template.todo");
           }

           TextBoxAlbumArt.Text = string.IsNullOrEmpty(SongAlbumArt) ? (string.IsNullOrEmpty(ProjectFile.AlbumArt) ? mDefaultAlbumArtPath : ProjectFile.AlbumArt) : SongAlbumArt;
           AppendStuffToFilename();

           RefreshWindowTitle(true);
           starting = false;
       }
       
        private void ClearToDoList()
        {
            var item = ActiveItem;
            for (var i = 0; i < 15; i++)
            {
                ActiveItem = i;
                getActiveTextBox().Text = "Click to add new item...";
                ToDoDescription[i] = "";
                ToDoImportant[i] = false;
                ToDoCompleted[i] = false;
                UpdateToDoStuff();
            }

            ActiveItem = item;
        }

        private void GetToDoFromFile(string input_line, bool is_template)
        {
            try
            {
                var line = input_line.Replace("ToDo", "");
                var index = line.IndexOf("=", StringComparison.Ordinal);
                ActiveItem = Convert.ToInt16(line.Substring(0, index)) - 1;
                line = line.Substring(index + 1, line.Length - index - 1);
                ToDoDescription[ActiveItem] = line.Substring(0, line.IndexOf(",", StringComparison.Ordinal));
                line = line.Replace(ToDoDescription[ActiveItem] + ",", "");
                
                if (is_template)
                {
                    ToDoImportant[ActiveItem] = Convert.ToBoolean(line);
                    ToDoCompleted[ActiveItem] = false;
                }
                else
                {
                    index = line.IndexOf(",", StringComparison.Ordinal);
                    ToDoImportant[ActiveItem] = Convert.ToBoolean(line.Substring(0, index));
                    ToDoCompleted[ActiveItem] = Convert.ToBoolean(line.Substring(index + 1, line.Length - index - 1));
                }

                if (ToDoDescription[ActiveItem] != "")
                {
                    getActiveTextBox().Text = ToDoDescription[ActiveItem];
                }
                UpdateToDoStuff();
            }
            catch (Exception)
            {
               //
            }
        }

       private void PictureProDifficulty(object sender, MouseEventArgs e)
       {
           if (e.Button != MouseButtons.Left) return;
           switch (((Control) sender).Name)
           {
               case "PictureProBassDifficulty1":
                   ProBassDiff = 1;
                   break;
               case "PictureProBassDifficulty2":
                   ProBassDiff = 150;
                   break;
               case "PictureProBassDifficulty3":
                   ProBassDiff = 208;
                   break;
               case "PictureProBassDifficulty4":
                   ProBassDiff = 267;
                   break;
               case "PictureProBassDifficulty5":
                   ProBassDiff = 325;
                   break;
               case "PictureProBassDifficulty6":
                   ProBassDiff = 384;
                   break;
               case "PictureProBassDifficulty7":
                   ProBassDiff = 442;
                   break;
               case "PictureProGuitarDifficulty1":
                   ProGuitarDiff = 1;
                   break;
               case "PictureProGuitarDifficulty2":
                   ProGuitarDiff = 150;
                   break;
               case "PictureProGuitarDifficulty3":
                   ProGuitarDiff = 208;
                   break;
               case "PictureProGuitarDifficulty4":
                   ProGuitarDiff = 267;
                   break;
               case "PictureProGuitarDifficulty5":
                   ProGuitarDiff = 325;
                   break;
               case "PictureProGuitarDifficulty6":
                   ProGuitarDiff = 384;
                   break;
               case "PictureProGuitarDifficulty7":
                   ProGuitarDiff = 442;
                   break;
           }
           
           Difficulty_Click(sender, null);
       }

       private void chkMaster_CheckedChanged(object sender, EventArgs e)
       {
           IsMaster = chkMaster.Checked ? 1 : 0;
           DoShowToast("Song marked as " + (chkMaster.Checked ? "master" : "cover"));
           RefreshWindowTitle();
       }

       private void ComboRating_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (ComboRating.SelectedIndex != -1)
           {
               SongRating = ComboRating.SelectedIndex + 1;
               DoShowToast("Song rating changed to " + ComboRating.Items[ComboRating.SelectedIndex]);
           }
           RefreshWindowTitle();
       }

       private void TextBoxBuildDestination_TextChanged(object sender, EventArgs e)
       {
           if (TextBoxBuildDestination.Text == "")
           {
               ProjectFile.DestinationFile = "";
               if (!useUniqueNumericSongID.Checked)
               {
                   txtSongID.Text = "";
               }
               SongID = "";
               return;
           }

           TextBoxBuildDestination.RightToLeft = TextBoxBuildDestination.Text.Length > 132 ? RightToLeft.Yes : RightToLeft.No;

           var file = Path.GetFileName(TextBoxBuildDestination.Text);
           if (!string.IsNullOrEmpty(file) && file.Length > 26 && !useUniqueNumericSongID.Checked)
           {
               MessageBox.Show("That filename is longer than recommended and may cause problems\nI shortened it to the recommended max of 26 characters", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               txtSongID.Text = CleanOutputFile(txtSongID.Text);
               return;
           }
           
           if (ProjDir != "" && TextBoxBuildDestination.Text != "" && Path.GetPathRoot(TextBoxBuildDestination.Text) != "")
           {
               var oldroot = Path.GetPathRoot(TextBoxBuildDestination.Text);
               var newroot = Path.GetPathRoot(ProjDir);
               if (oldroot != newroot)
               {
                   TextBoxBuildDestination.Text = TextBoxBuildDestination.Text.Replace(oldroot, newroot);
                   return;
               }
           }

           var folder = Path.GetDirectoryName(TextBoxBuildDestination.Text);
           var folderexists = folder != null && Directory.Exists(folder);
           //work around issues when cut/pasting project folder to another directory
           if (Path.GetDirectoryName(TextBoxBuildDestination.Text) != "" && !folderexists && !Importing)
           {
               TextBoxBuildDestination.Text = ProjDir + Path.GetFileName(TextBoxBuildDestination.Text);
               return;
           }

           if (ProjDir != "" && TextBoxBuildDestination.Text.Contains(ProjDir))
           {
               TextBoxBuildDestination.Text = TextBoxBuildDestination.Text.Replace(ProjDir, "");
               return;
           }

           string str;

           if (Path.GetDirectoryName(TextBoxBuildDestination.Text) == "")
           {
               str = ProjDir + TextBoxBuildDestination.Text;
               str = str.Replace("////", "//");
               str = str.Replace("///", "//");
           }
           else
           {
               str = TextBoxBuildDestination.Text;
           }
           ProjectFile.DestinationFile = str.EndsWith(".rba", StringComparison.Ordinal) ? str : str + ".rba";
           
           if (!string.IsNullOrEmpty(str))
           {
               SongID = Path.GetFileNameWithoutExtension(str);
               if (SongID != null && SongID.Length > 25)
               {
                   SongID = SongID.Substring(0, 25);
               }
               if (!useUniqueNumericSongID.Checked)
               {
                   txtSongID.Text = useCustomID && !string.IsNullOrEmpty(CustomID) ? CustomID : SongID;
               }
           }
           RefreshWindowTitle();
       }
        
        private void AppendStuffToFilename()
        {
            var text = TextBoxBuildDestination.Text.Replace(".rba", "");
            const string version = "v#";
            if (appendSongVersionToFileName.Checked && !text.Contains(version))
            {
                if (text.EndsWith("_rb3con", StringComparison.Ordinal))
                {
                    text = text.Replace("_rb3con", version + "_rb3con");
                }
                else
                {
                    text = text + version;
                }
            }
            else if (!appendSongVersionToFileName.Checked && text.Contains(version))
            {
                text = text.Replace(version, "");
            }
            if (appendrb3conToFile.Checked && !text.EndsWith("_rb3con", StringComparison.Ordinal))
            {
                text = text + "_rb3con";
            }
            else if (!appendrb3conToFile.Checked && text.Contains("_rb3con"))
            {
                text = text.Replace("_rb3con", "");
            }
            TextBoxBuildDestination.Text = text;
        }

       private void ComboTonicNote_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (ComboTonicNote.SelectedIndex != -1)
           {
               TonicNote = ComboTonicNote.SelectedIndex;
               ErrorProviderCharCheck.SetError(ComboTonicNote, "");
               DoShowToast("Vocal tonic note changed to " + ComboTonicNote.Items[ComboTonicNote.SelectedIndex]);
           }

           RefreshWindowTitle();
       }

       private void TextBoxSongName_TextChanged(object sender, EventArgs e)
       {
           RefreshWindowTitle();

           btnDispDLC.Enabled = TextBoxSongName.Text != "";
           btnDispDefault.Enabled = TextBoxSongName.Text != "" && TextBoxArtistName.Text != "";

           if (TextBoxSongName.Text == "")
           {
               Song = "";
               ProjectFile.SongName = "";
               updateTitleDisplay();
               return;
           }

           for (var i = 1; i < 10; i++)
           {
               var message = "";

               switch (i)
               {
                   case 1:
                       message = "rhythm version";
                       break;
                   case 2:
                       message = "rhytm version";
                       break;
                   case 3:
                       message = "rythm version";
                       break;
                   case 4:
                       message = "rytm version";
                       break;
                   case 5:
                       message = "2x bass pedal";
                       break;
                   case 6:
                       message = "2x bass";
                       break;
                   case 7:
                       message = "2x pedal";
                       break;
               }

               if (!TextBoxSongName.Text.ToLowerInvariant().Contains(message)) continue;
               CheckSongName(message, i);
               break;
           }
           
           Song = TextBoxSongName.Text.Trim();
           ValidateTextBox(TextBoxSongName);
           updateTitleDisplay();
       }

        public void RefreshWindowTitle(bool saved = false)
        {
            if (starting || refreshing) return;
            ProjectFile.SetSaveStatus(saved ? SaveStatus.kSaved :  SaveStatus.kUnsaved);

            var str = mAppTitle + (wiiConversion.Checked ? " (Wii Mode)" : "");
            if (ProjectFile.HasFilename())
            {
                var fileName = Path.GetFileName(ProjectFile.GetFilename());
                if (!string.IsNullOrEmpty(fileName))
                {
                    try
                    {
                        var name = Path.GetFileNameWithoutExtension(ProjectFile.GetFilename());
                        if (name != null)
                        {
                            str = str + " - " + name;
                        }
                    }
                    catch
                    { }
                }
            }
            if (ProjectFile.GetSaveStatus() == SaveStatus.kUnsaved ||
                ProjectFile.GetSaveStatus() == SaveStatus.kUnsavedNoFilename)
            {
                str = "* " + str + " *";
            }
            Text = str.Replace(".rba", "");
        }
        
        private void CheckSongName(string message, int type)
        {
            if (message == "") return;
            if (!starting && !Importing && !refreshing)
            {
                MessageBox.Show("Hey there\nIt looks like you're trying to mark this song as '" + message +
                    "'\n\nDid you notice those neat little icons down there?\nInstead of typing '" + message +
                    "' up here, mark the song by clicking on the appropriate icon below\n\nThis way we can ensure we all use the same naming convention AND " +
                    "Nautilus and " + mAppTitle + " can keep track of the features each song has\n\nDon't worry, I'll make sure in game your song shows the " +
                    "correct information\n\nFor now, I removed '" + message + "' from your song name and marked the song accordingly",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
            switch (type)
            {
                case 4:
                case 3:
                case 2:
                case 1:
                    if (!chkRhythmKeys.Checked && !chkRhythmBass.Checked)
                    {
                        chkRhythmKeys.Checked = true;
                    }
                    break;
                case 7:
                case 6:
                case 5:
                    if (!chk2xBass.Checked)
                    {
                        chk2xBass.Checked = true;
                    }
                    break;
            }

            var name = TextBoxSongName.Text.ToLowerInvariant().Replace(message, "").Replace("()","");
            name = name.Trim();
            name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
            TextBoxSongName.Text = name;
            TextBoxSongName.SelectionStart = TextBoxSongName.Text.Length;
        }

       private void TextBoxArtistName_TextChanged(object sender, EventArgs e)
       {
           RefreshWindowTitle();

           btnDispDefault.Enabled = TextBoxSongName.Text != "" && TextBoxArtistName.Text != "";

           if (TextBoxArtistName.Text == "" )
           {
               Artist = "";
               ProjectFile.ArtistName = "";
               updateTitleDisplay();
               return;
           }

           Artist = TextBoxArtistName.Text.Trim();
           ValidateTextBox(TextBoxArtistName);
           updateTitleDisplay();
       }

       private void ComboDrumSFX_SelectedIndexChanged(object sender, EventArgs e)
       {
           DrumSFX = ComboDrumSFX.SelectedIndex;
           DoShowToast("Drum Kit SFX changed to " + ComboDrumSFX.Items[ComboDrumSFX.SelectedIndex]);

           RefreshWindowTitle();
       }

       private void ComboHopo_SelectedIndexChanged(object sender, EventArgs e)
       {
           HopoValue = ComboHopo.SelectedIndex;
           DoShowToast("HOPO threshold changed to " + ComboHopo.Items[ComboHopo.SelectedIndex]);

           RefreshWindowTitle();
       }

       private void chkReRecord_CheckedChanged(object sender, EventArgs e)
       {  
           numericReRecord.Enabled = chkReRecord.Checked;
           yearReRecord = (int)numericReRecord.Value;
           DoShowToast("Song was marked as a re-record");

           RefreshWindowTitle();
       }

       private void numericReRecord_ValueChanged(object sender, EventArgs e)
       {
           yearReRecord = (int)numericReRecord.Value;
           RefreshWindowTitle();
       }

       private void TextBoxAuthor_TextChanged(object sender, EventArgs e)
       {    
           picAuthor.Visible = (TextBoxAuthor.Text != ""); 
           SongAuthor = TextBoxAuthor.Text.Trim();
           ValidateTextBox(TextBoxAuthor);
           ProjectFile.Author = TextBoxAuthor.Text.Trim();           
           RefreshWindowTitle();
       }

       private void keepSongsdtaFileToolStripMenuItem_Click(object sender, EventArgs e)
       {
           DoShowToast("DTA file will " + (keepSongsdtaFile.Checked ? "not" : "") + " be deleted");
       }

       private void doNotDeleteExtractedFilesToolStripMenuItem_Click(object sender, EventArgs e)
       {
           DoShowToast("Extracted files folder will " + (doNotDeleteExtractedFiles.Checked ? "not" : "") + " be deleted");
       }

       private void chkRhythmKeys_CheckedChanged(object sender, EventArgs e)
       {
           if (chkRhythmKeys.Checked)
           {
               chkRhythmBass.Checked = false;
               chkProKeys.Checked = false;
               DoShowToast("Song marked Rhythm on Keys");
           }
           updateTitleDisplay();
           RefreshWindowTitle();
       }

       private void chkRhythmBass_CheckedChanged(object sender, EventArgs e)
       {
           if (chkRhythmBass.Checked)
           {
               chkRhythmKeys.Checked = false;
               DoShowToast("Song marked Rhythm on Bass");
           }
           updateTitleDisplay();
           RefreshWindowTitle();
       }
        
       private void chkKaraoke_CheckedChanged(object sender, EventArgs e)
       {
            if (chkKaraoke.Checked)
            {
                chkMultitrack.Checked = false;
                chkDIYStems.Checked = false;
                chkPartial.Checked = false;
                DoShowToast("Song marked as Karaoke");
            }
           RefreshWindowTitle();
       }

       private void chkMultitrack_CheckedChanged(object sender, EventArgs e)
       {
            if (chkMultitrack.Checked)
            {
                chkKaraoke.Checked = false;
                chkDIYStems.Checked = false;
                chkPartial.Checked = false;
                DoShowToast("Song marked as Multitrack");
            }
            RefreshWindowTitle();
       }

       private void chkConvert_CheckedChanged(object sender, EventArgs e)
       {
           if (chkConvert.Checked)
           {
               DoShowToast("Song marked as Convert");
           }
           RefreshWindowTitle();
       }

       private void chk2xBass_CheckedChanged(object sender, EventArgs e)
       {
           if (chk2xBass.Checked)
           {
               DoShowToast("Song marked as 2x Bass Pedal");
           }
           updateTitleDisplay();
           RefreshWindowTitle();
       }

       private void numericTuningCents_ValueChanged(object sender, EventArgs e)
       {
           TuningCents = (int)numericTuningCents.Value;
           RefreshWindowTitle();
       }

       public void SaveOptions()
       {
           var sw = new StreamWriter(config_file, false, System.Text.Encoding.Default);
            try
            {
                sw.WriteLine("CreatedWith=" + mAppTitle + mAppVersion);
                sw.WriteLine("DeleteRBAFiles=" + deleteRBAFiles.Checked);
                sw.WriteLine("UseSilenceTracks=" + useSilenceTracksByDefault.Checked);
                sw.WriteLine("Use44kHz=" + use441KHzToolStripMenuItem.Checked);
                sw.WriteLine("Use48kHz=" + use48KHzToolStripMenuItem.Checked);
                sw.WriteLine("AnalyzeMIDIFile=" + analyzeMIDIFileForContents.Checked);
                sw.WriteLine("OverwriteAuthor=" + overrideProjectFileAuthor.Checked);
                sw.WriteLine("DefaultAuthor=" + DefaultAuthor);
                sw.WriteLine("AppendVersionToID=" + appendSongVersionToSongID.Checked);
                sw.WriteLine("AppendVersionToFile=" + appendSongVersionToFileName.Checked);
                sw.WriteLine("AutoIncreaseVersion=" + increaseSongVersionAutomatically.Checked);
                sw.WriteLine("AppendRB3Con=" + appendrb3conToFile.Checked);
                sw.WriteLine("KeepDTA=" + keepSongsdtaFile.Checked);
                sw.WriteLine("KeepExtracted=" + doNotDeleteExtractedFiles.Checked);
                sw.WriteLine("ShowToDoList=" + openToDoListByDefault.Checked);
                sw.WriteLine("ShowToast=" + showToast.Checked);
                sw.WriteLine("UseFireSkin=" + burnBabyBurn.Checked);
                sw.WriteLine("UseColorfulSkin=" + cIsForColorfulTool.Checked);
                sw.WriteLine("UseDarkSkin=" + oldDarkTool.Checked);
                sw.WriteLine("OverrideArt=" + overrideAlbumArt.Checked);
                sw.WriteLine("OverrideMIDI=" + overrideMIDIFile.Checked);
                sw.WriteLine("OverrideMogg=" + overrideAudioFile.Checked);
                sw.WriteLine("OverrideMilo=" + overrideMiloFile.Checked);
                var texture_size = 512;
                if (x256.Checked)
                {
                    texture_size = 256;
                }
                else if (x1024.Checked)
                {
                    texture_size = 1024;
                }
                else if (x2048.Checked)
                {
                    texture_size = 2048;
                }
                sw.WriteLine("AlbumArtSize=" + texture_size);
                sw.WriteLine("NeverCheckTempo=" + neverCheckForTempoMap.Checked);
                sw.WriteLine("BypassNemoValidator=" + bypassNemosMIDIValidator.Checked);
                sw.WriteLine("NautilusPath=" + nautilusPath);
                sw.WriteLine("AudacityPath=" + AudacityPath);
                sw.WriteLine("ProjectCompiler=" + ProjectCompiler);
                sw.WriteLine("WiiMode=" + wiiConversion.Checked);
                sw.WriteLine("DoLIVE=" + signSongAsLIVE.Checked);
                sw.WriteLine("Use44kHz24=" + use441KHz24bitToolStripMenuItem.Checked);
                sw.WriteLine("Use48kHz24=" + use48KHz24bitToolStripMenuItem.Checked);
                sw.WriteLine("UseCustomSkin=" + customSkinTool.Checked);
                sw.WriteLine("CustomSkinPath=" + SKIN_PATH);
                sw.WriteLine("UseNumericSongID=" + useUniqueNumericSongID.Checked);
                sw.WriteLine("SaveAuthorToDTA=" + chkAuthorDTA.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error saving the configuration file\nThis is what happened:\n\n" + ex.Message, mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            sw.Dispose();

           //make backups
           
           var backup_config = data_folder + Path.GetFileName(config_file);
           try
           {
               Tools.DeleteFile(backup_config);
               File.Copy(config_file, backup_config);
           }
           catch (Exception)
           {}
        }        

        private void LoadOptions()
        {
            var texture_size = 512;

            var backup_config = data_folder + Path.GetFileName(config_file);
            if (!File.Exists(config_file) && File.Exists(backup_config))
            {
                if (MessageBox.Show("It looks like you don't have a configuration file in the /bin folder, but I found a backup. Do you want me to " +
                                    "restore that?\n\n[RECOMMENDED]\nClick Yes to restore and keep your existing configuration\n\n" +
                                    "[NOT RECOMMENDED]\nClick No to ignore and start with the default configuration", mAppTitle, MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Copy(backup_config, config_file);
                }
            }

            if (File.Exists(config_file))
            {
                var sr = new StreamReader(config_file, System.Text.Encoding.Default);
                try
                {
                    while (sr.Peek() >= 0)
                    {
                        var version = Tools.GetConfigString(sr.ReadLine());
                        if (!version.ToLowerInvariant().Contains("magma: rok on edition v4"))
                        {
                            sr.Close();
                            Tools.DeleteFile(config_file);
                            break;
                        }
                        deleteRBAFiles.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        useSilenceTracksByDefault.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        use441KHzToolStripMenuItem.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        use48KHzToolStripMenuItem.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        analyzeMIDIFileForContents.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        overrideProjectFileAuthor.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        DefaultAuthor = Tools.GetConfigString(sr.ReadLine());
                        appendSongVersionToSongID.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        appendSongVersionToFileName.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        increaseSongVersionAutomatically.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        appendrb3conToFile.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        keepSongsdtaFile.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        doNotDeleteExtractedFiles.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        openToDoListByDefault.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        showToast.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        burnBabyBurn.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        cIsForColorfulTool.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        oldDarkTool.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        overrideAlbumArt.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        overrideMIDIFile.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        overrideAudioFile.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        overrideMiloFile.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        texture_size = Convert.ToInt16(Tools.GetConfigString(sr.ReadLine()));   
                        neverCheckForTempoMap.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        bypassNemosMIDIValidator.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        nautilusPath = Tools.GetConfigString(sr.ReadLine());
                        AudacityPath = Tools.GetConfigString(sr.ReadLine());
                        ProjectCompiler = Tools.GetConfigString(sr.ReadLine());
                        wiiConversion.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");

                        if (!version.Contains("v3.1") && !version.Contains("v3.2") && !version.Contains("v3.3") && !version.Contains("v4.0")) break;
                        signSongAsLIVE.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        use441KHz24bitToolStripMenuItem.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        use48KHz24bitToolStripMenuItem.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        customSkinTool.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        SKIN_PATH = Tools.GetConfigString(sr.ReadLine());
                        if (!version.Contains("v3.2") && !version.Contains("v3.3") && !version.Contains("v4.0")) break;
                        useUniqueNumericSongID.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                        if (!version.Contains("v4.0")) break;
                        chkAuthorDTA.Checked = sr.ReadLine().ToLowerInvariant().Contains("true");
                    }
                }
                catch (Exception)
                {
                    Tools.DeleteFile(config_file);
                    MessageBox.Show("There was an error loading your configuration file\nA new one will be created when you close me down",
                        mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                sr.Dispose();

                if (openToDoListByDefault.Checked)
                {
                    Width = WIDTH_EXPANDED;
                }
                if (burnBabyBurn.Checked)
                {
                    TabPageInformation.BackgroundImage = Resources.bg_onfire2;
                    TabPageAudio.BackgroundImage = Resources.bg_onfire2;
                    TabPageGameData.BackgroundImage = Resources.bg_onfire2;
                    PictureBoxMagmaLogoTop.Image = Resources.magma_onfire;
                    PictureBoxMagmaLogoTop.BackgroundImage = null;
                    PanelHeader.BackgroundImage = null;
                    todoPic.Image = Resources.todo_onfire;
                    ButtonClearAlbumArt.BackgroundImage = Resources.btn_small_lava;
                    ButtonAlbumArt.BackgroundImage = Resources.btn_small_lava;
                    ButtonBuildTo.BackgroundImage = Resources.btn_small_lava;
                    ButtonBuildSong.BackgroundImage = Resources.btn_large_lava;
                    ButtonDrumKit.BackgroundImage = Resources.btn_small_lava;
                    ButtonDrumSnare.BackgroundImage = Resources.btn_small_lava;
                    ButtonDrumKick.BackgroundImage = Resources.btn_small_lava;
                    ButtonBass.BackgroundImage = Resources.btn_small_lava;
                    ButtonGuitar.BackgroundImage = Resources.btn_small_lava;
                    ButtonKeys.BackgroundImage = Resources.btn_small_lava;
                    ButtonVocals.BackgroundImage = Resources.btn_small_lava;
                    ButtonDryVocals.BackgroundImage = Resources.btn_small_lava;
                    ButtonDryVocalsHarmony2.BackgroundImage = Resources.btn_small_lava;
                    ButtonDryVocalsHarmony3.BackgroundImage = Resources.btn_small_lava;
                    ButtonBacking.BackgroundImage = Resources.btn_small_lava;
                    btnCrowd.BackgroundImage = Resources.btn_small_lava;
                    btnPlay.BackgroundImage = Resources.btn_small_lava;
                    ButtonBrowseForMIDI.BackgroundImage = Resources.btn_small_lava;
                    btnID.BackgroundImage = Resources.btn_small_lava;
                    ButtonExportMIDI.BackgroundImage = Resources.btn_large_lava;
                    btnTester.BackgroundImage = Resources.btn_large_lava;
                    btnCleaner.BackgroundImage = Resources.btn_large_lava;
                    btnDescDefault.BackgroundImage = Resources.btn_large_lava;
                    btnDispDefault.BackgroundImage = Resources.btn_large_lava;
                    btnDispDLC.BackgroundImage = Resources.btn_large_lava;
                    ZeroBacking.BackgroundImage = Resources.btn_small_lava;
                    ZeroGuitar.BackgroundImage = Resources.btn_small_lava;
                    ZeroBass.BackgroundImage = Resources.btn_small_lava;
                    ZeroKeys.BackgroundImage = Resources.btn_small_lava;
                    ZeroVocals.BackgroundImage = Resources.btn_small_lava;
                    ZeroDrumKick.BackgroundImage = Resources.btn_small_lava;
                    ZeroDrumKit.BackgroundImage = Resources.btn_small_lava;
                    ZeroDrumSnare.BackgroundImage = Resources.btn_small_lava;
                    ZeroCrowd.BackgroundImage = Resources.btn_small_lava;
                    ActiveSkin = "fire";
                }
                else if (cIsForColorfulTool.Checked)
                {
                    useColorfulSkin();
                    ActiveSkin = "colorful";
                }
                else if (customSkinTool.Checked && File.Exists(SKIN_PATH))
                {
                    LoadCustomSkin(SKIN_PATH);
                }
            }

            switch (texture_size)
            {
                case 256:
                    x256ToolStripMenuItem_Click(null, null);
                    break;
                case 1024:
                    x1024ToolStripMenuItem_Click(null, null);
                    break;
                case 2048:
                    x2048ToolStripMenuItem_Click(null, null);
                    break;
                default:
                    x512ToolStripMenuItem_Click(null, null);
                    break;
            }

            use441KHzToolStripMenuItem.Enabled = useSilenceTracksByDefault.Checked;
            use48KHzToolStripMenuItem.Enabled = useSilenceTracksByDefault.Checked;
            use441KHz24bitToolStripMenuItem.Enabled = useSilenceTracksByDefault.Checked;
            use48KHz24bitToolStripMenuItem.Enabled = useSilenceTracksByDefault.Checked;
        }

        private void TextBoxMidiFile_TextChanged(object sender, EventArgs e)
        {
           btnCleaner.Enabled = TextBoxMidiFile.Text != "";
           try
           {
              if (ProjDir != "" && TextBoxMidiFile.Text.Contains(ProjDir))
              {
                  TextBoxMidiFile.Text = TextBoxMidiFile.Text.Replace(ProjDir, "");
                  return;
              }

              TextBoxMidiFile.RightToLeft = TextBoxMidiFile.Text.Length > 46 ? RightToLeft.Yes : RightToLeft.No;
              //work around issues when cut/pasting project folder to another directory
              if (!File.Exists(TextBoxMidiFile.Text) && TextBoxMidiFile.Text != "" && !Importing && !File.Exists(ProjDir + TextBoxMidiFile.Text))
              {
                  if (File.Exists(ProjDir + Path.GetFileName(TextBoxMidiFile.Text)))
                  {
                      TextBoxMidiFile.Text = Path.GetFileName(TextBoxMidiFile.Text);
                      return;
                  }

                  try
                  {
                      var folder = Path.GetDirectoryName(TextBoxMidiFile.Text);
                      if (folder != null)
                      {
                          var parent = Directory.GetParent(folder);
                          var subfolder = TextBoxMidiFile.Text.Replace(parent + "\\", "");
                          if (File.Exists(ProjDir + subfolder))
                          {
                              TextBoxMidiFile.Text = subfolder;
                              return;
                          }
                      }
                  }
                  catch (Exception)
                  {
                      //
                  }
              }

              GetMIDI(TextBoxMidiFile.Text);
              RefreshWindowTitle();
          }
          catch (Exception ex)
          {
              MessageBox.Show(
                    "There was an error accessing that MIDI file\n\nThe error says:\n" + ex.Message + "\n\nTry again",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
       }

        private void DoShowToast(string message)
        {
            if (starting || refreshing || Importing || !showToast.Checked) return;
            var toast = new frmToast(message, MousePosition);
            toast.Show();
        }
        
        private void uTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uTF8Menu.Checked = true;
            aNSIMenu.Checked = false;
            DoShowToast("UTF-8 text encoding enabled");
        }

        private void aNSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aNSIMenu.Checked = true;
            uTF8Menu.Checked = false;
            DoShowToast("ANSI text encoding enabled");
        }

        private void TextBoxAlbumName_TextChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();

            if (TextBoxAlbumName.Text == "")
            {
                Album = "";
                ProjectFile.AlbumName = "";
                return;
            }

            Album = TextBoxAlbumName.Text.Trim();
            ValidateTextBox(TextBoxAlbumName);
        }

        private void appendrb3conToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoShowToast("Will " + (appendrb3conToFile.Checked ? "" : "not") + " append _rb3con to file name");

            if (TextBoxBuildDestination.Text == "") return;
            AppendStuffToFilename();
        }

        private void deleteOldRBAFileFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoShowToast("Will " + (deleteRBAFiles.Checked ? "" : "not") + " delete the old RBA file first");
        }

        private void txtSongID_TextChanged(object sender, EventArgs e)
        {
            if (!txtSongID.Enabled) return;

            if (txtSongID.Text == SongID)
            {
                useCustomID = false;
            }
            else if (txtSongID.Text == "")
            {
                if (TextBoxBuildDestination.Text != "" && !useUniqueNumericSongID.Checked)
                {
                    txtSongID.Text = SongID;
                    useCustomID = false;
                }
            }
            else if (!useUniqueNumericSongID.Checked)
            {
                CustomID = txtSongID.Text.Length > 25 ? txtSongID.Text.Substring(0, 25) : txtSongID.Text;
                txtSongID.Text = CustomID;
                useCustomID = true;
            }
            
            var version = "v" + numVersion.Value;
            if (!useUniqueNumericSongID.Checked)
            {
                txtSongID.Text = txtSongID.Text.Replace("_rb3con", "").Replace(version, "");
            }
            RefreshWindowTitle();
        }

        private void doDrumMix()
        {
            if (TextBoxDrumKick.Text == "" && TextBoxDrumSnare.Text == "" && TextBoxDrumKit.Text == "")
            {
                lblDrumMix.Visible = false;
                return;
            }
            
            var unsupported = false;
            var drum_kit = ProjectFile.GetTrack("drum_kit");
            var drum_kick = ProjectFile.GetTrack("drum_kick");
            var drum_snare = ProjectFile.GetTrack("drum_snare");
            
            if (!drum_kit.Enabled || drum_kit.NumChannels != 2)
            {
                //kit must always be enabled and be stereo
                unsupported = true;
            }
            else if (!drum_kick.Enabled && !drum_snare.Enabled)
            {
                //drums0: One stereo stream for the entire Kit
                lblDrumMix.Text = DrumMix + "0]";
            }
            else if (drum_kick.Enabled && drum_kick.NumChannels == 1 &&
                     drum_snare.Enabled && drum_snare.NumChannels == 1)
            {
                //drums1: mono Kick, mono Snare, stereo Kit
                lblDrumMix.Text = DrumMix + "1]";
            }
            else if (drum_kick.Enabled && drum_kick.NumChannels == 1 && drum_snare.Enabled &&
                     drum_snare.NumChannels == 2)
            {
                //drums2: mono Kick, stereo Snare, stereo Kit
                lblDrumMix.Text = DrumMix + "2]";
            }
            else if (drum_kick.Enabled && drum_kick.NumChannels == 2 && drum_snare.Enabled &&
                     drum_snare.NumChannels == 2)
            {
                //drums3: stereo Kick, stereo Snare, stereo Kit
                lblDrumMix.Text = DrumMix + "3]";
            }
            else if (drum_kick.Enabled && drum_kick.NumChannels == 1 && !drum_snare.Enabled)
            {
                //drums4: mono Kick, stereo Kit
                lblDrumMix.Text = DrumMix + "4]"; 
            }
            else
            {
                unsupported = true;
            }
            
            lblDrumMix.Visible = true;
            if (unsupported)
            {
                lblDrumMix.Text = "Unsupported";
                lblDrumMix.Cursor = Cursors.No;
                ToolTip.SetToolTip(lblDrumMix, "I don't think this combination is supported in the game. I don't have a drum mix to show you");
            }
            else
            {
                lblDrumMix.Cursor = Cursors.Hand;
                ToolTip.SetToolTip(lblDrumMix, "This is the recommended drum mix based on your audio selection. Click to copy to your clipboard");
            }
        }
       
        private void CheckCrowd_CheckedChanged(object sender, EventArgs e)
        {
            if (wiiConversion.Checked && !WiiWarning && CheckCrowd.Checked)
            {
                MessageBox.Show("You're currently using Wii Mode.\nDue to the Wii's limited memory, Crowd Audio is disabled.",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                WiiWarning = true;
                CheckCrowd.Checked = false;
                return;
            }

            WiiWarning = false;
            SetTextBoxEnabledState(TextBoxCrowd, CheckCrowd.Checked);
            if (!CheckCrowd.Checked)
            {
                CrowdAudio = "";
            }
            numericCrowd.Value = CrowdVol;
        }

        private void EncodingQualityUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            GetEncodingQuality();
            RefreshWindowTitle();
        }

        private void GetEncodingQuality(bool ShowWiiMessage = true)
        {
            var qual = cboEncodingQuality.SelectedIndex;
            if (wiiConversion.Checked && !WiiWarning && ShowWiiMessage && qual != 1 && qual != 2 && qual != 3)
            {
                MessageBox.Show("You're currently using Wii Mode.\nDue to the Wii's limited memory, you are restricted to using\nAudio Quality 3 " +
                                "or lower.",mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                WiiWarning = true;
                cboEncodingQuality.SelectedIndex = 2; // "3 (default)";
                return;
            }

            WiiWarning = false;
            EncodingQuality = cboEncodingQuality.SelectedIndex + 1;  

            if (ComboDrums.SelectedIndex > 0 && EncodingQuality > 3)
            {
                MessageBox.Show("You have selected a drum mix requiring multiple audio stems.\nAudio Quality 3 has been automatically selected" +
                                "\ndue to known issues with playback on the PS3.", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEncodingQuality.SelectedIndex = 2;// "3 (default)";
                EncodingQuality = 3;
            }
        }

        private void btnCrowd_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(TextBoxCrowd);
        }

        private void TextCrowd_TextChanged(object sender, EventArgs e)
        {
            if (ProjDir != "" && TextBoxCrowd.Text.Contains(ProjDir))
            {
                TextBoxCrowd.Text = TextBoxCrowd.Text.Replace(ProjDir, "");
                return;
            }
            
            //work around issues when cut/pasting project folder to another directory
            if (TextBoxCrowd.Text != "" && !File.Exists(TextBoxCrowd.Text) && !Importing && !File.Exists(ProjDir + TextBoxCrowd.Text) && !File.Exists(Application.StartupPath + "\\" + TextBoxCrowd.Text))
            {
                if (File.Exists(ProjDir + Path.GetFileName(TextBoxCrowd.Text)))
                {
                    TextBoxCrowd.Text = Path.GetFileName(TextBoxCrowd.Text);
                    return;
                }

                try
                {
                    var folder = Path.GetDirectoryName(TextBoxCrowd.Text);
                    if (folder != null)
                    {
                        var parent = Directory.GetParent(folder);
                        var subfolder = TextBoxCrowd.Text.Replace(parent + "\\", "");
                        if (File.Exists(ProjDir + subfolder))
                        {
                            TextBoxCrowd.Text = subfolder;
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    //
                }
            }

            string str;

            if (File.Exists(ProjDir + TextBoxCrowd.Text))
            {
                str = ProjDir + TextBoxCrowd.Text;
            }
            else if (File.Exists(TextBoxCrowd.Text))
            {
                str = TextBoxCrowd.Text;
            }
            else
            {
                return;
            }
            
            if (TextBoxCrowd.Text == "")
            {
                ErrorProviderCharCheck.SetError(TextBoxCrowd, "");
                CrowdAudio = "";
            }
            else
            {
                if (File.Exists(str))
                {
                    var crowdinfo = new Wrapper.WaveInfo();
                    Wrapper.GetWaveInfo(str, crowdinfo);

                    if (crowdinfo.mNumChannels == 2 && (crowdinfo.mBitsPerSample == 16 || crowdinfo.mBitsPerSample == 24) &&
                        (crowdinfo.mSampleRate == 48000 || crowdinfo.mSampleRate == 44100))
                    {
                        CrowdSampleRate = crowdinfo.mSampleRate;
                        numericCrowd.Visible = true;
                        LabelCrowdPan.Visible = true;

                        RefreshWindowTitle();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Adding the crowd backing track is tricky!\nTo make sure we do it right, we're restricting you to 2 channel, 16 bit/24 bit WAV files with a sample rate of either 41,000Hz or 48,000Hz\nTry again",
                            mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        TextBoxCrowd.Text = "";
                    }
                }
                else
                {
                    ErrorProviderCharCheck.SetError(TextBoxCrowd, "That is not a valid path! Can't find that audio stem.");
                }
                CrowdAudio = str;
                numericCrowd.Value = CrowdVol;
            }
        }

        private void lblDrumMix_Click(object sender, EventArgs e)
        {
            if (lblDrumMix.Cursor==Cursors.No)
            {
                return;
            }

            Clipboard.SetText(lblDrumMix.Text);
            DoShowToast("Drum mix copied to clipboard, just paste in REAPER now");
        }
        
        private void chkXOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (chkXOnly.Checked)
            {
                chkCAT.Checked = false;
                DoShowToast("Song marked as Expert Only");
            }
            RefreshWindowTitle();
        }
        
        private void appendSongVersionToFileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoShowToast("Will " + (appendSongVersionToFileName.Checked ? "" : "not") + " append version to file name");

            if (TextBoxBuildDestination.Text == "") return;
            AppendStuffToFilename();
        }

        private void appendSongVersionToSongIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoShowToast("Will " + (appendSongVersionToSongID.Checked ? "" : "not") + " append version to song ID");
        }

        private void ZeroDrumKit_Click(object sender, EventArgs e)
        {
            NumericDrumKitAttenuation.Value = 0;
        }

        private void ZeroDrumSnare_Click(object sender, EventArgs e)
        {
            NumericDrumSnareAttenuation.Value = 0;
        }

        private void ZeroDrumKick_Click(object sender, EventArgs e)
        {
            NumericDrumKickAttenuation.Value = 0;
        }

        private void ZeroBass_Click(object sender, EventArgs e)
        {
            NumericBassAttenuation.Value = 0;
        }

        private void ZeroGuitar_Click(object sender, EventArgs e)
        {
            NumericGuitarAttenuation.Value = 0;
        }

        private void ZeroKeys_Click(object sender, EventArgs e)
        {
            NumericKeysAttenuation.Value = 0;
        }

        private void ZeroVocals_Click(object sender, EventArgs e)
        {
            NumericVocalAttenuation.Value = 0;
        }

        private void ZeroBacking_Click(object sender, EventArgs e)
        {
            NumericBackingAttenuation.Value = 0;
        }

        private void TextBoxDrumKit_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxDrumKit.Text == "")
            {
                ErrorProviderCharCheck.SetError(TextBoxDrumKit,"");
                NumericDrumKitAttenuation.Visible = false;
                NumericDrumKitPan.Visible = false;
                LabelDrumKitPan.Visible = false;
            }
            GetAudioFile((TextBox)sender);
            doDrumMix();
        }

        private void TextBoxDrumSnare_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxDrumSnare.Text == "")
            {
                ErrorProviderCharCheck.SetError(TextBoxDrumSnare, "");
                NumericDrumSnareAttenuation.Visible = false;
                NumericDrumSnarePan.Visible = false;
                LabelDrumSnarePan.Visible = false;
            }
            GetAudioFile((TextBox)sender);
            doDrumMix();
        }

        private void TextBoxDrumKick_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxDrumKick.Text == "")
            {
                ErrorProviderCharCheck.SetError(TextBoxDrumKick, "");
                NumericDrumKickAttenuation.Visible = false;
                NumericDrumKickPan.Visible = false;
                LabelDrumKickPan.Visible = false;
            }
            GetAudioFile((TextBox)sender);
            doDrumMix();
        }

        private void TextBoxBass_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxBass.Text == "")
            {
                ErrorProviderCharCheck.SetError(TextBoxBass, "");
                NumericBassAttenuation.Visible = false;
                NumericBassPan.Visible = false;
                LabelBassPan.Visible = false;
            }
            GetAudioFile((TextBox)sender);
        }

        private void TextBoxGuitar_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxGuitar.Text == "")
            {
                ErrorProviderCharCheck.SetError(TextBoxGuitar, "");
                NumericGuitarAttenuation.Visible = false;
                NumericGuitarPan.Visible = false;
                LabelGuitarPan.Visible = false;
            }
            GetAudioFile((TextBox)sender);
        }

        private void TextBoxKeys_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxKeys.Text == "")
            {
                ErrorProviderCharCheck.SetError(TextBoxKeys, "");
                NumericKeysAttenuation.Visible = false;
                NumericKeysPan.Visible = false;
                LabelKeysPan.Visible = false;
            }
            GetAudioFile((TextBox)sender);
        }

        private void TextBoxVocals_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxVocals.Text == "")
            {
                ErrorProviderCharCheck.SetError(TextBoxVocals, "");
                NumericVocalAttenuation.Visible = false;
                NumericVocalPan.Visible = false;
                LabelVocalPan.Visible = false;
            }
            GetAudioFile((TextBox)sender);
        }

        private void TextBoxBacking_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxBacking.Text == "")
            {
                ErrorProviderCharCheck.SetError(TextBoxBacking, "");
                NumericBackingAttenuation.Visible = false;
                NumericBackingPan.Visible = false;
                LabelBackingPan.Visible = false;
            }
            GetAudioFile((TextBox)sender);
        }

        private void TextBoxDrumKit_EnabledChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();
            if (!TextBoxDrumKit.Enabled)
            {
                NumericDrumKitAttenuation.Visible = false;
                NumericDrumKitPan.Visible = false;
                LabelDrumKitPan.Visible = false;
                ButtonDrumKit.Visible = false;
                return;
            }
            ButtonDrumKit.Visible = true;
            if (TextBoxDrumKit.Text == "") return;
            NumericDrumKitAttenuation.Visible = true;
            NumericDrumKitPan.Visible = ProjectFile.GetTrack("drum_kit").NumChannels == 1;
            LabelDrumKitPan.Visible = ProjectFile.GetTrack("drum_kit").NumChannels == 2;
        }

        private void TextBoxDrumSnare_EnabledChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();
            if (!TextBoxDrumSnare.Enabled)
            {
                NumericDrumSnareAttenuation.Visible = false;
                NumericDrumSnarePan.Visible = false;
                LabelDrumSnarePan.Visible = false;
                ButtonDrumSnare.Visible = false;
                return;
            }
            ButtonDrumSnare.Visible = true;
            if (TextBoxDrumSnare.Text == "") return;
            NumericDrumSnareAttenuation.Visible = true;
            NumericDrumSnarePan.Visible = ProjectFile.GetTrack("drum_snare").NumChannels == 1;
            LabelDrumSnarePan.Visible = ProjectFile.GetTrack("drum_snare").NumChannels == 2;
        }

        private void TextBoxDrumKick_EnabledChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();
            if (!TextBoxDrumKick.Enabled)
            {
                NumericDrumKickAttenuation.Visible = false;
                NumericDrumKickPan.Visible = false;
                LabelDrumKickPan.Visible = false;
                ButtonDrumKick.Visible = false;
                return;
            }
            ButtonDrumKick.Visible = true;
            if (TextBoxDrumKick.Text == "") return;
            NumericDrumKickAttenuation.Visible = true;
            NumericDrumKickPan.Visible = ProjectFile.GetTrack("drum_kick").NumChannels == 1;
            LabelDrumKickPan.Visible = ProjectFile.GetTrack("drum_kick").NumChannels == 2;
        }

        private void TextBoxBass_EnabledChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();
            if (!TextBoxBass.Enabled)
            {
                NumericBassAttenuation.Visible = false;
                NumericBassPan.Visible = false;
                LabelBassPan.Visible = false;
                ButtonBass.Visible = false;
                return;
            }
            ButtonBass.Visible = true;
            if (TextBoxBass.Text == "") return;
            NumericBassAttenuation.Visible = true;
            NumericBassPan.Visible = ProjectFile.GetTrack("bass").NumChannels == 1;
            LabelBassPan.Visible = ProjectFile.GetTrack("bass").NumChannels == 2;
        }

        private void TextBoxGuitar_EnabledChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();
            if (!TextBoxGuitar.Enabled)
            {
                NumericGuitarAttenuation.Visible = false;
                NumericGuitarPan.Visible = false;
                LabelGuitarPan.Visible = false;
                ButtonGuitar.Visible = false;
                return;
            }
            ButtonGuitar.Visible = true;
            if (TextBoxGuitar.Text == "") return;
            NumericGuitarAttenuation.Visible = true;
            NumericGuitarPan.Visible = ProjectFile.GetTrack("guitar").NumChannels == 1;
            LabelGuitarPan.Visible = ProjectFile.GetTrack("guitar").NumChannels == 2;
        }

        private void TextBoxKeys_EnabledChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();
            if (!TextBoxKeys.Enabled)
            {
                NumericKeysAttenuation.Visible = false;
                NumericKeysPan.Visible = false;
                LabelKeysPan.Visible = false;
                ButtonKeys.Visible = false;
                return;
            }
            ButtonKeys.Visible = true;
            if (TextBoxKeys.Text == "") return;
            NumericKeysAttenuation.Visible = true;
            NumericKeysPan.Visible = ProjectFile.GetTrack("keys").NumChannels == 1;
            LabelKeysPan.Visible = ProjectFile.GetTrack("keys").NumChannels == 2;
        }

        private void TextBoxVocals_EnabledChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();
            if (!TextBoxVocals.Enabled)
            {
                NumericVocalAttenuation.Visible = false;
                NumericVocalPan.Visible = false;
                LabelVocalPan.Visible = false;
                ButtonVocals.Visible = false;
                return;
            }
            ButtonVocals.Visible = true;
            if (TextBoxVocals.Text == "") return;
            NumericVocalAttenuation.Visible = true;
            NumericVocalPan.Visible = ProjectFile.GetTrack("vocals").NumChannels == 1;
            LabelVocalPan.Visible = ProjectFile.GetTrack("vocals").NumChannels == 2;
        }

        private void TextBoxBacking_EnabledChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();
            if (!TextBoxBacking.Enabled)
            {
                NumericBackingAttenuation.Visible = false;
                NumericBackingPan.Visible = false;
                LabelBackingPan.Visible = false;
                ButtonBacking.Visible = false;
                return;
            }
            ButtonBacking.Visible = true;
            if (TextBoxBacking.Text == "") return;
            NumericBackingAttenuation.Visible = true;
            NumericBackingPan.Visible = ProjectFile.GetTrack("backing").NumChannels == 1;
            LabelBackingPan.Visible = ProjectFile.GetTrack("backing").NumChannels == 2;
        }
        
        private void TextBoxMidiFile_DragDrop(object sender, DragEventArgs e)
        {
            var fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            if (fileName.ToLowerInvariant().EndsWith(".mid", StringComparison.CurrentCultureIgnoreCase))
            {
                TextBoxMidiFile.Text = fileName;
            }
            else
            {
                MessageBox.Show("You can only drag and drop a MIDI file here\nTry again", mAppTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void HandleDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }
        
        private void AudioBoxes_DragDrop(object sender, DragEventArgs e)
        {
            var fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            switch (Path.GetExtension(fileName).ToLowerInvariant())
            {
                case ".ogg":
                case ".mp3":
                case ".wav":
                case ".flac":
                    ((TextBox)sender).Text = fileName;
                    Tools.CurrentFolder = Path.GetDirectoryName(fileName) + "\\";
                    break;
                default:
                    MessageBox.Show("File '" + Path.GetFileName(fileName) + "' is not valid here\nTry again", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        private void changeCompilerExecutableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ADVANCED USE ONLY\n\nIf you're having problems compiling your project and you think it is caused by a modification to MagmaCompilerC3.exe, use this option to select the original MagmaCompiler.exe\n\nNOTE: Many of the new Magma: Rok On Edition features will not compile correctly with the old MagmaCompiler.exe\n\nIf you're not sure what you're doing, press CANCEL to back out and no changes will be made\n\nPress OK to select the new compiler executable you want me to use\n\nThis can be changed again later",
                "ADVANCED USE ONLY", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
            var fileDialog = new OpenFileDialog
                {
                    Filter = "Windows Executable (*.exe)|*.exe",
                    InitialDirectory = Application.StartupPath
                };

            fileDialog.ShowDialog();

            if (fileDialog.FileName == "" || fileDialog.FileName.Substring(fileDialog.FileName.Length - 4, 4) != ".exe")
                return;
            ProjectCompiler = Path.GetFileName(fileDialog.FileName);
            changeCompilerExecutable.Text = "Change compiler executable (currently using '" + ProjectCompiler + "')";
        }

        private void txtTitleDisplay_TextChanged(object sender, EventArgs e)
        {
            PackageDisplay = txtTitleDisplay.Text.Trim();
            RefreshWindowTitle();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            PackageDescription = txtDescription.Text.Trim();
            RefreshWindowTitle();
        }

        private void btnDescDefault_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "Created with Magma: Rok On Edition.";
        }

        private void updateTitleDisplay()
        {
            if (TextBoxSongName.Text == "" && TextBoxArtistName.Text == "")
            {
                txtTitleDisplay.Text = "";
                return;
            }

            var songversions = "";
            if (chk2xBass.Checked)
            {
                songversions = songversions + " (2x Bass Pedal)";
            }
            if (chkRhythmKeys.Checked || chkRhythmBass.Checked)
            {
                songversions = songversions + " (Rhythm Version)";
            }

            songversions = songversions.Trim();

            if (songversions != "")
            {
                songversions = " " + songversions;
            }

            if (dispDefault)
            {
                if (TextBoxArtistName.Text != "")
                {
                    PackageDisplay = (string.IsNullOrEmpty(Artist) ? TextBoxArtistName.Text : Artist) + " - " + Song + songversions;
                }
                else
                {
                    PackageDisplay = (string.IsNullOrEmpty(Song) ? TextBoxSongName.Text : Song) + songversions;
                }
            }
            else if (dispDLC && TextBoxSongName.Text !="")
            {
                PackageDisplay = "\"" + (string.IsNullOrEmpty(Song) ? TextBoxSongName.Text : Song) + songversions + "\"";
            }

            txtTitleDisplay.Text = PackageDisplay;
        }

        private void btnDispDefault_Click(object sender, EventArgs e)
        {
            dispDefault = true;
            dispDLC = false;

            updateTitleDisplay();
        }

        private void btnDispDLC_Click(object sender, EventArgs e)
        {
            dispDefault = false;
            dispDLC = true;

            updateTitleDisplay();
        }

        private void getThumb(string input)
        {
            string file;

            if (input == "")
            {
                var ofd = new OpenFileDialog
                    {
                        Filter = "Image Files|*.bmp;*.tif;*.jpg;*.png",
                        Title = "Select a thumbnail image",
                        InitialDirectory = Tools.CurrentFolder
                    };
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;
                file = ofd.FileName;
                Tools.CurrentFolder = Path.GetDirectoryName(file) + "\\";
            }
            else
            {
                file = input;
            }

            var filePath = Path.GetDirectoryName(file) + "\\" + Path.GetFileNameWithoutExtension(file) + "_thumb.png";
            if (ProjectFile.DestinationFile != "")
            {
                filePath = Path.GetDirectoryName(ProjectFile.DestinationFile) + "\\" + Path.GetFileNameWithoutExtension(file) + "_thumb.png";
            }
            
            try
            {
                try
                {
                    var image = Tools.NemoLoadImage(file);
                    if (image.Width == 64 && image.Height == 64)
                    {
                        picThumb.Image = image;
                        PackageThumb = file;
                    }
                    else
                    {
                        var bitmap = new Bitmap(64, 64, PixelFormat.Format24bppRgb);
                        using (var graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.CompositingQuality = CompositingQuality.HighQuality;
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            graphics.SmoothingMode = SmoothingMode.HighQuality;
                            graphics.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);
                        }
                        bitmap.Save(filePath, ImageFormat.Png);

                        picThumb.Image = Tools.NemoLoadImage(filePath);
                        PackageThumb = filePath;
                    }
                }
                catch
                {
                    UGCDebug.ShowOKMsgBox(this, "This file does not seem to be valid image and cannot be converted.");
                    return;
                }

                DoShowToast("Package thumbnail loaded successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the thumbnail\nThe error says:\n" + ex.Message, mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                picThumb.Image = PictureBoxAlbumArt.Image;
                PackageThumb = "";
                DoShowToast("Reverted to default thumbnail");
            }

            RefreshWindowTitle();
        }
        
        private void useDefaultRB3ImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picThumb.Image = Resources.ContentImage;
            PackageThumb = "rb3";

            RefreshWindowTitle();
        }

        private void importpngxboxFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Rock Band Album Art (*.png_xbox)|*.png_xbox",
                InitialDirectory = Tools.CurrentFolder,
                Title = "Select Rock Band album art file..."
            };
            if (ofd.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(ofd.FileName)) return;
            TextBoxAlbumArt.Text = ofd.FileName;
            Tools.CurrentFolder = Path.GetDirectoryName(ofd.FileName) + "\\";
        }

        private bool isValid(string con)
        {
            //try to load the STFS package
            var xPackage = new STFSPackage(con);
            if (!xPackage.ParseSuccess)
            {
                MessageBox.Show("Error opening song file '" + Path.GetFileName(con), mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                xPackage.CloseIO();
                return false;
            }

            //we can't work with packs or pro upgrades, so check and skip
            var xent = xPackage.GetFolder("songs_upgrades");
            if (xent != null)
            {
                xent = xPackage.GetFolder("songs");
                MessageBox.Show(xent != null
                        ? "It looks like this is a pack...\nWhat were you expecting me to do with this?\nTry a single song, please"
                        : "It looks like this is a pro upgrade...\nWhat were you expecting me to do with this?\nTry a full song, please",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                xPackage.CloseIO();
                return false;
            }

            var fileName = Path.GetFileName(con);
            var dta = Application.StartupPath + "\\" + fileName.Replace(" ", "") + ".dta";
            if (!Parser.ExtractDTA(con, dta))
            {
                MessageBox.Show("Can't find songs.dta inside this file!\nI can't work without it, sorry", mAppTitle,
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!Parser.ReadDTA(dta))
            {
                MessageBox.Show("Failed to read the songs.dta file\nI can't work without it, sorry", mAppTitle,
                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Parser.Songs.Count == 1) return true;
            MessageBox.Show("It looks like this is a pack...\nWhat were you expecting me to do with this?\nTry a single song, please",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        private bool loadINI(string ini)
        {
            if (!File.Exists(ini)) return false;
            var error = false;
            var song = new SongData();
            song.Initialize();
            song.Master = true;
            using (var sr = new StreamReader(ini))
            {
                while (sr.Peek() >= 0)
                {
                    try
                    {
                        var line = sr.ReadLine();
                        if (line.Contains("artist=") || line.Contains("artist ="))
                        {
                            song.Artist = Tools.GetConfigString(line);
                        }
                        else if (line.Contains("name=") || line.Contains("name ="))
                        {
                            song.Name = Tools.GetConfigString(line);
                        }
                        else if (line.Contains("album=") || line.Contains("album ="))
                        {
                            song.Album = Tools.GetConfigString(line);
                        }
                        else if (line.Contains("year=") || line.Contains("year ="))
                        {
                            song.YearReleased = Convert.ToInt16(Tools.GetConfigString(line));
                        }
                        else if (line.Contains("genre=") || line.Contains("genre ="))
                        {
                            song.Genre = Tools.GetConfigString(line).ToLowerInvariant().Replace(" ","").Replace("newwave","new_wave");
                            song.RawGenre = string.IsNullOrEmpty(song.Genre) ? "" : song.Genre;
                        }
                        else if (line.Contains("song_length"))
                        {
                            song.Length = Convert.ToInt32(Tools.GetConfigString(line));
                        }
                        else if (line.Contains("preview_start_time"))
                        {
                            song.PreviewStart = Convert.ToInt32(Tools.GetConfigString(line));
                            song.PreviewEnd = song.PreviewStart + 30000;
                        }
                        else if (line.Contains("charter=") || line.Contains("charter ="))
                        {
                            song.ChartAuthor = Tools.GetConfigString(line);
                        }
                        else if (line.Contains("diff_keys_real") && !line.Contains("diff_keys_real_ps"))
                        {
                            song.ProKeysDiff = Convert.ToInt16(Tools.GetConfigString(line)) + 1;
                            song.DisableProKeys = song.ProKeysDiff <= 0;
                        }
                        else if (line.Contains("track=") || line.Contains("track ="))
                        {
                            song.TrackNumber = Convert.ToInt16(Tools.GetConfigString(line));
                        }
                        else if (line.Contains("hopo_frequency"))
                        {
                            song.HopoThreshold = Convert.ToInt16(Tools.GetConfigString(line));
                        }
                        else if (line.Contains("kit_type"))
                        {
                            int kit;
                            try
                            {
                                kit = Convert.ToInt16(Tools.GetConfigString(line));
                            }
                            catch (Exception)
                            {
                                kit = 1;
                            }
                            song.DrumBank = "kit0" + kit;
                        }
                        else if (line.Contains("real_bass_tuning"))
                        {
                            song.ProBassTuning = Tools.GetConfigString(line);
                        }
                        else if (line.Contains("real_guitar_tuning"))
                        {
                            song.ProGuitarTuning = Tools.GetConfigString(line);
                        }
                        else if (line.Contains("diff_drums") && !line.Contains("diff_drums_real"))
                        {
                            song.DrumsDiff = Convert.ToInt16(Tools.GetConfigString(line)) + 1;
                        }
                        else if (line.Contains("diff_drums") && !line.Contains("diff_drums_real"))
                        {
                            song.DrumsDiff = Convert.ToInt16(Tools.GetConfigString(line)) + 1;
                        }
                        else if (line.Contains("diff_bass") && !line.Contains("diff_bass_real") &&
                                 !line.Contains("diff_bass_coop"))
                        {
                            song.BassDiff = Convert.ToInt16(Tools.GetConfigString(line)) + 1;
                        }
                        else if (line.Contains("diff_bass_real") && !line.Contains("diff_bass_real_22"))
                        {
                            song.ProBassDiff = Convert.ToInt16(Tools.GetConfigString(line)) + 1;
                        }
                        else if (line.Contains("diff_guitar") && !line.Contains("diff_guitar_real") &&
                                 !line.Contains("diff_guitar_coop"))
                        {
                            song.GuitarDiff = Convert.ToInt16(Tools.GetConfigString(line)) + 1;
                        }
                        else if (line.Contains("diff_guitar_real") && !line.Contains("diff_guitar_real_22"))
                        {
                            song.ProGuitarDiff = Convert.ToInt16(Tools.GetConfigString(line)) + 1;
                        }
                        else if (line.Contains("diff_keys") && !line.Contains("diff_keys_real"))
                        {
                            song.KeysDiff = Convert.ToInt16(Tools.GetConfigString(line)) + 1;
                        }
                        else if (line.Contains("diff_keys_real"))
                        {
                            song.ProKeysDiff = Convert.ToInt16(Tools.GetConfigString(line)) + 1;
                        }
                        else if (line.Contains("diff_vocals") && !line.Contains("diff_vocals_harm"))
                        {
                            song.VocalsDiff = Convert.ToInt16(Tools.GetConfigString(line)) + 1;
                        }
                        else if (line.Contains("diff_band"))
                        {
                            song.BandDiff = Convert.ToInt16(Tools.GetConfigString(line)) + 1;
                        }
                    }
                    catch (Exception)
                    {
                        error = true;
                    }
                }
                sr.Dispose();
            }
            if (error) return false;
            Parser.Songs.Add(song);
            return true;
        }
        
        private void loadDTA(string dta, bool isINI)
        {
            //setNemoDefaults();
            Parser.Songs = new List<SongData>();
            if (isINI)
            {
                if (!loadINI(dta))
                {
                    return;
                }
            }
            else
            {
                if (!Parser.ReadDTA(dta) || !Parser.Songs.Any())
                {
                    MessageBox.Show("There was an error reading that DTA file, can't continue with Import function", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            Importing = true;  //disable toast notifications
            Tools.CurrentFolder = Path.GetDirectoryName(dta) + "\\";
            
            var guitartune1 = "0";
            var guitartune2 = "0";
            var guitartune3 = "0";
            var guitartune4 = "0";
            var guitartune5 = "0";
            var guitartune6 = "0";
            var basstune1 = "0";
            var basstune2 = "0";
            var basstune3 = "0";
            var basstune4 = "0";

            //disable all instruments
            CheckVocals.Checked = false;
            CheckHarmonyVocals2.Checked = false;
            CheckHarmonyVocals3.Checked = false;
            CheckDrums.Checked = false;
            CheckBass.Checked = false;
            CheckGuitar.Checked = false;
            CheckKeys.Checked = false;
            CheckBacking.Checked = false;
            CheckCrowd.Checked = false;
            chkProKeys.Checked = false;
            chkProBass.Checked = false;
            chkProGuitar.Checked = false;
            //chkTonicNote.Checked = false;
            CheckBoxFromAlbum.Checked = false;

            var song = Parser.Songs[0];
            TextBoxSongName.Text = song.Name;
            TextBoxArtistName.Text = song.Artist;
            if (!useUniqueNumericSongID.Checked)
            {
                var songid = song.InternalName;
                txtSongID.Text = songid.Contains(")") ? songid.Substring(0, songid.IndexOf(")", StringComparison.Ordinal)) : songid;
                try
                {
                    if (txtSongID.Text.Substring(txtSongID.Text.Length - 2, 1) == "v" &&
                        Convert.ToInt16(txtSongID.Text.Substring(txtSongID.Text.Length - 1, 1)) != 0)
                    {
                        numVersion.Value = Convert.ToInt16(txtSongID.Text.Substring(txtSongID.Text.Length - 1, 1)) + 1;
                        txtSongID.Text = txtSongID.Text.Substring(0, txtSongID.Text.Length - 2);
                    }
                    else if (txtSongID.Text.Substring(txtSongID.Text.Length - 3, 1) == "v" &&
                                Convert.ToInt16(txtSongID.Text.Substring(txtSongID.Text.Length - 2, 2)) != 0)
                    {
                        numVersion.Value = Convert.ToInt16(txtSongID.Text.Substring(txtSongID.Text.Length - 2, 2)) + 1;
                        txtSongID.Text = txtSongID.Text.Substring(0, txtSongID.Text.Length - 3);
                    }
                }
                catch (Exception)
                {}//
            }
            else if (useUniqueNumericSongID.Checked && song.SongId > 0 && song.SongId != 99999999 && Parser.IsNumericID(song.SongId.ToString(CultureInfo.InvariantCulture)))
            {
                txtSongID.Text = song.SongId.ToString(CultureInfo.InvariantCulture);
                UniqueNumericID = song.SongId.ToString(CultureInfo.InvariantCulture);
            }
            ComboRating.SelectedIndex = song.Rating > 0 ? song.Rating - 1 : 3; //unrated if rating error
            chkSoloDrums.Checked = song.InstrumentSolos.ToLowerInvariant().Contains("drum");
            chkSoloGuitar.Checked = song.InstrumentSolos.ToLowerInvariant().Contains("guitar");
            chkSoloBass.Checked = song.InstrumentSolos.ToLowerInvariant().Contains("bass");
            chkSoloKeys.Checked = song.InstrumentSolos.ToLowerInvariant().Contains("keys");
            chkSoloVocals.Checked = song.InstrumentSolos.ToLowerInvariant().Contains("vocal");
            NumericTrackNumber.Value = song.TrackNumber > 0 ? song.TrackNumber : 1;
            chkTonicNote.Checked = song.TonicNote > -1;
            ComboTonicNote.SelectedIndex = song.TonicNote;
            if (song.Encoding.Contains("latin1"))
            {
                aNSIToolStripMenuItem_Click(null, null);
            }
            else if (song.Encoding.Contains("utf8"))
            {
                uTF8ToolStripMenuItem_Click(null, null);
            }
            NumericGuidePitchAttenuation.Value = song.GuidePitch;
            numericVocalMute.Value = song.MuteVolumeVocals;
            numericMuteVol.Value = song.MuteVolume;
            numericTuningCents.Value = song.TuningCents;
            ComboVocalGender.SelectedIndex = song.Gender.ToLowerInvariant().Contains("female") ? 1 : 0;
            if (song.PreviewStart == 0)
            {
                DoShowToast("Imported song had preview time at 0:00, changed to 0:30");
                NumericPreviewMins.Value = new Decimal(0);
                DomainPreviewSecs.SelectedItem = "30";
                ProjectFile.PreviewStart = 30000;
            }
            else
            {
                SongPreview = song.PreviewStart;
                ProjectFile.PreviewStart = (int)SongPreview;
                UpdateSongPreview();
            }
            ComboDrumSFX.SelectedIndex = Parser.GetDrumKit(song.DrumBank) - 1;
            CheckCrowd.Checked = song.ChannelsCrowd > 0 && !wiiConversion.Checked;
            if (song.PercussionBank.Contains("hand"))
            {
                ComboVocalPercussion.SelectedIndex = 2;
            }
            else if (song.PercussionBank.Contains("tambourine"))
            {
                ComboVocalPercussion.SelectedIndex = 0;
            }
            else if (song.PercussionBank.Contains("cow"))
            {
                ComboVocalPercussion.SelectedIndex = 1;
            }
            switch (song.HopoThreshold)
            {
                case 90:
                    ComboHopo.SelectedIndex = 0;
                    break;
                case 130:
                    ComboHopo.SelectedIndex = 1;
                    break;
                case 170:
                    ComboHopo.SelectedIndex = 2;
                    break;
                case 250:
                    ComboHopo.SelectedIndex = 3;
                    break;
                default:
                    ComboHopo.SelectedIndex = 2;
                    break;
            }
            chkMaster.Checked = song.Master;
            switch (song.AnimTempo)
            {
                case 16:
                    ComboAnimationSpeed.SelectedIndex = 0;
                    break;
                case 24:
                    ComboAnimationSpeed.SelectedIndex = 1;
                    break;
                case 32:
                    ComboAnimationSpeed.SelectedIndex = 2;
                    break;
                case 48:
                    ComboAnimationSpeed.SelectedIndex = 3;
                    break;
                case 64:
                    ComboAnimationSpeed.SelectedIndex = 4;
                    break;
                default:
                    ComboAnimationSpeed.SelectedIndex = 2;
                    break;
            }
            switch (song.ScrollSpeed)
            {
                case 3000:
                    ComboVocalScroll.SelectedIndex = 0;
                    break;
                case 2750:
                    ComboVocalScroll.SelectedIndex = 1;
                    break;
                case 2600:
                    ComboVocalScroll.SelectedIndex = 2;
                    break;
                case 2450:
                    ComboVocalScroll.SelectedIndex = 3;
                    break;
                case 2300:
                    ComboVocalScroll.SelectedIndex = 4;
                    break;
                case 2150:
                    ComboVocalScroll.SelectedIndex = 5;
                    break;
                case 2000:
                    ComboVocalScroll.SelectedIndex = 6;
                    break;
                case 1850:
                    ComboVocalScroll.SelectedIndex = 7;
                    break;
                case 1700:
                    ComboVocalScroll.SelectedIndex = 8;
                    break;
                default:
                    ComboVocalScroll.SelectedIndex = 4;
                    break;
            }
            TextBoxAlbumName.Text = song.Album;
            CheckBoxFromAlbum.Checked = TextBoxAlbumName.Text != "";
            NumericUpDownYear.Value = song.YearReleased;
            numericReRecord.Value = song.YearRecorded == 0 ? DateTime.Now.Year : song.YearRecorded;
            chkReRecord.Checked = song.YearRecorded != 0;
            DrumDiff(song.DrumsDiff);
            scrollDrums.Value = song.DrumsDiffRaw;
            BassDiff(song.BassDiff);
            scrollBass.Value = song.BassDiffRaw;
            ProBassDiff = song.ProBassDiff;
            scrollProBass.Value = song.ProBassDiffRaw;
            GuitarDiff(song.GuitarDiff);
            scrollGuitar.Value = song.GuitarDiffRaw;
            ProGuitarDiff = song.ProGuitarDiff;
            scrollProGuitar.Value = song.ProGuitarDiffRaw;
            VocalsDiff(song.VocalsDiff);
            scrollVocals.Value = song.VocalsDiffRaw;
            KeysDiff(song.KeysDiff);
            scrollKeys.Value = song.KeysDiffRaw;
            ProKeysDiff(song.ProKeysDiff);
            scrollProKeys.Value = song.ProKeysDiffRaw;
            BandDiff(song.BandDiff);
            scrollBand.Value = song.BandDiffRaw;
            ProjectFile.Genre = song.RawGenre;
            ProjectFile.SubGenre = song.RawSubGenre;
            
            if (song.Multitrack)
            {
                chkMultitrack.Checked = true;
                chkKaraoke.Checked = false;
                chkDIYStems.Checked = false;
            }
            else if (song.Karaoke)
            {
                chkMultitrack.Checked = false;
                chkKaraoke.Checked = true;
                chkDIYStems.Checked = false;
            }
            else if (song.DIYStems)
            {
                chkMultitrack.Checked = false;
                chkKaraoke.Checked = false;
                chkDIYStems.Checked = true;
            }

            if (song.ProGuitarTuning != "")
            {
                try
                {
                    var tuning = song.ProGuitarTuning.Replace("(real_guitar_tuning (", "");
                    tuning = tuning.Replace("))", ")").Trim();
                    var tunes = tuning.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    guitartune1 = tunes[0];
                    guitartune2 = tunes[1];
                    guitartune3 = tunes[2];
                    guitartune4 = tunes[3];
                    guitartune5 = tunes[4];
                    guitartune6 = tunes[5];
                    chkProGuitar.Checked = true;
                }
                catch (Exception)
                {}
            }
            if (song.ProBassTuning != "")
            {
                try
                {
                    var tuning = song.ProGuitarTuning.Replace("(real_bass_tuning (", "");
                    tuning = tuning.Replace("))", ")").Trim();
                    tuning = tuning.Trim();
                    var tunes = tuning.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    basstune1 = tunes[0];
                    basstune2 = tunes[1];
                    basstune3 = tunes[2];
                    basstune4 = tunes[3];
                    chkProBass.Checked = true;
                }
                catch (Exception)
                { }
            }
            if (!string.IsNullOrEmpty(song.ChartAuthor))
            {
                TextBoxAuthor.Text = song.ChartAuthor;
            }
            if (!string.IsNullOrEmpty(song.OverrideName))
            {
                TextBoxSongName.Text = song.OverrideName;
            }
            if (song.DisableProKeys)
            {
                chkProKeys.Checked = false;
            }
            chkRhythmBass.Checked = song.RhythmBass;
            chkRhythmKeys.Checked = song.RhythmKeys;
            chk2xBass.Checked = song.DoubleBass;
            chkKaraoke.Checked = song.Karaoke;
            chkMultitrack.Checked = song.Multitrack;
            chkXOnly.Checked = song.ExpertOnly;
            chkCAT.Checked = song.CATemh;
            chkConvert.Checked = song.Convert;
            CheckBoxLangEnglish.Checked = song.Languages == "" || song.Languages.Contains("English");
            CheckBoxLangFrench.Checked = song.Languages.Contains("French");
            CheckBoxLangGerman.Checked = song.Languages.Contains("German");
            CheckBoxLangItalian.Checked = song.Languages.Contains("Italian");
            CheckBoxLangJapanese.Checked = song.Languages.Contains("Japanese");
            CheckBoxLangSpanish.Checked = song.Languages.Contains("Spanish");
            try
            {
                UiUtl.SetLocalizedComboBoxValue(ComboBoxGenre, ProjectFile.Genre, mGenreSymbols);
            }
            catch (Exception)
            {}
            RefreshGenres();
            var silence_stereo = "";
            if (useSilenceTracksByDefault.Checked && use441KHzToolStripMenuItem.Checked)
            {
                silence_stereo = SilenceStereo44;
            }
            if (useSilenceTracksByDefault.Checked && use48KHzToolStripMenuItem.Checked)
            {
                silence_stereo = SilenceStereo48;
            }
            CheckDrums.Checked = ProjectFile.GetTrack("drum_kit").Enabled;
            TextBoxDrumSnare.Text = "";
            TextBoxDrumKit.Text = "";
            TextBoxDrumKit.Text = CheckDrums.Checked ? silence_stereo : "";
            CheckBass.Checked = ProjectFile.GetTrack("bass").Enabled;
            TextBoxBass.Text = CheckBass.Checked ? silence_stereo : "";
            CheckGuitar.Checked = ProjectFile.GetTrack("guitar").Enabled;
            TextBoxGuitar.Text = CheckGuitar.Checked ? silence_stereo : "";
            CheckKeys.Checked = ProjectFile.GetTrack("keys").Enabled;
            TextBoxKeys.Text = CheckKeys.Checked ? silence_stereo : "";
            CheckVocals.Checked = ProjectFile.GetTrack("vocals").Enabled;
            TextBoxVocals.Text = CheckVocals.Checked ? silence_stereo : "";

            switch (song.VocalParts)
            {
                case 2:
                    ProjectFile.DryVoxHarmony2Enabled = true;
                    break;
                case 3:
                    ProjectFile.DryVoxHarmony2Enabled = true;
                    ProjectFile.DryVoxHarmony3Enabled = true;
                    break;
            }
            CheckHarmonyVocals2.Checked = ProjectFile.DryVoxHarmony2Enabled;
            CheckHarmonyVocals3.Checked = ProjectFile.DryVoxHarmony3Enabled;

            //Wii can't use milo files generated by MagmaCompiler, so skip having to generate lipsync files
            //since it makes no difference to them, less work
            if (TextBoxDryVocals.Enabled && wiiConversion.Checked)
            {
                TextBoxDryVocals.Text = BlankDryvox;
            }
            if (TextBoxDryVocalsHarmony2.Enabled && wiiConversion.Checked)
            {
                TextBoxDryVocalsHarmony2.Text = BlankDryvox;
            }
            if (TextBoxDryVocalsHarmony3.Enabled && wiiConversion.Checked)
            {
                TextBoxDryVocalsHarmony3.Text = BlankDryvox;
            }

            if (ProGuitarDiff > 0)
            {
                doProGuitarDiff(ProGuitarDiff);
            }
            if (ProBassDiff > 0)
            {
                doProBassDiff(ProBassDiff);
            }

            if (disableProKeys)
            {
                chkProKeys.Checked = false;
            }

            GuitarTuning1.Text = guitartune1;
            GuitarTuning2.Text = guitartune2;
            GuitarTuning3.Text = guitartune3;
            GuitarTuning4.Text = guitartune4;
            GuitarTuning5.Text = guitartune5;
            GuitarTuning6.Text = guitartune6;
            BassTuning1.Text = basstune1;
            BassTuning2.Text = basstune2;
            BassTuning3.Text = basstune3;
            BassTuning4.Text = basstune4;

            //always enable backing by default
            CheckBacking.Checked = true;
            EnableDisableTrack("backing", true);

            if (txtSongID.Text == "" && TextBoxMidiFile.Text!="" && !useUniqueNumericSongID.Checked)
            {
                txtSongID.Text = Path.GetFileNameWithoutExtension(TextBoxMidiFile.Text).Replace(" ", "");
            }
            var folder = Path.GetDirectoryName(dta) + "\\";
            if (isINI)
            {
                
                var oggs = Directory.GetFiles(folder, "*.ogg", SearchOption.TopDirectoryOnly);
                if (oggs.Any())
                {
                    if (MessageBox.Show("I found " + oggs.Count() + " ogg " + (oggs.Count() == 1 ? "file" : "files") +
                            "!\nDo you want me to add them to your project?", mAppTitle,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        EnableDisable(false);
                        if (oggs.Count() == 1 && Path.GetFileName(oggs[0]).ToLowerInvariant() == "guitar.ogg")
                        {
                            TextBoxBacking.Text = oggs[0];
                        }
                        else
                        {
                            SearchForStems(folder, ".ogg");
                        }
                        EnableDisable(true);
                    }
                }
                if (File.Exists(folder + "notes.mid"))
                {
                    TextBoxMidiFile.Text = folder + "notes.mid";
                }
                if (File.Exists(folder + "album.png"))
                {
                    TextBoxAlbumArt.Text = folder + "album.png";
                }
            }
            Importing = false;
        }

        private void BandDiff(int difficulty)
        {
            ProjectFile.RankBand = difficulty > 0 ? difficulty : 1;
            UpdateDifficultyDisplayNEMO(PictureBandDifficulty1,difficulty,true);
        }

        private void BassDiff(int difficulty)
        {
            EnableDisableTrack("bass", difficulty > 0);
            ProjectFile.RankBass = difficulty > 0 ? difficulty : 1;
            UpdateDifficultyDisplayNEMO(PictureBassDifficulty1, difficulty, difficulty > 0);
        }

        private void doProBassDiff(int difficulty)
        {
            chkProBass.Checked = difficulty > 0;
            RankProBass = difficulty > 0 ? difficulty : 1;
            UpdateDifficultyDisplayNEMO(PictureProBassDifficulty1, difficulty, difficulty > 0);
        }

        private void doProBassDiff(string line)
        {
            doProBassDiff(Parser.ProBassDiff(line));
        }

        private void GuitarDiff(int difficulty)
        {
            EnableDisableTrack("guitar", difficulty > 0);
            ProjectFile.RankGuitar = difficulty > 0 ? difficulty : 1;
            UpdateDifficultyDisplayNEMO(PictureGuitarDifficulty1, difficulty, difficulty > 0);
        }

        private void doProGuitarDiff(int difficulty)
        {
            chkProGuitar.Checked = difficulty > 0;
            RankProGuitar = difficulty > 0 ? difficulty : 1;
            UpdateDifficultyDisplayNEMO(PictureProGuitarDifficulty1, difficulty, difficulty > 0);
        }

        private void doProGuitarDiff(string line)
        {
            doProGuitarDiff(Parser.ProGuitarDiff(line));
        }

        private void DrumDiff(int difficulty)
        {
            EnableDisableTrack("drum_kick", false);
            EnableDisableTrack("drum_snare", false);

            EnableDisableTrack("drum_kit", difficulty > 0);
            ProjectFile.RankDrum = difficulty > 0 ? difficulty : 1;
            UpdateDifficultyDisplayNEMO(PictureDrumDifficulty1, difficulty, difficulty > 0);
        }

        private void KeysDiff(int difficulty)
        {
            EnableDisableTrack("keys", difficulty > 0);
            ProjectFile.RankKeys = difficulty > 0 ? difficulty : 1;
            UpdateDifficultyDisplayNEMO(PictureKeysDifficulty1, difficulty, difficulty > 0);
        }

        private void ProKeysDiff(int difficulty)
        {
            ProjectFile.RankProKeys = difficulty > 0 ? difficulty : 1;
            chkProKeys.Checked = difficulty > 0;
            UpdateDifficultyDisplayNEMO(PictureProKeysDifficulty1, difficulty, difficulty > 0);
        }

        private void VocalsDiff(int difficulty)
        {
            EnableDisableTrack("vocals", difficulty > 0);
            ProjectFile.RankVocals = difficulty > 0 ? difficulty : 1;
            UpdateDifficultyDisplayNEMO(PictureVocalDifficulty1, difficulty, difficulty > 0);
        }

        private void importCON(string con)
        {
            Importing = true;
            FileNewMenuItem_Click(null, null);
            var moggpath = "";

            var projectfolder = Path.GetDirectoryName(con) + "\\" + Path.GetFileName(con).Replace(" ", "").Replace("-", "").Replace(".", "") + "_Project";
            ProjDir = projectfolder + "\\";
            var xPackage = new STFSPackage(con);
            var extractfolder = projectfolder.Substring(0, projectfolder.Length - 7) + "extracted";
            Directory.CreateDirectory(projectfolder);
            Directory.CreateDirectory(projectfolder + "\\Audio");
            Tools.CurrentFolder = ProjDir;

            var success = false;
            if (xPackage.ParseSuccess)
            {
                success = xPackage.ExtractPayload(extractfolder, true, true);
            }

            if (!success)
            {
                MessageBox.Show("Error extracting CON file\nCan't continue with Import function, sorry", mAppTitle,MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (xPackage.Header.Description.ToLowerInvariant().Contains("ghtorb3") || xPackage.Header.Description.ToLowerInvariant().Contains("tiny.cc/ghtorb") || xPackage.Header.Description.ToLowerInvariant().Contains("t=405473"))
            {
                TextBoxAuthor.Text = "GHtoRB3";
            }
            else if (xPackage.Header.Description.ToLowerInvariant().Contains("rockband.com"))
            {
                TextBoxAuthor.Text = "Harmonix";
                chkMultitrack.Checked = true;
            }
            if (xPackage.Header.Description.Contains(xPackage.Header.Title_Display.Replace("\"", "")) && !xPackage.Header.Description.ToLowerInvariant().Contains("rockband.com") && !xPackage.Header.Description.ToLowerInvariant().Contains("ghtorb3") && !xPackage.Header.Description.ToLowerInvariant().Contains("tiny.cc/ghtorb") && !xPackage.Header.Description.ToLowerInvariant().Contains("t=405473"))
            {
                TextBoxAuthor.Text = "Rock Band Network";
                chkMultitrack.Checked = true;
            }
            if (xPackage.Header.Description.Contains("Buy The Beatles: Rock Band"))
            {
                chkMultitrack.Checked = true;
                chkConvert.Checked = true;
                TextBoxAuthor.Text = "Harmonix / TrojanNemo";
            }

            try
            {
                //find and move MIDI
                var MIDI = Directory.GetFiles(extractfolder, "*.mid", SearchOption.AllDirectories);
                if (!string.IsNullOrEmpty(MIDI[0]))
                {
                    Tools.MoveFile(MIDI[0], projectfolder + "\\" + Path.GetFileName(MIDI[0]));
                    TextBoxMidiFile.Text = projectfolder + "\\" + Path.GetFileName(MIDI[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error moving MIDI file during import, sorry\nThe error says: " + ex.Message, mAppTitle, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }

            try
            {
                //find and move mogg
                var mogg = Directory.GetFiles(extractfolder, "*.mogg", SearchOption.AllDirectories);
                if (!string.IsNullOrEmpty(mogg[0]))
                {
                    moggpath = projectfolder + "\\" + Path.GetFileName(mogg[0]);
                    nautilus.DecM(File.ReadAllBytes(mogg[0]), true, false, NautilusFREE.DecryptMode.ToFile, moggpath);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error moving the MOGG file during import, sorry\nThe error says: " + ex.Message, mAppTitle, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }

            try
            {
                //find and move milo
                var milo = Directory.GetFiles(extractfolder, "*.milo_xbox", SearchOption.AllDirectories);
                if (!string.IsNullOrEmpty(milo[0]))
                {
                    Tools.MoveFile(milo[0], projectfolder + "\\" + Path.GetFileName(milo[0]));
                }
            }
            catch (Exception)
            { } //just continue, this is an optional file
            
            Importing = true;
            //find and move album art
            var albumart = Directory.GetFiles(extractfolder, "*.png_xbox", SearchOption.AllDirectories);
            try
            {
                if (!string.IsNullOrEmpty(albumart[0]))
                {
                    Tools.MoveFile(albumart[0], projectfolder + "\\" + Path.GetFileName(albumart[0]));
                    TextBoxAlbumArt.Text = projectfolder + "\\" + Path.GetFileName(albumart[0]);
                }
            }
            catch
            {
                //just continue, this is an optional file
            }
            overrideAlbumArt.Checked = true;
            
            txtTitleDisplay.Text = xPackage.Header.Title_Display;
            if (xPackage.Header.Description != "")
            {
                txtDescription.Text = xPackage.Header.Description.Replace(Environment.NewLine, " ");
            }
            else
            {
                btnDescDefault_Click(null, null);
            }

            try
            {
                Importing = true;
                //find and move dta
                var dta = Directory.GetFiles(extractfolder, "*.dta", SearchOption.AllDirectories);
                if (!string.IsNullOrEmpty(dta[0]))
                {
                    Tools.MoveFile(dta[0], projectfolder + "\\" + Path.GetFileName(dta[0]));
                    loadDTA(projectfolder + "\\" + Path.GetFileName(dta[0]), false);
                }

                if (!wiiConversion.Checked)
                {
                    Tools.DeleteFile(projectfolder + "\\" + Path.GetFileName(dta[0]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error moving the DTA file during import, sorry\nThe error says: " + ex.Message, mAppTitle, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            
            //assign values from package
            TextBoxBuildDestination.Text = CleanOutputFile(TextBoxMidiFile.Text.ToLowerInvariant().Replace(".mid,", ""));
            AppendStuffToFilename();
            
            Importing = true;
            var thumb = ProjectFile.DestinationFile + "_thumb.png";
            xPackage.Header.PackageImage.Save(thumb);
            
            getThumb(thumb);
            xPackage.CloseIO();

            Tools.DeleteFolder(extractfolder, true);

            //add one to the existing song version, otherwise it would compile with the old song version
            numVersion.Value = (int)numVersion.Value + 1;

            if (wiiConversion.Checked)
            {
                DoWiiPrep();
            }

            //save project
            var proj = Path.GetDirectoryName(ProjectFile.DestinationFile) + "\\" + Path.GetFileName(ProjectFile.DestinationFile).Replace("v#", "").Replace("_rb3con", "").Replace(".rba", "") + ".rbproj";
            ProjectFile.WriteFile(proj);
            var directoryName = Path.GetDirectoryName(ProjectFile.DestinationFile);
            if (!string.IsNullOrEmpty(directoryName))
            {
               Tools.CurrentFolder = directoryName + "\\";
            }
            saveFix(ProjectFile.GetFilename());
            RefreshWindowTitle(true);
            
            MessageBox.Show("Success!\n\nI extracted the audio, MIDI, album art and DTA files\nThen I converted the album art and loaded it here, selected the " +
                            "MIDI file, processed the DTA as best as I could, and created and saved the Magma project!\n\nAll you have to do now is process" +
                            " the mogg I extracted into wav files I can use...\n\nThe mogg is found at: " + moggpath, mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                     
            if (MessageBox.Show("Do you want me to try and separate the mogg file into separate instrument wav files?", mAppTitle, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SeparateMogg(con, projectfolder +"\\audio\\");
                ProjectFile.WriteFile(proj);
                saveFix(ProjectFile.GetFilename());
                RefreshWindowTitle(true);
                return;
            }

            if (MessageBox.Show("Do you want to send the mogg to Audacity?", mAppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var program = "";
                if (AudacityPath != "" && File.Exists(AudacityPath))
                {
                    program = AudacityPath;
                }
                else
                {
                    if (File.Exists("C:\\Program Files (x86)\\Audacity\\audacity.exe"))
                    {
                        program = "C:\\Program Files (x86)\\Audacity\\audacity.exe";
                    }
                    else if (File.Exists("C:\\Program Files\\Audacity\\audacity.exe"))
                    {
                        program = "C:\\Program Files\\Audacity\\audacity.exe";
                    }
                }
                if (program == "")
                {
                    var openfile = new OpenFileDialog
                    {
                        Filter = "Windows Executable (*.exe)|*.exe",
                        InitialDirectory = Application.StartupPath,
                        Title = "Select Audacity executable",
                        FileName = "audacity"
                    };

                    openfile.ShowDialog();

                    if (openfile.FileName != "")
                    {
                        AudacityPath = openfile.FileName;
                        program = openfile.FileName;
                    }
                    else
                    {
                        Importing = false;
                        return;
                    }
                }

                if (moggpath.Contains("-"))
                {
                    Process.Start(program);
                }
                else
                {
                    Process.Start(program, "\"" + moggpath + "\"");
                }
            }
            Importing = false;
        }

        private void DoWiiPrep()
        {
            WiiWarning = true;
            ComboDrums.SelectedIndex = 0;
            cboEncodingQuality.SelectedIndex = 2; //3 (default)
            EncodingQuality = 3;
            if (!useUniqueNumericSongID.Checked && !string.IsNullOrEmpty(txtSongID.Text))
            {
                txtSongID.Text = txtSongID.Text + "_wii";
            }
            WiiWarning = false;
        }

        private void SeparateMogg(string con, string folder)
        {
            var splitter = new MoggSplitter();
            EnableDisable(false);
            if (!splitter.SplitMogg(con, folder, "allstems", MoggSplitter.MoggSplitFormat.WAV))
            {
                var error = "";
                foreach (var line in splitter.ErrorLog)
                {
                    error = line + "\n";
                }
                MessageBox.Show("Failed to separate mogg file:\n" + error, mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Importing = false;
                EnableDisable(true);
                return;
            }
            CombineDrumsForWii(folder);
            SearchForStems(folder, ".wav");
            EnableDisable(true);
            Importing = false;
            MessageBox.Show("Finished separating mogg file", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CombineDrumsForWii(string folder)
        {
            if (!wiiConversion.Checked || !Directory.Exists(folder)) return;
            var drums = folder + "drums.wav";
            var drums1 = folder + "drums_1.wav";
            var drums2 = folder + "drums_2.wav";
            var drums3 = folder + "drums_3.wav";

            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Handle))
            {
                MessageBox.Show("Error initializing BASS.NET - can't combine drum stems\n" + Bass.BASS_ErrorGetCode());
                return;
            }
            var tracks = new List<string> { drums1, drums2, drums3 };
            var channels = 0;
            BassMixer = BassMix.BASS_Mixer_StreamCreate(44100, 2, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_MIXER_END);
            foreach (var track in tracks.Where(File.Exists))
            {
                BassStream = Bass.BASS_StreamCreateFile(track, 0L, 0L, BASSFlag.BASS_STREAM_DECODE);
                var info = Bass.BASS_ChannelGetInfo(BassStream);
                if (info.chans == 0) continue;
                BassMix.BASS_Mixer_StreamAddChannel(BassMixer, BassStream, BASSFlag.BASS_STREAM_AUTOFREE | BASSFlag.BASS_MIXER_MATRIX);
                var matrix = new float[2, info.chans];
                matrix[0, 0] = 1.0f;
                matrix[1, info.chans == 1 ? 0 : 1] = 1.0f;
                BassMix.BASS_Mixer_ChannelSetMatrix(BassStream, matrix);
                channels += info.chans;
            }
            if (channels == 0) return;
            Tools.DeleteFile(drums);
            BassEnc.BASS_Encode_Start(BassMixer, drums, BASSEncode.BASS_ENCODE_PCM | BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
            while (true)
            {
                var buffer = new byte[20000];
                var c = Bass.BASS_ChannelGetData(BassMixer, buffer, buffer.Length);
                if (c < 0) break;
            }
            try
            {
                Bass.BASS_Free();
            }
            catch (Exception)
            { }
        }

        private void ResampleForWii(string file)
        {
            if (!wiiConversion.Checked || !File.Exists(file)) return;
            try
            {
                Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                Tools.PlayingSongOggData = File.ReadAllBytes(file);
                var inStream = Bass.BASS_StreamCreateFile(Tools.GetOggStreamIntPtr(), 0, Tools.PlayingSongOggData.Length, BASSFlag.BASS_STREAM_DECODE);
                var info = Bass.BASS_ChannelGetInfo(inStream);
                if (info.freq <= 44100)
                {
                    Tools.ReleaseStreamHandle();
                    Bass.BASS_Free();
                    return;
                }
                var mixStream = BassMix.BASS_Mixer_StreamCreate(44100, info.chans, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_MIXER_END);
                BassMix.BASS_Mixer_StreamAddChannel(mixStream, inStream, BASSFlag.BASS_STREAM_AUTOFREE);
                if (mixStream == 0)
                {
                    MessageBox.Show("I wasn't able to read audio file '" + Path.GetFileName(file) + "' so I can't resample it, sorry", mAppTitle, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    Tools.DeleteFile(file);
                    BassEnc.BASS_Encode_Start(mixStream, file, BASSEncode.BASS_ENCODE_PCM | BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
                    while (true)
                    {
                        var buffer = new byte[20000];
                        var c = Bass.BASS_ChannelGetData(mixStream, buffer, buffer.Length);
                        if (c < 0) break;
                    }
                    Tools.ReleaseStreamHandle();
                }
            }
            catch (Exception ex)
            {
                Tools.ReleaseStreamHandle();
                MessageBox.Show("Error resampling audio file '" + Path.GetFileName(file) + "'\nError: " + ex.Message, mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            try
            {
                Bass.BASS_Free();
            }
            catch (Exception)
            { }
        }

        private void SearchForStems(string folder, string ext)
        {
            var drums = folder + "drums" + ext;
            var drums1 = folder + "drums_1" + ext;
            var drums2 = folder + "drums_2" + ext;
            var drums3 = folder + "drums_3" + ext;
            var bass = folder + "bass" + ext;
            var rhythm = folder + "rhythm" + ext;
            var guitar = folder + "guitar" + ext;
            var keys = folder + "keys" + ext;
            var vocals = folder + "vocals" + ext;
            var backing = folder + "backing" + ext;
            var song = folder + "song" + ext;
            var crowd = folder + "crowd" + ext;
            var stems = new List<string>
            {
                drums,drums1,drums2,drums3,bass,rhythm,guitar,keys,vocals,backing,song,crowd
            };
            foreach (var stem in stems)
            {
                ResampleForWii(stem);
            }
            if (File.Exists(drums))
            {
                ComboDrums.SelectedIndex = 0; //kit
                TextBoxDrumKit.Text = drums;
            }
            else if (File.Exists(drums1) && !wiiConversion.Checked)
            {
                TextBoxDrumKick.Text = drums1;
                if (File.Exists(drums2) && File.Exists(drums3))
                {
                    ComboDrums.SelectedIndex = 2; //kick, snare, kit
                    TextBoxDrumSnare.Text = drums2;
                }
                else if (File.Exists(drums2) && !File.Exists(drums3))
                {
                    ComboDrums.SelectedIndex = 1; //asume kick + kit
                    TextBoxDrumKit.Text = drums2;
                }
                if (File.Exists(drums3))
                {
                    TextBoxDrumKit.Text = drums3;
                }
            }
            if (File.Exists(bass))
            {
                TextBoxBass.Text = bass;
            }
            else if (File.Exists(rhythm))
            {
                TextBoxBass.Text = rhythm;
            }
            if (File.Exists(guitar))
            {
                TextBoxGuitar.Text = guitar;
            }
            if (File.Exists(keys))
            {
                TextBoxKeys.Text = keys;
            }
            if (File.Exists(vocals))
            {
                TextBoxVocals.Text = vocals;
            }
            if (File.Exists(backing))
            {
                TextBoxBacking.Text = backing;
            }
            else if (File.Exists(song))
            {
                TextBoxBacking.Text = song;
            }
            if (File.Exists(crowd))
            {
                TextBoxCrowd.Text = crowd;
            }
        }

        private void importCONLIVEFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProjectFile.HasUnsavedChanges())
            {
                if (MessageBox.Show("This feature will create a new project\nYour current project has unsaved changes that will be lost\nAre you sure you want to do that?", mAppTitle,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            var fileDialog = new OpenFileDialog
                {
                    InitialDirectory = Tools.CurrentFolder,
                    Title = "Select a CON or LIVE file..."
                };

            if (fileDialog.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(fileDialog.FileName)) return;
            try
            {
                if (VariousFunctions.ReadFileType(fileDialog.FileName) == XboxFileType.STFS && isValid(fileDialog.FileName))
                {
                    importCON(fileDialog.FileName);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("There was an error accessing that file\nThe error says:\n" + ex.Message, mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string CleanOutputFile(string input)
        {
            var destfile = Path.GetFileNameWithoutExtension(input);

            if (string.IsNullOrEmpty(destfile))
            {
                return input;
            }

            destfile = destfile.Replace("'", "");
            destfile = destfile.Replace(",", "");
            destfile = destfile.Replace(";", "");
            destfile = destfile.Replace("!", "");
            destfile = destfile.Replace("@", "");
            destfile = destfile.Replace("#", "");
            destfile = destfile.Replace("$", "");
            destfile = destfile.Replace("%", "");
            destfile = destfile.Replace("^", "");
            destfile = destfile.Replace("&", "and");
            destfile = destfile.Replace("*", "");
            destfile = destfile.Replace("+", "");
            destfile = destfile.Replace("~", "");
            destfile = destfile.Replace("`", "");
            destfile = destfile.Replace("?", "");
            destfile = destfile.Replace("<", "");
            destfile = destfile.Replace(">", "");
            destfile = destfile.Replace("-", "");
            destfile = destfile.Replace(" ", "");

            if (destfile.Length > 26)
            {
                destfile = destfile.Substring(0, 26);
            }

            if (Path.GetDirectoryName(input) != "")
            {
                return Path.GetDirectoryName(input) + "\\" + destfile;
            }
            return destfile;
        }

        private void importSongsdtaFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Rock Band Metadata (*.dta)|*.dta",
                Title = "Select songs.dta file...",
                InitialDirectory = Tools.CurrentFolder
            };
            if (ofd.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(ofd.FileName)) return;
            loadDTA(ofd.FileName, false);
        }

        private void SetTrackAttenuation(string track_name, NumericUpDown value)
        {
            var track = ProjectFile.GetTrack(track_name);
            track.SetAttenuation((float)value.Value);
            ProjectFile.SetTrack(track);

            RefreshWindowTitle();
        }

        private void NumericDrumKitAttenuation_ValueChanged(object sender, EventArgs e)
        {
            ZeroDrumKit.Visible = NumericDrumKitAttenuation.Value != 0;

            SetTrackAttenuation("drum_kit",(NumericUpDown)sender);
        }

        private void NumericBackingAttenuation_ValueChanged(object sender, EventArgs e)
        {
            ZeroBacking.Visible = NumericBackingAttenuation.Value != 0;

            SetTrackAttenuation("backing", (NumericUpDown)sender);
        }

        private void NumericVocalAttenuation_ValueChanged(object sender, EventArgs e)
        {
            ZeroVocals.Visible = NumericVocalAttenuation.Value != 0;

            SetTrackAttenuation("vocals", (NumericUpDown)sender);
        }

        private void NumericKeysAttenuation_ValueChanged(object sender, EventArgs e)
        {
            ZeroKeys.Visible = NumericKeysAttenuation.Value != 0;

            SetTrackAttenuation("keys", (NumericUpDown)sender);
        }

        private void NumericGuitarAttenuation_ValueChanged(object sender, EventArgs e)
        {
            ZeroGuitar.Visible = NumericGuitarAttenuation.Value != 0;

            SetTrackAttenuation("guitar", (NumericUpDown)sender);
        }

        private void NumericBassAttenuation_ValueChanged(object sender, EventArgs e)
        {
            ZeroBass.Visible = NumericBassAttenuation.Value != 0;

            SetTrackAttenuation("bass", (NumericUpDown)sender);
        }

        private void NumericDrumKickAttenuation_ValueChanged(object sender, EventArgs e)
        {
            ZeroDrumKick.Visible = NumericDrumKickAttenuation.Value != 0;

            SetTrackAttenuation("drum_kick", (NumericUpDown)sender);
        }

        private void NumericDrumSnareAttenuation_ValueChanged(object sender, EventArgs e)
        {
            ZeroDrumSnare.Visible = NumericDrumSnareAttenuation.Value != 0;

            SetTrackAttenuation("drum_snare", (NumericUpDown)sender);
        }

        private void selectAudacityPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = "Windows Executable (*.exe)|*.exe",
                InitialDirectory = Application.StartupPath,
                Title = "Select Audacity Executable"
            };

            fileDialog.ShowDialog();

            if (fileDialog.FileName == "" || fileDialog.FileName.Substring(fileDialog.FileName.Length - 4, 4) != ".exe")
                return;
            AudacityPath = fileDialog.FileName;
        }
        
        private void CheckBoxFromAlbum_CheckedChanged(object sender, EventArgs e)
        {
            ProjectFile.HasAlbum = CheckBoxFromAlbum.Checked;
            SetTextBoxEnabledState(TextBoxAlbumName, CheckBoxFromAlbum.Checked);
            NumericTrackNumber.Enabled = CheckBoxFromAlbum.Checked;
            LabelAlbumName.Enabled = CheckBoxFromAlbum.Checked;
            LabelTrackNumber.Enabled = CheckBoxFromAlbum.Checked;

            RefreshWindowTitle();
        }
        
        private void NumericUpDownYear_ValueChanged(object sender, EventArgs e)
        {
            ProjectFile.YearReleased = (int)NumericUpDownYear.Value;

            RefreshWindowTitle();
        }

        private void NumericTrackNumber_ValueChanged(object sender, EventArgs e)
        {
            ProjectFile.TrackNumber = (int)NumericTrackNumber.Value;

            RefreshWindowTitle();
        }

        private void ComboBoxAutogenTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxAutogenTheme.SelectedIndex.ToString(CultureInfo.InvariantCulture) != "Default" && ComboBoxAutogenTheme.SelectedIndex.ToString(CultureInfo.InvariantCulture) != "")
            {
                ProjectFile.AutogenTheme = ComboBoxAutogenTheme.Items[ComboBoxAutogenTheme.SelectedIndex].ToString().Replace(" ", string.Empty) + ".rbtheme";
                DoShowToast("Venue autogen theme changed to " + ComboBoxAutogenTheme.Items[ComboBoxAutogenTheme.SelectedIndex]);
            }

            RefreshWindowTitle();
        }

        private void ComboBoxGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (refreshing)
            {
                return;
            }
            ProjectFile.Genre = mGenreSymbols[ComboBoxGenre.SelectedIndex];
            RefreshGenres();
            DoShowToast("Genre changed to " + ComboBoxGenre.Items[ComboBoxGenre.SelectedIndex]);

            RefreshWindowTitle();
        }

        private void ComboBoxSubGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (refreshing)
            {
                return;
            } 
            ProjectFile.SubGenre = mSubGenreSymbols[ComboBoxSubGenre.SelectedIndex];
            DoShowToast("Subgenre changed to " + ComboBoxSubGenre.Items[ComboBoxSubGenre.SelectedIndex]);

            RefreshWindowTitle();
        }
        
        private void SetTrackPan(string track_name, NumericUpDown value)
        {
            var track = ProjectFile.GetTrack(track_name);
            track.SetPan((float)value.Value);
            ProjectFile.SetTrack(track);

            RefreshWindowTitle();
        }
        
        private void NumericKeysPan_ValueChanged(object sender, EventArgs e)
        {
            SetTrackPan("keys", (NumericUpDown) sender);
        }
        
        private void NumericGuitarPan_ValueChanged(object sender, EventArgs e)
        {
            SetTrackPan("guitar", (NumericUpDown)sender);
        }
        
        private void NumericBassPan_ValueChanged(object sender, EventArgs e)
        {
            SetTrackPan("bass", (NumericUpDown)sender);
        }
        
        private void NumericVocalPan_ValueChanged(object sender, EventArgs e)
        {
            SetTrackPan("vocals", (NumericUpDown)sender);
        }

        private void NumericDrumKitPan_ValueChanged(object sender, EventArgs e)
        {
            SetTrackPan("drum_kit", (NumericUpDown)sender);
        }
        
        private void NumericDrumSnarePan_ValueChanged(object sender, EventArgs e)
        {
            SetTrackPan("drum_snare", (NumericUpDown)sender);
        }
        
        private void NumericDrumKickPan_ValueChanged(object sender, EventArgs e)
        {
            SetTrackPan("drum_kick", (NumericUpDown)sender);
        }

        private void NumericBackingPan_ValueChanged(object sender, EventArgs e)
        {
            SetTrackPan("backing", (NumericUpDown)sender);
        }

        private void CheckBoxLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (refreshing) return;
            CheckLanguages();
        }

        private void CheckLanguages()
        {
            ProjectFile.LangEnglish = CheckBoxLangEnglish.Checked;
            ProjectFile.LangFrench = CheckBoxLangFrench.Checked;
            ProjectFile.LangItalian = CheckBoxLangItalian.Checked;
            ProjectFile.LangSpanish = CheckBoxLangSpanish.Checked;
            ProjectFile.LangGerman = CheckBoxLangGerman.Checked;
            ProjectFile.LangJapanese = CheckBoxLangJapanese.Checked;

            Language = (CheckBoxLangEnglish.Checked ? "English, " : "") +
                       (CheckBoxLangFrench.Checked ? "French, " : "") +
                       (CheckBoxLangGerman.Checked ? "German, " : "") +
                       (CheckBoxLangItalian.Checked ? "Italian, " : "") +
                       (CheckBoxLangJapanese.Checked ? "Japanese, " : "") +
                       (CheckBoxLangSpanish.Checked ? "Spanish, " : "");
            Language = Language.Trim();
            DoShowToast("Song language(s) changed to " + Language);
            RefreshWindowTitle();
        }

        private bool doSongPreview(bool sanity_check = false)
        {
            //do preview start
            int num1;
            try
            {
                num1 = DomainPreviewSecs.Text.Length <= 0
               ? 0 : Convert.ToInt16(DomainPreviewSecs.Text);
                if (num1 > 59)
                {
                    DomainPreviewSecs.SelectedItem = "00";
                    num1 = 0;
                }
            }
            catch
            {
                DomainPreviewSecs.SelectedItem = "30";
                num1 = 30;
                UGCDebug.ShowOKMsgBox(this, "Invalid preview start seconds value.");
            }
            var num2 = (int)Math.Round(NumericPreviewMins.Value, 0);
            if (num2 != NumericPreviewMins.Value)
            {
                UGCDebug.ShowOKMsgBox(this, "Invalid preview start minutes value.");
                NumericPreviewMins.Value = num2;
            }
            var num3 = (num2 * 60) + num1;
            SongPreview = (num3 * 1000) + (int)numericMilliseconds.Value; //we'll use this when converting to CON
            
            if (num3 < mSongLength - 30)
            {
                if (SongPreview > 570000) //magmacompiler won't accept a number bigger than 9 minutes 30 seconds
                {
                    ProjectFile.PreviewStart = 570000; //let's lie to MagmaCompiler
                }
                else
                {
                    ProjectFile.PreviewStart = (int)SongPreview; //if it's less than 9 minutes 30 seconds don't need to lie
                }
            }
            else
            {
                if (LabelSongLength.Text != "0:00" && !starting && !refreshing && !Importing)
                {
                    MessageBox.Show("Preview start time must be at least 30 seconds before the ending of the song!",
                        mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            //do preview end
            try
            {
                num1 = prevEndSeconds.Text.Length <= 0 ? 0 : Convert.ToInt16(prevEndSeconds.Text);
                if (num1 > 59)
                {
                    prevEndSeconds.SelectedItem = "00";
                    num1 = 0;
                }
            }
            catch
            {
                prevEndSeconds.SelectedItem = "30";
                num1 = 30;
                UGCDebug.ShowOKMsgBox(this, "Invalid preview end seconds value.");
            }
            num2 = (int)Math.Round(prevEndMinutes.Value, 0);
            if (num2 != prevEndMinutes.Value)
            {
                UGCDebug.ShowOKMsgBox(this, "Invalid preview end minutes value.");
                prevEndMinutes.Value = num2;
            }
            num3 = (num2 * 60) + num1;
            PreviewEnd = (num3 * 1000) + (int)prevEndMilliseconds.Value; //we'll use this when converting to CON

            //sanity check
            if (!sanity_check) return true;
            if (PreviewEnd <= SongPreview)
            {
                PreviewEnd = SongPreview + 30000; //default to 30 seconds more
                MessageBox.Show("Invalid values for preview start and preview end detected, please correct before compiling!", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void NumericPreviewMins_ValueChanged(object sender, EventArgs e)
        {
            if (starting || Importing) return;
            StopBASS();
            try
            {
                NumericPreviewMins.Value = Convert.ToInt16(NumericPreviewMins.Value) < 0 ? 0 : Convert.ToInt16(NumericPreviewMins.Value);
            }
            catch
            {
                NumericPreviewMins.Value = 0;
            }
            doSongPreview();
            RefreshWindowTitle();
        }
        
        private void NumericGuidePitchAttenuation_ValueChanged(object sender, EventArgs e)
        {
            ProjectFile.GuidePitchVolume = (float)NumericGuidePitchAttenuation.Value;
            RefreshWindowTitle();
        }

        private void UpdateSongPreview()
        {
            try
            {
                var time = SongPreview / 1000;
                NumericPreviewMins.Value = time / 60;
                var secs = "00" + (time - (NumericPreviewMins.Value * 60)).ToString(CultureInfo.InvariantCulture);
                DomainPreviewSecs.Text = secs.Substring(secs.Length - 2, 2);
                var milliseconds = SongPreview.ToString(CultureInfo.InvariantCulture).Substring(SongPreview.ToString(CultureInfo.InvariantCulture).Length - 3, 3);
                numericMilliseconds.Value = Convert.ToInt32(milliseconds);
            }
            catch
            { }

            try
            {
                var time = PreviewEnd / 1000;
                prevEndMinutes.Value = time / 60;
                var secs = "00" + (time - (prevEndMinutes.Value * 60)).ToString(CultureInfo.InvariantCulture);
                prevEndSeconds.Text = secs.Substring(secs.Length - 2, 2);
                var milliseconds = PreviewEnd.ToString(CultureInfo.InvariantCulture).Substring(PreviewEnd.ToString(CultureInfo.InvariantCulture).Length - 3, 3);
                prevEndMilliseconds.Value = Convert.ToInt32(milliseconds);
            }
            catch
            { }
        }

        private void TextBoxAlbumArt_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxAlbumArt.Text.Length == 0)
            {
                return;
            }

            TextBoxAlbumArt.RightToLeft = TextBoxAlbumArt.Text.Length > 30 ? RightToLeft.Yes : RightToLeft.No;

            try
            {
                if (ProjDir != "" && TextBoxAlbumArt.Text.Contains(ProjDir))
                {
                    TextBoxAlbumArt.Text = TextBoxAlbumArt.Text.Replace(ProjDir, "");
                    return;
                }
                if (TextBoxAlbumArt.Text.Contains(Application.StartupPath + "\\"))
                {
                    TextBoxAlbumArt.Text = TextBoxAlbumArt.Text.Replace(Application.StartupPath + "\\", "");
                    return;
                }

                //work around issues when cut/pasting project folder to another directory
                if (TextBoxAlbumArt.Text != "" && !File.Exists(TextBoxAlbumArt.Text) && !Importing && !File.Exists(ProjDir + TextBoxAlbumArt.Text) && !File.Exists(Application.StartupPath + "\\" + TextBoxAlbumArt.Text))
                {
                    if (File.Exists(ProjDir + Path.GetFileName(TextBoxAlbumArt.Text)))
                    {
                        if (TextBoxAlbumArt.Text != Path.GetFileName(TextBoxAlbumArt.Text))
                        {
                            TextBoxAlbumArt.Text = Path.GetFileName(TextBoxAlbumArt.Text);
                            return;
                        }
                    }
                    try
                    {
                        var folder = Path.GetDirectoryName(TextBoxAlbumArt.Text);
                        if (folder != null)
                        {
                            var parent = Directory.GetParent(folder);
                            var subfolder = TextBoxAlbumArt.Text.Replace(parent + "\\", "");
                            if (File.Exists(ProjDir + subfolder))
                            {
                                TextBoxAlbumArt.Text = subfolder;
                                return;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //
                    }
                }

                var str = "";
                SongAlbumArt = "";
                var variations = new List<string>
                {
                    ProjDir + TextBoxAlbumArt.Text,
                    ProjDir + Path.GetFileName(TextBoxAlbumArt.Text),
                    Application.StartupPath + "\\" + TextBoxAlbumArt.Text,
                    Application.StartupPath + "\\" + Path.GetFileName(TextBoxAlbumArt.Text),
                    TextBoxAlbumArt.Text
                };
                var found = false;
                foreach (var variation in variations.Where(File.Exists))
                {
                    found = true;
                    str = variation;
                    break;
                }
                if (!found)
                {
                    ErrorProviderCharCheck.SetError(TextBoxAlbumArt, "Can't find that image file");
                    return;
                }

                SongAlbumArt = str;
                ErrorProviderCharCheck.SetError(TextBoxAlbumArt, "");

                ChangeAlbumArt();
                Tools.CurrentFolder = Path.GetDirectoryName(str) + "\\";
                DoShowToast("Album art changed...");

                RefreshWindowTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error accessing that image file\n\nThe error says:\n" + ex.Message + "\n\nTry again",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ChangeAlbumArt()
        {
            var file = Path.GetDirectoryName(SongAlbumArt) + "\\" + Path.GetFileNameWithoutExtension(SongAlbumArt);
            var bmp = file + "_x256.bmp";
            var xbox = file + ".png_xbox";
            var png = file + ".png";

            if (SongAlbumArt.ToLowerInvariant() != mDefaultAlbumArtPath.ToLowerInvariant() && 
               (Application.StartupPath + "\\" + SongAlbumArt).ToLowerInvariant() != mDefaultAlbumArtPath.ToLowerInvariant())
            {
                if (SongAlbumArt == xbox && (!File.Exists(png) || !refreshing))
                {
                    Tools.DeleteFile(png);
                    if (!Tools.ConvertRBImage(SongAlbumArt, png))
                    {
                        FailedAlbumArt();
                        return;
                    }
                }

                if (!File.Exists(xbox))
                {
                    Tools.TextureSize = 512;
                    if (x256.Checked)
                    {
                        Tools.TextureSize = 256;
                    }
                    else if (x1024.Checked)
                    {
                        Tools.TextureSize = 1024;
                    }
                    else if (x2048.Checked)
                    {
                        Tools.TextureSize = 2048;
                    }
                    Tools.ConvertImagetoRB(SongAlbumArt, xbox);
                }

                if (!File.Exists(bmp) && !File.Exists(png) && SongAlbumArt == xbox)
                {
                    FailedAlbumArt();
                    return;
                }
                
                if ((!File.Exists(bmp) || !refreshing) && !Tools.CreateAlbumArt(SongAlbumArt == xbox? png : SongAlbumArt, bmp))
                {
                    FailedAlbumArt();
                    return;
                }

                ProjectFile.AlbumArt = bmp;
                PictureBoxAlbumArt.Image = Tools.NemoLoadImage(SongAlbumArt == xbox ? (File.Exists(png) ? png : bmp): SongAlbumArt);
            }
            else
            {
                ProjectFile.AlbumArt = mDefaultAlbumArtPath;
                PictureBoxAlbumArt.Image = Tools.NemoLoadImage(mDefaultAlbumArtPath);
            }

            if (string.IsNullOrEmpty(PackageThumb))
            {
                picThumb.Image = PictureBoxAlbumArt.Image;
            }
            DoShowToast("Album art loaded successfully");
        }

        private void FailedAlbumArt()
        {
            ProjectFile.AlbumArt = mDefaultAlbumArtPath;
            PictureBoxAlbumArt.Image = Tools.NemoLoadImage(mDefaultAlbumArtPath);
            if (string.IsNullOrEmpty(PackageThumb))
            {
                picThumb.Image = PictureBoxAlbumArt.Image;
            }
            DoShowToast("Failed to convert album art, using default");
        }

        private void TextBoxDryVocals_TextChanged(object sender, EventArgs e)
        {
            var box = (TextBox) sender;
            if (box.Text != "")
            {
                GetAudioFile((TextBox)sender);
            }
        }

        private void numericVocalMute_ValueChanged(object sender, EventArgs e)
        {
            VocalMuteVol = (int)numericVocalMute.Value;
            RefreshWindowTitle();
        }

        private void numericMuteVol_ValueChanged(object sender, EventArgs e)
        {
            MuteVol = (int)numericMuteVol.Value;
            RefreshWindowTitle();
        }

        private void ComboVocalGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectFile.Gender = mGenderSymbols[ComboVocalGender.SelectedIndex];
            DoShowToast("Vocalist gender changed to " + ComboVocalGender.Items[ComboVocalGender.SelectedIndex]);
            RefreshWindowTitle();
        }

        private void ComboVocalPercussion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectFile.Percussion = mPercussionSymbols[ComboVocalPercussion.SelectedIndex];
            DoShowToast("Percussion instrument changed to " + ComboVocalPercussion.Items[ComboVocalPercussion.SelectedIndex]);
            RefreshWindowTitle();
        }

        private void ComboAnimationSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            var animTempos = new int[] { 16, 24, 32, 48, 64 };
            ProjectFile.Tempo = animTempos[ComboAnimationSpeed.SelectedIndex];
            animTempo = ProjectFile.Tempo;
            DoShowToast("Animation speed changed to " + ComboAnimationSpeed.Items[ComboAnimationSpeed.SelectedIndex]);
            //ProjectFile.Tempo = mAnimationSpeeds[ComboAnimationSpeed.SelectedIndex];
            //DoShowToast("Animation speed changed to " + ComboAnimationSpeed.Items[ComboAnimationSpeed.SelectedIndex]);
            RefreshWindowTitle();
        }

        private void ComboVocalScroll_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboVocalScroll.SelectedIndex)
            {
                case 0:
                    ProjectFile.ScrollSpeed = 3000;
                    break;
                case 1:
                    ProjectFile.ScrollSpeed = 2750;
                    break;
                case 2:
                    ProjectFile.ScrollSpeed = 2600;
                    break;
                case 3:
                    ProjectFile.ScrollSpeed = 2450;
                    break;
                case 4:
                    ProjectFile.ScrollSpeed = 2300;
                    break;
                case 5:
                    ProjectFile.ScrollSpeed = 2150;
                    break;
                case 6:
                    ProjectFile.ScrollSpeed = 2000;
                    break;
                case 7:
                    ProjectFile.ScrollSpeed = 1850;
                    break;
                case 8:
                    ProjectFile.ScrollSpeed = 1700;
                    break;
                default:
                    ProjectFile.ScrollSpeed = 2300;
                    break;
            }

            DoShowToast("Vocal scroll speed changed to " + ComboVocalScroll.Items[ComboVocalScroll.SelectedIndex]);
            RefreshWindowTitle();
        }

        private void TextBoxDryVocals_EnabledChanged(object sender, EventArgs e)
        {
            ButtonDryVocals.Visible = TextBoxDryVocals.Enabled;
        }

        private void TextBoxDryVocalsHarmony2_EnabledChanged(object sender, EventArgs e)
        {
            ButtonDryVocalsHarmony2.Visible = TextBoxDryVocalsHarmony2.Enabled;
        }

        private void TextBoxDryVocalsHarmony3_EnabledChanged(object sender, EventArgs e)
        {
            ButtonDryVocalsHarmony3.Visible = TextBoxDryVocalsHarmony3.Enabled;
        }

        private void TextCrowd_EnabledChanged(object sender, EventArgs e)
        {
            btnCrowd.Visible = TextBoxCrowd.Enabled;

            if (TextBoxCrowd.Enabled) return;
            LabelCrowdPan.Visible = false;
            numericCrowd.Visible = false;
        }

        private void ComboDrums_EnabledChanged(object sender, EventArgs e)
        {
            ComboDrums_SelectedIndexChanged(sender, e);
        }

        private void numericCrowd_ValueChanged(object sender, EventArgs e)
        {
            CrowdVol = (int) numericCrowd.Value;

            ZeroCrowd.Visible = numericCrowd.Value != 0;

            RefreshWindowTitle();
        }

        private void Mono44SilenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveTextBox.Text = SilenceMono44;
        }

        private void Mono48SilenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveTextBox.Text = SilenceMono48;
        }

        private void Stereo44SilenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveTextBox.Text = SilenceStereo44;
        }

        private void Stereo48SilenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveTextBox.Text = SilenceStereo48;
        }

        private void use48KHzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            use441KHzToolStripMenuItem.Checked = false;
            use441KHz24bitToolStripMenuItem.Checked = false;
            use48KHz24bitToolStripMenuItem.Checked = false;
            DoShowToast("Will use 48kHz 16-bit silence tracks by default"); use48KHzToolStripMenuItem.Checked = true;
        }

        private void use441KHzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            use48KHzToolStripMenuItem.Checked = false;
            use441KHzToolStripMenuItem.Checked = true;
            use441KHz24bitToolStripMenuItem.Checked = false;
            use48KHz24bitToolStripMenuItem.Checked = false;
            DoShowToast("Will use 44.1kHz 16-bit silence tracks by default");
        }

        private void useSilenceTracksByDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            use441KHzToolStripMenuItem.Enabled = useSilenceTracksByDefault.Checked;
            use48KHzToolStripMenuItem.Enabled = useSilenceTracksByDefault.Checked;
            DoShowToast("Will " + (useSilenceTracksByDefault.Checked ? "" : "not") + " use silence tracks by default");
        }
        
        private void picAuthor_MouseLeave(object sender, EventArgs e)
        {
            picAuthor.BorderStyle = BorderStyle.None;
        }

        private void picAuthor_MouseHover(object sender, EventArgs e)
        {
            picAuthor.BorderStyle = BorderStyle.Fixed3D;
        }
        
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveTextBox.Text = null;
            ErrorProviderCharCheck.SetError(ActiveTextBox, "");
        }
        
        private void LabelDrumKitPan_VisibleChanged(object sender, EventArgs e)
        {
            doDrumMix();
        }
        
        private void contextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            blankDryvoxFileToolStripMenuItem.Enabled = false;

            //replace with MenuSource(sender, false)
            var enabled = ActiveTextBox.Text == "";
            clearToolStripMenuItem.Enabled = !enabled;
            copyToolStripMenuItem.Enabled = !enabled;

            copyLeadDryVocalsHere.Visible = (ActiveTextBox.Name == "TextBoxDryVocalsHarmony2" ||
                                            ActiveTextBox.Name == "TextBoxDryVocalsHarmony3") && !string.IsNullOrEmpty(TextBoxDryVocals.Text);
            convertVocalsStemToDryvox.Visible = ActiveTextBox.Name == "TextBoxDryVocals" && !string.IsNullOrEmpty(TextBoxVocals.Text);

            enabled = Clipboard.GetText() != "";
            pasteToolStripMenuItem.Enabled = enabled;

            enabled = ActiveTextBox.Name == "TextBoxDrumKit";
            Mono44SilenceToolStripMenuItem.Enabled = !enabled;
            Mono48SilenceToolStripMenuItem.Enabled = !enabled;
            Mono44Silence24.Enabled = !enabled;
            Mono48Silence24.Enabled = !enabled;
            Stereo48SilenceToolStripMenuItem.Enabled = enabled;
            Stereo44SilenceToolStripMenuItem.Enabled = enabled;
            Stereo44Silence24.Enabled = enabled;
            Stereo48Silence24.Enabled = enabled;
            
            if (enabled)
            {
                return;
            }

            enabled = ActiveTextBox.Name == "TextCrowd" ||
                          ActiveTextBox.Name == "TextBoxBacking" ||
                          ActiveTextBox.Name == "TextBoxDryVocals" ||
                          ActiveTextBox.Name == "TextBoxDryVocalsHarmony2" ||
                          ActiveTextBox.Name == "TextBoxDryVocalsHarmony3";

            Mono44SilenceToolStripMenuItem.Enabled = !enabled;
            Mono48SilenceToolStripMenuItem.Enabled = !enabled;
            Stereo44SilenceToolStripMenuItem.Enabled = !enabled;
            Stereo48SilenceToolStripMenuItem.Enabled = !enabled;
            Mono44Silence24.Enabled = !enabled;
            Mono48Silence24.Enabled = !enabled;
            Stereo44Silence24.Enabled = !enabled;
            Stereo48Silence24.Enabled = !enabled;
            
            enabled = ActiveTextBox.Name == "TextBoxDryVocals" || ActiveTextBox.Name == "TextBoxDryVocalsHarmony2" ||
                          ActiveTextBox.Name == "TextBoxDryVocalsHarmony3";

            blankDryvoxFileToolStripMenuItem.Enabled = enabled;
        }

        private void DomainPreviewSecs_Leave(object sender, EventArgs e)
        {
            if (starting || Importing) return;
            StopBASS();
            if (DomainPreviewSecs.Text == "60")
            {
                DomainPreviewSecs.SelectedItem = "00";
            }
            if (DomainPreviewSecs.Text == "-1")
            {
                DomainPreviewSecs.SelectedItem = "59";
            }

            try
            {
                if (Convert.ToInt32(DomainPreviewSecs.Text) < 0)
                {
                    DomainPreviewSecs.SelectedItem = "00";
                }
                if (DomainPreviewSecs.Text.Length > 2)
                {
                    DomainPreviewSecs.SelectedItem = "59";
                }
            }
            catch
            {
                DomainPreviewSecs.SelectedItem = "00";
            }

            DomainPreviewSecs.SelectedItem = DomainPreviewSecs.Text.PadLeft(2, '0');
            doSongPreview();
            RefreshWindowTitle();
        }
        
        private void chkTempo_CheckedChanged(object sender, EventArgs e)
        {
            if (ProjectFile.DestinationFile != "")
            {
                RefreshWindowTitle();
            }
            DoShowToast("This song will " + (chkTempo.Checked? "" : "not") + " be checked for a tempo map");
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            picThumb.Image = PictureBoxAlbumArt.Image;
            PackageThumb = "";
            RefreshWindowTitle();
        }

        private void picThumb_DragDrop(object sender, DragEventArgs e)
        {
            var file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

            if (file.EndsWith(".jpg", StringComparison.Ordinal) || file.EndsWith(".png", StringComparison.Ordinal) 
                || file.EndsWith(".bmp", StringComparison.Ordinal) || file.EndsWith(".tif", StringComparison.Ordinal))
            {
                getThumb(file);
            }
            else
            {
                MessageBox.Show("That's not a valid image format to drop here", mAppTitle, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            Tools.CurrentFolder = Path.GetDirectoryName(file) + "\\";
        }

        private void ZeroCrowd_Click(object sender, EventArgs e)
        {
            numericCrowd.Value = 0;
        }
                
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ActiveTextBox.Text);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveTextBox.Text = Clipboard.GetText();
        }

        private void chkDrumsMix_CheckedChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();
            DoShowToast("Drum mixes will " + (chkDrumsMix.Checked ? "" : "not") + " be added to the MIDI file");
        }

        private void neverCheckForTempoMap_Click(object sender, EventArgs e)
        {
            if (neverCheckForTempoMap.Checked && MessageBox.Show("WARNING ..... WARNING ..... WARNING ..... WARNING ..... WARNING\n\nThe vast majority of songs DO NOT have a fixed tempo map\n\nIf you disable this check, I will NEVER check your songs for possible missing tempo map and you may end up with song that got exported without its tempo map in REAPER\n\nInstead of disabling it here, you can disable it on a song-by-song basis in the 'Game Data' screen for songs that you know have a fixed tempo map. That way I won't nag you for those songs, but I will for a song that should have a tempo map but is missing it\n\nSo, are you sure to want me to NEVER check for tempo map?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                neverCheckForTempoMap.Checked = false;
            }
            else
            {
                chkTempo.Checked = !neverCheckForTempoMap.Checked;
                chkTempo.Enabled = !neverCheckForTempoMap.Checked;
            }
            DoShowToast("Checking for tempo map " + (neverCheckForTempoMap.Checked ? " disabled" : "enabled"));
        }

        private void SkinLabels(Color color, int type)
        {
            var newfont = new Font(LabelSongName.Font, FontStyle.Regular);

            var labels = new[]
                {
                    LabelMIDI, LabelAutogenTheme, LabelAnimationSpeed, LabelHopoThreshold, LabelPercussion, LabelVocalGender, LabelVocalScroll,
                    LabelVocalGuidePitch, LabelTuningCents, LabelMuteVolume, LabelMuteVolumeVocals, LabelSongRating,
                    LabelGuitarTuning, LabelBassTuning, LabelDrumKitSFX, LabelBuildTo, LabelDrums, LabelDrumKit, LabelDrumKick, LabelDrumSnare,
                    LabelGuitar, LabelBass, LabelKeys, LabelVocals, LabelDryVocals, LabelDryVocalsHarmony2, LabelDryVocalsHarmony3, LabelBacking,
                    LabelCrowd, LabelCrowdPan, LabelLength, LabelSongLength, LabelStartPreview, lblDrumMix, label29, label30, LabelGuitarPan,
                    LabelBassPan, LabelKeysPan, LabelBackingPan, LabelDrumKickPan, LabelDrumKitPan, LabelDrumSnarePan, LabelVocalPan,
                    LabelEncodingQuality, LabelSongName, LabelArtist, LabelAlbumName, LabelLanguages, LabelGenre, LabelSubgenre,
                    LabelYearReleased, LabelAuthor, label1, label2, LabelTrackNumber, LabelReRecording, LabelPreviewSeparator, label3,
                    LabelSolos, LabelEndPreview, LabelBandFail, label5, label6
                };

            foreach (var label in labels)
            {
                switch (type)
                {
                    case 0:
                        label.BackColor = color;
                        break;
                    case 1:
                        label.ForeColor = color;
                        break;
                }
                label.Font = newfont;
            }

            var checkboxes = new[]
                {
                    CheckBoxLangEnglish, CheckBoxLangFrench, CheckBoxLangGerman, CheckBoxLangItalian, CheckBoxLangJapanese,
                    CheckBoxLangSpanish, chkReRecord, chkMaster, CheckBoxFromAlbum, chkTempo, chkKeysAnim, chkAutoKeys, chkDrumsMix,
                    chkSoloDrums, chkSoloGuitar,chkSoloBass, chkSoloKeys, chkSoloVocals, chkTonicNote, chkAuthorDTA, chkTonality
                };

            foreach (var checkbox in checkboxes)
            {
                switch (type)
                {
                    case 0:
                        checkbox.BackColor = color;
                        break;
                    case 1:
                        checkbox.ForeColor = color;
                        break;
                }
                checkbox.Font = newfont;
            }

            switch (type)
            {
                case 0:
                    SkinDifficultyLabels(color, 0);
                    break;
                case 1:
                    SkinDifficultyLabels(color, 1);
                    break;
            }     
        }

        private void SkinTextBoxes(Color color, int type)
        {
            var textboxes = new[]
                {
                    TextBoxMidiFile, txtSongID, GuitarTuning1, GuitarTuning2, GuitarTuning3, GuitarTuning4, GuitarTuning5,
                    GuitarTuning6, BassTuning1, BassTuning2, BassTuning3, BassTuning4, TextBoxBuildDestination,
                    TextBoxSongName, TextBoxArtistName, TextBoxAuthor, txtTitleDisplay, txtDescription, TextBoxAlbumArt, 
                    TextBoxBuildDestination, TextBoxAlbumName, TextBoxGuitar,TextBoxBacking,TextBoxBass,TextBoxVocals,TextBoxKeys,TextBoxCrowd,
                    TextBoxDrumKick,TextBoxDrumKit,TextBoxDrumSnare, TextBoxDryVocals,TextBoxDryVocalsHarmony2,TextBoxDryVocalsHarmony3
                };
            
            foreach (var textbox in textboxes)
            {
                switch (type)
                {
                    case 0:
                        mTextBoxEnabledBackColor = color;
                        SkinTextBoxBackgroundColor = color;
                        textbox.BackColor = textbox.Enabled ? color : mTextBoxDisabledBackColor;
                        break;
                    case 1:
                        textbox.ForeColor = color;
                        SkinTextBoxTextColor = color;
                        break;
                    case 2:
                        mTextBoxDisabledBackColor = color;
                        textbox.BackColor = textbox.Enabled ? SkinTextBoxBackgroundColor : color;
                        break;
                }
            }
        }

        private void SkinToDoStuff(Color color, int type)
        {
            var item = ActiveItem; //save it to put back after we skin the boxes

            for (var i = 0; i < 15; i++)
            {
                ActiveItem = i;
                if (!ToDoCompleted[i] && !ToDoImportant[i])
                {
                    switch (type)
                    {
                        case 0:
                            getActiveTextBox().BackColor = color;
                            GetActiveListBox().BackColor = color;
                            break;
                        case 1:
                            getActiveTextBox().ForeColor = color;
                            GetActiveListBox().ForeColor = color;
                            break;
                    }
                }
                else
                {
                    UpdateToDoStuff();
                }
            }

            ActiveItem = item;
        }

        private void SkinComboBoxes(Color color, int type)
        {
            var comboboxes = new[]
                {
                    ComboBoxAutogenTheme, ComboAnimationSpeed, ComboHopo, ComboVocalGender, ComboVocalPercussion, ComboVocalScroll,
                    ComboTonicNote, ComboRating, ComboDrumSFX, ComboDrums, ComboBoxGenre, ComboBoxSubGenre
                };
            
            foreach (var combobox in comboboxes)
            {
                switch (type)
                {
                    case 0:
                        combobox.BackColor = color;
                        break;
                    case 1:
                        combobox.ForeColor = color;
                        break;
                }
            }
        }

        private void SkinComboBoxesStyle(FlatStyle style)
        {
            var comboboxes = new[]
                {
                    ComboBoxAutogenTheme, ComboAnimationSpeed, ComboHopo, ComboVocalGender, ComboVocalPercussion, ComboVocalScroll,
                    ComboTonicNote, ComboRating, ComboDrumSFX, ComboDrums, ComboBoxGenre, ComboBoxSubGenre
                };

            foreach (var combobox in comboboxes)
            {
                combobox.FlatStyle = style;
            }
        }

        private void SkinDifficultyLabels(Color color, int type)
        {
            var labels = new[]
                {
                    LabelDrumDifficulty, LabelBassDifficulty, LabelProBass, LabelProGuitar, LabelGuitarDifficulty,
                    LabelKeysDifficulty, LabelProKeysDifficulty, LabelVocalDifficulty, LabelBandDifficulty
                };

            foreach (var label in labels)
            {
                switch (type)
                {
                    case 0:
                        label.BackColor = color;
                        break;
                    case 1:
                        label.ForeColor = color;
                        break;
                }
            }
        }

        private void SkinNumerics(Color color, int type)
        {
            var numerics = new[]
                {
                    numericVocalMute, numericMuteVol, NumericGuidePitchAttenuation, numericTuningCents, numericCrowd, NumericBackingAttenuation, numericMilliseconds,
                    NumericGuitarAttenuation, NumericBassAttenuation, NumericVocalAttenuation, NumericKeysAttenuation, NumericDrumKickAttenuation, numVersion,
                    NumericDrumKitAttenuation, NumericDrumSnareAttenuation, NumericPreviewMins, NumericGuitarPan, NumericBassPan, NumericDrumKickPan,
                    NumericDrumKitPan, NumericDrumSnarePan, NumericKeysPan, NumericVocalPan, NumericBackingPan, NumericUpDownYear, numericReRecord, NumericTrackNumber
                };

            foreach (var numeric in numerics)
            {
                switch (type)
                {
                    case 0:
                        numeric.BackColor = color;
                        cboEncodingQuality.BackColor = color;
                        DomainPreviewSecs.BackColor = color;
                        break;
                    case 1:
                        numeric.ForeColor = color;
                        cboEncodingQuality.ForeColor = color;
                        DomainPreviewSecs.ForeColor = color;
                        break;
                }
            }
        }

        private void SkinFooterButtons(Color color)
        {
            ButtonBuildTo.BackgroundImage = null;
            ButtonBuildTo.BackColor = color;
            ButtonBuildSong.BackgroundImage = null;
            ButtonBuildSong.BackColor = color;
            SkinButtonBackgroundColor = color;
        }

        private void SkinButtonText(Color color)
        {
            var buttons = new[]
                {
                    ButtonBrowseForMIDI, ButtonExportMIDI, ButtonGuitar, ButtonBass, ButtonKeys, ButtonVocals,
                    ButtonBacking, ButtonDrumKick, ButtonDrumKit, ButtonDrumSnare, ButtonDryVocals,
                    ButtonDryVocalsHarmony2, ButtonDryVocalsHarmony3, btnCrowd, btnDispDLC, btnDispDefault,
                    btnDescDefault, ButtonAlbumArt, ButtonClearAlbumArt,btnPlay,
                    ButtonBuildSong, btnTester, btnCleaner, ButtonInformationTab, ButtonGameDataTab, ButtonAudioTab, ButtonBuildTo
                };

            foreach (var button in buttons)
            {
                button.ForeColor = color;
            }
            SkinButtonTextColor = color;
        }

        private void SkinGroupBoxes(Color color, int type)
        {
            var groupboxes = new[] {GroupBoxDifficulty, groupID, groupBox1, groupBox2, groupDrumMix};

            foreach (var groupbox in groupboxes)
            {
                switch (type)
                {
                    case 0:
                        groupbox.BackColor = color;
                        break;
                    case 1:
                        groupbox.ForeColor = color;
                        break;
                }
            }
        }

        private void SkinFooter(Color color)
        {
            PanelFooter.BorderStyle = BorderStyle.FixedSingle;
            PanelFooter.BackgroundImage = null;
            PanelFooter.BackColor = color;
            pictureBox9.Visible = false;
        }

        private void SkinTabAudio(Color color)
        {
            TabPageAudio.BackgroundImage = null;
            TabPageAudio.BackColor = color;
        }

        private void SkinTabButtonAudio(Color color)
        {
            ButtonAudioTab.BackColor = color;
        }

        private void SkinTabData(Color color)
        {
            TabPageGameData.BackgroundImage = null;
            TabPageGameData.BackColor = color;
        }

        private void SkinTabButtonData(Color color)
        {
            ButtonGameDataTab.BackColor = color;
        }

        private void SkinTabInfo(Color color)
        {
            TabPageInformation.BackgroundImage = null;
            TabPageInformation.BackColor = color;
        }
        
        private void SkinTabButtonInfo(Color color)
        {
            ButtonInformationTab.BackColor = color;
        }

        private void SkinInfoButtons(Color color)
        {
            ButtonClearAlbumArt.BackgroundImage = null;
            ButtonAlbumArt.BackgroundImage = null;
            btnDispDLC.BackgroundImage = null;
            btnDescDefault.BackgroundImage = null;
            btnDispDefault.BackgroundImage = null;

            btnDispDLC.BackColor = color;
            btnDispDefault.BackColor = color;
            btnDescDefault.BackColor = color;
            ButtonAlbumArt.BackColor = color;
            ButtonClearAlbumArt.BackColor = color;
        }

        private void SkinAudioButtons(Color color)
        {
            var buttons = new[]
                {
                    ButtonGuitar, ButtonBass, ButtonKeys, ButtonVocals, ButtonBacking, ButtonDrumKick, ButtonDrumKit,
                    ButtonDrumSnare, ButtonVocals, ButtonDryVocals, ButtonDryVocalsHarmony2, ButtonDryVocalsHarmony3,
                    btnCrowd, ZeroBacking,ZeroGuitar, ZeroBass, ZeroKeys,ZeroVocals,ZeroDrumKick,ZeroDrumKit,ZeroDrumSnare,ZeroCrowd, btnPlay
                };

            foreach (var button in buttons)
            {
                button.BackgroundImage = null;
                button.BackColor = color;
            }
        }

        private void SkinDataButtons(Color color)
        {
            ButtonBrowseForMIDI.BackColor = color;
            ButtonBrowseForMIDI.BackgroundImage = null;
            ButtonExportMIDI.BackColor = color;
            ButtonExportMIDI.BackgroundImage = null;
            btnTester.BackgroundImage = null;
            btnTester.BackColor = color;
            btnCleaner.BackgroundImage = null;
            btnCleaner.BackColor = color;
            btnID.BackgroundImage = null;
            btnID.BackColor = color;
        }

        private void useOGSkin()
        {
            SkinDefaults();
            UpdateSkinnedPips();
            PictureBoxMagmaLogoTop.Image = Resources.magma_logo_sized_colorful;
            todoPic.Image = Resources.todo_color;

            //group boxes
            SkinGroupBoxes(Color.Transparent, 0);
            SkinGroupBoxes(Color.Black, 1);

            //button styles
            SkinButtonStyles(FlatStyle.Flat);

            mTabOffColor = Color.DimGray;
            mTabOnColor = Color.White;
            mTabHoverColor = Color.White;

            UpdateSkinnedTabButtons();

            SkinTabData(SystemColors.GradientInactiveCaption);
            SkinTabButtonData(Color.FromArgb(230, 216, 0));
            SkinDataButtons(Color.FromArgb(230, 216, 0));

            SkinTabAudio(SystemColors.GradientInactiveCaption);
            SkinTabButtonAudio(Color.FromArgb(196, 33, 34));
            SkinAudioButtons(Color.FromArgb(196, 33, 34));

            SkinTabInfo(SystemColors.GradientInactiveCaption);
            SkinInfoButtons(Color.FromArgb(27, 178, 37));
            SkinTabButtonInfo(Color.FromArgb(27, 178, 37));

            //button text color
            SkinButtonText(Color.White);

            //footer
            SkinFooter(SystemColors.GradientInactiveCaption);

            //labels
            SkinLabels(Color.Black, 1);
            SkinLabels(Color.Transparent, 0);

            //text boxes
            SkinTextBoxes(Color.White, 0);
            SkinTextBoxes(Color.Black, 1);

            //combo boxes
            SkinComboBoxesStyle(FlatStyle.Flat);
            SkinComboBoxes(Color.White, 0);
            SkinComboBoxes(Color.Black, 1);

            //numeric updowns
            SkinNumerics(Color.White, 0);
            SkinNumerics(Color.Black, 1);

            mMenuHighlight = Color.FromArgb(239, 106, 5);
            mMenuBackground = Color.FromArgb(39, 85, 196);
            mMenuText = Color.White;
            mMenuBorder = Color.FromArgb(239, 106, 5);
            menuStrip1.Renderer = new DarkRenderer();
            SkinMenu(mMenuBackground, 0);
            SkinMenu(mMenuText, 1);

            //buttons global
            SkinFooterButtons(Color.FromArgb(39, 85, 196));
        }

        private void useColorfulSkin()
        {
            SkinDefaults();
            UpdateSkinnedPips();
            PictureBoxMagmaLogoTop.Image = Resources.magma_logo_sized_colorful;
            todoPic.Image = Resources.todo_color;

            //group boxes
            SkinGroupBoxes(Color.Transparent, 0);
            SkinGroupBoxes(Color.Black, 1);
            
            //button styles
            SkinButtonStyles(FlatStyle.Flat);

            mTabOffColor = Color.DimGray;
            mTabOnColor = Color.White;
            mTabHoverColor = Color.White;

            UpdateSkinnedTabButtons();

            SkinTabData(SystemColors.GradientInactiveCaption);
            SkinTabButtonData(Color.FromArgb(230, 216, 0));
            SkinDataButtons(Color.FromArgb(230, 216, 0));

            SkinTabAudio(SystemColors.GradientInactiveCaption);
            SkinTabButtonAudio(Color.FromArgb(196, 33, 34));
            SkinAudioButtons(Color.FromArgb(196, 33, 34));

            SkinTabInfo(SystemColors.GradientInactiveCaption);
            SkinInfoButtons(Color.FromArgb(27, 178, 37));
            SkinTabButtonInfo(Color.FromArgb(27, 178, 37));
            
            //button text color
            SkinButtonText(Color.White);

            //footer
            SkinFooter(SystemColors.GradientInactiveCaption);

            //labels
            SkinLabels(Color.Black, 1);
            SkinLabels(Color.Transparent, 0);

            //text boxes
            SkinTextBoxes(Color.White,0);
            SkinTextBoxes(Color.Black,1);

            //combo boxes
            SkinComboBoxesStyle(FlatStyle.Flat);
            SkinComboBoxes(Color.White,0);
            SkinComboBoxes(Color.Black,1);
            
            //numeric updowns
            SkinNumerics(Color.White,0);
            SkinNumerics(Color.Black, 1);

            mMenuHighlight = Color.FromArgb(239,106,5);
            mMenuBackground = Color.FromArgb(39, 85, 196);
            mMenuText = Color.White;
            mMenuBorder = Color.FromArgb(239, 106, 5);
            menuStrip1.Renderer = new DarkRenderer();
            SkinMenu(mMenuBackground,0);
            SkinMenu(mMenuText, 1);
            
            //buttons global
            SkinFooterButtons(Color.FromArgb(39, 85, 196));
        }

        private void SkinHeader(Color color)
        {
            PanelHeader.BackgroundImage = null;
            PictureBoxMagmaLogoTop.BackgroundImage = null;
            PictureBoxMagmaLogoTop.Image = null;
            PanelHeader.BackColor = color;
        }

        private void SkinBackground(Color color)
        {
            BackColor = color;
            BackgroundImage = null;
            TopLevelTabs.BackColor = color;
            SkinFormBackgroundColor = color;
        }

        private void SkinDefaults()
        {
            SkinBackground(SystemColors.GradientInactiveCaption);
            SkinHeader(SystemColors.GradientInactiveCaption);
            PictureBoxMagmaLogoTop.BackgroundImage = null;

            ToDoForeColor = Color.Black;
            ToDoBackColor = Color.White;

            SkinToDoStuff(ToDoBackColor, 0);
            SkinToDoStuff(ToDoForeColor,1);

            PipDevil = Resources.pip_devil;
            PipDevilOff = Resources.pip_devil_disabled;
            PipOff = Resources.pip_off;
            PipOn = Resources.pip_on;
            PipDisabledOff = Resources.pip_disabled;
            PipDisabledOn = Resources.pip_disabled;
        }

        private void UpdateSkinnedPips()
        {
            UpdateDifficultyDisplayNEMO(PictureDrumDifficulty1, ProjectFile.RankDrum, CheckDrums.Checked);
            UpdateDifficultyDisplayNEMO(PictureBassDifficulty1, ProjectFile.RankBass, CheckBass.Checked);
            UpdateDifficultyDisplayNEMO(PictureGuitarDifficulty1, ProjectFile.RankGuitar, CheckGuitar.Checked);
            UpdateDifficultyDisplayNEMO(PictureKeysDifficulty1, ProjectFile.RankKeys, CheckKeys.Checked);
            UpdateDifficultyDisplayNEMO(PictureProKeysDifficulty1, ProjectFile.RankProKeys, chkProKeys.Checked);
            UpdateDifficultyDisplayNEMO(PictureVocalDifficulty1, ProjectFile.RankVocals, CheckVocals.Checked);
            UpdateDifficultyDisplayNEMO(PictureProGuitarDifficulty1, RankProGuitar, chkProGuitar.Checked);
            UpdateDifficultyDisplayNEMO(PictureProBassDifficulty1, RankProBass, chkProBass.Checked);
            UpdateDifficultyDisplayNEMO(PictureBandDifficulty1, ProjectFile.RankBand, true);
        }

        private void SkinButtonStyles(FlatStyle style)
        {
            var buttons = new[]
                {
                    ButtonBrowseForMIDI, ButtonExportMIDI, ButtonGuitar, ButtonBass, ButtonKeys, ButtonVocals,
                    ButtonBacking, ButtonDrumKick, ButtonDrumKit, ButtonDrumSnare, ButtonDryVocals,
                    ButtonDryVocalsHarmony2, ButtonDryVocalsHarmony3, btnCrowd, btnDispDLC, btnDispDefault,
                    btnDescDefault, ButtonAlbumArt, ButtonClearAlbumArt, btnID,btnPlay,
                    ButtonBuildSong, btnTester, btnCleaner, ButtonInformationTab, ButtonGameDataTab, ButtonAudioTab, ButtonBuildTo,
                    btnDispDLC, btnDispDefault, btnDescDefault
                };
            
            foreach (var button in buttons)
            {
                button.FlatStyle = style;
            }
            SkinButtonStyle = style;
        }

        private void UpdateSkinnedTabButtons()
        {
            ButtonInformationTab.ForeColor = mTabOffColor;
            ButtonGameDataTab.ForeColor = mTabOffColor;
            ButtonAudioTab.ForeColor = mTabOffColor;
            switch (TopLevelTabs.SelectedIndex)
            {
                case 0:
                    ButtonInformationTab.ForeColor = mTabOnColor;
                    break;
                case 1:
                    ButtonAudioTab.ForeColor = mTabOnColor;
                    break;
                case 2:
                    ButtonGameDataTab.ForeColor = mTabOnColor;
                    break;
            }
        }
        
        private void SkinMenu(Color color, int type)
        {
            var newfont = new Font(fileToolStripMenuItem.Font, FontStyle.Regular);

            var menu_items = new[]
                {
                    fileToolStripMenuItem, optionsToolStripMenuItem, aboutToolStripMenuItem, newToolStripMenuItem,
                    openToolStripMenuItem, importSongToolStripMenuItem, importSongsdtaFileToolStripMenuItem, importpngxboxFileToolStripMenuItem,
                    exitToolStripMenuItem, selectThumbnail, selectAudioFile, analyzeMIDIFileForContents, convertVocalsStemToDryvox,
                    showToast, aDVANCEDUSEONLYToolStripMenuItem, overrideAlbumArt, overrideAudioFile, copyLeadDryVocalsHere, 
                    overrideMIDIFile, overrideMiloFile, selectAudacityPath, selectNautilusPath, changeCompilerExecutable,
                    keepSongsdtaFile, doNotDeleteExtractedFiles, overrideProjectFileAuthor, useSilenceTracksByDefault, use441KHzToolStripMenuItem,
                    use48KHzToolStripMenuItem, wiiConversion, deleteRBAFiles, appendSongVersionToFileName,
                    appendSongVersionToSongID, appendrb3conToFile, aNSIMenu, uTF8Menu, skinsToolStripMenuItem, saveAsToolStripMenuItem,
                    saveToolStripMenuItem, importCONLIVEFileToolStripMenuItem, neverCheckForTempoMap, loadTemplateToolStripMenuItem,
                    saveCurrentListAsTemplateToolStripMenuItem, clearToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem,
                    Mono44SilenceToolStripMenuItem, Mono48SilenceToolStripMenuItem, Stereo44SilenceToolStripMenuItem,
                    Stereo48SilenceToolStripMenuItem, clearThumbnailTool, useDefaultRB3ImageToolStripMenuItem, openToDoListByDefault,
                    bypassNemosMIDIValidator,blankDryvoxFileToolStripMenuItem, albumArtDimensions,x256,x512,x1024,x2048,
                    visitAlbumArtRepository, useDefaultArt, increaseSongVersionAutomatically, signSongAsLIVE, Mono44Silence24, Mono48Silence24, 
                    Stereo44Silence24, Stereo48Silence24, use441KHz24bitToolStripMenuItem, use48KHz24bitToolStripMenuItem, customSkinTool,
                    useUniqueNumericSongID, batchReplaceSongIDs, batchRestoreSongIDs, removeSubgenre,
                    importSonginiFileToolStripMenuItem, checkForUpdates, viewChangeLog, helpToolStripMenuItem
                };
            
            foreach (var item in menu_items)
            {
                switch (type)
                {
                    case 0:
                        menuStrip1.BackColor = color;
                        item.BackColor = color;
                        break;
                    case 1:
                        item.ForeColor = color;
                        break;
                }
                item.Font = newfont;
            }
            SkinMenuSkinChoices();
        }

        private void SkinMenuSkinChoices()
        {
            var newfont = new Font(fileToolStripMenuItem.Font, FontStyle.Regular);
            var oldfont = new Font("Tahoma", (float)8.25, FontStyle.Bold);

            oldDarkTool.BackColor = Color.Black;
            oldDarkTool.ForeColor = Color.LightGray;
            oldDarkTool.Font = oldfont;

            if (!customSkinTool.Checked)
            {
                customSkinTool.BackColor = Color.White;
                customSkinTool.ForeColor = Color.Black;
                customSkinTool.Font = newfont;
            }
            
            cIsForColorfulTool.BackColor = Color.FromArgb(39, 85, 196);
            cIsForColorfulTool.ForeColor = Color.White;
            cIsForColorfulTool.Font = newfont;
        }
        
        private void oldDarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cIsForColorfulTool.Checked = false;
            oldDarkTool.Checked = true;
            customSkinTool.Checked = false;
            burnBabyBurn.Checked = false;
            ActiveSkin = "dark";

            MessageBox.Show("Please restart Magma: Rok On Edition to activate this skin", mAppTitle, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
        
        private void cIsForColorfulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cIsForColorfulTool.Checked = true;
            oldDarkTool.Checked = false;
            customSkinTool.Checked = false;
            burnBabyBurn.Checked = false;

            customSkinTool.Text = "Custom Skin";
            customSkinTool.BackColor = Color.White;
            customSkinTool.ForeColor = Color.Black;

            ActiveSkin = "colorful";
            useColorfulSkin();
        }
        
        private TextBox getActiveTextBox()
        {
            var textbox = todo1;
            
            switch (ActiveItem)
            {
                case 0:
                    textbox = todo1;
                    break;
                case 1:
                    textbox = todo2;
                    break;
                case 2:
                    textbox = todo3;
                    break;
                case 3:
                    textbox = todo4;
                    break;
                case 4:
                    textbox = todo5;
                    break;
                case 5:
                    textbox = todo6;
                    break;
                case 6:
                    textbox = todo7;
                    break;
                case 7:
                    textbox = todo8;
                    break;
                case 8:
                    textbox = todo9;
                    break;
                case 9:
                    textbox = todo10;
                    break;
                case 10:
                    textbox = todo11;
                    break;
                case 11:
                    textbox = todo12;
                    break;
                case 12:
                    textbox = todo13;
                    break;
                case 13:
                    textbox = todo14;
                    break;
                case 14:
                    textbox = todo15;
                    break;
            }

            return textbox;
        }

        private TextBox GetActiveListBox()
        {
            var textbox = list1;

            switch (ActiveItem)
            {
                case 0:
                    textbox = list1;
                    break;
                case 1:
                    textbox = list2;
                    break;
                case 2:
                    textbox = list3;
                    break;
                case 3:
                    textbox = list4;
                    break;
                case 4:
                    textbox = list5;
                    break;
                case 5:
                    textbox = list6;
                    break;
                case 6:
                    textbox = list7;
                    break;
                case 7:
                    textbox = list8;
                    break;
                case 8:
                    textbox = list9;
                    break;
                case 9:
                    textbox = list10;
                    break;
                case 10:
                    textbox = list11;
                    break;
                case 11:
                    textbox = list12;
                    break;
                case 12:
                    textbox = list13;
                    break;
                case 13:
                    textbox = list14;
                    break;
                case 14:
                    textbox = list15;
                    break;
            }

            return textbox;
        }
        
        private void UpdateToDoStuff()
        {
            var textbox = getActiveTextBox();
            var listbox = GetActiveListBox();

            if (ToDoImportant[ActiveItem] && !ToDoCompleted[ActiveItem])
            {
                textbox.BackColor = Color.LightGoldenrodYellow;
                textbox.ForeColor = Color.Black;
            }
            else if (ToDoCompleted[ActiveItem])
            {
                textbox.BackColor = Color.PaleGreen;
                textbox.ForeColor = Color.Black;
            }
            else
            {
                textbox.BackColor = ToDoBackColor;
                textbox.ForeColor = ToDoForeColor;
            }

            picDone.Image = ToDoCompleted[ActiveItem] ? ToDoImgDone : ToDoImgNotDone;
            picImportant.Image = ToDoImportant[ActiveItem] ? ToDoImgImportant : ToDoImgNotImportant;

            listbox.BackColor = textbox.BackColor;
            listbox.ForeColor = textbox.ForeColor;
        }
        
        private void todo1_MouseDown(object sender, MouseEventArgs e)
        {
            var textbox = (TextBox) sender;
            ActiveItem = Convert.ToInt16(textbox.Tag);

            if (textbox.Text == "Click to add new item...")
            {
                textbox.Text = "";
            }

            UpdateToDoStuff();
        }

        private void todo1_Leave(object sender, EventArgs e)
        {
            var textbox = (TextBox) sender;
            ActiveItem = Convert.ToInt16(textbox.Tag);

            if (textbox.Text == "")
            {
                textbox.Text = "Click to add new item...";
                ToDoDescription[ActiveItem] = "";
                ToDoImportant[ActiveItem] = false;
                ToDoCompleted[ActiveItem] = false;
            }
            else if (ToDoDescription[ActiveItem] != textbox.Text)
            {
                ToDoDescription[ActiveItem] = textbox.Text;
                RefreshWindowTitle();
            }

            UpdateToDoStuff();

            picImportant.Image = ToDoImgNotImportant;
            picDone.Image = ToDoImgNotDone;
        }

        private void todo1_TextChanged(object sender, EventArgs e)
        {
            if (starting)
            {
                return;
            }

            var textbox = (TextBox)sender;
            ActiveItem = Convert.ToInt16(textbox.Tag);

            if (ToDoDescription[ActiveItem] == textbox.Text) return;
            ToDoDescription[ActiveItem] = textbox.Text;
            RefreshWindowTitle();
        }

        private void openToDoListByDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openToDoListByDefault.Checked)
            {
                Width = WIDTH_EXPANDED;
            }
            DoShowToast("To Do list will " + (openToDoListByDefault.Checked ? "" : "not") + " be opened by default");
        }

        private void saveCurrentListAsTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
                {
                    InitialDirectory = Application.StartupPath,
                    Filter = "To Do Template (*.todo)|*.todo",
                    Title = "Save To Do List as Template",
                    OverwritePrompt = true
                };

            if (sfd.ShowDialog() != DialogResult.OK) return;
            var sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.Default);
            sw.WriteLine("Magma: Rok On Edition To Do Template Begin");
            sw.WriteLine("//You can create your own by filling out the fields in Magma and then clicking 'Save current list as template");
            sw.WriteLine("//To do it manually, use the following format:");
            sw.WriteLine("//ToDo#=Description text,important_boolean --- for example:");
            sw.WriteLine("//ToDo1=Enter and verify all metadata,True");
            sw.WriteLine("//ToDo15=Set preview time to optimal spot,False");
            sw.WriteLine("");

            var item = ActiveItem;
            for (var i = 0; i < 15; i++)
            {
                ActiveItem = i;
                sw.WriteLine("ToDo" + (i + 1) + "=" + getActiveTextBox().Text + "," + ToDoImportant[i]);
            }

            ActiveItem = item;
            sw.WriteLine("");
            sw.WriteLine("Magma: Rok On Edition To Do Template End");
            sw.Dispose();

            DoShowToast("Template " + Path.GetFileName(sfd.FileName) + " saved successfully");
        }

        private void loadTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                FileName = "",
                InitialDirectory = Application.StartupPath,
                Filter = "To Do Template (*.todo)|*.todo",
                Title = "Open To Do List Template",
            };

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName != "" && File.Exists(ofd.FileName))
            {
               LoadTemplate(ofd.FileName); 
            }
        }

        private void LoadTemplate(string template)
        {
            if (!File.Exists(template)) return;

            starting = true;
            try
            {
                var sr = new StreamReader(template, System.Text.Encoding.Default);
                string line;

                do
                {
                    line = sr.ReadLine();
                } while (!line.Contains("ToDo") || line.StartsWith("//", StringComparison.Ordinal));

                ClearToDoList();
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("Magma: Rok On Edition To Do Template End"))
                        break;

                    if (!line.StartsWith("//", StringComparison.Ordinal) && !line.Contains("=;False"))
                    {
                        GetToDoFromFile(line, true);
                    }
                }
                sr.Dispose();
                DoShowToast("Loaded template " + Path.GetFileName(template) + " successfully");
            }
            catch (Exception)
            {
                DoShowToast("Failed to load template file");
            }

            starting = false;
        }

        private void btnTester_Click(object sender, EventArgs e)
        {
            var MIDI = "";
            if (ProjectFile.MidiFile != "" && File.Exists(ProjectFile.MidiFile))
            {
                MIDI = ProjectFile.MidiFile;
            }
            else if (File.Exists(TextBoxMidiFile.Text))
            {
                MIDI = TextBoxMidiFile.Text;
            }
            var tester = new MidiTester(this, MIDI);
            tester.ShowDialog();
        }
                
        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadImages();
            if (customSkinTool.Checked && SKIN_PATH != "")
            {
                LoadCustomSkin(SKIN_PATH);
            }            
            
            updater.RunWorkerAsync();
            var xmasfile = Application.StartupPath + "\\bin\\DO_NOT_OPEN_TIL_XMAS.rok";
            if (DateTime.Now.Month == 12 && DateTime.Now.Day < 24 && !File.Exists(xmasfile))
            {
                var sw = new StreamWriter(xmasfile, false, System.Text.Encoding.Default);
                sw.WriteLine("WHAT ARE YOU DOING?!?!");
                sw.WriteLine("IT'S NOT CHRISTMAS YET!");
                sw.Dispose();
                var toast = showToast.Checked;
                showToast.Checked = true;
                DoShowToast("Christmas file created ... can you find it?");
                showToast.Checked = toast;
            }
            if (DateTime.Now.Month != 12 || (DateTime.Now.Month == 12 && DateTime.Now.Day >= 26))
            {
                Tools.DeleteFile(xmasfile);
            }
            if (DateTime.Now.Month != 12 || DateTime.Now.Day <= 23 || DateTime.Now.Day >= 26 ||
                !File.Exists(xmasfile)) return;
            var message = ThreadSafeStringList.xmas_msg;
            message = message.Replace("#AUTHOR", DefaultAuthor == "" ? "there" : DefaultAuthor);
            message = message.Replace("#DAY", DateTime.Now.Day.ToString(CultureInfo.InvariantCulture));
            message = message.Replace("#WHEN", DateTime.Now.Year == 2013 ? "Two months ago" : "In October of 2013");
            var xmas = new HelpForm(this, "Happy Holidays!", message);
            xmas.ShowDialog();
            Tools.DeleteFile(xmasfile);
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
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
        
        private void blankDryvoxFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveTextBox.Text = BlankDryvox;
        }

        private void btnCleaner_Click(object sender, EventArgs e)
        {
            var MIDI = "";
            if (ProjectFile.MidiFile != "" && File.Exists(ProjectFile.MidiFile))
            {
                MIDI = ProjectFile.MidiFile;
            }
            else if (File.Exists(TextBoxMidiFile.Text))
            {
                MIDI = TextBoxMidiFile.Text;
            }
            else
            {
                MessageBox.Show("Can't find MIDI file '" + MIDI + "'\nNothing to clean", mAppTitle, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Click 'OK' to send MIDI file '" + Path.GetFileName(MIDI) +
                    "' to MIDI Cleaner\n\nChange settings as necessary, press 'Begin' and wait for your MIDI file to be cleaned, then close MIDI Cleaner and Magma will grab the clean copy and move it to your project directory\r\n\r\nClick 'Cancel' to go back without cleaning your MIDI file",
                    mAppTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                DoShowToast("User aborted cleaning of MIDI file, no changes were made");
                return;
            }

            if (nautilusPath == "" || !File.Exists(nautilusPath))
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
                    nautilusPath = fileDialog.FileName;
                }
            }
            
            var folder = Path.GetDirectoryName(nautilusPath) ?? Tools.CurrentFolder;
            var startInfo = new ProcessStartInfo
            {
                FileName = nautilusPath,
                Arguments = "\"-cleaner " + MIDI + "\"",
                WorkingDirectory = folder
            };
            var process = Process.Start(startInfo);
            do
            {
                //wait until it's done
            } while (!process.HasExited);
            

            var newMIDI = MIDI.Replace(".mid", "_clean.mid");
            var backup = MIDI.Replace(".mid", "_dirty.mid");
            Tools.DeleteFile(backup);
            if (File.Exists(newMIDI))
            {
                try
                {
                    Tools.MoveFile(MIDI, backup);
                    Tools.MoveFile(newMIDI, MIDI);
                    MessageBox.Show("Cleaning of MIDI file '" + Path.GetFileName(MIDI) +
                        "' completed successfully\r\n\r\nOriginal MIDI file was backed up to '" +
                        Path.GetFileName(backup) + "'", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    var message = "Original MIDI file could not be restored, sorry";
                    if (File.Exists(backup))
                    {
                        Tools.DeleteFile(MIDI);
                        if (Tools.MoveFile(backup, MIDI))
                        {
                            message = "Original MIDI file was restored successfully";
                        }
                    }
                    MessageBox.Show("There was an error trying to overwrite the dirty MIDI file with the clean one\n\n" + message, mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Could not find '" + Path.GetFileName(newMIDI) + "'\n\nNothing was changed",
                                mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void numericMilliseconds_ValueChanged(object sender, EventArgs e)
        {
            if (starting || Importing) return;
            StopBASS();
            doSongPreview();
            RefreshWindowTitle();
        }

        private void selectToolsPath_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = "Windows Executable (*.exe)|*.exe",
                InitialDirectory = Application.StartupPath,
                Title = "Select Nautilus Executable"
            };

            fileDialog.ShowDialog();

            if (fileDialog.FileName == "" || fileDialog.FileName.Substring(fileDialog.FileName.Length - 4, 4) != ".exe")
                return;
            nautilusPath = fileDialog.FileName;
        }

        private void x256ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x256.Checked = true;
            x512.Checked = false;
            x1024.Checked = false;
            x2048.Checked = false;
            DoShowToast("Album art dimensions changed to 256x256 pixels");
        }

        private void x512ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x256.Checked = false;
            x512.Checked = true;
            x1024.Checked = false;
            x2048.Checked = false;
            DoShowToast("Album art dimensions changed to 512x512 pixels");
        }

        private void x1024ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x256.Checked = false;
            x512.Checked = false;
            x1024.Checked = true;
            x2048.Checked = false;
            DoShowToast("Album art dimensions changed to 1024x1024 pixels");
        }

        private void x2048ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x256.Checked = false;
            x512.Checked = false;
            x1024.Checked = false;
            x2048.Checked = true;
            DoShowToast("Album art dimensions changed to 2048x2048 pixels");
        }

        private void bypassNemosMIDIValidatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoShowToast("Nemo's MIDI Validator " + (bypassNemosMIDIValidator.Checked ? "enabled" : "disabled"));
        }

        private void overrideAlbumArt_Click(object sender, EventArgs e)
        {
            DoShowToast("Override album art file will " + (overrideAlbumArt.Checked ? "" : "not") + " be used");
        }

        private void overrideMIDIFile_Click(object sender, EventArgs e)
        {
            DoShowToast("Override MIDI file will " + (overrideMIDIFile.Checked ? "" : "not") + " be used");
        }

        private void overrideAudioFile_Click(object sender, EventArgs e)
        {
            DoShowToast("Override audio file will " + (overrideAudioFile.Checked ? "" : "not") + " be used");
        }

        private void overrideMiloFile_Click(object sender, EventArgs e)
        {
            DoShowToast("Override animations file will " + (overrideMiloFile.Checked ? "" : "not") + " be used");
        }

        private void overrideProjectFileAuthor_Click(object sender, EventArgs e)
        {
            DoShowToast("Will " + (overrideProjectFileAuthor.Checked ? "" : "not") + " override project file author");
        }

        private void chkAutoKeys_CheckedChanged(object sender, EventArgs e)
        {
            DoShowToast("Fake pro-keys charts will " + (chkAutoKeys.Checked ? "" : "not") + " be auto-generated");
        }

        private void chkKeysAnim_CheckedChanged(object sender, EventArgs e)
        {
            DoShowToast("Keys animations will " + (chkKeysAnim.Checked ? "" : "not") + " be auto-generated");
        }

        private void picHelp_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var file = "";
            var name = "";

            switch (((PictureBox) sender).Name)
            {
                case "picHelpTuningCents":
                    file = "cents";
                    name = "Tuning Offset Cents";
                    break;
                case "picHelpTonicNote":                    
                    file = "tonic";
                    name = "Vocal Tonic Note & Song Tonality";
                    break;
                case "picHelpMuteVol":
                    file = "mute";
                    name = "Mute Volume & Mute Volume Vocals";
                    break;
                case "picHelpGuitarTuning":
                    file = "prog";
                    name = "Pro Guitar Tuning";
                    break;
                case "picHelpBassTuning":
                    file = "prob";
                    name = "Pro Bass Tuning";
                    break;
                case "picDrumSFX":
                    file = "drums";
                    name = "Drum Kit SFX";
                    break;
                case "picHelpCrowd":
                    file = "crowd";
                    name = "Crowd Audio";
                    break;
                case "picHelpSolos":
                    file = "solos";
                    name = "Instrument Solos";
                    break;
            }

            var message = Tools.ReadHelpFile(file);
            var help = new HelpForm(this, "Help - " + name, message);
            help.ShowDialog();
        }

        private void picChecklist_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Width = Width == WIDTH_COMPACT ? WIDTH_EXPANDED : WIDTH_COMPACT;
        }

        private void picTemplate_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            contextMenuStrip3.Show(MousePosition.X, MousePosition.Y);
        }

        private void picImportant_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ToDoImportant[ActiveItem] = !ToDoImportant[ActiveItem];

            UpdateToDoStuff();
            RefreshWindowTitle();
        }

        private void picDone_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ToDoCompleted[ActiveItem] = !ToDoCompleted[ActiveItem];
            UpdateToDoStuff();
            RefreshWindowTitle();
        }

        private void picRemove_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            for (var i = ActiveItem; i < 14; i++)
            {
                var textbox = getActiveTextBox();
                ToDoDescription[ActiveItem] = ToDoDescription[ActiveItem + 1];
                ToDoCompleted[ActiveItem] = ToDoCompleted[ActiveItem + 1];
                ToDoImportant[ActiveItem] = ToDoImportant[ActiveItem + 1];

                textbox.Text = ToDoDescription[ActiveItem] != "" ? ToDoDescription[ActiveItem] : "Click to add new item...";
                UpdateToDoStuff();
                ActiveItem++;
            }
            ToDoDescription[14] = "";
            ToDoImportant[14] = false;
            ToDoCompleted[14] = false;
            todo15.Text = "Click to add new item...";
            RefreshWindowTitle();
        }

        private void PictureBoxAlbumArt_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var dir = ProjDir != "" ? ProjDir : Tools.CurrentFolder;
            var ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.bmp;*.tif;*.jpg;*.png;*.png_xbox",
                Title = "Select album art image",
                InitialDirectory = dir
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Tools.CurrentFolder = Path.GetDirectoryName(ofd.FileName) + "\\";
            TextBoxAlbumArt.Text = string.IsNullOrEmpty(ProjDir) ? ofd.FileName : ofd.FileName.Replace(ProjDir, "");
        }

        private void picKaraoke_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            chkKaraoke.Checked = !chkKaraoke.Checked;
        }

        private void picMultitrack_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            chkMultitrack.Checked = !chkMultitrack.Checked;
        }

        private void pic2xBass_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            chk2xBass.Checked = !chk2xBass.Checked;
        }
        
        private void picRhythmKeys_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            chkRhythmKeys.Checked = !chkRhythmKeys.Checked;
        }

        private void picRhythmBass_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            chkRhythmBass.Checked = !chkRhythmBass.Checked;
        }

        private void picConvert_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            chkConvert.Checked = !chkConvert.Checked;
        }

        private void picXOnly_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            chkXOnly.Checked = !chkXOnly.Checked;
        }

        private int GetDifficultyValue(int difficulty, string instrument)
        {
            switch (instrument)
            {
                case "Drum":
                    switch (difficulty)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 124;
                        case 3:
                            return 151;
                        case 4:
                            return 178;
                        case 5:
                            return 242;
                        case 6:
                            return 345;
                        case 7:
                            return 448;
                    }
                    break;
                case "Bass":
                    switch (difficulty)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 135;
                        case 3:
                            return 181;
                        case 4:
                            return 228;
                        case 5:
                            return 293;
                        case 6:
                            return 364;
                        case 7:
                            return 436;
                    }
                    break;
                case "ProBass":
                    switch (difficulty)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 150;
                        case 3:
                            return 208;
                        case 4:
                            return 267;
                        case 5:
                            return 325;
                        case 6:
                            return 384;
                        case 7:
                            return 442;
                    }
                    break;
                case "Guitar":
                    switch (difficulty)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 139;
                        case 3:
                            return 176;
                        case 4:
                            return 221;
                        case 5:
                            return 267;
                        case 6:
                            return 333;
                        case 7:
                            return 409;
                    }
                    break;
                case "ProGuitar":
                    switch (difficulty)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 150;
                        case 3:
                            return 208;
                        case 4:
                            return 267;
                        case 5:
                            return 325;
                        case 6:
                            return 384;
                        case 7:
                            return 442;
                    }
                    break;
                case "Keys":
                    switch (difficulty)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 153;
                        case 3:
                            return 211;
                        case 4:
                            return 269;
                        case 5:
                            return 327;
                        case 6:
                            return 385;
                        case 7:
                            return 443;
                    }
                    break;
                case "ProKeys":
                    switch (difficulty)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 153;
                        case 3:
                            return 211;
                        case 4:
                            return 269;
                        case 5:
                            return 327;
                        case 6:
                            return 385;
                        case 7:
                            return 443;
                    }
                    break;
                case "Vocal":
                    switch (difficulty)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 132;
                        case 3:
                            return 175;
                        case 4:
                            return 218;
                        case 5:
                            return 279;
                        case 6:
                            return 353;
                        case 7:
                            return 427;
                    }
                    break;
                case "Band":
                    switch (difficulty)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 165;
                        case 3:
                            return 215;
                        case 4:
                            return 243;
                        case 5:
                            return 267;
                        case 6:
                            return 292;
                        case 7:
                            return 345;
                    }
                    break;
                default:
                    return 0;
            }
            return 0;
        }

        private void Difficulty_Click(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button != MouseButtons.Left) return;
            var name = ((PictureBox)sender).Name;
            var difficulty = Convert.ToInt16(Regex.Match(name, @"\d+").Value);

            var track = ((PictureBox)sender).Name.Replace("Picture", "");
            track = track.Substring(0, track.IndexOf("Difficulty", StringComparison.Ordinal));
            switch (track)
            {
                case "Drum":
                    ProjectFile.RankDrum = difficulty;
                    UpdateDifficultyDisplayNEMO(PictureDrumDifficulty1, difficulty, true);
                    scrollDrums.Value = GetDifficultyValue(difficulty, track);
                    break;
                case "Bass":
                    ProjectFile.RankBass = difficulty;
                    UpdateDifficultyDisplayNEMO(PictureBassDifficulty1, difficulty, true);
                    scrollBass.Value = GetDifficultyValue(difficulty, track);
                    break;
                case "ProBass":
                    RankProBass = difficulty;
                    UpdateDifficultyDisplayNEMO(PictureProBassDifficulty1, difficulty, true);
                    scrollProBass.Value = GetDifficultyValue(difficulty, track);
                    break;
                case "Guitar":
                    ProjectFile.RankGuitar = difficulty;
                    UpdateDifficultyDisplayNEMO(PictureGuitarDifficulty1, difficulty, true);
                    scrollGuitar.Value = GetDifficultyValue(difficulty, track);
                    break;
                case "ProGuitar":
                    RankProGuitar = difficulty;
                    UpdateDifficultyDisplayNEMO(PictureProGuitarDifficulty1, difficulty, true);
                    scrollProGuitar.Value = GetDifficultyValue(difficulty, track);
                    break;
                case "Vocal":
                    ProjectFile.RankVocals = difficulty;
                    UpdateDifficultyDisplayNEMO(PictureVocalDifficulty1, difficulty, true);
                    scrollVocals.Value = GetDifficultyValue(difficulty, track);
                    break;
                case "Keys":
                    ProjectFile.RankKeys = difficulty;
                    UpdateDifficultyDisplayNEMO(PictureKeysDifficulty1, difficulty, true);
                    scrollKeys.Value = GetDifficultyValue(difficulty, track);
                    break;
                case "ProKeys":
                    ProjectFile.RankProKeys = difficulty;
                    UpdateDifficultyDisplayNEMO(PictureProKeysDifficulty1, difficulty, true);
                    scrollProKeys.Value = GetDifficultyValue(difficulty, track);
                    break;
                case "Band":
                    ProjectFile.RankBand = difficulty;
                    UpdateDifficultyDisplayNEMO(PictureBandDifficulty1, difficulty, true);
                    scrollBand.Value = GetDifficultyValue(difficulty, track);
                    break;
            }
            RefreshWindowTitle();
        }

        private void picAuthor_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            DefaultAuthor = TextBoxAuthor.Text;
            if (TextBoxAuthor.Text.ToLowerInvariant() == "farottone")
            {
                DoShowToast("Default Author set to Lean Mean Charting Machine!");
                return;
            }
            if (TextBoxAuthor.Text.ToLowerInvariant() == "pksage")
            {
                if (MessageBox.Show("Hello Mostly-Benevolent Web Overlord,\nWhat luck have I to be used by you!\nYou are awesome, don't you agree?",
                        mAppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    picAuthor_MouseClick(null, null);
                }
                DoShowToast("Default Author set to Mostly-Benevolent Web Overlord!");
                return;
            }
            if (TextBoxAuthor.Text.ToLowerInvariant() == "espher" || TextBoxAuthor.Text.ToLowerInvariant() == "eskella")
            {
                DoShowToast("You want I should set Default Author to 'The Master of Harmonies', eh?");
                return;
            }
            DoShowToast("Default Author set to " + DefaultAuthor);
        }

        private void LoadImages()
        {
            var res = Application.StartupPath + "\\res\\";
            if (!Directory.Exists(res))
            {
                MessageBox.Show("Required directory 'res' is missing, please redownload this program and do not delete anything that comes with it",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                pic2xBass.Image = Tools.NemoLoadImage(res + "2xbass.png");
                picCAT.Image = Tools.NemoLoadImage(res + "cat.png");
                picConvert.Image = Tools.NemoLoadImage(res + "convert.png");
                picKaraoke.Image = Tools.NemoLoadImage(res + "karaoke.png");
                picMultitrack.Image = Tools.NemoLoadImage(res + "multi.png");
                picDIYStems.Image = Tools.NemoLoadImage(res + "diy_multitrack.png");
                picUnpitched.Image = Tools.NemoLoadImage(res + "unpitched_vocals.png");
                picPartial.Image = Tools.NemoLoadImage(res + "partial_multitrack.png");
                picRhythmBass.Image = Tools.NemoLoadImage(res + "rbass.png");
                picRhythmKeys.Image = Tools.NemoLoadImage(res + "rkeys.png");
                picXOnly.Image = Tools.NemoLoadImage(res + "xonly.png");                
                picAuthor.Image = Tools.NemoLoadImage(res + "check.png");
                picChecklist.Image = Tools.NemoLoadImage(res + "checklist.png");
                picHelpCrowd.Image = Tools.NemoLoadImage(res + "help.png");
                picHelpGuitarTuning.Image = picHelpCrowd.Image;
                picHelpMuteVol.Image = picHelpCrowd.Image;
                picHelpTonicNote.Image = picHelpCrowd.Image;
                picHelpTuningCents.Image = picHelpCrowd.Image;
                picHelpSolos.Image = picHelpCrowd.Image;
                ToDoImgDone = (Bitmap)Tools.NemoLoadImage(res + "todo_done.png");
                ToDoImgNotDone = (Bitmap)Tools.NemoLoadImage(res + "todo_done2.png");
                ToDoImgImportant = (Bitmap)Tools.NemoLoadImage(res + "todo_imp.png");
                ToDoImgNotImportant = (Bitmap)Tools.NemoLoadImage(res + "todo_imp2.png");
                picRemove.Image = Tools.NemoLoadImage(res + "todo_del.png");
                picTemplate.Image = Tools.NemoLoadImage(res + "todo_save.png");
                picWii.Image = Tools.NemoLoadImage(res + "wii.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error loading image resources\n" + ex.Message, mAppTitle,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picCAT_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            chkCAT.Checked = !chkCAT.Checked;
        }

        private void chkCAT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCAT.Checked)
            {
                chkXOnly.Checked = false;
                DoShowToast("Song marked as CAT EMH");
            }
            RefreshWindowTitle();
        }

        private void picThumb_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            getThumb("");
        }

        private void selectThumbnail_Click(object sender, EventArgs e)
        {
            getThumb("");
        }

        private void TextBoxDrumKit_MouseEnter(object sender, EventArgs e)
        {
            ActiveTextBox = (TextBox) sender;
        }

        private void selectAudioFile_Click(object sender, EventArgs e)
        {
            GetFilePathForTextbox(ActiveTextBox);
        }

        private void chkSoloDrums_CheckedChanged(object sender, EventArgs e)
        {
            DoShowToast((chkSoloDrums.Checked ? "Added" : "Removed") + " drum solo");
            RefreshWindowTitle();
        }

        private void chkSoloGuitar_CheckedChanged(object sender, EventArgs e)
        {
            DoShowToast((chkSoloGuitar.Checked ? "Added" : "Removed") + " guitar solo");
            RefreshWindowTitle();
        }

        private void chkSoloBass_CheckedChanged(object sender, EventArgs e)
        {
            DoShowToast((chkSoloBass.Checked ? "Added" : "Removed") + " bass solo");
            RefreshWindowTitle();
        }

        private void chkSoloKeys_CheckedChanged(object sender, EventArgs e)
        {
            DoShowToast((chkSoloKeys.Checked ? "Added" : "Removed") + " keys solo");
            RefreshWindowTitle();
        }

        private void chkSoloVocals_CheckedChanged(object sender, EventArgs e)
        {
            DoShowToast((chkSoloVocals.Checked ? "Added" : "Removed") + " vocal percussion solo");
            RefreshWindowTitle();
        }
        
        private void TextBoxBuildDestination_Leave(object sender, EventArgs e)
        {
            AppendStuffToFilename();
        }
        
        private void useDefaultArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonClearAlbumArt_Click(null, null);
        }

        private void visitAlbumArtRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.keepitfishy.com/albumart/");
        }

        private void increaseSongVersionAutomatically_Click(object sender, EventArgs e)
        {
            DoShowToast("Will " + (increaseSongVersionAutomatically.Checked ? "" : "not") + " increase song version automatically");
        }

        private void numVersion_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var version = (int)numVersion.Value;
                SongVersion = version;
            }
            catch
            {
                numVersion.Value = 1;
                return;
            }
            RefreshWindowTitle();
        }

        private void numVersion_Leave(object sender, EventArgs e)
        {
            if (numVersion.Text.Trim() == "" || numVersion.Value.ToString(CultureInfo.InvariantCulture).Length == 0)
            {
                numVersion.Text = numVersion.Value.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void use441KHz24bitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            use48KHzToolStripMenuItem.Checked = false;
            use441KHzToolStripMenuItem.Checked = false;
            use441KHz24bitToolStripMenuItem.Checked = true;
            use48KHz24bitToolStripMenuItem.Checked = false;
            DoShowToast("Will use 44.1kHz 24-bit silence tracks by default");
        }

        private void use48KHz24bitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            use48KHzToolStripMenuItem.Checked = false;
            use441KHzToolStripMenuItem.Checked = false;
            use441KHz24bitToolStripMenuItem.Checked = false;
            use48KHz24bitToolStripMenuItem.Checked = true;
            DoShowToast("Will use 48kHz 24-bit silence tracks by default");
        }

        private void Mono44Silence24_Click(object sender, EventArgs e)
        {
            ActiveTextBox.Text = SilenceMono44_24;
        }

        private void Stereo44Silence24_Click(object sender, EventArgs e)
        {
            ActiveTextBox.Text = SilenceStereo44_24;
        }

        private void Stereo48Silence24_Click(object sender, EventArgs e)
        {
            ActiveTextBox.Text = SilenceStereo48_24; 
        }

        private void Mono48Silence24_Click(object sender, EventArgs e)
        {
            ActiveTextBox.Text = SilenceMono48_24;
        }

        private void customSkinTool_Click(object sender, EventArgs e)
        {
            var skindir = Application.StartupPath + "\\";

            if (Directory.Exists(skindir + "skins\\"))
            {
                skindir = skindir + "skins\\";
            }

            var ofd = new OpenFileDialog
            {
                Filter = "Magma Skin (*.skin, *.txt)|*.skin;*.txt",
                InitialDirectory = skindir,
                Title = "Select your skin's configuration file"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            LoadCustomSkin(ofd.FileName);
        }

        private void LoadCustomSkin(string skin)
        {
            SKIN_PATH = skin;

            if ((!SKIN_PATH.EndsWith(".skin", StringComparison.Ordinal) && !SKIN_PATH.EndsWith(".txt", StringComparison.Ordinal)) || !File.Exists(SKIN_PATH))
            {
                return;
            }

            customSkinTool.Checked = true;
            cIsForColorfulTool.Checked = false;
            oldDarkTool.Checked = false;
            burnBabyBurn.Checked = false;
            ActiveSkin = "custom";

            SkinBackground(Color.Black);
            SkinHeader(Color.Black);
            todoPic.Image = Resources.todo_white;

            var line = "";
            //old method used a crapload of ifs and else-ifs
            //this reduces that completely but now we have a file with a bunch of comments and stuff
            //let's remove the comments and empty lines, then read the file in
            var sr = new StreamReader(SKIN_PATH, System.Text.Encoding.Default);
            var sw = new StreamWriter(SKIN_PATH + ".bak", false, System.Text.Encoding.Default);
            while (sr.Peek() >= 0)
            {
                line = sr.ReadLine();
                if (string.IsNullOrEmpty(line) || line.Trim().StartsWith("//", StringComparison.Ordinal)) continue;
                sw.WriteLine(line);
            }
            sr.Dispose();
            sw.Dispose();

            sr = new StreamReader(SKIN_PATH + ".bak", System.Text.Encoding.Default);
            try
            {
                while (sr.Peek() >= 0)
                {
                    line = sr.ReadLine();
                    customSkinTool.Text = Tools.GetConfigString(line).Trim() + " (click to change...)";
                    line = sr.ReadLine();
                    SkinBackground(Tools.GetColorFromString(line));
                    line = sr.ReadLine();
                    SkinHeader(Tools.GetColorFromString(line));

                    line = sr.ReadLine();
                    mTabOnColor = Tools.GetColorFromString(line);
                    line = sr.ReadLine();
                    mTabOffColor = Tools.GetColorFromString(line);
                    line = sr.ReadLine();
                    mTabHoverColor = Tools.GetColorFromString(line);

                    line = sr.ReadLine();
                    SkinTabInfo(Tools.GetColorFromString(line));
                    line = sr.ReadLine();
                    SkinTabButtonInfo(Tools.GetColorFromString(line));

                    line = sr.ReadLine();
                    SkinTabAudio(Tools.GetColorFromString(line));
                    line = sr.ReadLine();
                    SkinTabButtonAudio(Tools.GetColorFromString(line));

                    line = sr.ReadLine();
                    SkinTabData(Tools.GetColorFromString(line));
                    line = sr.ReadLine();
                    SkinTabButtonData(Tools.GetColorFromString(line));

                    line = sr.ReadLine();
                    SkinAudioButtons(Tools.GetColorFromString(line));
                    line = sr.ReadLine();
                    SkinDataButtons(Tools.GetColorFromString(line));
                    line = sr.ReadLine();
                    SkinInfoButtons(Tools.GetColorFromString(line));

                    line = sr.ReadLine();
                    SkinButtonText(Tools.GetColorFromString(line));
                    line = sr.ReadLine();
                    SkinButtonStyles(Tools.GetFlatStyle(line));

                    line = sr.ReadLine();
                    if (line.Contains("LabelBackgroundColor=")) //some skins have this, some don't
                    {
                        SkinLabels(Tools.GetColorFromString(line), 0);
                        line = sr.ReadLine();
                    }
                    SkinLabels(Tools.GetColorFromString(line), 1);
                    line = sr.ReadLine();
                    if (line.Contains("DifficultyBackgroundColor=")) //some skins have this, some don't
                    {
                        SkinDifficultyLabels(Tools.GetColorFromString(line), 0);
                        line = sr.ReadLine();
                    }
                    SkinDifficultyLabels(Tools.GetColorFromString(line), 1);

                    line = sr.ReadLine();
                    SkinTextBoxes(Tools.GetColorFromString(line), 0);
                    line = sr.ReadLine();
                    if (line.Contains("TextBoxDisabledColor="))
                    {
                        SkinTextBoxes(Tools.GetColorFromString(line), 2); //some skins have this, some don't
                        line = sr.ReadLine();
                    }
                    SkinTextBoxes(Tools.GetColorFromString(line), 1);

                    line = sr.ReadLine();
                    SkinGroupBoxes(Tools.GetColorFromString(line), 0);
                    line = sr.ReadLine();
                    SkinGroupBoxes(Tools.GetColorFromString(line), 1);

                    line = sr.ReadLine();
                    SkinComboBoxes(Tools.GetColorFromString(line), 0);
                    line = sr.ReadLine();
                    SkinComboBoxes(Tools.GetColorFromString(line), 1);
                    line = sr.ReadLine();
                    SkinComboBoxesStyle(Tools.GetFlatStyle(line));

                    line = sr.ReadLine();
                    SkinNumerics(Tools.GetColorFromString(line), 0);
                    line = sr.ReadLine();
                    SkinNumerics(Tools.GetColorFromString(line), 1);

                    line = sr.ReadLine();
                    ToDoBackColor = Tools.GetColorFromString(line);
                    SkinToDoStuff(ToDoBackColor, 0);
                    line = sr.ReadLine();
                    ToDoForeColor = Tools.GetColorFromString(line);
                    SkinToDoStuff(ToDoForeColor, 1);

                    line = sr.ReadLine();
                    SkinFooter(Tools.GetColorFromString(line));
                    line = sr.ReadLine();
                    SkinFooterButtons(Tools.GetColorFromString(line));

                    line = sr.ReadLine();
                    mMenuBackground = Tools.GetColorFromString(line);
                    line = sr.ReadLine();
                    mMenuText = Tools.GetColorFromString(line);
                    line = sr.ReadLine();
                    mMenuBorder = Tools.GetColorFromString(line);
                    line = sr.ReadLine();
                    mMenuHighlight = Tools.GetColorFromString(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Skin file " + Path.GetFileName(SKIN_PATH) + " is not formatted correctly\nLine:\n" + 
                    line + "\nreturned error:\n" + ex.Message + "\n\nPlease make sure custom skins are following the format of the template",
                    mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            sr.Dispose();
            Tools.DeleteFile(SKIN_PATH + ".bak");

            UpdateSkinnedTabButtons();
            PictureBoxMagmaLogoTop.Image = Resources.magma_logo_sized_original;

            menuStrip1.Renderer = new DarkRenderer();
            SkinMenu(mMenuBackground, 0);
            SkinMenu(mMenuText, 1);

            LoadCustomImages(skin);
        }

        private void LoadCustomImages(string skin)
        {
            var skindir = Application.StartupPath + "\\skins\\" + Path.GetFileNameWithoutExtension(skin) + "\\";

            if (!Directory.Exists(skindir))
            {
                MessageBox.Show("Skin directory:\n" + skindir + "\nwas not found\n\nNo images were loaded", mAppTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                BackgroundImage = Tools.NemoLoadImage(skindir + "background.jpg");
                SkinBackgroundImage = BackgroundImage;
                PanelHeader.BackgroundImage = Tools.NemoLoadImage(skindir + "header.png");
                PictureBoxMagmaLogoTop.Image = Tools.NemoLoadImage(skindir + "magma_logo.png");
                if (File.Exists(skindir + "tabs_all.jpg"))
                {
                    TabPageInformation.BackgroundImage = Tools.NemoLoadImage(skindir + "tabs_all.jpg");
                    TabPageAudio.BackgroundImage = TabPageInformation.BackgroundImage;
                    TabPageGameData.BackgroundImage = TabPageInformation.BackgroundImage;
                }
                else
                {
                    TabPageInformation.BackgroundImage = Tools.NemoLoadImage(skindir + "information_tab.jpg");
                    TabPageAudio.BackgroundImage = Tools.NemoLoadImage(skindir + "audio_tab.jpg");
                    TabPageGameData.BackgroundImage = Tools.NemoLoadImage(skindir + "gamedata_tab.jpg");
                }
                PanelFooter.BackgroundImage = Tools.NemoLoadImage(skindir + "footer.png");
                todoPic.Image = Tools.NemoLoadImage(skindir + "todo_header.png");
                picAuthor.Image = Tools.NemoLoadImage(skindir + "check.png");
                picChecklist.Image = Tools.NemoLoadImage(skindir + "checklist.png");
                PipDevil = (Bitmap)Tools.NemoLoadImage(skindir + "pip_devil.png");
                PipDevilOff = (Bitmap)Tools.NemoLoadImage(skindir + "pip_devil_disabled.png");
                PipDisabledOn = (Bitmap)Tools.NemoLoadImage(skindir + "pip_disabled.png");
                PipDisabledOff = PipDisabledOn;
                PipOff = (Bitmap)Tools.NemoLoadImage(skindir + "pip_off.png");
                PipOn = (Bitmap)Tools.NemoLoadImage(skindir + "pip_on.png");
                pic2xBass.Image = Tools.NemoLoadImage(skindir + "2xbass.png");
                picConvert.Image = Tools.NemoLoadImage(skindir + "convert.png");
                picKaraoke.Image = Tools.NemoLoadImage(skindir + "karaoke.png");
                picMultitrack.Image = Tools.NemoLoadImage(skindir + "multi.png");
                picRhythmBass.Image = Tools.NemoLoadImage(skindir + "rbass.png");
                picRhythmKeys.Image = Tools.NemoLoadImage(skindir + "rkeys.png");
                picHelpCrowd.Image = Tools.NemoLoadImage(skindir + "help.png");
                picHelpTuningCents.Image = Tools.NemoLoadImage(skindir + "help.png");
                picHelpTonicNote.Image = Tools.NemoLoadImage(skindir + "help.png");
                picHelpMuteVol.Image = Tools.NemoLoadImage(skindir + "help.png");
                picHelpGuitarTuning.Image = Tools.NemoLoadImage(skindir + "help.png");
                picDrumSFX.Image = Tools.NemoLoadImage(skindir + "help.png");
                picHelpSolos.Image = Tools.NemoLoadImage(skindir + "help.png");
                picXOnly.Image = Tools.NemoLoadImage(skindir + "xonly.png");
                picRemove.Image = Tools.NemoLoadImage(skindir + "todo_del.png");
                picTemplate.Image = Tools.NemoLoadImage(skindir + "todo_save.png");
                ToDoImgDone = (Bitmap)Tools.NemoLoadImage(skindir + "todo_done.png");
                ToDoImgNotDone = (Bitmap)Tools.NemoLoadImage(skindir + "todo_done2.png");
                ToDoImgImportant = (Bitmap)Tools.NemoLoadImage(skindir + "todo_imp.png");
                ToDoImgNotImportant = (Bitmap)Tools.NemoLoadImage(skindir + "todo_imp2.png");
                if (File.Exists(skindir + "wii.png")) //limited use, not worth throwing an error for anyone except wii people
                {
                    picWii.Image = Tools.NemoLoadImage(skindir + "wii.png");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading skin images\nMake sure the names and formats of your images match those in the template\nMake sure ALL UI images are accounted for in your skin\n\nThe error says: " +
                    ex.Message, mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateSkinnedPips();
            UpdateToDoStuff();
        }

        private void signSongAsLIVE_Click(object sender, EventArgs e)
        {
            DoShowToast("Song file will be signed as " + (signSongAsLIVE.Checked ? "LIVE" : "CON"));
        }

        private void analyzeMIDIFileForContents_Click(object sender, EventArgs e)
        {
            DoShowToast("Will " + (analyzeMIDIFileForContents.Checked? "" : "not ") + "analyze MIDI files for contents");
        }

        private void useUniqueNumericSongID_Click(object sender, EventArgs e)
        {
            doUseNumericID(useUniqueNumericSongID.Checked);
            RefreshWindowTitle();
            if (!useUniqueNumericSongID.Checked) return;
            optionsToolStripMenuItem.HideDropDown();
        }

        private void doUseNumericID(bool enabled)
        {
            var saved = !Text.Contains("*");            
            batchReplaceSongIDs.Enabled = enabled;
            txtSongID.Enabled = !enabled;
            txtSongID.TextAlign = enabled ? HorizontalAlignment.Left : HorizontalAlignment.Center;
            var alphaID = useCustomID && !string.IsNullOrEmpty(CustomID) ? CustomID : SongID;
            txtSongID.Text = enabled ? UniqueNumericID : alphaID;
            btnID.Visible = enabled;
            RefreshWindowTitle(saved);
        }

        public string GetNumericID()
        {
            if (string.IsNullOrEmpty(TextBoxBuildDestination.Text)) return "0";
            var corrector = new SongIDCorrector();
            var fileName = Path.GetFileName(TextBoxBuildDestination.Text);
            // Let me explain, rb3con in the internal name is removed, but not here.
            // This will do it and the 1x is to prevent the version name from being used without the 1x,
            // as this generates incorrect IDs. This solves it.
            if (fileName.EndsWith("_rb3con"))
            {
                fileName = fileName.Substring(0, fileName.Length - "_rb3con".Length);
            }
            Console.WriteLine(chk2xBass.Checked);
            if (chk2xBass.Checked)
            {
                fileName += "1x";
            }
            return corrector.ShortnameToSongID(fileName).ToString();
        }       

        private void useUniqueNumericSongID_CheckedChanged(object sender, EventArgs e)
        {
            appendSongVersionToSongID.Enabled = !useUniqueNumericSongID.Checked;
            if (useUniqueNumericSongID.Checked)
            {
                appendSongVersionToSongID.Checked = false;
            }
        }

        private void batchReplaceSongIDs_Click(object sender, EventArgs e)
        {
            DoBatchProcess(false);
        }

        private void batchRestoreSongIDs_Click(object sender, EventArgs e)
        {
            DoBatchProcess(true);
        }

        private void DoBatchProcess(bool reverse)
        {          
            if (MessageBox.Show("This process might take some time\n\nAre you sure you want to do this process now?",
                    mAppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            var folderUser = new FolderBrowserDialog
            {
                SelectedPath = Tools.CurrentFolder,
                Description = "Select folder containing CON files",
                ShowNewFolderButton = false
            };

            if (folderUser.ShowDialog() != DialogResult.OK) return;
            var folder = folderUser.SelectedPath;

            Tools.CurrentFolder = folder;
            var files = Directory.GetFiles(folder);
            if (!files.Any())
            {
                MessageBox.Show("No files found in that folder, try another", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var FilesToConvert = files.Where(file => VariousFunctions.ReadFileType(file) == XboxFileType.STFS).ToList();

            if (!FilesToConvert.Any())
            {
                MessageBox.Show("No CON files found in that folder, try another", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var batch = new BatchProcess(this, FilesToConvert, reverse);
            isBusy = true;
            batch.ShowDialog();
        }

        private void btnID_Click(object sender, EventArgs e)
        {
            if (!useUniqueNumericSongID.Checked) return;
            UniqueNumericID = GetNumericID();
            UniqueNumericID2x = "";
            txtSongID.Text = UniqueNumericID;
            txtSongID.Refresh();
            RefreshWindowTitle();
        }
        
        private string GetPlayerArgs()
        {
            var files = "-M";
            var track = ProjectFile.GetTrack("guitar");
            if (track.Enabled)
            {
                files = files + " \"" + track.Filename + "\"";
            }
            track = ProjectFile.GetTrack("bass");
            if (track.Enabled)
            {
                files = files + " \"" + track.Filename + "\"";
            }
            track = ProjectFile.GetTrack("vocals");
            if (track.Enabled)
            {
                files = files + " \"" + track.Filename + "\"";
            }
            track = ProjectFile.GetTrack("backing");
            if (track.Enabled)
            {
                files = files + " \"" + track.Filename + "\"";
            }
            track = ProjectFile.GetTrack("keys");
            if (track.Enabled)
            {
                files = files + " \"" + track.Filename + "\"";
            }
            track = ProjectFile.GetTrack("drum_kick");
            if (track.Enabled)
            {
                files = files + " \"" + track.Filename + "\"";
            }
            track = ProjectFile.GetTrack("drum_kit");
            if (track.Enabled)
            {
                files = files + " \"" + track.Filename + "\"";
            }
            track = ProjectFile.GetTrack("drum_snare");
            if (track.Enabled)
            {
                files = files + " \"" + track.Filename + "\"";
            }
            var arg = files + " -c 2 -d trim " + (ProjectFile.PreviewStart == 0 ? 0 : ProjectFile.PreviewStart/1000) + " 30 fade t 2.0 0 2.0";
            return arg;
        }
        
        private void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            if (PreviewEnd == 0)
            {
                PreviewEnd = SongPreview + 30000;
            }
            DrawSpectrum();
            // the stream is still playing...
            var pos = Bass.BASS_ChannelGetPosition(BassStream); // position in bytes
            var PlaybackSeconds = Bass.BASS_ChannelBytes2Seconds(BassStream, pos); // the elapsed time length
            //calculate how many seconds are left to play
            var time_left = ((SongPreview + PreviewEnd) / 1000) - PlaybackSeconds;
            if ((int)time_left == 3.0) //start fade-out
            {
                Bass.BASS_ChannelSlideAttribute(BassMixer, BASSAttribute.BASS_ATTRIB_VOL, 0, 3000);
            }
            else if (time_left <= 0.0)
            {
                StopBASS();
            }
        }

        private void StopBASS()
        {
            picSpectrum.Visible = false;
            Bass.BASS_ChannelStop(BassMixer);
            Bass.BASS_StreamFree(BassMixer);
            Bass.BASS_Free();
            btnPlay.Text = "Play";
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (btnPlay.Text == "Stop")
            {
                StopBASS();
                return;
            }
            if (LabelSongLength.Text == "0:00") return;

            //initialize BASS.NET
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Handle))
            {
                MessageBox.Show("Error initializing BASS.NET\n" + Bass.BASS_ErrorGetCode());
                return;
            }
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_BUFFER, 1000);
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATEPERIOD, 50);

            // create a stereo mixer
            BassMixer = BassMix.BASS_Mixer_StreamCreate(44100, 2, BASSFlag.BASS_MIXER_END);
            //float PlaybackSeconds = ProjectFile.PreviewStart == 0 ? 0 : (float)ProjectFile.PreviewStart / (float)1000;
            float PlaybackSeconds = SongPreview == 0 ? 0 : (float)SongPreview / (float)1000;

            //get audio streams
            var tracks = new List<string> {"guitar","bass","vocals","backing","keys","drum_kick","drum_kit","drum_snare"};
            var channels = 0;
            var totals = 0.0;
            foreach (var track in tracks.Select(t => ProjectFile.GetTrack(t)).Where(track => track.Enabled).Where(track => File.Exists(track.Filename)))
            {
                BassStream = Bass.BASS_StreamCreateFile(track.Filename, 0L, 0L, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT);
                var stream_info = Bass.BASS_ChannelGetInfo(BassStream);
                if (stream_info.chans == 0) continue;
                BassMix.BASS_Mixer_StreamAddChannel(BassMixer, BassStream, BASSFlag.BASS_MIXER_MATRIX);
                BassMix.BASS_Mixer_ChannelSetPosition(BassStream, Bass.BASS_ChannelSeconds2Bytes(BassStream, PlaybackSeconds));
                channels += stream_info.chans;
                totals += (track.VolLeft * stream_info.chans);
            }

            if (channels == 0) return;
            float vol;
            try
            {
                vol = (float)Utils.DBToLevel(Convert.ToDouble(totals/channels), 1.0);
            }
            catch (Exception)
            {
                vol = (float)1.0;
            }
            
            //apply volume correction to entire track
            Bass.BASS_ChannelSetAttribute(BassMixer, BASSAttribute.BASS_ATTRIB_VOL, 0);
            Bass.BASS_ChannelSlideAttribute(BassMixer, BASSAttribute.BASS_ATTRIB_VOL, vol, 3000);

            //start mix playback
            Bass.BASS_ChannelPlay(BassMixer, false);
            btnPlay.Text = "Stop";
            picSpectrum.Visible = true;
            PlaybackTimer.Enabled = true;
        }

        private int SpectrumID;
        private readonly Visuals Spectrum = new Visuals(); // visuals class instance
        private void DrawSpectrum()
        {
            Bitmap spect;
            var width = picSpectrum.Width;
            var height = picSpectrum.Height;
            var back_color = TabPageAudio.BackColor;
            switch (SpectrumID)
            {
                default:
                    SpectrumID = 0;
                    spect = Spectrum.CreateSpectrumLine(BassMixer, width, height, ChartGreen, ChartRed, back_color, 2, 2, false, false, true);
                    break;
                case 1:
                    spect = Spectrum.CreateSpectrum(BassMixer, width, height, ChartGreen, ChartRed, back_color, false, false, true);
                    break;
                case 2:
                    spect = Spectrum.CreateSpectrumLine(BassMixer, width, height, ChartBlue, ChartOrange, back_color, 4, 4, false, false, true);
                    break;
                case 3:
                    spect = Spectrum.CreateSpectrumLinePeak(BassMixer, width, height, ChartGreen, ChartYellow, ChartOrange, back_color, 2, 1, 2, 10, false, false, true);
                    break;
                case 4:
                    spect = Spectrum.CreateSpectrumLinePeak(BassMixer, width, height, ChartGreen, ChartBlue, ChartOrange, back_color, 3, 5, 3, 5, false, false, true);
                    break;
                case 5:
                    spect = Spectrum.CreateWaveForm(BassMixer, width, height, ChartGreen, ChartRed, ChartYellow, back_color, 1, true, false, true);
                    break;
            }
            picSpectrum.Image = spect;
        }

        private void picSpectrum_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SpectrumID++;
            }
        }

        private void wiiConversion_Click(object sender, EventArgs e)
        {
            DoWiiPrep();
        }

        private void importSonginiFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Phase Shift Metadata (*.ini)|*.ini",
                Title = "Select song.ini file...",
                InitialDirectory = Tools.CurrentFolder
            };
            if (ofd.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(ofd.FileName)) return;
            loadDTA(ofd.FileName, true);
        }

        private void copyLeadDryVocalsHere_Click(object sender, EventArgs e)
        {
            ActiveTextBox.Text = "";
            ActiveTextBox.Text = TextBoxDryVocals.Text;
        }

        private void convertVocalsStemToDryvox_Click(object sender, EventArgs e)
        {
            var file = TextBoxVocals.Text;
            if (!File.Exists(file))
            {
                var track = ProjectFile.GetTrack("vocals");
                if (!string.IsNullOrEmpty(track.Filename) && File.Exists(track.Filename))
                {
                    file = track.Filename;
                }
                else
                {
                    file = "";
                }
            }
            if (string.IsNullOrEmpty(file))
            {
                MessageBox.Show("Unable to find vocal stem file", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            EnableDisable(false);
            try
            {
                Bass.BASS_Init(-1, 16000, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                Tools.PlayingSongOggData = File.ReadAllBytes(file);
                var inStream = Bass.BASS_StreamCreateFile(Tools.GetOggStreamIntPtr(), 0, Tools.PlayingSongOggData.Length, BASSFlag.BASS_STREAM_DECODE);
                var mixStream = BassMix.BASS_Mixer_StreamCreate(16000, 1, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_MIXER_END);
                BassMix.BASS_Mixer_StreamAddChannel(mixStream, inStream, BASSFlag.BASS_STREAM_AUTOFREE);
                var stream = BassMix.BASS_Split_StreamCreate(mixStream, BASSFlag.BASS_STREAM_DECODE, new[]{0, -1});
                if (stream == 0)
                {
                    EnableDisable(true);
                    MessageBox.Show("I wasn't able to read audio file '" + Path.GetFileName(file) + "' so I can't convert it to dryvox, sorry", mAppTitle, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    Bass.BASS_Free();
                }
                else
                {
                    var dryvox = file.Replace(".wav", "_dryvox.wav");
                    Tools.DeleteFile(dryvox);
                    BassEnc.BASS_Encode_Start(stream, dryvox, BASSEncode.BASS_ENCODE_PCM | BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
                    while (true)
                    {
                        var buffer = new byte[20000];
                        var c = Bass.BASS_ChannelGetData(stream, buffer, buffer.Length);
                        if (c < 0) break;
                    }
                    Tools.ReleaseStreamHandle();
                    Bass.BASS_Free();
                    if (File.Exists(dryvox))
                    {
                        TextBoxDryVocals.Text = "";
                        TextBoxDryVocals.Text = dryvox;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error converting audio file '" + Path.GetFileName(file) + "' to dryvox\nError: " + ex.Message, mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            try
            {
                Bass.BASS_Free();
            }
            catch (Exception)
            { }
            EnableDisable(true);
        }

        private void picWii_MouseClick(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button != MouseButtons.Left) return;
            wiiConversion.Checked = false;
        }

        private void wiiConversion_CheckedChanged(object sender, EventArgs e)
        {
            picWii.Visible = wiiConversion.Checked;
            Text = Text.Replace(" (Wii Mode)", "");
            if (wiiConversion.Checked)
            {
                Text = Text.Replace(mAppTitle, mAppTitle + " (Wii Mode)");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var message = Tools.ReadHelpFile("about");
            MessageBox.Show(mAppTitle + mAppVersion + "\n\n" + message, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        private void updater_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var path = Application.StartupPath + "\\bin\\update.txt";
            Tools.DeleteFile(path);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault; //(SecurityProtocolType)3072; //TLS 1.2 for .NET 4.0
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile("https://nemosnautilus.com/magma/update.txt", path);
                }
                catch (Exception)
                { }
            }
        }

        private void updater_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            var path = Application.StartupPath + "\\bin\\update.txt";
            if (!File.Exists(path))
            {
                if (showMessage)
                {
                    MessageBox.Show("Unable to check for updates", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;
            }
            var thisVersion = "v4" + mAppVersion;
            var newVersion = "v";
            string appName;
            string releaseDate;
            string link;
            var changeLog = new List<string>();
            var sr = new StreamReader(path);
            try
            {
                var line = sr.ReadLine();
                if (line.ToLowerInvariant().Contains("html"))
                {
                    if (showMessage)
                    {
                        MessageBox.Show("Unable to check for updates", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    sr.Dispose();
                    return;
                }
                appName = Tools.GetConfigString(line);
                newVersion += Tools.GetConfigString(sr.ReadLine());
                releaseDate = Tools.GetConfigString(sr.ReadLine());
                link = Tools.GetConfigString(sr.ReadLine());
                sr.ReadLine();//ignore Change Log header
                while (sr.Peek() >= 0)
                {
                    changeLog.Add(sr.ReadLine());
                }
            }
            catch (Exception ex)
            {
                if (showMessage)
                {
                    MessageBox.Show("Error parsing update file:\n" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                sr.Dispose();
                return;
            }
            sr.Dispose();
            Tools.DeleteFile(path);
            if (thisVersion.Equals(newVersion))
            {
                if (showMessage)
                {
                    MessageBox.Show("You have the latest version", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }
            var newInt = Convert.ToInt16(newVersion.Replace("v", "").Replace(".", "").Trim());
            var thisInt = Convert.ToInt16(thisVersion.Replace("v", "").Replace(".", "").Trim());
            if (newInt <= thisInt)
            {
                if (showMessage)
                {
                    MessageBox.Show("You have a newer version (" + thisVersion + ") than what's on the server (" + newVersion + ")\nNo update needed!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }
            var updaterForm = new Updater();
            updaterForm.SetInfo(Text, thisVersion, appName, newVersion, releaseDate, link, changeLog);
            updaterForm.ShowDialog();
        }

        private void checkForUpdates_Click(object sender, EventArgs e)
        {
            showMessage = true;
            updater.RunWorkerAsync();
        }

        private void viewChangeLog_Click(object sender, EventArgs e)
        {
            const string changelog = "MagmaRokOn_changelog.txt";
            if (!File.Exists(Application.StartupPath + "\\" + changelog))
            {
                MessageBox.Show("Changelog file is missing!", mAppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Process.Start(Application.StartupPath + "\\" + changelog);
        }

        private void burnBabyBurn_Click(object sender, EventArgs e)
        {
            cIsForColorfulTool.Checked = false;
            oldDarkTool.Checked = false;
            customSkinTool.Checked = false;
            burnBabyBurn.Checked = true;
            ActiveSkin = "fire";

            MessageBox.Show("Please restart Magma: Rok On Edition to activate this skin", mAppTitle, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void chkTonality_CheckedChanged(object sender, EventArgs e)
        {
            cboTonality.Enabled = chkTonality.Checked;
            doTonality = chkTonality.Checked;
            if (doTonality && cboTonality.SelectedIndex == -1)
            {
                cboTonality.SelectedIndex = 0;
            }
            songTonality = cboTonality.SelectedIndex;
            RefreshWindowTitle();
        }

        private void chkDIYStems_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDIYStems.Checked)
            {
                chkKaraoke.Checked = false;
                chkMultitrack.Checked = false;
                chkPartial.Checked = false;
                DoShowToast("Song marked as DIY Stems");
            }
            RefreshWindowTitle();
        }

        private void picDIYStems_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            chkDIYStems.Checked = !chkDIYStems.Checked;
        }

        private void prevEndSeconds_Leave(object sender, EventArgs e)
        {
            if (starting || Importing) return;
            StopBASS();
            if (prevEndSeconds.Text == "60")
            {
                prevEndSeconds.SelectedItem = "00";
            }
            if (prevEndSeconds.Text == "-1")
            {
                prevEndSeconds.SelectedItem = "59";
            }

            try
            {
                if (Convert.ToInt32(prevEndSeconds.Text) < 0)
                {
                    prevEndSeconds.SelectedItem = "00";
                }
                if (prevEndSeconds.Text.Length > 2)
                {
                    prevEndSeconds.SelectedItem = "59";
                }
            }
            catch
            {
                prevEndSeconds.SelectedItem = "00";
            }

            prevEndSeconds.SelectedItem = prevEndSeconds.Text.PadLeft(2, '0');
            doSongPreview();
            RefreshWindowTitle();
        }

        private void prevEndMinutes_ValueChanged(object sender, EventArgs e)
        {
            if (starting || Importing) return;
            StopBASS();
            try
            {
                prevEndMinutes.Value = Convert.ToInt16(prevEndMinutes.Value) < 0 ? 0 : Convert.ToInt16(prevEndMinutes.Value);
            }
            catch
            {
                prevEndMinutes.Value = 0;
            }
            doSongPreview();
            RefreshWindowTitle();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (starting || Importing) return;
            StopBASS();
            doSongPreview();
            RefreshWindowTitle();
        }

        private void chkAuthorDTA_CheckedChanged(object sender, EventArgs e)
        {
            AuthorDTA = chkAuthorDTA.Checked;
        }

        private void removeSubgenre_Click(object sender, EventArgs e)
        {
            doRemoveSubgenre = removeSubgenre.Checked;
        }

        private void cboBandFail_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();
            bandFailIndex = cboBandFail.SelectedIndex;
        }

        private void chkUnpitched_CheckedChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();
        }

        private void picUnpitched_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            chkUnpitched.Checked = !chkUnpitched.Checked;
        }

        private void chkPartial_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPartial.Checked)
            {
                chkKaraoke.Checked = false;
                chkMultitrack.Checked = false;
                chkDIYStems.Checked = false;
                DoShowToast("Song marked as Partial Multitracks");
            }
            RefreshWindowTitle();
        }

        private void scrollDrums_ValueChanged(object sender, EventArgs e)
        {
            lblDrumsDiff.Text = scrollDrums.Value.ToString();
            RefreshWindowTitle();
            var difficulty = getPipDifficultyFromRawValue(scrollDrums.Value, 124, 151, 178, 242, 345, 448);
            UpdateDifficultyDisplayNEMO(PictureDrumDifficulty1, difficulty, difficulty > 0);
        }

        private int getPipDifficultyFromRawValue(int rawDifficulty, int Diff1, int Diff2, int Diff3, int Diff4, int Diff5, int Diff6)
        {
            if (rawDifficulty == 0)
            {
                return 0;
            }
            else
            {
                if (rawDifficulty > 0 && rawDifficulty <= Diff1)
                {
                    return 1;
                }
                else if (rawDifficulty > Diff1 && rawDifficulty <= Diff2)
                {
                    return 2;
                }
                else if (rawDifficulty > Diff2 && rawDifficulty <= Diff3)
                {
                    return 3;
                }
                else if (rawDifficulty > Diff3 && rawDifficulty <= Diff4)
                {
                    return 4;
                }
                else if (rawDifficulty > Diff4 && rawDifficulty <= Diff5)
                {
                    return 5;
                }
                else if (rawDifficulty > Diff5 && rawDifficulty <= Diff6)
                {
                    return 6;
                }
                else if (rawDifficulty > Diff6)
                {
                    return 7;
                }
                else
                {
                    return 0;
                }
            }
        }

        private void scrollBass_ValueChanged(object sender, EventArgs e)
        {
            lblBassDiff.Text = scrollBass.Value.ToString();
            RefreshWindowTitle();
            var difficulty = getPipDifficultyFromRawValue(scrollBass.Value, 135,181,228,293,364,436);
            UpdateDifficultyDisplayNEMO(PictureBassDifficulty1, difficulty, difficulty > 0);
        }

        private void scrollProBass_ValueChanged(object sender, EventArgs e)
        {
            lblProBassDiff.Text = scrollProBass.Value.ToString();
            RefreshWindowTitle();
            var difficulty = getPipDifficultyFromRawValue(scrollProBass.Value, 150,208,267,325,384,442);
            UpdateDifficultyDisplayNEMO(PictureProBassDifficulty1, difficulty, difficulty > 0);
        }

        private void scrollGuitar_ValueChanged(object sender, EventArgs e)
        {
            lblGuitarDiff.Text = scrollGuitar.Value.ToString();
            RefreshWindowTitle();
            var difficulty = getPipDifficultyFromRawValue(scrollGuitar.Value, 139, 176,221,267,333,409);
            UpdateDifficultyDisplayNEMO(PictureGuitarDifficulty1, difficulty, difficulty > 0);
        }

        private void scrollProGuitar_ValueChanged(object sender, EventArgs e)
        {
            lblProGuitarDiff.Text = scrollProGuitar.Value.ToString();
            RefreshWindowTitle();
            var difficulty = getPipDifficultyFromRawValue(scrollProGuitar.Value, 150,208,267,325,384,442);
            UpdateDifficultyDisplayNEMO(PictureProGuitarDifficulty1, difficulty, difficulty > 0);
        }

        private void scrollVocals_ValueChanged(object sender, EventArgs e)
        {
            lblVocalsDiff.Text = scrollVocals.Value.ToString();
            RefreshWindowTitle();
            var difficulty = getPipDifficultyFromRawValue(scrollVocals.Value, 132,175,218,279,353,427);
            UpdateDifficultyDisplayNEMO(PictureVocalDifficulty1, difficulty, difficulty > 0);
        }

        private void scrollKeys_ValueChanged(object sender, EventArgs e)
        {
            lblKeysDiff.Text = scrollKeys.Value.ToString();
            RefreshWindowTitle();
            var difficulty = getPipDifficultyFromRawValue(scrollKeys.Value, 153,211,269,327,385,443);
            UpdateDifficultyDisplayNEMO(PictureKeysDifficulty1, difficulty, difficulty > 0);
        }

        private void scrollProKeys_ValueChanged(object sender, EventArgs e)
        {
            lblProKeysDiff.Text = scrollProKeys.Value.ToString();
            RefreshWindowTitle();
            var difficulty = getPipDifficultyFromRawValue(scrollProKeys.Value, 153, 211, 269, 327, 385, 443);
            UpdateDifficultyDisplayNEMO(PictureProKeysDifficulty1, difficulty, difficulty > 0);
        }

        private void scrollBand_ValueChanged(object sender, EventArgs e)
        {
            lblBandDiff.Text = scrollBand.Value.ToString();
            RefreshWindowTitle();
            var difficulty = getPipDifficultyFromRawValue(scrollBand.Value, 165,215,243,267,292,345);
            UpdateDifficultyDisplayNEMO(PictureBandDifficulty1, difficulty, difficulty > 0);
        }

        private void cboEncodingQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            EncodingQuality = cboEncodingQuality.SelectedIndex + 1;
        }
    }
}
