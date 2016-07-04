namespace arctic_seasport_admin
{
    partial class Edit_rent_objects
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit_rent_objects));
            this.rentObjectsView = new System.Windows.Forms.DataGridView();
            this.rentObjectTypesView = new System.Windows.Forms.DataGridView();
            this.addObjectBtn = new System.Windows.Forms.Button();
            this.editObjectBtn = new System.Windows.Forms.Button();
            this.deleteObjectBtn = new System.Windows.Forms.Button();
            this.deleteTypeBtn = new System.Windows.Forms.Button();
            this.editTypeBtn = new System.Windows.Forms.Button();
            this.addTypeBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rentObjectsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentObjectTypesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rentObjectsView
            // 
            this.rentObjectsView.AllowUserToAddRows = false;
            this.rentObjectsView.AllowUserToDeleteRows = false;
            this.rentObjectsView.AllowUserToResizeColumns = false;
            this.rentObjectsView.AllowUserToResizeRows = false;
            this.rentObjectsView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.rentObjectsView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.rentObjectsView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rentObjectsView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.rentObjectsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rentObjectsView.EnableHeadersVisualStyles = false;
            this.rentObjectsView.Location = new System.Drawing.Point(12, 156);
            this.rentObjectsView.MultiSelect = false;
            this.rentObjectsView.Name = "rentObjectsView";
            this.rentObjectsView.ReadOnly = true;
            this.rentObjectsView.RowHeadersVisible = false;
            this.rentObjectsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rentObjectsView.Size = new System.Drawing.Size(262, 454);
            this.rentObjectsView.TabIndex = 4;
            // 
            // rentObjectTypesView
            // 
            this.rentObjectTypesView.AllowUserToAddRows = false;
            this.rentObjectTypesView.AllowUserToDeleteRows = false;
            this.rentObjectTypesView.AllowUserToResizeColumns = false;
            this.rentObjectTypesView.AllowUserToResizeRows = false;
            this.rentObjectTypesView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.rentObjectTypesView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.rentObjectTypesView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rentObjectTypesView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.rentObjectTypesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rentObjectTypesView.EnableHeadersVisualStyles = false;
            this.rentObjectTypesView.Location = new System.Drawing.Point(325, 156);
            this.rentObjectTypesView.MultiSelect = false;
            this.rentObjectTypesView.Name = "rentObjectTypesView";
            this.rentObjectTypesView.ReadOnly = true;
            this.rentObjectTypesView.RowHeadersVisible = false;
            this.rentObjectTypesView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rentObjectTypesView.Size = new System.Drawing.Size(262, 454);
            this.rentObjectTypesView.TabIndex = 5;
            // 
            // addObjectBtn
            // 
            this.addObjectBtn.BackColor = System.Drawing.SystemColors.Window;
            this.addObjectBtn.Location = new System.Drawing.Point(12, 120);
            this.addObjectBtn.Name = "addObjectBtn";
            this.addObjectBtn.Size = new System.Drawing.Size(75, 30);
            this.addObjectBtn.TabIndex = 6;
            this.addObjectBtn.Text = "New";
            this.addObjectBtn.UseVisualStyleBackColor = false;
            this.addObjectBtn.Click += new System.EventHandler(this.addObjectBtn_Click);
            // 
            // editObjectBtn
            // 
            this.editObjectBtn.BackColor = System.Drawing.SystemColors.Window;
            this.editObjectBtn.Location = new System.Drawing.Point(104, 120);
            this.editObjectBtn.Name = "editObjectBtn";
            this.editObjectBtn.Size = new System.Drawing.Size(75, 30);
            this.editObjectBtn.TabIndex = 7;
            this.editObjectBtn.Text = "Edit";
            this.editObjectBtn.UseVisualStyleBackColor = false;
            this.editObjectBtn.Click += new System.EventHandler(this.editObjectBtn_Click);
            // 
            // deleteObjectBtn
            // 
            this.deleteObjectBtn.BackColor = System.Drawing.SystemColors.Window;
            this.deleteObjectBtn.Location = new System.Drawing.Point(199, 120);
            this.deleteObjectBtn.Name = "deleteObjectBtn";
            this.deleteObjectBtn.Size = new System.Drawing.Size(75, 30);
            this.deleteObjectBtn.TabIndex = 8;
            this.deleteObjectBtn.Text = "Delete";
            this.deleteObjectBtn.UseVisualStyleBackColor = false;
            this.deleteObjectBtn.Click += new System.EventHandler(this.deleteObjectBtn_Click);
            // 
            // deleteTypeBtn
            // 
            this.deleteTypeBtn.BackColor = System.Drawing.SystemColors.Window;
            this.deleteTypeBtn.Location = new System.Drawing.Point(512, 120);
            this.deleteTypeBtn.Name = "deleteTypeBtn";
            this.deleteTypeBtn.Size = new System.Drawing.Size(75, 30);
            this.deleteTypeBtn.TabIndex = 11;
            this.deleteTypeBtn.Text = "Delete";
            this.deleteTypeBtn.UseVisualStyleBackColor = false;
            this.deleteTypeBtn.Click += new System.EventHandler(this.deleteTypeBtn_Click);
            // 
            // editTypeBtn
            // 
            this.editTypeBtn.BackColor = System.Drawing.SystemColors.Window;
            this.editTypeBtn.Location = new System.Drawing.Point(417, 120);
            this.editTypeBtn.Name = "editTypeBtn";
            this.editTypeBtn.Size = new System.Drawing.Size(75, 30);
            this.editTypeBtn.TabIndex = 10;
            this.editTypeBtn.Text = "Edit";
            this.editTypeBtn.UseVisualStyleBackColor = false;
            this.editTypeBtn.Click += new System.EventHandler(this.editTypeBtn_Click);
            // 
            // addTypeBtn
            // 
            this.addTypeBtn.BackColor = System.Drawing.SystemColors.Window;
            this.addTypeBtn.Location = new System.Drawing.Point(325, 120);
            this.addTypeBtn.Name = "addTypeBtn";
            this.addTypeBtn.Size = new System.Drawing.Size(75, 30);
            this.addTypeBtn.TabIndex = 9;
            this.addTypeBtn.Text = "New";
            this.addTypeBtn.UseVisualStyleBackColor = false;
            this.addTypeBtn.Click += new System.EventHandler(this.addTypeBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 68);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Rent objects";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(321, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Rent object types";
            // 
            // Edit_rent_objects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(603, 622);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.deleteTypeBtn);
            this.Controls.Add(this.editTypeBtn);
            this.Controls.Add(this.addTypeBtn);
            this.Controls.Add(this.deleteObjectBtn);
            this.Controls.Add(this.editObjectBtn);
            this.Controls.Add(this.addObjectBtn);
            this.Controls.Add(this.rentObjectTypesView);
            this.Controls.Add(this.rentObjectsView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Edit_rent_objects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit_rent_objects";
            this.Load += new System.EventHandler(this.Edit_rent_objects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rentObjectsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentObjectTypesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView rentObjectsView;
        private System.Windows.Forms.DataGridView rentObjectTypesView;
        private System.Windows.Forms.Button addObjectBtn;
        private System.Windows.Forms.Button editObjectBtn;
        private System.Windows.Forms.Button deleteObjectBtn;
        private System.Windows.Forms.Button deleteTypeBtn;
        private System.Windows.Forms.Button editTypeBtn;
        private System.Windows.Forms.Button addTypeBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}