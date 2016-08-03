namespace arctic_seasport_admin
{
    partial class ObjectDeleter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectDeleter));
            this.deleteBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // deleteBar
            // 
            this.deleteBar.Location = new System.Drawing.Point(12, 23);
            this.deleteBar.Name = "deleteBar";
            this.deleteBar.Size = new System.Drawing.Size(331, 23);
            this.deleteBar.TabIndex = 0;
            // 
            // ObjectDeleter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(355, 69);
            this.Controls.Add(this.deleteBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObjectDeleter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checking dates...";
            this.Load += new System.EventHandler(this.ObjectDeleter_Load);
            this.Shown += new System.EventHandler(this.ObjectDeleter_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar deleteBar;
    }
}