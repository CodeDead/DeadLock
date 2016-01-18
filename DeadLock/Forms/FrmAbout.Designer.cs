#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace DeadLock.Forms
{
    partial class FrmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.pnlAbout = new System.Windows.Forms.Panel();
            this.txtAbout = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnLicense = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCodeDead = new Syncfusion.Windows.Forms.ButtonAdv();
            this.pnlAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbout)).BeginInit();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAbout
            // 
            this.pnlAbout.Controls.Add(this.txtAbout);
            this.pnlAbout.Controls.Add(this.pnlImage);
            this.pnlAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAbout.Location = new System.Drawing.Point(0, 0);
            this.pnlAbout.Name = "pnlAbout";
            this.pnlAbout.Size = new System.Drawing.Size(343, 139);
            this.pnlAbout.TabIndex = 1;
            // 
            // txtAbout
            // 
            this.txtAbout.BeforeTouchSize = new System.Drawing.Size(243, 139);
            this.txtAbout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAbout.Location = new System.Drawing.Point(100, 0);
            this.txtAbout.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtAbout.Multiline = true;
            this.txtAbout.Name = "txtAbout";
            this.txtAbout.ReadOnly = true;
            this.txtAbout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAbout.Size = new System.Drawing.Size(243, 139);
            this.txtAbout.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtAbout.TabIndex = 1;
            this.txtAbout.TabStop = false;
            // 
            // pnlImage
            // 
            this.pnlImage.Controls.Add(this.picLogo);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlImage.Location = new System.Drawing.Point(0, 0);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(100, 139);
            this.pnlImage.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Image = global::DeadLock.Properties.Resources._lock;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 139);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(12, 145);
            this.btnClose.MetroColor = System.Drawing.Color.SteelBlue;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyle = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLicense
            // 
            this.btnLicense.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnLicense.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnLicense.ForeColor = System.Drawing.Color.White;
            this.btnLicense.IsBackStageButton = false;
            this.btnLicense.Location = new System.Drawing.Point(175, 145);
            this.btnLicense.MetroColor = System.Drawing.Color.SteelBlue;
            this.btnLicense.Name = "btnLicense";
            this.btnLicense.Size = new System.Drawing.Size(75, 23);
            this.btnLicense.TabIndex = 1;
            this.btnLicense.Text = "License";
            this.btnLicense.UseVisualStyle = true;
            this.btnLicense.UseVisualStyleBackColor = false;
            this.btnLicense.Click += new System.EventHandler(this.btnLicense_Click);
            // 
            // btnCodeDead
            // 
            this.btnCodeDead.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCodeDead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCodeDead.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnCodeDead.ForeColor = System.Drawing.Color.White;
            this.btnCodeDead.IsBackStageButton = false;
            this.btnCodeDead.Location = new System.Drawing.Point(256, 145);
            this.btnCodeDead.MetroColor = System.Drawing.Color.SteelBlue;
            this.btnCodeDead.Name = "btnCodeDead";
            this.btnCodeDead.Size = new System.Drawing.Size(75, 23);
            this.btnCodeDead.TabIndex = 2;
            this.btnCodeDead.Text = "CodeDead";
            this.btnCodeDead.UseVisualStyle = true;
            this.btnCodeDead.Click += new System.EventHandler(this.btnCodeDead_Click);
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.btnCodeDead;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.SteelBlue;
            this.BorderThickness = 3;
            this.CancelButton = this.btnClose;
            this.CaptionBarColor = System.Drawing.Color.SteelBlue;
            this.CaptionButtonColor = System.Drawing.Color.White;
            this.CaptionForeColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(343, 180);
            this.Controls.Add(this.btnCodeDead);
            this.Controls.Add(this.btnLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlAbout);
            this.DropShadow = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.SteelBlue;
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeadLock - About";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            this.pnlAbout.ResumeLayout(false);
            this.pnlAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbout)).EndInit();
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAbout;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.PictureBox picLogo;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtAbout;
        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private Syncfusion.Windows.Forms.ButtonAdv btnLicense;
        private Syncfusion.Windows.Forms.ButtonAdv btnCodeDead;
    }
}