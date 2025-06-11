using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MagmaRokOn
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private TabControl TopLevelTabs;
        private FolderBrowserDialog FolderBrowserDialogOutput;
        private ErrorProvider ErrorProviderCharCheck;
        private TabPage TabPageInformation;
        private TabPage TabPageAudio;
        private NumericUpDown NumericTrackNumber;
        private Label LabelTrackNumber;
        private Label LabelLanguages;
        private CheckBox CheckBoxLangItalian;
        private CheckBox CheckBoxLangEnglish;
        private CheckBox CheckBoxLangFrench;
        private CheckBox CheckBoxLangSpanish;
        private Label LabelAuthor;
        private TextBox TextBoxAuthor;
        private ComboBox ComboBoxGenre;
        private Label LabelGenre;
        private Label LabelSubgenre;
        private ComboBox ComboBoxSubGenre;
        private Label LabelSongName;
        private TextBox TextBoxSongName;
        private TextBox TextBoxArtistName;
        private Label LabelArtist;
        private TextBox TextBoxAlbumName;
        private Label LabelYearReleased;
        private NumericUpDown NumericUpDownYear;
        private PictureBox PictureBandDifficulty6;
        private PictureBox PictureBandDifficulty5;
        private PictureBox PictureBandDifficulty4;
        private PictureBox PictureBandDifficulty3;
        private PictureBox PictureBandDifficulty2;
        private PictureBox PictureBandDifficulty7;
        private PictureBox PictureBandDifficulty1;
        private Label LabelBandDifficulty;
        private PictureBox PictureDrumDifficulty6;
        private PictureBox PictureDrumDifficulty5;
        private PictureBox PictureDrumDifficulty4;
        private PictureBox PictureDrumDifficulty3;
        private PictureBox PictureDrumDifficulty2;
        private PictureBox PictureDrumDifficulty7;
        private PictureBox PictureDrumDifficulty1;
        private PictureBox PictureBassDifficulty6;
        private PictureBox PictureBassDifficulty5;
        private PictureBox PictureBassDifficulty4;
        private PictureBox PictureBassDifficulty3;
        private PictureBox PictureBassDifficulty2;
        private PictureBox PictureBassDifficulty7;
        private PictureBox PictureBassDifficulty1;
        private ComboBox ComboVocalScroll;
        private ComboBox ComboVocalPercussion;
        private ComboBox ComboVocalGender;
        private Label LabelVocalScroll;
        private Label LabelPercussion;
        private Label LabelVocalGender;
        private PictureBox PictureVocalDifficulty6;
        private PictureBox PictureVocalDifficulty5;
        private PictureBox PictureVocalDifficulty4;
        private PictureBox PictureVocalDifficulty3;
        private PictureBox PictureVocalDifficulty2;
        private PictureBox PictureVocalDifficulty7;
        private PictureBox PictureVocalDifficulty1;
        private PictureBox PictureGuitarDifficulty6;
        private PictureBox PictureGuitarDifficulty5;
        private PictureBox PictureGuitarDifficulty4;
        private PictureBox PictureGuitarDifficulty3;
        private PictureBox PictureGuitarDifficulty2;
        private PictureBox PictureGuitarDifficulty7;
        private PictureBox PictureGuitarDifficulty1;
        private TabPage TabPageGameData;
        private Label LabelLength;
        private ComboBox ComboAnimationSpeed;
        private Label LabelAnimationSpeed;
        private NumericUpDown NumericPreviewMins;
        private Label LabelStartPreview;
        private Label LabelMIDI;
        private TextBox TextBoxMidiFile;
        private Label LabelSongLength;
        private Button ButtonExportMIDI;
        private GroupBox GroupBoxDifficulty;
        private Label LabelVocalDifficulty;
        private Label LabelGuitarDifficulty;
        private Label LabelBassDifficulty;
        private Label LabelDrumDifficulty;
        private Label LabelPreviewSeparator;
        private DomainUpDown DomainPreviewSecs;
        private CheckBox CheckBoxFromAlbum;
        private Label LabelAlbumName;
        private Panel PanelHeader;
        private Button ButtonClearAlbumArt;
        private TextBox TextBoxAlbumArt;
        private PictureBox PictureBoxAlbumArt;
        private Button ButtonGameDataTab;
        private Button ButtonAudioTab;
        private Button ButtonInformationTab;
        private PictureBox PictureBoxMagmaLogoTop;
        private Button ButtonAlbumArt;
        private ComboBox ComboBoxAutogenTheme;
        private Label LabelAutogenTheme;
        private CheckBox CheckBoxLangGerman;
        private CheckBox CheckBoxLangJapanese;
        private Label LabelKeysDifficulty;
        private PictureBox PictureKeysDifficulty6;
        private PictureBox PictureKeysDifficulty5;
        private PictureBox PictureKeysDifficulty4;
        private PictureBox PictureKeysDifficulty3;
        private PictureBox PictureKeysDifficulty2;
        private PictureBox PictureKeysDifficulty7;
        private PictureBox PictureKeysDifficulty1;
        private Label LabelProKeysDifficulty;
        private PictureBox PictureProKeysDifficulty6;
        private PictureBox PictureProKeysDifficulty5;
        private PictureBox PictureProKeysDifficulty4;
        private PictureBox PictureProKeysDifficulty3;
        private PictureBox PictureProKeysDifficulty2;
        private PictureBox PictureProKeysDifficulty7;
        private PictureBox PictureProKeysDifficulty1;
        private Label LabelVocalGuidePitch;
        private NumericUpDown NumericGuidePitchAttenuation;
        private ToolTip ToolTip;
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
         {
            try
            {
                if (disposing && components != null)
                    components.Dispose();
                base.Dispose(disposing);
            }
            catch (Exception)
            {
                Close();
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCONLIVEFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSongsdtaFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSonginiFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importpngxboxFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.wiiConversion = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useSilenceTracksByDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.use441KHzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.use48KHzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.use441KHz24bitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.use48KHz24bitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyzeMIDIFileForContents = new System.Windows.Forms.ToolStripMenuItem();
            this.overrideProjectFileAuthor = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRBAFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.signSongAsLIVE = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.useUniqueNumericSongID = new System.Windows.Forms.ToolStripMenuItem();
            this.batchReplaceSongIDs = new System.Windows.Forms.ToolStripMenuItem();
            this.batchRestoreSongIDs = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseSongVersionAutomatically = new System.Windows.Forms.ToolStripMenuItem();
            this.appendSongVersionToSongID = new System.Windows.Forms.ToolStripMenuItem();
            this.appendSongVersionToFileName = new System.Windows.Forms.ToolStripMenuItem();
            this.appendrb3conToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSubgenre = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.keepSongsdtaFile = new System.Windows.Forms.ToolStripMenuItem();
            this.doNotDeleteExtractedFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.aNSIMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.uTF8Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.openToDoListByDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.showToast = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.skinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.burnBabyBurn = new System.Windows.Forms.ToolStripMenuItem();
            this.cIsForColorfulTool = new System.Windows.Forms.ToolStripMenuItem();
            this.oldDarkTool = new System.Windows.Forms.ToolStripMenuItem();
            this.customSkinTool = new System.Windows.Forms.ToolStripMenuItem();
            this.aDVANCEDUSEONLYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overrideAlbumArt = new System.Windows.Forms.ToolStripMenuItem();
            this.overrideMIDIFile = new System.Windows.Forms.ToolStripMenuItem();
            this.overrideAudioFile = new System.Windows.Forms.ToolStripMenuItem();
            this.overrideMiloFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.albumArtDimensions = new System.Windows.Forms.ToolStripMenuItem();
            this.x256 = new System.Windows.Forms.ToolStripMenuItem();
            this.x512 = new System.Windows.Forms.ToolStripMenuItem();
            this.x1024 = new System.Windows.Forms.ToolStripMenuItem();
            this.x2048 = new System.Windows.Forms.ToolStripMenuItem();
            this.neverCheckForTempoMap = new System.Windows.Forms.ToolStripMenuItem();
            this.bypassNemosMIDIValidator = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.selectNautilusPath = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAudacityPath = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCompilerExecutable = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.viewChangeLog = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopLevelTabs = new System.Windows.Forms.TabControl();
            this.TabPageInformation = new System.Windows.Forms.TabPage();
            this.chkPartial = new System.Windows.Forms.CheckBox();
            this.picPartial = new System.Windows.Forms.PictureBox();
            this.chkUnpitched = new System.Windows.Forms.CheckBox();
            this.picUnpitched = new System.Windows.Forms.PictureBox();
            this.chkAuthorDTA = new System.Windows.Forms.CheckBox();
            this.chkDIYStems = new System.Windows.Forms.CheckBox();
            this.picDIYStems = new System.Windows.Forms.PictureBox();
            this.chkCAT = new System.Windows.Forms.CheckBox();
            this.picCAT = new System.Windows.Forms.PictureBox();
            this.picAuthor = new System.Windows.Forms.PictureBox();
            this.picThumb = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectThumbnail = new System.Windows.Forms.ToolStripMenuItem();
            this.clearThumbnailTool = new System.Windows.Forms.ToolStripMenuItem();
            this.useDefaultRB3ImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDispDLC = new System.Windows.Forms.Button();
            this.btnDescDefault = new System.Windows.Forms.Button();
            this.btnDispDefault = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTitleDisplay = new System.Windows.Forms.TextBox();
            this.chkXOnly = new System.Windows.Forms.CheckBox();
            this.picXOnly = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkMaster = new System.Windows.Forms.CheckBox();
            this.chkConvert = new System.Windows.Forms.CheckBox();
            this.chkMultitrack = new System.Windows.Forms.CheckBox();
            this.chkKaraoke = new System.Windows.Forms.CheckBox();
            this.picConvert = new System.Windows.Forms.PictureBox();
            this.picMultitrack = new System.Windows.Forms.PictureBox();
            this.picKaraoke = new System.Windows.Forms.PictureBox();
            this.chk2xBass = new System.Windows.Forms.CheckBox();
            this.chkRhythmBass = new System.Windows.Forms.CheckBox();
            this.chkRhythmKeys = new System.Windows.Forms.CheckBox();
            this.pic2xBass = new System.Windows.Forms.PictureBox();
            this.picRhythmBass = new System.Windows.Forms.PictureBox();
            this.picRhythmKeys = new System.Windows.Forms.PictureBox();
            this.chkReRecord = new System.Windows.Forms.CheckBox();
            this.LabelReRecording = new System.Windows.Forms.Label();
            this.numericReRecord = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxLangJapanese = new System.Windows.Forms.CheckBox();
            this.CheckBoxLangGerman = new System.Windows.Forms.CheckBox();
            this.ButtonAlbumArt = new System.Windows.Forms.Button();
            this.LabelAlbumName = new System.Windows.Forms.Label();
            this.CheckBoxFromAlbum = new System.Windows.Forms.CheckBox();
            this.ButtonClearAlbumArt = new System.Windows.Forms.Button();
            this.TextBoxAlbumArt = new System.Windows.Forms.TextBox();
            this.NumericTrackNumber = new System.Windows.Forms.NumericUpDown();
            this.LabelTrackNumber = new System.Windows.Forms.Label();
            this.LabelLanguages = new System.Windows.Forms.Label();
            this.CheckBoxLangItalian = new System.Windows.Forms.CheckBox();
            this.CheckBoxLangEnglish = new System.Windows.Forms.CheckBox();
            this.CheckBoxLangFrench = new System.Windows.Forms.CheckBox();
            this.CheckBoxLangSpanish = new System.Windows.Forms.CheckBox();
            this.LabelAuthor = new System.Windows.Forms.Label();
            this.TextBoxAuthor = new System.Windows.Forms.TextBox();
            this.ComboBoxGenre = new System.Windows.Forms.ComboBox();
            this.LabelGenre = new System.Windows.Forms.Label();
            this.LabelSubgenre = new System.Windows.Forms.Label();
            this.ComboBoxSubGenre = new System.Windows.Forms.ComboBox();
            this.LabelSongName = new System.Windows.Forms.Label();
            this.TextBoxSongName = new System.Windows.Forms.TextBox();
            this.TextBoxArtistName = new System.Windows.Forms.TextBox();
            this.LabelArtist = new System.Windows.Forms.Label();
            this.TextBoxAlbumName = new System.Windows.Forms.TextBox();
            this.LabelYearReleased = new System.Windows.Forms.Label();
            this.NumericUpDownYear = new System.Windows.Forms.NumericUpDown();
            this.PictureBoxAlbumArt = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.useDefaultArt = new System.Windows.Forms.ToolStripMenuItem();
            this.visitAlbumArtRepository = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPageAudio = new System.Windows.Forms.TabPage();
            this.prevEndMilliseconds = new System.Windows.Forms.NumericUpDown();
            this.prevEndSeconds = new System.Windows.Forms.DomainUpDown();
            this.prevEndMinutes = new System.Windows.Forms.NumericUpDown();
            this.LabelEndPreview = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.picSpectrum = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.numericMilliseconds = new System.Windows.Forms.NumericUpDown();
            this.ZeroCrowd = new System.Windows.Forms.Button();
            this.picHelpCrowd = new System.Windows.Forms.PictureBox();
            this.numericCrowd = new System.Windows.Forms.NumericUpDown();
            this.LabelCrowdPan = new System.Windows.Forms.Label();
            this.ZeroBacking = new System.Windows.Forms.Button();
            this.ZeroVocals = new System.Windows.Forms.Button();
            this.ZeroKeys = new System.Windows.Forms.Button();
            this.ZeroGuitar = new System.Windows.Forms.Button();
            this.ZeroBass = new System.Windows.Forms.Button();
            this.ZeroDrumKick = new System.Windows.Forms.Button();
            this.ZeroDrumSnare = new System.Windows.Forms.Button();
            this.ZeroDrumKit = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.NumericBackingAttenuation = new System.Windows.Forms.NumericUpDown();
            this.NumericVocalAttenuation = new System.Windows.Forms.NumericUpDown();
            this.NumericKeysAttenuation = new System.Windows.Forms.NumericUpDown();
            this.NumericGuitarAttenuation = new System.Windows.Forms.NumericUpDown();
            this.NumericBassAttenuation = new System.Windows.Forms.NumericUpDown();
            this.NumericDrumSnareAttenuation = new System.Windows.Forms.NumericUpDown();
            this.NumericDrumKickAttenuation = new System.Windows.Forms.NumericUpDown();
            this.NumericDrumKitAttenuation = new System.Windows.Forms.NumericUpDown();
            this.LabelBackingPan = new System.Windows.Forms.Label();
            this.NumericBackingPan = new System.Windows.Forms.NumericUpDown();
            this.LabelVocalPan = new System.Windows.Forms.Label();
            this.NumericVocalPan = new System.Windows.Forms.NumericUpDown();
            this.LabelKeysPan = new System.Windows.Forms.Label();
            this.NumericKeysPan = new System.Windows.Forms.NumericUpDown();
            this.LabelGuitarPan = new System.Windows.Forms.Label();
            this.NumericGuitarPan = new System.Windows.Forms.NumericUpDown();
            this.LabelBassPan = new System.Windows.Forms.Label();
            this.NumericBassPan = new System.Windows.Forms.NumericUpDown();
            this.LabelDrumSnarePan = new System.Windows.Forms.Label();
            this.LabelDrumKickPan = new System.Windows.Forms.Label();
            this.LabelDrumKitPan = new System.Windows.Forms.Label();
            this.NumericDrumSnarePan = new System.Windows.Forms.NumericUpDown();
            this.NumericDrumKickPan = new System.Windows.Forms.NumericUpDown();
            this.NumericDrumKitPan = new System.Windows.Forms.NumericUpDown();
            this.ButtonBacking = new System.Windows.Forms.Button();
            this.TextBoxBacking = new System.Windows.Forms.TextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.Mono44SilenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Stereo44SilenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Mono48SilenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Stereo48SilenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.Mono44Silence24 = new System.Windows.Forms.ToolStripMenuItem();
            this.Stereo44Silence24 = new System.Windows.Forms.ToolStripMenuItem();
            this.Mono48Silence24 = new System.Windows.Forms.ToolStripMenuItem();
            this.Stereo48Silence24 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.blankDryvoxFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLeadDryVocalsHere = new System.Windows.Forms.ToolStripMenuItem();
            this.convertVocalsStemToDryvox = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAudioFile = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelBacking = new System.Windows.Forms.Label();
            this.CheckBacking = new System.Windows.Forms.CheckBox();
            this.CheckHarmonyVocals3 = new System.Windows.Forms.CheckBox();
            this.LabelDryVocalsHarmony3 = new System.Windows.Forms.Label();
            this.ButtonDryVocalsHarmony3 = new System.Windows.Forms.Button();
            this.TextBoxDryVocalsHarmony3 = new System.Windows.Forms.TextBox();
            this.CheckHarmonyVocals2 = new System.Windows.Forms.CheckBox();
            this.LabelDryVocalsHarmony2 = new System.Windows.Forms.Label();
            this.ButtonDryVocalsHarmony2 = new System.Windows.Forms.Button();
            this.ButtonDryVocals = new System.Windows.Forms.Button();
            this.TextBoxDryVocals = new System.Windows.Forms.TextBox();
            this.TextBoxDryVocalsHarmony2 = new System.Windows.Forms.TextBox();
            this.LabelDryVocals = new System.Windows.Forms.Label();
            this.ButtonVocals = new System.Windows.Forms.Button();
            this.TextBoxVocals = new System.Windows.Forms.TextBox();
            this.LabelVocals = new System.Windows.Forms.Label();
            this.CheckVocals = new System.Windows.Forms.CheckBox();
            this.ButtonKeys = new System.Windows.Forms.Button();
            this.TextBoxKeys = new System.Windows.Forms.TextBox();
            this.LabelKeys = new System.Windows.Forms.Label();
            this.CheckKeys = new System.Windows.Forms.CheckBox();
            this.ButtonGuitar = new System.Windows.Forms.Button();
            this.TextBoxGuitar = new System.Windows.Forms.TextBox();
            this.LabelGuitar = new System.Windows.Forms.Label();
            this.CheckGuitar = new System.Windows.Forms.CheckBox();
            this.ButtonBass = new System.Windows.Forms.Button();
            this.TextBoxBass = new System.Windows.Forms.TextBox();
            this.LabelBass = new System.Windows.Forms.Label();
            this.CheckBass = new System.Windows.Forms.CheckBox();
            this.ComboDrums = new System.Windows.Forms.ComboBox();
            this.LabelDrumSnare = new System.Windows.Forms.Label();
            this.LabelDrumKick = new System.Windows.Forms.Label();
            this.LabelDrumKit = new System.Windows.Forms.Label();
            this.ButtonDrumSnare = new System.Windows.Forms.Button();
            this.TextBoxDrumSnare = new System.Windows.Forms.TextBox();
            this.ButtonDrumKick = new System.Windows.Forms.Button();
            this.TextBoxDrumKick = new System.Windows.Forms.TextBox();
            this.ButtonDrumKit = new System.Windows.Forms.Button();
            this.LabelDrums = new System.Windows.Forms.Label();
            this.TextBoxDrumKit = new System.Windows.Forms.TextBox();
            this.CheckDrums = new System.Windows.Forms.CheckBox();
            this.btnCrowd = new System.Windows.Forms.Button();
            this.TextBoxCrowd = new System.Windows.Forms.TextBox();
            this.LabelCrowd = new System.Windows.Forms.Label();
            this.CheckCrowd = new System.Windows.Forms.CheckBox();
            this.EncodingQualityUpDown = new System.Windows.Forms.DomainUpDown();
            this.LabelEncodingQuality = new System.Windows.Forms.Label();
            this.groupDrumMix = new System.Windows.Forms.GroupBox();
            this.chkDrumsMix = new System.Windows.Forms.CheckBox();
            this.lblDrumMix = new System.Windows.Forms.Label();
            this.DomainPreviewSecs = new System.Windows.Forms.DomainUpDown();
            this.NumericPreviewMins = new System.Windows.Forms.NumericUpDown();
            this.LabelStartPreview = new System.Windows.Forms.Label();
            this.LabelSongLength = new System.Windows.Forms.Label();
            this.LabelLength = new System.Windows.Forms.Label();
            this.LabelPreviewSeparator = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TabPageGameData = new System.Windows.Forms.TabPage();
            this.cboBandFail = new System.Windows.Forms.ComboBox();
            this.LabelBandFail = new System.Windows.Forms.Label();
            this.cboTonality = new System.Windows.Forms.ComboBox();
            this.picHelpSolos = new System.Windows.Forms.PictureBox();
            this.chkSoloVocals = new System.Windows.Forms.CheckBox();
            this.chkSoloKeys = new System.Windows.Forms.CheckBox();
            this.chkSoloBass = new System.Windows.Forms.CheckBox();
            this.chkSoloGuitar = new System.Windows.Forms.CheckBox();
            this.chkSoloDrums = new System.Windows.Forms.CheckBox();
            this.LabelSolos = new System.Windows.Forms.Label();
            this.btnCleaner = new System.Windows.Forms.Button();
            this.btnTester = new System.Windows.Forms.Button();
            this.ButtonBrowseForMIDI = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkTempo = new System.Windows.Forms.CheckBox();
            this.chkKeysAnim = new System.Windows.Forms.CheckBox();
            this.chkAutoKeys = new System.Windows.Forms.CheckBox();
            this.picHelpMuteVol = new System.Windows.Forms.PictureBox();
            this.LabelMuteVolume = new System.Windows.Forms.Label();
            this.numericMuteVol = new System.Windows.Forms.NumericUpDown();
            this.LabelMuteVolumeVocals = new System.Windows.Forms.Label();
            this.numericVocalMute = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numVersion = new System.Windows.Forms.NumericUpDown();
            this.groupID = new System.Windows.Forms.GroupBox();
            this.btnID = new System.Windows.Forms.Button();
            this.txtSongID = new System.Windows.Forms.TextBox();
            this.picDrumSFX = new System.Windows.Forms.PictureBox();
            this.picHelpTuningCents = new System.Windows.Forms.PictureBox();
            this.LabelTuningCents = new System.Windows.Forms.Label();
            this.numericTuningCents = new System.Windows.Forms.NumericUpDown();
            this.ComboDrumSFX = new System.Windows.Forms.ComboBox();
            this.LabelDrumKitSFX = new System.Windows.Forms.Label();
            this.ComboHopo = new System.Windows.Forms.ComboBox();
            this.LabelHopoThreshold = new System.Windows.Forms.Label();
            this.picHelpGuitarTuning = new System.Windows.Forms.PictureBox();
            this.BassTuning4 = new System.Windows.Forms.TextBox();
            this.BassTuning3 = new System.Windows.Forms.TextBox();
            this.BassTuning2 = new System.Windows.Forms.TextBox();
            this.BassTuning1 = new System.Windows.Forms.TextBox();
            this.GuitarTuning6 = new System.Windows.Forms.TextBox();
            this.GuitarTuning5 = new System.Windows.Forms.TextBox();
            this.GuitarTuning4 = new System.Windows.Forms.TextBox();
            this.GuitarTuning3 = new System.Windows.Forms.TextBox();
            this.GuitarTuning2 = new System.Windows.Forms.TextBox();
            this.GuitarTuning1 = new System.Windows.Forms.TextBox();
            this.LabelBassTuning = new System.Windows.Forms.Label();
            this.LabelGuitarTuning = new System.Windows.Forms.Label();
            this.ComboRating = new System.Windows.Forms.ComboBox();
            this.LabelSongRating = new System.Windows.Forms.Label();
            this.picHelpTonicNote = new System.Windows.Forms.PictureBox();
            this.chkTonicNote = new System.Windows.Forms.CheckBox();
            this.ComboTonicNote = new System.Windows.Forms.ComboBox();
            this.NumericGuidePitchAttenuation = new System.Windows.Forms.NumericUpDown();
            this.LabelVocalGuidePitch = new System.Windows.Forms.Label();
            this.ComboBoxAutogenTheme = new System.Windows.Forms.ComboBox();
            this.LabelAutogenTheme = new System.Windows.Forms.Label();
            this.ComboAnimationSpeed = new System.Windows.Forms.ComboBox();
            this.LabelAnimationSpeed = new System.Windows.Forms.Label();
            this.LabelMIDI = new System.Windows.Forms.Label();
            this.TextBoxMidiFile = new System.Windows.Forms.TextBox();
            this.ComboVocalScroll = new System.Windows.Forms.ComboBox();
            this.ComboVocalPercussion = new System.Windows.Forms.ComboBox();
            this.ComboVocalGender = new System.Windows.Forms.ComboBox();
            this.LabelVocalScroll = new System.Windows.Forms.Label();
            this.LabelPercussion = new System.Windows.Forms.Label();
            this.LabelVocalGender = new System.Windows.Forms.Label();
            this.GroupBoxDifficulty = new System.Windows.Forms.GroupBox();
            this.lblBandDiff = new System.Windows.Forms.Label();
            this.scrollBand = new System.Windows.Forms.HScrollBar();
            this.lblProKeysDiff = new System.Windows.Forms.Label();
            this.scrollProKeys = new System.Windows.Forms.HScrollBar();
            this.lblKeysDiff = new System.Windows.Forms.Label();
            this.scrollKeys = new System.Windows.Forms.HScrollBar();
            this.lblVocalsDiff = new System.Windows.Forms.Label();
            this.scrollVocals = new System.Windows.Forms.HScrollBar();
            this.lblProGuitarDiff = new System.Windows.Forms.Label();
            this.scrollProGuitar = new System.Windows.Forms.HScrollBar();
            this.lblGuitarDiff = new System.Windows.Forms.Label();
            this.scrollGuitar = new System.Windows.Forms.HScrollBar();
            this.lblProBassDiff = new System.Windows.Forms.Label();
            this.scrollProBass = new System.Windows.Forms.HScrollBar();
            this.lblBassDiff = new System.Windows.Forms.Label();
            this.scrollBass = new System.Windows.Forms.HScrollBar();
            this.lblDrumsDiff = new System.Windows.Forms.Label();
            this.scrollDrums = new System.Windows.Forms.HScrollBar();
            this.PictureBandDifficulty6 = new System.Windows.Forms.PictureBox();
            this.PictureProKeysDifficulty6 = new System.Windows.Forms.PictureBox();
            this.PictureBandDifficulty5 = new System.Windows.Forms.PictureBox();
            this.PictureKeysDifficulty6 = new System.Windows.Forms.PictureBox();
            this.PictureBandDifficulty4 = new System.Windows.Forms.PictureBox();
            this.PictureProKeysDifficulty5 = new System.Windows.Forms.PictureBox();
            this.PictureBandDifficulty3 = new System.Windows.Forms.PictureBox();
            this.PictureProKeysDifficulty4 = new System.Windows.Forms.PictureBox();
            this.PictureBandDifficulty2 = new System.Windows.Forms.PictureBox();
            this.PictureBandDifficulty7 = new System.Windows.Forms.PictureBox();
            this.PictureKeysDifficulty5 = new System.Windows.Forms.PictureBox();
            this.PictureBandDifficulty1 = new System.Windows.Forms.PictureBox();
            this.PictureProKeysDifficulty3 = new System.Windows.Forms.PictureBox();
            this.PictureVocalDifficulty6 = new System.Windows.Forms.PictureBox();
            this.PictureProKeysDifficulty2 = new System.Windows.Forms.PictureBox();
            this.PictureKeysDifficulty4 = new System.Windows.Forms.PictureBox();
            this.PictureProKeysDifficulty7 = new System.Windows.Forms.PictureBox();
            this.PictureVocalDifficulty5 = new System.Windows.Forms.PictureBox();
            this.PictureProKeysDifficulty1 = new System.Windows.Forms.PictureBox();
            this.PictureKeysDifficulty3 = new System.Windows.Forms.PictureBox();
            this.PictureProGuitarDifficulty6 = new System.Windows.Forms.PictureBox();
            this.PictureKeysDifficulty2 = new System.Windows.Forms.PictureBox();
            this.PictureVocalDifficulty4 = new System.Windows.Forms.PictureBox();
            this.PictureKeysDifficulty7 = new System.Windows.Forms.PictureBox();
            this.PictureGuitarDifficulty6 = new System.Windows.Forms.PictureBox();
            this.PictureKeysDifficulty1 = new System.Windows.Forms.PictureBox();
            this.PictureVocalDifficulty3 = new System.Windows.Forms.PictureBox();
            this.PictureProGuitarDifficulty5 = new System.Windows.Forms.PictureBox();
            this.PictureVocalDifficulty2 = new System.Windows.Forms.PictureBox();
            this.PictureProBassDifficulty6 = new System.Windows.Forms.PictureBox();
            this.PictureVocalDifficulty7 = new System.Windows.Forms.PictureBox();
            this.PictureProGuitarDifficulty4 = new System.Windows.Forms.PictureBox();
            this.PictureVocalDifficulty1 = new System.Windows.Forms.PictureBox();
            this.PictureGuitarDifficulty5 = new System.Windows.Forms.PictureBox();
            this.PictureProGuitarDifficulty3 = new System.Windows.Forms.PictureBox();
            this.PictureProBassDifficulty5 = new System.Windows.Forms.PictureBox();
            this.PictureProGuitarDifficulty2 = new System.Windows.Forms.PictureBox();
            this.PictureGuitarDifficulty4 = new System.Windows.Forms.PictureBox();
            this.PictureProGuitarDifficulty7 = new System.Windows.Forms.PictureBox();
            this.PictureProGuitarDifficulty1 = new System.Windows.Forms.PictureBox();
            this.PictureBassDifficulty6 = new System.Windows.Forms.PictureBox();
            this.PictureGuitarDifficulty3 = new System.Windows.Forms.PictureBox();
            this.PictureProBassDifficulty4 = new System.Windows.Forms.PictureBox();
            this.PictureGuitarDifficulty2 = new System.Windows.Forms.PictureBox();
            this.PictureDrumDifficulty6 = new System.Windows.Forms.PictureBox();
            this.PictureGuitarDifficulty7 = new System.Windows.Forms.PictureBox();
            this.PictureGuitarDifficulty1 = new System.Windows.Forms.PictureBox();
            this.PictureProBassDifficulty3 = new System.Windows.Forms.PictureBox();
            this.PictureBassDifficulty5 = new System.Windows.Forms.PictureBox();
            this.PictureProBassDifficulty2 = new System.Windows.Forms.PictureBox();
            this.PictureBassDifficulty4 = new System.Windows.Forms.PictureBox();
            this.PictureProBassDifficulty7 = new System.Windows.Forms.PictureBox();
            this.PictureDrumDifficulty5 = new System.Windows.Forms.PictureBox();
            this.PictureProBassDifficulty1 = new System.Windows.Forms.PictureBox();
            this.PictureBassDifficulty3 = new System.Windows.Forms.PictureBox();
            this.chkProGuitar = new System.Windows.Forms.CheckBox();
            this.PictureBassDifficulty2 = new System.Windows.Forms.PictureBox();
            this.PictureDrumDifficulty4 = new System.Windows.Forms.PictureBox();
            this.PictureBassDifficulty7 = new System.Windows.Forms.PictureBox();
            this.LabelProGuitar = new System.Windows.Forms.Label();
            this.PictureBassDifficulty1 = new System.Windows.Forms.PictureBox();
            this.PictureDrumDifficulty3 = new System.Windows.Forms.PictureBox();
            this.PictureDrumDifficulty2 = new System.Windows.Forms.PictureBox();
            this.chkProBass = new System.Windows.Forms.CheckBox();
            this.PictureDrumDifficulty7 = new System.Windows.Forms.PictureBox();
            this.LabelProBass = new System.Windows.Forms.Label();
            this.PictureDrumDifficulty1 = new System.Windows.Forms.PictureBox();
            this.chkProKeys = new System.Windows.Forms.CheckBox();
            this.LabelProKeysDifficulty = new System.Windows.Forms.Label();
            this.LabelKeysDifficulty = new System.Windows.Forms.Label();
            this.LabelVocalDifficulty = new System.Windows.Forms.Label();
            this.LabelGuitarDifficulty = new System.Windows.Forms.Label();
            this.LabelBassDifficulty = new System.Windows.Forms.Label();
            this.LabelDrumDifficulty = new System.Windows.Forms.Label();
            this.LabelBandDifficulty = new System.Windows.Forms.Label();
            this.ButtonExportMIDI = new System.Windows.Forms.Button();
            this.chkTonality = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentListAsTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.ButtonBuildTo = new System.Windows.Forms.Button();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.LabelBuildTo = new System.Windows.Forms.Label();
            this.ButtonBuildSong = new System.Windows.Forms.Button();
            this.TextBoxBuildDestination = new System.Windows.Forms.TextBox();
            this.FolderBrowserDialogOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.ErrorProviderCharCheck = new System.Windows.Forms.ErrorProvider(this.components);
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ButtonGameDataTab = new System.Windows.Forms.Button();
            this.ButtonAudioTab = new System.Windows.Forms.Button();
            this.ButtonInformationTab = new System.Windows.Forms.Button();
            this.picTemplate = new System.Windows.Forms.PictureBox();
            this.picImportant = new System.Windows.Forms.PictureBox();
            this.picRemove = new System.Windows.Forms.PictureBox();
            this.picDone = new System.Windows.Forms.PictureBox();
            this.picWii = new System.Windows.Forms.PictureBox();
            this.PictureBoxMagmaLogoTop = new System.Windows.Forms.PictureBox();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.picChecklist = new System.Windows.Forms.PictureBox();
            this.todo1 = new System.Windows.Forms.TextBox();
            this.list1 = new System.Windows.Forms.TextBox();
            this.todo2 = new System.Windows.Forms.TextBox();
            this.list2 = new System.Windows.Forms.TextBox();
            this.todo3 = new System.Windows.Forms.TextBox();
            this.list3 = new System.Windows.Forms.TextBox();
            this.todo4 = new System.Windows.Forms.TextBox();
            this.list4 = new System.Windows.Forms.TextBox();
            this.todo5 = new System.Windows.Forms.TextBox();
            this.list5 = new System.Windows.Forms.TextBox();
            this.todo6 = new System.Windows.Forms.TextBox();
            this.list6 = new System.Windows.Forms.TextBox();
            this.todo7 = new System.Windows.Forms.TextBox();
            this.list7 = new System.Windows.Forms.TextBox();
            this.todo8 = new System.Windows.Forms.TextBox();
            this.list8 = new System.Windows.Forms.TextBox();
            this.todo9 = new System.Windows.Forms.TextBox();
            this.list9 = new System.Windows.Forms.TextBox();
            this.todo10 = new System.Windows.Forms.TextBox();
            this.list10 = new System.Windows.Forms.TextBox();
            this.todo11 = new System.Windows.Forms.TextBox();
            this.list11 = new System.Windows.Forms.TextBox();
            this.todo12 = new System.Windows.Forms.TextBox();
            this.list12 = new System.Windows.Forms.TextBox();
            this.todo13 = new System.Windows.Forms.TextBox();
            this.list13 = new System.Windows.Forms.TextBox();
            this.todo14 = new System.Windows.Forms.TextBox();
            this.list14 = new System.Windows.Forms.TextBox();
            this.todo15 = new System.Windows.Forms.TextBox();
            this.list15 = new System.Windows.Forms.TextBox();
            this.todoPic = new System.Windows.Forms.PictureBox();
            this.panelTODO = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.PlaybackTimer = new System.Windows.Forms.Timer(this.components);
            this.updater = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.TopLevelTabs.SuspendLayout();
            this.TabPageInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPartial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUnpitched)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDIYStems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAuthor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumb)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picXOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConvert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMultitrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKaraoke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2xBass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRhythmBass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRhythmKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericTrackNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxAlbumArt)).BeginInit();
            this.contextMenuStrip4.SuspendLayout();
            this.TabPageAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prevEndMilliseconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevEndMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpectrum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMilliseconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpCrowd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCrowd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBackingAttenuation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericVocalAttenuation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericKeysAttenuation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericGuitarAttenuation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBassAttenuation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDrumSnareAttenuation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDrumKickAttenuation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDrumKitAttenuation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBackingPan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericVocalPan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericKeysPan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericGuitarPan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBassPan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDrumSnarePan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDrumKickPan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDrumKitPan)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.groupDrumMix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPreviewMins)).BeginInit();
            this.TabPageGameData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpSolos)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpMuteVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMuteVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVocalMute)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVersion)).BeginInit();
            this.groupID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDrumSFX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpTuningCents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTuningCents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpGuitarTuning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpTonicNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericGuidePitchAttenuation)).BeginInit();
            this.GroupBoxDifficulty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty1)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            this.PanelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProviderCharCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImportant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWii)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMagmaLogoTop)).BeginInit();
            this.PanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChecklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoPic)).BeginInit();
            this.panelTODO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(152, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.importSongToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.FileNewMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.FileOpenMenuItem_Click);
            // 
            // importSongToolStripMenuItem
            // 
            this.importSongToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.importSongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCONLIVEFileToolStripMenuItem,
            this.importSongsdtaFileToolStripMenuItem,
            this.importSonginiFileToolStripMenuItem,
            this.importpngxboxFileToolStripMenuItem,
            this.toolStripMenuItem8,
            this.wiiConversion});
            this.importSongToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.importSongToolStripMenuItem.Name = "importSongToolStripMenuItem";
            this.importSongToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importSongToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.importSongToolStripMenuItem.Text = "&Import...";
            // 
            // importCONLIVEFileToolStripMenuItem
            // 
            this.importCONLIVEFileToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.importCONLIVEFileToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.importCONLIVEFileToolStripMenuItem.Name = "importCONLIVEFileToolStripMenuItem";
            this.importCONLIVEFileToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.importCONLIVEFileToolStripMenuItem.Text = "Import CON file";
            this.importCONLIVEFileToolStripMenuItem.ToolTipText = "Click here to import a song in CON/LIVE format to its individual parts so you can" +
    " modify it";
            this.importCONLIVEFileToolStripMenuItem.Click += new System.EventHandler(this.importCONLIVEFileToolStripMenuItem_Click);
            // 
            // importSongsdtaFileToolStripMenuItem
            // 
            this.importSongsdtaFileToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.importSongsdtaFileToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.importSongsdtaFileToolStripMenuItem.Name = "importSongsdtaFileToolStripMenuItem";
            this.importSongsdtaFileToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.importSongsdtaFileToolStripMenuItem.Text = "Import songs.dta file";
            this.importSongsdtaFileToolStripMenuItem.ToolTipText = "Click here to import all the metadata from a songs.dta file into your project";
            this.importSongsdtaFileToolStripMenuItem.Click += new System.EventHandler(this.importSongsdtaFileToolStripMenuItem_Click);
            // 
            // importSonginiFileToolStripMenuItem
            // 
            this.importSonginiFileToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.importSonginiFileToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.importSonginiFileToolStripMenuItem.Name = "importSonginiFileToolStripMenuItem";
            this.importSonginiFileToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.importSonginiFileToolStripMenuItem.Text = "Import song.ini file";
            this.importSonginiFileToolStripMenuItem.Click += new System.EventHandler(this.importSonginiFileToolStripMenuItem_Click);
            // 
            // importpngxboxFileToolStripMenuItem
            // 
            this.importpngxboxFileToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.importpngxboxFileToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.importpngxboxFileToolStripMenuItem.Name = "importpngxboxFileToolStripMenuItem";
            this.importpngxboxFileToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.importpngxboxFileToolStripMenuItem.Text = "Import .png_xbox file";
            this.importpngxboxFileToolStripMenuItem.ToolTipText = "Click here to import and convert to bmp a Rock Band album art file";
            this.importpngxboxFileToolStripMenuItem.Click += new System.EventHandler(this.importpngxboxFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(193, 6);
            // 
            // wiiConversion
            // 
            this.wiiConversion.BackColor = System.Drawing.Color.Black;
            this.wiiConversion.CheckOnClick = true;
            this.wiiConversion.ForeColor = System.Drawing.Color.LightGray;
            this.wiiConversion.Name = "wiiConversion";
            this.wiiConversion.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.wiiConversion.Size = new System.Drawing.Size(196, 22);
            this.wiiConversion.Text = "Wii Mode";
            this.wiiConversion.CheckedChanged += new System.EventHandler(this.wiiConversion_CheckedChanged);
            this.wiiConversion.Click += new System.EventHandler(this.wiiConversion_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.FileSaveMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Space)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.FileSaveAsMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.FileExitMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useSilenceTracksByDefault,
            this.analyzeMIDIFileForContents,
            this.overrideProjectFileAuthor,
            this.deleteRBAFiles,
            this.signSongAsLIVE,
            this.toolStripMenuItem1,
            this.useUniqueNumericSongID,
            this.increaseSongVersionAutomatically,
            this.appendSongVersionToSongID,
            this.appendSongVersionToFileName,
            this.appendrb3conToFile,
            this.removeSubgenre,
            this.toolStripSeparator1,
            this.keepSongsdtaFile,
            this.doNotDeleteExtractedFiles,
            this.toolStripMenuItem2,
            this.aNSIMenu,
            this.uTF8Menu,
            this.toolStripMenuItem3,
            this.openToDoListByDefault,
            this.showToast,
            this.toolStripMenuItem4,
            this.skinsToolStripMenuItem,
            this.aDVANCEDUSEONLYToolStripMenuItem});
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // useSilenceTracksByDefault
            // 
            this.useSilenceTracksByDefault.BackColor = System.Drawing.Color.Black;
            this.useSilenceTracksByDefault.Checked = true;
            this.useSilenceTracksByDefault.CheckOnClick = true;
            this.useSilenceTracksByDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useSilenceTracksByDefault.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.use441KHzToolStripMenuItem,
            this.use48KHzToolStripMenuItem,
            this.toolStripMenuItem9,
            this.use441KHz24bitToolStripMenuItem,
            this.use48KHz24bitToolStripMenuItem});
            this.useSilenceTracksByDefault.ForeColor = System.Drawing.Color.LightGray;
            this.useSilenceTracksByDefault.Name = "useSilenceTracksByDefault";
            this.useSilenceTracksByDefault.Size = new System.Drawing.Size(280, 22);
            this.useSilenceTracksByDefault.Text = "Use silence tracks by default";
            this.useSilenceTracksByDefault.ToolTipText = "Check to automatically populate the instrument audio with silence tracks";
            this.useSilenceTracksByDefault.Click += new System.EventHandler(this.useSilenceTracksByDefaultToolStripMenuItem_Click);
            // 
            // use441KHzToolStripMenuItem
            // 
            this.use441KHzToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.use441KHzToolStripMenuItem.Checked = true;
            this.use441KHzToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.use441KHzToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.use441KHzToolStripMenuItem.Name = "use441KHzToolStripMenuItem";
            this.use441KHzToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.use441KHzToolStripMenuItem.Text = "Use 44.1 kHz";
            this.use441KHzToolStripMenuItem.Click += new System.EventHandler(this.use441KHzToolStripMenuItem_Click);
            // 
            // use48KHzToolStripMenuItem
            // 
            this.use48KHzToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.use48KHzToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.use48KHzToolStripMenuItem.Name = "use48KHzToolStripMenuItem";
            this.use48KHzToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.use48KHzToolStripMenuItem.Text = "Use 48 kHz";
            this.use48KHzToolStripMenuItem.Click += new System.EventHandler(this.use48KHzToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(190, 6);
            // 
            // use441KHz24bitToolStripMenuItem
            // 
            this.use441KHz24bitToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.use441KHz24bitToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.use441KHz24bitToolStripMenuItem.Name = "use441KHz24bitToolStripMenuItem";
            this.use441KHz24bitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.use441KHz24bitToolStripMenuItem.Text = "Use 44.1 kHz (24-bit)";
            this.use441KHz24bitToolStripMenuItem.Click += new System.EventHandler(this.use441KHz24bitToolStripMenuItem_Click);
            // 
            // use48KHz24bitToolStripMenuItem
            // 
            this.use48KHz24bitToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.use48KHz24bitToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.use48KHz24bitToolStripMenuItem.Name = "use48KHz24bitToolStripMenuItem";
            this.use48KHz24bitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.use48KHz24bitToolStripMenuItem.Text = "Use 48 kHz (24-bit)";
            this.use48KHz24bitToolStripMenuItem.Click += new System.EventHandler(this.use48KHz24bitToolStripMenuItem_Click);
            // 
            // analyzeMIDIFileForContents
            // 
            this.analyzeMIDIFileForContents.BackColor = System.Drawing.Color.Black;
            this.analyzeMIDIFileForContents.Checked = true;
            this.analyzeMIDIFileForContents.CheckOnClick = true;
            this.analyzeMIDIFileForContents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.analyzeMIDIFileForContents.ForeColor = System.Drawing.Color.LightGray;
            this.analyzeMIDIFileForContents.Name = "analyzeMIDIFileForContents";
            this.analyzeMIDIFileForContents.Size = new System.Drawing.Size(280, 22);
            this.analyzeMIDIFileForContents.Text = "Analyze MIDI file for contents";
            this.analyzeMIDIFileForContents.Click += new System.EventHandler(this.analyzeMIDIFileForContents_Click);
            // 
            // overrideProjectFileAuthor
            // 
            this.overrideProjectFileAuthor.BackColor = System.Drawing.Color.Black;
            this.overrideProjectFileAuthor.CheckOnClick = true;
            this.overrideProjectFileAuthor.ForeColor = System.Drawing.Color.LightGray;
            this.overrideProjectFileAuthor.Name = "overrideProjectFileAuthor";
            this.overrideProjectFileAuthor.Size = new System.Drawing.Size(280, 22);
            this.overrideProjectFileAuthor.Text = "Override project file author";
            this.overrideProjectFileAuthor.ToolTipText = "Will replace whatever author name is in the project file with your Default Author" +
    " name";
            this.overrideProjectFileAuthor.Click += new System.EventHandler(this.overrideProjectFileAuthor_Click);
            // 
            // deleteRBAFiles
            // 
            this.deleteRBAFiles.BackColor = System.Drawing.Color.Black;
            this.deleteRBAFiles.CheckOnClick = true;
            this.deleteRBAFiles.ForeColor = System.Drawing.Color.LightGray;
            this.deleteRBAFiles.Name = "deleteRBAFiles";
            this.deleteRBAFiles.Size = new System.Drawing.Size(280, 22);
            this.deleteRBAFiles.Text = "Delete .rba file(s) after converting";
            this.deleteRBAFiles.ToolTipText = "Select this if you want to force Magma to create a new RBA (increases compilation" +
    " time)";
            this.deleteRBAFiles.Click += new System.EventHandler(this.deleteOldRBAFileFirstToolStripMenuItem_Click);
            // 
            // signSongAsLIVE
            // 
            this.signSongAsLIVE.BackColor = System.Drawing.Color.Black;
            this.signSongAsLIVE.CheckOnClick = true;
            this.signSongAsLIVE.ForeColor = System.Drawing.Color.LightGray;
            this.signSongAsLIVE.Name = "signSongAsLIVE";
            this.signSongAsLIVE.Size = new System.Drawing.Size(280, 22);
            this.signSongAsLIVE.Text = "Sign song as LIVE rather than CON";
            this.signSongAsLIVE.Click += new System.EventHandler(this.signSongAsLIVE_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(277, 6);
            // 
            // useUniqueNumericSongID
            // 
            this.useUniqueNumericSongID.BackColor = System.Drawing.Color.Black;
            this.useUniqueNumericSongID.Checked = true;
            this.useUniqueNumericSongID.CheckOnClick = true;
            this.useUniqueNumericSongID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useUniqueNumericSongID.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batchReplaceSongIDs,
            this.batchRestoreSongIDs});
            this.useUniqueNumericSongID.ForeColor = System.Drawing.Color.LightGray;
            this.useUniqueNumericSongID.Name = "useUniqueNumericSongID";
            this.useUniqueNumericSongID.Size = new System.Drawing.Size(280, 22);
            this.useUniqueNumericSongID.Text = "Use unique numeric song ID";
            this.useUniqueNumericSongID.CheckedChanged += new System.EventHandler(this.useUniqueNumericSongID_CheckedChanged);
            this.useUniqueNumericSongID.Click += new System.EventHandler(this.useUniqueNumericSongID_Click);
            // 
            // batchReplaceSongIDs
            // 
            this.batchReplaceSongIDs.BackColor = System.Drawing.Color.Black;
            this.batchReplaceSongIDs.ForeColor = System.Drawing.Color.LightGray;
            this.batchReplaceSongIDs.Name = "batchReplaceSongIDs";
            this.batchReplaceSongIDs.Size = new System.Drawing.Size(203, 22);
            this.batchReplaceSongIDs.Text = "Batch replace song IDs";
            this.batchReplaceSongIDs.Click += new System.EventHandler(this.batchReplaceSongIDs_Click);
            // 
            // batchRestoreSongIDs
            // 
            this.batchRestoreSongIDs.BackColor = System.Drawing.Color.Black;
            this.batchRestoreSongIDs.ForeColor = System.Drawing.Color.LightGray;
            this.batchRestoreSongIDs.Name = "batchRestoreSongIDs";
            this.batchRestoreSongIDs.Size = new System.Drawing.Size(203, 22);
            this.batchRestoreSongIDs.Text = "Batch restore song IDs";
            this.batchRestoreSongIDs.Visible = false;
            this.batchRestoreSongIDs.Click += new System.EventHandler(this.batchRestoreSongIDs_Click);
            // 
            // increaseSongVersionAutomatically
            // 
            this.increaseSongVersionAutomatically.BackColor = System.Drawing.Color.Black;
            this.increaseSongVersionAutomatically.Checked = true;
            this.increaseSongVersionAutomatically.CheckOnClick = true;
            this.increaseSongVersionAutomatically.CheckState = System.Windows.Forms.CheckState.Checked;
            this.increaseSongVersionAutomatically.ForeColor = System.Drawing.Color.LightGray;
            this.increaseSongVersionAutomatically.Name = "increaseSongVersionAutomatically";
            this.increaseSongVersionAutomatically.Size = new System.Drawing.Size(280, 22);
            this.increaseSongVersionAutomatically.Text = "Increase song version automatically";
            this.increaseSongVersionAutomatically.Click += new System.EventHandler(this.increaseSongVersionAutomatically_Click);
            // 
            // appendSongVersionToSongID
            // 
            this.appendSongVersionToSongID.BackColor = System.Drawing.Color.Black;
            this.appendSongVersionToSongID.CheckOnClick = true;
            this.appendSongVersionToSongID.Enabled = false;
            this.appendSongVersionToSongID.ForeColor = System.Drawing.Color.LightGray;
            this.appendSongVersionToSongID.Name = "appendSongVersionToSongID";
            this.appendSongVersionToSongID.Size = new System.Drawing.Size(280, 22);
            this.appendSongVersionToSongID.Text = "Append song version to song ID";
            this.appendSongVersionToSongID.ToolTipText = "You should leave this enabled so the user doesn\'t experience ID conflicts with up" +
    "dated versions of the song";
            this.appendSongVersionToSongID.Click += new System.EventHandler(this.appendSongVersionToSongIDToolStripMenuItem_Click);
            // 
            // appendSongVersionToFileName
            // 
            this.appendSongVersionToFileName.BackColor = System.Drawing.Color.Black;
            this.appendSongVersionToFileName.CheckOnClick = true;
            this.appendSongVersionToFileName.ForeColor = System.Drawing.Color.LightGray;
            this.appendSongVersionToFileName.Name = "appendSongVersionToFileName";
            this.appendSongVersionToFileName.Size = new System.Drawing.Size(280, 22);
            this.appendSongVersionToFileName.Text = "Append song version to file name";
            this.appendSongVersionToFileName.Click += new System.EventHandler(this.appendSongVersionToFileNameToolStripMenuItem_Click);
            // 
            // appendrb3conToFile
            // 
            this.appendrb3conToFile.BackColor = System.Drawing.Color.Black;
            this.appendrb3conToFile.Checked = true;
            this.appendrb3conToFile.CheckOnClick = true;
            this.appendrb3conToFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.appendrb3conToFile.ForeColor = System.Drawing.Color.LightGray;
            this.appendrb3conToFile.Name = "appendrb3conToFile";
            this.appendrb3conToFile.Size = new System.Drawing.Size(280, 22);
            this.appendrb3conToFile.Text = "Append \'_rb3con\' to file name";
            this.appendrb3conToFile.Click += new System.EventHandler(this.appendrb3conToFileToolStripMenuItem_Click);
            // 
            // removeSubgenre
            // 
            this.removeSubgenre.BackColor = System.Drawing.Color.Black;
            this.removeSubgenre.CheckOnClick = true;
            this.removeSubgenre.ForeColor = System.Drawing.Color.LightGray;
            this.removeSubgenre.Name = "removeSubgenre";
            this.removeSubgenre.Size = new System.Drawing.Size(280, 22);
            this.removeSubgenre.Text = "Remove subgenre from DTA file";
            this.removeSubgenre.Click += new System.EventHandler(this.removeSubgenre_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(277, 6);
            // 
            // keepSongsdtaFile
            // 
            this.keepSongsdtaFile.BackColor = System.Drawing.Color.Black;
            this.keepSongsdtaFile.CheckOnClick = true;
            this.keepSongsdtaFile.ForeColor = System.Drawing.Color.LightGray;
            this.keepSongsdtaFile.Name = "keepSongsdtaFile";
            this.keepSongsdtaFile.Size = new System.Drawing.Size(280, 22);
            this.keepSongsdtaFile.Text = "Keep songs.dta file";
            this.keepSongsdtaFile.ToolTipText = "Select this if you want to keep the songs.dta file that goes in the CON in case y" +
    "ou want to make manual edits";
            this.keepSongsdtaFile.Click += new System.EventHandler(this.keepSongsdtaFileToolStripMenuItem_Click);
            // 
            // doNotDeleteExtractedFiles
            // 
            this.doNotDeleteExtractedFiles.BackColor = System.Drawing.Color.Black;
            this.doNotDeleteExtractedFiles.CheckOnClick = true;
            this.doNotDeleteExtractedFiles.ForeColor = System.Drawing.Color.LightGray;
            this.doNotDeleteExtractedFiles.Name = "doNotDeleteExtractedFiles";
            this.doNotDeleteExtractedFiles.Size = new System.Drawing.Size(280, 22);
            this.doNotDeleteExtractedFiles.Text = "Keep extracted files folder";
            this.doNotDeleteExtractedFiles.ToolTipText = "Select this if you want to access the raw files that were in the RBA file";
            this.doNotDeleteExtractedFiles.Click += new System.EventHandler(this.doNotDeleteExtractedFilesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(277, 6);
            // 
            // aNSIMenu
            // 
            this.aNSIMenu.BackColor = System.Drawing.Color.Black;
            this.aNSIMenu.Checked = true;
            this.aNSIMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aNSIMenu.ForeColor = System.Drawing.Color.LightGray;
            this.aNSIMenu.Name = "aNSIMenu";
            this.aNSIMenu.Size = new System.Drawing.Size(280, 22);
            this.aNSIMenu.Text = "Use ANSI encoding (default)";
            this.aNSIMenu.ToolTipText = "Leave this checked unless the name of the song, artist or album has special chara" +
    "cters";
            this.aNSIMenu.Click += new System.EventHandler(this.aNSIToolStripMenuItem_Click);
            // 
            // uTF8Menu
            // 
            this.uTF8Menu.BackColor = System.Drawing.Color.Black;
            this.uTF8Menu.ForeColor = System.Drawing.Color.LightGray;
            this.uTF8Menu.Name = "uTF8Menu";
            this.uTF8Menu.Size = new System.Drawing.Size(280, 22);
            this.uTF8Menu.Text = "Use UTF-8 encoding";
            this.uTF8Menu.ToolTipText = "Use this if the name of the song, artist or album has special characters";
            this.uTF8Menu.Click += new System.EventHandler(this.uTF8ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(277, 6);
            // 
            // openToDoListByDefault
            // 
            this.openToDoListByDefault.BackColor = System.Drawing.Color.Black;
            this.openToDoListByDefault.CheckOnClick = true;
            this.openToDoListByDefault.ForeColor = System.Drawing.Color.LightGray;
            this.openToDoListByDefault.Name = "openToDoListByDefault";
            this.openToDoListByDefault.Size = new System.Drawing.Size(280, 22);
            this.openToDoListByDefault.Text = "Open To-Do list by default";
            this.openToDoListByDefault.Click += new System.EventHandler(this.openToDoListByDefaultToolStripMenuItem_Click);
            // 
            // showToast
            // 
            this.showToast.BackColor = System.Drawing.Color.Black;
            this.showToast.Checked = true;
            this.showToast.CheckOnClick = true;
            this.showToast.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showToast.ForeColor = System.Drawing.Color.LightGray;
            this.showToast.Name = "showToast";
            this.showToast.Size = new System.Drawing.Size(280, 22);
            this.showToast.Text = "Show toast notifications";
            this.showToast.ToolTipText = "Disable if you don\'t want to get the small pop-ups telling you what the program i" +
    "s doing";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(277, 6);
            // 
            // skinsToolStripMenuItem
            // 
            this.skinsToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.skinsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.burnBabyBurn,
            this.cIsForColorfulTool,
            this.oldDarkTool,
            this.customSkinTool});
            this.skinsToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.skinsToolStripMenuItem.Name = "skinsToolStripMenuItem";
            this.skinsToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.skinsToolStripMenuItem.Text = "Skins";
            // 
            // burnBabyBurn
            // 
            this.burnBabyBurn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.burnBabyBurn.Checked = true;
            this.burnBabyBurn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.burnBabyBurn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.burnBabyBurn.Name = "burnBabyBurn";
            this.burnBabyBurn.Size = new System.Drawing.Size(148, 22);
            this.burnBabyBurn.Text = "Lava";
            this.burnBabyBurn.Click += new System.EventHandler(this.burnBabyBurn_Click);
            // 
            // cIsForColorfulTool
            // 
            this.cIsForColorfulTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(85)))), ((int)(((byte)(196)))));
            this.cIsForColorfulTool.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cIsForColorfulTool.ForeColor = System.Drawing.Color.White;
            this.cIsForColorfulTool.Name = "cIsForColorfulTool";
            this.cIsForColorfulTool.Size = new System.Drawing.Size(148, 22);
            this.cIsForColorfulTool.Text = "C is for Colorful";
            this.cIsForColorfulTool.Click += new System.EventHandler(this.cIsForColorfulToolStripMenuItem_Click);
            // 
            // oldDarkTool
            // 
            this.oldDarkTool.BackColor = System.Drawing.Color.Black;
            this.oldDarkTool.ForeColor = System.Drawing.Color.LightGray;
            this.oldDarkTool.Name = "oldDarkTool";
            this.oldDarkTool.Size = new System.Drawing.Size(148, 22);
            this.oldDarkTool.Text = "Old && Dark";
            this.oldDarkTool.Click += new System.EventHandler(this.oldDarkToolStripMenuItem_Click);
            // 
            // customSkinTool
            // 
            this.customSkinTool.Name = "customSkinTool";
            this.customSkinTool.Size = new System.Drawing.Size(148, 22);
            this.customSkinTool.Text = "Custom Skin";
            this.customSkinTool.Click += new System.EventHandler(this.customSkinTool_Click);
            // 
            // aDVANCEDUSEONLYToolStripMenuItem
            // 
            this.aDVANCEDUSEONLYToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.aDVANCEDUSEONLYToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overrideAlbumArt,
            this.overrideMIDIFile,
            this.overrideAudioFile,
            this.overrideMiloFile,
            this.toolStripMenuItem12,
            this.albumArtDimensions,
            this.neverCheckForTempoMap,
            this.bypassNemosMIDIValidator,
            this.toolStripMenuItem6,
            this.selectNautilusPath,
            this.selectAudacityPath,
            this.changeCompilerExecutable});
            this.aDVANCEDUSEONLYToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.aDVANCEDUSEONLYToolStripMenuItem.Name = "aDVANCEDUSEONLYToolStripMenuItem";
            this.aDVANCEDUSEONLYToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.aDVANCEDUSEONLYToolStripMenuItem.Text = "ADVANCED SETTINGS";
            // 
            // overrideAlbumArt
            // 
            this.overrideAlbumArt.BackColor = System.Drawing.Color.Black;
            this.overrideAlbumArt.Checked = true;
            this.overrideAlbumArt.CheckOnClick = true;
            this.overrideAlbumArt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overrideAlbumArt.ForeColor = System.Drawing.Color.LightGray;
            this.overrideAlbumArt.Name = "overrideAlbumArt";
            this.overrideAlbumArt.Size = new System.Drawing.Size(291, 22);
            this.overrideAlbumArt.Text = "Override album art (*.png_xbox)";
            this.overrideAlbumArt.ToolTipText = "Replaces the album art from the RBA with any *.png_xbox file you put in the proje" +
    "ct folder";
            this.overrideAlbumArt.Click += new System.EventHandler(this.overrideAlbumArt_Click);
            // 
            // overrideMIDIFile
            // 
            this.overrideMIDIFile.BackColor = System.Drawing.Color.Black;
            this.overrideMIDIFile.CheckOnClick = true;
            this.overrideMIDIFile.ForeColor = System.Drawing.Color.LightGray;
            this.overrideMIDIFile.Name = "overrideMIDIFile";
            this.overrideMIDIFile.Size = new System.Drawing.Size(291, 22);
            this.overrideMIDIFile.Text = "Override MIDI file (override.mid)";
            this.overrideMIDIFile.ToolTipText = "Replaces the MIDI from the RBA with override.mid file placed in the project folde" +
    "r";
            this.overrideMIDIFile.Click += new System.EventHandler(this.overrideMIDIFile_Click);
            // 
            // overrideAudioFile
            // 
            this.overrideAudioFile.BackColor = System.Drawing.Color.Black;
            this.overrideAudioFile.CheckOnClick = true;
            this.overrideAudioFile.ForeColor = System.Drawing.Color.LightGray;
            this.overrideAudioFile.Name = "overrideAudioFile";
            this.overrideAudioFile.Size = new System.Drawing.Size(291, 22);
            this.overrideAudioFile.Text = "Override audio file (*.mogg)";
            this.overrideAudioFile.ToolTipText = "Replaces the audio file from the RBA with any *.mogg file you put in the project " +
    "folder";
            this.overrideAudioFile.Click += new System.EventHandler(this.overrideAudioFile_Click);
            // 
            // overrideMiloFile
            // 
            this.overrideMiloFile.BackColor = System.Drawing.Color.Black;
            this.overrideMiloFile.CheckOnClick = true;
            this.overrideMiloFile.ForeColor = System.Drawing.Color.LightGray;
            this.overrideMiloFile.Name = "overrideMiloFile";
            this.overrideMiloFile.Size = new System.Drawing.Size(291, 22);
            this.overrideMiloFile.Text = "Override animations file (*.milo_xbox)";
            this.overrideMiloFile.ToolTipText = "Replaces the animations file from the RBA with any *.milo_xbox file you put in th" +
    "e project folder";
            this.overrideMiloFile.Click += new System.EventHandler(this.overrideMiloFile_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(288, 6);
            // 
            // albumArtDimensions
            // 
            this.albumArtDimensions.BackColor = System.Drawing.Color.Black;
            this.albumArtDimensions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x256,
            this.x512,
            this.x1024,
            this.x2048});
            this.albumArtDimensions.ForeColor = System.Drawing.Color.LightGray;
            this.albumArtDimensions.Name = "albumArtDimensions";
            this.albumArtDimensions.Size = new System.Drawing.Size(291, 22);
            this.albumArtDimensions.Text = "Album art dimensions";
            // 
            // x256
            // 
            this.x256.BackColor = System.Drawing.Color.Black;
            this.x256.ForeColor = System.Drawing.Color.LightGray;
            this.x256.Name = "x256";
            this.x256.Size = new System.Drawing.Size(176, 22);
            this.x256.Text = "256x256";
            this.x256.Click += new System.EventHandler(this.x256ToolStripMenuItem_Click);
            // 
            // x512
            // 
            this.x512.BackColor = System.Drawing.Color.Black;
            this.x512.Checked = true;
            this.x512.CheckState = System.Windows.Forms.CheckState.Checked;
            this.x512.ForeColor = System.Drawing.Color.LightGray;
            this.x512.Name = "x512";
            this.x512.Size = new System.Drawing.Size(176, 22);
            this.x512.Text = "512x512 (default)";
            this.x512.Click += new System.EventHandler(this.x512ToolStripMenuItem_Click);
            // 
            // x1024
            // 
            this.x1024.BackColor = System.Drawing.Color.Black;
            this.x1024.ForeColor = System.Drawing.Color.LightGray;
            this.x1024.Name = "x1024";
            this.x1024.Size = new System.Drawing.Size(176, 22);
            this.x1024.Text = "1024x1024";
            this.x1024.Click += new System.EventHandler(this.x1024ToolStripMenuItem_Click);
            // 
            // x2048
            // 
            this.x2048.BackColor = System.Drawing.Color.Black;
            this.x2048.ForeColor = System.Drawing.Color.LightGray;
            this.x2048.Name = "x2048";
            this.x2048.Size = new System.Drawing.Size(176, 22);
            this.x2048.Text = "2048x2048";
            this.x2048.Click += new System.EventHandler(this.x2048ToolStripMenuItem_Click);
            // 
            // neverCheckForTempoMap
            // 
            this.neverCheckForTempoMap.BackColor = System.Drawing.Color.Black;
            this.neverCheckForTempoMap.CheckOnClick = true;
            this.neverCheckForTempoMap.ForeColor = System.Drawing.Color.LightGray;
            this.neverCheckForTempoMap.Name = "neverCheckForTempoMap";
            this.neverCheckForTempoMap.Size = new System.Drawing.Size(291, 22);
            this.neverCheckForTempoMap.Text = "Never check for tempo map";
            this.neverCheckForTempoMap.ToolTipText = "DO NOT ENABLE THIS unless you are absolutely sure you know what you are doing";
            this.neverCheckForTempoMap.Click += new System.EventHandler(this.neverCheckForTempoMap_Click);
            // 
            // bypassNemosMIDIValidator
            // 
            this.bypassNemosMIDIValidator.BackColor = System.Drawing.Color.Black;
            this.bypassNemosMIDIValidator.CheckOnClick = true;
            this.bypassNemosMIDIValidator.ForeColor = System.Drawing.Color.LightGray;
            this.bypassNemosMIDIValidator.Name = "bypassNemosMIDIValidator";
            this.bypassNemosMIDIValidator.Size = new System.Drawing.Size(291, 22);
            this.bypassNemosMIDIValidator.Text = "Bypass Nemo\'s MIDI Validator";
            this.bypassNemosMIDIValidator.Click += new System.EventHandler(this.bypassNemosMIDIValidatorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(288, 6);
            // 
            // selectNautilusPath
            // 
            this.selectNautilusPath.BackColor = System.Drawing.Color.Black;
            this.selectNautilusPath.ForeColor = System.Drawing.Color.LightGray;
            this.selectNautilusPath.Name = "selectNautilusPath";
            this.selectNautilusPath.Size = new System.Drawing.Size(291, 22);
            this.selectNautilusPath.Text = "Select Nautilus path";
            this.selectNautilusPath.ToolTipText = "You need this to enable \'Visualize\' and \'Nautilus\' after building your song";
            this.selectNautilusPath.Click += new System.EventHandler(this.selectToolsPath_Click);
            // 
            // selectAudacityPath
            // 
            this.selectAudacityPath.BackColor = System.Drawing.Color.Black;
            this.selectAudacityPath.ForeColor = System.Drawing.Color.LightGray;
            this.selectAudacityPath.Name = "selectAudacityPath";
            this.selectAudacityPath.Size = new System.Drawing.Size(291, 22);
            this.selectAudacityPath.Text = "Select Audacity path";
            this.selectAudacityPath.ToolTipText = "You only need this if you\'re going to import an existing song that is in CON/LIVE" +
    " format";
            this.selectAudacityPath.Click += new System.EventHandler(this.selectAudacityPathToolStripMenuItem_Click);
            // 
            // changeCompilerExecutable
            // 
            this.changeCompilerExecutable.BackColor = System.Drawing.Color.Black;
            this.changeCompilerExecutable.ForeColor = System.Drawing.Color.LightGray;
            this.changeCompilerExecutable.Name = "changeCompilerExecutable";
            this.changeCompilerExecutable.Size = new System.Drawing.Size(291, 22);
            this.changeCompilerExecutable.Text = "Change compiler executable";
            this.changeCompilerExecutable.ToolTipText = "DO NOT CHANGE THIS unless you know what you are doing";
            this.changeCompilerExecutable.Click += new System.EventHandler(this.changeCompilerExecutableToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdates,
            this.viewChangeLog,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // checkForUpdates
            // 
            this.checkForUpdates.BackColor = System.Drawing.Color.Black;
            this.checkForUpdates.ForeColor = System.Drawing.Color.LightGray;
            this.checkForUpdates.Name = "checkForUpdates";
            this.checkForUpdates.Size = new System.Drawing.Size(209, 22);
            this.checkForUpdates.Text = "Check for updates";
            this.checkForUpdates.Click += new System.EventHandler(this.checkForUpdates_Click);
            // 
            // viewChangeLog
            // 
            this.viewChangeLog.BackColor = System.Drawing.Color.Black;
            this.viewChangeLog.ForeColor = System.Drawing.Color.LightGray;
            this.viewChangeLog.Name = "viewChangeLog";
            this.viewChangeLog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F1)));
            this.viewChangeLog.Size = new System.Drawing.Size(209, 22);
            this.viewChangeLog.Text = "View change log";
            this.viewChangeLog.Click += new System.EventHandler(this.viewChangeLog_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // TopLevelTabs
            // 
            this.TopLevelTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TopLevelTabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TopLevelTabs.Controls.Add(this.TabPageInformation);
            this.TopLevelTabs.Controls.Add(this.TabPageAudio);
            this.TopLevelTabs.Controls.Add(this.TabPageGameData);
            this.TopLevelTabs.Location = new System.Drawing.Point(-4, 29);
            this.TopLevelTabs.Multiline = true;
            this.TopLevelTabs.Name = "TopLevelTabs";
            this.TopLevelTabs.SelectedIndex = 0;
            this.TopLevelTabs.Size = new System.Drawing.Size(757, 600);
            this.TopLevelTabs.TabIndex = 99;
            // 
            // TabPageInformation
            // 
            this.TabPageInformation.AllowDrop = true;
            this.TabPageInformation.BackColor = System.Drawing.Color.Black;
            this.TabPageInformation.BackgroundImage = global::MagmaRokOn.Properties.Resources.bg3;
            this.TabPageInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TabPageInformation.Controls.Add(this.chkPartial);
            this.TabPageInformation.Controls.Add(this.picPartial);
            this.TabPageInformation.Controls.Add(this.chkUnpitched);
            this.TabPageInformation.Controls.Add(this.picUnpitched);
            this.TabPageInformation.Controls.Add(this.chkAuthorDTA);
            this.TabPageInformation.Controls.Add(this.chkDIYStems);
            this.TabPageInformation.Controls.Add(this.picDIYStems);
            this.TabPageInformation.Controls.Add(this.chkCAT);
            this.TabPageInformation.Controls.Add(this.picCAT);
            this.TabPageInformation.Controls.Add(this.picAuthor);
            this.TabPageInformation.Controls.Add(this.picThumb);
            this.TabPageInformation.Controls.Add(this.btnDispDLC);
            this.TabPageInformation.Controls.Add(this.btnDescDefault);
            this.TabPageInformation.Controls.Add(this.btnDispDefault);
            this.TabPageInformation.Controls.Add(this.label2);
            this.TabPageInformation.Controls.Add(this.label1);
            this.TabPageInformation.Controls.Add(this.txtDescription);
            this.TabPageInformation.Controls.Add(this.txtTitleDisplay);
            this.TabPageInformation.Controls.Add(this.chkXOnly);
            this.TabPageInformation.Controls.Add(this.picXOnly);
            this.TabPageInformation.Controls.Add(this.panel4);
            this.TabPageInformation.Controls.Add(this.panel2);
            this.TabPageInformation.Controls.Add(this.panel1);
            this.TabPageInformation.Controls.Add(this.panel3);
            this.TabPageInformation.Controls.Add(this.chkMaster);
            this.TabPageInformation.Controls.Add(this.chkConvert);
            this.TabPageInformation.Controls.Add(this.chkMultitrack);
            this.TabPageInformation.Controls.Add(this.chkKaraoke);
            this.TabPageInformation.Controls.Add(this.picConvert);
            this.TabPageInformation.Controls.Add(this.picMultitrack);
            this.TabPageInformation.Controls.Add(this.picKaraoke);
            this.TabPageInformation.Controls.Add(this.chk2xBass);
            this.TabPageInformation.Controls.Add(this.chkRhythmBass);
            this.TabPageInformation.Controls.Add(this.chkRhythmKeys);
            this.TabPageInformation.Controls.Add(this.pic2xBass);
            this.TabPageInformation.Controls.Add(this.picRhythmBass);
            this.TabPageInformation.Controls.Add(this.picRhythmKeys);
            this.TabPageInformation.Controls.Add(this.chkReRecord);
            this.TabPageInformation.Controls.Add(this.LabelReRecording);
            this.TabPageInformation.Controls.Add(this.numericReRecord);
            this.TabPageInformation.Controls.Add(this.CheckBoxLangJapanese);
            this.TabPageInformation.Controls.Add(this.CheckBoxLangGerman);
            this.TabPageInformation.Controls.Add(this.ButtonAlbumArt);
            this.TabPageInformation.Controls.Add(this.LabelAlbumName);
            this.TabPageInformation.Controls.Add(this.CheckBoxFromAlbum);
            this.TabPageInformation.Controls.Add(this.ButtonClearAlbumArt);
            this.TabPageInformation.Controls.Add(this.TextBoxAlbumArt);
            this.TabPageInformation.Controls.Add(this.NumericTrackNumber);
            this.TabPageInformation.Controls.Add(this.LabelTrackNumber);
            this.TabPageInformation.Controls.Add(this.LabelLanguages);
            this.TabPageInformation.Controls.Add(this.CheckBoxLangItalian);
            this.TabPageInformation.Controls.Add(this.CheckBoxLangEnglish);
            this.TabPageInformation.Controls.Add(this.CheckBoxLangFrench);
            this.TabPageInformation.Controls.Add(this.CheckBoxLangSpanish);
            this.TabPageInformation.Controls.Add(this.LabelAuthor);
            this.TabPageInformation.Controls.Add(this.TextBoxAuthor);
            this.TabPageInformation.Controls.Add(this.ComboBoxGenre);
            this.TabPageInformation.Controls.Add(this.LabelGenre);
            this.TabPageInformation.Controls.Add(this.LabelSubgenre);
            this.TabPageInformation.Controls.Add(this.ComboBoxSubGenre);
            this.TabPageInformation.Controls.Add(this.LabelSongName);
            this.TabPageInformation.Controls.Add(this.TextBoxSongName);
            this.TabPageInformation.Controls.Add(this.TextBoxArtistName);
            this.TabPageInformation.Controls.Add(this.LabelArtist);
            this.TabPageInformation.Controls.Add(this.TextBoxAlbumName);
            this.TabPageInformation.Controls.Add(this.LabelYearReleased);
            this.TabPageInformation.Controls.Add(this.NumericUpDownYear);
            this.TabPageInformation.Controls.Add(this.PictureBoxAlbumArt);
            this.TabPageInformation.ForeColor = System.Drawing.Color.DarkGray;
            this.TabPageInformation.Location = new System.Drawing.Point(4, 25);
            this.TabPageInformation.Name = "TabPageInformation";
            this.TabPageInformation.Size = new System.Drawing.Size(749, 571);
            this.TabPageInformation.TabIndex = 6;
            this.TabPageInformation.Text = "Information";
            this.TabPageInformation.DragDrop += new System.Windows.Forms.DragEventHandler(this.HandleDragDrop);
            this.TabPageInformation.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            // 
            // chkPartial
            // 
            this.chkPartial.AutoSize = true;
            this.chkPartial.BackColor = System.Drawing.Color.Transparent;
            this.chkPartial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkPartial.Location = new System.Drawing.Point(170, 431);
            this.chkPartial.Name = "chkPartial";
            this.chkPartial.Size = new System.Drawing.Size(15, 14);
            this.chkPartial.TabIndex = 147;
            this.ToolTip.SetToolTip(this.chkPartial, "Click here if the song has partial multitracks");
            this.chkPartial.UseVisualStyleBackColor = false;
            this.chkPartial.CheckedChanged += new System.EventHandler(this.chkPartial_CheckedChanged);
            // 
            // picPartial
            // 
            this.picPartial.BackColor = System.Drawing.Color.Transparent;
            this.picPartial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPartial.Location = new System.Drawing.Point(143, 376);
            this.picPartial.Name = "picPartial";
            this.picPartial.Size = new System.Drawing.Size(64, 54);
            this.picPartial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPartial.TabIndex = 148;
            this.picPartial.TabStop = false;
            this.ToolTip.SetToolTip(this.picPartial, "Click here if the song has partial multitracks");
            // 
            // chkUnpitched
            // 
            this.chkUnpitched.AutoSize = true;
            this.chkUnpitched.BackColor = System.Drawing.Color.Transparent;
            this.chkUnpitched.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkUnpitched.Location = new System.Drawing.Point(294, 506);
            this.chkUnpitched.Name = "chkUnpitched";
            this.chkUnpitched.Size = new System.Drawing.Size(15, 14);
            this.chkUnpitched.TabIndex = 145;
            this.ToolTip.SetToolTip(this.chkUnpitched, "Click here if the song only has unpitched vocals charted");
            this.chkUnpitched.UseVisualStyleBackColor = false;
            this.chkUnpitched.CheckedChanged += new System.EventHandler(this.chkUnpitched_CheckedChanged);
            // 
            // picUnpitched
            // 
            this.picUnpitched.BackColor = System.Drawing.Color.Transparent;
            this.picUnpitched.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUnpitched.Location = new System.Drawing.Point(269, 451);
            this.picUnpitched.Name = "picUnpitched";
            this.picUnpitched.Size = new System.Drawing.Size(64, 54);
            this.picUnpitched.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picUnpitched.TabIndex = 146;
            this.picUnpitched.TabStop = false;
            this.ToolTip.SetToolTip(this.picUnpitched, "Click here if the song only has unpitched vocals charted");
            this.picUnpitched.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picUnpitched_MouseClick);
            // 
            // chkAuthorDTA
            // 
            this.chkAuthorDTA.AutoSize = true;
            this.chkAuthorDTA.BackColor = System.Drawing.Color.Transparent;
            this.chkAuthorDTA.Checked = true;
            this.chkAuthorDTA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuthorDTA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAuthorDTA.ForeColor = System.Drawing.Color.White;
            this.chkAuthorDTA.Location = new System.Drawing.Point(469, 330);
            this.chkAuthorDTA.Name = "chkAuthorDTA";
            this.chkAuthorDTA.Size = new System.Drawing.Size(147, 17);
            this.chkAuthorDTA.TabIndex = 144;
            this.chkAuthorDTA.Text = "Save author to DTA array";
            this.ToolTip.SetToolTip(this.chkAuthorDTA, "Click here to enable saving the author name to the DTA array");
            this.chkAuthorDTA.UseVisualStyleBackColor = false;
            this.chkAuthorDTA.CheckedChanged += new System.EventHandler(this.chkAuthorDTA_CheckedChanged);
            // 
            // chkDIYStems
            // 
            this.chkDIYStems.AutoSize = true;
            this.chkDIYStems.BackColor = System.Drawing.Color.Transparent;
            this.chkDIYStems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDIYStems.Location = new System.Drawing.Point(233, 431);
            this.chkDIYStems.Name = "chkDIYStems";
            this.chkDIYStems.Size = new System.Drawing.Size(15, 14);
            this.chkDIYStems.TabIndex = 142;
            this.ToolTip.SetToolTip(this.chkDIYStems, "Click here if the song has audio stems created manually or by an AI program such " +
        "as Demucs, etc\r\n");
            this.chkDIYStems.UseVisualStyleBackColor = false;
            this.chkDIYStems.CheckedChanged += new System.EventHandler(this.chkDIYStems_CheckedChanged);
            // 
            // picDIYStems
            // 
            this.picDIYStems.BackColor = System.Drawing.Color.Transparent;
            this.picDIYStems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDIYStems.Location = new System.Drawing.Point(206, 376);
            this.picDIYStems.Name = "picDIYStems";
            this.picDIYStems.Size = new System.Drawing.Size(64, 54);
            this.picDIYStems.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDIYStems.TabIndex = 143;
            this.picDIYStems.TabStop = false;
            this.ToolTip.SetToolTip(this.picDIYStems, "Click here if the song has audio stems created manually or by an AI program such " +
        "as Demucs, etc");
            this.picDIYStems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDIYStems_MouseClick);
            // 
            // chkCAT
            // 
            this.chkCAT.AutoSize = true;
            this.chkCAT.BackColor = System.Drawing.Color.Transparent;
            this.chkCAT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkCAT.Location = new System.Drawing.Point(168, 506);
            this.chkCAT.Name = "chkCAT";
            this.chkCAT.Size = new System.Drawing.Size(15, 14);
            this.chkCAT.TabIndex = 140;
            this.ToolTip.SetToolTip(this.chkCAT, "Click here if the song has EMH autogenerated by CAT");
            this.chkCAT.UseVisualStyleBackColor = false;
            this.chkCAT.CheckedChanged += new System.EventHandler(this.chkCAT_CheckedChanged);
            // 
            // picCAT
            // 
            this.picCAT.BackColor = System.Drawing.Color.Transparent;
            this.picCAT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCAT.Location = new System.Drawing.Point(143, 451);
            this.picCAT.Name = "picCAT";
            this.picCAT.Size = new System.Drawing.Size(64, 54);
            this.picCAT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCAT.TabIndex = 141;
            this.picCAT.TabStop = false;
            this.ToolTip.SetToolTip(this.picCAT, "Click here if the song has EMH autogenerated by CAT");
            this.picCAT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCAT_MouseClick);
            // 
            // picAuthor
            // 
            this.picAuthor.BackColor = System.Drawing.Color.Transparent;
            this.picAuthor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAuthor.Location = new System.Drawing.Point(410, 326);
            this.picAuthor.Name = "picAuthor";
            this.picAuthor.Size = new System.Drawing.Size(24, 24);
            this.picAuthor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAuthor.TabIndex = 138;
            this.picAuthor.TabStop = false;
            this.ToolTip.SetToolTip(this.picAuthor, "Click to save the current author name as default");
            this.picAuthor.Visible = false;
            this.picAuthor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picAuthor_MouseClick);
            this.picAuthor.MouseLeave += new System.EventHandler(this.picAuthor_MouseLeave);
            this.picAuthor.MouseHover += new System.EventHandler(this.picAuthor_MouseHover);
            // 
            // picThumb
            // 
            this.picThumb.BackColor = System.Drawing.Color.DarkGray;
            this.picThumb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picThumb.ContextMenuStrip = this.contextMenuStrip1;
            this.picThumb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picThumb.Location = new System.Drawing.Point(661, 212);
            this.picThumb.Name = "picThumb";
            this.picThumb.Padding = new System.Windows.Forms.Padding(2);
            this.picThumb.Size = new System.Drawing.Size(64, 64);
            this.picThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picThumb.TabIndex = 137;
            this.picThumb.TabStop = false;
            this.ToolTip.SetToolTip(this.picThumb, "This is the image you see on your Xbox dashboard. Click here to change it or drag" +
        " and drop an image here");
            this.picThumb.DragDrop += new System.Windows.Forms.DragEventHandler(this.picThumb_DragDrop);
            this.picThumb.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.picThumb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picThumb_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectThumbnail,
            this.clearThumbnailTool,
            this.useDefaultRB3ImageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(202, 70);
            // 
            // selectThumbnail
            // 
            this.selectThumbnail.BackColor = System.Drawing.Color.Black;
            this.selectThumbnail.ForeColor = System.Drawing.Color.LightGray;
            this.selectThumbnail.Name = "selectThumbnail";
            this.selectThumbnail.Size = new System.Drawing.Size(201, 22);
            this.selectThumbnail.Text = "Select thumbnail";
            this.selectThumbnail.Click += new System.EventHandler(this.selectThumbnail_Click);
            // 
            // clearThumbnailTool
            // 
            this.clearThumbnailTool.BackColor = System.Drawing.Color.Black;
            this.clearThumbnailTool.ForeColor = System.Drawing.Color.LightGray;
            this.clearThumbnailTool.Name = "clearThumbnailTool";
            this.clearThumbnailTool.Size = new System.Drawing.Size(201, 22);
            this.clearThumbnailTool.Text = "Use album art";
            this.clearThumbnailTool.Click += new System.EventHandler(this.clearToolStripMenuItem1_Click);
            // 
            // useDefaultRB3ImageToolStripMenuItem
            // 
            this.useDefaultRB3ImageToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.useDefaultRB3ImageToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.useDefaultRB3ImageToolStripMenuItem.Name = "useDefaultRB3ImageToolStripMenuItem";
            this.useDefaultRB3ImageToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.useDefaultRB3ImageToolStripMenuItem.Text = "Use default RB3 image";
            this.useDefaultRB3ImageToolStripMenuItem.Click += new System.EventHandler(this.useDefaultRB3ImageToolStripMenuItem_Click);
            // 
            // btnDispDLC
            // 
            this.btnDispDLC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDispDLC.BackgroundImage = global::MagmaRokOn.Properties.Resources.button_bg_large;
            this.btnDispDLC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDispDLC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDispDLC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispDLC.ForeColor = System.Drawing.Color.White;
            this.btnDispDLC.Location = new System.Drawing.Point(669, 419);
            this.btnDispDLC.Name = "btnDispDLC";
            this.btnDispDLC.Size = new System.Drawing.Size(55, 23);
            this.btnDispDLC.TabIndex = 135;
            this.btnDispDLC.Text = "DLC";
            this.btnDispDLC.UseVisualStyleBackColor = false;
            this.btnDispDLC.Click += new System.EventHandler(this.btnDispDLC_Click);
            // 
            // btnDescDefault
            // 
            this.btnDescDefault.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescDefault.BackgroundImage = global::MagmaRokOn.Properties.Resources.button_bg_large;
            this.btnDescDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDescDefault.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescDefault.ForeColor = System.Drawing.Color.White;
            this.btnDescDefault.Location = new System.Drawing.Point(669, 468);
            this.btnDescDefault.Name = "btnDescDefault";
            this.btnDescDefault.Size = new System.Drawing.Size(55, 23);
            this.btnDescDefault.TabIndex = 134;
            this.btnDescDefault.Text = "Default";
            this.btnDescDefault.UseVisualStyleBackColor = false;
            this.btnDescDefault.Click += new System.EventHandler(this.btnDescDefault_Click);
            // 
            // btnDispDefault
            // 
            this.btnDispDefault.BackColor = System.Drawing.Color.Black;
            this.btnDispDefault.BackgroundImage = global::MagmaRokOn.Properties.Resources.button_bg_large;
            this.btnDispDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDispDefault.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDispDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispDefault.ForeColor = System.Drawing.Color.White;
            this.btnDispDefault.Location = new System.Drawing.Point(669, 387);
            this.btnDispDefault.Name = "btnDispDefault";
            this.btnDispDefault.Size = new System.Drawing.Size(55, 23);
            this.btnDispDefault.TabIndex = 133;
            this.btnDispDefault.Text = "Default";
            this.btnDispDefault.UseVisualStyleBackColor = false;
            this.btnDispDefault.Click += new System.EventHandler(this.btnDispDefault_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(413, 452);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 132;
            this.label2.Text = "PACKAGE DESCRIPTION";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(413, 371);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "PACKAGE TITLE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.Location = new System.Drawing.Point(416, 468);
            this.txtDescription.MaxLength = 80;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(247, 54);
            this.txtDescription.TabIndex = 130;
            this.txtDescription.Text = "Created with Magma: Rok On Edition.";
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // txtTitleDisplay
            // 
            this.txtTitleDisplay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTitleDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitleDisplay.ForeColor = System.Drawing.Color.Black;
            this.txtTitleDisplay.Location = new System.Drawing.Point(416, 387);
            this.txtTitleDisplay.MaxLength = 80;
            this.txtTitleDisplay.Multiline = true;
            this.txtTitleDisplay.Name = "txtTitleDisplay";
            this.txtTitleDisplay.Size = new System.Drawing.Size(247, 54);
            this.txtTitleDisplay.TabIndex = 129;
            this.txtTitleDisplay.TextChanged += new System.EventHandler(this.txtTitleDisplay_TextChanged);
            // 
            // chkXOnly
            // 
            this.chkXOnly.AutoSize = true;
            this.chkXOnly.BackColor = System.Drawing.Color.Transparent;
            this.chkXOnly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkXOnly.Location = new System.Drawing.Point(231, 506);
            this.chkXOnly.Name = "chkXOnly";
            this.chkXOnly.Size = new System.Drawing.Size(15, 14);
            this.chkXOnly.TabIndex = 127;
            this.ToolTip.SetToolTip(this.chkXOnly, "Click here if the song only has Expert difficulty charted");
            this.chkXOnly.UseVisualStyleBackColor = false;
            this.chkXOnly.CheckedChanged += new System.EventHandler(this.chkXOnly_CheckedChanged);
            // 
            // picXOnly
            // 
            this.picXOnly.BackColor = System.Drawing.Color.Transparent;
            this.picXOnly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picXOnly.Location = new System.Drawing.Point(206, 451);
            this.picXOnly.Name = "picXOnly";
            this.picXOnly.Size = new System.Drawing.Size(64, 54);
            this.picXOnly.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picXOnly.TabIndex = 128;
            this.picXOnly.TabStop = false;
            this.ToolTip.SetToolTip(this.picXOnly, "Click here if the song only has Expert difficulty charted");
            this.picXOnly.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picXOnly_MouseClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.ForeColor = System.Drawing.Color.DimGray;
            this.panel4.Location = new System.Drawing.Point(16, 316);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(414, 1);
            this.panel4.TabIndex = 125;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.ForeColor = System.Drawing.Color.DimGray;
            this.panel2.Location = new System.Drawing.Point(18, 261);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 1);
            this.panel2.TabIndex = 124;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.ForeColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(18, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 1);
            this.panel1.TabIndex = 123;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.ForeColor = System.Drawing.Color.DimGray;
            this.panel3.Location = new System.Drawing.Point(18, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(414, 1);
            this.panel3.TabIndex = 122;
            // 
            // chkMaster
            // 
            this.chkMaster.AutoSize = true;
            this.chkMaster.BackColor = System.Drawing.Color.Transparent;
            this.chkMaster.Checked = true;
            this.chkMaster.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMaster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.chkMaster.ForeColor = System.Drawing.Color.LightGray;
            this.chkMaster.Location = new System.Drawing.Point(29, 53);
            this.chkMaster.Name = "chkMaster";
            this.chkMaster.Size = new System.Drawing.Size(81, 17);
            this.chkMaster.TabIndex = 121;
            this.chkMaster.Text = "MASTER?";
            this.ToolTip.SetToolTip(this.chkMaster, "Uncheck if the song is a cover, otherwise leave it checked (original song)");
            this.chkMaster.UseVisualStyleBackColor = false;
            this.chkMaster.CheckedChanged += new System.EventHandler(this.chkMaster_CheckedChanged);
            // 
            // chkConvert
            // 
            this.chkConvert.AutoSize = true;
            this.chkConvert.BackColor = System.Drawing.Color.Transparent;
            this.chkConvert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkConvert.Location = new System.Drawing.Point(357, 431);
            this.chkConvert.Name = "chkConvert";
            this.chkConvert.Size = new System.Drawing.Size(15, 14);
            this.chkConvert.TabIndex = 26;
            this.ToolTip.SetToolTip(this.chkConvert, "Click here if this song is a conversion from another game");
            this.chkConvert.UseVisualStyleBackColor = false;
            this.chkConvert.CheckedChanged += new System.EventHandler(this.chkConvert_CheckedChanged);
            // 
            // chkMultitrack
            // 
            this.chkMultitrack.AutoSize = true;
            this.chkMultitrack.BackColor = System.Drawing.Color.Transparent;
            this.chkMultitrack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMultitrack.Location = new System.Drawing.Point(106, 431);
            this.chkMultitrack.Name = "chkMultitrack";
            this.chkMultitrack.Size = new System.Drawing.Size(15, 14);
            this.chkMultitrack.TabIndex = 25;
            this.ToolTip.SetToolTip(this.chkMultitrack, "Click here if the song has separate audio stems");
            this.chkMultitrack.UseVisualStyleBackColor = false;
            this.chkMultitrack.CheckedChanged += new System.EventHandler(this.chkMultitrack_CheckedChanged);
            // 
            // chkKaraoke
            // 
            this.chkKaraoke.AutoSize = true;
            this.chkKaraoke.BackColor = System.Drawing.Color.Transparent;
            this.chkKaraoke.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkKaraoke.Location = new System.Drawing.Point(39, 431);
            this.chkKaraoke.Name = "chkKaraoke";
            this.chkKaraoke.Size = new System.Drawing.Size(15, 14);
            this.chkKaraoke.TabIndex = 24;
            this.ToolTip.SetToolTip(this.chkKaraoke, "Click here if the song has separate vocals and backing stems");
            this.chkKaraoke.UseVisualStyleBackColor = false;
            this.chkKaraoke.CheckedChanged += new System.EventHandler(this.chkKaraoke_CheckedChanged);
            // 
            // picConvert
            // 
            this.picConvert.BackColor = System.Drawing.Color.Transparent;
            this.picConvert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picConvert.Location = new System.Drawing.Point(332, 376);
            this.picConvert.Name = "picConvert";
            this.picConvert.Size = new System.Drawing.Size(64, 54);
            this.picConvert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picConvert.TabIndex = 116;
            this.picConvert.TabStop = false;
            this.ToolTip.SetToolTip(this.picConvert, "Click here if this song is a conversion from another game");
            this.picConvert.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picConvert_MouseClick);
            // 
            // picMultitrack
            // 
            this.picMultitrack.BackColor = System.Drawing.Color.Transparent;
            this.picMultitrack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMultitrack.Location = new System.Drawing.Point(79, 376);
            this.picMultitrack.Name = "picMultitrack";
            this.picMultitrack.Size = new System.Drawing.Size(64, 54);
            this.picMultitrack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMultitrack.TabIndex = 115;
            this.picMultitrack.TabStop = false;
            this.ToolTip.SetToolTip(this.picMultitrack, "Click here if the song has separate audio stems");
            this.picMultitrack.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picMultitrack_MouseClick);
            // 
            // picKaraoke
            // 
            this.picKaraoke.BackColor = System.Drawing.Color.Transparent;
            this.picKaraoke.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picKaraoke.Location = new System.Drawing.Point(15, 376);
            this.picKaraoke.Name = "picKaraoke";
            this.picKaraoke.Size = new System.Drawing.Size(64, 54);
            this.picKaraoke.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picKaraoke.TabIndex = 114;
            this.picKaraoke.TabStop = false;
            this.ToolTip.SetToolTip(this.picKaraoke, "Click here if the song has separate vocals and backing stems");
            this.picKaraoke.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picKaraoke_MouseClick);
            // 
            // chk2xBass
            // 
            this.chk2xBass.AutoSize = true;
            this.chk2xBass.BackColor = System.Drawing.Color.Transparent;
            this.chk2xBass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk2xBass.Location = new System.Drawing.Point(294, 431);
            this.chk2xBass.Name = "chk2xBass";
            this.chk2xBass.Size = new System.Drawing.Size(15, 14);
            this.chk2xBass.TabIndex = 23;
            this.ToolTip.SetToolTip(this.chk2xBass, "Click here if your song is a 2x Bass Pedal song");
            this.chk2xBass.UseVisualStyleBackColor = false;
            this.chk2xBass.CheckedChanged += new System.EventHandler(this.chk2xBass_CheckedChanged);
            // 
            // chkRhythmBass
            // 
            this.chkRhythmBass.AutoSize = true;
            this.chkRhythmBass.BackColor = System.Drawing.Color.Transparent;
            this.chkRhythmBass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRhythmBass.Location = new System.Drawing.Point(106, 506);
            this.chkRhythmBass.Name = "chkRhythmBass";
            this.chkRhythmBass.Size = new System.Drawing.Size(15, 14);
            this.chkRhythmBass.TabIndex = 22;
            this.ToolTip.SetToolTip(this.chkRhythmBass, "Click here if the song has rhythm guitar charted on the Bass track");
            this.chkRhythmBass.UseVisualStyleBackColor = false;
            this.chkRhythmBass.CheckedChanged += new System.EventHandler(this.chkRhythmBass_CheckedChanged);
            // 
            // chkRhythmKeys
            // 
            this.chkRhythmKeys.AutoSize = true;
            this.chkRhythmKeys.BackColor = System.Drawing.Color.Transparent;
            this.chkRhythmKeys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRhythmKeys.Location = new System.Drawing.Point(39, 506);
            this.chkRhythmKeys.Name = "chkRhythmKeys";
            this.chkRhythmKeys.Size = new System.Drawing.Size(15, 14);
            this.chkRhythmKeys.TabIndex = 21;
            this.ToolTip.SetToolTip(this.chkRhythmKeys, "Click here if the song has rhythm guitar charted on the Keys track");
            this.chkRhythmKeys.UseVisualStyleBackColor = false;
            this.chkRhythmKeys.CheckedChanged += new System.EventHandler(this.chkRhythmKeys_CheckedChanged);
            // 
            // pic2xBass
            // 
            this.pic2xBass.BackColor = System.Drawing.Color.Transparent;
            this.pic2xBass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic2xBass.Location = new System.Drawing.Point(269, 376);
            this.pic2xBass.Name = "pic2xBass";
            this.pic2xBass.Size = new System.Drawing.Size(64, 54);
            this.pic2xBass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic2xBass.TabIndex = 110;
            this.pic2xBass.TabStop = false;
            this.ToolTip.SetToolTip(this.pic2xBass, "Click here if your song is a 2x Bass Pedal song");
            this.pic2xBass.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic2xBass_MouseClick);
            // 
            // picRhythmBass
            // 
            this.picRhythmBass.BackColor = System.Drawing.Color.Transparent;
            this.picRhythmBass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRhythmBass.Location = new System.Drawing.Point(79, 451);
            this.picRhythmBass.Name = "picRhythmBass";
            this.picRhythmBass.Size = new System.Drawing.Size(64, 54);
            this.picRhythmBass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRhythmBass.TabIndex = 109;
            this.picRhythmBass.TabStop = false;
            this.ToolTip.SetToolTip(this.picRhythmBass, "Click here if the song has rhythm guitar charted on the Bass track");
            this.picRhythmBass.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picRhythmBass_MouseClick);
            // 
            // picRhythmKeys
            // 
            this.picRhythmKeys.BackColor = System.Drawing.Color.Transparent;
            this.picRhythmKeys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRhythmKeys.Location = new System.Drawing.Point(15, 451);
            this.picRhythmKeys.Name = "picRhythmKeys";
            this.picRhythmKeys.Size = new System.Drawing.Size(64, 54);
            this.picRhythmKeys.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRhythmKeys.TabIndex = 108;
            this.picRhythmKeys.TabStop = false;
            this.ToolTip.SetToolTip(this.picRhythmKeys, "Click here if the song has rhythm guitar charted on the Keys track");
            this.picRhythmKeys.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picRhythmKeys_MouseClick);
            // 
            // chkReRecord
            // 
            this.chkReRecord.AutoSize = true;
            this.chkReRecord.BackColor = System.Drawing.Color.Transparent;
            this.chkReRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkReRecord.ForeColor = System.Drawing.Color.LightGray;
            this.chkReRecord.Location = new System.Drawing.Point(275, 169);
            this.chkReRecord.Name = "chkReRecord";
            this.chkReRecord.Size = new System.Drawing.Size(15, 14);
            this.chkReRecord.TabIndex = 8;
            this.ToolTip.SetToolTip(this.chkReRecord, "Check if the song is a re-recording");
            this.chkReRecord.UseVisualStyleBackColor = false;
            this.chkReRecord.CheckedChanged += new System.EventHandler(this.chkReRecord_CheckedChanged);
            // 
            // LabelReRecording
            // 
            this.LabelReRecording.BackColor = System.Drawing.Color.Transparent;
            this.LabelReRecording.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelReRecording.ForeColor = System.Drawing.Color.LightGray;
            this.LabelReRecording.Location = new System.Drawing.Point(247, 169);
            this.LabelReRecording.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.LabelReRecording.Name = "LabelReRecording";
            this.LabelReRecording.Size = new System.Drawing.Size(126, 13);
            this.LabelReRecording.TabIndex = 106;
            this.LabelReRecording.Text = "RE-RELEASE";
            this.LabelReRecording.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.LabelReRecording, "Check this if the song is a re-recording, otherwise leave it unchecked (default)");
            // 
            // numericReRecord
            // 
            this.numericReRecord.BackColor = System.Drawing.Color.White;
            this.numericReRecord.Enabled = false;
            this.numericReRecord.ForeColor = System.Drawing.Color.Black;
            this.numericReRecord.Location = new System.Drawing.Point(375, 166);
            this.numericReRecord.Maximum = new decimal(new int[] {
            2112,
            0,
            0,
            0});
            this.numericReRecord.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericReRecord.Name = "numericReRecord";
            this.numericReRecord.Size = new System.Drawing.Size(55, 20);
            this.numericReRecord.TabIndex = 9;
            this.numericReRecord.Tag = "Information - Year Released";
            this.ToolTip.SetToolTip(this.numericReRecord, "Use this to set the re-recording date");
            this.numericReRecord.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            this.numericReRecord.ValueChanged += new System.EventHandler(this.numericReRecord_ValueChanged);
            // 
            // CheckBoxLangJapanese
            // 
            this.CheckBoxLangJapanese.AutoSize = true;
            this.CheckBoxLangJapanese.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxLangJapanese.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxLangJapanese.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxLangJapanese.ForeColor = System.Drawing.Color.White;
            this.CheckBoxLangJapanese.Location = new System.Drawing.Point(265, 292);
            this.CheckBoxLangJapanese.Name = "CheckBoxLangJapanese";
            this.CheckBoxLangJapanese.Size = new System.Drawing.Size(80, 17);
            this.CheckBoxLangJapanese.TabIndex = 18;
            this.CheckBoxLangJapanese.Text = "Japanese";
            this.ToolTip.SetToolTip(this.CheckBoxLangJapanese, "Click here to set the song\'s language to Japanese");
            this.CheckBoxLangJapanese.UseVisualStyleBackColor = false;
            this.CheckBoxLangJapanese.CheckedChanged += new System.EventHandler(this.CheckBoxLanguage_CheckedChanged);
            // 
            // CheckBoxLangGerman
            // 
            this.CheckBoxLangGerman.AutoSize = true;
            this.CheckBoxLangGerman.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxLangGerman.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxLangGerman.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxLangGerman.ForeColor = System.Drawing.Color.White;
            this.CheckBoxLangGerman.Location = new System.Drawing.Point(352, 270);
            this.CheckBoxLangGerman.Name = "CheckBoxLangGerman";
            this.CheckBoxLangGerman.Size = new System.Drawing.Size(69, 17);
            this.CheckBoxLangGerman.TabIndex = 15;
            this.CheckBoxLangGerman.Text = "German";
            this.ToolTip.SetToolTip(this.CheckBoxLangGerman, "Click here to set the song\'s language to German");
            this.CheckBoxLangGerman.UseVisualStyleBackColor = false;
            this.CheckBoxLangGerman.CheckedChanged += new System.EventHandler(this.CheckBoxLanguage_CheckedChanged);
            // 
            // ButtonAlbumArt
            // 
            this.ButtonAlbumArt.BackColor = System.Drawing.Color.Black;
            this.ButtonAlbumArt.BackgroundImage = global::MagmaRokOn.Properties.Resources.button_bg_small;
            this.ButtonAlbumArt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonAlbumArt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAlbumArt.FlatAppearance.BorderSize = 0;
            this.ButtonAlbumArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAlbumArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAlbumArt.ForeColor = System.Drawing.Color.White;
            this.ButtonAlbumArt.Location = new System.Drawing.Point(697, 287);
            this.ButtonAlbumArt.Name = "ButtonAlbumArt";
            this.ButtonAlbumArt.Size = new System.Drawing.Size(28, 22);
            this.ButtonAlbumArt.TabIndex = 100;
            this.ButtonAlbumArt.Text = "...";
            this.ButtonAlbumArt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolTip.SetToolTip(this.ButtonAlbumArt, "Click here to browse for a new image. HINT: you can just drag and drop it above!");
            this.ButtonAlbumArt.UseVisualStyleBackColor = false;
            this.ButtonAlbumArt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxAlbumArt_MouseClick);
            // 
            // LabelAlbumName
            // 
            this.LabelAlbumName.BackColor = System.Drawing.Color.Transparent;
            this.LabelAlbumName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAlbumName.ForeColor = System.Drawing.Color.LightGray;
            this.LabelAlbumName.Location = new System.Drawing.Point(70, 96);
            this.LabelAlbumName.Name = "LabelAlbumName";
            this.LabelAlbumName.Size = new System.Drawing.Size(96, 13);
            this.LabelAlbumName.TabIndex = 97;
            this.LabelAlbumName.Text = "ALBUM";
            this.LabelAlbumName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckBoxFromAlbum
            // 
            this.CheckBoxFromAlbum.AutoSize = true;
            this.CheckBoxFromAlbum.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxFromAlbum.Checked = true;
            this.CheckBoxFromAlbum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxFromAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxFromAlbum.Location = new System.Drawing.Point(29, 95);
            this.CheckBoxFromAlbum.Name = "CheckBoxFromAlbum";
            this.CheckBoxFromAlbum.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxFromAlbum.TabIndex = 4;
            this.ToolTip.SetToolTip(this.CheckBoxFromAlbum, "Uncheck if the song is a single");
            this.CheckBoxFromAlbum.UseVisualStyleBackColor = false;
            this.CheckBoxFromAlbum.CheckedChanged += new System.EventHandler(this.CheckBoxFromAlbum_CheckedChanged);
            // 
            // ButtonClearAlbumArt
            // 
            this.ButtonClearAlbumArt.BackColor = System.Drawing.Color.Black;
            this.ButtonClearAlbumArt.BackgroundImage = global::MagmaRokOn.Properties.Resources.button_bg_small;
            this.ButtonClearAlbumArt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonClearAlbumArt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonClearAlbumArt.FlatAppearance.BorderSize = 0;
            this.ButtonClearAlbumArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClearAlbumArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClearAlbumArt.ForeColor = System.Drawing.Color.White;
            this.ButtonClearAlbumArt.Location = new System.Drawing.Point(663, 287);
            this.ButtonClearAlbumArt.Name = "ButtonClearAlbumArt";
            this.ButtonClearAlbumArt.Size = new System.Drawing.Size(28, 22);
            this.ButtonClearAlbumArt.TabIndex = 17;
            this.ButtonClearAlbumArt.Text = "X";
            this.ToolTip.SetToolTip(this.ButtonClearAlbumArt, "Click here to remove the album art and use the default image");
            this.ButtonClearAlbumArt.UseVisualStyleBackColor = false;
            this.ButtonClearAlbumArt.Click += new System.EventHandler(this.ButtonClearAlbumArt_Click);
            // 
            // TextBoxAlbumArt
            // 
            this.TextBoxAlbumArt.AllowDrop = true;
            this.TextBoxAlbumArt.BackColor = System.Drawing.Color.White;
            this.TextBoxAlbumArt.ForeColor = System.Drawing.Color.Black;
            this.TextBoxAlbumArt.Location = new System.Drawing.Point(469, 289);
            this.TextBoxAlbumArt.MaxLength = 250;
            this.TextBoxAlbumArt.Name = "TextBoxAlbumArt";
            this.TextBoxAlbumArt.Size = new System.Drawing.Size(188, 20);
            this.TextBoxAlbumArt.TabIndex = 28;
            this.ToolTip.SetToolTip(this.TextBoxAlbumArt, "Album art path, click on the button to change");
            this.TextBoxAlbumArt.TextChanged += new System.EventHandler(this.TextBoxAlbumArt_TextChanged);
            this.TextBoxAlbumArt.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBoxAlbumArt_DragDrop);
            this.TextBoxAlbumArt.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            // 
            // NumericTrackNumber
            // 
            this.NumericTrackNumber.BackColor = System.Drawing.Color.White;
            this.NumericTrackNumber.ForeColor = System.Drawing.Color.Black;
            this.NumericTrackNumber.Location = new System.Drawing.Point(171, 122);
            this.NumericTrackNumber.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NumericTrackNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericTrackNumber.Name = "NumericTrackNumber";
            this.NumericTrackNumber.Size = new System.Drawing.Size(43, 20);
            this.NumericTrackNumber.TabIndex = 6;
            this.NumericTrackNumber.Tag = "Information - Track Number";
            this.ToolTip.SetToolTip(this.NumericTrackNumber, "Use this to set the track number");
            this.NumericTrackNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericTrackNumber.ValueChanged += new System.EventHandler(this.NumericTrackNumber_ValueChanged);
            // 
            // LabelTrackNumber
            // 
            this.LabelTrackNumber.BackColor = System.Drawing.Color.Transparent;
            this.LabelTrackNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTrackNumber.ForeColor = System.Drawing.Color.LightGray;
            this.LabelTrackNumber.Location = new System.Drawing.Point(40, 125);
            this.LabelTrackNumber.Name = "LabelTrackNumber";
            this.LabelTrackNumber.Size = new System.Drawing.Size(126, 13);
            this.LabelTrackNumber.TabIndex = 88;
            this.LabelTrackNumber.Text = "TRACK NUMBER";
            this.LabelTrackNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelLanguages
            // 
            this.LabelLanguages.BackColor = System.Drawing.Color.Transparent;
            this.LabelLanguages.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLanguages.ForeColor = System.Drawing.Color.LightGray;
            this.LabelLanguages.Location = new System.Drawing.Point(40, 270);
            this.LabelLanguages.Name = "LabelLanguages";
            this.LabelLanguages.Size = new System.Drawing.Size(126, 13);
            this.LabelLanguages.TabIndex = 86;
            this.LabelLanguages.Text = "LANGUAGE(S)";
            this.LabelLanguages.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckBoxLangItalian
            // 
            this.CheckBoxLangItalian.AutoSize = true;
            this.CheckBoxLangItalian.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxLangItalian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxLangItalian.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxLangItalian.ForeColor = System.Drawing.Color.White;
            this.CheckBoxLangItalian.Location = new System.Drawing.Point(171, 292);
            this.CheckBoxLangItalian.Name = "CheckBoxLangItalian";
            this.CheckBoxLangItalian.Size = new System.Drawing.Size(61, 17);
            this.CheckBoxLangItalian.TabIndex = 14;
            this.CheckBoxLangItalian.Text = "Italian";
            this.ToolTip.SetToolTip(this.CheckBoxLangItalian, "Click here to set the song\'s language to Italian");
            this.CheckBoxLangItalian.UseVisualStyleBackColor = false;
            this.CheckBoxLangItalian.CheckedChanged += new System.EventHandler(this.CheckBoxLanguage_CheckedChanged);
            // 
            // CheckBoxLangEnglish
            // 
            this.CheckBoxLangEnglish.AutoSize = true;
            this.CheckBoxLangEnglish.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxLangEnglish.Checked = true;
            this.CheckBoxLangEnglish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxLangEnglish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxLangEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxLangEnglish.ForeColor = System.Drawing.Color.White;
            this.CheckBoxLangEnglish.Location = new System.Drawing.Point(171, 270);
            this.CheckBoxLangEnglish.Name = "CheckBoxLangEnglish";
            this.CheckBoxLangEnglish.Size = new System.Drawing.Size(67, 17);
            this.CheckBoxLangEnglish.TabIndex = 13;
            this.CheckBoxLangEnglish.Text = "English";
            this.ToolTip.SetToolTip(this.CheckBoxLangEnglish, "Click here to set the song\'s language to English");
            this.CheckBoxLangEnglish.UseVisualStyleBackColor = false;
            this.CheckBoxLangEnglish.CheckedChanged += new System.EventHandler(this.CheckBoxLanguage_CheckedChanged);
            // 
            // CheckBoxLangFrench
            // 
            this.CheckBoxLangFrench.AutoSize = true;
            this.CheckBoxLangFrench.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxLangFrench.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxLangFrench.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxLangFrench.ForeColor = System.Drawing.Color.White;
            this.CheckBoxLangFrench.Location = new System.Drawing.Point(265, 270);
            this.CheckBoxLangFrench.Name = "CheckBoxLangFrench";
            this.CheckBoxLangFrench.Size = new System.Drawing.Size(64, 17);
            this.CheckBoxLangFrench.TabIndex = 16;
            this.CheckBoxLangFrench.Text = "French";
            this.ToolTip.SetToolTip(this.CheckBoxLangFrench, "Click here to set the song\'s language to French");
            this.CheckBoxLangFrench.UseVisualStyleBackColor = false;
            this.CheckBoxLangFrench.CheckedChanged += new System.EventHandler(this.CheckBoxLanguage_CheckedChanged);
            // 
            // CheckBoxLangSpanish
            // 
            this.CheckBoxLangSpanish.AutoSize = true;
            this.CheckBoxLangSpanish.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxLangSpanish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxLangSpanish.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxLangSpanish.ForeColor = System.Drawing.Color.White;
            this.CheckBoxLangSpanish.Location = new System.Drawing.Point(352, 292);
            this.CheckBoxLangSpanish.Name = "CheckBoxLangSpanish";
            this.CheckBoxLangSpanish.Size = new System.Drawing.Size(71, 17);
            this.CheckBoxLangSpanish.TabIndex = 17;
            this.CheckBoxLangSpanish.Text = "Spanish";
            this.ToolTip.SetToolTip(this.CheckBoxLangSpanish, "Click here to set the song\'s language to Spanish");
            this.CheckBoxLangSpanish.UseVisualStyleBackColor = false;
            this.CheckBoxLangSpanish.CheckedChanged += new System.EventHandler(this.CheckBoxLanguage_CheckedChanged);
            // 
            // LabelAuthor
            // 
            this.LabelAuthor.BackColor = System.Drawing.Color.Transparent;
            this.LabelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAuthor.ForeColor = System.Drawing.Color.LightGray;
            this.LabelAuthor.Location = new System.Drawing.Point(40, 332);
            this.LabelAuthor.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.LabelAuthor.Name = "LabelAuthor";
            this.LabelAuthor.Size = new System.Drawing.Size(126, 13);
            this.LabelAuthor.TabIndex = 81;
            this.LabelAuthor.Text = "AUTHOR(S)";
            this.LabelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextBoxAuthor
            // 
            this.TextBoxAuthor.BackColor = System.Drawing.Color.White;
            this.TextBoxAuthor.ForeColor = System.Drawing.Color.Black;
            this.TextBoxAuthor.Location = new System.Drawing.Point(171, 328);
            this.TextBoxAuthor.MaxLength = 74;
            this.TextBoxAuthor.Name = "TextBoxAuthor";
            this.TextBoxAuthor.Size = new System.Drawing.Size(233, 20);
            this.TextBoxAuthor.TabIndex = 19;
            this.TextBoxAuthor.Tag = "Information - Author";
            this.ToolTip.SetToolTip(this.TextBoxAuthor, "Enter your name or online alias here");
            this.TextBoxAuthor.TextChanged += new System.EventHandler(this.TextBoxAuthor_TextChanged);
            // 
            // ComboBoxGenre
            // 
            this.ComboBoxGenre.BackColor = System.Drawing.Color.White;
            this.ComboBoxGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxGenre.ForeColor = System.Drawing.Color.Black;
            this.ComboBoxGenre.FormattingEnabled = true;
            this.ComboBoxGenre.Location = new System.Drawing.Point(171, 198);
            this.ComboBoxGenre.Name = "ComboBoxGenre";
            this.ComboBoxGenre.Size = new System.Drawing.Size(261, 21);
            this.ComboBoxGenre.TabIndex = 10;
            this.ComboBoxGenre.Tag = "Information - Genre";
            this.ToolTip.SetToolTip(this.ComboBoxGenre, "Click here to select the song\'s genre");
            this.ComboBoxGenre.SelectedIndexChanged += new System.EventHandler(this.ComboBoxGenre_SelectedIndexChanged);
            // 
            // LabelGenre
            // 
            this.LabelGenre.BackColor = System.Drawing.Color.Transparent;
            this.LabelGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGenre.ForeColor = System.Drawing.Color.LightGray;
            this.LabelGenre.Location = new System.Drawing.Point(40, 202);
            this.LabelGenre.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.LabelGenre.Name = "LabelGenre";
            this.LabelGenre.Size = new System.Drawing.Size(126, 13);
            this.LabelGenre.TabIndex = 72;
            this.LabelGenre.Text = "GENRE";
            this.LabelGenre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelSubgenre
            // 
            this.LabelSubgenre.BackColor = System.Drawing.Color.Transparent;
            this.LabelSubgenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSubgenre.ForeColor = System.Drawing.Color.LightGray;
            this.LabelSubgenre.Location = new System.Drawing.Point(40, 231);
            this.LabelSubgenre.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.LabelSubgenre.Name = "LabelSubgenre";
            this.LabelSubgenre.Size = new System.Drawing.Size(126, 13);
            this.LabelSubgenre.TabIndex = 75;
            this.LabelSubgenre.Text = "SUB GENRE";
            this.LabelSubgenre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ComboBoxSubGenre
            // 
            this.ComboBoxSubGenre.BackColor = System.Drawing.Color.White;
            this.ComboBoxSubGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSubGenre.ForeColor = System.Drawing.Color.Black;
            this.ComboBoxSubGenre.FormattingEnabled = true;
            this.ComboBoxSubGenre.Items.AddRange(new object[] {
            "Rock",
            "Pop",
            "Flute"});
            this.ComboBoxSubGenre.Location = new System.Drawing.Point(171, 228);
            this.ComboBoxSubGenre.Name = "ComboBoxSubGenre";
            this.ComboBoxSubGenre.Size = new System.Drawing.Size(261, 21);
            this.ComboBoxSubGenre.TabIndex = 11;
            this.ComboBoxSubGenre.Tag = "Information - Sub Genre";
            this.ToolTip.SetToolTip(this.ComboBoxSubGenre, "Click here to select the song\'s sub-genre");
            this.ComboBoxSubGenre.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSubGenre_SelectedIndexChanged);
            // 
            // LabelSongName
            // 
            this.LabelSongName.BackColor = System.Drawing.Color.Transparent;
            this.LabelSongName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSongName.ForeColor = System.Drawing.Color.LightGray;
            this.LabelSongName.Location = new System.Drawing.Point(40, 24);
            this.LabelSongName.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.LabelSongName.Name = "LabelSongName";
            this.LabelSongName.Size = new System.Drawing.Size(126, 13);
            this.LabelSongName.TabIndex = 66;
            this.LabelSongName.Text = "TITLE";
            this.LabelSongName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextBoxSongName
            // 
            this.TextBoxSongName.BackColor = System.Drawing.Color.White;
            this.TextBoxSongName.ForeColor = System.Drawing.Color.Black;
            this.TextBoxSongName.Location = new System.Drawing.Point(171, 20);
            this.TextBoxSongName.MaxLength = 99;
            this.TextBoxSongName.Name = "TextBoxSongName";
            this.TextBoxSongName.Size = new System.Drawing.Size(261, 20);
            this.TextBoxSongName.TabIndex = 1;
            this.TextBoxSongName.Tag = "Information - Song Name";
            this.ToolTip.SetToolTip(this.TextBoxSongName, "Enter the song title here");
            this.TextBoxSongName.TextChanged += new System.EventHandler(this.TextBoxSongName_TextChanged);
            // 
            // TextBoxArtistName
            // 
            this.TextBoxArtistName.BackColor = System.Drawing.Color.White;
            this.TextBoxArtistName.ForeColor = System.Drawing.Color.Black;
            this.TextBoxArtistName.Location = new System.Drawing.Point(171, 50);
            this.TextBoxArtistName.MaxLength = 74;
            this.TextBoxArtistName.Name = "TextBoxArtistName";
            this.TextBoxArtistName.Size = new System.Drawing.Size(261, 20);
            this.TextBoxArtistName.TabIndex = 3;
            this.TextBoxArtistName.Tag = "Information - Artist";
            this.ToolTip.SetToolTip(this.TextBoxArtistName, "Enter artist / band name here");
            this.TextBoxArtistName.TextChanged += new System.EventHandler(this.TextBoxArtistName_TextChanged);
            // 
            // LabelArtist
            // 
            this.LabelArtist.BackColor = System.Drawing.Color.Transparent;
            this.LabelArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelArtist.ForeColor = System.Drawing.Color.LightGray;
            this.LabelArtist.Location = new System.Drawing.Point(101, 54);
            this.LabelArtist.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.LabelArtist.Name = "LabelArtist";
            this.LabelArtist.Size = new System.Drawing.Size(65, 13);
            this.LabelArtist.TabIndex = 68;
            this.LabelArtist.Text = "ARTIST";
            this.LabelArtist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextBoxAlbumName
            // 
            this.TextBoxAlbumName.ForeColor = System.Drawing.Color.Black;
            this.TextBoxAlbumName.Location = new System.Drawing.Point(171, 92);
            this.TextBoxAlbumName.MaxLength = 74;
            this.TextBoxAlbumName.Name = "TextBoxAlbumName";
            this.TextBoxAlbumName.Size = new System.Drawing.Size(261, 20);
            this.TextBoxAlbumName.TabIndex = 5;
            this.TextBoxAlbumName.Tag = "Information - Album";
            this.ToolTip.SetToolTip(this.TextBoxAlbumName, "Enter album name here");
            this.TextBoxAlbumName.TextChanged += new System.EventHandler(this.TextBoxAlbumName_TextChanged);
            // 
            // LabelYearReleased
            // 
            this.LabelYearReleased.BackColor = System.Drawing.Color.Transparent;
            this.LabelYearReleased.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelYearReleased.ForeColor = System.Drawing.Color.LightGray;
            this.LabelYearReleased.Location = new System.Drawing.Point(-3, 169);
            this.LabelYearReleased.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.LabelYearReleased.Name = "LabelYearReleased";
            this.LabelYearReleased.Size = new System.Drawing.Size(170, 13);
            this.LabelYearReleased.TabIndex = 71;
            this.LabelYearReleased.Text = "ORIG. RELEASE DATE";
            this.LabelYearReleased.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericUpDownYear
            // 
            this.NumericUpDownYear.BackColor = System.Drawing.Color.White;
            this.NumericUpDownYear.ForeColor = System.Drawing.Color.Black;
            this.NumericUpDownYear.Location = new System.Drawing.Point(171, 166);
            this.NumericUpDownYear.Maximum = new decimal(new int[] {
            2112,
            0,
            0,
            0});
            this.NumericUpDownYear.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericUpDownYear.Name = "NumericUpDownYear";
            this.NumericUpDownYear.Size = new System.Drawing.Size(55, 20);
            this.NumericUpDownYear.TabIndex = 7;
            this.NumericUpDownYear.Tag = "Information - Year Released";
            this.ToolTip.SetToolTip(this.NumericUpDownYear, "Use this to set the original release date");
            this.NumericUpDownYear.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            this.NumericUpDownYear.ValueChanged += new System.EventHandler(this.NumericUpDownYear_ValueChanged);
            // 
            // PictureBoxAlbumArt
            // 
            this.PictureBoxAlbumArt.BackColor = System.Drawing.Color.DarkGray;
            this.PictureBoxAlbumArt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBoxAlbumArt.ContextMenuStrip = this.contextMenuStrip4;
            this.PictureBoxAlbumArt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxAlbumArt.Location = new System.Drawing.Point(469, 20);
            this.PictureBoxAlbumArt.Name = "PictureBoxAlbumArt";
            this.PictureBoxAlbumArt.Padding = new System.Windows.Forms.Padding(2);
            this.PictureBoxAlbumArt.Size = new System.Drawing.Size(256, 256);
            this.PictureBoxAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxAlbumArt.TabIndex = 87;
            this.PictureBoxAlbumArt.TabStop = false;
            this.ToolTip.SetToolTip(this.PictureBoxAlbumArt, "This is the album art you see in game. Click here to change it or drag and drop a" +
        "n image here");
            this.PictureBoxAlbumArt.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBoxAlbumArt_DragDrop);
            this.PictureBoxAlbumArt.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.PictureBoxAlbumArt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxAlbumArt_MouseClick);
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useDefaultArt,
            this.visitAlbumArtRepository});
            this.contextMenuStrip4.Name = "contextMenuStrip4";
            this.contextMenuStrip4.Size = new System.Drawing.Size(224, 48);
            // 
            // useDefaultArt
            // 
            this.useDefaultArt.BackColor = System.Drawing.Color.Black;
            this.useDefaultArt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.useDefaultArt.ForeColor = System.Drawing.Color.LightGray;
            this.useDefaultArt.Name = "useDefaultArt";
            this.useDefaultArt.Size = new System.Drawing.Size(223, 22);
            this.useDefaultArt.Text = "Use default art";
            this.useDefaultArt.Click += new System.EventHandler(this.useDefaultArtToolStripMenuItem_Click);
            // 
            // visitAlbumArtRepository
            // 
            this.visitAlbumArtRepository.BackColor = System.Drawing.Color.Black;
            this.visitAlbumArtRepository.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.visitAlbumArtRepository.ForeColor = System.Drawing.Color.LightGray;
            this.visitAlbumArtRepository.Name = "visitAlbumArtRepository";
            this.visitAlbumArtRepository.Size = new System.Drawing.Size(223, 22);
            this.visitAlbumArtRepository.Text = "Visit Album Art Repository";
            this.visitAlbumArtRepository.Click += new System.EventHandler(this.visitAlbumArtRepositoryToolStripMenuItem_Click);
            // 
            // TabPageAudio
            // 
            this.TabPageAudio.AllowDrop = true;
            this.TabPageAudio.BackColor = System.Drawing.Color.Black;
            this.TabPageAudio.BackgroundImage = global::MagmaRokOn.Properties.Resources.bg3;
            this.TabPageAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TabPageAudio.Controls.Add(this.prevEndMilliseconds);
            this.TabPageAudio.Controls.Add(this.prevEndSeconds);
            this.TabPageAudio.Controls.Add(this.prevEndMinutes);
            this.TabPageAudio.Controls.Add(this.LabelEndPreview);
            this.TabPageAudio.Controls.Add(this.label5);
            this.TabPageAudio.Controls.Add(this.label6);
            this.TabPageAudio.Controls.Add(this.picSpectrum);
            this.TabPageAudio.Controls.Add(this.btnPlay);
            this.TabPageAudio.Controls.Add(this.numericMilliseconds);
            this.TabPageAudio.Controls.Add(this.ZeroCrowd);
            this.TabPageAudio.Controls.Add(this.picHelpCrowd);
            this.TabPageAudio.Controls.Add(this.numericCrowd);
            this.TabPageAudio.Controls.Add(this.LabelCrowdPan);
            this.TabPageAudio.Controls.Add(this.ZeroBacking);
            this.TabPageAudio.Controls.Add(this.ZeroVocals);
            this.TabPageAudio.Controls.Add(this.ZeroKeys);
            this.TabPageAudio.Controls.Add(this.ZeroGuitar);
            this.TabPageAudio.Controls.Add(this.ZeroBass);
            this.TabPageAudio.Controls.Add(this.ZeroDrumKick);
            this.TabPageAudio.Controls.Add(this.ZeroDrumSnare);
            this.TabPageAudio.Controls.Add(this.ZeroDrumKit);
            this.TabPageAudio.Controls.Add(this.panel11);
            this.TabPageAudio.Controls.Add(this.panel10);
            this.TabPageAudio.Controls.Add(this.panel9);
            this.TabPageAudio.Controls.Add(this.panel8);
            this.TabPageAudio.Controls.Add(this.panel7);
            this.TabPageAudio.Controls.Add(this.panel6);
            this.TabPageAudio.Controls.Add(this.panel5);
            this.TabPageAudio.Controls.Add(this.label30);
            this.TabPageAudio.Controls.Add(this.label29);
            this.TabPageAudio.Controls.Add(this.NumericBackingAttenuation);
            this.TabPageAudio.Controls.Add(this.NumericVocalAttenuation);
            this.TabPageAudio.Controls.Add(this.NumericKeysAttenuation);
            this.TabPageAudio.Controls.Add(this.NumericGuitarAttenuation);
            this.TabPageAudio.Controls.Add(this.NumericBassAttenuation);
            this.TabPageAudio.Controls.Add(this.NumericDrumSnareAttenuation);
            this.TabPageAudio.Controls.Add(this.NumericDrumKickAttenuation);
            this.TabPageAudio.Controls.Add(this.NumericDrumKitAttenuation);
            this.TabPageAudio.Controls.Add(this.LabelBackingPan);
            this.TabPageAudio.Controls.Add(this.NumericBackingPan);
            this.TabPageAudio.Controls.Add(this.LabelVocalPan);
            this.TabPageAudio.Controls.Add(this.NumericVocalPan);
            this.TabPageAudio.Controls.Add(this.LabelKeysPan);
            this.TabPageAudio.Controls.Add(this.NumericKeysPan);
            this.TabPageAudio.Controls.Add(this.LabelGuitarPan);
            this.TabPageAudio.Controls.Add(this.NumericGuitarPan);
            this.TabPageAudio.Controls.Add(this.LabelBassPan);
            this.TabPageAudio.Controls.Add(this.NumericBassPan);
            this.TabPageAudio.Controls.Add(this.LabelDrumSnarePan);
            this.TabPageAudio.Controls.Add(this.LabelDrumKickPan);
            this.TabPageAudio.Controls.Add(this.LabelDrumKitPan);
            this.TabPageAudio.Controls.Add(this.NumericDrumSnarePan);
            this.TabPageAudio.Controls.Add(this.NumericDrumKickPan);
            this.TabPageAudio.Controls.Add(this.NumericDrumKitPan);
            this.TabPageAudio.Controls.Add(this.ButtonBacking);
            this.TabPageAudio.Controls.Add(this.TextBoxBacking);
            this.TabPageAudio.Controls.Add(this.LabelBacking);
            this.TabPageAudio.Controls.Add(this.CheckBacking);
            this.TabPageAudio.Controls.Add(this.CheckHarmonyVocals3);
            this.TabPageAudio.Controls.Add(this.LabelDryVocalsHarmony3);
            this.TabPageAudio.Controls.Add(this.ButtonDryVocalsHarmony3);
            this.TabPageAudio.Controls.Add(this.TextBoxDryVocalsHarmony3);
            this.TabPageAudio.Controls.Add(this.CheckHarmonyVocals2);
            this.TabPageAudio.Controls.Add(this.LabelDryVocalsHarmony2);
            this.TabPageAudio.Controls.Add(this.ButtonDryVocalsHarmony2);
            this.TabPageAudio.Controls.Add(this.ButtonDryVocals);
            this.TabPageAudio.Controls.Add(this.TextBoxDryVocals);
            this.TabPageAudio.Controls.Add(this.TextBoxDryVocalsHarmony2);
            this.TabPageAudio.Controls.Add(this.LabelDryVocals);
            this.TabPageAudio.Controls.Add(this.ButtonVocals);
            this.TabPageAudio.Controls.Add(this.TextBoxVocals);
            this.TabPageAudio.Controls.Add(this.LabelVocals);
            this.TabPageAudio.Controls.Add(this.CheckVocals);
            this.TabPageAudio.Controls.Add(this.ButtonKeys);
            this.TabPageAudio.Controls.Add(this.TextBoxKeys);
            this.TabPageAudio.Controls.Add(this.LabelKeys);
            this.TabPageAudio.Controls.Add(this.CheckKeys);
            this.TabPageAudio.Controls.Add(this.ButtonGuitar);
            this.TabPageAudio.Controls.Add(this.TextBoxGuitar);
            this.TabPageAudio.Controls.Add(this.LabelGuitar);
            this.TabPageAudio.Controls.Add(this.CheckGuitar);
            this.TabPageAudio.Controls.Add(this.ButtonBass);
            this.TabPageAudio.Controls.Add(this.TextBoxBass);
            this.TabPageAudio.Controls.Add(this.LabelBass);
            this.TabPageAudio.Controls.Add(this.CheckBass);
            this.TabPageAudio.Controls.Add(this.ComboDrums);
            this.TabPageAudio.Controls.Add(this.LabelDrumSnare);
            this.TabPageAudio.Controls.Add(this.LabelDrumKick);
            this.TabPageAudio.Controls.Add(this.LabelDrumKit);
            this.TabPageAudio.Controls.Add(this.ButtonDrumSnare);
            this.TabPageAudio.Controls.Add(this.TextBoxDrumSnare);
            this.TabPageAudio.Controls.Add(this.ButtonDrumKick);
            this.TabPageAudio.Controls.Add(this.TextBoxDrumKick);
            this.TabPageAudio.Controls.Add(this.ButtonDrumKit);
            this.TabPageAudio.Controls.Add(this.LabelDrums);
            this.TabPageAudio.Controls.Add(this.TextBoxDrumKit);
            this.TabPageAudio.Controls.Add(this.CheckDrums);
            this.TabPageAudio.Controls.Add(this.btnCrowd);
            this.TabPageAudio.Controls.Add(this.TextBoxCrowd);
            this.TabPageAudio.Controls.Add(this.LabelCrowd);
            this.TabPageAudio.Controls.Add(this.CheckCrowd);
            this.TabPageAudio.Controls.Add(this.EncodingQualityUpDown);
            this.TabPageAudio.Controls.Add(this.LabelEncodingQuality);
            this.TabPageAudio.Controls.Add(this.groupDrumMix);
            this.TabPageAudio.Controls.Add(this.DomainPreviewSecs);
            this.TabPageAudio.Controls.Add(this.NumericPreviewMins);
            this.TabPageAudio.Controls.Add(this.LabelStartPreview);
            this.TabPageAudio.Controls.Add(this.LabelSongLength);
            this.TabPageAudio.Controls.Add(this.LabelLength);
            this.TabPageAudio.Controls.Add(this.LabelPreviewSeparator);
            this.TabPageAudio.Controls.Add(this.label3);
            this.TabPageAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPageAudio.Location = new System.Drawing.Point(4, 25);
            this.TabPageAudio.Name = "TabPageAudio";
            this.TabPageAudio.Size = new System.Drawing.Size(749, 571);
            this.TabPageAudio.TabIndex = 7;
            this.TabPageAudio.Text = "Audio";
            this.TabPageAudio.DragDrop += new System.Windows.Forms.DragEventHandler(this.HandleDragDrop);
            this.TabPageAudio.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            // 
            // prevEndMilliseconds
            // 
            this.prevEndMilliseconds.BackColor = System.Drawing.Color.White;
            this.prevEndMilliseconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevEndMilliseconds.ForeColor = System.Drawing.Color.Black;
            this.prevEndMilliseconds.Location = new System.Drawing.Point(263, 509);
            this.prevEndMilliseconds.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.prevEndMilliseconds.Name = "prevEndMilliseconds";
            this.prevEndMilliseconds.Size = new System.Drawing.Size(52, 20);
            this.prevEndMilliseconds.TabIndex = 170;
            this.prevEndMilliseconds.Tag = "Audio - Preview End";
            this.prevEndMilliseconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.prevEndMilliseconds, "Change the preview end time milliseconds");
            this.prevEndMilliseconds.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // prevEndSeconds
            // 
            this.prevEndSeconds.BackColor = System.Drawing.Color.White;
            this.prevEndSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevEndSeconds.ForeColor = System.Drawing.Color.Black;
            this.prevEndSeconds.Items.Add("60");
            this.prevEndSeconds.Items.Add("59");
            this.prevEndSeconds.Items.Add("58");
            this.prevEndSeconds.Items.Add("57");
            this.prevEndSeconds.Items.Add("56");
            this.prevEndSeconds.Items.Add("55");
            this.prevEndSeconds.Items.Add("54");
            this.prevEndSeconds.Items.Add("53");
            this.prevEndSeconds.Items.Add("52");
            this.prevEndSeconds.Items.Add("51");
            this.prevEndSeconds.Items.Add("50");
            this.prevEndSeconds.Items.Add("49");
            this.prevEndSeconds.Items.Add("48");
            this.prevEndSeconds.Items.Add("47");
            this.prevEndSeconds.Items.Add("46");
            this.prevEndSeconds.Items.Add("45");
            this.prevEndSeconds.Items.Add("44");
            this.prevEndSeconds.Items.Add("43");
            this.prevEndSeconds.Items.Add("42");
            this.prevEndSeconds.Items.Add("41");
            this.prevEndSeconds.Items.Add("40");
            this.prevEndSeconds.Items.Add("39");
            this.prevEndSeconds.Items.Add("38");
            this.prevEndSeconds.Items.Add("37");
            this.prevEndSeconds.Items.Add("36");
            this.prevEndSeconds.Items.Add("35");
            this.prevEndSeconds.Items.Add("34");
            this.prevEndSeconds.Items.Add("33");
            this.prevEndSeconds.Items.Add("32");
            this.prevEndSeconds.Items.Add("31");
            this.prevEndSeconds.Items.Add("30");
            this.prevEndSeconds.Items.Add("29");
            this.prevEndSeconds.Items.Add("28");
            this.prevEndSeconds.Items.Add("27");
            this.prevEndSeconds.Items.Add("26");
            this.prevEndSeconds.Items.Add("25");
            this.prevEndSeconds.Items.Add("24");
            this.prevEndSeconds.Items.Add("23");
            this.prevEndSeconds.Items.Add("22");
            this.prevEndSeconds.Items.Add("21");
            this.prevEndSeconds.Items.Add("20");
            this.prevEndSeconds.Items.Add("19");
            this.prevEndSeconds.Items.Add("18");
            this.prevEndSeconds.Items.Add("17");
            this.prevEndSeconds.Items.Add("16");
            this.prevEndSeconds.Items.Add("15");
            this.prevEndSeconds.Items.Add("14");
            this.prevEndSeconds.Items.Add("13");
            this.prevEndSeconds.Items.Add("12");
            this.prevEndSeconds.Items.Add("11");
            this.prevEndSeconds.Items.Add("10");
            this.prevEndSeconds.Items.Add("09");
            this.prevEndSeconds.Items.Add("08");
            this.prevEndSeconds.Items.Add("07");
            this.prevEndSeconds.Items.Add("06");
            this.prevEndSeconds.Items.Add("05");
            this.prevEndSeconds.Items.Add("04");
            this.prevEndSeconds.Items.Add("03");
            this.prevEndSeconds.Items.Add("02");
            this.prevEndSeconds.Items.Add("01");
            this.prevEndSeconds.Items.Add("00");
            this.prevEndSeconds.Items.Add("-1");
            this.prevEndSeconds.Location = new System.Drawing.Point(215, 509);
            this.prevEndSeconds.Name = "prevEndSeconds";
            this.prevEndSeconds.Size = new System.Drawing.Size(39, 20);
            this.prevEndSeconds.TabIndex = 169;
            this.prevEndSeconds.Tag = "Audio - Preview End";
            this.prevEndSeconds.Text = "00";
            this.prevEndSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.prevEndSeconds, "Change the preview end time second");
            this.prevEndSeconds.Leave += new System.EventHandler(this.prevEndSeconds_Leave);
            // 
            // prevEndMinutes
            // 
            this.prevEndMinutes.BackColor = System.Drawing.Color.White;
            this.prevEndMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevEndMinutes.ForeColor = System.Drawing.Color.Black;
            this.prevEndMinutes.Location = new System.Drawing.Point(168, 509);
            this.prevEndMinutes.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.prevEndMinutes.Name = "prevEndMinutes";
            this.prevEndMinutes.Size = new System.Drawing.Size(38, 20);
            this.prevEndMinutes.TabIndex = 168;
            this.prevEndMinutes.Tag = "Audio - Preview End";
            this.prevEndMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.prevEndMinutes, "Change the preview end time minute");
            this.prevEndMinutes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.prevEndMinutes.ValueChanged += new System.EventHandler(this.prevEndMinutes_ValueChanged);
            // 
            // LabelEndPreview
            // 
            this.LabelEndPreview.AutoSize = true;
            this.LabelEndPreview.BackColor = System.Drawing.Color.Transparent;
            this.LabelEndPreview.ForeColor = System.Drawing.Color.White;
            this.LabelEndPreview.Location = new System.Drawing.Point(95, 511);
            this.LabelEndPreview.Name = "LabelEndPreview";
            this.LabelEndPreview.Size = new System.Drawing.Size(70, 13);
            this.LabelEndPreview.TabIndex = 166;
            this.LabelEndPreview.Text = "Preview End:";
            this.LabelEndPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(204, 508);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 21);
            this.label5.TabIndex = 167;
            this.label5.Text = ":";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(252, 508);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 21);
            this.label6.TabIndex = 171;
            this.label6.Text = ":";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picSpectrum
            // 
            this.picSpectrum.BackColor = System.Drawing.Color.Transparent;
            this.picSpectrum.Location = new System.Drawing.Point(405, 471);
            this.picSpectrum.Name = "picSpectrum";
            this.picSpectrum.Size = new System.Drawing.Size(82, 34);
            this.picSpectrum.TabIndex = 165;
            this.picSpectrum.TabStop = false;
            this.ToolTip.SetToolTip(this.picSpectrum, "Click to change");
            this.picSpectrum.Visible = false;
            this.picSpectrum.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picSpectrum_MouseClick);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(73)))), ((int)(((byte)(84)))));
            this.btnPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlay.BackgroundImage")));
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Location = new System.Drawing.Point(323, 479);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(52, 22);
            this.btnPlay.TabIndex = 164;
            this.btnPlay.Text = "Play";
            this.ToolTip.SetToolTip(this.btnPlay, "Click to play the in-game audio preview");
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // numericMilliseconds
            // 
            this.numericMilliseconds.BackColor = System.Drawing.Color.White;
            this.numericMilliseconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMilliseconds.ForeColor = System.Drawing.Color.Black;
            this.numericMilliseconds.Location = new System.Drawing.Point(263, 480);
            this.numericMilliseconds.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericMilliseconds.Name = "numericMilliseconds";
            this.numericMilliseconds.Size = new System.Drawing.Size(52, 20);
            this.numericMilliseconds.TabIndex = 161;
            this.numericMilliseconds.Tag = "Audio - Preview Start";
            this.numericMilliseconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.numericMilliseconds, "Change the preview start time milliseconds");
            this.numericMilliseconds.ValueChanged += new System.EventHandler(this.numericMilliseconds_ValueChanged);
            // 
            // ZeroCrowd
            // 
            this.ZeroCrowd.BackColor = System.Drawing.Color.Transparent;
            this.ZeroCrowd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZeroCrowd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZeroCrowd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroCrowd.ForeColor = System.Drawing.Color.White;
            this.ZeroCrowd.Location = new System.Drawing.Point(693, 438);
            this.ZeroCrowd.Name = "ZeroCrowd";
            this.ZeroCrowd.Size = new System.Drawing.Size(45, 22);
            this.ZeroCrowd.TabIndex = 159;
            this.ZeroCrowd.Text = "Zero";
            this.ZeroCrowd.UseVisualStyleBackColor = false;
            this.ZeroCrowd.Visible = false;
            this.ZeroCrowd.Click += new System.EventHandler(this.ZeroCrowd_Click);
            // 
            // picHelpCrowd
            // 
            this.picHelpCrowd.BackColor = System.Drawing.Color.Transparent;
            this.picHelpCrowd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHelpCrowd.Location = new System.Drawing.Point(512, 436);
            this.picHelpCrowd.Name = "picHelpCrowd";
            this.picHelpCrowd.Size = new System.Drawing.Size(25, 25);
            this.picHelpCrowd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHelpCrowd.TabIndex = 158;
            this.picHelpCrowd.TabStop = false;
            this.ToolTip.SetToolTip(this.picHelpCrowd, "Click for help with Crowd Audio");
            this.picHelpCrowd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picHelp_MouseClick);
            // 
            // numericCrowd
            // 
            this.numericCrowd.BackColor = System.Drawing.Color.White;
            this.numericCrowd.DecimalPlaces = 1;
            this.numericCrowd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericCrowd.ForeColor = System.Drawing.Color.Black;
            this.numericCrowd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericCrowd.Location = new System.Drawing.Point(641, 438);
            this.numericCrowd.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericCrowd.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147418112});
            this.numericCrowd.Name = "numericCrowd";
            this.numericCrowd.Size = new System.Drawing.Size(46, 20);
            this.numericCrowd.TabIndex = 157;
            this.numericCrowd.Tag = "Audio - Crowd Attenuation";
            this.numericCrowd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.numericCrowd, "Use this to change the attenuation for the crowd track");
            this.numericCrowd.Value = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numericCrowd.Visible = false;
            this.numericCrowd.ValueChanged += new System.EventHandler(this.numericCrowd_ValueChanged);
            // 
            // LabelCrowdPan
            // 
            this.LabelCrowdPan.AutoSize = true;
            this.LabelCrowdPan.BackColor = System.Drawing.Color.Transparent;
            this.LabelCrowdPan.ForeColor = System.Drawing.Color.White;
            this.LabelCrowdPan.Location = new System.Drawing.Point(564, 440);
            this.LabelCrowdPan.Name = "LabelCrowdPan";
            this.LabelCrowdPan.Size = new System.Drawing.Size(38, 13);
            this.LabelCrowdPan.TabIndex = 156;
            this.LabelCrowdPan.Text = "Stereo";
            this.LabelCrowdPan.Visible = false;
            // 
            // ZeroBacking
            // 
            this.ZeroBacking.BackColor = System.Drawing.Color.Transparent;
            this.ZeroBacking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZeroBacking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZeroBacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroBacking.ForeColor = System.Drawing.Color.White;
            this.ZeroBacking.Location = new System.Drawing.Point(693, 399);
            this.ZeroBacking.Name = "ZeroBacking";
            this.ZeroBacking.Size = new System.Drawing.Size(45, 22);
            this.ZeroBacking.TabIndex = 155;
            this.ZeroBacking.Text = "Zero";
            this.ZeroBacking.UseVisualStyleBackColor = false;
            this.ZeroBacking.Visible = false;
            this.ZeroBacking.Click += new System.EventHandler(this.ZeroBacking_Click);
            // 
            // ZeroVocals
            // 
            this.ZeroVocals.BackColor = System.Drawing.Color.Transparent;
            this.ZeroVocals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZeroVocals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZeroVocals.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroVocals.ForeColor = System.Drawing.Color.White;
            this.ZeroVocals.Location = new System.Drawing.Point(693, 274);
            this.ZeroVocals.Name = "ZeroVocals";
            this.ZeroVocals.Size = new System.Drawing.Size(45, 22);
            this.ZeroVocals.TabIndex = 154;
            this.ZeroVocals.Text = "Zero";
            this.ZeroVocals.UseVisualStyleBackColor = false;
            this.ZeroVocals.Visible = false;
            this.ZeroVocals.Click += new System.EventHandler(this.ZeroVocals_Click);
            // 
            // ZeroKeys
            // 
            this.ZeroKeys.BackColor = System.Drawing.Color.Transparent;
            this.ZeroKeys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZeroKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZeroKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroKeys.ForeColor = System.Drawing.Color.White;
            this.ZeroKeys.Location = new System.Drawing.Point(693, 235);
            this.ZeroKeys.Name = "ZeroKeys";
            this.ZeroKeys.Size = new System.Drawing.Size(45, 22);
            this.ZeroKeys.TabIndex = 153;
            this.ZeroKeys.Text = "Zero";
            this.ZeroKeys.UseVisualStyleBackColor = false;
            this.ZeroKeys.Visible = false;
            this.ZeroKeys.Click += new System.EventHandler(this.ZeroKeys_Click);
            // 
            // ZeroGuitar
            // 
            this.ZeroGuitar.BackColor = System.Drawing.Color.Transparent;
            this.ZeroGuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZeroGuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZeroGuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroGuitar.ForeColor = System.Drawing.Color.White;
            this.ZeroGuitar.Location = new System.Drawing.Point(693, 196);
            this.ZeroGuitar.Name = "ZeroGuitar";
            this.ZeroGuitar.Size = new System.Drawing.Size(45, 22);
            this.ZeroGuitar.TabIndex = 152;
            this.ZeroGuitar.Text = "Zero";
            this.ZeroGuitar.UseVisualStyleBackColor = false;
            this.ZeroGuitar.Visible = false;
            this.ZeroGuitar.Click += new System.EventHandler(this.ZeroGuitar_Click);
            // 
            // ZeroBass
            // 
            this.ZeroBass.BackColor = System.Drawing.Color.Transparent;
            this.ZeroBass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZeroBass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZeroBass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroBass.ForeColor = System.Drawing.Color.White;
            this.ZeroBass.Location = new System.Drawing.Point(693, 157);
            this.ZeroBass.Name = "ZeroBass";
            this.ZeroBass.Size = new System.Drawing.Size(45, 22);
            this.ZeroBass.TabIndex = 151;
            this.ZeroBass.Text = "Zero";
            this.ZeroBass.UseVisualStyleBackColor = false;
            this.ZeroBass.Visible = false;
            this.ZeroBass.Click += new System.EventHandler(this.ZeroBass_Click);
            // 
            // ZeroDrumKick
            // 
            this.ZeroDrumKick.BackColor = System.Drawing.Color.Transparent;
            this.ZeroDrumKick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZeroDrumKick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZeroDrumKick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroDrumKick.ForeColor = System.Drawing.Color.White;
            this.ZeroDrumKick.Location = new System.Drawing.Point(693, 118);
            this.ZeroDrumKick.Name = "ZeroDrumKick";
            this.ZeroDrumKick.Size = new System.Drawing.Size(45, 22);
            this.ZeroDrumKick.TabIndex = 150;
            this.ZeroDrumKick.Text = "Zero";
            this.ZeroDrumKick.UseVisualStyleBackColor = false;
            this.ZeroDrumKick.Visible = false;
            this.ZeroDrumKick.Click += new System.EventHandler(this.ZeroDrumKick_Click);
            // 
            // ZeroDrumSnare
            // 
            this.ZeroDrumSnare.BackColor = System.Drawing.Color.Transparent;
            this.ZeroDrumSnare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZeroDrumSnare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZeroDrumSnare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroDrumSnare.ForeColor = System.Drawing.Color.White;
            this.ZeroDrumSnare.Location = new System.Drawing.Point(693, 89);
            this.ZeroDrumSnare.Name = "ZeroDrumSnare";
            this.ZeroDrumSnare.Size = new System.Drawing.Size(45, 22);
            this.ZeroDrumSnare.TabIndex = 149;
            this.ZeroDrumSnare.Text = "Zero";
            this.ZeroDrumSnare.UseVisualStyleBackColor = false;
            this.ZeroDrumSnare.Visible = false;
            this.ZeroDrumSnare.Click += new System.EventHandler(this.ZeroDrumSnare_Click);
            // 
            // ZeroDrumKit
            // 
            this.ZeroDrumKit.BackColor = System.Drawing.Color.Transparent;
            this.ZeroDrumKit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZeroDrumKit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZeroDrumKit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroDrumKit.ForeColor = System.Drawing.Color.White;
            this.ZeroDrumKit.Location = new System.Drawing.Point(693, 59);
            this.ZeroDrumKit.Name = "ZeroDrumKit";
            this.ZeroDrumKit.Size = new System.Drawing.Size(45, 22);
            this.ZeroDrumKit.TabIndex = 148;
            this.ZeroDrumKit.Text = "Zero";
            this.ZeroDrumKit.UseVisualStyleBackColor = false;
            this.ZeroDrumKit.Visible = false;
            this.ZeroDrumKit.Click += new System.EventHandler(this.ZeroDrumKit_Click);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.DarkGray;
            this.panel11.ForeColor = System.Drawing.Color.DimGray;
            this.panel11.Location = new System.Drawing.Point(16, 429);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(716, 1);
            this.panel11.TabIndex = 147;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.DarkGray;
            this.panel10.ForeColor = System.Drawing.Color.DimGray;
            this.panel10.Location = new System.Drawing.Point(16, 467);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(716, 1);
            this.panel10.TabIndex = 146;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.DarkGray;
            this.panel9.ForeColor = System.Drawing.Color.DimGray;
            this.panel9.Location = new System.Drawing.Point(16, 390);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(716, 1);
            this.panel9.TabIndex = 145;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DarkGray;
            this.panel8.ForeColor = System.Drawing.Color.DimGray;
            this.panel8.Location = new System.Drawing.Point(16, 266);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(716, 1);
            this.panel8.TabIndex = 143;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DarkGray;
            this.panel7.ForeColor = System.Drawing.Color.DimGray;
            this.panel7.Location = new System.Drawing.Point(16, 227);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(716, 1);
            this.panel7.TabIndex = 144;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkGray;
            this.panel6.ForeColor = System.Drawing.Color.DimGray;
            this.panel6.Location = new System.Drawing.Point(16, 188);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(716, 1);
            this.panel6.TabIndex = 143;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkGray;
            this.panel5.ForeColor = System.Drawing.Color.DimGray;
            this.panel5.Location = new System.Drawing.Point(16, 149);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(716, 1);
            this.panel5.TabIndex = 142;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(638, 10);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(86, 13);
            this.label30.TabIndex = 141;
            this.label30.Text = "ATTENUATION";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(568, 10);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(31, 13);
            this.label29.TabIndex = 140;
            this.label29.Text = "PAN";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumericBackingAttenuation
            // 
            this.NumericBackingAttenuation.BackColor = System.Drawing.Color.White;
            this.NumericBackingAttenuation.DecimalPlaces = 1;
            this.NumericBackingAttenuation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericBackingAttenuation.ForeColor = System.Drawing.Color.Black;
            this.NumericBackingAttenuation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericBackingAttenuation.Location = new System.Drawing.Point(641, 400);
            this.NumericBackingAttenuation.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NumericBackingAttenuation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147418112});
            this.NumericBackingAttenuation.Name = "NumericBackingAttenuation";
            this.NumericBackingAttenuation.Size = new System.Drawing.Size(46, 20);
            this.NumericBackingAttenuation.TabIndex = 139;
            this.NumericBackingAttenuation.Tag = "Audio - Backing Attenuation";
            this.NumericBackingAttenuation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.NumericBackingAttenuation, "Use this to change the attenuation for the backing track");
            this.NumericBackingAttenuation.Visible = false;
            this.NumericBackingAttenuation.ValueChanged += new System.EventHandler(this.NumericBackingAttenuation_ValueChanged);
            // 
            // NumericVocalAttenuation
            // 
            this.NumericVocalAttenuation.BackColor = System.Drawing.Color.White;
            this.NumericVocalAttenuation.DecimalPlaces = 1;
            this.NumericVocalAttenuation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericVocalAttenuation.ForeColor = System.Drawing.Color.Black;
            this.NumericVocalAttenuation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericVocalAttenuation.Location = new System.Drawing.Point(641, 275);
            this.NumericVocalAttenuation.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NumericVocalAttenuation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147418112});
            this.NumericVocalAttenuation.Name = "NumericVocalAttenuation";
            this.NumericVocalAttenuation.Size = new System.Drawing.Size(46, 20);
            this.NumericVocalAttenuation.TabIndex = 138;
            this.NumericVocalAttenuation.Tag = "Audio - Vocal Attenuation";
            this.NumericVocalAttenuation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.NumericVocalAttenuation, "Use this to change the attenuation for the vocals track");
            this.NumericVocalAttenuation.Visible = false;
            this.NumericVocalAttenuation.ValueChanged += new System.EventHandler(this.NumericVocalAttenuation_ValueChanged);
            // 
            // NumericKeysAttenuation
            // 
            this.NumericKeysAttenuation.BackColor = System.Drawing.Color.White;
            this.NumericKeysAttenuation.DecimalPlaces = 1;
            this.NumericKeysAttenuation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericKeysAttenuation.ForeColor = System.Drawing.Color.Black;
            this.NumericKeysAttenuation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericKeysAttenuation.Location = new System.Drawing.Point(641, 235);
            this.NumericKeysAttenuation.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NumericKeysAttenuation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147418112});
            this.NumericKeysAttenuation.Name = "NumericKeysAttenuation";
            this.NumericKeysAttenuation.Size = new System.Drawing.Size(46, 20);
            this.NumericKeysAttenuation.TabIndex = 137;
            this.NumericKeysAttenuation.Tag = "Audio - Keys Attenuation";
            this.NumericKeysAttenuation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.NumericKeysAttenuation, "Use this to change the attenuation for the keys track");
            this.NumericKeysAttenuation.Visible = false;
            this.NumericKeysAttenuation.ValueChanged += new System.EventHandler(this.NumericKeysAttenuation_ValueChanged);
            // 
            // NumericGuitarAttenuation
            // 
            this.NumericGuitarAttenuation.BackColor = System.Drawing.Color.White;
            this.NumericGuitarAttenuation.DecimalPlaces = 1;
            this.NumericGuitarAttenuation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericGuitarAttenuation.ForeColor = System.Drawing.Color.Black;
            this.NumericGuitarAttenuation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericGuitarAttenuation.Location = new System.Drawing.Point(641, 197);
            this.NumericGuitarAttenuation.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NumericGuitarAttenuation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147418112});
            this.NumericGuitarAttenuation.Name = "NumericGuitarAttenuation";
            this.NumericGuitarAttenuation.Size = new System.Drawing.Size(46, 20);
            this.NumericGuitarAttenuation.TabIndex = 136;
            this.NumericGuitarAttenuation.Tag = "Audio - Guitar Attenuation";
            this.NumericGuitarAttenuation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.NumericGuitarAttenuation, "Use this to change the attenuation for the guitar track");
            this.NumericGuitarAttenuation.Visible = false;
            this.NumericGuitarAttenuation.ValueChanged += new System.EventHandler(this.NumericGuitarAttenuation_ValueChanged);
            // 
            // NumericBassAttenuation
            // 
            this.NumericBassAttenuation.BackColor = System.Drawing.Color.White;
            this.NumericBassAttenuation.DecimalPlaces = 1;
            this.NumericBassAttenuation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericBassAttenuation.ForeColor = System.Drawing.Color.Black;
            this.NumericBassAttenuation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericBassAttenuation.Location = new System.Drawing.Point(641, 158);
            this.NumericBassAttenuation.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NumericBassAttenuation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147418112});
            this.NumericBassAttenuation.Name = "NumericBassAttenuation";
            this.NumericBassAttenuation.Size = new System.Drawing.Size(46, 20);
            this.NumericBassAttenuation.TabIndex = 135;
            this.NumericBassAttenuation.Tag = "Audio - Bass Attenuation";
            this.NumericBassAttenuation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.NumericBassAttenuation, "Use this to change the attenuation for the bass track");
            this.NumericBassAttenuation.Visible = false;
            this.NumericBassAttenuation.ValueChanged += new System.EventHandler(this.NumericBassAttenuation_ValueChanged);
            // 
            // NumericDrumSnareAttenuation
            // 
            this.NumericDrumSnareAttenuation.BackColor = System.Drawing.Color.White;
            this.NumericDrumSnareAttenuation.DecimalPlaces = 1;
            this.NumericDrumSnareAttenuation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericDrumSnareAttenuation.ForeColor = System.Drawing.Color.Black;
            this.NumericDrumSnareAttenuation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericDrumSnareAttenuation.Location = new System.Drawing.Point(641, 89);
            this.NumericDrumSnareAttenuation.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NumericDrumSnareAttenuation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147418112});
            this.NumericDrumSnareAttenuation.Name = "NumericDrumSnareAttenuation";
            this.NumericDrumSnareAttenuation.Size = new System.Drawing.Size(46, 20);
            this.NumericDrumSnareAttenuation.TabIndex = 133;
            this.NumericDrumSnareAttenuation.Tag = "Audio - Drum Snare Attenuation";
            this.NumericDrumSnareAttenuation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.NumericDrumSnareAttenuation, "Use this to change the attenuation for the drum snare track");
            this.NumericDrumSnareAttenuation.Visible = false;
            this.NumericDrumSnareAttenuation.ValueChanged += new System.EventHandler(this.NumericDrumSnareAttenuation_ValueChanged);
            // 
            // NumericDrumKickAttenuation
            // 
            this.NumericDrumKickAttenuation.BackColor = System.Drawing.Color.White;
            this.NumericDrumKickAttenuation.DecimalPlaces = 1;
            this.NumericDrumKickAttenuation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericDrumKickAttenuation.ForeColor = System.Drawing.Color.Black;
            this.NumericDrumKickAttenuation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericDrumKickAttenuation.Location = new System.Drawing.Point(641, 118);
            this.NumericDrumKickAttenuation.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NumericDrumKickAttenuation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147418112});
            this.NumericDrumKickAttenuation.Name = "NumericDrumKickAttenuation";
            this.NumericDrumKickAttenuation.Size = new System.Drawing.Size(46, 20);
            this.NumericDrumKickAttenuation.TabIndex = 134;
            this.NumericDrumKickAttenuation.Tag = "Audio - Drum Kick Attenuation";
            this.NumericDrumKickAttenuation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.NumericDrumKickAttenuation, "Use this to change the attenuation for the drum kick track");
            this.NumericDrumKickAttenuation.Visible = false;
            this.NumericDrumKickAttenuation.ValueChanged += new System.EventHandler(this.NumericDrumKickAttenuation_ValueChanged);
            // 
            // NumericDrumKitAttenuation
            // 
            this.NumericDrumKitAttenuation.BackColor = System.Drawing.Color.White;
            this.NumericDrumKitAttenuation.DecimalPlaces = 1;
            this.NumericDrumKitAttenuation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericDrumKitAttenuation.ForeColor = System.Drawing.Color.Black;
            this.NumericDrumKitAttenuation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericDrumKitAttenuation.Location = new System.Drawing.Point(641, 60);
            this.NumericDrumKitAttenuation.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NumericDrumKitAttenuation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147418112});
            this.NumericDrumKitAttenuation.Name = "NumericDrumKitAttenuation";
            this.NumericDrumKitAttenuation.Size = new System.Drawing.Size(46, 20);
            this.NumericDrumKitAttenuation.TabIndex = 132;
            this.NumericDrumKitAttenuation.Tag = "Audio - Drum Kit Attenuation";
            this.NumericDrumKitAttenuation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.NumericDrumKitAttenuation, "Use this to change the attenuation for the drum kit track");
            this.NumericDrumKitAttenuation.Visible = false;
            this.NumericDrumKitAttenuation.ValueChanged += new System.EventHandler(this.NumericDrumKitAttenuation_ValueChanged);
            // 
            // LabelBackingPan
            // 
            this.LabelBackingPan.AutoSize = true;
            this.LabelBackingPan.BackColor = System.Drawing.Color.Transparent;
            this.LabelBackingPan.ForeColor = System.Drawing.Color.White;
            this.LabelBackingPan.Location = new System.Drawing.Point(564, 402);
            this.LabelBackingPan.Name = "LabelBackingPan";
            this.LabelBackingPan.Size = new System.Drawing.Size(38, 13);
            this.LabelBackingPan.TabIndex = 128;
            this.LabelBackingPan.Text = "Stereo";
            this.LabelBackingPan.Visible = false;
            // 
            // NumericBackingPan
            // 
            this.NumericBackingPan.DecimalPlaces = 1;
            this.NumericBackingPan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericBackingPan.ForeColor = System.Drawing.Color.Black;
            this.NumericBackingPan.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericBackingPan.Location = new System.Drawing.Point(561, 398);
            this.NumericBackingPan.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.NumericBackingPan.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.NumericBackingPan.Name = "NumericBackingPan";
            this.NumericBackingPan.Size = new System.Drawing.Size(46, 20);
            this.NumericBackingPan.TabIndex = 129;
            this.NumericBackingPan.Tag = "Audio - Backing Pan";
            this.NumericBackingPan.Visible = false;
            this.NumericBackingPan.ValueChanged += new System.EventHandler(this.NumericBackingPan_ValueChanged);
            // 
            // LabelVocalPan
            // 
            this.LabelVocalPan.AutoSize = true;
            this.LabelVocalPan.BackColor = System.Drawing.Color.Transparent;
            this.LabelVocalPan.ForeColor = System.Drawing.Color.White;
            this.LabelVocalPan.Location = new System.Drawing.Point(564, 279);
            this.LabelVocalPan.Name = "LabelVocalPan";
            this.LabelVocalPan.Size = new System.Drawing.Size(38, 13);
            this.LabelVocalPan.TabIndex = 126;
            this.LabelVocalPan.Text = "Stereo";
            this.LabelVocalPan.Visible = false;
            // 
            // NumericVocalPan
            // 
            this.NumericVocalPan.DecimalPlaces = 1;
            this.NumericVocalPan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericVocalPan.ForeColor = System.Drawing.Color.Black;
            this.NumericVocalPan.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericVocalPan.Location = new System.Drawing.Point(561, 275);
            this.NumericVocalPan.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.NumericVocalPan.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.NumericVocalPan.Name = "NumericVocalPan";
            this.NumericVocalPan.Size = new System.Drawing.Size(46, 20);
            this.NumericVocalPan.TabIndex = 127;
            this.NumericVocalPan.Tag = "Audio - Vocal Pan";
            this.NumericVocalPan.Visible = false;
            this.NumericVocalPan.ValueChanged += new System.EventHandler(this.NumericVocalPan_ValueChanged);
            // 
            // LabelKeysPan
            // 
            this.LabelKeysPan.AutoSize = true;
            this.LabelKeysPan.BackColor = System.Drawing.Color.Transparent;
            this.LabelKeysPan.ForeColor = System.Drawing.Color.White;
            this.LabelKeysPan.Location = new System.Drawing.Point(564, 240);
            this.LabelKeysPan.Name = "LabelKeysPan";
            this.LabelKeysPan.Size = new System.Drawing.Size(38, 13);
            this.LabelKeysPan.TabIndex = 124;
            this.LabelKeysPan.Text = "Stereo";
            this.LabelKeysPan.Visible = false;
            // 
            // NumericKeysPan
            // 
            this.NumericKeysPan.DecimalPlaces = 1;
            this.NumericKeysPan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericKeysPan.ForeColor = System.Drawing.Color.Black;
            this.NumericKeysPan.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericKeysPan.Location = new System.Drawing.Point(561, 236);
            this.NumericKeysPan.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.NumericKeysPan.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.NumericKeysPan.Name = "NumericKeysPan";
            this.NumericKeysPan.Size = new System.Drawing.Size(46, 20);
            this.NumericKeysPan.TabIndex = 125;
            this.NumericKeysPan.Tag = "Audio - Keys Pan";
            this.NumericKeysPan.Visible = false;
            this.NumericKeysPan.ValueChanged += new System.EventHandler(this.NumericKeysPan_ValueChanged);
            // 
            // LabelGuitarPan
            // 
            this.LabelGuitarPan.AutoSize = true;
            this.LabelGuitarPan.BackColor = System.Drawing.Color.Transparent;
            this.LabelGuitarPan.ForeColor = System.Drawing.Color.White;
            this.LabelGuitarPan.Location = new System.Drawing.Point(564, 202);
            this.LabelGuitarPan.Name = "LabelGuitarPan";
            this.LabelGuitarPan.Size = new System.Drawing.Size(38, 13);
            this.LabelGuitarPan.TabIndex = 122;
            this.LabelGuitarPan.Text = "Stereo";
            this.LabelGuitarPan.Visible = false;
            // 
            // NumericGuitarPan
            // 
            this.NumericGuitarPan.DecimalPlaces = 1;
            this.NumericGuitarPan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericGuitarPan.ForeColor = System.Drawing.Color.Black;
            this.NumericGuitarPan.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericGuitarPan.Location = new System.Drawing.Point(563, 198);
            this.NumericGuitarPan.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.NumericGuitarPan.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.NumericGuitarPan.Name = "NumericGuitarPan";
            this.NumericGuitarPan.Size = new System.Drawing.Size(46, 20);
            this.NumericGuitarPan.TabIndex = 123;
            this.NumericGuitarPan.Tag = "Audio - Guitar Pan";
            this.NumericGuitarPan.Visible = false;
            this.NumericGuitarPan.ValueChanged += new System.EventHandler(this.NumericGuitarPan_ValueChanged);
            // 
            // LabelBassPan
            // 
            this.LabelBassPan.AutoSize = true;
            this.LabelBassPan.BackColor = System.Drawing.Color.Transparent;
            this.LabelBassPan.ForeColor = System.Drawing.Color.White;
            this.LabelBassPan.Location = new System.Drawing.Point(564, 162);
            this.LabelBassPan.Name = "LabelBassPan";
            this.LabelBassPan.Size = new System.Drawing.Size(38, 13);
            this.LabelBassPan.TabIndex = 120;
            this.LabelBassPan.Text = "Stereo";
            this.LabelBassPan.Visible = false;
            // 
            // NumericBassPan
            // 
            this.NumericBassPan.DecimalPlaces = 1;
            this.NumericBassPan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericBassPan.ForeColor = System.Drawing.Color.Black;
            this.NumericBassPan.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericBassPan.Location = new System.Drawing.Point(561, 158);
            this.NumericBassPan.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.NumericBassPan.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.NumericBassPan.Name = "NumericBassPan";
            this.NumericBassPan.Size = new System.Drawing.Size(46, 20);
            this.NumericBassPan.TabIndex = 121;
            this.NumericBassPan.Tag = "Audio - Bass Pan";
            this.NumericBassPan.Visible = false;
            this.NumericBassPan.ValueChanged += new System.EventHandler(this.NumericBassPan_ValueChanged);
            // 
            // LabelDrumSnarePan
            // 
            this.LabelDrumSnarePan.AutoSize = true;
            this.LabelDrumSnarePan.BackColor = System.Drawing.Color.Transparent;
            this.LabelDrumSnarePan.ForeColor = System.Drawing.Color.White;
            this.LabelDrumSnarePan.Location = new System.Drawing.Point(564, 94);
            this.LabelDrumSnarePan.Name = "LabelDrumSnarePan";
            this.LabelDrumSnarePan.Size = new System.Drawing.Size(38, 13);
            this.LabelDrumSnarePan.TabIndex = 117;
            this.LabelDrumSnarePan.Text = "Stereo";
            this.LabelDrumSnarePan.Visible = false;
            this.LabelDrumSnarePan.VisibleChanged += new System.EventHandler(this.LabelDrumKitPan_VisibleChanged);
            // 
            // LabelDrumKickPan
            // 
            this.LabelDrumKickPan.AutoSize = true;
            this.LabelDrumKickPan.BackColor = System.Drawing.Color.Transparent;
            this.LabelDrumKickPan.ForeColor = System.Drawing.Color.White;
            this.LabelDrumKickPan.Location = new System.Drawing.Point(564, 123);
            this.LabelDrumKickPan.Name = "LabelDrumKickPan";
            this.LabelDrumKickPan.Size = new System.Drawing.Size(38, 13);
            this.LabelDrumKickPan.TabIndex = 115;
            this.LabelDrumKickPan.Text = "Stereo";
            this.LabelDrumKickPan.Visible = false;
            this.LabelDrumKickPan.VisibleChanged += new System.EventHandler(this.LabelDrumKitPan_VisibleChanged);
            // 
            // LabelDrumKitPan
            // 
            this.LabelDrumKitPan.AutoSize = true;
            this.LabelDrumKitPan.BackColor = System.Drawing.Color.Transparent;
            this.LabelDrumKitPan.ForeColor = System.Drawing.Color.White;
            this.LabelDrumKitPan.Location = new System.Drawing.Point(564, 65);
            this.LabelDrumKitPan.Name = "LabelDrumKitPan";
            this.LabelDrumKitPan.Size = new System.Drawing.Size(38, 13);
            this.LabelDrumKitPan.TabIndex = 114;
            this.LabelDrumKitPan.Text = "Stereo";
            this.LabelDrumKitPan.Visible = false;
            this.LabelDrumKitPan.VisibleChanged += new System.EventHandler(this.LabelDrumKitPan_VisibleChanged);
            // 
            // NumericDrumSnarePan
            // 
            this.NumericDrumSnarePan.DecimalPlaces = 1;
            this.NumericDrumSnarePan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericDrumSnarePan.ForeColor = System.Drawing.Color.Black;
            this.NumericDrumSnarePan.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericDrumSnarePan.Location = new System.Drawing.Point(561, 90);
            this.NumericDrumSnarePan.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.NumericDrumSnarePan.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.NumericDrumSnarePan.Name = "NumericDrumSnarePan";
            this.NumericDrumSnarePan.Size = new System.Drawing.Size(46, 20);
            this.NumericDrumSnarePan.TabIndex = 118;
            this.NumericDrumSnarePan.Tag = "Audio - Drum Snare Pan";
            this.NumericDrumSnarePan.Visible = false;
            this.NumericDrumSnarePan.ValueChanged += new System.EventHandler(this.NumericDrumSnarePan_ValueChanged);
            // 
            // NumericDrumKickPan
            // 
            this.NumericDrumKickPan.DecimalPlaces = 1;
            this.NumericDrumKickPan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericDrumKickPan.ForeColor = System.Drawing.Color.Black;
            this.NumericDrumKickPan.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericDrumKickPan.Location = new System.Drawing.Point(561, 119);
            this.NumericDrumKickPan.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.NumericDrumKickPan.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.NumericDrumKickPan.Name = "NumericDrumKickPan";
            this.NumericDrumKickPan.Size = new System.Drawing.Size(46, 20);
            this.NumericDrumKickPan.TabIndex = 119;
            this.NumericDrumKickPan.Tag = "Audio - Drum Kick Pan";
            this.NumericDrumKickPan.Visible = false;
            this.NumericDrumKickPan.ValueChanged += new System.EventHandler(this.NumericDrumKickPan_ValueChanged);
            // 
            // NumericDrumKitPan
            // 
            this.NumericDrumKitPan.DecimalPlaces = 1;
            this.NumericDrumKitPan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericDrumKitPan.ForeColor = System.Drawing.Color.Black;
            this.NumericDrumKitPan.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericDrumKitPan.Location = new System.Drawing.Point(561, 61);
            this.NumericDrumKitPan.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.NumericDrumKitPan.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
            this.NumericDrumKitPan.Name = "NumericDrumKitPan";
            this.NumericDrumKitPan.Size = new System.Drawing.Size(46, 20);
            this.NumericDrumKitPan.TabIndex = 116;
            this.NumericDrumKitPan.Tag = "Audio - Drum Kit Pan";
            this.NumericDrumKitPan.Visible = false;
            this.NumericDrumKitPan.ValueChanged += new System.EventHandler(this.NumericDrumKitPan_ValueChanged);
            // 
            // ButtonBacking
            // 
            this.ButtonBacking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.ButtonBacking.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonBacking.BackgroundImage")));
            this.ButtonBacking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonBacking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonBacking.FlatAppearance.BorderSize = 0;
            this.ButtonBacking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonBacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBacking.ForeColor = System.Drawing.Color.White;
            this.ButtonBacking.Location = new System.Drawing.Point(480, 398);
            this.ButtonBacking.Name = "ButtonBacking";
            this.ButtonBacking.Size = new System.Drawing.Size(28, 22);
            this.ButtonBacking.TabIndex = 113;
            this.ButtonBacking.Text = "...";
            this.ToolTip.SetToolTip(this.ButtonBacking, "Click to browse for the backing track");
            this.ButtonBacking.UseVisualStyleBackColor = false;
            this.ButtonBacking.Visible = false;
            this.ButtonBacking.Click += new System.EventHandler(this.ButtonBacking_Click);
            // 
            // TextBoxBacking
            // 
            this.TextBoxBacking.AllowDrop = true;
            this.TextBoxBacking.ContextMenuStrip = this.contextMenuStrip2;
            this.TextBoxBacking.Enabled = false;
            this.TextBoxBacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxBacking.ForeColor = System.Drawing.Color.Black;
            this.TextBoxBacking.Location = new System.Drawing.Point(168, 400);
            this.TextBoxBacking.MaxLength = 250;
            this.TextBoxBacking.Name = "TextBoxBacking";
            this.TextBoxBacking.Size = new System.Drawing.Size(304, 20);
            this.TextBoxBacking.TabIndex = 112;
            this.TextBoxBacking.Tag = "Audio - Backing";
            this.ToolTip.SetToolTip(this.TextBoxBacking, "This is the location of your backing audio track");
            this.TextBoxBacking.EnabledChanged += new System.EventHandler(this.TextBoxBacking_EnabledChanged);
            this.TextBoxBacking.TextChanged += new System.EventHandler(this.TextBoxBacking_TextChanged);
            this.TextBoxBacking.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBoxes_DragDrop);
            this.TextBoxBacking.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.TextBoxBacking.MouseEnter += new System.EventHandler(this.TextBoxDrumKit_MouseEnter);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem7,
            this.Mono44SilenceToolStripMenuItem,
            this.Stereo44SilenceToolStripMenuItem,
            this.Mono48SilenceToolStripMenuItem,
            this.Stereo48SilenceToolStripMenuItem,
            this.toolStripMenuItem10,
            this.Mono44Silence24,
            this.Stereo44Silence24,
            this.Mono48Silence24,
            this.Stereo48Silence24,
            this.toolStripMenuItem5,
            this.blankDryvoxFileToolStripMenuItem,
            this.copyLeadDryVocalsHere,
            this.convertVocalsStemToDryvox,
            this.selectAudioFile});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(252, 352);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.clearToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.copyToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.pasteToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(248, 6);
            // 
            // Mono44SilenceToolStripMenuItem
            // 
            this.Mono44SilenceToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.Mono44SilenceToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.Mono44SilenceToolStripMenuItem.Name = "Mono44SilenceToolStripMenuItem";
            this.Mono44SilenceToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.Mono44SilenceToolStripMenuItem.Text = "44.1 kHz mono silence";
            this.Mono44SilenceToolStripMenuItem.Click += new System.EventHandler(this.Mono44SilenceToolStripMenuItem_Click);
            // 
            // Stereo44SilenceToolStripMenuItem
            // 
            this.Stereo44SilenceToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.Stereo44SilenceToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.Stereo44SilenceToolStripMenuItem.Name = "Stereo44SilenceToolStripMenuItem";
            this.Stereo44SilenceToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.Stereo44SilenceToolStripMenuItem.Text = "44.1 kHz stereo silence";
            this.Stereo44SilenceToolStripMenuItem.Click += new System.EventHandler(this.Stereo44SilenceToolStripMenuItem_Click);
            // 
            // Mono48SilenceToolStripMenuItem
            // 
            this.Mono48SilenceToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.Mono48SilenceToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.Mono48SilenceToolStripMenuItem.Name = "Mono48SilenceToolStripMenuItem";
            this.Mono48SilenceToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.Mono48SilenceToolStripMenuItem.Text = "48 kHz mono silence";
            this.Mono48SilenceToolStripMenuItem.Click += new System.EventHandler(this.Mono48SilenceToolStripMenuItem_Click);
            // 
            // Stereo48SilenceToolStripMenuItem
            // 
            this.Stereo48SilenceToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.Stereo48SilenceToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.Stereo48SilenceToolStripMenuItem.Name = "Stereo48SilenceToolStripMenuItem";
            this.Stereo48SilenceToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.Stereo48SilenceToolStripMenuItem.Text = "48 kHz stereo silence";
            this.Stereo48SilenceToolStripMenuItem.Click += new System.EventHandler(this.Stereo48SilenceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(248, 6);
            // 
            // Mono44Silence24
            // 
            this.Mono44Silence24.BackColor = System.Drawing.Color.Black;
            this.Mono44Silence24.ForeColor = System.Drawing.Color.LightGray;
            this.Mono44Silence24.Name = "Mono44Silence24";
            this.Mono44Silence24.Size = new System.Drawing.Size(251, 22);
            this.Mono44Silence24.Text = "44.1 kHz mono silence (24-bit)";
            this.Mono44Silence24.Click += new System.EventHandler(this.Mono44Silence24_Click);
            // 
            // Stereo44Silence24
            // 
            this.Stereo44Silence24.BackColor = System.Drawing.Color.Black;
            this.Stereo44Silence24.ForeColor = System.Drawing.Color.LightGray;
            this.Stereo44Silence24.Name = "Stereo44Silence24";
            this.Stereo44Silence24.Size = new System.Drawing.Size(251, 22);
            this.Stereo44Silence24.Text = "44.1 kHz stereo silence (24-bit)";
            this.Stereo44Silence24.Click += new System.EventHandler(this.Stereo44Silence24_Click);
            // 
            // Mono48Silence24
            // 
            this.Mono48Silence24.BackColor = System.Drawing.Color.Black;
            this.Mono48Silence24.ForeColor = System.Drawing.Color.LightGray;
            this.Mono48Silence24.Name = "Mono48Silence24";
            this.Mono48Silence24.Size = new System.Drawing.Size(251, 22);
            this.Mono48Silence24.Text = "48 kHz mono silence (24-bit)";
            this.Mono48Silence24.Click += new System.EventHandler(this.Mono48Silence24_Click);
            // 
            // Stereo48Silence24
            // 
            this.Stereo48Silence24.BackColor = System.Drawing.Color.Black;
            this.Stereo48Silence24.ForeColor = System.Drawing.Color.LightGray;
            this.Stereo48Silence24.Name = "Stereo48Silence24";
            this.Stereo48Silence24.Size = new System.Drawing.Size(251, 22);
            this.Stereo48Silence24.Text = "48 kHz stereo silence (24-bit)";
            this.Stereo48Silence24.Click += new System.EventHandler(this.Stereo48Silence24_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(248, 6);
            // 
            // blankDryvoxFileToolStripMenuItem
            // 
            this.blankDryvoxFileToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.blankDryvoxFileToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.blankDryvoxFileToolStripMenuItem.Name = "blankDryvoxFileToolStripMenuItem";
            this.blankDryvoxFileToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.blankDryvoxFileToolStripMenuItem.Text = "Blank dryvox";
            this.blankDryvoxFileToolStripMenuItem.Click += new System.EventHandler(this.blankDryvoxFileToolStripMenuItem_Click);
            // 
            // copyLeadDryVocalsHere
            // 
            this.copyLeadDryVocalsHere.BackColor = System.Drawing.Color.Black;
            this.copyLeadDryVocalsHere.ForeColor = System.Drawing.Color.LightGray;
            this.copyLeadDryVocalsHere.Name = "copyLeadDryVocalsHere";
            this.copyLeadDryVocalsHere.Size = new System.Drawing.Size(251, 22);
            this.copyLeadDryVocalsHere.Text = "Copy lead dry vocals here";
            this.copyLeadDryVocalsHere.Click += new System.EventHandler(this.copyLeadDryVocalsHere_Click);
            // 
            // convertVocalsStemToDryvox
            // 
            this.convertVocalsStemToDryvox.BackColor = System.Drawing.Color.Black;
            this.convertVocalsStemToDryvox.ForeColor = System.Drawing.Color.LightGray;
            this.convertVocalsStemToDryvox.Name = "convertVocalsStemToDryvox";
            this.convertVocalsStemToDryvox.Size = new System.Drawing.Size(251, 22);
            this.convertVocalsStemToDryvox.Text = "Convert vocals stem to dryvox";
            this.convertVocalsStemToDryvox.Click += new System.EventHandler(this.convertVocalsStemToDryvox_Click);
            // 
            // selectAudioFile
            // 
            this.selectAudioFile.BackColor = System.Drawing.Color.Black;
            this.selectAudioFile.ForeColor = System.Drawing.Color.LightGray;
            this.selectAudioFile.Name = "selectAudioFile";
            this.selectAudioFile.Size = new System.Drawing.Size(251, 22);
            this.selectAudioFile.Text = "Select audio file...";
            this.selectAudioFile.Click += new System.EventHandler(this.selectAudioFile_Click);
            // 
            // LabelBacking
            // 
            this.LabelBacking.BackColor = System.Drawing.Color.Transparent;
            this.LabelBacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBacking.ForeColor = System.Drawing.Color.LightGray;
            this.LabelBacking.Location = new System.Drawing.Point(35, 404);
            this.LabelBacking.Name = "LabelBacking";
            this.LabelBacking.Size = new System.Drawing.Size(126, 13);
            this.LabelBacking.TabIndex = 110;
            this.LabelBacking.Text = "BACKING";
            this.LabelBacking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckBacking
            // 
            this.CheckBacking.AutoSize = true;
            this.CheckBacking.BackColor = System.Drawing.Color.Transparent;
            this.CheckBacking.Checked = true;
            this.CheckBacking.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBacking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBacking.Location = new System.Drawing.Point(16, 402);
            this.CheckBacking.Name = "CheckBacking";
            this.CheckBacking.Size = new System.Drawing.Size(15, 14);
            this.CheckBacking.TabIndex = 111;
            this.ToolTip.SetToolTip(this.CheckBacking, "Click here to enable a backing track for this song");
            this.CheckBacking.UseVisualStyleBackColor = false;
            this.CheckBacking.CheckedChanged += new System.EventHandler(this.CheckBacking_CheckedChanged);
            // 
            // CheckHarmonyVocals3
            // 
            this.CheckHarmonyVocals3.AutoSize = true;
            this.CheckHarmonyVocals3.BackColor = System.Drawing.Color.Transparent;
            this.CheckHarmonyVocals3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckHarmonyVocals3.Enabled = false;
            this.CheckHarmonyVocals3.Location = new System.Drawing.Point(16, 364);
            this.CheckHarmonyVocals3.Name = "CheckHarmonyVocals3";
            this.CheckHarmonyVocals3.Size = new System.Drawing.Size(15, 14);
            this.CheckHarmonyVocals3.TabIndex = 109;
            this.ToolTip.SetToolTip(this.CheckHarmonyVocals3, "Click here to enable a third harmony track for this song");
            this.CheckHarmonyVocals3.UseVisualStyleBackColor = false;
            this.CheckHarmonyVocals3.CheckedChanged += new System.EventHandler(this.CheckHarmonyVocals3_CheckedChanged);
            // 
            // LabelDryVocalsHarmony3
            // 
            this.LabelDryVocalsHarmony3.BackColor = System.Drawing.Color.Transparent;
            this.LabelDryVocalsHarmony3.ForeColor = System.Drawing.Color.LightGray;
            this.LabelDryVocalsHarmony3.Location = new System.Drawing.Point(35, 366);
            this.LabelDryVocalsHarmony3.Name = "LabelDryVocalsHarmony3";
            this.LabelDryVocalsHarmony3.Size = new System.Drawing.Size(126, 13);
            this.LabelDryVocalsHarmony3.TabIndex = 108;
            this.LabelDryVocalsHarmony3.Text = "HARMONY 3 Dry Vocals";
            this.LabelDryVocalsHarmony3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ButtonDryVocalsHarmony3
            // 
            this.ButtonDryVocalsHarmony3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(75)))), ((int)(((byte)(88)))));
            this.ButtonDryVocalsHarmony3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonDryVocalsHarmony3.BackgroundImage")));
            this.ButtonDryVocalsHarmony3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDryVocalsHarmony3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDryVocalsHarmony3.FlatAppearance.BorderSize = 0;
            this.ButtonDryVocalsHarmony3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDryVocalsHarmony3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDryVocalsHarmony3.ForeColor = System.Drawing.Color.White;
            this.ButtonDryVocalsHarmony3.Location = new System.Drawing.Point(480, 360);
            this.ButtonDryVocalsHarmony3.Name = "ButtonDryVocalsHarmony3";
            this.ButtonDryVocalsHarmony3.Size = new System.Drawing.Size(28, 22);
            this.ButtonDryVocalsHarmony3.TabIndex = 106;
            this.ButtonDryVocalsHarmony3.Text = "...";
            this.ToolTip.SetToolTip(this.ButtonDryVocalsHarmony3, "Click to browse for the third harmony dryvox file");
            this.ButtonDryVocalsHarmony3.UseVisualStyleBackColor = false;
            this.ButtonDryVocalsHarmony3.Visible = false;
            this.ButtonDryVocalsHarmony3.Click += new System.EventHandler(this.ButtonDryVocalsHarmony3_Click);
            // 
            // TextBoxDryVocalsHarmony3
            // 
            this.TextBoxDryVocalsHarmony3.AllowDrop = true;
            this.TextBoxDryVocalsHarmony3.ContextMenuStrip = this.contextMenuStrip2;
            this.TextBoxDryVocalsHarmony3.Enabled = false;
            this.TextBoxDryVocalsHarmony3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDryVocalsHarmony3.ForeColor = System.Drawing.Color.Black;
            this.TextBoxDryVocalsHarmony3.Location = new System.Drawing.Point(168, 362);
            this.TextBoxDryVocalsHarmony3.MaxLength = 250;
            this.TextBoxDryVocalsHarmony3.Name = "TextBoxDryVocalsHarmony3";
            this.TextBoxDryVocalsHarmony3.Size = new System.Drawing.Size(304, 20);
            this.TextBoxDryVocalsHarmony3.TabIndex = 107;
            this.TextBoxDryVocalsHarmony3.Tag = "Audio - Harmony 3 Dry Vocals";
            this.ToolTip.SetToolTip(this.TextBoxDryVocalsHarmony3, "This is the location of your third harmony dryvox file");
            this.TextBoxDryVocalsHarmony3.EnabledChanged += new System.EventHandler(this.TextBoxDryVocalsHarmony3_EnabledChanged);
            this.TextBoxDryVocalsHarmony3.TextChanged += new System.EventHandler(this.TextBoxDryVocals_TextChanged);
            this.TextBoxDryVocalsHarmony3.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBoxes_DragDrop);
            this.TextBoxDryVocalsHarmony3.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.TextBoxDryVocalsHarmony3.MouseEnter += new System.EventHandler(this.TextBoxDrumKit_MouseEnter);
            // 
            // CheckHarmonyVocals2
            // 
            this.CheckHarmonyVocals2.AutoSize = true;
            this.CheckHarmonyVocals2.BackColor = System.Drawing.Color.Transparent;
            this.CheckHarmonyVocals2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckHarmonyVocals2.Enabled = false;
            this.CheckHarmonyVocals2.Location = new System.Drawing.Point(16, 335);
            this.CheckHarmonyVocals2.Name = "CheckHarmonyVocals2";
            this.CheckHarmonyVocals2.Size = new System.Drawing.Size(15, 14);
            this.CheckHarmonyVocals2.TabIndex = 105;
            this.ToolTip.SetToolTip(this.CheckHarmonyVocals2, "Click here to enable a second harmony track for this song");
            this.CheckHarmonyVocals2.UseVisualStyleBackColor = false;
            this.CheckHarmonyVocals2.CheckedChanged += new System.EventHandler(this.CheckHarmonyVocals2_CheckedChanged);
            // 
            // LabelDryVocalsHarmony2
            // 
            this.LabelDryVocalsHarmony2.BackColor = System.Drawing.Color.Transparent;
            this.LabelDryVocalsHarmony2.ForeColor = System.Drawing.Color.LightGray;
            this.LabelDryVocalsHarmony2.Location = new System.Drawing.Point(35, 337);
            this.LabelDryVocalsHarmony2.Name = "LabelDryVocalsHarmony2";
            this.LabelDryVocalsHarmony2.Size = new System.Drawing.Size(126, 13);
            this.LabelDryVocalsHarmony2.TabIndex = 104;
            this.LabelDryVocalsHarmony2.Text = "HARMONY 2 Dry Vocals";
            this.LabelDryVocalsHarmony2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ButtonDryVocalsHarmony2
            // 
            this.ButtonDryVocalsHarmony2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(73)))), ((int)(((byte)(84)))));
            this.ButtonDryVocalsHarmony2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonDryVocalsHarmony2.BackgroundImage")));
            this.ButtonDryVocalsHarmony2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDryVocalsHarmony2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDryVocalsHarmony2.FlatAppearance.BorderSize = 0;
            this.ButtonDryVocalsHarmony2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDryVocalsHarmony2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDryVocalsHarmony2.ForeColor = System.Drawing.Color.White;
            this.ButtonDryVocalsHarmony2.Location = new System.Drawing.Point(480, 331);
            this.ButtonDryVocalsHarmony2.Name = "ButtonDryVocalsHarmony2";
            this.ButtonDryVocalsHarmony2.Size = new System.Drawing.Size(28, 22);
            this.ButtonDryVocalsHarmony2.TabIndex = 102;
            this.ButtonDryVocalsHarmony2.Text = "...";
            this.ToolTip.SetToolTip(this.ButtonDryVocalsHarmony2, "Click to browse for the second harmony dryvox file");
            this.ButtonDryVocalsHarmony2.UseVisualStyleBackColor = false;
            this.ButtonDryVocalsHarmony2.Visible = false;
            this.ButtonDryVocalsHarmony2.Click += new System.EventHandler(this.ButtonDryVocalsHarmony2_Click);
            // 
            // ButtonDryVocals
            // 
            this.ButtonDryVocals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(74)))), ((int)(((byte)(85)))));
            this.ButtonDryVocals.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonDryVocals.BackgroundImage")));
            this.ButtonDryVocals.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDryVocals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDryVocals.FlatAppearance.BorderSize = 0;
            this.ButtonDryVocals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDryVocals.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDryVocals.ForeColor = System.Drawing.Color.White;
            this.ButtonDryVocals.Location = new System.Drawing.Point(480, 303);
            this.ButtonDryVocals.Name = "ButtonDryVocals";
            this.ButtonDryVocals.Size = new System.Drawing.Size(28, 22);
            this.ButtonDryVocals.TabIndex = 101;
            this.ButtonDryVocals.Text = "...";
            this.ToolTip.SetToolTip(this.ButtonDryVocals, "Click to browse for the lead vocal dryvox file");
            this.ButtonDryVocals.UseVisualStyleBackColor = false;
            this.ButtonDryVocals.Visible = false;
            this.ButtonDryVocals.Click += new System.EventHandler(this.ButtonDryVocals_Click);
            // 
            // TextBoxDryVocals
            // 
            this.TextBoxDryVocals.AllowDrop = true;
            this.TextBoxDryVocals.ContextMenuStrip = this.contextMenuStrip2;
            this.TextBoxDryVocals.Enabled = false;
            this.TextBoxDryVocals.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDryVocals.ForeColor = System.Drawing.Color.Black;
            this.TextBoxDryVocals.Location = new System.Drawing.Point(168, 305);
            this.TextBoxDryVocals.MaxLength = 250;
            this.TextBoxDryVocals.Name = "TextBoxDryVocals";
            this.TextBoxDryVocals.Size = new System.Drawing.Size(304, 20);
            this.TextBoxDryVocals.TabIndex = 100;
            this.TextBoxDryVocals.Tag = "Audio - Lead Dry Vocals";
            this.ToolTip.SetToolTip(this.TextBoxDryVocals, "This is the location of your lead harmony dryvox file");
            this.TextBoxDryVocals.EnabledChanged += new System.EventHandler(this.TextBoxDryVocals_EnabledChanged);
            this.TextBoxDryVocals.TextChanged += new System.EventHandler(this.TextBoxDryVocals_TextChanged);
            this.TextBoxDryVocals.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBoxes_DragDrop);
            this.TextBoxDryVocals.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.TextBoxDryVocals.MouseEnter += new System.EventHandler(this.TextBoxDrumKit_MouseEnter);
            // 
            // TextBoxDryVocalsHarmony2
            // 
            this.TextBoxDryVocalsHarmony2.AllowDrop = true;
            this.TextBoxDryVocalsHarmony2.ContextMenuStrip = this.contextMenuStrip2;
            this.TextBoxDryVocalsHarmony2.Enabled = false;
            this.TextBoxDryVocalsHarmony2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDryVocalsHarmony2.ForeColor = System.Drawing.Color.Black;
            this.TextBoxDryVocalsHarmony2.Location = new System.Drawing.Point(168, 333);
            this.TextBoxDryVocalsHarmony2.MaxLength = 250;
            this.TextBoxDryVocalsHarmony2.Name = "TextBoxDryVocalsHarmony2";
            this.TextBoxDryVocalsHarmony2.Size = new System.Drawing.Size(304, 20);
            this.TextBoxDryVocalsHarmony2.TabIndex = 103;
            this.TextBoxDryVocalsHarmony2.Tag = "Audio - Harmony 2 Dry Vocals";
            this.ToolTip.SetToolTip(this.TextBoxDryVocalsHarmony2, "This is the location of your second harmony dryvox file");
            this.TextBoxDryVocalsHarmony2.EnabledChanged += new System.EventHandler(this.TextBoxDryVocalsHarmony2_EnabledChanged);
            this.TextBoxDryVocalsHarmony2.TextChanged += new System.EventHandler(this.TextBoxDryVocals_TextChanged);
            this.TextBoxDryVocalsHarmony2.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBoxes_DragDrop);
            this.TextBoxDryVocalsHarmony2.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.TextBoxDryVocalsHarmony2.MouseEnter += new System.EventHandler(this.TextBoxDrumKit_MouseEnter);
            // 
            // LabelDryVocals
            // 
            this.LabelDryVocals.BackColor = System.Drawing.Color.Transparent;
            this.LabelDryVocals.ForeColor = System.Drawing.Color.LightGray;
            this.LabelDryVocals.Location = new System.Drawing.Point(7, 305);
            this.LabelDryVocals.Name = "LabelDryVocals";
            this.LabelDryVocals.Size = new System.Drawing.Size(154, 17);
            this.LabelDryVocals.TabIndex = 96;
            this.LabelDryVocals.Text = "SOLO/HARMONY 1 Dry Vocals";
            this.LabelDryVocals.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ButtonVocals
            // 
            this.ButtonVocals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(71)))), ((int)(((byte)(83)))));
            this.ButtonVocals.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonVocals.BackgroundImage")));
            this.ButtonVocals.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonVocals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonVocals.FlatAppearance.BorderSize = 0;
            this.ButtonVocals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonVocals.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonVocals.ForeColor = System.Drawing.Color.White;
            this.ButtonVocals.Location = new System.Drawing.Point(480, 275);
            this.ButtonVocals.Name = "ButtonVocals";
            this.ButtonVocals.Size = new System.Drawing.Size(28, 22);
            this.ButtonVocals.TabIndex = 99;
            this.ButtonVocals.Text = "...";
            this.ToolTip.SetToolTip(this.ButtonVocals, "Click to browse for the vocals track");
            this.ButtonVocals.UseVisualStyleBackColor = false;
            this.ButtonVocals.Visible = false;
            this.ButtonVocals.Click += new System.EventHandler(this.ButtonVocals_Click);
            // 
            // TextBoxVocals
            // 
            this.TextBoxVocals.AllowDrop = true;
            this.TextBoxVocals.ContextMenuStrip = this.contextMenuStrip2;
            this.TextBoxVocals.Enabled = false;
            this.TextBoxVocals.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxVocals.ForeColor = System.Drawing.Color.Black;
            this.TextBoxVocals.Location = new System.Drawing.Point(168, 277);
            this.TextBoxVocals.MaxLength = 250;
            this.TextBoxVocals.Name = "TextBoxVocals";
            this.TextBoxVocals.Size = new System.Drawing.Size(304, 20);
            this.TextBoxVocals.TabIndex = 98;
            this.TextBoxVocals.Tag = "Audio - Vocals";
            this.ToolTip.SetToolTip(this.TextBoxVocals, "This is the location of your vocals audio track");
            this.TextBoxVocals.EnabledChanged += new System.EventHandler(this.TextBoxVocals_EnabledChanged);
            this.TextBoxVocals.TextChanged += new System.EventHandler(this.TextBoxVocals_TextChanged);
            this.TextBoxVocals.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBoxes_DragDrop);
            this.TextBoxVocals.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.TextBoxVocals.MouseEnter += new System.EventHandler(this.TextBoxDrumKit_MouseEnter);
            // 
            // LabelVocals
            // 
            this.LabelVocals.BackColor = System.Drawing.Color.Transparent;
            this.LabelVocals.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVocals.ForeColor = System.Drawing.Color.LightGray;
            this.LabelVocals.Location = new System.Drawing.Point(35, 280);
            this.LabelVocals.Name = "LabelVocals";
            this.LabelVocals.Size = new System.Drawing.Size(126, 13);
            this.LabelVocals.TabIndex = 95;
            this.LabelVocals.Text = "VOCALS";
            this.LabelVocals.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckVocals
            // 
            this.CheckVocals.AutoSize = true;
            this.CheckVocals.BackColor = System.Drawing.Color.Transparent;
            this.CheckVocals.Checked = true;
            this.CheckVocals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckVocals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckVocals.Location = new System.Drawing.Point(16, 279);
            this.CheckVocals.Name = "CheckVocals";
            this.CheckVocals.Size = new System.Drawing.Size(15, 14);
            this.CheckVocals.TabIndex = 97;
            this.ToolTip.SetToolTip(this.CheckVocals, "Click here to enable vocals for this song");
            this.CheckVocals.UseVisualStyleBackColor = false;
            this.CheckVocals.CheckedChanged += new System.EventHandler(this.CheckVocals_CheckedChanged);
            // 
            // ButtonKeys
            // 
            this.ButtonKeys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(55)))), ((int)(((byte)(63)))));
            this.ButtonKeys.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonKeys.BackgroundImage")));
            this.ButtonKeys.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonKeys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonKeys.FlatAppearance.BorderSize = 0;
            this.ButtonKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonKeys.ForeColor = System.Drawing.Color.White;
            this.ButtonKeys.Location = new System.Drawing.Point(480, 235);
            this.ButtonKeys.Name = "ButtonKeys";
            this.ButtonKeys.Size = new System.Drawing.Size(28, 22);
            this.ButtonKeys.TabIndex = 94;
            this.ButtonKeys.Text = "...";
            this.ToolTip.SetToolTip(this.ButtonKeys, "Click to browse for the keys track");
            this.ButtonKeys.UseVisualStyleBackColor = false;
            this.ButtonKeys.Visible = false;
            this.ButtonKeys.Click += new System.EventHandler(this.ButtonKeys_Click);
            // 
            // TextBoxKeys
            // 
            this.TextBoxKeys.AllowDrop = true;
            this.TextBoxKeys.ContextMenuStrip = this.contextMenuStrip2;
            this.TextBoxKeys.Enabled = false;
            this.TextBoxKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxKeys.ForeColor = System.Drawing.Color.Black;
            this.TextBoxKeys.Location = new System.Drawing.Point(168, 237);
            this.TextBoxKeys.MaxLength = 250;
            this.TextBoxKeys.Name = "TextBoxKeys";
            this.TextBoxKeys.Size = new System.Drawing.Size(304, 20);
            this.TextBoxKeys.TabIndex = 93;
            this.TextBoxKeys.Tag = "Audio - Keys";
            this.ToolTip.SetToolTip(this.TextBoxKeys, "This is the location of your keys audio track");
            this.TextBoxKeys.EnabledChanged += new System.EventHandler(this.TextBoxKeys_EnabledChanged);
            this.TextBoxKeys.TextChanged += new System.EventHandler(this.TextBoxKeys_TextChanged);
            this.TextBoxKeys.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBoxes_DragDrop);
            this.TextBoxKeys.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.TextBoxKeys.MouseEnter += new System.EventHandler(this.TextBoxDrumKit_MouseEnter);
            // 
            // LabelKeys
            // 
            this.LabelKeys.BackColor = System.Drawing.Color.Transparent;
            this.LabelKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelKeys.ForeColor = System.Drawing.Color.LightGray;
            this.LabelKeys.Location = new System.Drawing.Point(35, 240);
            this.LabelKeys.Name = "LabelKeys";
            this.LabelKeys.Size = new System.Drawing.Size(126, 13);
            this.LabelKeys.TabIndex = 91;
            this.LabelKeys.Text = "KEYS";
            this.LabelKeys.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckKeys
            // 
            this.CheckKeys.AutoSize = true;
            this.CheckKeys.BackColor = System.Drawing.Color.Transparent;
            this.CheckKeys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckKeys.Location = new System.Drawing.Point(16, 239);
            this.CheckKeys.Name = "CheckKeys";
            this.CheckKeys.Size = new System.Drawing.Size(15, 14);
            this.CheckKeys.TabIndex = 92;
            this.ToolTip.SetToolTip(this.CheckKeys, "Click here to enable keys for this song");
            this.CheckKeys.UseVisualStyleBackColor = false;
            this.CheckKeys.CheckedChanged += new System.EventHandler(this.CheckKeys_CheckedChanged);
            // 
            // ButtonGuitar
            // 
            this.ButtonGuitar.BackColor = System.Drawing.Color.Black;
            this.ButtonGuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonGuitar.BackgroundImage")));
            this.ButtonGuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonGuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonGuitar.FlatAppearance.BorderSize = 0;
            this.ButtonGuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGuitar.ForeColor = System.Drawing.Color.White;
            this.ButtonGuitar.Location = new System.Drawing.Point(480, 196);
            this.ButtonGuitar.Name = "ButtonGuitar";
            this.ButtonGuitar.Size = new System.Drawing.Size(28, 22);
            this.ButtonGuitar.TabIndex = 90;
            this.ButtonGuitar.Text = "...";
            this.ToolTip.SetToolTip(this.ButtonGuitar, "Click to browse for the guitar track");
            this.ButtonGuitar.UseVisualStyleBackColor = false;
            this.ButtonGuitar.Visible = false;
            this.ButtonGuitar.Click += new System.EventHandler(this.ButtonGuitar_Click);
            // 
            // TextBoxGuitar
            // 
            this.TextBoxGuitar.AllowDrop = true;
            this.TextBoxGuitar.ContextMenuStrip = this.contextMenuStrip2;
            this.TextBoxGuitar.Enabled = false;
            this.TextBoxGuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxGuitar.ForeColor = System.Drawing.Color.Black;
            this.TextBoxGuitar.Location = new System.Drawing.Point(168, 198);
            this.TextBoxGuitar.MaxLength = 250;
            this.TextBoxGuitar.Name = "TextBoxGuitar";
            this.TextBoxGuitar.Size = new System.Drawing.Size(304, 20);
            this.TextBoxGuitar.TabIndex = 89;
            this.TextBoxGuitar.Tag = "Audio - Guitar";
            this.ToolTip.SetToolTip(this.TextBoxGuitar, "This is the location of your guitar audio track");
            this.TextBoxGuitar.EnabledChanged += new System.EventHandler(this.TextBoxGuitar_EnabledChanged);
            this.TextBoxGuitar.TextChanged += new System.EventHandler(this.TextBoxGuitar_TextChanged);
            this.TextBoxGuitar.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBoxes_DragDrop);
            this.TextBoxGuitar.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.TextBoxGuitar.MouseEnter += new System.EventHandler(this.TextBoxDrumKit_MouseEnter);
            // 
            // LabelGuitar
            // 
            this.LabelGuitar.BackColor = System.Drawing.Color.Transparent;
            this.LabelGuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGuitar.ForeColor = System.Drawing.Color.LightGray;
            this.LabelGuitar.Location = new System.Drawing.Point(35, 201);
            this.LabelGuitar.Name = "LabelGuitar";
            this.LabelGuitar.Size = new System.Drawing.Size(126, 13);
            this.LabelGuitar.TabIndex = 87;
            this.LabelGuitar.Text = "GUITAR";
            this.LabelGuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckGuitar
            // 
            this.CheckGuitar.AutoSize = true;
            this.CheckGuitar.BackColor = System.Drawing.Color.Transparent;
            this.CheckGuitar.Checked = true;
            this.CheckGuitar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckGuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckGuitar.Location = new System.Drawing.Point(16, 200);
            this.CheckGuitar.Name = "CheckGuitar";
            this.CheckGuitar.Size = new System.Drawing.Size(15, 14);
            this.CheckGuitar.TabIndex = 88;
            this.ToolTip.SetToolTip(this.CheckGuitar, "Click here to enable guitar for this song");
            this.CheckGuitar.UseVisualStyleBackColor = false;
            this.CheckGuitar.CheckedChanged += new System.EventHandler(this.CheckGuitar_CheckedChanged);
            // 
            // ButtonBass
            // 
            this.ButtonBass.BackColor = System.Drawing.Color.Black;
            this.ButtonBass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonBass.BackgroundImage")));
            this.ButtonBass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonBass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonBass.FlatAppearance.BorderSize = 0;
            this.ButtonBass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonBass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBass.ForeColor = System.Drawing.Color.White;
            this.ButtonBass.Location = new System.Drawing.Point(480, 157);
            this.ButtonBass.Name = "ButtonBass";
            this.ButtonBass.Size = new System.Drawing.Size(28, 22);
            this.ButtonBass.TabIndex = 86;
            this.ButtonBass.Text = "...";
            this.ToolTip.SetToolTip(this.ButtonBass, "Click to browse for the bass track");
            this.ButtonBass.UseVisualStyleBackColor = false;
            this.ButtonBass.Visible = false;
            this.ButtonBass.Click += new System.EventHandler(this.ButtonBass_Click);
            // 
            // TextBoxBass
            // 
            this.TextBoxBass.AllowDrop = true;
            this.TextBoxBass.ContextMenuStrip = this.contextMenuStrip2;
            this.TextBoxBass.Enabled = false;
            this.TextBoxBass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxBass.ForeColor = System.Drawing.Color.Black;
            this.TextBoxBass.Location = new System.Drawing.Point(168, 159);
            this.TextBoxBass.MaxLength = 250;
            this.TextBoxBass.Name = "TextBoxBass";
            this.TextBoxBass.Size = new System.Drawing.Size(304, 20);
            this.TextBoxBass.TabIndex = 85;
            this.TextBoxBass.Tag = "Audio - Bass";
            this.ToolTip.SetToolTip(this.TextBoxBass, "This is the location of your bass audio track");
            this.TextBoxBass.EnabledChanged += new System.EventHandler(this.TextBoxBass_EnabledChanged);
            this.TextBoxBass.TextChanged += new System.EventHandler(this.TextBoxBass_TextChanged);
            this.TextBoxBass.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBoxes_DragDrop);
            this.TextBoxBass.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.TextBoxBass.MouseEnter += new System.EventHandler(this.TextBoxDrumKit_MouseEnter);
            // 
            // LabelBass
            // 
            this.LabelBass.BackColor = System.Drawing.Color.Transparent;
            this.LabelBass.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBass.ForeColor = System.Drawing.Color.LightGray;
            this.LabelBass.Location = new System.Drawing.Point(35, 164);
            this.LabelBass.Name = "LabelBass";
            this.LabelBass.Size = new System.Drawing.Size(126, 13);
            this.LabelBass.TabIndex = 83;
            this.LabelBass.Text = "BASS";
            this.LabelBass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckBass
            // 
            this.CheckBass.AutoSize = true;
            this.CheckBass.BackColor = System.Drawing.Color.Transparent;
            this.CheckBass.Checked = true;
            this.CheckBass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBass.Location = new System.Drawing.Point(16, 161);
            this.CheckBass.Name = "CheckBass";
            this.CheckBass.Size = new System.Drawing.Size(15, 14);
            this.CheckBass.TabIndex = 84;
            this.ToolTip.SetToolTip(this.CheckBass, "Click here to enable bass for this song");
            this.CheckBass.UseVisualStyleBackColor = false;
            this.CheckBass.CheckedChanged += new System.EventHandler(this.CheckBass_CheckedChanged);
            // 
            // ComboDrums
            // 
            this.ComboDrums.BackColor = System.Drawing.Color.White;
            this.ComboDrums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboDrums.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboDrums.ForeColor = System.Drawing.Color.Black;
            this.ComboDrums.FormattingEnabled = true;
            this.ComboDrums.Items.AddRange(new object[] {
            "Kit",
            "Kit & Kick",
            "Kit, Kick & Snare"});
            this.ComboDrums.Location = new System.Drawing.Point(168, 33);
            this.ComboDrums.Name = "ComboDrums";
            this.ComboDrums.Size = new System.Drawing.Size(304, 21);
            this.ComboDrums.TabIndex = 72;
            this.ComboDrums.Tag = "Audio - Drums";
            this.ToolTip.SetToolTip(this.ComboDrums, "Click to select the drum mix");
            this.ComboDrums.SelectedIndexChanged += new System.EventHandler(this.ComboDrums_SelectedIndexChanged);
            this.ComboDrums.EnabledChanged += new System.EventHandler(this.ComboDrums_EnabledChanged);
            // 
            // LabelDrumSnare
            // 
            this.LabelDrumSnare.BackColor = System.Drawing.Color.Transparent;
            this.LabelDrumSnare.ForeColor = System.Drawing.Color.LightGray;
            this.LabelDrumSnare.Location = new System.Drawing.Point(35, 94);
            this.LabelDrumSnare.Name = "LabelDrumSnare";
            this.LabelDrumSnare.Size = new System.Drawing.Size(126, 13);
            this.LabelDrumSnare.TabIndex = 82;
            this.LabelDrumSnare.Text = "Snare";
            this.LabelDrumSnare.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelDrumKick
            // 
            this.LabelDrumKick.BackColor = System.Drawing.Color.Transparent;
            this.LabelDrumKick.ForeColor = System.Drawing.Color.LightGray;
            this.LabelDrumKick.Location = new System.Drawing.Point(35, 123);
            this.LabelDrumKick.Name = "LabelDrumKick";
            this.LabelDrumKick.Size = new System.Drawing.Size(126, 13);
            this.LabelDrumKick.TabIndex = 81;
            this.LabelDrumKick.Text = "Kick";
            this.LabelDrumKick.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelDrumKit
            // 
            this.LabelDrumKit.BackColor = System.Drawing.Color.Transparent;
            this.LabelDrumKit.ForeColor = System.Drawing.Color.LightGray;
            this.LabelDrumKit.Location = new System.Drawing.Point(35, 65);
            this.LabelDrumKit.Name = "LabelDrumKit";
            this.LabelDrumKit.Size = new System.Drawing.Size(126, 13);
            this.LabelDrumKit.TabIndex = 80;
            this.LabelDrumKit.Text = "Kit";
            this.LabelDrumKit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ButtonDrumSnare
            // 
            this.ButtonDrumSnare.BackColor = System.Drawing.Color.Black;
            this.ButtonDrumSnare.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonDrumSnare.BackgroundImage")));
            this.ButtonDrumSnare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDrumSnare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDrumSnare.FlatAppearance.BorderSize = 0;
            this.ButtonDrumSnare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDrumSnare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDrumSnare.ForeColor = System.Drawing.Color.White;
            this.ButtonDrumSnare.Location = new System.Drawing.Point(480, 89);
            this.ButtonDrumSnare.Name = "ButtonDrumSnare";
            this.ButtonDrumSnare.Size = new System.Drawing.Size(28, 22);
            this.ButtonDrumSnare.TabIndex = 77;
            this.ButtonDrumSnare.Text = "...";
            this.ToolTip.SetToolTip(this.ButtonDrumSnare, "Click to browse for the drum snare track");
            this.ButtonDrumSnare.UseVisualStyleBackColor = false;
            this.ButtonDrumSnare.Visible = false;
            this.ButtonDrumSnare.Click += new System.EventHandler(this.ButtonDrumSnare_Click);
            // 
            // TextBoxDrumSnare
            // 
            this.TextBoxDrumSnare.AllowDrop = true;
            this.TextBoxDrumSnare.ContextMenuStrip = this.contextMenuStrip2;
            this.TextBoxDrumSnare.Enabled = false;
            this.TextBoxDrumSnare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDrumSnare.ForeColor = System.Drawing.Color.Black;
            this.TextBoxDrumSnare.Location = new System.Drawing.Point(168, 91);
            this.TextBoxDrumSnare.MaxLength = 250;
            this.TextBoxDrumSnare.Name = "TextBoxDrumSnare";
            this.TextBoxDrumSnare.Size = new System.Drawing.Size(304, 20);
            this.TextBoxDrumSnare.TabIndex = 76;
            this.TextBoxDrumSnare.Tag = "Audio - Drums - Snare";
            this.ToolTip.SetToolTip(this.TextBoxDrumSnare, "This is the location of your drum snare audio track");
            this.TextBoxDrumSnare.EnabledChanged += new System.EventHandler(this.TextBoxDrumSnare_EnabledChanged);
            this.TextBoxDrumSnare.TextChanged += new System.EventHandler(this.TextBoxDrumSnare_TextChanged);
            this.TextBoxDrumSnare.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBoxes_DragDrop);
            this.TextBoxDrumSnare.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.TextBoxDrumSnare.MouseEnter += new System.EventHandler(this.TextBoxDrumKit_MouseEnter);
            // 
            // ButtonDrumKick
            // 
            this.ButtonDrumKick.BackColor = System.Drawing.Color.Black;
            this.ButtonDrumKick.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonDrumKick.BackgroundImage")));
            this.ButtonDrumKick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDrumKick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDrumKick.FlatAppearance.BorderSize = 0;
            this.ButtonDrumKick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDrumKick.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDrumKick.ForeColor = System.Drawing.Color.White;
            this.ButtonDrumKick.Location = new System.Drawing.Point(480, 118);
            this.ButtonDrumKick.Name = "ButtonDrumKick";
            this.ButtonDrumKick.Size = new System.Drawing.Size(28, 22);
            this.ButtonDrumKick.TabIndex = 79;
            this.ButtonDrumKick.Text = "...";
            this.ToolTip.SetToolTip(this.ButtonDrumKick, "Click to browse for the drum kick track");
            this.ButtonDrumKick.UseVisualStyleBackColor = false;
            this.ButtonDrumKick.Visible = false;
            this.ButtonDrumKick.Click += new System.EventHandler(this.ButtonDrumKick_Click);
            // 
            // TextBoxDrumKick
            // 
            this.TextBoxDrumKick.AllowDrop = true;
            this.TextBoxDrumKick.ContextMenuStrip = this.contextMenuStrip2;
            this.TextBoxDrumKick.Enabled = false;
            this.TextBoxDrumKick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDrumKick.ForeColor = System.Drawing.Color.Black;
            this.TextBoxDrumKick.Location = new System.Drawing.Point(168, 120);
            this.TextBoxDrumKick.MaxLength = 250;
            this.TextBoxDrumKick.Name = "TextBoxDrumKick";
            this.TextBoxDrumKick.Size = new System.Drawing.Size(304, 20);
            this.TextBoxDrumKick.TabIndex = 78;
            this.TextBoxDrumKick.Tag = "Audio - Drums - Kick";
            this.ToolTip.SetToolTip(this.TextBoxDrumKick, "This is the location of your drum kick audio track");
            this.TextBoxDrumKick.EnabledChanged += new System.EventHandler(this.TextBoxDrumKick_EnabledChanged);
            this.TextBoxDrumKick.TextChanged += new System.EventHandler(this.TextBoxDrumKick_TextChanged);
            this.TextBoxDrumKick.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBoxes_DragDrop);
            this.TextBoxDrumKick.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.TextBoxDrumKick.MouseEnter += new System.EventHandler(this.TextBoxDrumKit_MouseEnter);
            // 
            // ButtonDrumKit
            // 
            this.ButtonDrumKit.BackColor = System.Drawing.Color.Black;
            this.ButtonDrumKit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonDrumKit.BackgroundImage")));
            this.ButtonDrumKit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDrumKit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDrumKit.FlatAppearance.BorderSize = 0;
            this.ButtonDrumKit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDrumKit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDrumKit.ForeColor = System.Drawing.Color.White;
            this.ButtonDrumKit.Location = new System.Drawing.Point(480, 60);
            this.ButtonDrumKit.Name = "ButtonDrumKit";
            this.ButtonDrumKit.Size = new System.Drawing.Size(28, 22);
            this.ButtonDrumKit.TabIndex = 75;
            this.ButtonDrumKit.Text = "...";
            this.ToolTip.SetToolTip(this.ButtonDrumKit, "Click to browse for the drum kit track");
            this.ButtonDrumKit.UseVisualStyleBackColor = false;
            this.ButtonDrumKit.Visible = false;
            this.ButtonDrumKit.Click += new System.EventHandler(this.ButtonDrumKit_Click);
            // 
            // LabelDrums
            // 
            this.LabelDrums.BackColor = System.Drawing.Color.Transparent;
            this.LabelDrums.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDrums.ForeColor = System.Drawing.Color.LightGray;
            this.LabelDrums.Location = new System.Drawing.Point(35, 36);
            this.LabelDrums.Name = "LabelDrums";
            this.LabelDrums.Size = new System.Drawing.Size(126, 13);
            this.LabelDrums.TabIndex = 73;
            this.LabelDrums.Text = "DRUM MIX";
            this.LabelDrums.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextBoxDrumKit
            // 
            this.TextBoxDrumKit.AllowDrop = true;
            this.TextBoxDrumKit.ContextMenuStrip = this.contextMenuStrip2;
            this.TextBoxDrumKit.Enabled = false;
            this.TextBoxDrumKit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDrumKit.ForeColor = System.Drawing.Color.Black;
            this.TextBoxDrumKit.Location = new System.Drawing.Point(168, 62);
            this.TextBoxDrumKit.MaxLength = 250;
            this.TextBoxDrumKit.Name = "TextBoxDrumKit";
            this.TextBoxDrumKit.Size = new System.Drawing.Size(304, 20);
            this.TextBoxDrumKit.TabIndex = 74;
            this.TextBoxDrumKit.Tag = "Audio - Drums - Kit";
            this.ToolTip.SetToolTip(this.TextBoxDrumKit, "This is the location of your drum kit audio track");
            this.TextBoxDrumKit.EnabledChanged += new System.EventHandler(this.TextBoxDrumKit_EnabledChanged);
            this.TextBoxDrumKit.TextChanged += new System.EventHandler(this.TextBoxDrumKit_TextChanged);
            this.TextBoxDrumKit.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBoxes_DragDrop);
            this.TextBoxDrumKit.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.TextBoxDrumKit.MouseEnter += new System.EventHandler(this.TextBoxDrumKit_MouseEnter);
            // 
            // CheckDrums
            // 
            this.CheckDrums.AutoSize = true;
            this.CheckDrums.BackColor = System.Drawing.Color.Transparent;
            this.CheckDrums.Checked = true;
            this.CheckDrums.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckDrums.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckDrums.Location = new System.Drawing.Point(16, 35);
            this.CheckDrums.Name = "CheckDrums";
            this.CheckDrums.Size = new System.Drawing.Size(15, 14);
            this.CheckDrums.TabIndex = 71;
            this.ToolTip.SetToolTip(this.CheckDrums, "Click here to enable drums for this song");
            this.CheckDrums.UseVisualStyleBackColor = false;
            this.CheckDrums.CheckedChanged += new System.EventHandler(this.CheckDrums_CheckedChanged);
            // 
            // btnCrowd
            // 
            this.btnCrowd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.btnCrowd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCrowd.BackgroundImage")));
            this.btnCrowd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrowd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrowd.FlatAppearance.BorderSize = 0;
            this.btnCrowd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrowd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrowd.ForeColor = System.Drawing.Color.White;
            this.btnCrowd.Location = new System.Drawing.Point(480, 436);
            this.btnCrowd.Name = "btnCrowd";
            this.btnCrowd.Size = new System.Drawing.Size(28, 22);
            this.btnCrowd.TabIndex = 70;
            this.btnCrowd.Text = "...";
            this.ToolTip.SetToolTip(this.btnCrowd, "Click to browse for the crowd track");
            this.btnCrowd.UseVisualStyleBackColor = false;
            this.btnCrowd.Visible = false;
            this.btnCrowd.Click += new System.EventHandler(this.btnCrowd_Click);
            // 
            // TextBoxCrowd
            // 
            this.TextBoxCrowd.AllowDrop = true;
            this.TextBoxCrowd.ContextMenuStrip = this.contextMenuStrip2;
            this.TextBoxCrowd.Enabled = false;
            this.TextBoxCrowd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCrowd.ForeColor = System.Drawing.Color.Black;
            this.TextBoxCrowd.Location = new System.Drawing.Point(168, 438);
            this.TextBoxCrowd.MaxLength = 250;
            this.TextBoxCrowd.Name = "TextBoxCrowd";
            this.TextBoxCrowd.Size = new System.Drawing.Size(304, 20);
            this.TextBoxCrowd.TabIndex = 38;
            this.TextBoxCrowd.Tag = "Audio - Crowd";
            this.ToolTip.SetToolTip(this.TextBoxCrowd, "This is the location of the crowd audio track");
            this.TextBoxCrowd.EnabledChanged += new System.EventHandler(this.TextCrowd_EnabledChanged);
            this.TextBoxCrowd.TextChanged += new System.EventHandler(this.TextCrowd_TextChanged);
            this.TextBoxCrowd.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioBoxes_DragDrop);
            this.TextBoxCrowd.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            this.TextBoxCrowd.MouseEnter += new System.EventHandler(this.TextBoxDrumKit_MouseEnter);
            // 
            // LabelCrowd
            // 
            this.LabelCrowd.AutoSize = true;
            this.LabelCrowd.BackColor = System.Drawing.Color.Transparent;
            this.LabelCrowd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCrowd.ForeColor = System.Drawing.Color.LightGray;
            this.LabelCrowd.Location = new System.Drawing.Point(110, 442);
            this.LabelCrowd.Name = "LabelCrowd";
            this.LabelCrowd.Size = new System.Drawing.Size(51, 13);
            this.LabelCrowd.TabIndex = 68;
            this.LabelCrowd.Text = "CROWD";
            this.LabelCrowd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckCrowd
            // 
            this.CheckCrowd.AutoSize = true;
            this.CheckCrowd.BackColor = System.Drawing.Color.Transparent;
            this.CheckCrowd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckCrowd.Location = new System.Drawing.Point(16, 440);
            this.CheckCrowd.Name = "CheckCrowd";
            this.CheckCrowd.Size = new System.Drawing.Size(15, 14);
            this.CheckCrowd.TabIndex = 69;
            this.ToolTip.SetToolTip(this.CheckCrowd, "Click here to enable a crowd track for this song");
            this.CheckCrowd.UseVisualStyleBackColor = false;
            this.CheckCrowd.CheckedChanged += new System.EventHandler(this.CheckCrowd_CheckedChanged);
            // 
            // EncodingQualityUpDown
            // 
            this.EncodingQualityUpDown.BackColor = System.Drawing.Color.White;
            this.EncodingQualityUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodingQualityUpDown.ForeColor = System.Drawing.Color.Black;
            this.EncodingQualityUpDown.Items.Add("10 (highest)");
            this.EncodingQualityUpDown.Items.Add("09");
            this.EncodingQualityUpDown.Items.Add("08");
            this.EncodingQualityUpDown.Items.Add("07");
            this.EncodingQualityUpDown.Items.Add("06");
            this.EncodingQualityUpDown.Items.Add("05");
            this.EncodingQualityUpDown.Items.Add("04");
            this.EncodingQualityUpDown.Items.Add("03 (default)");
            this.EncodingQualityUpDown.Items.Add("02");
            this.EncodingQualityUpDown.Items.Add("01 (lowest)");
            this.EncodingQualityUpDown.Location = new System.Drawing.Point(405, 507);
            this.EncodingQualityUpDown.Name = "EncodingQualityUpDown";
            this.EncodingQualityUpDown.ReadOnly = true;
            this.EncodingQualityUpDown.Size = new System.Drawing.Size(82, 20);
            this.EncodingQualityUpDown.TabIndex = 67;
            this.EncodingQualityUpDown.Text = "03 (default)";
            this.EncodingQualityUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.EncodingQualityUpDown, "Set the encoding quality for the audio. Default is 3.");
            this.EncodingQualityUpDown.SelectedItemChanged += new System.EventHandler(this.EncodingQualityUpDown_SelectedItemChanged);
            // 
            // LabelEncodingQuality
            // 
            this.LabelEncodingQuality.AutoSize = true;
            this.LabelEncodingQuality.BackColor = System.Drawing.Color.Transparent;
            this.LabelEncodingQuality.ForeColor = System.Drawing.Color.White;
            this.LabelEncodingQuality.Location = new System.Drawing.Point(332, 512);
            this.LabelEncodingQuality.Name = "LabelEncodingQuality";
            this.LabelEncodingQuality.Size = new System.Drawing.Size(72, 13);
            this.LabelEncodingQuality.TabIndex = 66;
            this.LabelEncodingQuality.Text = "Audio Quality:";
            this.LabelEncodingQuality.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupDrumMix
            // 
            this.groupDrumMix.BackColor = System.Drawing.Color.Transparent;
            this.groupDrumMix.Controls.Add(this.chkDrumsMix);
            this.groupDrumMix.Controls.Add(this.lblDrumMix);
            this.groupDrumMix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDrumMix.ForeColor = System.Drawing.Color.White;
            this.groupDrumMix.Location = new System.Drawing.Point(544, 470);
            this.groupDrumMix.Name = "groupDrumMix";
            this.groupDrumMix.Size = new System.Drawing.Size(191, 61);
            this.groupDrumMix.TabIndex = 65;
            this.groupDrumMix.TabStop = false;
            this.groupDrumMix.Text = "Recommended Drum Mix";
            // 
            // chkDrumsMix
            // 
            this.chkDrumsMix.AutoSize = true;
            this.chkDrumsMix.Checked = true;
            this.chkDrumsMix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDrumsMix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDrumsMix.Location = new System.Drawing.Point(102, 42);
            this.chkDrumsMix.Name = "chkDrumsMix";
            this.chkDrumsMix.Size = new System.Drawing.Size(83, 17);
            this.chkDrumsMix.TabIndex = 65;
            this.chkDrumsMix.Text = "Add to MIDI";
            this.ToolTip.SetToolTip(this.chkDrumsMix, "Check to automatically add or edit the drum mix events");
            this.chkDrumsMix.UseVisualStyleBackColor = true;
            this.chkDrumsMix.CheckedChanged += new System.EventHandler(this.chkDrumsMix_CheckedChanged);
            // 
            // lblDrumMix
            // 
            this.lblDrumMix.BackColor = System.Drawing.Color.Transparent;
            this.lblDrumMix.Cursor = System.Windows.Forms.Cursors.No;
            this.lblDrumMix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrumMix.ForeColor = System.Drawing.Color.White;
            this.lblDrumMix.Location = new System.Drawing.Point(6, 21);
            this.lblDrumMix.Name = "lblDrumMix";
            this.lblDrumMix.Size = new System.Drawing.Size(179, 13);
            this.lblDrumMix.TabIndex = 64;
            this.lblDrumMix.Text = "Recommend drum mix:";
            this.lblDrumMix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.lblDrumMix, "This is the recommended drum mix based on your audio selection. Click to copy to " +
        "your clipboard");
            this.lblDrumMix.Visible = false;
            this.lblDrumMix.Click += new System.EventHandler(this.lblDrumMix_Click);
            // 
            // DomainPreviewSecs
            // 
            this.DomainPreviewSecs.BackColor = System.Drawing.Color.White;
            this.DomainPreviewSecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DomainPreviewSecs.ForeColor = System.Drawing.Color.Black;
            this.DomainPreviewSecs.Items.Add("60");
            this.DomainPreviewSecs.Items.Add("59");
            this.DomainPreviewSecs.Items.Add("58");
            this.DomainPreviewSecs.Items.Add("57");
            this.DomainPreviewSecs.Items.Add("56");
            this.DomainPreviewSecs.Items.Add("55");
            this.DomainPreviewSecs.Items.Add("54");
            this.DomainPreviewSecs.Items.Add("53");
            this.DomainPreviewSecs.Items.Add("52");
            this.DomainPreviewSecs.Items.Add("51");
            this.DomainPreviewSecs.Items.Add("50");
            this.DomainPreviewSecs.Items.Add("49");
            this.DomainPreviewSecs.Items.Add("48");
            this.DomainPreviewSecs.Items.Add("47");
            this.DomainPreviewSecs.Items.Add("46");
            this.DomainPreviewSecs.Items.Add("45");
            this.DomainPreviewSecs.Items.Add("44");
            this.DomainPreviewSecs.Items.Add("43");
            this.DomainPreviewSecs.Items.Add("42");
            this.DomainPreviewSecs.Items.Add("41");
            this.DomainPreviewSecs.Items.Add("40");
            this.DomainPreviewSecs.Items.Add("39");
            this.DomainPreviewSecs.Items.Add("38");
            this.DomainPreviewSecs.Items.Add("37");
            this.DomainPreviewSecs.Items.Add("36");
            this.DomainPreviewSecs.Items.Add("35");
            this.DomainPreviewSecs.Items.Add("34");
            this.DomainPreviewSecs.Items.Add("33");
            this.DomainPreviewSecs.Items.Add("32");
            this.DomainPreviewSecs.Items.Add("31");
            this.DomainPreviewSecs.Items.Add("30");
            this.DomainPreviewSecs.Items.Add("29");
            this.DomainPreviewSecs.Items.Add("28");
            this.DomainPreviewSecs.Items.Add("27");
            this.DomainPreviewSecs.Items.Add("26");
            this.DomainPreviewSecs.Items.Add("25");
            this.DomainPreviewSecs.Items.Add("24");
            this.DomainPreviewSecs.Items.Add("23");
            this.DomainPreviewSecs.Items.Add("22");
            this.DomainPreviewSecs.Items.Add("21");
            this.DomainPreviewSecs.Items.Add("20");
            this.DomainPreviewSecs.Items.Add("19");
            this.DomainPreviewSecs.Items.Add("18");
            this.DomainPreviewSecs.Items.Add("17");
            this.DomainPreviewSecs.Items.Add("16");
            this.DomainPreviewSecs.Items.Add("15");
            this.DomainPreviewSecs.Items.Add("14");
            this.DomainPreviewSecs.Items.Add("13");
            this.DomainPreviewSecs.Items.Add("12");
            this.DomainPreviewSecs.Items.Add("11");
            this.DomainPreviewSecs.Items.Add("10");
            this.DomainPreviewSecs.Items.Add("09");
            this.DomainPreviewSecs.Items.Add("08");
            this.DomainPreviewSecs.Items.Add("07");
            this.DomainPreviewSecs.Items.Add("06");
            this.DomainPreviewSecs.Items.Add("05");
            this.DomainPreviewSecs.Items.Add("04");
            this.DomainPreviewSecs.Items.Add("03");
            this.DomainPreviewSecs.Items.Add("02");
            this.DomainPreviewSecs.Items.Add("01");
            this.DomainPreviewSecs.Items.Add("00");
            this.DomainPreviewSecs.Items.Add("-1");
            this.DomainPreviewSecs.Location = new System.Drawing.Point(215, 480);
            this.DomainPreviewSecs.Name = "DomainPreviewSecs";
            this.DomainPreviewSecs.Size = new System.Drawing.Size(39, 20);
            this.DomainPreviewSecs.TabIndex = 63;
            this.DomainPreviewSecs.Tag = "Audio - Preview Start";
            this.DomainPreviewSecs.Text = "30";
            this.DomainPreviewSecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.DomainPreviewSecs, "Change the preview start time second");
            this.DomainPreviewSecs.Leave += new System.EventHandler(this.DomainPreviewSecs_Leave);
            // 
            // NumericPreviewMins
            // 
            this.NumericPreviewMins.BackColor = System.Drawing.Color.White;
            this.NumericPreviewMins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericPreviewMins.ForeColor = System.Drawing.Color.Black;
            this.NumericPreviewMins.Location = new System.Drawing.Point(168, 480);
            this.NumericPreviewMins.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.NumericPreviewMins.Name = "NumericPreviewMins";
            this.NumericPreviewMins.Size = new System.Drawing.Size(38, 20);
            this.NumericPreviewMins.TabIndex = 62;
            this.NumericPreviewMins.Tag = "Audio - Preview Start";
            this.NumericPreviewMins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.NumericPreviewMins, "Change the preview start time minute");
            this.NumericPreviewMins.ValueChanged += new System.EventHandler(this.NumericPreviewMins_ValueChanged);
            // 
            // LabelStartPreview
            // 
            this.LabelStartPreview.AutoSize = true;
            this.LabelStartPreview.BackColor = System.Drawing.Color.Transparent;
            this.LabelStartPreview.ForeColor = System.Drawing.Color.White;
            this.LabelStartPreview.Location = new System.Drawing.Point(92, 483);
            this.LabelStartPreview.Name = "LabelStartPreview";
            this.LabelStartPreview.Size = new System.Drawing.Size(73, 13);
            this.LabelStartPreview.TabIndex = 21;
            this.LabelStartPreview.Text = "Preview Start:";
            this.LabelStartPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelSongLength
            // 
            this.LabelSongLength.BackColor = System.Drawing.Color.Transparent;
            this.LabelSongLength.ForeColor = System.Drawing.Color.White;
            this.LabelSongLength.Location = new System.Drawing.Point(14, 507);
            this.LabelSongLength.Name = "LabelSongLength";
            this.LabelSongLength.Size = new System.Drawing.Size(68, 21);
            this.LabelSongLength.TabIndex = 27;
            this.LabelSongLength.Text = "9:88";
            this.LabelSongLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.LabelSongLength, "This is the length of your song");
            // 
            // LabelLength
            // 
            this.LabelLength.AutoSize = true;
            this.LabelLength.BackColor = System.Drawing.Color.Transparent;
            this.LabelLength.ForeColor = System.Drawing.Color.White;
            this.LabelLength.Location = new System.Drawing.Point(13, 483);
            this.LabelLength.Name = "LabelLength";
            this.LabelLength.Size = new System.Drawing.Size(71, 13);
            this.LabelLength.TabIndex = 26;
            this.LabelLength.Text = "Song Length:";
            this.LabelLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelPreviewSeparator
            // 
            this.LabelPreviewSeparator.BackColor = System.Drawing.Color.Transparent;
            this.LabelPreviewSeparator.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPreviewSeparator.ForeColor = System.Drawing.Color.White;
            this.LabelPreviewSeparator.Location = new System.Drawing.Point(204, 479);
            this.LabelPreviewSeparator.Name = "LabelPreviewSeparator";
            this.LabelPreviewSeparator.Size = new System.Drawing.Size(14, 21);
            this.LabelPreviewSeparator.TabIndex = 28;
            this.LabelPreviewSeparator.Text = ":";
            this.LabelPreviewSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(252, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 21);
            this.label3.TabIndex = 162;
            this.label3.Text = ":";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TabPageGameData
            // 
            this.TabPageGameData.AllowDrop = true;
            this.TabPageGameData.BackColor = System.Drawing.Color.Black;
            this.TabPageGameData.BackgroundImage = global::MagmaRokOn.Properties.Resources.bg3;
            this.TabPageGameData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TabPageGameData.Controls.Add(this.cboBandFail);
            this.TabPageGameData.Controls.Add(this.LabelBandFail);
            this.TabPageGameData.Controls.Add(this.cboTonality);
            this.TabPageGameData.Controls.Add(this.picHelpSolos);
            this.TabPageGameData.Controls.Add(this.chkSoloVocals);
            this.TabPageGameData.Controls.Add(this.chkSoloKeys);
            this.TabPageGameData.Controls.Add(this.chkSoloBass);
            this.TabPageGameData.Controls.Add(this.chkSoloGuitar);
            this.TabPageGameData.Controls.Add(this.chkSoloDrums);
            this.TabPageGameData.Controls.Add(this.LabelSolos);
            this.TabPageGameData.Controls.Add(this.btnCleaner);
            this.TabPageGameData.Controls.Add(this.btnTester);
            this.TabPageGameData.Controls.Add(this.ButtonBrowseForMIDI);
            this.TabPageGameData.Controls.Add(this.groupBox2);
            this.TabPageGameData.Controls.Add(this.picHelpMuteVol);
            this.TabPageGameData.Controls.Add(this.LabelMuteVolume);
            this.TabPageGameData.Controls.Add(this.numericMuteVol);
            this.TabPageGameData.Controls.Add(this.LabelMuteVolumeVocals);
            this.TabPageGameData.Controls.Add(this.numericVocalMute);
            this.TabPageGameData.Controls.Add(this.groupBox1);
            this.TabPageGameData.Controls.Add(this.groupID);
            this.TabPageGameData.Controls.Add(this.picDrumSFX);
            this.TabPageGameData.Controls.Add(this.picHelpTuningCents);
            this.TabPageGameData.Controls.Add(this.LabelTuningCents);
            this.TabPageGameData.Controls.Add(this.numericTuningCents);
            this.TabPageGameData.Controls.Add(this.ComboDrumSFX);
            this.TabPageGameData.Controls.Add(this.LabelDrumKitSFX);
            this.TabPageGameData.Controls.Add(this.ComboHopo);
            this.TabPageGameData.Controls.Add(this.LabelHopoThreshold);
            this.TabPageGameData.Controls.Add(this.picHelpGuitarTuning);
            this.TabPageGameData.Controls.Add(this.BassTuning4);
            this.TabPageGameData.Controls.Add(this.BassTuning3);
            this.TabPageGameData.Controls.Add(this.BassTuning2);
            this.TabPageGameData.Controls.Add(this.BassTuning1);
            this.TabPageGameData.Controls.Add(this.GuitarTuning6);
            this.TabPageGameData.Controls.Add(this.GuitarTuning5);
            this.TabPageGameData.Controls.Add(this.GuitarTuning4);
            this.TabPageGameData.Controls.Add(this.GuitarTuning3);
            this.TabPageGameData.Controls.Add(this.GuitarTuning2);
            this.TabPageGameData.Controls.Add(this.GuitarTuning1);
            this.TabPageGameData.Controls.Add(this.LabelBassTuning);
            this.TabPageGameData.Controls.Add(this.LabelGuitarTuning);
            this.TabPageGameData.Controls.Add(this.ComboRating);
            this.TabPageGameData.Controls.Add(this.LabelSongRating);
            this.TabPageGameData.Controls.Add(this.picHelpTonicNote);
            this.TabPageGameData.Controls.Add(this.chkTonicNote);
            this.TabPageGameData.Controls.Add(this.ComboTonicNote);
            this.TabPageGameData.Controls.Add(this.NumericGuidePitchAttenuation);
            this.TabPageGameData.Controls.Add(this.LabelVocalGuidePitch);
            this.TabPageGameData.Controls.Add(this.ComboBoxAutogenTheme);
            this.TabPageGameData.Controls.Add(this.LabelAutogenTheme);
            this.TabPageGameData.Controls.Add(this.ComboAnimationSpeed);
            this.TabPageGameData.Controls.Add(this.LabelAnimationSpeed);
            this.TabPageGameData.Controls.Add(this.LabelMIDI);
            this.TabPageGameData.Controls.Add(this.TextBoxMidiFile);
            this.TabPageGameData.Controls.Add(this.ComboVocalScroll);
            this.TabPageGameData.Controls.Add(this.ComboVocalPercussion);
            this.TabPageGameData.Controls.Add(this.ComboVocalGender);
            this.TabPageGameData.Controls.Add(this.LabelVocalScroll);
            this.TabPageGameData.Controls.Add(this.LabelPercussion);
            this.TabPageGameData.Controls.Add(this.LabelVocalGender);
            this.TabPageGameData.Controls.Add(this.GroupBoxDifficulty);
            this.TabPageGameData.Controls.Add(this.ButtonExportMIDI);
            this.TabPageGameData.Controls.Add(this.chkTonality);
            this.TabPageGameData.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPageGameData.Location = new System.Drawing.Point(4, 25);
            this.TabPageGameData.Name = "TabPageGameData";
            this.TabPageGameData.Size = new System.Drawing.Size(749, 571);
            this.TabPageGameData.TabIndex = 8;
            this.TabPageGameData.Text = "Game Data";
            this.TabPageGameData.DragDrop += new System.Windows.Forms.DragEventHandler(this.HandleDragDrop);
            this.TabPageGameData.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            // 
            // cboBandFail
            // 
            this.cboBandFail.BackColor = System.Drawing.Color.White;
            this.cboBandFail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBandFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBandFail.ForeColor = System.Drawing.Color.Black;
            this.cboBandFail.FormattingEnabled = true;
            this.cboBandFail.Items.AddRange(new object[] {
            "Electronic",
            "Electronic (Keys)",
            "Heavy",
            "Heavy (Keys)",
            "Rock",
            "Rock (Keys)",
            "Vintage",
            "Vintage (Keys)"});
            this.cboBandFail.Location = new System.Drawing.Point(186, 166);
            this.cboBandFail.Name = "cboBandFail";
            this.cboBandFail.Size = new System.Drawing.Size(280, 21);
            this.cboBandFail.TabIndex = 172;
            this.cboBandFail.Tag = "MIDI - Hopo Threshold";
            this.ToolTip.SetToolTip(this.cboBandFail, "Click here to change the band fail sfx cue");
            this.cboBandFail.SelectedIndexChanged += new System.EventHandler(this.cboBandFail_SelectedIndexChanged);
            // 
            // LabelBandFail
            // 
            this.LabelBandFail.BackColor = System.Drawing.Color.Transparent;
            this.LabelBandFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelBandFail.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelBandFail.Location = new System.Drawing.Point(14, 168);
            this.LabelBandFail.Name = "LabelBandFail";
            this.LabelBandFail.Size = new System.Drawing.Size(168, 15);
            this.LabelBandFail.TabIndex = 173;
            this.LabelBandFail.Text = "BAND FAIL SFX";
            this.LabelBandFail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboTonality
            // 
            this.cboTonality.BackColor = System.Drawing.Color.White;
            this.cboTonality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTonality.Enabled = false;
            this.cboTonality.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTonality.ForeColor = System.Drawing.Color.Black;
            this.cboTonality.FormattingEnabled = true;
            this.cboTonality.Items.AddRange(new object[] {
            "0 - Major",
            "1 - Minor"});
            this.cboTonality.Location = new System.Drawing.Point(355, 315);
            this.cboTonality.Name = "cboTonality";
            this.cboTonality.Size = new System.Drawing.Size(78, 21);
            this.cboTonality.TabIndex = 171;
            this.cboTonality.Tag = "Audio - Tonality";
            this.ToolTip.SetToolTip(this.cboTonality, "Click to change the song tonality. Click on the question mark for help on how to " +
        "use");
            // 
            // picHelpSolos
            // 
            this.picHelpSolos.BackColor = System.Drawing.Color.Transparent;
            this.picHelpSolos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHelpSolos.Location = new System.Drawing.Point(414, 436);
            this.picHelpSolos.Name = "picHelpSolos";
            this.picHelpSolos.Size = new System.Drawing.Size(25, 25);
            this.picHelpSolos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHelpSolos.TabIndex = 169;
            this.picHelpSolos.TabStop = false;
            this.ToolTip.SetToolTip(this.picHelpSolos, "Click for help with Instrument Solos");
            this.picHelpSolos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picHelp_MouseClick);
            // 
            // chkSoloVocals
            // 
            this.chkSoloVocals.AutoSize = true;
            this.chkSoloVocals.BackColor = System.Drawing.Color.Transparent;
            this.chkSoloVocals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSoloVocals.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.chkSoloVocals.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkSoloVocals.Location = new System.Drawing.Point(261, 453);
            this.chkSoloVocals.Name = "chkSoloVocals";
            this.chkSoloVocals.Size = new System.Drawing.Size(147, 17);
            this.chkSoloVocals.TabIndex = 168;
            this.chkSoloVocals.Text = "VOCAL PERCUSSION";
            this.ToolTip.SetToolTip(this.chkSoloVocals, "Check if song has vocal percussion solo");
            this.chkSoloVocals.UseVisualStyleBackColor = false;
            this.chkSoloVocals.CheckedChanged += new System.EventHandler(this.chkSoloVocals_CheckedChanged);
            // 
            // chkSoloKeys
            // 
            this.chkSoloKeys.AutoSize = true;
            this.chkSoloKeys.BackColor = System.Drawing.Color.Transparent;
            this.chkSoloKeys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSoloKeys.Enabled = false;
            this.chkSoloKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.chkSoloKeys.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkSoloKeys.Location = new System.Drawing.Point(186, 453);
            this.chkSoloKeys.Name = "chkSoloKeys";
            this.chkSoloKeys.Size = new System.Drawing.Size(58, 17);
            this.chkSoloKeys.TabIndex = 167;
            this.chkSoloKeys.Text = "KEYS";
            this.ToolTip.SetToolTip(this.chkSoloKeys, "Check if song has keys solo");
            this.chkSoloKeys.UseVisualStyleBackColor = false;
            this.chkSoloKeys.CheckedChanged += new System.EventHandler(this.chkSoloKeys_CheckedChanged);
            // 
            // chkSoloBass
            // 
            this.chkSoloBass.AutoSize = true;
            this.chkSoloBass.BackColor = System.Drawing.Color.Transparent;
            this.chkSoloBass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSoloBass.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.chkSoloBass.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkSoloBass.Location = new System.Drawing.Point(336, 434);
            this.chkSoloBass.Name = "chkSoloBass";
            this.chkSoloBass.Size = new System.Drawing.Size(58, 17);
            this.chkSoloBass.TabIndex = 166;
            this.chkSoloBass.Text = "BASS";
            this.ToolTip.SetToolTip(this.chkSoloBass, "Check if song has bass solo");
            this.chkSoloBass.UseVisualStyleBackColor = false;
            this.chkSoloBass.CheckedChanged += new System.EventHandler(this.chkSoloBass_CheckedChanged);
            // 
            // chkSoloGuitar
            // 
            this.chkSoloGuitar.AutoSize = true;
            this.chkSoloGuitar.BackColor = System.Drawing.Color.Transparent;
            this.chkSoloGuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSoloGuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.chkSoloGuitar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkSoloGuitar.Location = new System.Drawing.Point(261, 434);
            this.chkSoloGuitar.Name = "chkSoloGuitar";
            this.chkSoloGuitar.Size = new System.Drawing.Size(69, 17);
            this.chkSoloGuitar.TabIndex = 165;
            this.chkSoloGuitar.Text = "GUITAR";
            this.ToolTip.SetToolTip(this.chkSoloGuitar, "Check if song has guitar solo");
            this.chkSoloGuitar.UseVisualStyleBackColor = false;
            this.chkSoloGuitar.CheckedChanged += new System.EventHandler(this.chkSoloGuitar_CheckedChanged);
            // 
            // chkSoloDrums
            // 
            this.chkSoloDrums.AutoSize = true;
            this.chkSoloDrums.BackColor = System.Drawing.Color.Transparent;
            this.chkSoloDrums.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSoloDrums.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.chkSoloDrums.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkSoloDrums.Location = new System.Drawing.Point(186, 434);
            this.chkSoloDrums.Name = "chkSoloDrums";
            this.chkSoloDrums.Size = new System.Drawing.Size(69, 17);
            this.chkSoloDrums.TabIndex = 164;
            this.chkSoloDrums.Text = "DRUMS";
            this.ToolTip.SetToolTip(this.chkSoloDrums, "Check if song has drums solo");
            this.chkSoloDrums.UseVisualStyleBackColor = false;
            this.chkSoloDrums.CheckedChanged += new System.EventHandler(this.chkSoloDrums_CheckedChanged);
            // 
            // LabelSolos
            // 
            this.LabelSolos.BackColor = System.Drawing.Color.Transparent;
            this.LabelSolos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelSolos.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelSolos.Location = new System.Drawing.Point(71, 445);
            this.LabelSolos.Name = "LabelSolos";
            this.LabelSolos.Size = new System.Drawing.Size(109, 13);
            this.LabelSolos.TabIndex = 163;
            this.LabelSolos.Text = "SOLOS";
            this.LabelSolos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCleaner
            // 
            this.btnCleaner.BackColor = System.Drawing.Color.Black;
            this.btnCleaner.BackgroundImage = global::MagmaRokOn.Properties.Resources.button_bg_large;
            this.btnCleaner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCleaner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCleaner.Enabled = false;
            this.btnCleaner.FlatAppearance.BorderSize = 0;
            this.btnCleaner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCleaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCleaner.ForeColor = System.Drawing.Color.White;
            this.btnCleaner.Location = new System.Drawing.Point(382, 68);
            this.btnCleaner.Name = "btnCleaner";
            this.btnCleaner.Size = new System.Drawing.Size(84, 22);
            this.btnCleaner.TabIndex = 162;
            this.btnCleaner.Text = "CLEAN";
            this.ToolTip.SetToolTip(this.btnCleaner, "Click here to launch MIDI Cleaner");
            this.btnCleaner.UseVisualStyleBackColor = false;
            this.btnCleaner.Click += new System.EventHandler(this.btnCleaner_Click);
            // 
            // btnTester
            // 
            this.btnTester.BackColor = System.Drawing.Color.Black;
            this.btnTester.BackgroundImage = global::MagmaRokOn.Properties.Resources.button_bg_large;
            this.btnTester.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTester.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTester.FlatAppearance.BorderSize = 0;
            this.btnTester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTester.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTester.ForeColor = System.Drawing.Color.White;
            this.btnTester.Location = new System.Drawing.Point(284, 68);
            this.btnTester.Name = "btnTester";
            this.btnTester.Size = new System.Drawing.Size(84, 22);
            this.btnTester.TabIndex = 139;
            this.btnTester.Text = "TEST";
            this.ToolTip.SetToolTip(this.btnTester, "Click here to launch MIDI Tester");
            this.btnTester.UseVisualStyleBackColor = false;
            this.btnTester.Click += new System.EventHandler(this.btnTester_Click);
            // 
            // ButtonBrowseForMIDI
            // 
            this.ButtonBrowseForMIDI.BackColor = System.Drawing.Color.Black;
            this.ButtonBrowseForMIDI.BackgroundImage = global::MagmaRokOn.Properties.Resources.button_bg_small;
            this.ButtonBrowseForMIDI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonBrowseForMIDI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonBrowseForMIDI.FlatAppearance.BorderSize = 0;
            this.ButtonBrowseForMIDI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonBrowseForMIDI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBrowseForMIDI.ForeColor = System.Drawing.Color.White;
            this.ButtonBrowseForMIDI.Location = new System.Drawing.Point(470, 14);
            this.ButtonBrowseForMIDI.Name = "ButtonBrowseForMIDI";
            this.ButtonBrowseForMIDI.Size = new System.Drawing.Size(28, 22);
            this.ButtonBrowseForMIDI.TabIndex = 138;
            this.ButtonBrowseForMIDI.Text = "...";
            this.ToolTip.SetToolTip(this.ButtonBrowseForMIDI, "Click to browse for the MIDI file");
            this.ButtonBrowseForMIDI.UseVisualStyleBackColor = false;
            this.ButtonBrowseForMIDI.Click += new System.EventHandler(this.ButtonBrowseForMIDI_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox2.Controls.Add(this.chkTempo);
            this.groupBox2.Controls.Add(this.chkKeysAnim);
            this.groupBox2.Controls.Add(this.chkAutoKeys);
            this.groupBox2.Location = new System.Drawing.Point(509, 440);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 82);
            this.groupBox2.TabIndex = 137;
            this.groupBox2.TabStop = false;
            // 
            // chkTempo
            // 
            this.chkTempo.AutoSize = true;
            this.chkTempo.BackColor = System.Drawing.Color.Transparent;
            this.chkTempo.Checked = true;
            this.chkTempo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTempo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.chkTempo.ForeColor = System.Drawing.Color.White;
            this.chkTempo.Location = new System.Drawing.Point(12, 9);
            this.chkTempo.Name = "chkTempo";
            this.chkTempo.Size = new System.Drawing.Size(143, 19);
            this.chkTempo.TabIndex = 138;
            this.chkTempo.Text = "Check for tempo map";
            this.ToolTip.SetToolTip(this.chkTempo, "Uncheck if you don\'t want me to check for a tempo map");
            this.chkTempo.UseVisualStyleBackColor = false;
            this.chkTempo.CheckedChanged += new System.EventHandler(this.chkTempo_CheckedChanged);
            // 
            // chkKeysAnim
            // 
            this.chkKeysAnim.AutoSize = true;
            this.chkKeysAnim.BackColor = System.Drawing.Color.Transparent;
            this.chkKeysAnim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkKeysAnim.Enabled = false;
            this.chkKeysAnim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.chkKeysAnim.ForeColor = System.Drawing.Color.White;
            this.chkKeysAnim.Location = new System.Drawing.Point(12, 58);
            this.chkKeysAnim.Name = "chkKeysAnim";
            this.chkKeysAnim.Size = new System.Drawing.Size(197, 19);
            this.chkKeysAnim.TabIndex = 137;
            this.chkKeysAnim.Text = " Auto-generate keys animations";
            this.ToolTip.SetToolTip(this.chkKeysAnim, "Check to generate simple keys animations based on the 5 lane expert chart");
            this.chkKeysAnim.UseVisualStyleBackColor = false;
            this.chkKeysAnim.CheckedChanged += new System.EventHandler(this.chkKeysAnim_CheckedChanged);
            // 
            // chkAutoKeys
            // 
            this.chkAutoKeys.AutoSize = true;
            this.chkAutoKeys.BackColor = System.Drawing.Color.Transparent;
            this.chkAutoKeys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAutoKeys.Enabled = false;
            this.chkAutoKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.chkAutoKeys.ForeColor = System.Drawing.Color.White;
            this.chkAutoKeys.Location = new System.Drawing.Point(12, 33);
            this.chkAutoKeys.Name = "chkAutoKeys";
            this.chkAutoKeys.Size = new System.Drawing.Size(187, 19);
            this.chkAutoKeys.TabIndex = 136;
            this.chkAutoKeys.Text = " Auto-generate \'fake\' pro-keys";
            this.ToolTip.SetToolTip(this.chkAutoKeys, "Check to generate fake pro keys tracks based on the 5 lane expert chart");
            this.chkAutoKeys.UseVisualStyleBackColor = false;
            this.chkAutoKeys.CheckedChanged += new System.EventHandler(this.chkAutoKeys_CheckedChanged);
            // 
            // picHelpMuteVol
            // 
            this.picHelpMuteVol.BackColor = System.Drawing.Color.Transparent;
            this.picHelpMuteVol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHelpMuteVol.Location = new System.Drawing.Point(441, 344);
            this.picHelpMuteVol.Name = "picHelpMuteVol";
            this.picHelpMuteVol.Size = new System.Drawing.Size(25, 25);
            this.picHelpMuteVol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHelpMuteVol.TabIndex = 135;
            this.picHelpMuteVol.TabStop = false;
            this.ToolTip.SetToolTip(this.picHelpMuteVol, "Click for help with Vocals Mute Volume and Mute Volume");
            this.picHelpMuteVol.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picHelp_MouseClick);
            // 
            // LabelMuteVolume
            // 
            this.LabelMuteVolume.AutoSize = true;
            this.LabelMuteVolume.BackColor = System.Drawing.Color.Transparent;
            this.LabelMuteVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelMuteVolume.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelMuteVolume.Location = new System.Drawing.Point(290, 347);
            this.LabelMuteVolume.Name = "LabelMuteVolume";
            this.LabelMuteVolume.Size = new System.Drawing.Size(93, 13);
            this.LabelMuteVolume.TabIndex = 134;
            this.LabelMuteVolume.Text = "MUTE VOLUME";
            this.LabelMuteVolume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericMuteVol
            // 
            this.numericMuteVol.BackColor = System.Drawing.Color.White;
            this.numericMuteVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMuteVol.ForeColor = System.Drawing.Color.Black;
            this.numericMuteVol.Increment = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericMuteVol.Location = new System.Drawing.Point(385, 344);
            this.numericMuteVol.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericMuteVol.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericMuteVol.Name = "numericMuteVol";
            this.numericMuteVol.Size = new System.Drawing.Size(48, 20);
            this.numericMuteVol.TabIndex = 133;
            this.numericMuteVol.Tag = "Audio - Mute Volume";
            this.numericMuteVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.numericMuteVol, "Use to change the mute volume levels value. For help click on the question mark");
            this.numericMuteVol.Value = new decimal(new int[] {
            96,
            0,
            0,
            -2147483648});
            this.numericMuteVol.ValueChanged += new System.EventHandler(this.numericMuteVol_ValueChanged);
            // 
            // LabelMuteVolumeVocals
            // 
            this.LabelMuteVolumeVocals.BackColor = System.Drawing.Color.Transparent;
            this.LabelMuteVolumeVocals.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelMuteVolumeVocals.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelMuteVolumeVocals.Location = new System.Drawing.Point(30, 347);
            this.LabelMuteVolumeVocals.Name = "LabelMuteVolumeVocals";
            this.LabelMuteVolumeVocals.Size = new System.Drawing.Size(150, 13);
            this.LabelMuteVolumeVocals.TabIndex = 131;
            this.LabelMuteVolumeVocals.Text = "MUTE VOLUME VOCALS";
            this.LabelMuteVolumeVocals.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericVocalMute
            // 
            this.numericVocalMute.BackColor = System.Drawing.Color.White;
            this.numericVocalMute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericVocalMute.ForeColor = System.Drawing.Color.Black;
            this.numericVocalMute.Increment = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericVocalMute.Location = new System.Drawing.Point(186, 344);
            this.numericVocalMute.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericVocalMute.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericVocalMute.Name = "numericVocalMute";
            this.numericVocalMute.Size = new System.Drawing.Size(49, 20);
            this.numericVocalMute.TabIndex = 130;
            this.numericVocalMute.Tag = "Audio - Vocals - Mute Volume";
            this.numericVocalMute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.numericVocalMute, "Use to change the vocals mute volume levels value. For help click on the question" +
        " mark");
            this.numericVocalMute.Value = new decimal(new int[] {
            12,
            0,
            0,
            -2147483648});
            this.numericVocalMute.ValueChanged += new System.EventHandler(this.numericVocalMute_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.numVersion);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(676, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(56, 59);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Version";
            // 
            // numVersion
            // 
            this.numVersion.BackColor = System.Drawing.Color.White;
            this.numVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numVersion.ForeColor = System.Drawing.Color.Black;
            this.numVersion.Location = new System.Drawing.Point(4, 24);
            this.numVersion.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numVersion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVersion.Name = "numVersion";
            this.numVersion.Size = new System.Drawing.Size(48, 20);
            this.numVersion.TabIndex = 134;
            this.numVersion.Tag = "Song Version";
            this.numVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.numVersion, "Use to change the song version");
            this.numVersion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVersion.ValueChanged += new System.EventHandler(this.numVersion_ValueChanged);
            this.numVersion.Leave += new System.EventHandler(this.numVersion_Leave);
            // 
            // groupID
            // 
            this.groupID.BackColor = System.Drawing.Color.Transparent;
            this.groupID.Controls.Add(this.btnID);
            this.groupID.Controls.Add(this.txtSongID);
            this.groupID.ForeColor = System.Drawing.Color.White;
            this.groupID.Location = new System.Drawing.Point(509, 12);
            this.groupID.Name = "groupID";
            this.groupID.Size = new System.Drawing.Size(161, 59);
            this.groupID.TabIndex = 125;
            this.groupID.TabStop = false;
            this.groupID.Text = "Song ID";
            // 
            // btnID
            // 
            this.btnID.BackColor = System.Drawing.Color.Black;
            this.btnID.BackgroundImage = global::MagmaRokOn.Properties.Resources.button_bg_small;
            this.btnID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnID.FlatAppearance.BorderSize = 0;
            this.btnID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btnID.ForeColor = System.Drawing.Color.White;
            this.btnID.Location = new System.Drawing.Point(99, 23);
            this.btnID.Name = "btnID";
            this.btnID.Size = new System.Drawing.Size(56, 22);
            this.btnID.TabIndex = 170;
            this.btnID.Text = "New ID";
            this.ToolTip.SetToolTip(this.btnID, "Click to issue a new numeric ID");
            this.btnID.UseVisualStyleBackColor = false;
            this.btnID.Click += new System.EventHandler(this.btnID_Click);
            // 
            // txtSongID
            // 
            this.txtSongID.BackColor = System.Drawing.Color.White;
            this.txtSongID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtSongID.Location = new System.Drawing.Point(6, 24);
            this.txtSongID.MaxLength = 25;
            this.txtSongID.Name = "txtSongID";
            this.txtSongID.Size = new System.Drawing.Size(90, 20);
            this.txtSongID.TabIndex = 0;
            this.txtSongID.Tag = "Song ID";
            this.txtSongID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.txtSongID, "This is the current song ID in use. Click to change it. There is a 25 character l" +
        "imit");
            this.txtSongID.TextChanged += new System.EventHandler(this.txtSongID_TextChanged);
            // 
            // picDrumSFX
            // 
            this.picDrumSFX.BackColor = System.Drawing.Color.Transparent;
            this.picDrumSFX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDrumSFX.Location = new System.Drawing.Point(441, 400);
            this.picDrumSFX.Name = "picDrumSFX";
            this.picDrumSFX.Size = new System.Drawing.Size(25, 25);
            this.picDrumSFX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDrumSFX.TabIndex = 123;
            this.picDrumSFX.TabStop = false;
            this.ToolTip.SetToolTip(this.picDrumSFX, "Click for help with Drum Kit SFX");
            this.picDrumSFX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picHelp_MouseClick);
            // 
            // picHelpTuningCents
            // 
            this.picHelpTuningCents.BackColor = System.Drawing.Color.Transparent;
            this.picHelpTuningCents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHelpTuningCents.Location = new System.Drawing.Point(441, 284);
            this.picHelpTuningCents.Name = "picHelpTuningCents";
            this.picHelpTuningCents.Size = new System.Drawing.Size(25, 25);
            this.picHelpTuningCents.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHelpTuningCents.TabIndex = 122;
            this.picHelpTuningCents.TabStop = false;
            this.ToolTip.SetToolTip(this.picHelpTuningCents, "Click for help using Tuning Cents Offset");
            this.picHelpTuningCents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picHelp_MouseClick);
            // 
            // LabelTuningCents
            // 
            this.LabelTuningCents.AutoSize = true;
            this.LabelTuningCents.BackColor = System.Drawing.Color.Transparent;
            this.LabelTuningCents.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelTuningCents.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelTuningCents.Location = new System.Drawing.Point(291, 289);
            this.LabelTuningCents.Name = "LabelTuningCents";
            this.LabelTuningCents.Size = new System.Drawing.Size(92, 13);
            this.LabelTuningCents.TabIndex = 120;
            this.LabelTuningCents.Text = "TUNING CENTS";
            this.LabelTuningCents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericTuningCents
            // 
            this.numericTuningCents.BackColor = System.Drawing.Color.White;
            this.numericTuningCents.Enabled = false;
            this.numericTuningCents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericTuningCents.ForeColor = System.Drawing.Color.Black;
            this.numericTuningCents.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericTuningCents.Location = new System.Drawing.Point(385, 286);
            this.numericTuningCents.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericTuningCents.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.numericTuningCents.Name = "numericTuningCents";
            this.numericTuningCents.Size = new System.Drawing.Size(48, 20);
            this.numericTuningCents.TabIndex = 10;
            this.numericTuningCents.Tag = "Audio - Vocals - Tuning Cents";
            this.numericTuningCents.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.numericTuningCents, "Use to change the tuning cents offset value. For help click on the question mark");
            this.numericTuningCents.ValueChanged += new System.EventHandler(this.numericTuningCents_ValueChanged);
            // 
            // ComboDrumSFX
            // 
            this.ComboDrumSFX.BackColor = System.Drawing.Color.White;
            this.ComboDrumSFX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboDrumSFX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboDrumSFX.ForeColor = System.Drawing.Color.Black;
            this.ComboDrumSFX.FormattingEnabled = true;
            this.ComboDrumSFX.Items.AddRange(new object[] {
            "Hard Rock Kit (default)",
            "Arena Kit",
            "Vintage Kit",
            "Trashy Kit",
            "Electronic Kit"});
            this.ComboDrumSFX.Location = new System.Drawing.Point(186, 402);
            this.ComboDrumSFX.Name = "ComboDrumSFX";
            this.ComboDrumSFX.Size = new System.Drawing.Size(247, 21);
            this.ComboDrumSFX.TabIndex = 26;
            this.ComboDrumSFX.Tag = "Song Rating";
            this.ToolTip.SetToolTip(this.ComboDrumSFX, "Click to change the drum kit sfx of your song. Click the question mark for more i" +
        "nformation");
            this.ComboDrumSFX.SelectedIndexChanged += new System.EventHandler(this.ComboDrumSFX_SelectedIndexChanged);
            // 
            // LabelDrumKitSFX
            // 
            this.LabelDrumKitSFX.BackColor = System.Drawing.Color.Transparent;
            this.LabelDrumKitSFX.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelDrumKitSFX.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelDrumKitSFX.Location = new System.Drawing.Point(72, 406);
            this.LabelDrumKitSFX.Name = "LabelDrumKitSFX";
            this.LabelDrumKitSFX.Size = new System.Drawing.Size(108, 13);
            this.LabelDrumKitSFX.TabIndex = 118;
            this.LabelDrumKitSFX.Text = "DRUM KIT SFX";
            this.LabelDrumKitSFX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ComboHopo
            // 
            this.ComboHopo.BackColor = System.Drawing.Color.White;
            this.ComboHopo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboHopo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboHopo.ForeColor = System.Drawing.Color.Black;
            this.ComboHopo.FormattingEnabled = true;
            this.ComboHopo.Items.AddRange(new object[] {
            "90",
            "130",
            "170 (default)",
            "250"});
            this.ComboHopo.Location = new System.Drawing.Point(186, 137);
            this.ComboHopo.Name = "ComboHopo";
            this.ComboHopo.Size = new System.Drawing.Size(280, 21);
            this.ComboHopo.TabIndex = 4;
            this.ComboHopo.Tag = "MIDI - Hopo Threshold";
            this.ToolTip.SetToolTip(this.ComboHopo, "Click here to change the HOPO threshold");
            this.ComboHopo.SelectedIndexChanged += new System.EventHandler(this.ComboHopo_SelectedIndexChanged);
            // 
            // LabelHopoThreshold
            // 
            this.LabelHopoThreshold.BackColor = System.Drawing.Color.Transparent;
            this.LabelHopoThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelHopoThreshold.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelHopoThreshold.Location = new System.Drawing.Point(14, 139);
            this.LabelHopoThreshold.Name = "LabelHopoThreshold";
            this.LabelHopoThreshold.Size = new System.Drawing.Size(168, 15);
            this.LabelHopoThreshold.TabIndex = 116;
            this.LabelHopoThreshold.Text = "HOPO THRESHOLD";
            this.LabelHopoThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picHelpGuitarTuning
            // 
            this.picHelpGuitarTuning.BackColor = System.Drawing.Color.Transparent;
            this.picHelpGuitarTuning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHelpGuitarTuning.Location = new System.Drawing.Point(393, 481);
            this.picHelpGuitarTuning.Name = "picHelpGuitarTuning";
            this.picHelpGuitarTuning.Size = new System.Drawing.Size(25, 25);
            this.picHelpGuitarTuning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHelpGuitarTuning.TabIndex = 114;
            this.picHelpGuitarTuning.TabStop = false;
            this.ToolTip.SetToolTip(this.picHelpGuitarTuning, "Click for help with Pro Guitar / Bass Tuning");
            this.picHelpGuitarTuning.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picHelp_MouseClick);
            // 
            // BassTuning4
            // 
            this.BassTuning4.BackColor = System.Drawing.Color.White;
            this.BassTuning4.Enabled = false;
            this.BassTuning4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BassTuning4.Location = new System.Drawing.Point(288, 509);
            this.BassTuning4.MaxLength = 4;
            this.BassTuning4.Name = "BassTuning4";
            this.BassTuning4.Size = new System.Drawing.Size(30, 20);
            this.BassTuning4.TabIndex = 23;
            this.BassTuning4.Text = "0";
            this.BassTuning4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.BassTuning4, "Click on the question mark for help with this");
            this.BassTuning4.TextChanged += new System.EventHandler(this.ValidateTuning);
            // 
            // BassTuning3
            // 
            this.BassTuning3.BackColor = System.Drawing.Color.White;
            this.BassTuning3.Enabled = false;
            this.BassTuning3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BassTuning3.Location = new System.Drawing.Point(254, 509);
            this.BassTuning3.MaxLength = 4;
            this.BassTuning3.Name = "BassTuning3";
            this.BassTuning3.Size = new System.Drawing.Size(30, 20);
            this.BassTuning3.TabIndex = 22;
            this.BassTuning3.Text = "0";
            this.BassTuning3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.BassTuning3, "Click on the question mark for help with this");
            this.BassTuning3.TextChanged += new System.EventHandler(this.ValidateTuning);
            // 
            // BassTuning2
            // 
            this.BassTuning2.BackColor = System.Drawing.Color.White;
            this.BassTuning2.Enabled = false;
            this.BassTuning2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BassTuning2.Location = new System.Drawing.Point(220, 509);
            this.BassTuning2.MaxLength = 4;
            this.BassTuning2.Name = "BassTuning2";
            this.BassTuning2.Size = new System.Drawing.Size(30, 20);
            this.BassTuning2.TabIndex = 21;
            this.BassTuning2.Text = "0";
            this.BassTuning2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.BassTuning2, "Click on the question mark for help with this");
            this.BassTuning2.TextChanged += new System.EventHandler(this.ValidateTuning);
            // 
            // BassTuning1
            // 
            this.BassTuning1.BackColor = System.Drawing.Color.White;
            this.BassTuning1.Enabled = false;
            this.BassTuning1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BassTuning1.Location = new System.Drawing.Point(186, 509);
            this.BassTuning1.MaxLength = 4;
            this.BassTuning1.Name = "BassTuning1";
            this.BassTuning1.Size = new System.Drawing.Size(30, 20);
            this.BassTuning1.TabIndex = 20;
            this.BassTuning1.Text = "0";
            this.BassTuning1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.BassTuning1, "Click on the question mark for help with this");
            this.BassTuning1.TextChanged += new System.EventHandler(this.ValidateTuning);
            // 
            // GuitarTuning6
            // 
            this.GuitarTuning6.BackColor = System.Drawing.Color.White;
            this.GuitarTuning6.Enabled = false;
            this.GuitarTuning6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuitarTuning6.Location = new System.Drawing.Point(355, 483);
            this.GuitarTuning6.MaxLength = 4;
            this.GuitarTuning6.Name = "GuitarTuning6";
            this.GuitarTuning6.Size = new System.Drawing.Size(30, 20);
            this.GuitarTuning6.TabIndex = 19;
            this.GuitarTuning6.Text = "0";
            this.GuitarTuning6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.GuitarTuning6, "Click on the question mark for help with this");
            this.GuitarTuning6.TextChanged += new System.EventHandler(this.ValidateTuning);
            // 
            // GuitarTuning5
            // 
            this.GuitarTuning5.BackColor = System.Drawing.Color.White;
            this.GuitarTuning5.Enabled = false;
            this.GuitarTuning5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuitarTuning5.Location = new System.Drawing.Point(321, 483);
            this.GuitarTuning5.MaxLength = 4;
            this.GuitarTuning5.Name = "GuitarTuning5";
            this.GuitarTuning5.Size = new System.Drawing.Size(30, 20);
            this.GuitarTuning5.TabIndex = 18;
            this.GuitarTuning5.Text = "0";
            this.GuitarTuning5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.GuitarTuning5, "Click on the question mark for help with this");
            this.GuitarTuning5.TextChanged += new System.EventHandler(this.ValidateTuning);
            // 
            // GuitarTuning4
            // 
            this.GuitarTuning4.BackColor = System.Drawing.Color.White;
            this.GuitarTuning4.Enabled = false;
            this.GuitarTuning4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuitarTuning4.Location = new System.Drawing.Point(288, 483);
            this.GuitarTuning4.MaxLength = 4;
            this.GuitarTuning4.Name = "GuitarTuning4";
            this.GuitarTuning4.Size = new System.Drawing.Size(30, 20);
            this.GuitarTuning4.TabIndex = 17;
            this.GuitarTuning4.Text = "0";
            this.GuitarTuning4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.GuitarTuning4, "Click on the question mark for help with this");
            this.GuitarTuning4.TextChanged += new System.EventHandler(this.ValidateTuning);
            // 
            // GuitarTuning3
            // 
            this.GuitarTuning3.BackColor = System.Drawing.Color.White;
            this.GuitarTuning3.Enabled = false;
            this.GuitarTuning3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuitarTuning3.Location = new System.Drawing.Point(254, 483);
            this.GuitarTuning3.MaxLength = 4;
            this.GuitarTuning3.Name = "GuitarTuning3";
            this.GuitarTuning3.Size = new System.Drawing.Size(30, 20);
            this.GuitarTuning3.TabIndex = 16;
            this.GuitarTuning3.Text = "0";
            this.GuitarTuning3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.GuitarTuning3, "Click on the question mark for help with this");
            this.GuitarTuning3.TextChanged += new System.EventHandler(this.ValidateTuning);
            // 
            // GuitarTuning2
            // 
            this.GuitarTuning2.BackColor = System.Drawing.Color.White;
            this.GuitarTuning2.Enabled = false;
            this.GuitarTuning2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuitarTuning2.Location = new System.Drawing.Point(220, 483);
            this.GuitarTuning2.MaxLength = 4;
            this.GuitarTuning2.Name = "GuitarTuning2";
            this.GuitarTuning2.Size = new System.Drawing.Size(30, 20);
            this.GuitarTuning2.TabIndex = 15;
            this.GuitarTuning2.Text = "0";
            this.GuitarTuning2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.GuitarTuning2, "Click on the question mark for help with this");
            this.GuitarTuning2.TextChanged += new System.EventHandler(this.ValidateTuning);
            // 
            // GuitarTuning1
            // 
            this.GuitarTuning1.BackColor = System.Drawing.Color.White;
            this.GuitarTuning1.Enabled = false;
            this.GuitarTuning1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuitarTuning1.Location = new System.Drawing.Point(186, 483);
            this.GuitarTuning1.MaxLength = 4;
            this.GuitarTuning1.Name = "GuitarTuning1";
            this.GuitarTuning1.Size = new System.Drawing.Size(30, 20);
            this.GuitarTuning1.TabIndex = 14;
            this.GuitarTuning1.Text = "0";
            this.GuitarTuning1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.GuitarTuning1, "Click on the question mark for help with this");
            this.GuitarTuning1.TextChanged += new System.EventHandler(this.ValidateTuning);
            // 
            // LabelBassTuning
            // 
            this.LabelBassTuning.BackColor = System.Drawing.Color.Transparent;
            this.LabelBassTuning.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelBassTuning.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelBassTuning.Location = new System.Drawing.Point(69, 513);
            this.LabelBassTuning.Name = "LabelBassTuning";
            this.LabelBassTuning.Size = new System.Drawing.Size(111, 13);
            this.LabelBassTuning.TabIndex = 113;
            this.LabelBassTuning.Text = "PRO BASS TUNING";
            this.LabelBassTuning.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelGuitarTuning
            // 
            this.LabelGuitarTuning.BackColor = System.Drawing.Color.Transparent;
            this.LabelGuitarTuning.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelGuitarTuning.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelGuitarTuning.Location = new System.Drawing.Point(69, 485);
            this.LabelGuitarTuning.Name = "LabelGuitarTuning";
            this.LabelGuitarTuning.Size = new System.Drawing.Size(111, 13);
            this.LabelGuitarTuning.TabIndex = 112;
            this.LabelGuitarTuning.Text = "PRO GUITAR TUNING";
            this.LabelGuitarTuning.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ComboRating
            // 
            this.ComboRating.BackColor = System.Drawing.Color.White;
            this.ComboRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboRating.ForeColor = System.Drawing.Color.Black;
            this.ComboRating.FormattingEnabled = true;
            this.ComboRating.Items.AddRange(new object[] {
            "1 - Family Friendly",
            "2 - Supervision Recommended",
            "3 - Mature",
            "4 - Unrated"});
            this.ComboRating.Location = new System.Drawing.Point(186, 376);
            this.ComboRating.Name = "ComboRating";
            this.ComboRating.Size = new System.Drawing.Size(247, 21);
            this.ComboRating.TabIndex = 13;
            this.ComboRating.Tag = "Song Rating";
            this.ToolTip.SetToolTip(this.ComboRating, "Click to change the song\'s rating");
            this.ComboRating.SelectedIndexChanged += new System.EventHandler(this.ComboRating_SelectedIndexChanged);
            // 
            // LabelSongRating
            // 
            this.LabelSongRating.BackColor = System.Drawing.Color.Transparent;
            this.LabelSongRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelSongRating.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelSongRating.Location = new System.Drawing.Point(69, 380);
            this.LabelSongRating.Name = "LabelSongRating";
            this.LabelSongRating.Size = new System.Drawing.Size(111, 13);
            this.LabelSongRating.TabIndex = 111;
            this.LabelSongRating.Text = "SONG RATING";
            this.LabelSongRating.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picHelpTonicNote
            // 
            this.picHelpTonicNote.BackColor = System.Drawing.Color.Transparent;
            this.picHelpTonicNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHelpTonicNote.Location = new System.Drawing.Point(441, 315);
            this.picHelpTonicNote.Name = "picHelpTonicNote";
            this.picHelpTonicNote.Size = new System.Drawing.Size(25, 25);
            this.picHelpTonicNote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHelpTonicNote.TabIndex = 109;
            this.picHelpTonicNote.TabStop = false;
            this.ToolTip.SetToolTip(this.picHelpTonicNote, "Click for help with Vocal Tonic Note and Song Tonality");
            this.picHelpTonicNote.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picHelp_MouseClick);
            // 
            // chkTonicNote
            // 
            this.chkTonicNote.BackColor = System.Drawing.Color.Transparent;
            this.chkTonicNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkTonicNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.chkTonicNote.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkTonicNote.Location = new System.Drawing.Point(40, 318);
            this.chkTonicNote.Name = "chkTonicNote";
            this.chkTonicNote.Size = new System.Drawing.Size(140, 17);
            this.chkTonicNote.TabIndex = 11;
            this.chkTonicNote.Text = "VOCAL TONIC NOTE";
            this.chkTonicNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip.SetToolTip(this.chkTonicNote, "Check to enable Vocal Tonic Note");
            this.chkTonicNote.UseVisualStyleBackColor = false;
            this.chkTonicNote.CheckedChanged += new System.EventHandler(this.chkTonicNote_CheckedChanged);
            // 
            // ComboTonicNote
            // 
            this.ComboTonicNote.BackColor = System.Drawing.Color.White;
            this.ComboTonicNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTonicNote.Enabled = false;
            this.ComboTonicNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboTonicNote.ForeColor = System.Drawing.Color.Black;
            this.ComboTonicNote.FormattingEnabled = true;
            this.ComboTonicNote.Items.AddRange(new object[] {
            "0 - C",
            "1 - C# /Db",
            "2 - D",
            "3 - D# / Eb",
            "4- E",
            "5 - F",
            "6 - F# / Gb",
            "7 - G",
            "8 - G# / Ab",
            "9 - A",
            "10 - A# / Bb",
            "11 - B"});
            this.ComboTonicNote.Location = new System.Drawing.Point(186, 315);
            this.ComboTonicNote.Name = "ComboTonicNote";
            this.ComboTonicNote.Size = new System.Drawing.Size(84, 21);
            this.ComboTonicNote.TabIndex = 12;
            this.ComboTonicNote.Tag = "Audio - Vocals - Tonic Note";
            this.ToolTip.SetToolTip(this.ComboTonicNote, "Click to change the vocal tonic note. Click on the question mark for help on how " +
        "to use");
            this.ComboTonicNote.SelectedIndexChanged += new System.EventHandler(this.ComboTonicNote_SelectedIndexChanged);
            // 
            // NumericGuidePitchAttenuation
            // 
            this.NumericGuidePitchAttenuation.BackColor = System.Drawing.Color.White;
            this.NumericGuidePitchAttenuation.DecimalPlaces = 1;
            this.NumericGuidePitchAttenuation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericGuidePitchAttenuation.ForeColor = System.Drawing.Color.Black;
            this.NumericGuidePitchAttenuation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumericGuidePitchAttenuation.Location = new System.Drawing.Point(186, 286);
            this.NumericGuidePitchAttenuation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147418112});
            this.NumericGuidePitchAttenuation.Name = "NumericGuidePitchAttenuation";
            this.NumericGuidePitchAttenuation.Size = new System.Drawing.Size(46, 20);
            this.NumericGuidePitchAttenuation.TabIndex = 8;
            this.NumericGuidePitchAttenuation.Tag = "Audio - Vocals - Guide Pitch Attenuation";
            this.NumericGuidePitchAttenuation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.NumericGuidePitchAttenuation, "Use this to change the vocal guide pitch volume");
            this.NumericGuidePitchAttenuation.Value = new decimal(new int[] {
            30,
            0,
            0,
            -2147418112});
            this.NumericGuidePitchAttenuation.ValueChanged += new System.EventHandler(this.NumericGuidePitchAttenuation_ValueChanged);
            // 
            // LabelVocalGuidePitch
            // 
            this.LabelVocalGuidePitch.BackColor = System.Drawing.Color.Transparent;
            this.LabelVocalGuidePitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelVocalGuidePitch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelVocalGuidePitch.Location = new System.Drawing.Point(12, 289);
            this.LabelVocalGuidePitch.Name = "LabelVocalGuidePitch";
            this.LabelVocalGuidePitch.Size = new System.Drawing.Size(168, 13);
            this.LabelVocalGuidePitch.TabIndex = 105;
            this.LabelVocalGuidePitch.Text = "VOCAL GUIDE PITCH VOLUME";
            this.LabelVocalGuidePitch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ComboBoxAutogenTheme
            // 
            this.ComboBoxAutogenTheme.BackColor = System.Drawing.Color.White;
            this.ComboBoxAutogenTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAutogenTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.ComboBoxAutogenTheme.ForeColor = System.Drawing.Color.Black;
            this.ComboBoxAutogenTheme.FormattingEnabled = true;
            this.ComboBoxAutogenTheme.Location = new System.Drawing.Point(186, 41);
            this.ComboBoxAutogenTheme.Name = "ComboBoxAutogenTheme";
            this.ComboBoxAutogenTheme.Size = new System.Drawing.Size(280, 21);
            this.ComboBoxAutogenTheme.TabIndex = 2;
            this.ComboBoxAutogenTheme.Tag = "MIDI - Autogen Theme";
            this.ToolTip.SetToolTip(this.ComboBoxAutogenTheme, "Click to select an autogeneration theme for your venue");
            this.ComboBoxAutogenTheme.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAutogenTheme_SelectedIndexChanged);
            // 
            // LabelAutogenTheme
            // 
            this.LabelAutogenTheme.BackColor = System.Drawing.Color.Transparent;
            this.LabelAutogenTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelAutogenTheme.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelAutogenTheme.Location = new System.Drawing.Point(10, 44);
            this.LabelAutogenTheme.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.LabelAutogenTheme.Name = "LabelAutogenTheme";
            this.LabelAutogenTheme.Size = new System.Drawing.Size(170, 13);
            this.LabelAutogenTheme.TabIndex = 104;
            this.LabelAutogenTheme.Text = "AUTOGENERATION THEME";
            this.LabelAutogenTheme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ComboAnimationSpeed
            // 
            this.ComboAnimationSpeed.BackColor = System.Drawing.Color.White;
            this.ComboAnimationSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboAnimationSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboAnimationSpeed.ForeColor = System.Drawing.Color.Black;
            this.ComboAnimationSpeed.FormattingEnabled = true;
            this.ComboAnimationSpeed.Items.AddRange(new object[] {
            "Slow (under 100bpm) - 16",
            "Custom (Medium Slow) - 24",
            "Medium (100-160bpm) - 32",
            "Custom (Medium Fast) - 48",
            "Fast (over 160bpm) - 64"});
            this.ComboAnimationSpeed.Location = new System.Drawing.Point(186, 109);
            this.ComboAnimationSpeed.Name = "ComboAnimationSpeed";
            this.ComboAnimationSpeed.Size = new System.Drawing.Size(280, 21);
            this.ComboAnimationSpeed.TabIndex = 3;
            this.ComboAnimationSpeed.Tag = "MIDI - Animation";
            this.ToolTip.SetToolTip(this.ComboAnimationSpeed, "Click here to change the animation speed");
            this.ComboAnimationSpeed.SelectedIndexChanged += new System.EventHandler(this.ComboAnimationSpeed_SelectedIndexChanged);
            // 
            // LabelAnimationSpeed
            // 
            this.LabelAnimationSpeed.BackColor = System.Drawing.Color.Transparent;
            this.LabelAnimationSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelAnimationSpeed.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelAnimationSpeed.Location = new System.Drawing.Point(14, 111);
            this.LabelAnimationSpeed.Name = "LabelAnimationSpeed";
            this.LabelAnimationSpeed.Size = new System.Drawing.Size(168, 15);
            this.LabelAnimationSpeed.TabIndex = 24;
            this.LabelAnimationSpeed.Text = "ANIMATION SPEED";
            this.LabelAnimationSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelMIDI
            // 
            this.LabelMIDI.BackColor = System.Drawing.Color.Transparent;
            this.LabelMIDI.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelMIDI.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelMIDI.Location = new System.Drawing.Point(12, 18);
            this.LabelMIDI.Name = "LabelMIDI";
            this.LabelMIDI.Size = new System.Drawing.Size(168, 15);
            this.LabelMIDI.TabIndex = 19;
            this.LabelMIDI.Text = "MIDI";
            this.LabelMIDI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextBoxMidiFile
            // 
            this.TextBoxMidiFile.AllowDrop = true;
            this.TextBoxMidiFile.BackColor = System.Drawing.Color.White;
            this.TextBoxMidiFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxMidiFile.ForeColor = System.Drawing.Color.Black;
            this.TextBoxMidiFile.Location = new System.Drawing.Point(186, 15);
            this.TextBoxMidiFile.MaxLength = 250;
            this.TextBoxMidiFile.Name = "TextBoxMidiFile";
            this.TextBoxMidiFile.Size = new System.Drawing.Size(280, 20);
            this.TextBoxMidiFile.TabIndex = 1;
            this.TextBoxMidiFile.Tag = "MIDI - MIDI";
            this.ToolTip.SetToolTip(this.TextBoxMidiFile, "This is the location of the MIDI file");
            this.TextBoxMidiFile.TextChanged += new System.EventHandler(this.TextBoxMidiFile_TextChanged);
            this.TextBoxMidiFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxMidiFile_DragDrop);
            this.TextBoxMidiFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            // 
            // ComboVocalScroll
            // 
            this.ComboVocalScroll.BackColor = System.Drawing.Color.White;
            this.ComboVocalScroll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboVocalScroll.Enabled = false;
            this.ComboVocalScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboVocalScroll.ForeColor = System.Drawing.Color.Black;
            this.ComboVocalScroll.FormattingEnabled = true;
            this.ComboVocalScroll.Location = new System.Drawing.Point(186, 252);
            this.ComboVocalScroll.Name = "ComboVocalScroll";
            this.ComboVocalScroll.Size = new System.Drawing.Size(280, 21);
            this.ComboVocalScroll.TabIndex = 7;
            this.ComboVocalScroll.Tag = "Audio - Vocals - Scroll Speed";
            this.ToolTip.SetToolTip(this.ComboVocalScroll, "Change vocal scroll speed. This is very useful for really fast or really slow son" +
        "gs.");
            this.ComboVocalScroll.SelectedIndexChanged += new System.EventHandler(this.ComboVocalScroll_SelectedIndexChanged);
            // 
            // ComboVocalPercussion
            // 
            this.ComboVocalPercussion.BackColor = System.Drawing.Color.White;
            this.ComboVocalPercussion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboVocalPercussion.Enabled = false;
            this.ComboVocalPercussion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboVocalPercussion.ForeColor = System.Drawing.Color.Black;
            this.ComboVocalPercussion.FormattingEnabled = true;
            this.ComboVocalPercussion.Location = new System.Drawing.Point(186, 224);
            this.ComboVocalPercussion.Name = "ComboVocalPercussion";
            this.ComboVocalPercussion.Size = new System.Drawing.Size(280, 21);
            this.ComboVocalPercussion.TabIndex = 5;
            this.ComboVocalPercussion.Tag = "Audio - Vocals - Percussion";
            this.ToolTip.SetToolTip(this.ComboVocalPercussion, "Change the vocal percussion sound");
            this.ComboVocalPercussion.SelectedIndexChanged += new System.EventHandler(this.ComboVocalPercussion_SelectedIndexChanged);
            // 
            // ComboVocalGender
            // 
            this.ComboVocalGender.BackColor = System.Drawing.Color.White;
            this.ComboVocalGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboVocalGender.Enabled = false;
            this.ComboVocalGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboVocalGender.ForeColor = System.Drawing.Color.Black;
            this.ComboVocalGender.FormattingEnabled = true;
            this.ComboVocalGender.Location = new System.Drawing.Point(186, 196);
            this.ComboVocalGender.Name = "ComboVocalGender";
            this.ComboVocalGender.Size = new System.Drawing.Size(280, 21);
            this.ComboVocalGender.TabIndex = 6;
            this.ComboVocalGender.Tag = "Audio - Vocals - Gender";
            this.ToolTip.SetToolTip(this.ComboVocalGender, "Change the gender of your singer");
            this.ComboVocalGender.SelectedIndexChanged += new System.EventHandler(this.ComboVocalGender_SelectedIndexChanged);
            // 
            // LabelVocalScroll
            // 
            this.LabelVocalScroll.BackColor = System.Drawing.Color.Transparent;
            this.LabelVocalScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelVocalScroll.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelVocalScroll.Location = new System.Drawing.Point(14, 256);
            this.LabelVocalScroll.Name = "LabelVocalScroll";
            this.LabelVocalScroll.Size = new System.Drawing.Size(168, 13);
            this.LabelVocalScroll.TabIndex = 30;
            this.LabelVocalScroll.Text = "VOCAL SCROLL SPEED";
            this.LabelVocalScroll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelPercussion
            // 
            this.LabelPercussion.BackColor = System.Drawing.Color.Transparent;
            this.LabelPercussion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelPercussion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelPercussion.Location = new System.Drawing.Point(14, 227);
            this.LabelPercussion.Name = "LabelPercussion";
            this.LabelPercussion.Size = new System.Drawing.Size(168, 13);
            this.LabelPercussion.TabIndex = 29;
            this.LabelPercussion.Text = "VOCAL PERCUSSION";
            this.LabelPercussion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVocalGender
            // 
            this.LabelVocalGender.BackColor = System.Drawing.Color.Transparent;
            this.LabelVocalGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.LabelVocalGender.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelVocalGender.Location = new System.Drawing.Point(14, 199);
            this.LabelVocalGender.Name = "LabelVocalGender";
            this.LabelVocalGender.Size = new System.Drawing.Size(168, 13);
            this.LabelVocalGender.TabIndex = 25;
            this.LabelVocalGender.Text = "VOCAL GENDER";
            this.LabelVocalGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GroupBoxDifficulty
            // 
            this.GroupBoxDifficulty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GroupBoxDifficulty.Controls.Add(this.lblBandDiff);
            this.GroupBoxDifficulty.Controls.Add(this.scrollBand);
            this.GroupBoxDifficulty.Controls.Add(this.lblProKeysDiff);
            this.GroupBoxDifficulty.Controls.Add(this.scrollProKeys);
            this.GroupBoxDifficulty.Controls.Add(this.lblKeysDiff);
            this.GroupBoxDifficulty.Controls.Add(this.scrollKeys);
            this.GroupBoxDifficulty.Controls.Add(this.lblVocalsDiff);
            this.GroupBoxDifficulty.Controls.Add(this.scrollVocals);
            this.GroupBoxDifficulty.Controls.Add(this.lblProGuitarDiff);
            this.GroupBoxDifficulty.Controls.Add(this.scrollProGuitar);
            this.GroupBoxDifficulty.Controls.Add(this.lblGuitarDiff);
            this.GroupBoxDifficulty.Controls.Add(this.scrollGuitar);
            this.GroupBoxDifficulty.Controls.Add(this.lblProBassDiff);
            this.GroupBoxDifficulty.Controls.Add(this.scrollProBass);
            this.GroupBoxDifficulty.Controls.Add(this.lblBassDiff);
            this.GroupBoxDifficulty.Controls.Add(this.scrollBass);
            this.GroupBoxDifficulty.Controls.Add(this.lblDrumsDiff);
            this.GroupBoxDifficulty.Controls.Add(this.scrollDrums);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBandDifficulty6);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProKeysDifficulty6);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBandDifficulty5);
            this.GroupBoxDifficulty.Controls.Add(this.PictureKeysDifficulty6);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBandDifficulty4);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProKeysDifficulty5);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBandDifficulty3);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProKeysDifficulty4);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBandDifficulty2);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBandDifficulty7);
            this.GroupBoxDifficulty.Controls.Add(this.PictureKeysDifficulty5);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBandDifficulty1);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProKeysDifficulty3);
            this.GroupBoxDifficulty.Controls.Add(this.PictureVocalDifficulty6);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProKeysDifficulty2);
            this.GroupBoxDifficulty.Controls.Add(this.PictureKeysDifficulty4);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProKeysDifficulty7);
            this.GroupBoxDifficulty.Controls.Add(this.PictureVocalDifficulty5);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProKeysDifficulty1);
            this.GroupBoxDifficulty.Controls.Add(this.PictureKeysDifficulty3);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProGuitarDifficulty6);
            this.GroupBoxDifficulty.Controls.Add(this.PictureKeysDifficulty2);
            this.GroupBoxDifficulty.Controls.Add(this.PictureVocalDifficulty4);
            this.GroupBoxDifficulty.Controls.Add(this.PictureKeysDifficulty7);
            this.GroupBoxDifficulty.Controls.Add(this.PictureGuitarDifficulty6);
            this.GroupBoxDifficulty.Controls.Add(this.PictureKeysDifficulty1);
            this.GroupBoxDifficulty.Controls.Add(this.PictureVocalDifficulty3);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProGuitarDifficulty5);
            this.GroupBoxDifficulty.Controls.Add(this.PictureVocalDifficulty2);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProBassDifficulty6);
            this.GroupBoxDifficulty.Controls.Add(this.PictureVocalDifficulty7);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProGuitarDifficulty4);
            this.GroupBoxDifficulty.Controls.Add(this.PictureVocalDifficulty1);
            this.GroupBoxDifficulty.Controls.Add(this.PictureGuitarDifficulty5);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProGuitarDifficulty3);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProBassDifficulty5);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProGuitarDifficulty2);
            this.GroupBoxDifficulty.Controls.Add(this.PictureGuitarDifficulty4);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProGuitarDifficulty7);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProGuitarDifficulty1);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBassDifficulty6);
            this.GroupBoxDifficulty.Controls.Add(this.PictureGuitarDifficulty3);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProBassDifficulty4);
            this.GroupBoxDifficulty.Controls.Add(this.PictureGuitarDifficulty2);
            this.GroupBoxDifficulty.Controls.Add(this.PictureDrumDifficulty6);
            this.GroupBoxDifficulty.Controls.Add(this.PictureGuitarDifficulty7);
            this.GroupBoxDifficulty.Controls.Add(this.PictureGuitarDifficulty1);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProBassDifficulty3);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBassDifficulty5);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProBassDifficulty2);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBassDifficulty4);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProBassDifficulty7);
            this.GroupBoxDifficulty.Controls.Add(this.PictureDrumDifficulty5);
            this.GroupBoxDifficulty.Controls.Add(this.PictureProBassDifficulty1);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBassDifficulty3);
            this.GroupBoxDifficulty.Controls.Add(this.chkProGuitar);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBassDifficulty2);
            this.GroupBoxDifficulty.Controls.Add(this.PictureDrumDifficulty4);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBassDifficulty7);
            this.GroupBoxDifficulty.Controls.Add(this.LabelProGuitar);
            this.GroupBoxDifficulty.Controls.Add(this.PictureBassDifficulty1);
            this.GroupBoxDifficulty.Controls.Add(this.PictureDrumDifficulty3);
            this.GroupBoxDifficulty.Controls.Add(this.PictureDrumDifficulty2);
            this.GroupBoxDifficulty.Controls.Add(this.chkProBass);
            this.GroupBoxDifficulty.Controls.Add(this.PictureDrumDifficulty7);
            this.GroupBoxDifficulty.Controls.Add(this.LabelProBass);
            this.GroupBoxDifficulty.Controls.Add(this.PictureDrumDifficulty1);
            this.GroupBoxDifficulty.Controls.Add(this.chkProKeys);
            this.GroupBoxDifficulty.Controls.Add(this.LabelProKeysDifficulty);
            this.GroupBoxDifficulty.Controls.Add(this.LabelKeysDifficulty);
            this.GroupBoxDifficulty.Controls.Add(this.LabelVocalDifficulty);
            this.GroupBoxDifficulty.Controls.Add(this.LabelGuitarDifficulty);
            this.GroupBoxDifficulty.Controls.Add(this.LabelBassDifficulty);
            this.GroupBoxDifficulty.Controls.Add(this.LabelDrumDifficulty);
            this.GroupBoxDifficulty.Controls.Add(this.LabelBandDifficulty);
            this.GroupBoxDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxDifficulty.ForeColor = System.Drawing.Color.White;
            this.GroupBoxDifficulty.Location = new System.Drawing.Point(472, 77);
            this.GroupBoxDifficulty.Name = "GroupBoxDifficulty";
            this.GroupBoxDifficulty.Size = new System.Drawing.Size(260, 357);
            this.GroupBoxDifficulty.TabIndex = 29;
            this.GroupBoxDifficulty.TabStop = false;
            this.GroupBoxDifficulty.Text = "Difficulty";
            // 
            // lblBandDiff
            // 
            this.lblBandDiff.BackColor = System.Drawing.Color.White;
            this.lblBandDiff.ForeColor = System.Drawing.Color.Black;
            this.lblBandDiff.Location = new System.Drawing.Point(220, 331);
            this.lblBandDiff.Name = "lblBandDiff";
            this.lblBandDiff.Size = new System.Drawing.Size(30, 16);
            this.lblBandDiff.TabIndex = 141;
            this.lblBandDiff.Text = "1";
            this.lblBandDiff.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolTip.SetToolTip(this.lblBandDiff, "Band Difficulty");
            // 
            // scrollBand
            // 
            this.scrollBand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scrollBand.LargeChange = 1;
            this.scrollBand.Location = new System.Drawing.Point(104, 331);
            this.scrollBand.Maximum = 580;
            this.scrollBand.Minimum = 1;
            this.scrollBand.Name = "scrollBand";
            this.scrollBand.Size = new System.Drawing.Size(105, 16);
            this.scrollBand.TabIndex = 140;
            this.scrollBand.Value = 1;
            this.scrollBand.ValueChanged += new System.EventHandler(this.scrollBand_ValueChanged);
            // 
            // lblProKeysDiff
            // 
            this.lblProKeysDiff.BackColor = System.Drawing.Color.White;
            this.lblProKeysDiff.ForeColor = System.Drawing.Color.Black;
            this.lblProKeysDiff.Location = new System.Drawing.Point(220, 294);
            this.lblProKeysDiff.Name = "lblProKeysDiff";
            this.lblProKeysDiff.Size = new System.Drawing.Size(30, 16);
            this.lblProKeysDiff.TabIndex = 139;
            this.lblProKeysDiff.Text = "0";
            this.lblProKeysDiff.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolTip.SetToolTip(this.lblProKeysDiff, "Pro Keys Difficulty");
            // 
            // scrollProKeys
            // 
            this.scrollProKeys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scrollProKeys.Enabled = false;
            this.scrollProKeys.LargeChange = 1;
            this.scrollProKeys.Location = new System.Drawing.Point(104, 294);
            this.scrollProKeys.Maximum = 505;
            this.scrollProKeys.Name = "scrollProKeys";
            this.scrollProKeys.Size = new System.Drawing.Size(105, 16);
            this.scrollProKeys.TabIndex = 138;
            this.scrollProKeys.ValueChanged += new System.EventHandler(this.scrollProKeys_ValueChanged);
            // 
            // lblKeysDiff
            // 
            this.lblKeysDiff.BackColor = System.Drawing.Color.White;
            this.lblKeysDiff.ForeColor = System.Drawing.Color.Black;
            this.lblKeysDiff.Location = new System.Drawing.Point(220, 256);
            this.lblKeysDiff.Name = "lblKeysDiff";
            this.lblKeysDiff.Size = new System.Drawing.Size(30, 16);
            this.lblKeysDiff.TabIndex = 137;
            this.lblKeysDiff.Text = "0";
            this.lblKeysDiff.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolTip.SetToolTip(this.lblKeysDiff, "Keys Difficulty");
            // 
            // scrollKeys
            // 
            this.scrollKeys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scrollKeys.Enabled = false;
            this.scrollKeys.LargeChange = 1;
            this.scrollKeys.Location = new System.Drawing.Point(104, 256);
            this.scrollKeys.Maximum = 500;
            this.scrollKeys.Name = "scrollKeys";
            this.scrollKeys.Size = new System.Drawing.Size(105, 16);
            this.scrollKeys.TabIndex = 136;
            this.scrollKeys.ValueChanged += new System.EventHandler(this.scrollKeys_ValueChanged);
            // 
            // lblVocalsDiff
            // 
            this.lblVocalsDiff.BackColor = System.Drawing.Color.White;
            this.lblVocalsDiff.ForeColor = System.Drawing.Color.Black;
            this.lblVocalsDiff.Location = new System.Drawing.Point(220, 219);
            this.lblVocalsDiff.Name = "lblVocalsDiff";
            this.lblVocalsDiff.Size = new System.Drawing.Size(30, 16);
            this.lblVocalsDiff.TabIndex = 135;
            this.lblVocalsDiff.Text = "0";
            this.lblVocalsDiff.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolTip.SetToolTip(this.lblVocalsDiff, "Vocals Difficulty");
            // 
            // scrollVocals
            // 
            this.scrollVocals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scrollVocals.LargeChange = 1;
            this.scrollVocals.Location = new System.Drawing.Point(104, 219);
            this.scrollVocals.Maximum = 525;
            this.scrollVocals.Name = "scrollVocals";
            this.scrollVocals.Size = new System.Drawing.Size(105, 16);
            this.scrollVocals.TabIndex = 134;
            this.scrollVocals.ValueChanged += new System.EventHandler(this.scrollVocals_ValueChanged);
            // 
            // lblProGuitarDiff
            // 
            this.lblProGuitarDiff.BackColor = System.Drawing.Color.White;
            this.lblProGuitarDiff.ForeColor = System.Drawing.Color.Black;
            this.lblProGuitarDiff.Location = new System.Drawing.Point(220, 182);
            this.lblProGuitarDiff.Name = "lblProGuitarDiff";
            this.lblProGuitarDiff.Size = new System.Drawing.Size(30, 16);
            this.lblProGuitarDiff.TabIndex = 133;
            this.lblProGuitarDiff.Text = "0";
            this.lblProGuitarDiff.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolTip.SetToolTip(this.lblProGuitarDiff, "Pro Guitar Difficulty");
            // 
            // scrollProGuitar
            // 
            this.scrollProGuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scrollProGuitar.Enabled = false;
            this.scrollProGuitar.LargeChange = 1;
            this.scrollProGuitar.Location = new System.Drawing.Point(104, 182);
            this.scrollProGuitar.Maximum = 600;
            this.scrollProGuitar.Name = "scrollProGuitar";
            this.scrollProGuitar.Size = new System.Drawing.Size(105, 16);
            this.scrollProGuitar.TabIndex = 132;
            this.scrollProGuitar.ValueChanged += new System.EventHandler(this.scrollProGuitar_ValueChanged);
            // 
            // lblGuitarDiff
            // 
            this.lblGuitarDiff.BackColor = System.Drawing.Color.White;
            this.lblGuitarDiff.ForeColor = System.Drawing.Color.Black;
            this.lblGuitarDiff.Location = new System.Drawing.Point(220, 145);
            this.lblGuitarDiff.Name = "lblGuitarDiff";
            this.lblGuitarDiff.Size = new System.Drawing.Size(30, 16);
            this.lblGuitarDiff.TabIndex = 131;
            this.lblGuitarDiff.Text = "0";
            this.lblGuitarDiff.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolTip.SetToolTip(this.lblGuitarDiff, "Guitar Difficulty");
            // 
            // scrollGuitar
            // 
            this.scrollGuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scrollGuitar.LargeChange = 1;
            this.scrollGuitar.Location = new System.Drawing.Point(104, 145);
            this.scrollGuitar.Maximum = 605;
            this.scrollGuitar.Name = "scrollGuitar";
            this.scrollGuitar.Size = new System.Drawing.Size(105, 16);
            this.scrollGuitar.TabIndex = 130;
            this.scrollGuitar.ValueChanged += new System.EventHandler(this.scrollGuitar_ValueChanged);
            // 
            // lblProBassDiff
            // 
            this.lblProBassDiff.BackColor = System.Drawing.Color.White;
            this.lblProBassDiff.ForeColor = System.Drawing.Color.Black;
            this.lblProBassDiff.Location = new System.Drawing.Point(220, 108);
            this.lblProBassDiff.Name = "lblProBassDiff";
            this.lblProBassDiff.Size = new System.Drawing.Size(30, 16);
            this.lblProBassDiff.TabIndex = 129;
            this.lblProBassDiff.Text = "0";
            this.lblProBassDiff.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolTip.SetToolTip(this.lblProBassDiff, "Pro Bass Difficulty");
            // 
            // scrollProBass
            // 
            this.scrollProBass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scrollProBass.Enabled = false;
            this.scrollProBass.LargeChange = 1;
            this.scrollProBass.Location = new System.Drawing.Point(104, 108);
            this.scrollProBass.Maximum = 500;
            this.scrollProBass.Name = "scrollProBass";
            this.scrollProBass.Size = new System.Drawing.Size(105, 16);
            this.scrollProBass.TabIndex = 128;
            this.scrollProBass.ValueChanged += new System.EventHandler(this.scrollProBass_ValueChanged);
            // 
            // lblBassDiff
            // 
            this.lblBassDiff.BackColor = System.Drawing.Color.White;
            this.lblBassDiff.ForeColor = System.Drawing.Color.Black;
            this.lblBassDiff.Location = new System.Drawing.Point(220, 71);
            this.lblBassDiff.Name = "lblBassDiff";
            this.lblBassDiff.Size = new System.Drawing.Size(30, 16);
            this.lblBassDiff.TabIndex = 127;
            this.lblBassDiff.Text = "0";
            this.lblBassDiff.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolTip.SetToolTip(this.lblBassDiff, "Bass Difficulty");
            // 
            // scrollBass
            // 
            this.scrollBass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scrollBass.LargeChange = 1;
            this.scrollBass.Location = new System.Drawing.Point(104, 71);
            this.scrollBass.Maximum = 600;
            this.scrollBass.Name = "scrollBass";
            this.scrollBass.Size = new System.Drawing.Size(105, 16);
            this.scrollBass.TabIndex = 126;
            this.scrollBass.ValueChanged += new System.EventHandler(this.scrollBass_ValueChanged);
            // 
            // lblDrumsDiff
            // 
            this.lblDrumsDiff.BackColor = System.Drawing.Color.White;
            this.lblDrumsDiff.ForeColor = System.Drawing.Color.Black;
            this.lblDrumsDiff.Location = new System.Drawing.Point(220, 34);
            this.lblDrumsDiff.Name = "lblDrumsDiff";
            this.lblDrumsDiff.Size = new System.Drawing.Size(30, 16);
            this.lblDrumsDiff.TabIndex = 125;
            this.lblDrumsDiff.Text = "0";
            this.lblDrumsDiff.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolTip.SetToolTip(this.lblDrumsDiff, "Drums Difficulty");
            // 
            // scrollDrums
            // 
            this.scrollDrums.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scrollDrums.LargeChange = 1;
            this.scrollDrums.Location = new System.Drawing.Point(104, 34);
            this.scrollDrums.Maximum = 600;
            this.scrollDrums.Name = "scrollDrums";
            this.scrollDrums.Size = new System.Drawing.Size(105, 16);
            this.scrollDrums.TabIndex = 124;
            this.scrollDrums.ValueChanged += new System.EventHandler(this.scrollDrums_ValueChanged);
            // 
            // PictureBandDifficulty6
            // 
            this.PictureBandDifficulty6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBandDifficulty6.Location = new System.Drawing.Point(178, 315);
            this.PictureBandDifficulty6.Name = "PictureBandDifficulty6";
            this.PictureBandDifficulty6.Size = new System.Drawing.Size(14, 13);
            this.PictureBandDifficulty6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBandDifficulty6.TabIndex = 32;
            this.PictureBandDifficulty6.TabStop = false;
            this.PictureBandDifficulty6.Tag = "6";
            this.PictureBandDifficulty6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBandDifficulty6.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBandDifficulty6.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProKeysDifficulty6
            // 
            this.PictureProKeysDifficulty6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProKeysDifficulty6.Enabled = false;
            this.PictureProKeysDifficulty6.Location = new System.Drawing.Point(178, 278);
            this.PictureProKeysDifficulty6.Name = "PictureProKeysDifficulty6";
            this.PictureProKeysDifficulty6.Size = new System.Drawing.Size(14, 13);
            this.PictureProKeysDifficulty6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProKeysDifficulty6.TabIndex = 26;
            this.PictureProKeysDifficulty6.TabStop = false;
            this.PictureProKeysDifficulty6.Tag = "6";
            this.PictureProKeysDifficulty6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureProKeysDifficulty6.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProKeysDifficulty6.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureBandDifficulty5
            // 
            this.PictureBandDifficulty5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBandDifficulty5.Location = new System.Drawing.Point(164, 315);
            this.PictureBandDifficulty5.Name = "PictureBandDifficulty5";
            this.PictureBandDifficulty5.Size = new System.Drawing.Size(14, 13);
            this.PictureBandDifficulty5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBandDifficulty5.TabIndex = 31;
            this.PictureBandDifficulty5.TabStop = false;
            this.PictureBandDifficulty5.Tag = "5";
            this.PictureBandDifficulty5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBandDifficulty5.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBandDifficulty5.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureKeysDifficulty6
            // 
            this.PictureKeysDifficulty6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureKeysDifficulty6.Enabled = false;
            this.PictureKeysDifficulty6.Location = new System.Drawing.Point(178, 240);
            this.PictureKeysDifficulty6.Name = "PictureKeysDifficulty6";
            this.PictureKeysDifficulty6.Size = new System.Drawing.Size(14, 13);
            this.PictureKeysDifficulty6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureKeysDifficulty6.TabIndex = 26;
            this.PictureKeysDifficulty6.TabStop = false;
            this.PictureKeysDifficulty6.Tag = "6";
            this.PictureKeysDifficulty6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureKeysDifficulty6.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureKeysDifficulty6.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureBandDifficulty4
            // 
            this.PictureBandDifficulty4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBandDifficulty4.Location = new System.Drawing.Point(150, 315);
            this.PictureBandDifficulty4.Name = "PictureBandDifficulty4";
            this.PictureBandDifficulty4.Size = new System.Drawing.Size(14, 13);
            this.PictureBandDifficulty4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBandDifficulty4.TabIndex = 30;
            this.PictureBandDifficulty4.TabStop = false;
            this.PictureBandDifficulty4.Tag = "4";
            this.PictureBandDifficulty4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBandDifficulty4.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBandDifficulty4.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProKeysDifficulty5
            // 
            this.PictureProKeysDifficulty5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProKeysDifficulty5.Enabled = false;
            this.PictureProKeysDifficulty5.Location = new System.Drawing.Point(164, 278);
            this.PictureProKeysDifficulty5.Name = "PictureProKeysDifficulty5";
            this.PictureProKeysDifficulty5.Size = new System.Drawing.Size(14, 13);
            this.PictureProKeysDifficulty5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProKeysDifficulty5.TabIndex = 25;
            this.PictureProKeysDifficulty5.TabStop = false;
            this.PictureProKeysDifficulty5.Tag = "5";
            this.PictureProKeysDifficulty5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureProKeysDifficulty5.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProKeysDifficulty5.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureBandDifficulty3
            // 
            this.PictureBandDifficulty3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBandDifficulty3.Location = new System.Drawing.Point(136, 315);
            this.PictureBandDifficulty3.Name = "PictureBandDifficulty3";
            this.PictureBandDifficulty3.Size = new System.Drawing.Size(14, 13);
            this.PictureBandDifficulty3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBandDifficulty3.TabIndex = 29;
            this.PictureBandDifficulty3.TabStop = false;
            this.PictureBandDifficulty3.Tag = "3";
            this.PictureBandDifficulty3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBandDifficulty3.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBandDifficulty3.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProKeysDifficulty4
            // 
            this.PictureProKeysDifficulty4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProKeysDifficulty4.Enabled = false;
            this.PictureProKeysDifficulty4.Location = new System.Drawing.Point(150, 278);
            this.PictureProKeysDifficulty4.Name = "PictureProKeysDifficulty4";
            this.PictureProKeysDifficulty4.Size = new System.Drawing.Size(14, 13);
            this.PictureProKeysDifficulty4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProKeysDifficulty4.TabIndex = 24;
            this.PictureProKeysDifficulty4.TabStop = false;
            this.PictureProKeysDifficulty4.Tag = "4";
            this.PictureProKeysDifficulty4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureProKeysDifficulty4.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProKeysDifficulty4.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureBandDifficulty2
            // 
            this.PictureBandDifficulty2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBandDifficulty2.Location = new System.Drawing.Point(122, 315);
            this.PictureBandDifficulty2.Name = "PictureBandDifficulty2";
            this.PictureBandDifficulty2.Size = new System.Drawing.Size(14, 13);
            this.PictureBandDifficulty2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBandDifficulty2.TabIndex = 28;
            this.PictureBandDifficulty2.TabStop = false;
            this.PictureBandDifficulty2.Tag = "2";
            this.PictureBandDifficulty2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBandDifficulty2.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBandDifficulty2.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureBandDifficulty7
            // 
            this.PictureBandDifficulty7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBandDifficulty7.Location = new System.Drawing.Point(196, 315);
            this.PictureBandDifficulty7.Name = "PictureBandDifficulty7";
            this.PictureBandDifficulty7.Size = new System.Drawing.Size(13, 13);
            this.PictureBandDifficulty7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBandDifficulty7.TabIndex = 27;
            this.PictureBandDifficulty7.TabStop = false;
            this.PictureBandDifficulty7.Tag = "7";
            this.PictureBandDifficulty7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBandDifficulty7.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBandDifficulty7.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureKeysDifficulty5
            // 
            this.PictureKeysDifficulty5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureKeysDifficulty5.Enabled = false;
            this.PictureKeysDifficulty5.Location = new System.Drawing.Point(164, 240);
            this.PictureKeysDifficulty5.Name = "PictureKeysDifficulty5";
            this.PictureKeysDifficulty5.Size = new System.Drawing.Size(14, 13);
            this.PictureKeysDifficulty5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureKeysDifficulty5.TabIndex = 25;
            this.PictureKeysDifficulty5.TabStop = false;
            this.PictureKeysDifficulty5.Tag = "5";
            this.PictureKeysDifficulty5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureKeysDifficulty5.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureKeysDifficulty5.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureBandDifficulty1
            // 
            this.PictureBandDifficulty1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBandDifficulty1.Location = new System.Drawing.Point(104, 315);
            this.PictureBandDifficulty1.Name = "PictureBandDifficulty1";
            this.PictureBandDifficulty1.Size = new System.Drawing.Size(14, 13);
            this.PictureBandDifficulty1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBandDifficulty1.TabIndex = 26;
            this.PictureBandDifficulty1.TabStop = false;
            this.PictureBandDifficulty1.Tag = "1";
            this.PictureBandDifficulty1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBandDifficulty1.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBandDifficulty1.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProKeysDifficulty3
            // 
            this.PictureProKeysDifficulty3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProKeysDifficulty3.Enabled = false;
            this.PictureProKeysDifficulty3.Location = new System.Drawing.Point(136, 278);
            this.PictureProKeysDifficulty3.Name = "PictureProKeysDifficulty3";
            this.PictureProKeysDifficulty3.Size = new System.Drawing.Size(14, 13);
            this.PictureProKeysDifficulty3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProKeysDifficulty3.TabIndex = 23;
            this.PictureProKeysDifficulty3.TabStop = false;
            this.PictureProKeysDifficulty3.Tag = "3";
            this.PictureProKeysDifficulty3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureProKeysDifficulty3.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProKeysDifficulty3.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureVocalDifficulty6
            // 
            this.PictureVocalDifficulty6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureVocalDifficulty6.Enabled = false;
            this.PictureVocalDifficulty6.Location = new System.Drawing.Point(178, 203);
            this.PictureVocalDifficulty6.Name = "PictureVocalDifficulty6";
            this.PictureVocalDifficulty6.Size = new System.Drawing.Size(14, 13);
            this.PictureVocalDifficulty6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureVocalDifficulty6.TabIndex = 26;
            this.PictureVocalDifficulty6.TabStop = false;
            this.PictureVocalDifficulty6.Tag = "6";
            this.PictureVocalDifficulty6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureVocalDifficulty6.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureVocalDifficulty6.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProKeysDifficulty2
            // 
            this.PictureProKeysDifficulty2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProKeysDifficulty2.Enabled = false;
            this.PictureProKeysDifficulty2.Location = new System.Drawing.Point(122, 278);
            this.PictureProKeysDifficulty2.Name = "PictureProKeysDifficulty2";
            this.PictureProKeysDifficulty2.Size = new System.Drawing.Size(14, 13);
            this.PictureProKeysDifficulty2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProKeysDifficulty2.TabIndex = 22;
            this.PictureProKeysDifficulty2.TabStop = false;
            this.PictureProKeysDifficulty2.Tag = "2";
            this.PictureProKeysDifficulty2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureProKeysDifficulty2.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProKeysDifficulty2.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureKeysDifficulty4
            // 
            this.PictureKeysDifficulty4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureKeysDifficulty4.Enabled = false;
            this.PictureKeysDifficulty4.Location = new System.Drawing.Point(150, 240);
            this.PictureKeysDifficulty4.Name = "PictureKeysDifficulty4";
            this.PictureKeysDifficulty4.Size = new System.Drawing.Size(14, 13);
            this.PictureKeysDifficulty4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureKeysDifficulty4.TabIndex = 24;
            this.PictureKeysDifficulty4.TabStop = false;
            this.PictureKeysDifficulty4.Tag = "4";
            this.PictureKeysDifficulty4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureKeysDifficulty4.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureKeysDifficulty4.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProKeysDifficulty7
            // 
            this.PictureProKeysDifficulty7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProKeysDifficulty7.Enabled = false;
            this.PictureProKeysDifficulty7.Location = new System.Drawing.Point(196, 278);
            this.PictureProKeysDifficulty7.Name = "PictureProKeysDifficulty7";
            this.PictureProKeysDifficulty7.Size = new System.Drawing.Size(13, 13);
            this.PictureProKeysDifficulty7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProKeysDifficulty7.TabIndex = 21;
            this.PictureProKeysDifficulty7.TabStop = false;
            this.PictureProKeysDifficulty7.Tag = "7";
            this.PictureProKeysDifficulty7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureProKeysDifficulty7.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProKeysDifficulty7.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureVocalDifficulty5
            // 
            this.PictureVocalDifficulty5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureVocalDifficulty5.Enabled = false;
            this.PictureVocalDifficulty5.Location = new System.Drawing.Point(164, 203);
            this.PictureVocalDifficulty5.Name = "PictureVocalDifficulty5";
            this.PictureVocalDifficulty5.Size = new System.Drawing.Size(14, 13);
            this.PictureVocalDifficulty5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureVocalDifficulty5.TabIndex = 25;
            this.PictureVocalDifficulty5.TabStop = false;
            this.PictureVocalDifficulty5.Tag = "5";
            this.PictureVocalDifficulty5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureVocalDifficulty5.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureVocalDifficulty5.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProKeysDifficulty1
            // 
            this.PictureProKeysDifficulty1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProKeysDifficulty1.Enabled = false;
            this.PictureProKeysDifficulty1.Location = new System.Drawing.Point(104, 278);
            this.PictureProKeysDifficulty1.Name = "PictureProKeysDifficulty1";
            this.PictureProKeysDifficulty1.Size = new System.Drawing.Size(14, 13);
            this.PictureProKeysDifficulty1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProKeysDifficulty1.TabIndex = 20;
            this.PictureProKeysDifficulty1.TabStop = false;
            this.PictureProKeysDifficulty1.Tag = "1";
            this.PictureProKeysDifficulty1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureProKeysDifficulty1.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProKeysDifficulty1.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureKeysDifficulty3
            // 
            this.PictureKeysDifficulty3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureKeysDifficulty3.Enabled = false;
            this.PictureKeysDifficulty3.Location = new System.Drawing.Point(136, 240);
            this.PictureKeysDifficulty3.Name = "PictureKeysDifficulty3";
            this.PictureKeysDifficulty3.Size = new System.Drawing.Size(14, 13);
            this.PictureKeysDifficulty3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureKeysDifficulty3.TabIndex = 23;
            this.PictureKeysDifficulty3.TabStop = false;
            this.PictureKeysDifficulty3.Tag = "3";
            this.PictureKeysDifficulty3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureKeysDifficulty3.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureKeysDifficulty3.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProGuitarDifficulty6
            // 
            this.PictureProGuitarDifficulty6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProGuitarDifficulty6.Enabled = false;
            this.PictureProGuitarDifficulty6.Location = new System.Drawing.Point(178, 166);
            this.PictureProGuitarDifficulty6.Name = "PictureProGuitarDifficulty6";
            this.PictureProGuitarDifficulty6.Size = new System.Drawing.Size(14, 13);
            this.PictureProGuitarDifficulty6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProGuitarDifficulty6.TabIndex = 26;
            this.PictureProGuitarDifficulty6.TabStop = false;
            this.PictureProGuitarDifficulty6.Tag = "6";
            this.PictureProGuitarDifficulty6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProGuitarDifficulty6.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProGuitarDifficulty6.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureKeysDifficulty2
            // 
            this.PictureKeysDifficulty2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureKeysDifficulty2.Enabled = false;
            this.PictureKeysDifficulty2.Location = new System.Drawing.Point(122, 240);
            this.PictureKeysDifficulty2.Name = "PictureKeysDifficulty2";
            this.PictureKeysDifficulty2.Size = new System.Drawing.Size(14, 13);
            this.PictureKeysDifficulty2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureKeysDifficulty2.TabIndex = 22;
            this.PictureKeysDifficulty2.TabStop = false;
            this.PictureKeysDifficulty2.Tag = "2";
            this.PictureKeysDifficulty2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureKeysDifficulty2.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureKeysDifficulty2.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureVocalDifficulty4
            // 
            this.PictureVocalDifficulty4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureVocalDifficulty4.Enabled = false;
            this.PictureVocalDifficulty4.Location = new System.Drawing.Point(150, 203);
            this.PictureVocalDifficulty4.Name = "PictureVocalDifficulty4";
            this.PictureVocalDifficulty4.Size = new System.Drawing.Size(14, 13);
            this.PictureVocalDifficulty4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureVocalDifficulty4.TabIndex = 24;
            this.PictureVocalDifficulty4.TabStop = false;
            this.PictureVocalDifficulty4.Tag = "4";
            this.PictureVocalDifficulty4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureVocalDifficulty4.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureVocalDifficulty4.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureKeysDifficulty7
            // 
            this.PictureKeysDifficulty7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureKeysDifficulty7.Enabled = false;
            this.PictureKeysDifficulty7.Location = new System.Drawing.Point(196, 240);
            this.PictureKeysDifficulty7.Name = "PictureKeysDifficulty7";
            this.PictureKeysDifficulty7.Size = new System.Drawing.Size(13, 13);
            this.PictureKeysDifficulty7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureKeysDifficulty7.TabIndex = 21;
            this.PictureKeysDifficulty7.TabStop = false;
            this.PictureKeysDifficulty7.Tag = "7";
            this.PictureKeysDifficulty7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureKeysDifficulty7.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureKeysDifficulty7.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureGuitarDifficulty6
            // 
            this.PictureGuitarDifficulty6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureGuitarDifficulty6.Enabled = false;
            this.PictureGuitarDifficulty6.Location = new System.Drawing.Point(178, 129);
            this.PictureGuitarDifficulty6.Name = "PictureGuitarDifficulty6";
            this.PictureGuitarDifficulty6.Size = new System.Drawing.Size(14, 13);
            this.PictureGuitarDifficulty6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureGuitarDifficulty6.TabIndex = 26;
            this.PictureGuitarDifficulty6.TabStop = false;
            this.PictureGuitarDifficulty6.Tag = "6";
            this.PictureGuitarDifficulty6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureGuitarDifficulty6.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureGuitarDifficulty6.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureKeysDifficulty1
            // 
            this.PictureKeysDifficulty1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureKeysDifficulty1.Enabled = false;
            this.PictureKeysDifficulty1.Location = new System.Drawing.Point(104, 240);
            this.PictureKeysDifficulty1.Name = "PictureKeysDifficulty1";
            this.PictureKeysDifficulty1.Size = new System.Drawing.Size(14, 13);
            this.PictureKeysDifficulty1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureKeysDifficulty1.TabIndex = 20;
            this.PictureKeysDifficulty1.TabStop = false;
            this.PictureKeysDifficulty1.Tag = "1";
            this.PictureKeysDifficulty1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureKeysDifficulty1.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureKeysDifficulty1.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureVocalDifficulty3
            // 
            this.PictureVocalDifficulty3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureVocalDifficulty3.Enabled = false;
            this.PictureVocalDifficulty3.Location = new System.Drawing.Point(136, 203);
            this.PictureVocalDifficulty3.Name = "PictureVocalDifficulty3";
            this.PictureVocalDifficulty3.Size = new System.Drawing.Size(14, 13);
            this.PictureVocalDifficulty3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureVocalDifficulty3.TabIndex = 23;
            this.PictureVocalDifficulty3.TabStop = false;
            this.PictureVocalDifficulty3.Tag = "3";
            this.PictureVocalDifficulty3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureVocalDifficulty3.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureVocalDifficulty3.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProGuitarDifficulty5
            // 
            this.PictureProGuitarDifficulty5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProGuitarDifficulty5.Enabled = false;
            this.PictureProGuitarDifficulty5.Location = new System.Drawing.Point(164, 166);
            this.PictureProGuitarDifficulty5.Name = "PictureProGuitarDifficulty5";
            this.PictureProGuitarDifficulty5.Size = new System.Drawing.Size(14, 13);
            this.PictureProGuitarDifficulty5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProGuitarDifficulty5.TabIndex = 25;
            this.PictureProGuitarDifficulty5.TabStop = false;
            this.PictureProGuitarDifficulty5.Tag = "5";
            this.PictureProGuitarDifficulty5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProGuitarDifficulty5.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProGuitarDifficulty5.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureVocalDifficulty2
            // 
            this.PictureVocalDifficulty2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureVocalDifficulty2.Enabled = false;
            this.PictureVocalDifficulty2.Location = new System.Drawing.Point(122, 203);
            this.PictureVocalDifficulty2.Name = "PictureVocalDifficulty2";
            this.PictureVocalDifficulty2.Size = new System.Drawing.Size(14, 13);
            this.PictureVocalDifficulty2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureVocalDifficulty2.TabIndex = 22;
            this.PictureVocalDifficulty2.TabStop = false;
            this.PictureVocalDifficulty2.Tag = "2";
            this.PictureVocalDifficulty2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureVocalDifficulty2.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureVocalDifficulty2.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProBassDifficulty6
            // 
            this.PictureProBassDifficulty6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProBassDifficulty6.Enabled = false;
            this.PictureProBassDifficulty6.Location = new System.Drawing.Point(178, 92);
            this.PictureProBassDifficulty6.Name = "PictureProBassDifficulty6";
            this.PictureProBassDifficulty6.Size = new System.Drawing.Size(14, 13);
            this.PictureProBassDifficulty6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProBassDifficulty6.TabIndex = 26;
            this.PictureProBassDifficulty6.TabStop = false;
            this.PictureProBassDifficulty6.Tag = "6";
            this.PictureProBassDifficulty6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProBassDifficulty6.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProBassDifficulty6.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureVocalDifficulty7
            // 
            this.PictureVocalDifficulty7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureVocalDifficulty7.Enabled = false;
            this.PictureVocalDifficulty7.Location = new System.Drawing.Point(196, 203);
            this.PictureVocalDifficulty7.Name = "PictureVocalDifficulty7";
            this.PictureVocalDifficulty7.Size = new System.Drawing.Size(13, 13);
            this.PictureVocalDifficulty7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureVocalDifficulty7.TabIndex = 21;
            this.PictureVocalDifficulty7.TabStop = false;
            this.PictureVocalDifficulty7.Tag = "7";
            this.PictureVocalDifficulty7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureVocalDifficulty7.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureVocalDifficulty7.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProGuitarDifficulty4
            // 
            this.PictureProGuitarDifficulty4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProGuitarDifficulty4.Enabled = false;
            this.PictureProGuitarDifficulty4.Location = new System.Drawing.Point(150, 166);
            this.PictureProGuitarDifficulty4.Name = "PictureProGuitarDifficulty4";
            this.PictureProGuitarDifficulty4.Size = new System.Drawing.Size(14, 13);
            this.PictureProGuitarDifficulty4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProGuitarDifficulty4.TabIndex = 24;
            this.PictureProGuitarDifficulty4.TabStop = false;
            this.PictureProGuitarDifficulty4.Tag = "4";
            this.PictureProGuitarDifficulty4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProGuitarDifficulty4.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProGuitarDifficulty4.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureVocalDifficulty1
            // 
            this.PictureVocalDifficulty1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureVocalDifficulty1.Enabled = false;
            this.PictureVocalDifficulty1.Location = new System.Drawing.Point(104, 203);
            this.PictureVocalDifficulty1.Name = "PictureVocalDifficulty1";
            this.PictureVocalDifficulty1.Size = new System.Drawing.Size(14, 13);
            this.PictureVocalDifficulty1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureVocalDifficulty1.TabIndex = 20;
            this.PictureVocalDifficulty1.TabStop = false;
            this.PictureVocalDifficulty1.Tag = "1";
            this.PictureVocalDifficulty1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureVocalDifficulty1.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureVocalDifficulty1.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureGuitarDifficulty5
            // 
            this.PictureGuitarDifficulty5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureGuitarDifficulty5.Enabled = false;
            this.PictureGuitarDifficulty5.Location = new System.Drawing.Point(164, 129);
            this.PictureGuitarDifficulty5.Name = "PictureGuitarDifficulty5";
            this.PictureGuitarDifficulty5.Size = new System.Drawing.Size(14, 13);
            this.PictureGuitarDifficulty5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureGuitarDifficulty5.TabIndex = 25;
            this.PictureGuitarDifficulty5.TabStop = false;
            this.PictureGuitarDifficulty5.Tag = "5";
            this.PictureGuitarDifficulty5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureGuitarDifficulty5.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureGuitarDifficulty5.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProGuitarDifficulty3
            // 
            this.PictureProGuitarDifficulty3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProGuitarDifficulty3.Enabled = false;
            this.PictureProGuitarDifficulty3.Location = new System.Drawing.Point(136, 166);
            this.PictureProGuitarDifficulty3.Name = "PictureProGuitarDifficulty3";
            this.PictureProGuitarDifficulty3.Size = new System.Drawing.Size(14, 13);
            this.PictureProGuitarDifficulty3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProGuitarDifficulty3.TabIndex = 23;
            this.PictureProGuitarDifficulty3.TabStop = false;
            this.PictureProGuitarDifficulty3.Tag = "3";
            this.PictureProGuitarDifficulty3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProGuitarDifficulty3.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProGuitarDifficulty3.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProBassDifficulty5
            // 
            this.PictureProBassDifficulty5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProBassDifficulty5.Enabled = false;
            this.PictureProBassDifficulty5.Location = new System.Drawing.Point(164, 92);
            this.PictureProBassDifficulty5.Name = "PictureProBassDifficulty5";
            this.PictureProBassDifficulty5.Size = new System.Drawing.Size(14, 13);
            this.PictureProBassDifficulty5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProBassDifficulty5.TabIndex = 25;
            this.PictureProBassDifficulty5.TabStop = false;
            this.PictureProBassDifficulty5.Tag = "5";
            this.PictureProBassDifficulty5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProBassDifficulty5.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProBassDifficulty5.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProGuitarDifficulty2
            // 
            this.PictureProGuitarDifficulty2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProGuitarDifficulty2.Enabled = false;
            this.PictureProGuitarDifficulty2.Location = new System.Drawing.Point(122, 166);
            this.PictureProGuitarDifficulty2.Name = "PictureProGuitarDifficulty2";
            this.PictureProGuitarDifficulty2.Size = new System.Drawing.Size(14, 13);
            this.PictureProGuitarDifficulty2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProGuitarDifficulty2.TabIndex = 22;
            this.PictureProGuitarDifficulty2.TabStop = false;
            this.PictureProGuitarDifficulty2.Tag = "2";
            this.PictureProGuitarDifficulty2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProGuitarDifficulty2.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProGuitarDifficulty2.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureGuitarDifficulty4
            // 
            this.PictureGuitarDifficulty4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureGuitarDifficulty4.Enabled = false;
            this.PictureGuitarDifficulty4.Location = new System.Drawing.Point(150, 129);
            this.PictureGuitarDifficulty4.Name = "PictureGuitarDifficulty4";
            this.PictureGuitarDifficulty4.Size = new System.Drawing.Size(14, 13);
            this.PictureGuitarDifficulty4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureGuitarDifficulty4.TabIndex = 24;
            this.PictureGuitarDifficulty4.TabStop = false;
            this.PictureGuitarDifficulty4.Tag = "4";
            this.PictureGuitarDifficulty4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureGuitarDifficulty4.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureGuitarDifficulty4.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProGuitarDifficulty7
            // 
            this.PictureProGuitarDifficulty7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProGuitarDifficulty7.Enabled = false;
            this.PictureProGuitarDifficulty7.Location = new System.Drawing.Point(196, 166);
            this.PictureProGuitarDifficulty7.Name = "PictureProGuitarDifficulty7";
            this.PictureProGuitarDifficulty7.Size = new System.Drawing.Size(13, 13);
            this.PictureProGuitarDifficulty7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProGuitarDifficulty7.TabIndex = 21;
            this.PictureProGuitarDifficulty7.TabStop = false;
            this.PictureProGuitarDifficulty7.Tag = "7";
            this.PictureProGuitarDifficulty7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProGuitarDifficulty7.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProGuitarDifficulty7.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProGuitarDifficulty1
            // 
            this.PictureProGuitarDifficulty1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProGuitarDifficulty1.Enabled = false;
            this.PictureProGuitarDifficulty1.Location = new System.Drawing.Point(104, 166);
            this.PictureProGuitarDifficulty1.Name = "PictureProGuitarDifficulty1";
            this.PictureProGuitarDifficulty1.Size = new System.Drawing.Size(14, 13);
            this.PictureProGuitarDifficulty1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProGuitarDifficulty1.TabIndex = 20;
            this.PictureProGuitarDifficulty1.TabStop = false;
            this.PictureProGuitarDifficulty1.Tag = "1";
            this.PictureProGuitarDifficulty1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProGuitarDifficulty1.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProGuitarDifficulty1.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureBassDifficulty6
            // 
            this.PictureBassDifficulty6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBassDifficulty6.Enabled = false;
            this.PictureBassDifficulty6.Location = new System.Drawing.Point(178, 55);
            this.PictureBassDifficulty6.Name = "PictureBassDifficulty6";
            this.PictureBassDifficulty6.Size = new System.Drawing.Size(14, 13);
            this.PictureBassDifficulty6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBassDifficulty6.TabIndex = 26;
            this.PictureBassDifficulty6.TabStop = false;
            this.PictureBassDifficulty6.Tag = "6";
            this.PictureBassDifficulty6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBassDifficulty6.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBassDifficulty6.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureGuitarDifficulty3
            // 
            this.PictureGuitarDifficulty3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureGuitarDifficulty3.Enabled = false;
            this.PictureGuitarDifficulty3.Location = new System.Drawing.Point(136, 129);
            this.PictureGuitarDifficulty3.Name = "PictureGuitarDifficulty3";
            this.PictureGuitarDifficulty3.Size = new System.Drawing.Size(14, 13);
            this.PictureGuitarDifficulty3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureGuitarDifficulty3.TabIndex = 23;
            this.PictureGuitarDifficulty3.TabStop = false;
            this.PictureGuitarDifficulty3.Tag = "3";
            this.PictureGuitarDifficulty3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureGuitarDifficulty3.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureGuitarDifficulty3.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProBassDifficulty4
            // 
            this.PictureProBassDifficulty4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProBassDifficulty4.Enabled = false;
            this.PictureProBassDifficulty4.Location = new System.Drawing.Point(150, 92);
            this.PictureProBassDifficulty4.Name = "PictureProBassDifficulty4";
            this.PictureProBassDifficulty4.Size = new System.Drawing.Size(14, 13);
            this.PictureProBassDifficulty4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProBassDifficulty4.TabIndex = 24;
            this.PictureProBassDifficulty4.TabStop = false;
            this.PictureProBassDifficulty4.Tag = "4";
            this.PictureProBassDifficulty4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProBassDifficulty4.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProBassDifficulty4.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureGuitarDifficulty2
            // 
            this.PictureGuitarDifficulty2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureGuitarDifficulty2.Enabled = false;
            this.PictureGuitarDifficulty2.Location = new System.Drawing.Point(122, 129);
            this.PictureGuitarDifficulty2.Name = "PictureGuitarDifficulty2";
            this.PictureGuitarDifficulty2.Size = new System.Drawing.Size(14, 13);
            this.PictureGuitarDifficulty2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureGuitarDifficulty2.TabIndex = 22;
            this.PictureGuitarDifficulty2.TabStop = false;
            this.PictureGuitarDifficulty2.Tag = "2";
            this.PictureGuitarDifficulty2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureGuitarDifficulty2.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureGuitarDifficulty2.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureDrumDifficulty6
            // 
            this.PictureDrumDifficulty6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureDrumDifficulty6.Enabled = false;
            this.PictureDrumDifficulty6.Location = new System.Drawing.Point(178, 17);
            this.PictureDrumDifficulty6.Name = "PictureDrumDifficulty6";
            this.PictureDrumDifficulty6.Size = new System.Drawing.Size(14, 13);
            this.PictureDrumDifficulty6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDrumDifficulty6.TabIndex = 19;
            this.PictureDrumDifficulty6.TabStop = false;
            this.PictureDrumDifficulty6.Tag = "6";
            this.PictureDrumDifficulty6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureDrumDifficulty6.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureDrumDifficulty6.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureGuitarDifficulty7
            // 
            this.PictureGuitarDifficulty7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureGuitarDifficulty7.Enabled = false;
            this.PictureGuitarDifficulty7.Location = new System.Drawing.Point(196, 129);
            this.PictureGuitarDifficulty7.Name = "PictureGuitarDifficulty7";
            this.PictureGuitarDifficulty7.Size = new System.Drawing.Size(13, 13);
            this.PictureGuitarDifficulty7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureGuitarDifficulty7.TabIndex = 21;
            this.PictureGuitarDifficulty7.TabStop = false;
            this.PictureGuitarDifficulty7.Tag = "7";
            this.PictureGuitarDifficulty7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureGuitarDifficulty7.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureGuitarDifficulty7.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureGuitarDifficulty1
            // 
            this.PictureGuitarDifficulty1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureGuitarDifficulty1.Enabled = false;
            this.PictureGuitarDifficulty1.Location = new System.Drawing.Point(104, 129);
            this.PictureGuitarDifficulty1.Name = "PictureGuitarDifficulty1";
            this.PictureGuitarDifficulty1.Size = new System.Drawing.Size(14, 13);
            this.PictureGuitarDifficulty1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureGuitarDifficulty1.TabIndex = 20;
            this.PictureGuitarDifficulty1.TabStop = false;
            this.PictureGuitarDifficulty1.Tag = "1";
            this.PictureGuitarDifficulty1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureGuitarDifficulty1.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureGuitarDifficulty1.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProBassDifficulty3
            // 
            this.PictureProBassDifficulty3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProBassDifficulty3.Enabled = false;
            this.PictureProBassDifficulty3.Location = new System.Drawing.Point(136, 92);
            this.PictureProBassDifficulty3.Name = "PictureProBassDifficulty3";
            this.PictureProBassDifficulty3.Size = new System.Drawing.Size(14, 13);
            this.PictureProBassDifficulty3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProBassDifficulty3.TabIndex = 23;
            this.PictureProBassDifficulty3.TabStop = false;
            this.PictureProBassDifficulty3.Tag = "3";
            this.PictureProBassDifficulty3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProBassDifficulty3.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProBassDifficulty3.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureBassDifficulty5
            // 
            this.PictureBassDifficulty5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBassDifficulty5.Enabled = false;
            this.PictureBassDifficulty5.Location = new System.Drawing.Point(164, 55);
            this.PictureBassDifficulty5.Name = "PictureBassDifficulty5";
            this.PictureBassDifficulty5.Size = new System.Drawing.Size(14, 13);
            this.PictureBassDifficulty5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBassDifficulty5.TabIndex = 25;
            this.PictureBassDifficulty5.TabStop = false;
            this.PictureBassDifficulty5.Tag = "5";
            this.PictureBassDifficulty5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBassDifficulty5.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBassDifficulty5.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProBassDifficulty2
            // 
            this.PictureProBassDifficulty2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProBassDifficulty2.Enabled = false;
            this.PictureProBassDifficulty2.Location = new System.Drawing.Point(122, 92);
            this.PictureProBassDifficulty2.Name = "PictureProBassDifficulty2";
            this.PictureProBassDifficulty2.Size = new System.Drawing.Size(14, 13);
            this.PictureProBassDifficulty2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProBassDifficulty2.TabIndex = 22;
            this.PictureProBassDifficulty2.TabStop = false;
            this.PictureProBassDifficulty2.Tag = "2";
            this.PictureProBassDifficulty2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProBassDifficulty2.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProBassDifficulty2.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureBassDifficulty4
            // 
            this.PictureBassDifficulty4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBassDifficulty4.Enabled = false;
            this.PictureBassDifficulty4.Location = new System.Drawing.Point(150, 55);
            this.PictureBassDifficulty4.Name = "PictureBassDifficulty4";
            this.PictureBassDifficulty4.Size = new System.Drawing.Size(14, 13);
            this.PictureBassDifficulty4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBassDifficulty4.TabIndex = 24;
            this.PictureBassDifficulty4.TabStop = false;
            this.PictureBassDifficulty4.Tag = "4";
            this.PictureBassDifficulty4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBassDifficulty4.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBassDifficulty4.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProBassDifficulty7
            // 
            this.PictureProBassDifficulty7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProBassDifficulty7.Enabled = false;
            this.PictureProBassDifficulty7.Location = new System.Drawing.Point(196, 92);
            this.PictureProBassDifficulty7.Name = "PictureProBassDifficulty7";
            this.PictureProBassDifficulty7.Size = new System.Drawing.Size(13, 13);
            this.PictureProBassDifficulty7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProBassDifficulty7.TabIndex = 21;
            this.PictureProBassDifficulty7.TabStop = false;
            this.PictureProBassDifficulty7.Tag = "7";
            this.PictureProBassDifficulty7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProBassDifficulty7.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProBassDifficulty7.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureDrumDifficulty5
            // 
            this.PictureDrumDifficulty5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureDrumDifficulty5.Enabled = false;
            this.PictureDrumDifficulty5.Location = new System.Drawing.Point(164, 17);
            this.PictureDrumDifficulty5.Name = "PictureDrumDifficulty5";
            this.PictureDrumDifficulty5.Size = new System.Drawing.Size(14, 13);
            this.PictureDrumDifficulty5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDrumDifficulty5.TabIndex = 18;
            this.PictureDrumDifficulty5.TabStop = false;
            this.PictureDrumDifficulty5.Tag = "5";
            this.PictureDrumDifficulty5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureDrumDifficulty5.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureDrumDifficulty5.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureProBassDifficulty1
            // 
            this.PictureProBassDifficulty1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureProBassDifficulty1.Enabled = false;
            this.PictureProBassDifficulty1.Location = new System.Drawing.Point(104, 92);
            this.PictureProBassDifficulty1.Name = "PictureProBassDifficulty1";
            this.PictureProBassDifficulty1.Size = new System.Drawing.Size(14, 13);
            this.PictureProBassDifficulty1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureProBassDifficulty1.TabIndex = 20;
            this.PictureProBassDifficulty1.TabStop = false;
            this.PictureProBassDifficulty1.Tag = "1";
            this.PictureProBassDifficulty1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureProDifficulty);
            this.PictureProBassDifficulty1.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureProBassDifficulty1.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureBassDifficulty3
            // 
            this.PictureBassDifficulty3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBassDifficulty3.Enabled = false;
            this.PictureBassDifficulty3.Location = new System.Drawing.Point(136, 55);
            this.PictureBassDifficulty3.Name = "PictureBassDifficulty3";
            this.PictureBassDifficulty3.Size = new System.Drawing.Size(14, 13);
            this.PictureBassDifficulty3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBassDifficulty3.TabIndex = 23;
            this.PictureBassDifficulty3.TabStop = false;
            this.PictureBassDifficulty3.Tag = "3";
            this.PictureBassDifficulty3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBassDifficulty3.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBassDifficulty3.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // chkProGuitar
            // 
            this.chkProGuitar.AutoSize = true;
            this.chkProGuitar.BackColor = System.Drawing.Color.Transparent;
            this.chkProGuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkProGuitar.Enabled = false;
            this.chkProGuitar.Location = new System.Drawing.Point(13, 165);
            this.chkProGuitar.Name = "chkProGuitar";
            this.chkProGuitar.Size = new System.Drawing.Size(15, 14);
            this.chkProGuitar.TabIndex = 28;
            this.ToolTip.SetToolTip(this.chkProGuitar, "Check if your song has pro guitar charted");
            this.chkProGuitar.UseVisualStyleBackColor = false;
            this.chkProGuitar.CheckedChanged += new System.EventHandler(this.chkProGuitar_CheckedChanged);
            // 
            // PictureBassDifficulty2
            // 
            this.PictureBassDifficulty2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBassDifficulty2.Enabled = false;
            this.PictureBassDifficulty2.Location = new System.Drawing.Point(122, 55);
            this.PictureBassDifficulty2.Name = "PictureBassDifficulty2";
            this.PictureBassDifficulty2.Size = new System.Drawing.Size(14, 13);
            this.PictureBassDifficulty2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBassDifficulty2.TabIndex = 22;
            this.PictureBassDifficulty2.TabStop = false;
            this.PictureBassDifficulty2.Tag = "2";
            this.PictureBassDifficulty2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBassDifficulty2.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBassDifficulty2.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureDrumDifficulty4
            // 
            this.PictureDrumDifficulty4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureDrumDifficulty4.Enabled = false;
            this.PictureDrumDifficulty4.Location = new System.Drawing.Point(150, 17);
            this.PictureDrumDifficulty4.Name = "PictureDrumDifficulty4";
            this.PictureDrumDifficulty4.Size = new System.Drawing.Size(14, 13);
            this.PictureDrumDifficulty4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDrumDifficulty4.TabIndex = 17;
            this.PictureDrumDifficulty4.TabStop = false;
            this.PictureDrumDifficulty4.Tag = "4";
            this.PictureDrumDifficulty4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureDrumDifficulty4.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureDrumDifficulty4.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureBassDifficulty7
            // 
            this.PictureBassDifficulty7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBassDifficulty7.Enabled = false;
            this.PictureBassDifficulty7.Location = new System.Drawing.Point(196, 55);
            this.PictureBassDifficulty7.Name = "PictureBassDifficulty7";
            this.PictureBassDifficulty7.Size = new System.Drawing.Size(13, 13);
            this.PictureBassDifficulty7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBassDifficulty7.TabIndex = 21;
            this.PictureBassDifficulty7.TabStop = false;
            this.PictureBassDifficulty7.Tag = "7";
            this.PictureBassDifficulty7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBassDifficulty7.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBassDifficulty7.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // LabelProGuitar
            // 
            this.LabelProGuitar.BackColor = System.Drawing.Color.Transparent;
            this.LabelProGuitar.ForeColor = System.Drawing.Color.IndianRed;
            this.LabelProGuitar.Location = new System.Drawing.Point(30, 164);
            this.LabelProGuitar.Name = "LabelProGuitar";
            this.LabelProGuitar.Size = new System.Drawing.Size(68, 15);
            this.LabelProGuitar.TabIndex = 114;
            this.LabelProGuitar.Text = "Pro Guitar:";
            this.LabelProGuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PictureBassDifficulty1
            // 
            this.PictureBassDifficulty1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBassDifficulty1.Enabled = false;
            this.PictureBassDifficulty1.Location = new System.Drawing.Point(104, 55);
            this.PictureBassDifficulty1.Name = "PictureBassDifficulty1";
            this.PictureBassDifficulty1.Size = new System.Drawing.Size(14, 13);
            this.PictureBassDifficulty1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBassDifficulty1.TabIndex = 20;
            this.PictureBassDifficulty1.TabStop = false;
            this.PictureBassDifficulty1.Tag = "1";
            this.PictureBassDifficulty1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureBassDifficulty1.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureBassDifficulty1.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureDrumDifficulty3
            // 
            this.PictureDrumDifficulty3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureDrumDifficulty3.Enabled = false;
            this.PictureDrumDifficulty3.Location = new System.Drawing.Point(136, 17);
            this.PictureDrumDifficulty3.Name = "PictureDrumDifficulty3";
            this.PictureDrumDifficulty3.Size = new System.Drawing.Size(14, 13);
            this.PictureDrumDifficulty3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDrumDifficulty3.TabIndex = 16;
            this.PictureDrumDifficulty3.TabStop = false;
            this.PictureDrumDifficulty3.Tag = "3";
            this.PictureDrumDifficulty3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureDrumDifficulty3.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureDrumDifficulty3.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // PictureDrumDifficulty2
            // 
            this.PictureDrumDifficulty2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureDrumDifficulty2.Enabled = false;
            this.PictureDrumDifficulty2.Location = new System.Drawing.Point(122, 17);
            this.PictureDrumDifficulty2.Name = "PictureDrumDifficulty2";
            this.PictureDrumDifficulty2.Size = new System.Drawing.Size(14, 13);
            this.PictureDrumDifficulty2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDrumDifficulty2.TabIndex = 15;
            this.PictureDrumDifficulty2.TabStop = false;
            this.PictureDrumDifficulty2.Tag = "2";
            this.PictureDrumDifficulty2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureDrumDifficulty2.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureDrumDifficulty2.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // chkProBass
            // 
            this.chkProBass.AutoSize = true;
            this.chkProBass.BackColor = System.Drawing.Color.Transparent;
            this.chkProBass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkProBass.Enabled = false;
            this.chkProBass.Location = new System.Drawing.Point(13, 92);
            this.chkProBass.Name = "chkProBass";
            this.chkProBass.Size = new System.Drawing.Size(15, 14);
            this.chkProBass.TabIndex = 27;
            this.ToolTip.SetToolTip(this.chkProBass, "Check if your song has pro bass charted");
            this.chkProBass.UseVisualStyleBackColor = false;
            this.chkProBass.CheckedChanged += new System.EventHandler(this.chkProBass_CheckedChanged);
            // 
            // PictureDrumDifficulty7
            // 
            this.PictureDrumDifficulty7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureDrumDifficulty7.Enabled = false;
            this.PictureDrumDifficulty7.Location = new System.Drawing.Point(196, 17);
            this.PictureDrumDifficulty7.Name = "PictureDrumDifficulty7";
            this.PictureDrumDifficulty7.Size = new System.Drawing.Size(13, 13);
            this.PictureDrumDifficulty7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDrumDifficulty7.TabIndex = 7;
            this.PictureDrumDifficulty7.TabStop = false;
            this.PictureDrumDifficulty7.Tag = "7";
            this.PictureDrumDifficulty7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureDrumDifficulty7.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureDrumDifficulty7.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // LabelProBass
            // 
            this.LabelProBass.BackColor = System.Drawing.Color.Transparent;
            this.LabelProBass.ForeColor = System.Drawing.Color.IndianRed;
            this.LabelProBass.Location = new System.Drawing.Point(30, 90);
            this.LabelProBass.Name = "LabelProBass";
            this.LabelProBass.Size = new System.Drawing.Size(68, 15);
            this.LabelProBass.TabIndex = 111;
            this.LabelProBass.Text = "Pro Bass:";
            this.LabelProBass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PictureDrumDifficulty1
            // 
            this.PictureDrumDifficulty1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureDrumDifficulty1.Enabled = false;
            this.PictureDrumDifficulty1.Location = new System.Drawing.Point(104, 17);
            this.PictureDrumDifficulty1.Name = "PictureDrumDifficulty1";
            this.PictureDrumDifficulty1.Size = new System.Drawing.Size(14, 13);
            this.PictureDrumDifficulty1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureDrumDifficulty1.TabIndex = 6;
            this.PictureDrumDifficulty1.TabStop = false;
            this.PictureDrumDifficulty1.Tag = "1";
            this.PictureDrumDifficulty1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Difficulty_Click);
            this.PictureDrumDifficulty1.MouseEnter += new System.EventHandler(this.DifficultyHover);
            this.PictureDrumDifficulty1.MouseLeave += new System.EventHandler(this.DifficultyLeave);
            // 
            // chkProKeys
            // 
            this.chkProKeys.AutoSize = true;
            this.chkProKeys.BackColor = System.Drawing.Color.Transparent;
            this.chkProKeys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkProKeys.Enabled = false;
            this.chkProKeys.Location = new System.Drawing.Point(13, 278);
            this.chkProKeys.Name = "chkProKeys";
            this.chkProKeys.Size = new System.Drawing.Size(15, 14);
            this.chkProKeys.TabIndex = 29;
            this.ToolTip.SetToolTip(this.chkProKeys, "Uncheck to disable pro keys");
            this.chkProKeys.UseVisualStyleBackColor = false;
            this.chkProKeys.CheckedChanged += new System.EventHandler(this.chkProKeys_CheckedChanged);
            // 
            // LabelProKeysDifficulty
            // 
            this.LabelProKeysDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.LabelProKeysDifficulty.ForeColor = System.Drawing.Color.IndianRed;
            this.LabelProKeysDifficulty.Location = new System.Drawing.Point(30, 276);
            this.LabelProKeysDifficulty.Name = "LabelProKeysDifficulty";
            this.LabelProKeysDifficulty.Size = new System.Drawing.Size(68, 15);
            this.LabelProKeysDifficulty.TabIndex = 36;
            this.LabelProKeysDifficulty.Text = "Pro Keys:";
            this.LabelProKeysDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelKeysDifficulty
            // 
            this.LabelKeysDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.LabelKeysDifficulty.ForeColor = System.Drawing.Color.IndianRed;
            this.LabelKeysDifficulty.Location = new System.Drawing.Point(30, 238);
            this.LabelKeysDifficulty.Name = "LabelKeysDifficulty";
            this.LabelKeysDifficulty.Size = new System.Drawing.Size(68, 15);
            this.LabelKeysDifficulty.TabIndex = 34;
            this.LabelKeysDifficulty.Text = "Keys:";
            this.LabelKeysDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelVocalDifficulty
            // 
            this.LabelVocalDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.LabelVocalDifficulty.ForeColor = System.Drawing.Color.IndianRed;
            this.LabelVocalDifficulty.Location = new System.Drawing.Point(30, 201);
            this.LabelVocalDifficulty.Name = "LabelVocalDifficulty";
            this.LabelVocalDifficulty.Size = new System.Drawing.Size(68, 15);
            this.LabelVocalDifficulty.TabIndex = 32;
            this.LabelVocalDifficulty.Text = "Vocals:";
            this.LabelVocalDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelGuitarDifficulty
            // 
            this.LabelGuitarDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.LabelGuitarDifficulty.ForeColor = System.Drawing.Color.IndianRed;
            this.LabelGuitarDifficulty.Location = new System.Drawing.Point(30, 127);
            this.LabelGuitarDifficulty.Name = "LabelGuitarDifficulty";
            this.LabelGuitarDifficulty.Size = new System.Drawing.Size(68, 15);
            this.LabelGuitarDifficulty.TabIndex = 31;
            this.LabelGuitarDifficulty.Text = "Guitar:";
            this.LabelGuitarDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelBassDifficulty
            // 
            this.LabelBassDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.LabelBassDifficulty.ForeColor = System.Drawing.Color.IndianRed;
            this.LabelBassDifficulty.Location = new System.Drawing.Point(30, 53);
            this.LabelBassDifficulty.Name = "LabelBassDifficulty";
            this.LabelBassDifficulty.Size = new System.Drawing.Size(68, 15);
            this.LabelBassDifficulty.TabIndex = 30;
            this.LabelBassDifficulty.Text = "Bass:";
            this.LabelBassDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelDrumDifficulty
            // 
            this.LabelDrumDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.LabelDrumDifficulty.ForeColor = System.Drawing.Color.IndianRed;
            this.LabelDrumDifficulty.Location = new System.Drawing.Point(30, 15);
            this.LabelDrumDifficulty.Name = "LabelDrumDifficulty";
            this.LabelDrumDifficulty.Size = new System.Drawing.Size(68, 15);
            this.LabelDrumDifficulty.TabIndex = 29;
            this.LabelDrumDifficulty.Text = "Drums:";
            this.LabelDrumDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelBandDifficulty
            // 
            this.LabelBandDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.LabelBandDifficulty.ForeColor = System.Drawing.Color.IndianRed;
            this.LabelBandDifficulty.Location = new System.Drawing.Point(30, 313);
            this.LabelBandDifficulty.Name = "LabelBandDifficulty";
            this.LabelBandDifficulty.Size = new System.Drawing.Size(68, 15);
            this.LabelBandDifficulty.TabIndex = 24;
            this.LabelBandDifficulty.Text = "Band:";
            this.LabelBandDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ButtonExportMIDI
            // 
            this.ButtonExportMIDI.BackColor = System.Drawing.Color.Black;
            this.ButtonExportMIDI.BackgroundImage = global::MagmaRokOn.Properties.Resources.button_bg_large;
            this.ButtonExportMIDI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonExportMIDI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExportMIDI.Enabled = false;
            this.ButtonExportMIDI.FlatAppearance.BorderSize = 0;
            this.ButtonExportMIDI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExportMIDI.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExportMIDI.ForeColor = System.Drawing.Color.White;
            this.ButtonExportMIDI.Location = new System.Drawing.Point(186, 68);
            this.ButtonExportMIDI.Name = "ButtonExportMIDI";
            this.ButtonExportMIDI.Size = new System.Drawing.Size(84, 22);
            this.ButtonExportMIDI.TabIndex = 3;
            this.ButtonExportMIDI.Text = "EXPORT";
            this.ToolTip.SetToolTip(this.ButtonExportMIDI, "Click to export a MIDI file with a venue track authored");
            this.ButtonExportMIDI.UseVisualStyleBackColor = false;
            this.ButtonExportMIDI.Click += new System.EventHandler(this.ButtonExportMIDI_Click);
            // 
            // chkTonality
            // 
            this.chkTonality.BackColor = System.Drawing.Color.Transparent;
            this.chkTonality.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkTonality.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.chkTonality.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkTonality.Location = new System.Drawing.Point(276, 318);
            this.chkTonality.Name = "chkTonality";
            this.chkTonality.Size = new System.Drawing.Size(92, 17);
            this.chkTonality.TabIndex = 170;
            this.chkTonality.Text = "TONALITY";
            this.ToolTip.SetToolTip(this.chkTonality, "Check to enable Vocal Tonic Note");
            this.chkTonality.UseVisualStyleBackColor = false;
            this.chkTonality.CheckedChanged += new System.EventHandler(this.chkTonality_CheckedChanged);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTemplateToolStripMenuItem,
            this.saveCurrentListAsTemplateToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(239, 48);
            // 
            // loadTemplateToolStripMenuItem
            // 
            this.loadTemplateToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.loadTemplateToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.loadTemplateToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.loadTemplateToolStripMenuItem.Name = "loadTemplateToolStripMenuItem";
            this.loadTemplateToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.loadTemplateToolStripMenuItem.Text = "Load existing template";
            this.loadTemplateToolStripMenuItem.Click += new System.EventHandler(this.loadTemplateToolStripMenuItem_Click);
            // 
            // saveCurrentListAsTemplateToolStripMenuItem
            // 
            this.saveCurrentListAsTemplateToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.saveCurrentListAsTemplateToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.saveCurrentListAsTemplateToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.saveCurrentListAsTemplateToolStripMenuItem.Name = "saveCurrentListAsTemplateToolStripMenuItem";
            this.saveCurrentListAsTemplateToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.saveCurrentListAsTemplateToolStripMenuItem.Text = "Save current list as template";
            this.saveCurrentListAsTemplateToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentListAsTemplateToolStripMenuItem_Click);
            // 
            // PanelFooter
            // 
            this.PanelFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelFooter.BackgroundImage = global::MagmaRokOn.Properties.Resources.footer;
            this.PanelFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PanelFooter.Controls.Add(this.ButtonBuildTo);
            this.PanelFooter.Controls.Add(this.pictureBox9);
            this.PanelFooter.Controls.Add(this.LabelBuildTo);
            this.PanelFooter.Controls.Add(this.ButtonBuildSong);
            this.PanelFooter.Controls.Add(this.TextBoxBuildDestination);
            this.PanelFooter.Location = new System.Drawing.Point(-1, 592);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(1016, 35);
            this.PanelFooter.TabIndex = 104;
            // 
            // ButtonBuildTo
            // 
            this.ButtonBuildTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBuildTo.BackColor = System.Drawing.Color.Black;
            this.ButtonBuildTo.BackgroundImage = global::MagmaRokOn.Properties.Resources.button_bg_small;
            this.ButtonBuildTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonBuildTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonBuildTo.FlatAppearance.BorderSize = 0;
            this.ButtonBuildTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonBuildTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBuildTo.ForeColor = System.Drawing.Color.White;
            this.ButtonBuildTo.Location = new System.Drawing.Point(867, 6);
            this.ButtonBuildTo.Name = "ButtonBuildTo";
            this.ButtonBuildTo.Size = new System.Drawing.Size(28, 22);
            this.ButtonBuildTo.TabIndex = 139;
            this.ButtonBuildTo.Text = "...";
            this.ButtonBuildTo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolTip.SetToolTip(this.ButtonBuildTo, "Click to change where the RBA file will be saved");
            this.ButtonBuildTo.UseVisualStyleBackColor = false;
            this.ButtonBuildTo.Click += new System.EventHandler(this.ButtonBuildTo_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox9.Image = global::MagmaRokOn.Properties.Resources.footer_divider;
            this.pictureBox9.Location = new System.Drawing.Point(901, -4);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(3, 35);
            this.pictureBox9.TabIndex = 65;
            this.pictureBox9.TabStop = false;
            // 
            // LabelBuildTo
            // 
            this.LabelBuildTo.AutoSize = true;
            this.LabelBuildTo.BackColor = System.Drawing.Color.Transparent;
            this.LabelBuildTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBuildTo.ForeColor = System.Drawing.Color.LightGray;
            this.LabelBuildTo.Location = new System.Drawing.Point(7, 11);
            this.LabelBuildTo.Name = "LabelBuildTo";
            this.LabelBuildTo.Size = new System.Drawing.Size(61, 13);
            this.LabelBuildTo.TabIndex = 13;
            this.LabelBuildTo.Tag = "LabelBuildToTooltip";
            this.LabelBuildTo.Text = "File Path:";
            this.LabelBuildTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonBuildSong
            // 
            this.ButtonBuildSong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBuildSong.BackColor = System.Drawing.Color.Black;
            this.ButtonBuildSong.BackgroundImage = global::MagmaRokOn.Properties.Resources.button_bg_large;
            this.ButtonBuildSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonBuildSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonBuildSong.FlatAppearance.BorderSize = 0;
            this.ButtonBuildSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonBuildSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBuildSong.ForeColor = System.Drawing.Color.White;
            this.ButtonBuildSong.Location = new System.Drawing.Point(912, 6);
            this.ButtonBuildSong.Name = "ButtonBuildSong";
            this.ButtonBuildSong.Size = new System.Drawing.Size(92, 22);
            this.ButtonBuildSong.TabIndex = 63;
            this.ButtonBuildSong.Text = "BUILD SONG";
            this.ToolTip.SetToolTip(this.ButtonBuildSong, "Click here to build your song");
            this.ButtonBuildSong.UseVisualStyleBackColor = false;
            this.ButtonBuildSong.Click += new System.EventHandler(this.ButtonBuildSong_Click);
            // 
            // TextBoxBuildDestination
            // 
            this.TextBoxBuildDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxBuildDestination.BackColor = System.Drawing.Color.White;
            this.TextBoxBuildDestination.ForeColor = System.Drawing.Color.Black;
            this.TextBoxBuildDestination.Location = new System.Drawing.Point(70, 7);
            this.TextBoxBuildDestination.MaxLength = 250;
            this.TextBoxBuildDestination.Name = "TextBoxBuildDestination";
            this.TextBoxBuildDestination.Size = new System.Drawing.Size(791, 20);
            this.TextBoxBuildDestination.TabIndex = 29;
            this.TextBoxBuildDestination.Tag = "Build To";
            this.ToolTip.SetToolTip(this.TextBoxBuildDestination, "This is where your .rba file will be created");
            this.TextBoxBuildDestination.TextChanged += new System.EventHandler(this.TextBoxBuildDestination_TextChanged);
            this.TextBoxBuildDestination.Leave += new System.EventHandler(this.TextBoxBuildDestination_Leave);
            // 
            // ErrorProviderCharCheck
            // 
            this.ErrorProviderCharCheck.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorProviderCharCheck.ContainerControl = this;
            // 
            // ToolTip
            // 
            this.ToolTip.AutoPopDelay = 2000;
            this.ToolTip.InitialDelay = 500;
            this.ToolTip.IsBalloon = true;
            this.ToolTip.ReshowDelay = 100;
            this.ToolTip.ShowAlways = true;
            // 
            // ButtonGameDataTab
            // 
            this.ButtonGameDataTab.BackColor = System.Drawing.Color.Black;
            this.ButtonGameDataTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonGameDataTab.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonGameDataTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.ButtonGameDataTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGameDataTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGameDataTab.ForeColor = System.Drawing.Color.Gainsboro;
            this.ButtonGameDataTab.Location = new System.Drawing.Point(241, 28);
            this.ButtonGameDataTab.Name = "ButtonGameDataTab";
            this.ButtonGameDataTab.Size = new System.Drawing.Size(103, 23);
            this.ButtonGameDataTab.TabIndex = 31;
            this.ButtonGameDataTab.Text = "GAME DATA";
            this.ToolTip.SetToolTip(this.ButtonGameDataTab, "Click to change the song\'s game data");
            this.ButtonGameDataTab.UseVisualStyleBackColor = false;
            this.ButtonGameDataTab.Click += new System.EventHandler(this.ChangeTab);
            this.ButtonGameDataTab.MouseEnter += new System.EventHandler(this.TabHover);
            this.ButtonGameDataTab.MouseLeave += new System.EventHandler(this.TabEndHover);
            // 
            // ButtonAudioTab
            // 
            this.ButtonAudioTab.BackColor = System.Drawing.Color.Black;
            this.ButtonAudioTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAudioTab.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonAudioTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.ButtonAudioTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAudioTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAudioTab.ForeColor = System.Drawing.Color.LightGray;
            this.ButtonAudioTab.Location = new System.Drawing.Point(139, 28);
            this.ButtonAudioTab.Name = "ButtonAudioTab";
            this.ButtonAudioTab.Size = new System.Drawing.Size(96, 23);
            this.ButtonAudioTab.TabIndex = 30;
            this.ButtonAudioTab.Text = "AUDIO";
            this.ToolTip.SetToolTip(this.ButtonAudioTab, "Click here to select audio files and settings");
            this.ButtonAudioTab.UseVisualStyleBackColor = false;
            this.ButtonAudioTab.Click += new System.EventHandler(this.ChangeTab);
            this.ButtonAudioTab.MouseEnter += new System.EventHandler(this.TabHover);
            this.ButtonAudioTab.MouseLeave += new System.EventHandler(this.TabEndHover);
            // 
            // ButtonInformationTab
            // 
            this.ButtonInformationTab.BackColor = System.Drawing.Color.Black;
            this.ButtonInformationTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonInformationTab.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonInformationTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.ButtonInformationTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonInformationTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonInformationTab.ForeColor = System.Drawing.Color.LightGray;
            this.ButtonInformationTab.Location = new System.Drawing.Point(8, 28);
            this.ButtonInformationTab.Name = "ButtonInformationTab";
            this.ButtonInformationTab.Size = new System.Drawing.Size(125, 23);
            this.ButtonInformationTab.TabIndex = 0;
            this.ButtonInformationTab.Text = "INFORMATION";
            this.ToolTip.SetToolTip(this.ButtonInformationTab, "Click to change the song\'s metadata");
            this.ButtonInformationTab.UseVisualStyleBackColor = false;
            this.ButtonInformationTab.Click += new System.EventHandler(this.ChangeTab);
            this.ButtonInformationTab.MouseEnter += new System.EventHandler(this.TabHover);
            this.ButtonInformationTab.MouseLeave += new System.EventHandler(this.TabEndHover);
            // 
            // picTemplate
            // 
            this.picTemplate.ContextMenuStrip = this.contextMenuStrip3;
            this.picTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTemplate.Location = new System.Drawing.Point(4, 67);
            this.picTemplate.Name = "picTemplate";
            this.picTemplate.Size = new System.Drawing.Size(26, 25);
            this.picTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTemplate.TabIndex = 1;
            this.picTemplate.TabStop = false;
            this.ToolTip.SetToolTip(this.picTemplate, "Click to view template options");
            this.picTemplate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picTemplate_MouseClick);
            // 
            // picImportant
            // 
            this.picImportant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImportant.Location = new System.Drawing.Point(128, 66);
            this.picImportant.Name = "picImportant";
            this.picImportant.Size = new System.Drawing.Size(25, 25);
            this.picImportant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImportant.TabIndex = 2;
            this.picImportant.TabStop = false;
            this.ToolTip.SetToolTip(this.picImportant, "Click to mark item as REQUIRED");
            this.picImportant.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picImportant_MouseClick);
            // 
            // picRemove
            // 
            this.picRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRemove.Location = new System.Drawing.Point(216, 66);
            this.picRemove.Name = "picRemove";
            this.picRemove.Size = new System.Drawing.Size(25, 25);
            this.picRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRemove.TabIndex = 3;
            this.picRemove.TabStop = false;
            this.ToolTip.SetToolTip(this.picRemove, "Click to REMOVE item");
            this.picRemove.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picRemove_MouseClick);
            // 
            // picDone
            // 
            this.picDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDone.Location = new System.Drawing.Point(172, 66);
            this.picDone.Name = "picDone";
            this.picDone.Size = new System.Drawing.Size(25, 25);
            this.picDone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDone.TabIndex = 4;
            this.picDone.TabStop = false;
            this.ToolTip.SetToolTip(this.picDone, "Click to mark item as COMPLETED");
            this.picDone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDone_MouseClick);
            // 
            // picWii
            // 
            this.picWii.BackColor = System.Drawing.Color.Transparent;
            this.picWii.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picWii.Location = new System.Drawing.Point(366, 8);
            this.picWii.Name = "picWii";
            this.picWii.Size = new System.Drawing.Size(79, 40);
            this.picWii.TabIndex = 33;
            this.picWii.TabStop = false;
            this.ToolTip.SetToolTip(this.picWii, "Wii Mode is enabled - click to disable");
            this.picWii.Visible = false;
            this.picWii.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picWii_MouseClick);
            // 
            // PictureBoxMagmaLogoTop
            // 
            this.PictureBoxMagmaLogoTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBoxMagmaLogoTop.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxMagmaLogoTop.BackgroundImage = global::MagmaRokOn.Properties.Resources.header_fire;
            this.PictureBoxMagmaLogoTop.Image = global::MagmaRokOn.Properties.Resources.magma_logo_sized;
            this.PictureBoxMagmaLogoTop.Location = new System.Drawing.Point(786, 11);
            this.PictureBoxMagmaLogoTop.Margin = new System.Windows.Forms.Padding(0);
            this.PictureBoxMagmaLogoTop.Name = "PictureBoxMagmaLogoTop";
            this.PictureBoxMagmaLogoTop.Size = new System.Drawing.Size(220, 42);
            this.PictureBoxMagmaLogoTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBoxMagmaLogoTop.TabIndex = 102;
            this.PictureBoxMagmaLogoTop.TabStop = false;
            // 
            // PanelHeader
            // 
            this.PanelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelHeader.BackgroundImage = global::MagmaRokOn.Properties.Resources.header_fire;
            this.PanelHeader.Controls.Add(this.picWii);
            this.PanelHeader.Controls.Add(this.picChecklist);
            this.PanelHeader.Controls.Add(this.ButtonGameDataTab);
            this.PanelHeader.Controls.Add(this.ButtonAudioTab);
            this.PanelHeader.Controls.Add(this.ButtonInformationTab);
            this.PanelHeader.Location = new System.Drawing.Point(-1, 3);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(1018, 50);
            this.PanelHeader.TabIndex = 100;
            // 
            // picChecklist
            // 
            this.picChecklist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picChecklist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picChecklist.Location = new System.Drawing.Point(740, 8);
            this.picChecklist.Name = "picChecklist";
            this.picChecklist.Size = new System.Drawing.Size(26, 40);
            this.picChecklist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picChecklist.TabIndex = 32;
            this.picChecklist.TabStop = false;
            this.picChecklist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picChecklist_MouseClick);
            // 
            // todo1
            // 
            this.todo1.BackColor = System.Drawing.Color.Black;
            this.todo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo1.ForeColor = System.Drawing.Color.White;
            this.todo1.Location = new System.Drawing.Point(34, 103);
            this.todo1.MaxLength = 74;
            this.todo1.Name = "todo1";
            this.todo1.Size = new System.Drawing.Size(207, 20);
            this.todo1.TabIndex = 20;
            this.todo1.Tag = "0";
            this.todo1.Text = "Click to add new item...";
            this.todo1.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo1.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list1
            // 
            this.list1.BackColor = System.Drawing.Color.Black;
            this.list1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list1.ForeColor = System.Drawing.Color.White;
            this.list1.Location = new System.Drawing.Point(7, 103);
            this.list1.MaxLength = 74;
            this.list1.Name = "list1";
            this.list1.ReadOnly = true;
            this.list1.Size = new System.Drawing.Size(21, 20);
            this.list1.TabIndex = 21;
            this.list1.Tag = "";
            this.list1.Text = "1.";
            this.list1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo2
            // 
            this.todo2.BackColor = System.Drawing.Color.Black;
            this.todo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo2.ForeColor = System.Drawing.Color.White;
            this.todo2.Location = new System.Drawing.Point(34, 129);
            this.todo2.MaxLength = 74;
            this.todo2.Name = "todo2";
            this.todo2.Size = new System.Drawing.Size(207, 20);
            this.todo2.TabIndex = 22;
            this.todo2.Tag = "1";
            this.todo2.Text = "Click to add new item...";
            this.todo2.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo2.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list2
            // 
            this.list2.BackColor = System.Drawing.Color.Black;
            this.list2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list2.ForeColor = System.Drawing.Color.White;
            this.list2.Location = new System.Drawing.Point(7, 129);
            this.list2.MaxLength = 74;
            this.list2.Name = "list2";
            this.list2.ReadOnly = true;
            this.list2.Size = new System.Drawing.Size(21, 20);
            this.list2.TabIndex = 23;
            this.list2.Tag = "";
            this.list2.Text = "2.";
            this.list2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo3
            // 
            this.todo3.BackColor = System.Drawing.Color.Black;
            this.todo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo3.ForeColor = System.Drawing.Color.White;
            this.todo3.Location = new System.Drawing.Point(34, 155);
            this.todo3.MaxLength = 74;
            this.todo3.Name = "todo3";
            this.todo3.Size = new System.Drawing.Size(207, 20);
            this.todo3.TabIndex = 24;
            this.todo3.Tag = "2";
            this.todo3.Text = "Click to add new item...";
            this.todo3.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo3.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list3
            // 
            this.list3.BackColor = System.Drawing.Color.Black;
            this.list3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list3.ForeColor = System.Drawing.Color.White;
            this.list3.Location = new System.Drawing.Point(7, 155);
            this.list3.MaxLength = 74;
            this.list3.Name = "list3";
            this.list3.ReadOnly = true;
            this.list3.Size = new System.Drawing.Size(21, 20);
            this.list3.TabIndex = 25;
            this.list3.Tag = "";
            this.list3.Text = "3.";
            this.list3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo4
            // 
            this.todo4.BackColor = System.Drawing.Color.Black;
            this.todo4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo4.ForeColor = System.Drawing.Color.White;
            this.todo4.Location = new System.Drawing.Point(34, 181);
            this.todo4.MaxLength = 74;
            this.todo4.Name = "todo4";
            this.todo4.Size = new System.Drawing.Size(207, 20);
            this.todo4.TabIndex = 26;
            this.todo4.Tag = "3";
            this.todo4.Text = "Click to add new item...";
            this.todo4.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo4.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list4
            // 
            this.list4.BackColor = System.Drawing.Color.Black;
            this.list4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list4.ForeColor = System.Drawing.Color.White;
            this.list4.Location = new System.Drawing.Point(7, 181);
            this.list4.MaxLength = 74;
            this.list4.Name = "list4";
            this.list4.ReadOnly = true;
            this.list4.Size = new System.Drawing.Size(21, 20);
            this.list4.TabIndex = 27;
            this.list4.Tag = "";
            this.list4.Text = "4.";
            this.list4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo5
            // 
            this.todo5.BackColor = System.Drawing.Color.Black;
            this.todo5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo5.ForeColor = System.Drawing.Color.White;
            this.todo5.Location = new System.Drawing.Point(34, 207);
            this.todo5.MaxLength = 74;
            this.todo5.Name = "todo5";
            this.todo5.Size = new System.Drawing.Size(207, 20);
            this.todo5.TabIndex = 28;
            this.todo5.Tag = "4";
            this.todo5.Text = "Click to add new item...";
            this.todo5.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo5.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list5
            // 
            this.list5.BackColor = System.Drawing.Color.Black;
            this.list5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list5.ForeColor = System.Drawing.Color.White;
            this.list5.Location = new System.Drawing.Point(7, 207);
            this.list5.MaxLength = 74;
            this.list5.Name = "list5";
            this.list5.ReadOnly = true;
            this.list5.Size = new System.Drawing.Size(21, 20);
            this.list5.TabIndex = 29;
            this.list5.Tag = "";
            this.list5.Text = "5.";
            this.list5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo6
            // 
            this.todo6.BackColor = System.Drawing.Color.Black;
            this.todo6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo6.ForeColor = System.Drawing.Color.White;
            this.todo6.Location = new System.Drawing.Point(34, 233);
            this.todo6.MaxLength = 74;
            this.todo6.Name = "todo6";
            this.todo6.Size = new System.Drawing.Size(207, 20);
            this.todo6.TabIndex = 30;
            this.todo6.Tag = "5";
            this.todo6.Text = "Click to add new item...";
            this.todo6.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo6.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list6
            // 
            this.list6.BackColor = System.Drawing.Color.Black;
            this.list6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list6.ForeColor = System.Drawing.Color.White;
            this.list6.Location = new System.Drawing.Point(7, 233);
            this.list6.MaxLength = 74;
            this.list6.Name = "list6";
            this.list6.ReadOnly = true;
            this.list6.Size = new System.Drawing.Size(21, 20);
            this.list6.TabIndex = 31;
            this.list6.Tag = "";
            this.list6.Text = "6.";
            this.list6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo7
            // 
            this.todo7.BackColor = System.Drawing.Color.Black;
            this.todo7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo7.ForeColor = System.Drawing.Color.White;
            this.todo7.Location = new System.Drawing.Point(34, 259);
            this.todo7.MaxLength = 74;
            this.todo7.Name = "todo7";
            this.todo7.Size = new System.Drawing.Size(207, 20);
            this.todo7.TabIndex = 32;
            this.todo7.Tag = "6";
            this.todo7.Text = "Click to add new item...";
            this.todo7.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo7.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list7
            // 
            this.list7.BackColor = System.Drawing.Color.Black;
            this.list7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list7.ForeColor = System.Drawing.Color.White;
            this.list7.Location = new System.Drawing.Point(7, 259);
            this.list7.MaxLength = 74;
            this.list7.Name = "list7";
            this.list7.ReadOnly = true;
            this.list7.Size = new System.Drawing.Size(21, 20);
            this.list7.TabIndex = 33;
            this.list7.Tag = "";
            this.list7.Text = "7.";
            this.list7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo8
            // 
            this.todo8.BackColor = System.Drawing.Color.Black;
            this.todo8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo8.ForeColor = System.Drawing.Color.White;
            this.todo8.Location = new System.Drawing.Point(34, 285);
            this.todo8.MaxLength = 74;
            this.todo8.Name = "todo8";
            this.todo8.Size = new System.Drawing.Size(207, 20);
            this.todo8.TabIndex = 34;
            this.todo8.Tag = "7";
            this.todo8.Text = "Click to add new item...";
            this.todo8.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo8.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list8
            // 
            this.list8.BackColor = System.Drawing.Color.Black;
            this.list8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list8.ForeColor = System.Drawing.Color.White;
            this.list8.Location = new System.Drawing.Point(7, 285);
            this.list8.MaxLength = 74;
            this.list8.Name = "list8";
            this.list8.ReadOnly = true;
            this.list8.Size = new System.Drawing.Size(21, 20);
            this.list8.TabIndex = 35;
            this.list8.Tag = "";
            this.list8.Text = "8.";
            this.list8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo9
            // 
            this.todo9.BackColor = System.Drawing.Color.Black;
            this.todo9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo9.ForeColor = System.Drawing.Color.White;
            this.todo9.Location = new System.Drawing.Point(34, 311);
            this.todo9.MaxLength = 74;
            this.todo9.Name = "todo9";
            this.todo9.Size = new System.Drawing.Size(207, 20);
            this.todo9.TabIndex = 36;
            this.todo9.Tag = "8";
            this.todo9.Text = "Click to add new item...";
            this.todo9.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo9.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list9
            // 
            this.list9.BackColor = System.Drawing.Color.Black;
            this.list9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list9.ForeColor = System.Drawing.Color.White;
            this.list9.Location = new System.Drawing.Point(7, 311);
            this.list9.MaxLength = 74;
            this.list9.Name = "list9";
            this.list9.ReadOnly = true;
            this.list9.Size = new System.Drawing.Size(21, 20);
            this.list9.TabIndex = 37;
            this.list9.Tag = "";
            this.list9.Text = "9.";
            this.list9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo10
            // 
            this.todo10.BackColor = System.Drawing.Color.Black;
            this.todo10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo10.ForeColor = System.Drawing.Color.White;
            this.todo10.Location = new System.Drawing.Point(34, 337);
            this.todo10.MaxLength = 74;
            this.todo10.Name = "todo10";
            this.todo10.Size = new System.Drawing.Size(207, 20);
            this.todo10.TabIndex = 38;
            this.todo10.Tag = "9";
            this.todo10.Text = "Click to add new item...";
            this.todo10.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo10.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list10
            // 
            this.list10.BackColor = System.Drawing.Color.Black;
            this.list10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list10.ForeColor = System.Drawing.Color.White;
            this.list10.Location = new System.Drawing.Point(7, 337);
            this.list10.MaxLength = 74;
            this.list10.Name = "list10";
            this.list10.ReadOnly = true;
            this.list10.Size = new System.Drawing.Size(21, 20);
            this.list10.TabIndex = 39;
            this.list10.Tag = "";
            this.list10.Text = "10.";
            this.list10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo11
            // 
            this.todo11.BackColor = System.Drawing.Color.Black;
            this.todo11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo11.ForeColor = System.Drawing.Color.White;
            this.todo11.Location = new System.Drawing.Point(34, 363);
            this.todo11.MaxLength = 74;
            this.todo11.Name = "todo11";
            this.todo11.Size = new System.Drawing.Size(207, 20);
            this.todo11.TabIndex = 40;
            this.todo11.Tag = "10";
            this.todo11.Text = "Click to add new item...";
            this.todo11.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo11.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list11
            // 
            this.list11.BackColor = System.Drawing.Color.Black;
            this.list11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list11.ForeColor = System.Drawing.Color.White;
            this.list11.Location = new System.Drawing.Point(7, 363);
            this.list11.MaxLength = 74;
            this.list11.Name = "list11";
            this.list11.ReadOnly = true;
            this.list11.Size = new System.Drawing.Size(21, 20);
            this.list11.TabIndex = 41;
            this.list11.Tag = "";
            this.list11.Text = "11.";
            this.list11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo12
            // 
            this.todo12.BackColor = System.Drawing.Color.Black;
            this.todo12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo12.ForeColor = System.Drawing.Color.White;
            this.todo12.Location = new System.Drawing.Point(34, 389);
            this.todo12.MaxLength = 74;
            this.todo12.Name = "todo12";
            this.todo12.Size = new System.Drawing.Size(207, 20);
            this.todo12.TabIndex = 42;
            this.todo12.Tag = "11";
            this.todo12.Text = "Click to add new item...";
            this.todo12.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo12.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list12
            // 
            this.list12.BackColor = System.Drawing.Color.Black;
            this.list12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list12.ForeColor = System.Drawing.Color.White;
            this.list12.Location = new System.Drawing.Point(7, 389);
            this.list12.MaxLength = 74;
            this.list12.Name = "list12";
            this.list12.ReadOnly = true;
            this.list12.Size = new System.Drawing.Size(21, 20);
            this.list12.TabIndex = 43;
            this.list12.Tag = "";
            this.list12.Text = "12.";
            this.list12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo13
            // 
            this.todo13.BackColor = System.Drawing.Color.Black;
            this.todo13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo13.ForeColor = System.Drawing.Color.White;
            this.todo13.Location = new System.Drawing.Point(34, 415);
            this.todo13.MaxLength = 74;
            this.todo13.Name = "todo13";
            this.todo13.Size = new System.Drawing.Size(207, 20);
            this.todo13.TabIndex = 44;
            this.todo13.Tag = "12";
            this.todo13.Text = "Click to add new item...";
            this.todo13.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo13.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list13
            // 
            this.list13.BackColor = System.Drawing.Color.Black;
            this.list13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list13.ForeColor = System.Drawing.Color.White;
            this.list13.Location = new System.Drawing.Point(7, 415);
            this.list13.MaxLength = 74;
            this.list13.Name = "list13";
            this.list13.ReadOnly = true;
            this.list13.Size = new System.Drawing.Size(21, 20);
            this.list13.TabIndex = 45;
            this.list13.Tag = "";
            this.list13.Text = "13.";
            this.list13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo14
            // 
            this.todo14.BackColor = System.Drawing.Color.Black;
            this.todo14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo14.ForeColor = System.Drawing.Color.White;
            this.todo14.Location = new System.Drawing.Point(34, 441);
            this.todo14.MaxLength = 74;
            this.todo14.Name = "todo14";
            this.todo14.Size = new System.Drawing.Size(207, 20);
            this.todo14.TabIndex = 46;
            this.todo14.Tag = "13";
            this.todo14.Text = "Click to add new item...";
            this.todo14.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo14.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list14
            // 
            this.list14.BackColor = System.Drawing.Color.Black;
            this.list14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list14.ForeColor = System.Drawing.Color.White;
            this.list14.Location = new System.Drawing.Point(7, 441);
            this.list14.MaxLength = 74;
            this.list14.Name = "list14";
            this.list14.ReadOnly = true;
            this.list14.Size = new System.Drawing.Size(21, 20);
            this.list14.TabIndex = 47;
            this.list14.Tag = "";
            this.list14.Text = "14.";
            this.list14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todo15
            // 
            this.todo15.BackColor = System.Drawing.Color.Black;
            this.todo15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todo15.ForeColor = System.Drawing.Color.White;
            this.todo15.Location = new System.Drawing.Point(34, 467);
            this.todo15.MaxLength = 74;
            this.todo15.Name = "todo15";
            this.todo15.Size = new System.Drawing.Size(207, 20);
            this.todo15.TabIndex = 48;
            this.todo15.Tag = "14";
            this.todo15.Text = "Click to add new item...";
            this.todo15.TextChanged += new System.EventHandler(this.todo1_TextChanged);
            this.todo15.Leave += new System.EventHandler(this.todo1_Leave);
            this.todo15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todo1_MouseDown);
            // 
            // list15
            // 
            this.list15.BackColor = System.Drawing.Color.Black;
            this.list15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list15.ForeColor = System.Drawing.Color.White;
            this.list15.Location = new System.Drawing.Point(7, 467);
            this.list15.MaxLength = 74;
            this.list15.Name = "list15";
            this.list15.ReadOnly = true;
            this.list15.Size = new System.Drawing.Size(21, 20);
            this.list15.TabIndex = 49;
            this.list15.Tag = "";
            this.list15.Text = "15.";
            this.list15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // todoPic
            // 
            this.todoPic.Image = global::MagmaRokOn.Properties.Resources.todo_fire;
            this.todoPic.Location = new System.Drawing.Point(5, 3);
            this.todoPic.Name = "todoPic";
            this.todoPic.Size = new System.Drawing.Size(242, 57);
            this.todoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.todoPic.TabIndex = 50;
            this.todoPic.TabStop = false;
            // 
            // panelTODO
            // 
            this.panelTODO.BackColor = System.Drawing.Color.Transparent;
            this.panelTODO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTODO.Controls.Add(this.todoPic);
            this.panelTODO.Controls.Add(this.list15);
            this.panelTODO.Controls.Add(this.todo15);
            this.panelTODO.Controls.Add(this.list14);
            this.panelTODO.Controls.Add(this.todo14);
            this.panelTODO.Controls.Add(this.list13);
            this.panelTODO.Controls.Add(this.todo13);
            this.panelTODO.Controls.Add(this.list12);
            this.panelTODO.Controls.Add(this.todo12);
            this.panelTODO.Controls.Add(this.list11);
            this.panelTODO.Controls.Add(this.todo11);
            this.panelTODO.Controls.Add(this.list10);
            this.panelTODO.Controls.Add(this.todo10);
            this.panelTODO.Controls.Add(this.list9);
            this.panelTODO.Controls.Add(this.todo9);
            this.panelTODO.Controls.Add(this.list8);
            this.panelTODO.Controls.Add(this.todo8);
            this.panelTODO.Controls.Add(this.list7);
            this.panelTODO.Controls.Add(this.todo7);
            this.panelTODO.Controls.Add(this.list6);
            this.panelTODO.Controls.Add(this.todo6);
            this.panelTODO.Controls.Add(this.list5);
            this.panelTODO.Controls.Add(this.todo5);
            this.panelTODO.Controls.Add(this.list4);
            this.panelTODO.Controls.Add(this.todo4);
            this.panelTODO.Controls.Add(this.list3);
            this.panelTODO.Controls.Add(this.todo3);
            this.panelTODO.Controls.Add(this.list2);
            this.panelTODO.Controls.Add(this.todo2);
            this.panelTODO.Controls.Add(this.list1);
            this.panelTODO.Controls.Add(this.todo1);
            this.panelTODO.Controls.Add(this.picDone);
            this.panelTODO.Controls.Add(this.picRemove);
            this.panelTODO.Controls.Add(this.picImportant);
            this.panelTODO.Controls.Add(this.picTemplate);
            this.panelTODO.Location = new System.Drawing.Point(748, 74);
            this.panelTODO.Name = "panelTODO";
            this.panelTODO.Size = new System.Drawing.Size(254, 502);
            this.panelTODO.TabIndex = 139;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(739, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 20);
            this.pictureBox1.TabIndex = 140;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(739, 576);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 16);
            this.pictureBox2.TabIndex = 141;
            this.pictureBox2.TabStop = false;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel12.Location = new System.Drawing.Point(753, 53);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(260, 1);
            this.panel12.TabIndex = 142;
            // 
            // PlaybackTimer
            // 
            this.PlaybackTimer.Interval = 50;
            this.PlaybackTimer.Tick += new System.EventHandler(this.PlaybackTimer_Tick);
            // 
            // updater
            // 
            this.updater.WorkerReportsProgress = true;
            this.updater.WorkerSupportsCancellation = true;
            this.updater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updater_DoWork);
            this.updater.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.updater_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1014, 626);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelTODO);
            this.Controls.Add(this.PictureBoxMagmaLogoTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.PanelHeader);
            this.Controls.Add(this.PanelFooter);
            this.Controls.Add(this.TopLevelTabs);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.DarkGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 700);
            this.MinimumSize = new System.Drawing.Size(750, 655);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magma: Rok On Edition v4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TopLevelTabs.ResumeLayout(false);
            this.TabPageInformation.ResumeLayout(false);
            this.TabPageInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPartial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUnpitched)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDIYStems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAuthor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumb)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picXOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConvert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMultitrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKaraoke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2xBass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRhythmBass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRhythmKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericTrackNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxAlbumArt)).EndInit();
            this.contextMenuStrip4.ResumeLayout(false);
            this.TabPageAudio.ResumeLayout(false);
            this.TabPageAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prevEndMilliseconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevEndMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpectrum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMilliseconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpCrowd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCrowd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBackingAttenuation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericVocalAttenuation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericKeysAttenuation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericGuitarAttenuation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBassAttenuation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDrumSnareAttenuation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDrumKickAttenuation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDrumKitAttenuation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBackingPan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericVocalPan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericKeysPan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericGuitarPan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericBassPan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDrumSnarePan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDrumKickPan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDrumKitPan)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupDrumMix.ResumeLayout(false);
            this.groupDrumMix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPreviewMins)).EndInit();
            this.TabPageGameData.ResumeLayout(false);
            this.TabPageGameData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpSolos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpMuteVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMuteVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVocalMute)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numVersion)).EndInit();
            this.groupID.ResumeLayout(false);
            this.groupID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDrumSFX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpTuningCents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTuningCents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpGuitarTuning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpTonicNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericGuidePitchAttenuation)).EndInit();
            this.GroupBoxDifficulty.ResumeLayout(false);
            this.GroupBoxDifficulty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBandDifficulty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProKeysDifficulty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureKeysDifficulty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureVocalDifficulty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProGuitarDifficulty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureGuitarDifficulty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureProBassDifficulty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBassDifficulty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDrumDifficulty1)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            this.PanelFooter.ResumeLayout(false);
            this.PanelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProviderCharCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImportant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWii)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMagmaLogoTop)).EndInit();
            this.PanelHeader.ResumeLayout(false);
            this.PanelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChecklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoPic)).EndInit();
            this.panelTODO.ResumeLayout(false);
            this.panelTODO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox chkTonicNote;
        private ComboBox ComboTonicNote;
        private PictureBox picHelpTonicNote;
        private ComboBox ComboRating;
        private Label LabelSongRating;
        private TextBox BassTuning4;
        private TextBox BassTuning3;
        private TextBox BassTuning2;
        private TextBox BassTuning1;
        private TextBox GuitarTuning6;
        private TextBox GuitarTuning5;
        private TextBox GuitarTuning4;
        private TextBox GuitarTuning3;
        private TextBox GuitarTuning2;
        private TextBox GuitarTuning1;
        private Label LabelBassTuning;
        private Label LabelGuitarTuning;
        private CheckBox chkProKeys;
        private Label LabelProBass;
        private PictureBox PictureProBassDifficulty6;
        private PictureBox PictureProBassDifficulty5;
        private PictureBox PictureProBassDifficulty4;
        private PictureBox PictureProBassDifficulty3;
        private PictureBox PictureProBassDifficulty2;
        private PictureBox PictureProBassDifficulty7;
        private PictureBox PictureProBassDifficulty1;
        private CheckBox chkProBass;
        private Label LabelProGuitar;
        private PictureBox PictureProGuitarDifficulty6;
        private PictureBox PictureProGuitarDifficulty5;
        private PictureBox PictureProGuitarDifficulty4;
        private PictureBox PictureProGuitarDifficulty3;
        private PictureBox PictureProGuitarDifficulty2;
        private PictureBox PictureProGuitarDifficulty7;
        private PictureBox PictureProGuitarDifficulty1;
        private CheckBox chkProGuitar;
        private PictureBox picHelpGuitarTuning;
        private CheckBox chkReRecord;
        private Label LabelReRecording;
        private NumericUpDown numericReRecord;
        private ComboBox ComboHopo;
        private Label LabelHopoThreshold;
        private ComboBox ComboDrumSFX;
        private Label LabelDrumKitSFX;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem keepSongsdtaFile;
        private ToolStripMenuItem doNotDeleteExtractedFiles;
        private Label LabelTuningCents;
        private NumericUpDown numericTuningCents;
        private PictureBox picHelpTuningCents;
        private ToolStripMenuItem showToast;
        private PictureBox picDrumSFX;
        private ToolStripMenuItem uTF8Menu;
        private ToolStripMenuItem aNSIMenu;
        private ToolStripMenuItem appendrb3conToFile;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem deleteRBAFiles;
        private GroupBox groupID;
        private TextBox txtSongID;
        private Label lblDrumMix;
        private GroupBox groupDrumMix;
        private DomainUpDown EncodingQualityUpDown;
        private Label LabelEncodingQuality;
        private Button btnCrowd;
        private TextBox TextBoxCrowd;
        private Label LabelCrowd;
        private CheckBox CheckCrowd;
        private Button ButtonBacking;
        private TextBox TextBoxBacking;
        private Label LabelBacking;
        private CheckBox CheckBacking;
        private CheckBox CheckHarmonyVocals3;
        private Label LabelDryVocalsHarmony3;
        private Button ButtonDryVocalsHarmony3;
        private TextBox TextBoxDryVocalsHarmony3;
        private CheckBox CheckHarmonyVocals2;
        private Label LabelDryVocalsHarmony2;
        private Button ButtonDryVocalsHarmony2;
        private Button ButtonDryVocals;
        private TextBox TextBoxDryVocals;
        private TextBox TextBoxDryVocalsHarmony2;
        private Label LabelDryVocals;
        private Button ButtonVocals;
        private TextBox TextBoxVocals;
        private Label LabelVocals;
        private CheckBox CheckVocals;
        private Button ButtonKeys;
        private TextBox TextBoxKeys;
        private Label LabelKeys;
        private CheckBox CheckKeys;
        private Button ButtonGuitar;
        private TextBox TextBoxGuitar;
        private Label LabelGuitar;
        private CheckBox CheckGuitar;
        private Button ButtonBass;
        private TextBox TextBoxBass;
        private Label LabelBass;
        private CheckBox CheckBass;
        private ComboBox ComboDrums;
        private Label LabelDrumSnare;
        private Label LabelDrumKick;
        private Label LabelDrumKit;
        private Button ButtonDrumSnare;
        private TextBox TextBoxDrumSnare;
        private Button ButtonDrumKick;
        private TextBox TextBoxDrumKick;
        private Button ButtonDrumKit;
        private Label LabelDrums;
        private TextBox TextBoxDrumKit;
        private CheckBox CheckDrums;
        private NumericUpDown NumericBackingAttenuation;
        private NumericUpDown NumericVocalAttenuation;
        private NumericUpDown NumericKeysAttenuation;
        private NumericUpDown NumericGuitarAttenuation;
        private NumericUpDown NumericBassAttenuation;
        private NumericUpDown NumericDrumSnareAttenuation;
        private NumericUpDown NumericDrumKickAttenuation;
        private NumericUpDown NumericDrumKitAttenuation;
        private Label LabelBackingPan;
        private NumericUpDown NumericBackingPan;
        private Label LabelVocalPan;
        private NumericUpDown NumericVocalPan;
        private Label LabelKeysPan;
        private NumericUpDown NumericKeysPan;
        private Label LabelGuitarPan;
        private NumericUpDown NumericGuitarPan;
        private Label LabelBassPan;
        private NumericUpDown NumericBassPan;
        private Label LabelDrumSnarePan;
        private Label LabelDrumKickPan;
        private Label LabelDrumKitPan;
        private NumericUpDown NumericDrumSnarePan;
        private NumericUpDown NumericDrumKickPan;
        private NumericUpDown NumericDrumKitPan;
        private Panel panel4;
        private Panel panel2;
        private Panel panel1;
        private Panel panel3;
        private CheckBox chkMaster;
        private Panel PanelFooter;
        private PictureBox pictureBox9;
        private Label LabelBuildTo;
        private Button ButtonBuildSong;
        private TextBox TextBoxBuildDestination;
        private Label label30;
        private Label label29;
        private Panel panel10;
        private Panel panel9;
        private Panel panel8;
        private Panel panel7;
        private Panel panel6;
        private Panel panel5;
        private Panel panel11;
        private GroupBox groupBox1;
        private ToolStripMenuItem appendSongVersionToFileName;
        private ToolStripMenuItem appendSongVersionToSongID;
        private Button ZeroDrumKit;
        private Button ZeroDrumSnare;
        private Button ZeroDrumKick;
        private Button ZeroBacking;
        private Button ZeroVocals;
        private Button ZeroKeys;
        private Button ZeroGuitar;
        private Button ZeroBass;
        private ToolStripMenuItem importSongToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem aDVANCEDUSEONLYToolStripMenuItem;
        private ToolStripMenuItem changeCompilerExecutable;
        private CheckBox chkXOnly;
        private PictureBox picXOnly;
        private CheckBox chkConvert;
        private CheckBox chkMultitrack;
        private CheckBox chkKaraoke;
        private PictureBox picConvert;
        private PictureBox picMultitrack;
        private PictureBox picKaraoke;
        private CheckBox chk2xBass;
        private CheckBox chkRhythmBass;
        private CheckBox chkRhythmKeys;
        private PictureBox pic2xBass;
        private PictureBox picRhythmBass;
        private PictureBox picRhythmKeys;
        private Label label2;
        private Label label1;
        private TextBox txtDescription;
        private TextBox txtTitleDisplay;
        private Button btnDispDLC;
        private Button btnDescDefault;
        private Button btnDispDefault;
        private PictureBox picThumb;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem useDefaultRB3ImageToolStripMenuItem;
        private ToolStripMenuItem importCONLIVEFileToolStripMenuItem;
        private ToolStripMenuItem importSongsdtaFileToolStripMenuItem;
        private ToolStripMenuItem importpngxboxFileToolStripMenuItem;
        private ToolStripMenuItem selectNautilusPath;
        private ToolStripMenuItem selectAudacityPath;
        private PictureBox picHelpMuteVol;
        private Label LabelMuteVolume;
        private NumericUpDown numericMuteVol;
        private Label LabelMuteVolumeVocals;
        private NumericUpDown numericVocalMute;
        private GroupBox groupBox2;
        private CheckBox chkAutoKeys;
        private NumericUpDown numericCrowd;
        private Label LabelCrowdPan;
        private PictureBox picHelpCrowd;
        private CheckBox chkKeysAnim;
        private Button ButtonBrowseForMIDI;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem Mono44SilenceToolStripMenuItem;
        private ToolStripMenuItem Stereo44SilenceToolStripMenuItem;
        private ToolStripMenuItem Mono48SilenceToolStripMenuItem;
        private ToolStripMenuItem Stereo48SilenceToolStripMenuItem;
        private ToolStripMenuItem useSilenceTracksByDefault;
        private ToolStripMenuItem use441KHzToolStripMenuItem;
        private ToolStripMenuItem use48KHzToolStripMenuItem;
        private PictureBox picAuthor;
        private ToolStripMenuItem overrideProjectFileAuthor;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem neverCheckForTempoMap;
        private ToolStripSeparator toolStripMenuItem6;
        private CheckBox chkTempo;
        private ToolStripMenuItem clearThumbnailTool;
        private Button ZeroCrowd;
        private ToolStripMenuItem overrideAlbumArt;
        private ToolStripMenuItem overrideMiloFile;
        private ToolStripMenuItem overrideMIDIFile;
        private ToolStripMenuItem overrideAudioFile;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem7;
        private CheckBox chkDrumsMix;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripMenuItem wiiConversion;
        private ToolStripMenuItem skinsToolStripMenuItem;
        private ToolStripMenuItem oldDarkTool;
        private Button ButtonBuildTo;
        private PictureBox picChecklist;
        private ToolStripMenuItem cIsForColorfulTool;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem loadTemplateToolStripMenuItem;
        private ToolStripMenuItem saveCurrentListAsTemplateToolStripMenuItem;
        private ToolStripMenuItem openToDoListByDefault;
        private Button btnTester;
        private Panel panelTODO;
        private PictureBox todoPic;
        private TextBox list15;
        private TextBox todo15;
        private TextBox list14;
        private TextBox todo14;
        private TextBox list13;
        private TextBox todo13;
        private TextBox list12;
        private TextBox todo12;
        private TextBox list11;
        private TextBox todo11;
        private TextBox list10;
        private TextBox todo10;
        private TextBox list9;
        private TextBox todo9;
        private TextBox list8;
        private TextBox todo8;
        private TextBox list7;
        private TextBox todo7;
        private TextBox list6;
        private TextBox todo6;
        private TextBox list5;
        private TextBox todo5;
        private TextBox list4;
        private TextBox todo4;
        private TextBox list3;
        private TextBox todo3;
        private TextBox list2;
        private TextBox todo2;
        private TextBox list1;
        private TextBox todo1;
        private PictureBox picDone;
        private PictureBox picRemove;
        private PictureBox picImportant;
        private PictureBox picTemplate;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel12;
        private ToolStripSeparator toolStripMenuItem12;
        private ToolStripMenuItem bypassNemosMIDIValidator;
        private ToolStripMenuItem blankDryvoxFileToolStripMenuItem;
        private Button btnCleaner;
        private Label label3;
        private NumericUpDown numericMilliseconds;
        private ToolStripMenuItem albumArtDimensions;
        private ToolStripMenuItem x256;
        private ToolStripMenuItem x512;
        private ToolStripMenuItem x1024;
        private ToolStripMenuItem x2048;
        private CheckBox chkCAT;
        private PictureBox picCAT;
        private ToolStripMenuItem selectThumbnail;
        private ToolStripMenuItem selectAudioFile;
        private PictureBox picHelpSolos;
        private CheckBox chkSoloVocals;
        private CheckBox chkSoloKeys;
        private CheckBox chkSoloBass;
        private CheckBox chkSoloGuitar;
        private CheckBox chkSoloDrums;
        private Label LabelSolos;
        private ToolStripMenuItem analyzeMIDIFileForContents;
        private ContextMenuStrip contextMenuStrip4;
        private ToolStripMenuItem useDefaultArt;
        private ToolStripMenuItem visitAlbumArtRepository;
        private ToolStripMenuItem increaseSongVersionAutomatically;
        private NumericUpDown numVersion;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem signSongAsLIVE;
        private ToolStripSeparator toolStripMenuItem9;
        private ToolStripMenuItem use441KHz24bitToolStripMenuItem;
        private ToolStripMenuItem use48KHz24bitToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem10;
        private ToolStripMenuItem Mono44Silence24;
        private ToolStripMenuItem Stereo44Silence24;
        private ToolStripMenuItem Stereo48Silence24;
        private ToolStripMenuItem Mono48Silence24;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem customSkinTool;
        private ToolStripMenuItem useUniqueNumericSongID;
        private ToolStripMenuItem batchReplaceSongIDs;
        private ToolStripMenuItem batchRestoreSongIDs;
        private Button btnID;
        private Timer PlaybackTimer;
        private Button btnPlay;
        private PictureBox picSpectrum;
        private ToolStripMenuItem importSonginiFileToolStripMenuItem;
        private ToolStripMenuItem copyLeadDryVocalsHere;
        private ToolStripMenuItem convertVocalsStemToDryvox;
        private PictureBox picWii;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem checkForUpdates;
        private BackgroundWorker updater;
        private ToolStripMenuItem viewChangeLog;
        private ToolStripMenuItem burnBabyBurn;
        private ComboBox cboTonality;
        private CheckBox chkTonality;
        private CheckBox chkDIYStems;
        private PictureBox picDIYStems;
        private NumericUpDown prevEndMilliseconds;
        private DomainUpDown prevEndSeconds;
        private NumericUpDown prevEndMinutes;
        private Label LabelEndPreview;
        private Label label5;
        private Label label6;
        private CheckBox chkAuthorDTA;
        private ToolStripMenuItem removeSubgenre;
        private ComboBox cboBandFail;
        private Label LabelBandFail;
        private CheckBox chkUnpitched;
        private PictureBox picUnpitched;
        private CheckBox chkPartial;
        private PictureBox picPartial;
        private HScrollBar scrollDrums;
        private Label lblDrumsDiff;
        private Label lblBassDiff;
        private HScrollBar scrollBass;
        private HScrollBar scrollProBass;
        private Label lblProBassDiff;
        private Label lblGuitarDiff;
        private HScrollBar scrollGuitar;
        private Label lblProGuitarDiff;
        private HScrollBar scrollProGuitar;
        private Label lblVocalsDiff;
        private HScrollBar scrollVocals;
        private HScrollBar scrollKeys;
        private Label lblKeysDiff;
        private Label lblProKeysDiff;
        private HScrollBar scrollProKeys;
        private HScrollBar scrollBand;
        private Label lblBandDiff;
    }
}