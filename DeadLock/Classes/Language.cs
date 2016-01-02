namespace DeadLock.Classes
{
    public class Language
    {
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

        //Main Form - Tools menu - Items:
        public string BarItemSettings;

        //Main Form - Help menu - Items:
        public string BarItemHelp;
        public string BarItemCheckForUpdates;
        public string BarItemHomePage;
        public string BarItemLicense;
        public string BarItemAbout;

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

        public string MsgSuccessfullyKilled;

        //Main Form - NotifyIcon:
        public string CmiHideShow;

        //Main Form - Messages:
        public string MsgAdministrator;

        public string MsgVersion;
        public string MsgAvailable;
        public string MsgDownloadNewVersion;
        public string MsgLatestVersionAlreadyInstalled;

        #endregion

        #region About_Form
        //About Form - Text:
        public string TxtAbout;

        //About Form - Buttons:
        public string BtnAboutClose;
        public string BtnLicense;
        #endregion

        #region Settings_Form
        //Settings Form - Text:
        public string TxtSettings;

        //Settings Form - General Tab:
        public string LblGeneral;
        public string ChbAutoUpdate;
        public string ChbShowNotifyIcon;
        public string ChbStartMinimized;
        public string ChbShowAdminWarning;

        //Settings Form - Appearance Tab:
        public string LblAppearance;
        public string LblThemeStyle;
        public string LblBorderThickness;
        public string LblRememberFormSize;
        public string LblShowDetails;
        public string LblLanguage;

        //Settings Form - Advanced Tab:
        public string LblAdvanced;
        public string LblAutoRunDeadLock;
        public string LblWindowsExplorerIntegration;

        //Settings Form - Buttons:
        public string BtnSettingsClose;
        public string BtnReset;
        public string BtnSave;

        //Settins Form - Messages:
        public string MsgRestartRequired;
        #endregion

        #region Updater_Form
        //Updater Form - Text:
        public string TxtUpdater;

        //Updater Form - General:
        public string LblPath;
        public string LblProgress;

        //Updater Form - Buttons:
        public string BtnCancel;
        public string BtnUpdate;
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
