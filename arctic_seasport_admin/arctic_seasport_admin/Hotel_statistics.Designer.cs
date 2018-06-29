namespace arctic_seasport_admin
{
    partial class Hotel_statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hotel_statistics));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.numAccom = new System.Windows.Forms.TextBox();
            this.totalGuests = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.arrivingBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.arrivingNorway = new System.Windows.Forms.TextBox();
            this.monthUp = new System.Windows.Forms.Button();
            this.monthDown = new System.Windows.Forms.Button();
            this.yearUp = new System.Windows.Forms.Button();
            this.yearDown = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.CustomFormat = "dd               MMMM     yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(-55, 46);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(385, 29);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.AllowUserToResizeColumns = false;
            this.dataView.AllowUserToResizeRows = false;
            this.dataView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataView.Location = new System.Drawing.Point(33, 307);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.RowHeadersVisible = false;
            this.dataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView.Size = new System.Drawing.Size(205, 299);
            this.dataView.TabIndex = 17;
            // 
            // numAccom
            // 
            this.numAccom.Cursor = System.Windows.Forms.Cursors.No;
            this.numAccom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAccom.Location = new System.Drawing.Point(175, 140);
            this.numAccom.Name = "numAccom";
            this.numAccom.ReadOnly = true;
            this.numAccom.Size = new System.Drawing.Size(68, 24);
            this.numAccom.TabIndex = 18;
            this.numAccom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalGuests
            // 
            this.totalGuests.Cursor = System.Windows.Forms.Cursors.No;
            this.totalGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalGuests.Location = new System.Drawing.Point(175, 168);
            this.totalGuests.Name = "totalGuests";
            this.totalGuests.ReadOnly = true;
            this.totalGuests.Size = new System.Drawing.Size(68, 24);
            this.totalGuests.TabIndex = 19;
            this.totalGuests.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Utleiedøgn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Gjestedøgn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Gjestedøgn pr. land";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Ankomster utland";
            // 
            // arrivingBox
            // 
            this.arrivingBox.Cursor = System.Windows.Forms.Cursors.No;
            this.arrivingBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivingBox.Location = new System.Drawing.Point(175, 208);
            this.arrivingBox.Name = "arrivingBox";
            this.arrivingBox.ReadOnly = true;
            this.arrivingBox.Size = new System.Drawing.Size(68, 24);
            this.arrivingBox.TabIndex = 23;
            this.arrivingBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Ankomster norge";
            // 
            // arrivingNorway
            // 
            this.arrivingNorway.Cursor = System.Windows.Forms.Cursors.No;
            this.arrivingNorway.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivingNorway.Location = new System.Drawing.Point(175, 235);
            this.arrivingNorway.Name = "arrivingNorway";
            this.arrivingNorway.ReadOnly = true;
            this.arrivingNorway.Size = new System.Drawing.Size(68, 24);
            this.arrivingNorway.TabIndex = 26;
            this.arrivingNorway.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // monthUp
            // 
            this.monthUp.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.monthUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.monthUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthUp.Image = ((System.Drawing.Image)(resources.GetObject("monthUp.Image")));
            this.monthUp.Location = new System.Drawing.Point(62, 6);
            this.monthUp.Name = "monthUp";
            this.monthUp.Size = new System.Drawing.Size(53, 37);
            this.monthUp.TabIndex = 27;
            this.monthUp.UseVisualStyleBackColor = false;
            this.monthUp.Click += new System.EventHandler(this.monthUp_Click);
            // 
            // monthDown
            // 
            this.monthDown.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.monthDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.monthDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthDown.Image = ((System.Drawing.Image)(resources.GetObject("monthDown.Image")));
            this.monthDown.Location = new System.Drawing.Point(62, 78);
            this.monthDown.Name = "monthDown";
            this.monthDown.Size = new System.Drawing.Size(53, 37);
            this.monthDown.TabIndex = 28;
            this.monthDown.UseVisualStyleBackColor = false;
            this.monthDown.Click += new System.EventHandler(this.monthDown_Click);
            // 
            // yearUp
            // 
            this.yearUp.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.yearUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yearUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearUp.Image = ((System.Drawing.Image)(resources.GetObject("yearUp.Image")));
            this.yearUp.Location = new System.Drawing.Point(152, 6);
            this.yearUp.Name = "yearUp";
            this.yearUp.Size = new System.Drawing.Size(53, 37);
            this.yearUp.TabIndex = 29;
            this.yearUp.UseVisualStyleBackColor = false;
            this.yearUp.Click += new System.EventHandler(this.yearUp_Click);
            // 
            // yearDown
            // 
            this.yearDown.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.yearDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yearDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearDown.Image = ((System.Drawing.Image)(resources.GetObject("yearDown.Image")));
            this.yearDown.Location = new System.Drawing.Point(152, 78);
            this.yearDown.Name = "yearDown";
            this.yearDown.Size = new System.Drawing.Size(53, 37);
            this.yearDown.TabIndex = 30;
            this.yearDown.UseVisualStyleBackColor = false;
            this.yearDown.Click += new System.EventHandler(this.yearDown_Click);
            // 
            // Hotel_statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(273, 625);
            this.Controls.Add(this.yearDown);
            this.Controls.Add(this.yearUp);
            this.Controls.Add(this.monthDown);
            this.Controls.Add(this.monthUp);
            this.Controls.Add(this.arrivingNorway);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.arrivingBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalGuests);
            this.Controls.Add(this.numAccom);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.dateTimePicker1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Hotel_statistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.Hotel_statistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.TextBox numAccom;
        private System.Windows.Forms.TextBox totalGuests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox arrivingBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox arrivingNorway;
        private System.Windows.Forms.Button monthUp;
        private System.Windows.Forms.Button monthDown;
        private System.Windows.Forms.Button yearUp;
        private System.Windows.Forms.Button yearDown;
    }
}