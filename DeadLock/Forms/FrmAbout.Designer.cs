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
            this.btnDonate = new Syncfusion.Windows.Forms.ButtonAdv();
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
            this.pnlAbout.Location = new System.Drawing.Point(2, 2);
            this.pnlAbout.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAbout.Name = "pnlAbout";
            this.pnlAbout.Size = new System.Drawing.Size(455, 171);
            this.pnlAbout.TabIndex = 1;
            // 
            // txtAbout
            // 
            this.txtAbout.BeforeTouchSize = new System.Drawing.Size(322, 171);
            this.txtAbout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAbout.Location = new System.Drawing.Point(133, 0);
            this.txtAbout.Margin = new System.Windows.Forms.Padding(4);
            this.txtAbout.Multiline = true;
            this.txtAbout.Name = "txtAbout";
            this.txtAbout.ReadOnly = true;
            this.txtAbout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAbout.Size = new System.Drawing.Size(322, 171);
            this.txtAbout.TabIndex = 1;
            this.txtAbout.TabStop = false;
            this.txtAbout.ThemeName = "Default";
            // 
            // pnlImage
            // 
            this.pnlImage.Controls.Add(this.picLogo);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlImage.Location = new System.Drawing.Point(0, 0);
            this.pnlImage.Margin = new System.Windows.Forms.Padding(4);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(133, 171);
            this.pnlImage.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Image = global::DeadLock.Properties.Resources._lock;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(133, 171);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(100, 28);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(6, 187);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.ThemeName = "Metro";
            this.btnClose.UseVisualStyle = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDonate
            // 
            this.btnDonate.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnDonate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnDonate.BeforeTouchSize = new System.Drawing.Size(100, 28);
            this.btnDonate.ForeColor = System.Drawing.Color.White;
            this.btnDonate.Location = new System.Drawing.Point(245, 187);
            this.btnDonate.Margin = new System.Windows.Forms.Padding(4);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(100, 28);
            this.btnDonate.TabIndex = 1;
            this.btnDonate.Text = "Donate";
            this.btnDonate.ThemeName = "Metro";
            this.btnDonate.UseVisualStyle = true;
            this.btnDonate.UseVisualStyleBackColor = false;
            this.btnDonate.Click += new System.EventHandler(this.btnDonate_Click);
            // 
            // btnCodeDead
            // 
            this.btnCodeDead.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCodeDead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCodeDead.BeforeTouchSize = new System.Drawing.Size(100, 28);
            this.btnCodeDead.ForeColor = System.Drawing.Color.White;
            this.btnCodeDead.Location = new System.Drawing.Point(353, 187);
            this.btnCodeDead.Margin = new System.Windows.Forms.Padding(4);
            this.btnCodeDead.Name = "btnCodeDead";
            this.btnCodeDead.Size = new System.Drawing.Size(100, 28);
            this.btnCodeDead.TabIndex = 2;
            this.btnCodeDead.Text = "CodeDead";
            this.btnCodeDead.ThemeName = "Metro";
            this.btnCodeDead.UseVisualStyle = true;
            this.btnCodeDead.Click += new System.EventHandler(this.btnCodeDead_Click);
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.btnCodeDead;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(459, 221);
            this.Controls.Add(this.btnCodeDead);
            this.Controls.Add(this.btnDonate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
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
        private Syncfusion.Windows.Forms.ButtonAdv btnDonate;
        private Syncfusion.Windows.Forms.ButtonAdv btnCodeDead;
    }
}