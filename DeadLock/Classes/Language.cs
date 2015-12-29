using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadLock.Classes
{
    public class Language
    {

        #region Main_Form
        //Main form - Menu items:
        public string _barFile;
        public string _barEdit;
        public string _barView;
        public string _barTools;
        public string _barHelp;

        //Main Form - File menu - Items:
        public string _barItemOpenFiles;
        public string _barItemOpenFolder;
        public string _barItemRestart;
        public string _barItemExit;

        //Main Form - Edit menu - Items:
        public string _barItemUnlock;
        public string _barItemCopy;
        public string _barItemMove;
        public string _barItemRemove;

        public string _barItemOwnership;
        public string _barItemOwnershipTrue;
        public string _barItemOwnershipFalse;

        public string _barItemRemoveItem;
        public string _barItemClearItems;
        public string _barItemAutoSizeColumns;
        public string _barItemCancelTask;

        //Main Form - View menu - Items:
        public string _barItemDetails;

        //Main Form - Tools menu - Items:
        public string _barItemSettings;

        //Main Form - Help menu - Items:
        public string _barItemHelp;
        public string _barItemCheckForUpdates;
        public string _barItemHomePage;
        public string _barItemLicense;
        public string _barItemAbout;

        //Main Form - ListView Items:
        public string _clhPath;
        public string _clhStatus;
        public string _clhOwnership;

        public string _msgUnknown;
        public string _msgLocked;
        public string _msgUnlocked;
        public string _msgOperationCancelled;
        public string _msgLoading;

        public string _msgSuccessfullyUnlocked;
        public string _msgCouldNotUnlock;

        public string _msgSuccessfullyCopied;
        public string _msgCouldNotCopy;

        public string _msgSuccessfullyMoved;
        public string _msgCouldNotMove;

        public string _msgSuccessfullyRemoved;
        public string _msgCouldNotRemove;

        //Main Form - ListView Details:
        public string _clhFileName;
        public string _clhProcessId;

        //Main Form - Status bar:
        public string _lblVersion;

        //Main Form - ContextMenu Items:
        public string _cmiDetails;
        public string _cmiOpenInVirusTotal;

        //Main Form - ContextMenu Details:
        public string _cmiKill;
        public string _cmiOpenFileLocation;

        public string _msgSuccessfullyKilled;

        //Main Form - NotifyIcon:
        public string _cmiHideShow;

        //Main Form - Messages:
        public string _msgAdministrator;

        public string _msgVersion;
        public string _msgAvailable;
        public string _msgDownloadNewVersion;
        public string _msgLatestVersionAlreadyInstalled;

        #endregion

        #region About_Form
        //About Form - Text:
        public string _txtAbout;

        //About Form - Buttons:
        public string _btnAboutClose;
        public string _btnLicense;
        #endregion

        #region Settings_Form
        //Settings Form - Text:
        public string _txtSettings;

        //Settings Form - General Tab:
        public string _chbAutoUpdate;
        public string _chbShowNotifyIcon;
        public string _chbStartMinimized;
        public string _chbShowAdminWarning;

        //Settings Form - Appearance Tab:
        public string _lblThemeStyle;
        public string _lblBorderThickness;
        public string _lblRememberFormSize;
        public string _lblShowDetails;
        public string _lblLanguage;

        //Settings Form - Advanced Tab:
        public string _lblAutoRunDeadLock;
        public string _lblWindowsExplorerIntegration;

        //Settings Form - Buttons:
        public string _btnSettingsClose;
        public string _btnReset;
        public string _btnSave;

        //Settins Form - Messages:
        public string _msgRestartRequired;
        #endregion

        #region Updater_Form
        //Updater Form - Text:
        public string _txtUpdater;

        //Updater Form - General:
        public string _lblPath;
        public string _lblProgress;

        //Updater Form - Buttons:
        public string _btnCancel;
        public string _btnUpdate;
        #endregion

        public Language()
        {
            
        }
    }
}
