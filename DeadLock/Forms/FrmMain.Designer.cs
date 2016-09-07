#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace DeadLock.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.mfbmMain = new Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager(this);
            this.barMain = new Syncfusion.Windows.Forms.Tools.XPMenus.Bar(this.mfbmMain, "MainMenu");
            this.fileParentBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.openFilesBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.openFolderbarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.restartBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.exitBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.editParentBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.unlockParentBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.unlockBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.copyBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.moveBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.removeBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.ownershipParentBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.trueBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.falseBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.propertiesBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.removeItemBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.clearItemsbarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.autoSizeColumnsBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.cancelOperationBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.viewParentBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.detailsBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.toolsParentBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.settingsBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.helpParentBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.helpBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.checkForUpdatesBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.homePageBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.licenseBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.aboutBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.barStatus = new Syncfusion.Windows.Forms.Tools.XPMenus.Bar(this.mfbmMain, "StatusMenu");
            this.versionStaticBarItem = new Syncfusion.Windows.Forms.Tools.XPMenus.StaticBarItem();
            this.splItems = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.lsvItems = new System.Windows.Forms.ListView();
            this.clhPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhOwnership = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsItems = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this.unlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ownershipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trueOwnershipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.falseOwnershipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItemItems = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.removeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.openInVirusTotalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelCurrentOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgFileIcons = new System.Windows.Forms.ImageList(this.components);
            this.lsvDetails = new System.Windows.Forms.ListView();
            this.clhFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhProcessPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhProcessID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsDetails = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this.propertiesToolStripMenuItemDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.openInVirusTotalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nfiTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTray = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this.hideShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mfbmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splItems)).BeginInit();
            this.splItems.Panel1.SuspendLayout();
            this.splItems.Panel2.SuspendLayout();
            this.splItems.SuspendLayout();
            this.cmsItems.SuspendLayout();
            this.cmsDetails.SuspendLayout();
            this.cmsTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // mfbmMain
            // 
            this.mfbmMain.AllowUserRenaming = false;
            this.mfbmMain.BarPositionInfo = ((System.IO.MemoryStream)(resources.GetObject("mfbmMain.BarPositionInfo")));
            this.mfbmMain.Bars.Add(this.barMain);
            this.mfbmMain.Bars.Add(this.barStatus);
            this.mfbmMain.Categories.Add("File");
            this.mfbmMain.Categories.Add("Edit");
            this.mfbmMain.Categories.Add("View");
            this.mfbmMain.Categories.Add("Tools");
            this.mfbmMain.Categories.Add("Help");
            this.mfbmMain.Categories.Add("Status");
            this.mfbmMain.CurrentBaseFormType = "Syncfusion.Windows.Forms.MetroForm";
            this.mfbmMain.EnableCustomizing = false;
            this.mfbmMain.EnableMenuMerge = true;
            this.mfbmMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mfbmMain.Form = this;
            this.mfbmMain.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.editParentBarItem,
            this.unlockParentBarItem,
            this.ownershipParentBarItem,
            this.propertiesBarItem,
            this.trueBarItem,
            this.falseBarItem,
            this.clearItemsbarItem,
            this.autoSizeColumnsBarItem,
            this.cancelOperationBarItem,
            this.unlockBarItem,
            this.fileParentBarItem,
            this.copyBarItem,
            this.moveBarItem,
            this.openFilesBarItem,
            this.openFolderbarItem,
            this.restartBarItem,
            this.exitBarItem,
            this.toolsParentBarItem,
            this.settingsBarItem,
            this.helpParentBarItem,
            this.helpBarItem,
            this.checkForUpdatesBarItem,
            this.homePageBarItem,
            this.licenseBarItem,
            this.aboutBarItem,
            this.versionStaticBarItem,
            this.viewParentBarItem,
            this.detailsBarItem,
            this.removeItemBarItem,
            this.removeBarItem});
            this.mfbmMain.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.mfbmMain.ResetCustomization = false;
            this.mfbmMain.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.mfbmMain.UseBackwardCompatiblity = false;
            // 
            // barMain
            // 
            this.barMain.AllowCustomizing = false;
            this.barMain.BarName = "MainMenu";
            this.barMain.BarStyle = ((Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle)(((((Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.AllowQuickCustomizing | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.IsMainMenu) 
            | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.RotateWhenVertical) 
            | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.Visible) 
            | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.DrawDragBorder)));
            this.barMain.Caption = "MainMenu";
            this.barMain.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.fileParentBarItem,
            this.editParentBarItem,
            this.viewParentBarItem,
            this.toolsParentBarItem,
            this.helpParentBarItem});
            this.barMain.Manager = this.mfbmMain;
            // 
            // fileParentBarItem
            // 
            this.fileParentBarItem.BarName = "fileParentBarItem";
            this.fileParentBarItem.CategoryIndex = 0;
            this.fileParentBarItem.ID = "&File";
            this.fileParentBarItem.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.openFilesBarItem,
            this.openFolderbarItem,
            this.restartBarItem,
            this.exitBarItem});
            this.fileParentBarItem.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.fileParentBarItem.SeparatorIndices.AddRange(new int[] {
            2});
            this.fileParentBarItem.ShowToolTipInPopUp = false;
            this.fileParentBarItem.SizeToFit = true;
            this.fileParentBarItem.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.fileParentBarItem.Text = "&File";
            this.fileParentBarItem.WrapLength = 20;
            // 
            // openFilesBarItem
            // 
            this.openFilesBarItem.BarName = "openFilesBarItem";
            this.openFilesBarItem.CategoryIndex = 0;
            this.openFilesBarItem.ID = "Open file(s)...";
            this.openFilesBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("openFilesBarItem.Image")));
            this.openFilesBarItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.openFilesBarItem.ShowToolTipInPopUp = false;
            this.openFilesBarItem.SizeToFit = true;
            this.openFilesBarItem.Text = "Open file(s)...";
            this.openFilesBarItem.Click += new System.EventHandler(this.openFilesBarItem_Click);
            // 
            // openFolderbarItem
            // 
            this.openFolderbarItem.BarName = "openFolderbarItem";
            this.openFolderbarItem.CategoryIndex = 0;
            this.openFolderbarItem.ID = "Open folder...";
            this.openFolderbarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("openFolderbarItem.Image")));
            this.openFolderbarItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftO;
            this.openFolderbarItem.ShowToolTipInPopUp = false;
            this.openFolderbarItem.SizeToFit = true;
            this.openFolderbarItem.Text = "Open folder...";
            this.openFolderbarItem.Click += new System.EventHandler(this.openFolderbarItem_Click);
            // 
            // restartBarItem
            // 
            this.restartBarItem.BarName = "restartBarItem";
            this.restartBarItem.CategoryIndex = 0;
            this.restartBarItem.ID = "Restart";
            this.restartBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("restartBarItem.Image")));
            this.restartBarItem.ShowToolTipInPopUp = false;
            this.restartBarItem.SizeToFit = true;
            this.restartBarItem.Text = "Restart";
            this.restartBarItem.Click += new System.EventHandler(this.restartBarItem_Click);
            // 
            // exitBarItem
            // 
            this.exitBarItem.BarName = "exitBarItem";
            this.exitBarItem.CategoryIndex = 0;
            this.exitBarItem.ID = "Exit";
            this.exitBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("exitBarItem.Image")));
            this.exitBarItem.ShowToolTipInPopUp = false;
            this.exitBarItem.SizeToFit = true;
            this.exitBarItem.Text = "Exit";
            this.exitBarItem.Click += new System.EventHandler(this.exitBarItem_Click);
            // 
            // editParentBarItem
            // 
            this.editParentBarItem.BarName = "editParentBarItem";
            this.editParentBarItem.CategoryIndex = 1;
            this.editParentBarItem.ID = "&Edit";
            this.editParentBarItem.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.unlockParentBarItem,
            this.ownershipParentBarItem,
            this.propertiesBarItem,
            this.removeItemBarItem,
            this.clearItemsbarItem,
            this.autoSizeColumnsBarItem,
            this.cancelOperationBarItem});
            this.editParentBarItem.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.editParentBarItem.SeparatorIndices.AddRange(new int[] {
            2,
            3,
            5,
            6});
            this.editParentBarItem.ShowToolTipInPopUp = false;
            this.editParentBarItem.SizeToFit = true;
            this.editParentBarItem.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.editParentBarItem.Text = "&Edit";
            this.editParentBarItem.WrapLength = 20;
            // 
            // unlockParentBarItem
            // 
            this.unlockParentBarItem.BarName = "unlockParentBarItem";
            this.unlockParentBarItem.CategoryIndex = 1;
            this.unlockParentBarItem.ID = "Unlock";
            this.unlockParentBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("unlockParentBarItem.Image")));
            this.unlockParentBarItem.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.unlockBarItem,
            this.copyBarItem,
            this.moveBarItem,
            this.removeBarItem});
            this.unlockParentBarItem.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.unlockParentBarItem.SeparatorIndices.AddRange(new int[] {
            1,
            3});
            this.unlockParentBarItem.ShowToolTipInPopUp = false;
            this.unlockParentBarItem.SizeToFit = true;
            this.unlockParentBarItem.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.unlockParentBarItem.Text = "Unlock";
            this.unlockParentBarItem.WrapLength = 20;
            // 
            // unlockBarItem
            // 
            this.unlockBarItem.BarName = "unlockBarItem";
            this.unlockBarItem.CategoryIndex = 1;
            this.unlockBarItem.ID = "Unlock_1";
            this.unlockBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("unlockBarItem.Image")));
            this.unlockBarItem.ShowToolTipInPopUp = false;
            this.unlockBarItem.SizeToFit = true;
            this.unlockBarItem.Text = "Unlock";
            this.unlockBarItem.Click += new System.EventHandler(this.unlockToolStripMenuItem1_Click);
            // 
            // copyBarItem
            // 
            this.copyBarItem.BarName = "copyBarItem";
            this.copyBarItem.CategoryIndex = 1;
            this.copyBarItem.ID = "Copy";
            this.copyBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("copyBarItem.Image")));
            this.copyBarItem.ShowToolTipInPopUp = false;
            this.copyBarItem.SizeToFit = true;
            this.copyBarItem.Text = "Copy";
            this.copyBarItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // moveBarItem
            // 
            this.moveBarItem.BarName = "moveBarItem";
            this.moveBarItem.CategoryIndex = 1;
            this.moveBarItem.ID = "Move";
            this.moveBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("moveBarItem.Image")));
            this.moveBarItem.ShowToolTipInPopUp = false;
            this.moveBarItem.SizeToFit = true;
            this.moveBarItem.Text = "Move";
            this.moveBarItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // removeBarItem
            // 
            this.removeBarItem.BarName = "removeBarItem";
            this.removeBarItem.CategoryIndex = 1;
            this.removeBarItem.ID = "removeBarItem";
            this.removeBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("removeBarItem.Image")));
            this.removeBarItem.ShowToolTipInPopUp = false;
            this.removeBarItem.SizeToFit = true;
            this.removeBarItem.Text = "Remove";
            this.removeBarItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // ownershipParentBarItem
            // 
            this.ownershipParentBarItem.BarName = "ownershipParentBarItem";
            this.ownershipParentBarItem.CategoryIndex = 1;
            this.ownershipParentBarItem.ID = "Ownership";
            this.ownershipParentBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("ownershipParentBarItem.Image")));
            this.ownershipParentBarItem.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.trueBarItem,
            this.falseBarItem});
            this.ownershipParentBarItem.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.ownershipParentBarItem.ShowToolTipInPopUp = false;
            this.ownershipParentBarItem.SizeToFit = true;
            this.ownershipParentBarItem.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.ownershipParentBarItem.Text = "Ownership";
            this.ownershipParentBarItem.WrapLength = 20;
            // 
            // trueBarItem
            // 
            this.trueBarItem.BarName = "trueBarItem";
            this.trueBarItem.CategoryIndex = 1;
            this.trueBarItem.ID = "True";
            this.trueBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("trueBarItem.Image")));
            this.trueBarItem.ShowToolTipInPopUp = false;
            this.trueBarItem.SizeToFit = true;
            this.trueBarItem.Text = "True";
            this.trueBarItem.Click += new System.EventHandler(this.trueOwnershipToolStripMenuItem_Click);
            // 
            // falseBarItem
            // 
            this.falseBarItem.BarName = "falseBarItem";
            this.falseBarItem.CategoryIndex = 1;
            this.falseBarItem.ID = "False";
            this.falseBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("falseBarItem.Image")));
            this.falseBarItem.ShowToolTipInPopUp = false;
            this.falseBarItem.SizeToFit = true;
            this.falseBarItem.Text = "False";
            this.falseBarItem.Click += new System.EventHandler(this.falseOwnershipToolStripMenuItem_Click);
            // 
            // propertiesBarItem
            // 
            this.propertiesBarItem.BarName = "propertiesBarItem";
            this.propertiesBarItem.CategoryIndex = 1;
            this.propertiesBarItem.ID = "Properties";
            this.propertiesBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("propertiesBarItem.Image")));
            this.propertiesBarItem.ShowToolTipInPopUp = false;
            this.propertiesBarItem.SizeToFit = true;
            this.propertiesBarItem.Text = "Properties";
            this.propertiesBarItem.Click += new System.EventHandler(this.propertiesToolStripMenuItemItems_Click);
            // 
            // removeItemBarItem
            // 
            this.removeItemBarItem.BarName = "removeItemBarItem";
            this.removeItemBarItem.CategoryIndex = 1;
            this.removeItemBarItem.ID = "removeItemBarItem";
            this.removeItemBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("removeItemBarItem.Image")));
            this.removeItemBarItem.ShowToolTipInPopUp = false;
            this.removeItemBarItem.SizeToFit = true;
            this.removeItemBarItem.Text = "Remove item";
            this.removeItemBarItem.Click += new System.EventHandler(this.removeItemToolStripMenuItem_Click);
            // 
            // clearItemsbarItem
            // 
            this.clearItemsbarItem.BarName = "clearItemsbarItem";
            this.clearItemsbarItem.CategoryIndex = 1;
            this.clearItemsbarItem.ID = "Clear items";
            this.clearItemsbarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("clearItemsbarItem.Image")));
            this.clearItemsbarItem.ShowToolTipInPopUp = false;
            this.clearItemsbarItem.SizeToFit = true;
            this.clearItemsbarItem.Text = "Clear items";
            this.clearItemsbarItem.Click += new System.EventHandler(this.clearItemsToolStripMenuItem_Click);
            // 
            // autoSizeColumnsBarItem
            // 
            this.autoSizeColumnsBarItem.BarName = "autoSizeColumnsBarItem";
            this.autoSizeColumnsBarItem.CategoryIndex = 1;
            this.autoSizeColumnsBarItem.ID = "Auto size columns";
            this.autoSizeColumnsBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("autoSizeColumnsBarItem.Image")));
            this.autoSizeColumnsBarItem.ShowToolTipInPopUp = false;
            this.autoSizeColumnsBarItem.SizeToFit = true;
            this.autoSizeColumnsBarItem.Text = "Auto size columns";
            this.autoSizeColumnsBarItem.Click += new System.EventHandler(this.autoSizeColumnsBarItem_Click);
            // 
            // cancelOperationBarItem
            // 
            this.cancelOperationBarItem.BarName = "cancelOperationBarItem";
            this.cancelOperationBarItem.CategoryIndex = 1;
            this.cancelOperationBarItem.ID = "Cancel current operation";
            this.cancelOperationBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("cancelOperationBarItem.Image")));
            this.cancelOperationBarItem.ShowToolTipInPopUp = false;
            this.cancelOperationBarItem.SizeToFit = true;
            this.cancelOperationBarItem.Text = "Cancel task";
            this.cancelOperationBarItem.Click += new System.EventHandler(this.cancelCurrentOperationToolStripMenuItem_Click);
            // 
            // viewParentBarItem
            // 
            this.viewParentBarItem.BarName = "viewParentBarItem";
            this.viewParentBarItem.CategoryIndex = 2;
            this.viewParentBarItem.ID = "&View";
            this.viewParentBarItem.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.detailsBarItem});
            this.viewParentBarItem.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.viewParentBarItem.ShowToolTipInPopUp = false;
            this.viewParentBarItem.SizeToFit = true;
            this.viewParentBarItem.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.viewParentBarItem.Text = "&View";
            this.viewParentBarItem.WrapLength = 20;
            // 
            // detailsBarItem
            // 
            this.detailsBarItem.BarName = "detailsBarItem";
            this.detailsBarItem.CategoryIndex = 2;
            this.detailsBarItem.Checked = true;
            this.detailsBarItem.ID = "Details";
            this.detailsBarItem.ShowToolTipInPopUp = false;
            this.detailsBarItem.SizeToFit = true;
            this.detailsBarItem.Text = "Details";
            this.detailsBarItem.Click += new System.EventHandler(this.detailsBarItem_Click);
            // 
            // toolsParentBarItem
            // 
            this.toolsParentBarItem.BarName = "toolsParentBarItem";
            this.toolsParentBarItem.CategoryIndex = 3;
            this.toolsParentBarItem.ID = "&Tools";
            this.toolsParentBarItem.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.settingsBarItem});
            this.toolsParentBarItem.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.toolsParentBarItem.ShowToolTipInPopUp = false;
            this.toolsParentBarItem.SizeToFit = true;
            this.toolsParentBarItem.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.toolsParentBarItem.Text = "&Tools";
            this.toolsParentBarItem.WrapLength = 20;
            // 
            // settingsBarItem
            // 
            this.settingsBarItem.BarName = "settingsBarItem";
            this.settingsBarItem.CategoryIndex = 3;
            this.settingsBarItem.ID = "Settings";
            this.settingsBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("settingsBarItem.Image")));
            this.settingsBarItem.ShowToolTipInPopUp = false;
            this.settingsBarItem.SizeToFit = true;
            this.settingsBarItem.Text = "Settings";
            this.settingsBarItem.Click += new System.EventHandler(this.settingsBarItem_Click);
            // 
            // helpParentBarItem
            // 
            this.helpParentBarItem.BarName = "helpParentBarItem";
            this.helpParentBarItem.CategoryIndex = 4;
            this.helpParentBarItem.ID = "&Help";
            this.helpParentBarItem.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.helpBarItem,
            this.checkForUpdatesBarItem,
            this.homePageBarItem,
            this.licenseBarItem,
            this.aboutBarItem});
            this.helpParentBarItem.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.helpParentBarItem.SeparatorIndices.AddRange(new int[] {
            1,
            3,
            4});
            this.helpParentBarItem.ShowToolTipInPopUp = false;
            this.helpParentBarItem.SizeToFit = true;
            this.helpParentBarItem.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.helpParentBarItem.Text = "&Help";
            this.helpParentBarItem.WrapLength = 20;
            // 
            // helpBarItem
            // 
            this.helpBarItem.BarName = "helpBarItem";
            this.helpBarItem.CategoryIndex = 4;
            this.helpBarItem.ID = "Help";
            this.helpBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("helpBarItem.Image")));
            this.helpBarItem.ShowToolTipInPopUp = false;
            this.helpBarItem.SizeToFit = true;
            this.helpBarItem.Text = "Help";
            this.helpBarItem.Click += new System.EventHandler(this.helpBarItem_Click);
            // 
            // checkForUpdatesBarItem
            // 
            this.checkForUpdatesBarItem.BarName = "checkForUpdatesBarItem";
            this.checkForUpdatesBarItem.CategoryIndex = 4;
            this.checkForUpdatesBarItem.ID = "Check for updates";
            this.checkForUpdatesBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("checkForUpdatesBarItem.Image")));
            this.checkForUpdatesBarItem.ShowToolTipInPopUp = false;
            this.checkForUpdatesBarItem.SizeToFit = true;
            this.checkForUpdatesBarItem.Text = "Check for updates";
            this.checkForUpdatesBarItem.Click += new System.EventHandler(this.checkForUpdatesBarItem_Click);
            // 
            // homePageBarItem
            // 
            this.homePageBarItem.BarName = "homePageBarItem";
            this.homePageBarItem.CategoryIndex = 4;
            this.homePageBarItem.ID = "Homepage";
            this.homePageBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("homePageBarItem.Image")));
            this.homePageBarItem.ShowToolTipInPopUp = false;
            this.homePageBarItem.SizeToFit = true;
            this.homePageBarItem.Text = "Homepage";
            this.homePageBarItem.Click += new System.EventHandler(this.homePageBarItem_Click);
            // 
            // licenseBarItem
            // 
            this.licenseBarItem.BarName = "licenseBarItem";
            this.licenseBarItem.CategoryIndex = 4;
            this.licenseBarItem.ID = "License";
            this.licenseBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("licenseBarItem.Image")));
            this.licenseBarItem.ShowToolTipInPopUp = false;
            this.licenseBarItem.SizeToFit = true;
            this.licenseBarItem.Text = "License";
            this.licenseBarItem.Click += new System.EventHandler(this.licenseBarItem_Click);
            // 
            // aboutBarItem
            // 
            this.aboutBarItem.BarName = "aboutBarItem";
            this.aboutBarItem.CategoryIndex = 4;
            this.aboutBarItem.ID = "About";
            this.aboutBarItem.Image = ((Syncfusion.Windows.Forms.Tools.XPMenus.ImageExt)(resources.GetObject("aboutBarItem.Image")));
            this.aboutBarItem.ShowToolTipInPopUp = false;
            this.aboutBarItem.SizeToFit = true;
            this.aboutBarItem.Text = "About";
            this.aboutBarItem.Click += new System.EventHandler(this.aboutBarItem_Click);
            // 
            // barStatus
            // 
            this.barStatus.BarName = "StatusMenu";
            this.barStatus.BarStyle = ((Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle)(((((Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.AllowQuickCustomizing | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.RotateWhenVertical) 
            | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.Visible) 
            | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.DrawDragBorder) 
            | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.IsStatusBar)));
            this.barStatus.Caption = "StatusMenu";
            this.barStatus.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.versionStaticBarItem});
            this.barStatus.Manager = this.mfbmMain;
            // 
            // versionStaticBarItem
            // 
            this.versionStaticBarItem.BarName = "versionStaticBarItem";
            this.versionStaticBarItem.CategoryIndex = 5;
            this.versionStaticBarItem.ID = "Version:";
            this.versionStaticBarItem.ShowToolTipInPopUp = false;
            this.versionStaticBarItem.SizeToFit = true;
            this.versionStaticBarItem.Text = "Version:";
            // 
            // splItems
            // 
            this.splItems.BeforeTouchSize = 7;
            this.splItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splItems.Location = new System.Drawing.Point(0, 32);
            this.splItems.Name = "splItems";
            this.splItems.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // splItems.Panel1
            // 
            this.splItems.Panel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            this.splItems.Panel1.Controls.Add(this.lsvItems);
            // 
            // splItems.Panel2
            // 
            this.splItems.Panel2.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            this.splItems.Panel2.Controls.Add(this.lsvDetails);
            this.splItems.Size = new System.Drawing.Size(508, 267);
            this.splItems.SplitterDistance = 175;
            this.splItems.Style = Syncfusion.Windows.Forms.Tools.Enums.Style.VS2005;
            this.splItems.TabIndex = 12;
            this.splItems.ThemesEnabled = true;
            // 
            // lsvItems
            // 
            this.lsvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhPath,
            this.clhStatus,
            this.clhOwnership});
            this.lsvItems.ContextMenuStrip = this.cmsItems;
            this.lsvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvItems.FullRowSelect = true;
            this.lsvItems.GridLines = true;
            this.lsvItems.Location = new System.Drawing.Point(0, 0);
            this.lsvItems.MultiSelect = false;
            this.lsvItems.Name = "lsvItems";
            this.lsvItems.Size = new System.Drawing.Size(508, 175);
            this.lsvItems.SmallImageList = this.imgFileIcons;
            this.lsvItems.TabIndex = 0;
            this.lsvItems.UseCompatibleStateImageBehavior = false;
            this.lsvItems.View = System.Windows.Forms.View.Details;
            this.lsvItems.SelectedIndexChanged += new System.EventHandler(this.lsvItems_SelectedIndexChanged);
            this.lsvItems.DoubleClick += new System.EventHandler(this.lsvItems_DoubleClick);
            // 
            // clhPath
            // 
            this.clhPath.Text = "Path";
            // 
            // clhStatus
            // 
            this.clhStatus.Text = "Status";
            // 
            // clhOwnership
            // 
            this.clhOwnership.Text = "Ownership";
            this.clhOwnership.Width = 70;
            // 
            // cmsItems
            // 
            this.cmsItems.DropShadowEnabled = false;
            this.cmsItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unlockToolStripMenuItem,
            this.ownershipToolStripMenuItem,
            this.splitToolStripMenuItem1,
            this.detailsToolStripMenuItem,
            this.propertiesToolStripMenuItemItems,
            this.splitToolStripMenuItem2,
            this.removeItemToolStripMenuItem,
            this.clearItemsToolStripMenuItem,
            this.splitToolStripMenuItem3,
            this.openInVirusTotalToolStripMenuItem,
            this.splitToolStripMenuItem8,
            this.cancelCurrentOperationToolStripMenuItem});
            this.cmsItems.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.cmsItems.Name = "cmsItems";
            this.cmsItems.Size = new System.Drawing.Size(213, 204);
            this.cmsItems.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Metro;
            // 
            // unlockToolStripMenuItem
            // 
            this.unlockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unlockToolStripMenuItem1,
            this.splitToolStripMenuItem4,
            this.copyToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.splitToolStripMenuItem5,
            this.removeToolStripMenuItem});
            this.unlockToolStripMenuItem.Image = global::DeadLock.Properties.Resources.unlock;
            this.unlockToolStripMenuItem.Name = "unlockToolStripMenuItem";
            this.unlockToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.unlockToolStripMenuItem.Text = "Unlock";
            // 
            // unlockToolStripMenuItem1
            // 
            this.unlockToolStripMenuItem1.Image = global::DeadLock.Properties.Resources.unlock;
            this.unlockToolStripMenuItem1.Name = "unlockToolStripMenuItem1";
            this.unlockToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.U)));
            this.unlockToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.unlockToolStripMenuItem1.Text = "Unlock";
            this.unlockToolStripMenuItem1.Click += new System.EventHandler(this.unlockToolStripMenuItem1_Click);
            // 
            // splitToolStripMenuItem4
            // 
            this.splitToolStripMenuItem4.Name = "splitToolStripMenuItem4";
            this.splitToolStripMenuItem4.Size = new System.Drawing.Size(197, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::DeadLock.Properties.Resources.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Image = global::DeadLock.Properties.Resources.move;
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.M)));
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // splitToolStripMenuItem5
            // 
            this.splitToolStripMenuItem5.Name = "splitToolStripMenuItem5";
            this.splitToolStripMenuItem5.Size = new System.Drawing.Size(197, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::DeadLock.Properties.Resources.delete;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // ownershipToolStripMenuItem
            // 
            this.ownershipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trueOwnershipToolStripMenuItem,
            this.falseOwnershipToolStripMenuItem});
            this.ownershipToolStripMenuItem.Image = global::DeadLock.Properties.Resources.ownership;
            this.ownershipToolStripMenuItem.Name = "ownershipToolStripMenuItem";
            this.ownershipToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.ownershipToolStripMenuItem.Text = "Ownership";
            // 
            // trueOwnershipToolStripMenuItem
            // 
            this.trueOwnershipToolStripMenuItem.Image = global::DeadLock.Properties.Resources.allow;
            this.trueOwnershipToolStripMenuItem.Name = "trueOwnershipToolStripMenuItem";
            this.trueOwnershipToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.trueOwnershipToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.trueOwnershipToolStripMenuItem.Text = "True";
            this.trueOwnershipToolStripMenuItem.Click += new System.EventHandler(this.trueOwnershipToolStripMenuItem_Click);
            // 
            // falseOwnershipToolStripMenuItem
            // 
            this.falseOwnershipToolStripMenuItem.Image = global::DeadLock.Properties.Resources.delete;
            this.falseOwnershipToolStripMenuItem.Name = "falseOwnershipToolStripMenuItem";
            this.falseOwnershipToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.falseOwnershipToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.falseOwnershipToolStripMenuItem.Text = "False";
            this.falseOwnershipToolStripMenuItem.Click += new System.EventHandler(this.falseOwnershipToolStripMenuItem_Click);
            // 
            // splitToolStripMenuItem1
            // 
            this.splitToolStripMenuItem1.Name = "splitToolStripMenuItem1";
            this.splitToolStripMenuItem1.Size = new System.Drawing.Size(209, 6);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Image = global::DeadLock.Properties.Resources.details;
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.lsvItems_DoubleClick);
            // 
            // propertiesToolStripMenuItemItems
            // 
            this.propertiesToolStripMenuItemItems.Image = global::DeadLock.Properties.Resources.details;
            this.propertiesToolStripMenuItemItems.Name = "propertiesToolStripMenuItemItems";
            this.propertiesToolStripMenuItemItems.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.propertiesToolStripMenuItemItems.Size = new System.Drawing.Size(212, 22);
            this.propertiesToolStripMenuItemItems.Text = "Properties";
            this.propertiesToolStripMenuItemItems.Click += new System.EventHandler(this.propertiesToolStripMenuItemItems_Click);
            // 
            // splitToolStripMenuItem2
            // 
            this.splitToolStripMenuItem2.Name = "splitToolStripMenuItem2";
            this.splitToolStripMenuItem2.Size = new System.Drawing.Size(209, 6);
            // 
            // removeItemToolStripMenuItem
            // 
            this.removeItemToolStripMenuItem.Image = global::DeadLock.Properties.Resources.delete;
            this.removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            this.removeItemToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeItemToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.removeItemToolStripMenuItem.Text = "Remove item";
            this.removeItemToolStripMenuItem.Click += new System.EventHandler(this.removeItemToolStripMenuItem_Click);
            // 
            // clearItemsToolStripMenuItem
            // 
            this.clearItemsToolStripMenuItem.Image = global::DeadLock.Properties.Resources.exit;
            this.clearItemsToolStripMenuItem.Name = "clearItemsToolStripMenuItem";
            this.clearItemsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.clearItemsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.clearItemsToolStripMenuItem.Text = "Clear items";
            this.clearItemsToolStripMenuItem.Click += new System.EventHandler(this.clearItemsToolStripMenuItem_Click);
            // 
            // splitToolStripMenuItem3
            // 
            this.splitToolStripMenuItem3.Name = "splitToolStripMenuItem3";
            this.splitToolStripMenuItem3.Size = new System.Drawing.Size(209, 6);
            // 
            // openInVirusTotalToolStripMenuItem
            // 
            this.openInVirusTotalToolStripMenuItem.Image = global::DeadLock.Properties.Resources.VirusTotal;
            this.openInVirusTotalToolStripMenuItem.Name = "openInVirusTotalToolStripMenuItem";
            this.openInVirusTotalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.openInVirusTotalToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.openInVirusTotalToolStripMenuItem.Text = "Open in VirusTotal";
            this.openInVirusTotalToolStripMenuItem.Click += new System.EventHandler(this.openInVirusTotalToolStripMenuItem_Click);
            // 
            // splitToolStripMenuItem8
            // 
            this.splitToolStripMenuItem8.Name = "splitToolStripMenuItem8";
            this.splitToolStripMenuItem8.Size = new System.Drawing.Size(209, 6);
            // 
            // cancelCurrentOperationToolStripMenuItem
            // 
            this.cancelCurrentOperationToolStripMenuItem.Image = global::DeadLock.Properties.Resources.exit;
            this.cancelCurrentOperationToolStripMenuItem.Name = "cancelCurrentOperationToolStripMenuItem";
            this.cancelCurrentOperationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cancelCurrentOperationToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.cancelCurrentOperationToolStripMenuItem.Text = "Cancel task";
            this.cancelCurrentOperationToolStripMenuItem.Click += new System.EventHandler(this.cancelCurrentOperationToolStripMenuItem_Click);
            // 
            // imgFileIcons
            // 
            this.imgFileIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgFileIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.imgFileIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lsvDetails
            // 
            this.lsvDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhFileName,
            this.clhProcessPath,
            this.clhProcessID});
            this.lsvDetails.ContextMenuStrip = this.cmsDetails;
            this.lsvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvDetails.FullRowSelect = true;
            this.lsvDetails.GridLines = true;
            this.lsvDetails.Location = new System.Drawing.Point(0, 0);
            this.lsvDetails.Name = "lsvDetails";
            this.lsvDetails.Size = new System.Drawing.Size(508, 85);
            this.lsvDetails.TabIndex = 0;
            this.lsvDetails.UseCompatibleStateImageBehavior = false;
            this.lsvDetails.View = System.Windows.Forms.View.Details;
            this.lsvDetails.DoubleClick += new System.EventHandler(this.lsvDetails_DoubleClick);
            // 
            // clhFileName
            // 
            this.clhFileName.Text = "File name";
            // 
            // clhProcessPath
            // 
            this.clhProcessPath.Text = "Path";
            // 
            // clhProcessID
            // 
            this.clhProcessID.Text = "Process ID";
            // 
            // cmsDetails
            // 
            this.cmsDetails.DropShadowEnabled = false;
            this.cmsDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItemDetails,
            this.splitToolStripMenuItem12,
            this.killToolStripMenuItem,
            this.splitToolStripMenuItem6,
            this.openFileLocationToolStripMenuItem,
            this.splitToolStripMenuItem7,
            this.openInVirusTotalToolStripMenuItem1});
            this.cmsDetails.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.cmsDetails.Name = "cmsDetails";
            this.cmsDetails.Size = new System.Drawing.Size(213, 110);
            this.cmsDetails.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Metro;
            // 
            // propertiesToolStripMenuItemDetails
            // 
            this.propertiesToolStripMenuItemDetails.Image = global::DeadLock.Properties.Resources.details;
            this.propertiesToolStripMenuItemDetails.Name = "propertiesToolStripMenuItemDetails";
            this.propertiesToolStripMenuItemDetails.Size = new System.Drawing.Size(212, 22);
            this.propertiesToolStripMenuItemDetails.Text = "Properties";
            this.propertiesToolStripMenuItemDetails.Click += new System.EventHandler(this.lsvDetails_DoubleClick);
            // 
            // splitToolStripMenuItem12
            // 
            this.splitToolStripMenuItem12.Name = "splitToolStripMenuItem12";
            this.splitToolStripMenuItem12.Size = new System.Drawing.Size(209, 6);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Image = global::DeadLock.Properties.Resources.exit;
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.killToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click);
            // 
            // splitToolStripMenuItem6
            // 
            this.splitToolStripMenuItem6.Name = "splitToolStripMenuItem6";
            this.splitToolStripMenuItem6.Size = new System.Drawing.Size(209, 6);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Image = global::DeadLock.Properties.Resources.folder;
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.openFileLocationToolStripMenuItem.Text = "Open file location";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // splitToolStripMenuItem7
            // 
            this.splitToolStripMenuItem7.Name = "splitToolStripMenuItem7";
            this.splitToolStripMenuItem7.Size = new System.Drawing.Size(209, 6);
            // 
            // openInVirusTotalToolStripMenuItem1
            // 
            this.openInVirusTotalToolStripMenuItem1.Image = global::DeadLock.Properties.Resources.VirusTotal;
            this.openInVirusTotalToolStripMenuItem1.Name = "openInVirusTotalToolStripMenuItem1";
            this.openInVirusTotalToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.openInVirusTotalToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.openInVirusTotalToolStripMenuItem1.Text = "Open in VirusTotal";
            this.openInVirusTotalToolStripMenuItem1.Click += new System.EventHandler(this.openInVirusTotalToolStripMenuItem1_Click);
            // 
            // nfiTray
            // 
            this.nfiTray.ContextMenuStrip = this.cmsTray;
            this.nfiTray.Icon = ((System.Drawing.Icon)(resources.GetObject("nfiTray.Icon")));
            this.nfiTray.Text = "DeadLock";
            this.nfiTray.Visible = true;
            this.nfiTray.DoubleClick += new System.EventHandler(this.hideShowToolStripMenuItem_Click);
            // 
            // cmsTray
            // 
            this.cmsTray.DropShadowEnabled = false;
            this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideShowToolStripMenuItem,
            this.splitToolStripMenuItem9,
            this.settingsToolStripMenuItem,
            this.splitToolStripMenuItem10,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.splitToolStripMenuItem11,
            this.exitToolStripMenuItem});
            this.cmsTray.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.cmsTray.Name = "cmsTray";
            this.cmsTray.Size = new System.Drawing.Size(140, 132);
            this.cmsTray.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Metro;
            // 
            // hideShowToolStripMenuItem
            // 
            this.hideShowToolStripMenuItem.Image = global::DeadLock.Properties.Resources.visibility;
            this.hideShowToolStripMenuItem.Name = "hideShowToolStripMenuItem";
            this.hideShowToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.hideShowToolStripMenuItem.Text = "Hide / Show";
            this.hideShowToolStripMenuItem.Click += new System.EventHandler(this.hideShowToolStripMenuItem_Click);
            // 
            // splitToolStripMenuItem9
            // 
            this.splitToolStripMenuItem9.Name = "splitToolStripMenuItem9";
            this.splitToolStripMenuItem9.Size = new System.Drawing.Size(136, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::DeadLock.Properties.Resources.settings;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsBarItem_Click);
            // 
            // splitToolStripMenuItem10
            // 
            this.splitToolStripMenuItem10.Name = "splitToolStripMenuItem10";
            this.splitToolStripMenuItem10.Size = new System.Drawing.Size(136, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = global::DeadLock.Properties.Resources.help;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpBarItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::DeadLock.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutBarItem_Click);
            // 
            // splitToolStripMenuItem11
            // 
            this.splitToolStripMenuItem11.Name = "splitToolStripMenuItem11";
            this.splitToolStripMenuItem11.Size = new System.Drawing.Size(136, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::DeadLock.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitBarItem_Click);
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.SteelBlue;
            this.BorderThickness = 3;
            this.CaptionBarColor = System.Drawing.Color.SteelBlue;
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionForeColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(508, 331);
            this.Controls.Add(this.splItems);
            this.DoubleBuffered = true;
            this.DropShadow = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MetroColor = System.Drawing.Color.SteelBlue;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeadLock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.mfbmMain)).EndInit();
            this.splItems.Panel1.ResumeLayout(false);
            this.splItems.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splItems)).EndInit();
            this.splItems.ResumeLayout(false);
            this.cmsItems.ResumeLayout(false);
            this.cmsDetails.ResumeLayout(false);
            this.cmsTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager mfbmMain;
        private Syncfusion.Windows.Forms.Tools.XPMenus.Bar barMain;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem fileParentBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem openFilesBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem openFolderbarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem exitBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem editParentBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem clearItemsbarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem toolsParentBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem settingsBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem helpParentBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem helpBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem checkForUpdatesBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem homePageBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem licenseBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem aboutBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem autoSizeColumnsBarItem;
        private System.Windows.Forms.ColumnHeader clhProcessID;
        private System.Windows.Forms.ColumnHeader clhProcessPath;
        private System.Windows.Forms.ColumnHeader clhFileName;
        private System.Windows.Forms.ListView lsvDetails;
        private System.Windows.Forms.ColumnHeader clhStatus;
        private System.Windows.Forms.ColumnHeader clhPath;
        private System.Windows.Forms.ListView lsvItems;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splItems;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx cmsItems;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem removeItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem openInVirusTotalToolStripMenuItem;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx cmsDetails;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem openInVirusTotalToolStripMenuItem1;
        private Syncfusion.Windows.Forms.Tools.XPMenus.Bar barStatus;
        private Syncfusion.Windows.Forms.Tools.XPMenus.StaticBarItem versionStaticBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem unlockParentBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem unlockBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem copyBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem moveBarItem;
        private System.Windows.Forms.ToolStripMenuItem unlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unlockToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem cancelCurrentOperationToolStripMenuItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem viewParentBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem detailsBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem cancelOperationBarItem;
        private System.Windows.Forms.ImageList imgFileIcons;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx cmsTray;
        private System.Windows.Forms.ToolStripMenuItem hideShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        internal System.Windows.Forms.NotifyIcon nfiTray;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem restartBarItem;
        private System.Windows.Forms.ColumnHeader clhOwnership;
        private System.Windows.Forms.ToolStripMenuItem ownershipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trueOwnershipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem falseOwnershipToolStripMenuItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem ownershipParentBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem trueBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem falseBarItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItemDetails;
        private System.Windows.Forms.ToolStripSeparator splitToolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItemItems;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem propertiesBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem removeItemBarItem;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem removeBarItem;
    }
}