namespace arctic_seasport_admin
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.loginSettingsButton = new System.Windows.Forms.Button();
            this.backupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginSettingsButton
            // 
            this.loginSettingsButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginSettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("loginSettingsButton.Image")));
            this.loginSettingsButton.Location = new System.Drawing.Point(23, 12);
            this.loginSettingsButton.Name = "loginSettingsButton";
            this.loginSettingsButton.Size = new System.Drawing.Size(169, 49);
            this.loginSettingsButton.TabIndex = 0;
            this.loginSettingsButton.Text = "Login settings";
            this.loginSettingsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.loginSettingsButton.UseVisualStyleBackColor = false;
            this.loginSettingsButton.Click += new System.EventHandler(this.loginSettingsButton_Click);
            // 
            // backupButton
            // 
            this.backupButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.backupButton.Image = ((System.Drawing.Image)(resources.GetObject("backupButton.Image")));
            this.backupButton.Location = new System.Drawing.Point(23, 79);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(169, 49);
            this.backupButton.TabIndex = 1;
            this.backupButton.Text = "Backup database";
            this.backupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.backupButton.UseVisualStyleBackColor = false;
            this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(216, 143);
            this.Controls.Add(this.backupButton);
            this.Controls.Add(this.loginSettingsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loginSettingsButton;
        private System.Windows.Forms.Button backupButton;
    }
}