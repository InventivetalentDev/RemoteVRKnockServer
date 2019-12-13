using System.ComponentModel;

namespace KnockServer
{
    partial class InfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.label1 = new System.Windows.Forms.Label();
            this.qrPictureBox = new System.Windows.Forms.PictureBox();
            this.hostLabel = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gameActivityCheckbox = new System.Windows.Forms.CheckBox();
            this.autostartCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize) (this.qrPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scan the QR Code Below using the VRKnock App!";
            // 
            // qrPictureBox
            // 
            this.qrPictureBox.Location = new System.Drawing.Point(10, 30);
            this.qrPictureBox.Name = "qrPictureBox";
            this.qrPictureBox.Size = new System.Drawing.Size(199, 200);
            this.qrPictureBox.TabIndex = 1;
            this.qrPictureBox.TabStop = false;
            // 
            // hostLabel
            // 
            this.hostLabel.Location = new System.Drawing.Point(10, 240);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(226, 20);
            this.hostLabel.TabIndex = 2;
            this.hostLabel.Text = "Host:";
            // 
            // codeLabel
            // 
            this.codeLabel.Location = new System.Drawing.Point(10, 260);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(226, 20);
            this.codeLabel.TabIndex = 3;
            this.codeLabel.Text = "Code:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Right-Click the Tray Icon to Exit";
            // 
            // gameActivityCheckbox
            // 
            this.gameActivityCheckbox.Location = new System.Drawing.Point(16, 300);
            this.gameActivityCheckbox.Name = "gameActivityCheckbox";
            this.gameActivityCheckbox.Size = new System.Drawing.Size(199, 20);
            this.gameActivityCheckbox.TabIndex = 5;
            this.gameActivityCheckbox.Text = "Show Current Game In App";
            this.gameActivityCheckbox.UseVisualStyleBackColor = true;
            // 
            // autostartCheckbox
            // 
            this.autostartCheckbox.Location = new System.Drawing.Point(16, 330);
            this.autostartCheckbox.Name = "autostartCheckbox";
            this.autostartCheckbox.Size = new System.Drawing.Size(199, 20);
            this.autostartCheckbox.TabIndex = 6;
            this.autostartCheckbox.Text = "Autostart with SteamVR";
            this.autostartCheckbox.UseVisualStyleBackColor = true;
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 511);
            this.Controls.Add(this.autostartCheckbox);
            this.Controls.Add(this.gameActivityCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.qrPictureBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "InfoForm";
            this.Text = "VRKnock Server";
            ((System.ComponentModel.ISupportInitialize) (this.qrPictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox qrPictureBox;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox gameActivityCheckbox;
        private System.Windows.Forms.CheckBox autostartCheckbox;
    }
}