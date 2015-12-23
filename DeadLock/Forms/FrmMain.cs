#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeadLock.Classes;
using Syncfusion.Windows.Forms;
using FixedPanel = Syncfusion.Windows.Forms.Tools.Enums.FixedPanel;

namespace DeadLock.Forms
{
    public partial class FrmMain : MetroForm
    {
        private readonly LanguageManager _lm;
        private ListViewLockerManager _lvlManager;

        public FrmMain(IReadOnlyCollection<string> args)
        {
            InitializeComponent();
            try
            {
                _lm = new LanguageManager(Properties.Settings.Default.Language);
                _lvlManager = new ListViewLockerManager();

                LanguageSwitch();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (args.Count == 0) return;
            foreach (string s in args)
            {
                OpenPath(s);
            }
        }

        private void LanguageSwitch()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update(bool showError, bool showNoUpdates)
        {
            try
            {
                WebClient wc = new WebClient();
                string download = wc.DownloadString("http://codedead.com/Software/DeadLock/version.txt");
                string[] version = download.Split('|');

                if (version[0] != Application.ProductVersion)
                {
                    if (MessageBoxAdv.Show(_lm.GetText("NewVersion_Msg_1") + " " + version[0] + " " + _lm.GetText("NewVersion_Msg_2"), "DeadLock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        new FrmUpdater(version[1]).ShowDialog();
                    }
                }
                else
                {
                    if (showNoUpdates)
                    {
                        MessageBoxAdv.Show(_lm.GetText("NoNewVersion_Msg"), "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void LoadTheme()
        {
            try
            {
                detailsBarItem.Checked = Properties.Settings.Default.ViewDetails;
                DetailsChange();

                BorderThickness = Properties.Settings.Default.BorderThickness;
                MetroColor = Properties.Settings.Default.MetroColor;
                BorderColor = Properties.Settings.Default.MetroColor;

                mfbmMain.MetroColor = Properties.Settings.Default.MetroColor;
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            versionStaticBarItem.Text += @" " + Application.ProductVersion;
            try
            {
                nfiTray.Visible = Properties.Settings.Default.ShowNotifyIcon;
                if (Properties.Settings.Default.RememberFormSize)
                {
                    Size = Properties.Settings.Default.FormSize;
                    CenterToScreen();
                }
                LoadTheme();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutBarItem_Click(object sender, EventArgs e)
        {
            new FrmAbout().ShowDialog();
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

        private void OpenPath(string path)
        {
            if (!File.Exists(path) && !Directory.Exists(path)) return;
            if (_lvlManager.FindListViewLocker(path) != null) return;

            int index = lsvItems.Items.Count;
            ListViewItem lvi = new ListViewItem { Text = path, UseItemStyleForSubItems = false, ImageIndex = index };

            try
            {
                lvi.SubItems.Add(_lm.GetText("Unknown_Lvi"));
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

            ListViewLocker lvl = new ListViewLocker(path);
            lvi.SubItems.Add(lvl.HasOwnership().ToString());
            lsvItems.Items.Add(lvi);

            _lvlManager.AddListViewLocker(lvl);

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

            CancelSelectedTask(lsvItems.SelectedItems[0]);

            _lvlManager.DeleteListViewLocker(lsvItems.SelectedItems[0].Text);

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
            new FrmLicense().Show();
        }

        private async void unlockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;

            ListViewItem selected = lsvItems.SelectedItems[0];
            ListViewLocker lvl = _lvlManager.FindListViewLocker(selected.Text);

            CancelSelectedTask(selected);
            await Task.Run(() =>
            {
                while (lvl.IsRunning()) { }
            });

            try
            {
                SetLoading(selected, 1);

                lvl.SetRunning(true);
                await LockManager.Unlock(selected.Text, lvl.GetCancellationToken());

                if (!lvl.HasCancelled())
                {
                    selected.SubItems[1].ForeColor = Color.Green;
                    selected.SubItems[1].Text = _lm.GetText("SuccessUnlock_Lvi");
                }
                else
                {
                    SetCancelled(selected);
                }
                lvl.SetRunning(false);
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message + Environment.NewLine + ex.StackTrace, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selected.SubItems[1].ForeColor = Color.Red;
                try
                {
                    selected.SubItems[1].Text = _lm.GetText("UnSuccessUnlock_Lvi");
                }
                catch (Exception exc)
                {
                    MessageBoxAdv.Show(exc.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            ListViewItem selected = lsvItems.SelectedItems[0];
            ListViewLocker lvl = _lvlManager.FindListViewLocker(selected.Text);

            CancelSelectedTask(selected);
            await Task.Run(() =>
            {
                while (lvl.IsRunning()) { }
            });

            try
            {
                SetLoading(selected, 1);

                lvl.SetRunning(true);
                await LockManager.Copy(selected.Text, lvl.GetCancellationToken());

                if (!lvl.HasCancelled())
                {
                    selected.SubItems[1].ForeColor = Color.Green;
                    selected.SubItems[1].Text = _lm.GetText("SuccessCopy_Lvi");
                }
                else
                {
                    SetCancelled(selected);
                }
                lvl.SetRunning(false);
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selected.SubItems[1].ForeColor = Color.Red;

                try
                {
                    selected.SubItems[1].Text = _lm.GetText("UnSuccessCopy_Lvi");
                }
                catch (Exception exc)
                {
                    MessageBoxAdv.Show(exc.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.ShowAdminWarning)
                {
                    WindowsIdentity identity = WindowsIdentity.GetCurrent();
                    if (identity != null)
                    {
                        WindowsPrincipal principal = new WindowsPrincipal(identity);
                        if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                        {
                            MessageBoxAdv.Show("Some functions might not work correctly without administrative rights !", "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }

                if (Properties.Settings.Default.AutoUpdate) Update(false, false);
                Visible = !Properties.Settings.Default.StartMinimized;
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void helpBarItem_Click(object sender, EventArgs e)
        {
            new FrmHelp().Show();
        }

        private async void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;

            ListViewItem selected = lsvItems.SelectedItems[0];
            ListViewLocker lvl = _lvlManager.FindListViewLocker(selected.Text);

            CancelSelectedTask(selected);
            await Task.Run(() =>
            {
                while (lvl.IsRunning()) { }
            });

            try
            {
                SetLoading(selected, 1);

                lvl.SetRunning(true);
                await LockManager.Move(selected.Text, lvl.GetCancellationToken());

                if (!lvl.HasCancelled())
                {
                    selected.SubItems[1].ForeColor = Color.Green;
                    selected.SubItems[1].Text = _lm.GetText("SuccessMove_Lvi");
                }
                else
                {
                    SetCancelled(selected);
                }
                lvl.SetRunning(false);
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selected.SubItems[1].ForeColor = Color.Red;

                try
                {
                    selected.SubItems[1].Text = _lm.GetText("UnSuccessMove_Lvi");
                }
                catch (Exception exc)
                {
                    MessageBoxAdv.Show(exc.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;

            ListViewItem selected = lsvItems.SelectedItems[0];
            ListViewLocker lvl = _lvlManager.FindListViewLocker(selected.Text);

            CancelSelectedTask(selected);
            await Task.Run(() =>
            {
                while (lvl.IsRunning()) { }
            });

            try
            {
                SetLoading(selected, 1);

                lvl.SetRunning(true);
                LockManager.Remove(selected.Text, lvl.GetCancellationToken());

                if (!lvl.HasCancelled())
                {
                    selected.SubItems[1].ForeColor = Color.Green;
                    selected.SubItems[1].Text = _lm.GetText("SuccessRemove_Lvi");
                }
                else
                {
                    SetCancelled(selected);
                }
                lvl.SetRunning(false);
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selected.SubItems[1].ForeColor = Color.Red;

                try
                {
                    selected.SubItems[1].Text = _lm.GetText("UnSuccessRemove_Lvi");
                }
                catch (Exception exc)
                {
                    MessageBoxAdv.Show(exc.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CancelSelectedTask(ListViewItem lvi)
        {
            ListViewLocker lvl = _lvlManager.FindListViewLocker(lvi.Text);
            if (lvl == null) return false;
            if (!lvl.IsRunning()) return false;
            lvl.CancelTask();
            return true;
        }

        private async void lsvItems_DoubleClick(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;
            lsvDetails.Items.Clear();

            ListViewItem selected = lsvItems.SelectedItems[0];
            ListViewLocker lvl = _lvlManager.FindListViewLocker(selected.Text);

            try
            {
                if (!lvl.HasOwnership())
                {
                    lvl.SetOwnership(true);
                }

                CancelSelectedTask(selected);
                await Task.Run(() =>
                {
                    while (lvl.IsRunning())
                    {
                    }
                });
                _lvlManager.FindListViewLocker(selected.Text)?.SetLocker(new List<Process>());


                if (!File.Exists(selected.Text) && !Directory.Exists(selected.Text))
                {
                    imgFileIcons.Images.RemoveByKey(selected.Text);
                    lsvItems.Items.Remove(selected);
                    return;
                }

                SetLoading(selected, 1);
                SetLoading(selected, 2);

                lvl.SetRunning(true);
                List<Process> lockers = await LockManager.GetLockerDetails(selected.Text, lvl.GetCancellationToken());
                if (!lvl.HasCancelled())
                {
                    if (lockers.Count == 0)
                    {
                        try
                        {
                            selected.SubItems[1].Text = _lm.GetText("Unlocked_Lvi");
                        }
                        catch (Exception ex)
                        {
                            MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        selected.SubItems[1].ForeColor = Color.Green;
                    }
                    else
                    {
                        try
                        {
                            selected.SubItems[1].Text = _lm.GetText("Locked_Lvi");
                        }
                        catch (Exception ex)
                        {
                            MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        selected.SubItems[1].ForeColor = Color.Red;
                    }
                    selected.SubItems[2].Text = lvl.HasOwnership().ToString();

                    foreach (Process p in lockers)
                    {
                        string path = LockManager.GetMainModuleFilepath(p.Id);
                        ListViewItem lvi = new ListViewItem();
                        if (string.IsNullOrEmpty(path))
                        {
                            path = "Access denied";
                            lvi.Text = path;
                        }
                        else
                        {
                            lvi.Text = Path.GetFileName(path);
                        }
                        lvi.SubItems.Add(path);
                        lvi.SubItems.Add(p.Id.ToString());

                        lsvDetails.Items.Add(lvi);
                    }

                    _lvlManager.FindListViewLocker(selected.Text)?.SetLocker(lockers);

                    lsvDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lsvDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
                else
                {
                    lvl.SetLocker(new List<Process>());
                    SetCancelled(selected);
                }
                lvl.SetRunning(false);
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvl.SetLocker(new List<Process>());
                SetCancelled(selected);
                lvl.SetRunning(false);
            }
        }

        private void lsvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsvDetails.Items.Clear();
            if (lsvItems.SelectedItems.Count == 0) return;

            //Needs work
            ListViewLocker lvl = _lvlManager.FindListViewLocker(lsvItems.SelectedItems[0].Text);
            foreach (Process p in lvl.GetLockers())
            {

                ListViewItem lvi = new ListViewItem { Text = LockManager.GetMainModuleFilepath(p.Id) };
                lvi.SubItems.Add(LockManager.GetMainModuleFilepath(p.Id));
                lvi.SubItems.Add(p.Id.ToString());

                lsvDetails.Items.Add(lvi);
            }
        }

        private void clearItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lvlManager = new ListViewLockerManager();
            lsvItems.Items.Clear();
            lsvDetails.Items.Clear();
            imgFileIcons.Images.Clear();


            _lvlManager.CancelAllTasks();
            _lvlManager = new ListViewLockerManager();
        }

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

        private static void SetCancelled(ListViewItem selected)
        {
            if (selected == null) return;
            selected.SubItems[1].ForeColor = Color.Red;
            selected.SubItems[1].Text = "Operation cancelled";
            selected.SubItems[2].Text = "Operation cancelled";
        }

        private static void SetLoading(ListViewItem selected, int index)
        {
            if (selected == null) return;
            selected.SubItems[index].ForeColor = Color.Black;
            selected.SubItems[index].Text = "Loading...";
        }

        private void cancelCurrentOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;

            ListViewItem selected = lsvItems.SelectedItems[0];

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
                Process.Start("https://www.virustotal.com/en/file/" + FileUtil.GetSHA256FromFile(lsvItems.SelectedItems[0].Text) + "/analysis/");
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openInVirusTotalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lsvDetails.SelectedItems.Count == 0) return;
            try
            {
                Process.Start("https://www.virustotal.com/en/file/" + FileUtil.GetSHA256FromFile(lsvDetails.SelectedItems[0].SubItems[1].Text) + "/analysis/");
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
            new FrmSettings(nfiTray).ShowDialog();
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvDetails.SelectedItems.Count == 0) return;
            try
            {
                foreach (ListViewItem l in lsvDetails.SelectedItems)
                {
                    Process.GetProcessById(Convert.ToInt32(l.SubItems[2].Text)).Kill();
                }
                MessageBoxAdv.Show(_lm.GetText("SuccessProcessKill_Msg"), "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Process.Start("explorer.exe", @"/select, " + l.SubItems[1].Text);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkForUpdatesBarItem_Click(object sender, EventArgs e)
        {
            Update(true, false);
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

            ListViewLocker lvl = _lvlManager.FindListViewLocker(lsvItems.SelectedItems[0].Text);
            lvl.SetOwnership(true);
            lsvItems.SelectedItems[0].SubItems[2].Text = lvl.HasOwnership().ToString();
        }

        private void falseOwnershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvItems.SelectedItems.Count == 0) return;

            ListViewLocker lvl = _lvlManager.FindListViewLocker(lsvItems.SelectedItems[0].Text);
            lvl.SetOwnership(false);
            lsvItems.SelectedItems[0].SubItems[2].Text = lvl.HasOwnership().ToString();
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
    }
}
