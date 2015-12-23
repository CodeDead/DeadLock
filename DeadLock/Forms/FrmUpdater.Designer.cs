#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace DeadLock.Forms
{
    partial class FrmUpdater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdater));
            this.lblProgress = new System.Windows.Forms.Label();
            this.pgbDownload = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnUpdate = new Syncfusion.Windows.Forms.ButtonAdv();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.btnSelectPath = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.pgbDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Location = new System.Drawing.Point(12, 48);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(51, 13);
            this.lblProgress.TabIndex = 3;
            this.lblProgress.Text = "Progress:";
            // 
            // pgbDownload
            // 
            this.pgbDownload.BackGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.pgbDownload.BackGradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.pgbDownload.BackgroundStyle = Syncfusion.Windows.Forms.Tools.ProgressBarBackgroundStyles.Gradient;
            this.pgbDownload.BackMultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.pgbDownload.BackSegments = false;
            this.pgbDownload.BackTubeEndColor = System.Drawing.Color.White;
            this.pgbDownload.BackTubeStartColor = System.Drawing.Color.LightGray;
            this.pgbDownload.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            this.pgbDownload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pgbDownload.CustomText = null;
            this.pgbDownload.CustomWaitingRender = false;
            this.pgbDownload.FontColor = System.Drawing.Color.White;
            this.pgbDownload.ForegroundImage = null;
            this.pgbDownload.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.pgbDownload.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.pgbDownload.Location = new System.Drawing.Point(12, 64);
            this.pgbDownload.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.pgbDownload.Name = "pgbDownload";
            this.pgbDownload.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Metro;
            this.pgbDownload.SegmentWidth = 12;
            this.pgbDownload.Size = new System.Drawing.Size(364, 23);
            this.pgbDownload.TabIndex = 4;
            this.pgbDownload.ThemesEnabled = false;
            this.pgbDownload.TubeEndColor = System.Drawing.Color.Black;
            this.pgbDownload.TubeStartColor = System.Drawing.Color.Red;
            this.pgbDownload.Value = 0;
            this.pgbDownload.WaitingGradientWidth = 400;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(12, 93);
            this.btnCancel.MetroColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyle = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnUpdate.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.IsBackStageButton = false;
            this.btnUpdate.Location = new System.Drawing.Point(301, 93);
            this.btnUpdate.MetroColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyle = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 9);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Path:";
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.BeforeTouchSize = new System.Drawing.Size(305, 20);
            this.txtPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPath.Location = new System.Drawing.Point(15, 25);
            this.txtPath.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(305, 20);
            this.txtPath.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.txtPath.TabIndex = 1;
            this.txtPath.DoubleClick += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnSelectPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnSelectPath.BeforeTouchSize = new System.Drawing.Size(50, 20);
            this.btnSelectPath.ForeColor = System.Drawing.Color.White;
            this.btnSelectPath.IsBackStageButton = false;
            this.btnSelectPath.Location = new System.Drawing.Point(326, 25);
            this.btnSelectPath.MetroColor = System.Drawing.Color.SteelBlue;
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(50, 20);
            this.btnSelectPath.TabIndex = 2;
            this.btnSelectPath.Text = "...";
            this.btnSelectPath.UseVisualStyle = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // FrmUpdater
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.SteelBlue;
            this.BorderThickness = 3;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(388, 128);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pgbDownload);
            this.Controls.Add(this.lblProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.SteelBlue;
            this.Name = "FrmUpdater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeadLock - Updater";
            ((System.ComponentModel.ISupportInitialize)(this.pgbDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProgress;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv pgbDownload;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnUpdate;
        private System.Windows.Forms.Label lblPath;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPath;
        private Syncfusion.Windows.Forms.ButtonAdv btnSelectPath;
    }
}