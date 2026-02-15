// ReSharper disable UnassignedField.Global

namespace DeadLock.Classes
{
    /// <summary>
    /// Collection of strings that represent the translation of DeadLock into a certain language.
    /// </summary>
    public class Language
    {
        #region Author

        public string Author;
        public string Comment;

        #endregion

        #region Shared

        public string BtnClose;
        public string BarItemSettings;
        public string BarItemAbout;
        public string BtnLicense;

        #endregion

        #region Main_Form

        //Main form - Menu items:
        public string BarFile;
        public string BarEdit;
        public string BarView;
        public string BarTools;
        public string BarHelp;

        //Main Form - File menu - Items:
        public string BarItemOpenFiles;
        public string BarItemOpenFolder;
        public string BarItemRestart;
        public string BarItemExit;

        //Main Form - Edit menu - Items:
        public string BarItemUnlock;
        public string BarItemCopy;
        public string BarItemMove;
        public string BarItemRemove;

        public string BarItemOwnership;
        public string BarItemOwnershipTrue;
        public string BarItemOwnershipFalse;

        public string BarItemRemoveItem;
        public string BarItemClearItems;
        public string BarItemAutoSizeColumns;
        public string BarItemCancelTask;

        //Main Form - View menu - Items:
        public string BarItemDetails;

        //Main Form - Help menu - Items:
        public string BarItemHelp;
        public string BarItemCheckForUpdates;
        public string BarItemHomePage;

        //Main Form - ListView Items:
        public string ClhPath;
        public string ClhStatus;
        public string ClhOwnership;

        public string MsgUnknown;
        public string MsgLocked;
        public string MsgUnlocked;
        public string MsgOperationCancelled;
        public string MsgLoading;

        public string MsgSuccessfullyUnlocked;
        public string MsgCouldNotUnlock;

        public string MsgSuccessfullyCopied;
        public string MsgCouldNotCopy;

        public string MsgSuccessfullyMoved;
        public string MsgCouldNotMove;

        public string MsgSuccessfullyRemoved;
        public string MsgCouldNotRemove;

        //Main Form - ListView Details:
        public string ClhFileName;
        public string ClhProcessId;

        //Main Form - Status bar:
        public string LblVersion;

        //Main Form - ContextMenu Items:
        public string CmiDetails;
        public string CmiOpenInVirusTotal;

        //Main Form - ContextMenu Details:
        public string CmiKill;
        public string CmiOpenFileLocation;
        public string CmiProperties;

        public string MsgSuccessfullyKilled;

        //Main Form - NotifyIcon:
        public string CmiHideShow;

        //Main Form - Messages:
        public string MsgAdministrator;
        public string MsgDownloadNewVersion;
        public string MsgLatestVersionAlreadyInstalled;

        #endregion

        #region About_Form

        //About Form - About:
        public string TxtAboutCreated;
        public string TxtAboutImages;
        public string TxtAboutTheme;
        public string TxtAboutCopyright;
        public string TxtAboutTranslation;
        public string BtnDonate;

        #endregion

        #region Settings_Form

        //Settings Form - General Tab:
        public string LblGeneral;
        public string ChbAutoUpdate;
        public string ChbShowNotifyIcon;
        public string ChbStartMinimized;
        public string ChbShowAdminWarning;

        //Settings Form - Appearance Tab:
        public string LblAppearance;
        public string LblThemeStyle;
        public string LblRememberFormSize;
        public string LblShowDetails;
        public string LblLanguage;

        //Settings Form - Advanced Tab:
        public string LblAdvanced;
        public string LblAutoRunDeadLock;
        public string LblWindowsExplorerIntegration;
        public string LblOwnership;

        //Settings Form - Buttons:
        public string BtnReset;
        public string BtnSave;

        //Settings Form - ToggleButtons
        public string TbtnOn;
        public string TbtnOff;

        #endregion

        #region NativeMethods

        public string MsgCouldNotRestart;
        public string MsgCouldNotRegister;
        public string MsgCouldNotList;
        public string MsgCouldNotListResult;

        #endregion

        #region ProcessLocker

        public string MsgAccessDenied;

        #endregion
    }
}