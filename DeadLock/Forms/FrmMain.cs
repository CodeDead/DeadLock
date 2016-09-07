using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DeadLock.Classes;
using Syncfusion.Windows.Forms;
using FixedPanel = Syncfusion.Windows.Forms.Tools.Enums.FixedPanel;

namespace DeadLock.Forms
{
    public partial class FrmMain : MetroForm
    {
        #region Variables
        internal readonly LanguageManager LanguageManager;
        private Update _update;
        private readonly string[] _args;
        #endregion

        /// <summary>
        /// Generate a new FrmMain form.
        /// </summary>
        /// <param name="args">A collection of arguments.</param>
        public FrmMain(string[] args)
        {
            InitializeComponent();
            LoadTheme();
            LanguageManager = new LanguageManager();
            _update = new Update();
            try
            {
                LanguageSwitch();

                nfiTray.Visible = Properties.Settings.Default.ShowNotifyIcon;
                if (Properties.Settings.Default.RememberFormSize)
                {
                    Size = Properties.Settings.Default.FormSize;
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _args = args;
        }

        /// <summary>
        /// Change the GUI to match the current Language.
        /// </summary>
        internal void LanguageSwitch()
        {
            if (Properties.Settings.Default.Language == 12)
            {
                if (Properties.Settings.Default.LanguagePath.Length != 0)
                {
                    LanguageManager.LoadLanguage(Properties.Settings.Default.LanguagePath);
                }
                else
                {
                    LanguageManager.LoadLanguage(1);
                }
            }
            else
            {
                try
                {
                    LanguageManager.LoadLanguage(Properties.Settings.Default.Language);
                }
                catch (Exception)
                {
                    LanguageManager.LoadLanguage(1);
                }
            }

            Language l = LanguageManager.GetLanguage();
            //Main form - Menu items:
            fileParentBarItem.Text = l.BarFile;
            editParentBarItem.Text = l.BarEdit;
            viewParentBarItem.Text = l.BarView;
            toolsParentBarItem.Text = l.BarTools;
            helpParentBarItem.Text = l.BarHelp;

            //Main Form - File menu - Items:
            openFilesBarItem.Text = l.BarItemOpenFiles;
            openFolderbarItem.Text = l.BarItemOpenFolder;
            restartBarItem.Text = l.BarItemRestart;
            exitBarItem.Text = l.BarItemExit;

            //Main Form - Edit menu - Items:
            unlockParentBarItem.Text = l.BarItemUnlock;
            unlockBarItem.Text = l.BarItemUnlock;
            copyBarItem.Text = l.BarItemCopy;
            moveBarItem.Text = l.BarItemMove;
            removeBarItem.Text = l.BarItemRemove;

            ownershipParentBarItem.Text = l.BarItemOwnership;
            trueBarItem.Text = l.BarItemOwnershipTrue;
            falseBarItem.Text = l.BarItemOwnershipFalse;

            propertiesBarItem.Text = l.CmiProperties;

            removeItemBarItem.Text = l.BarItemRemoveItem;
            clearItemsbarItem.Text = l.BarItemClearItems;
            autoSizeColumnsBarItem.Text = l.BarItemAutoSizeColumns;
            cancelOperationBarItem.Text = l.BarItemCancelTask;

            //Main Form - View menu - Items:
            detailsBarItem.Text = l.BarItemDetails;

            //Main Form - Tools menu - Items:
            settingsBarItem.Text = l.BarItemSettings;

            //Main Form - Help menu - Items:
            helpBarItem.Text = l.BarItemHelp;
            checkForUpdatesBarItem.Text = l.BarItemCheckForUpdates;
            homePageBarItem.Text = l.BarItemHomePage;
            licenseBarItem.Text = l.BtnLicense;
            aboutBarItem.Text = l.BarItemAbout;

            //Main Form - ListView Items:
            clhPath.Text = l.ClhPath;
            clhStatus.Text = l.ClhStatus;
            clhOwnership.Text = l.ClhOwnership;

            //Main Form - ListView Details:
            clhFileName.Text = l.ClhFileName;
            clhProcessPath.Text = l.ClhPath;
            clhProcessID.Text = l.ClhProcessId;

            //Main Form - Status bar:
            versionStaticBarItem.Text = l.LblVersion;

            //Main Form - ContextMenu Items:
            detailsToolStripMenuItem.Text = l.CmiDetails;
            openInVirusTotalToolStripMenuItem.Text = l.CmiOpenInVirusTotal;
            openInVirusTotalToolStripMenuItem1.Text = l.CmiOpenInVirusTotal;
            unlockToolStripMenuItem.Text = l.BarItemUnlock;
            unlockToolStripMenuItem1.Text = l.BarItemUnlock;
            copyToolStripMenuItem.Text = l.BarItemCopy;
            moveToolStripMenuItem.Text = l.BarItemMove;
            removeToolStripMenuItem.Text = l.BarItemRemove;

            ownershipToolStripMenuItem.Text = l.BarItemOwnership;
            trueOwnershipToolStripMenuItem.Text = l.BarItemOwnershipTrue;
            falseOwnershipToolStripMenuItem.Text = l.BarItemOwnershipFalse;
            propertiesToolStripMenuItemItems.Text = l.CmiProperties;
            removeItemToolStripMenuItem.Text = l.BarItemRemoveItem;
            clearItemsToolStripMenuItem.Text = l.BarItemClearItems;
            cancelCurrentOperationToolStripMenuItem.Text = l.BarItemCancelTask;

            //Main Form - ContextMenu Details:
            killToolStripMenuItem.Text = l.CmiKill;
            openFileLocationToolStripMenuItem.Text = l.CmiOpenFileLocation;
            propertiesToolStripMenuItemDetails.Text = l.CmiProperties;

            //Main Form - NotifyIcon:
            hideShowToolStripMenuItem.Text = l.CmiHideShow;
            settingsToolStripMenuItem.Text = l.BarItemSettings;
            helpToolStripMenuItem.Text = l.BarItemHelp;
            aboutToolStripMenuItem.Text = l.BarItemAbout;
            exitToolStripMenuItem.Text = l.BarItemExit;
        }

        /// <summary>
        /// Check if there are updates available for the program.
        /// </summary>
        /// <param name="showError">Show errors.</param>
        /// <param name="showNoUpdates">Show a MessageBox when there are no updates available.</param>
        private async void Update(bool showError, bool showNoUpdates)
        {
            Language l = LanguageManager.GetLanguage();

            try
            {
                WebClient wc = new WebClient();
                string xml = await wc.DownloadStringTaskAsync("http://codedead.com/Software/DeadLock/update.xml");

                XmlSerializer serializer = new XmlSerializer(_update.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(xml);
                    writer.Flush();
                    stream.Position = 0;
                    _update = (Update)serializer.Deserialize(stream);
                    writer.Dispose();
                }
                if (_update.CheckForUpdate())
                {
                    if (MessageBoxAdv.Show(l.MsgVersion + " " + _update.GetUpdateVersion() + " " + l.MsgAvailable + Environment.NewLine + l.MsgDownloadNewVersion, "DeadLock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        new FrmUpdater(_update, LanguageManager.GetLanguage()).Show();
                    }
                }
                else
                {
                    if (showNoUpdates)
                    {
                        MessageBoxAdv.Show(l.MsgLatestVersionAlreadyInstalled, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                if (showError)
                {
                    MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Change the GUI to match the current theme.
        /// </summary>
        private void LoadTheme()
        {
            try
            {
                detailsBarItem.Checked = Properties.Settings.Default.ViewDetails;
                DetailsChange();

                BorderThickness = Properties.Settings.Default.BorderThickness;
                MetroColor = Properties.Settings.Default.MetroColor;
                BorderColor = Properties.Settings.Default.MetroColor;
                CaptionBarColor = Properties.Settings.Default.MetroColor;

                cmsItems.MetroColor = Properties.Settings.Default.MetroColor;
                cmsDetails.MetroColor = Properties.Settings.Default.MetroColor;
                cmsTray.MetroColor = Properties.Settings.Default.MetroColor;

                mfbmMain.MetroColor = Properties.Settings.Default.MetroColor;
                mfbmMain.ResetCustomization = false;
                mfbmMain.Style = VisualStyle.Metro;

                fileParentBarItem.MetroColor = Properties.Settings.Default.MetroColor;
                editParentBarItem.MetroColor = Properties.Settings.Default.MetroColor;
                unlockParentBarItem.MetroColor = Properties.Settings.Default.MetroColor;
                ownershipParentBarItem.MetroColor = Properties.Settings.Default.MetroColor;
                viewParentBarItem.MetroColor = Properties.Settings.Default.MetroColor;
                toolsParentBarItem.MetroColor = Properties.Settings.Default.MetroColor;
                helpParentBarItem.MetroColor = Properties.Settings.Default.MetroColor;

                mfbmMain.RefreshCommandBarsAfterDesignerLoad(false);
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            versionStaticBarItem.Text += @" " + Application.ProductVersion;
        }

        private void aboutBarItem_Click(object sender, EventArgs e)
        {
            new FrmAbout(LanguageManager.GetLanguage()).ShowDialog();
        }

        private void exitBarItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openFilesBarItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                ValidateNames = false,
                Multiselect = true
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            foreach (string s in ofd.FileNames)
            {
                OpenPath(s);
            }
        }

        /// <summary>
        /// Open a file or folder into DeadLock.
        /// </summary>
        /// <param name="path">The path to the file or folder.</param>
        private void OpenPath(string path)
        {
            if (!File.Exists(path) && !Directory.Exists(path)) return;

            bool add = true;
            foreach (ListViewItem lv in lsvItems.Items)
            {
                if (lv.Text == path) add = false;
            }
            if (!add) return;

            Language l = LanguageManager.GetLanguage();
            int index = lsvItems.Items.Count;
            ListViewLocker lvi = new ListViewLocker(path, l, index);

            lvi.SubItems.Add(l.MsgUnknown);

            Image img;
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
            {
                img = Properties.Resources.folder;
            }
            else
            {
                Icon ico = Icon.ExtractAssociatedIcon(path);
                img = ico?.ToBitmap() ?? Properties.Resources.file;
            }
            imgFileIcons.Images.Add(img);
            img.Dispose();

            lvi.SubItems.Add(lvi.HasOwnership() ? l.BarItemOwnershipTrue : l.BarItemOwnershipFalse);
            lsvItems.Items.Add(lvi);

            lsvItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void autoSizeColumnsBarItem_Click(object sender, EventArgs e)
        {
            lsvItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lsvDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void openFolderbarItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog { ShowNewFolderButton = false };
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                OpenPath(fbd.SelectedPath);
            }
        }

        private void removeItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;

            CancelSelectedTask((ListViewLocker)lsvItems.SelectedItems[0]);

            int iImageIndex = lsvItems.SelectedItems[0].ImageIndex;
            int iIndex = lsvItems.SelectedItems[0].Index;
            for (int i = iIndex + 1; i < lsvItems.Items.Count; i++)
            {
                lsvItems.Items[i].ImageIndex--;
            }
            lsvItems.SelectedItems[0].Remove();
            imgFileIcons.Images.RemoveAt(iImageIndex);

            lsvDetails.Items.Clear();
        }

        private void licenseBarItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\gpl.pdf");
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void unlockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;

            Language l = LanguageManager.GetLanguage();
            ListViewLocker lvl = (ListViewLocker)lsvItems.SelectedItems[0];

            CancelSelectedTask(lvl);
            await Task.Run(() =>
            {
                while (lvl.IsRunning()) { }
            });

            try
            {
                SetLoading(lvl, 1);

                lvl.SetRunning(true);
                await lvl.Unlock();

                if (!lvl.HasCancelled())
                {
                    lvl.SubItems[1].ForeColor = Color.Green;
                    lvl.SubItems[1].Text = l.MsgSuccessfullyUnlocked;
                }
                else
                {
                    SetCancelled(lvl);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message + Environment.NewLine + ex.StackTrace, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lvl.SubItems[1].ForeColor = Color.Red;
                lvl.SubItems[1].Text = l.MsgCouldNotUnlock;
            }
            finally
            {
                lvl.SetRunning(false);
            }

            lsvDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lsvDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void homePageBarItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://codedead.com/");
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;

            ListViewLocker lvl = (ListViewLocker)lsvItems.SelectedItems[0];
            Language l = LanguageManager.GetLanguage();

            CancelSelectedTask(lvl);
            await Task.Run(() =>
            {
                while (lvl.IsRunning()) { }
            });

            try
            {
                SetLoading(lvl, 1);

                lvl.SetRunning(true);
                await lvl.Copy();

                if (!lvl.HasCancelled())
                {
                    lvl.SubItems[1].ForeColor = Color.Green;
                    lvl.SubItems[1].Text = l.MsgSuccessfullyCopied;
                }
                else
                {
                    SetCancelled(lvl);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lvl.SubItems[1].ForeColor = Color.Red;
                lvl.SubItems[1].Text = l.MsgCouldNotCopy;
            }
            finally
            {
                lvl.SetRunning(false);
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            Language l = LanguageManager.GetLanguage();
            try
            {
                if (Properties.Settings.Default.ShowAdminWarning)
                {
                    WindowsIdentity identity = WindowsIdentity.GetCurrent();
                    WindowsPrincipal principal = new WindowsPrincipal(identity);
                    if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                    {
                        MessageBoxAdv.Show(l.MsgAdministrator, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                if (Properties.Settings.Default.AutoUpdate)
                {
                    Update(false, false);
                }
                Visible = !Properties.Settings.Default.StartMinimized;

                if (_args.Length == 0) return;
                foreach (string s in _args)
                {
                    OpenPath(s);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void helpBarItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\help.pdf");
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;

            ListViewLocker lvl = (ListViewLocker)lsvItems.SelectedItems[0];
            Language l = LanguageManager.GetLanguage();

            CancelSelectedTask(lvl);
            await Task.Run(() =>
            {
                while (lvl.IsRunning()) { }
            });

            try
            {
                SetLoading(lvl, 1);

                lvl.SetRunning(true);
                await lvl.Move();

                if (!lvl.HasCancelled())
                {
                    lvl.SubItems[1].ForeColor = Color.Green;
                    lvl.SubItems[1].Text = l.MsgSuccessfullyMoved;
                }
                else
                {
                    SetCancelled(lvl);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lvl.SubItems[1].ForeColor = Color.Red;
                lvl.SubItems[1].Text = l.MsgCouldNotMove;
            }
            finally
            {
                lvl.SetRunning(false);
            }
        }

        private async void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;

            ListViewLocker lvl = (ListViewLocker)lsvItems.SelectedItems[0];
            Language l = LanguageManager.GetLanguage();

            CancelSelectedTask(lvl);
            await Task.Run(() =>
            {
                while (lvl.IsRunning()) { }
            });

            try
            {
                SetLoading(lvl, 1);
                lvl.SetRunning(true);
                await lvl.RemoveItem();

                if (!lvl.HasCancelled())
                {
                    lvl.SubItems[1].ForeColor = Color.Green;
                    lvl.SubItems[1].Text = l.MsgSuccessfullyRemoved;
                }
                else
                {
                    SetCancelled(lvl);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lvl.SubItems[1].ForeColor = Color.Red;
                lvl.SubItems[1].Text = l.MsgCouldNotRemove;
            }
            finally
            {
                lvl.SetRunning(false);
            }
        }

        /// <summary>
        /// Cancel the ListViewLocker task, if applicable.
        /// </summary>
        /// <param name="lvi">The ListViewLocker that should be updated.</param>
        /// <returns>A boolean to represent whether the task was cancelled or not.</returns>
        private static bool CancelSelectedTask(ListViewLocker lvi)
        {
            if (lvi == null) return false;
            if (!lvi.IsRunning()) return false;
            lvi.CancelTask();
            return true;
        }

        private async void lsvItems_DoubleClick(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;
            lsvDetails.Items.Clear();

            ListViewLocker lvl = (ListViewLocker)lsvItems.SelectedItems[0];
            Language l = LanguageManager.GetLanguage();

            try
            {
                CancelSelectedTask(lvl);
                await Task.Run(() =>
                {
                    while (lvl.IsRunning()) { }
                });
                lvl.SetLocker(new List<ProcessLocker>());

                if (!File.Exists(lvl.Text) && !Directory.Exists(lvl.Text))
                {
                    imgFileIcons.Images.RemoveByKey(lvl.Text);
                    lsvItems.Items.Remove(lvl);
                    return;
                }

                SetLoading(lvl, 1);
                SetLoading(lvl, 2);

                lvl.SetRunning(true);
                List<ProcessLocker> lockers = await lvl.GetLockerDetails();

                if (!lvl.HasCancelled())
                {
                    if (lockers.Count == 0)
                    {
                        lvl.SubItems[1].Text = l.MsgUnlocked;
                        lvl.SubItems[1].ForeColor = Color.Green;
                    }
                    else
                    {
                        lvl.SubItems[1].Text = l.MsgLocked;
                        lvl.SubItems[1].ForeColor = Color.Red;
                    }
                    lvl.SubItems[2].Text = lvl.HasOwnership() ? l.BarItemOwnershipTrue : l.BarItemOwnershipFalse;

                    foreach (ProcessLocker p in lockers)
                    {
                        ListViewItem lvi = new ListViewItem { Text = p.GetFileName() };
                        lvi.SubItems.Add(p.GetFilePath());
                        lvi.SubItems.Add(p.GetProcessId().ToString());

                        lsvDetails.Items.Add(lvi);
                    }
                    lvl.SetLocker(lockers);

                    lsvDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lsvDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
                else
                {
                    lvl.SetLocker(new List<ProcessLocker>());
                    SetCancelled(lvl);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvl.SetRunning(false);
            }
        }

        private void lsvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsvDetails.Items.Clear();
            if (lsvItems.SelectedItems.Count == 0) return;

            ListViewLocker lvl = (ListViewLocker)lsvItems.SelectedItems[0];
            foreach (ProcessLocker p in lvl.GetLockers())
            {
                ListViewItem lvi = new ListViewItem { Text = p.GetFileName() };
                lvi.SubItems.Add(p.GetFilePath());
                lvi.SubItems.Add(p.GetProcessId().ToString());
                lsvDetails.Items.Add(lvi);
            }
        }

        private void clearItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lsvItems.Items)
            {
                ListViewLocker lvl = (ListViewLocker)lvi;
                lvl.CancelTask();
            }
            lsvItems.Items.Clear();
            lsvDetails.Items.Clear();
            imgFileIcons.Images.Clear();
        }

        /// <summary>
        /// Change the GUI when the Details setting has changed.
        /// </summary>
        private void DetailsChange()
        {
            if (detailsBarItem.Checked)
            {
                splItems.Panel2.Show();
                splItems.FixedPanel = FixedPanel.None;
            }
            else
            {
                splItems.Panel2.Hide();
                splItems.FixedPanel = FixedPanel.Panel1;
            }
            splItems.Panel2Collapsed = !detailsBarItem.Checked;
            splItems.IsSplitterFixed = !detailsBarItem.Checked;
        }

        private void detailsBarItem_Click(object sender, EventArgs e)
        {
            detailsBarItem.Checked = !detailsBarItem.Checked;
            DetailsChange();
        }

        /// <summary>
        /// Change the ListViewItem to notify the user that the task has cancelled.
        /// </summary>
        /// <param name="selected">The ListViewItem that should be updated.</param>
        private void SetCancelled(ListViewItem selected)
        {
            if (selected == null) return;
            Language l = LanguageManager.GetLanguage();
            selected.SubItems[1].ForeColor = Color.Red;
            selected.SubItems[1].Text = l.MsgOperationCancelled;
            selected.SubItems[2].Text = l.MsgOperationCancelled;
        }

        /// <summary>
        /// Change the ListViewItem to notify the user that the task is loading.
        /// </summary>
        /// <param name="selected">The ListViewItem that should be updated.</param>
        /// <param name="index">The index of the ListViewItem that should be updated.</param>
        private void SetLoading(ListViewItem selected, int index)
        {
            if (selected == null) return;
            Language l = LanguageManager.GetLanguage();
            selected.SubItems[index].ForeColor = Color.Black;
            selected.SubItems[index].Text = l.MsgLoading;
        }

        private void cancelCurrentOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;

            ListViewLocker selected = (ListViewLocker)lsvItems.SelectedItems[0];
            if (CancelSelectedTask(selected))
            {
                SetCancelled(selected);
            }
        }

        private void openInVirusTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;
            if (File.GetAttributes(lsvItems.SelectedItems[0].Text).HasFlag(FileAttributes.Directory)) return;
            try
            {
                Process.Start("https://www.virustotal.com/en/file/" + GetSha256FromFile(lsvItems.SelectedItems[0].Text) + "/analysis/");
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Get the SHA-256 value of a file.
        /// </summary>
        /// <param name="path">The path to a file.</param>
        /// <returns>The SHA-256 value of a file.</returns>
        private static string GetSha256FromFile(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                using (SHA256 sha = new SHA256Managed())
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (byte t in sha.ComputeHash(fs))
                    {
                        sb.Append(t.ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
        }

        private void openInVirusTotalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lsvDetails.SelectedItems.Count == 0) return;
            try
            {
                Process.Start("https://www.virustotal.com/en/file/" + GetSha256FromFile(lsvDetails.SelectedItems[0].SubItems[1].Text) + "/analysis/");
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hideShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
        }

        private void settingsBarItem_Click(object sender, EventArgs e)
        {
            new FrmSettings(this).ShowDialog();
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvDetails.SelectedItems.Count == 0) return;
            Language lang = LanguageManager.GetLanguage();
            try
            {
                foreach (ListViewItem l in lsvDetails.SelectedItems)
                {
                    Process.GetProcessById(Convert.ToInt32(l.SubItems[2].Text)).Kill();
                }
                MessageBoxAdv.Show(lang.MsgSuccessfullyKilled, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvDetails.SelectedItems.Count == 0) return;
            try
            {
                foreach (ListViewItem l in lsvDetails.SelectedItems)
                {
                    if (!File.Exists(l.SubItems[1].Text)) continue;
                    Process.Start("explorer.exe", "/select, " + l.SubItems[1].Text);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkForUpdatesBarItem_Click(object sender, EventArgs e)
        {
            Update(true, true);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Properties.Settings.Default.FormSize = Size;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restartBarItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void trueOwnershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;
            SetOwnership((ListViewLocker)lsvItems.SelectedItems[0], true);
        }

        private void falseOwnershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;
            SetOwnership((ListViewLocker)lsvItems.SelectedItems[0], false);
        }

        /// <summary>
        /// Change the ownership of the ListViewLocker.
        /// </summary>
        /// <param name="lvi">The ListViewLocker that should be updated.</param>
        /// <param name="ownership">A boolean to represent whether the user has ownership rights or not.</param>
        private void SetOwnership(ListViewLocker lvi, bool ownership)
        {
            lvi.SetOwnership(ownership);
            lvi.SubItems[2].Text = lvi.HasOwnership() ? LanguageManager.GetLanguage().BarItemOwnershipTrue : LanguageManager.GetLanguage().BarItemOwnershipFalse;
        }

        private void FrmMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string f in fileList)
            {
                OpenPath(f);
            }
        }

        private void lsvDetails_DoubleClick(object sender, EventArgs e)
        {
            if (lsvDetails.SelectedItems.Count == 0) return;
            foreach (ListViewItem lvi in lsvDetails.SelectedItems)
            {
                NativeMethods.ShowFileProperties(lvi.SubItems[1].Text);
            }
        }

        private void propertiesToolStripMenuItemItems_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;
            NativeMethods.ShowFileProperties(lsvItems.SelectedItems[0].Text);
        }
    }
}
