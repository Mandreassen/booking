namespace arctic_seasport_admin
{
    partial class Check_inn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Check_inn));
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.useTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.roComboBox = new System.Windows.Forms.ComboBox();
            this.checkInnButton = new System.Windows.Forms.Button();
            this.checkOutButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.useTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // customerComboBox
            // 
            this.customerComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(12, 116);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(224, 24);
            this.customerComboBox.TabIndex = 0;
            this.customerComboBox.SelectedIndexChanged += new System.EventHandler(this.customerComboBox_SelectedIndexChanged);
            // 
            // useTable
            // 
            this.useTable.AllowUserToAddRows = false;
            this.useTable.AllowUserToDeleteRows = false;
            this.useTable.AllowUserToResizeColumns = false;
            this.useTable.AllowUserToResizeRows = false;
            this.useTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.useTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.useTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.useTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.useTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.useTable.ColumnHeadersVisible = false;
            this.useTable.GridColor = System.Drawing.SystemColors.ControlLight;
            this.useTable.Location = new System.Drawing.Point(386, 61);
            this.useTable.Name = "useTable";
            this.useTable.ReadOnly = true;
            this.useTable.RowHeadersVisible = false;
            this.useTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.useTable.Size = new System.Drawing.Size(338, 377);
            this.useTable.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(382, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Check out customer";
            // 
            // roComboBox
            // 
            this.roComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roComboBox.FormattingEnabled = true;
            this.roComboBox.Location = new System.Drawing.Point(12, 178);
            this.roComboBox.Name = "roComboBox";
            this.roComboBox.Size = new System.Drawing.Size(224, 24);
            this.roComboBox.TabIndex = 29;
            // 
            // checkInnButton
            // 
            this.checkInnButton.BackColor = System.Drawing.SystemColors.Window;
            this.checkInnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkInnButton.Location = new System.Drawing.Point(256, 165);
            this.checkInnButton.Name = "checkInnButton";
            this.checkInnButton.Size = new System.Drawing.Size(98, 29);
            this.checkInnButton.TabIndex = 30;
            this.checkInnButton.Text = "Check inn ->";
            this.checkInnButton.UseVisualStyleBackColor = false;
            this.checkInnButton.Click += new System.EventHandler(this.checkInnButton_Click);
            // 
            // checkOutButton
            // 
            this.checkOutButton.BackColor = System.Drawing.SystemColors.Window;
            this.checkOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOutButton.Location = new System.Drawing.Point(256, 126);
            this.checkOutButton.Name = "checkOutButton";
            this.checkOutButton.Size = new System.Drawing.Size(98, 29);
            this.checkOutButton.TabIndex = 31;
            this.checkOutButton.Text = "<- Check out";
            this.checkOutButton.UseVisualStyleBackColor = false;
            this.checkOutButton.Click += new System.EventHandler(this.checkOutButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Select rent object";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Check in booking";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 68);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // Check_inn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(736, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkOutButton);
            this.Controls.Add(this.checkInnButton);
            this.Controls.Add(this.roComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.useTable);
            this.Controls.Add(this.customerComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Check_inn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arctic Seasport Admin - Check in/out";
            this.Load += new System.EventHandler(this.Check_inn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.useTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.DataGridView useTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox roComboBox;
        private System.Windows.Forms.Button checkInnButton;
        private System.Windows.Forms.Button checkOutButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}