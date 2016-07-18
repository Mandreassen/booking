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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fast_check_in));
            this.roComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.detailsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.p_count = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.p_count)).BeginInit();
            this.SuspendLayout();
            // 
            // roComboBox
            // 
            this.roComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roComboBox.FormattingEnabled = true;
            this.roComboBox.Location = new System.Drawing.Point(12, 89);
            this.roComboBox.Name = "roComboBox";
            this.roComboBox.Size = new System.Drawing.Size(258, 28);
            this.roComboBox.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.Window;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(133, 141);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(110, 39);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Check in";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // detailsButton
            // 
            this.detailsButton.BackColor = System.Drawing.SystemColors.Window;
            this.detailsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsButton.Location = new System.Drawing.Point(198, 12);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(157, 39);
            this.detailsButton.TabIndex = 2;
            this.detailsButton.Text = "View booking details";
            this.detailsButton.UseVisualStyleBackColor = false;
            this.detailsButton.Click += new System.EventHandler(this.detailsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Check in";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(288, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Persons";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Object";
            // 
            // p_count
            // 
            this.p_count.BackColor = System.Drawing.SystemColors.Info;
            this.p_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p_count.Location = new System.Drawing.Point(292, 90);
            this.p_count.Name = "p_count";
            this.p_count.Size = new System.Drawing.Size(63, 26);
            this.p_count.TabIndex = 7;
            // 
            // Fast_check_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(367, 192);
            this.Controls.Add(this.p_count);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.detailsButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.roComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Fast_check_in";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check in";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fast_check_in_FormClosing);
            this.Load += new System.EventHandler(this.Fast_check_in_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox roComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button detailsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown p_count;
    }
}