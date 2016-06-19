namespace arctic_seasport_admin
{
    partial class Fast_check_in
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
            this.roComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // roComboBox
            // 
            this.roComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roComboBox.FormattingEnabled = true;
            this.roComboBox.Location = new System.Drawing.Point(13, 13);
            this.roComboBox.Name = "roComboBox";
            this.roComboBox.Size = new System.Drawing.Size(307, 28);
            this.roComboBox.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.Window;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(114, 63);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(110, 39);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Check in";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Fast_check_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(332, 114);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.roComboBox);
            this.Name = "Fast_check_in";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fast_check_in";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox roComboBox;
        private System.Windows.Forms.Button saveButton;
    }
}