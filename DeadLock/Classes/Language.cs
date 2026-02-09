namespace DeadLock.Classes
{
    /// <summary>
    /// Collection of strings that represent the translation of DeadLock into a certain language.
    /// </summary>
    public class Language
    {
        #region Author

        public string Author { get; set; }
        public string Comment { get; set; }

        #endregion

        #region Shared

        public string BtnClose { get; set; }
        public string BarItemSettings { get; set; }
        public string BarItemAbout { get; set; }
        public string BtnLicense { get; set; }

        #endregion

        #region Main_Form

        //Main form - Menu items:
        public string BarFile { get; set; }
        public string BarEdit { get; set; }
        public string BarView { get; set; }
        public string BarTools { get; set; }
        public string BarHelp { get; set; }

        //Main Form - File menu - Items:
        public string BarItemOpenFiles { get; set; }
        public string BarItemOpenFolder { get; set; }
        public string BarItemRestart { get; set; }
        public string BarItemExit { get; set; }

        //Main Form - Edit menu - Items:
        public string BarItemUnlock { get; set; }
        public string BarItemCopy { get; set; }
        public string BarItemMove { get; set; }
        public string BarItemRemove { get; set; }

        public string BarItemOwnership { get; set; }
        public string BarItemOwnershipTrue { get; set; }
        public string BarItemOwnershipFalse { get; set; }

        public string BarItemRemoveItem { get; set; }
        public string BarItemClearItems { get; set; }
        public string BarItemAutoSizeColumns { get; set; }
        public string BarItemCancelTask { get; set; }

        //Main Form - View menu - Items:
        public string BarItemDetails { get; set; }

        //Main Form - Help menu - Items:
        public string BarItemHelp { get; set; }
        public string BarItemCheckForUpdates { get; set; }
        public string BarItemHomePage { get; set; }

        //Main Form - ListView Items:
        public string ClhPath { get; set; }
        public string ClhStatus { get; set; }
        public string ClhOwnership { get; set; }

        public string MsgUnknown { get; set; }
        public string MsgLocked { get; set; }
        public string MsgUnlocked { get; set; }
        public string MsgOperationCancelled { get; set; }
        public string MsgLoading { get; set; }

        public string MsgSuccessfullyUnlocked { get; set; }
        public string MsgCouldNotUnlock { get; set; }

        public string MsgSuccessfullyCopied { get; set; }
        public string MsgCouldNotCopy { get; set; }

        public string MsgSuccessfullyMoved { get; set; }
        public string MsgCouldNotMove { get; set; }

        public string MsgSuccessfullyRemoved { get; set; }
        public string MsgCouldNotRemove { get; set; }

        //Main Form - ListView Details:
        public string ClhFileName { get; set; }
        public string ClhProcessId { get; set; }

        //Main Form - Status bar:
        public string LblVersion { get; set; }

        //Main Form - ContextMenu Items:
        public string CmiDetails { get; set; }
        public string CmiOpenInVirusTotal { get; set; }

        //Main Form - ContextMenu Details:
        public string CmiKill { get; set; }
        public string CmiOpenFileLocation { get; set; }
        public string CmiProperties { get; set; }

        public string MsgSuccessfullyKilled { get; set; }

        //Main Form - NotifyIcon:
        public string CmiHideShow { get; set; }

        //Main Form - Messages:
        public string MsgAdministrator { get; set; }
        public string MsgDownloadNewVersion { get; set; }
        public string MsgLatestVersionAlreadyInstalled { get; set; }

        #endregion

        #region About_Form

        //About Form - About:
        public string TxtAboutCreated { get; set; }
        public string TxtAboutImages { get; set; }
        public string TxtAboutTheme { get; set; }
        public string TxtAboutCopyright { get; set; }
        public string TxtAboutTranslation { get; set; }

        #endregion

        #region Settings_Form

        //Settings Form - General Tab:
        public string LblGeneral { get; set; }
        public string ChbAutoUpdate { get; set; }
        public string ChbShowNotifyIcon { get; set; }
        public string ChbStartMinimized { get; set; }
        public string ChbShowAdminWarning { get; set; }

        //Settings Form - Appearance Tab:
        public string LblAppearance { get; set; }
        public string LblThemeStyle { get; set; }
        public string LblRememberFormSize { get; set; }
        public string LblShowDetails { get; set; }
        public string LblLanguage { get; set; }

        //Settings Form - Advanced Tab:
        public string LblAdvanced { get; set; }
        public string LblAutoRunDeadLock { get; set; }
        public string LblWindowsExplorerIntegration { get; set; }
        public string LblOwnership { get; set; }

        //Settings Form - Buttons:
        public string BtnReset { get; set; }
        public string BtnSave { get; set; }

        //Settings Form - ToggleButtons
        public string TbtnOn { get; set; }
        public string TbtnOff { get; set; }

        #endregion

        #region NativeMethods

        public string MsgCouldNotRestart { get; set; }
        public string MsgCouldNotRegister { get; set; }
        public string MsgCouldNotList { get; set; }
        public string MsgCouldNotListResult { get; set; }

        #endregion

        #region ProcessLocker

        public string MsgAccessDenied { get; set; }

        #endregion
    }
}