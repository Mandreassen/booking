namespace arctic_seasport_admin
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.manageBookingsButton = new System.Windows.Forms.Button();
            this.checkinnButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.useTable = new System.Windows.Forms.DataGridView();
            this.arrivalsTable = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.ready_rent_objects_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.departureTable = new System.Windows.Forms.DataGridView();
            this.editRoBtn = new System.Windows.Forms.Button();
            this.arrival_button = new System.Windows.Forms.Button();
            this.depatures = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.useTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureTable)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(13, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "New booking";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 68);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Window;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1120, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 38);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // manageBookingsButton
            // 
            this.manageBookingsButton.BackColor = System.Drawing.SystemColors.Window;
            this.manageBookingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageBookingsButton.Location = new System.Drawing.Point(13, 279);
            this.manageBookingsButton.Name = "manageBookingsButton";
            this.manageBookingsButton.Size = new System.Drawing.Size(200, 38);
            this.manageBookingsButton.TabIndex = 8;
            this.manageBookingsButton.Text = "Edit bookings";
            this.manageBookingsButton.UseVisualStyleBackColor = false;
            this.manageBookingsButton.Click += new System.EventHandler(this.manageBookingsButton_Click);
            // 
            // checkinnButton
            // 
            this.checkinnButton.BackColor = System.Drawing.SystemColors.Window;
            this.checkinnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkinnButton.Location = new System.Drawing.Point(13, 167);
            this.checkinnButton.Name = "checkinnButton";
            this.checkinnButton.Size = new System.Drawing.Size(200, 38);
            this.checkinnButton.TabIndex = 9;
            this.checkinnButton.Text = "Check in/out";
            this.checkinnButton.UseVisualStyleBackColor = false;
            this.checkinnButton.Click += new System.EventHandler(this.checkinnButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "Checked in";
            // 
            // useTable
            // 
            this.useTable.AllowUserToAddRows = false;
            this.useTable.AllowUserToDeleteRows = false;
            this.useTable.AllowUserToResizeColumns = false;
            this.useTable.AllowUserToResizeRows = false;
            this.useTable.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.useTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.useTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.useTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.useTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.useTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.useTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.useTable.EnableHeadersVisualStyles = false;
            this.useTable.GridColor = System.Drawing.SystemColors.ControlLight;
            this.useTable.Location = new System.Drawing.Point(244, 99);
            this.useTable.Name = "useTable";
            this.useTable.ReadOnly = true;
            this.useTable.RowHeadersVisible = false;
            this.useTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.useTable.Size = new System.Drawing.Size(563, 404);
            this.useTable.TabIndex = 28;
            this.useTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.useTable_CellDoubleClick);
            // 
            // arrivalsTable
            // 
            this.arrivalsTable.AllowUserToAddRows = false;
            this.arrivalsTable.AllowUserToDeleteRows = false;
            this.arrivalsTable.AllowUserToResizeColumns = false;
            this.arrivalsTable.AllowUserToResizeRows = false;
            this.arrivalsTable.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.arrivalsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.arrivalsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.arrivalsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.arrivalsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.arrivalsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.arrivalsTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.arrivalsTable.EnableHeadersVisualStyles = false;
            this.arrivalsTable.GridColor = System.Drawing.SystemColors.ControlLight;
            this.arrivalsTable.Location = new System.Drawing.Point(837, 99);
            this.arrivalsTable.Name = "arrivalsTable";
            this.arrivalsTable.ReadOnly = true;
            this.arrivalsTable.RowHeadersVisible = false;
            this.arrivalsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.arrivalsTable.Size = new System.Drawing.Size(325, 180);
            this.arrivalsTable.TabIndex = 30;
            this.arrivalsTable.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.arrivalsTable_CellContentDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(833, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 24);
            this.label2.TabIndex = 31;
            this.label2.Text = "Today\'s arrivals";
            // 
            // ready_rent_objects_button
            // 
            this.ready_rent_objects_button.BackColor = System.Drawing.SystemColors.Window;
            this.ready_rent_objects_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ready_rent_objects_button.Location = new System.Drawing.Point(13, 211);
            this.ready_rent_objects_button.Name = "ready_rent_objects_button";
            this.ready_rent_objects_button.Size = new System.Drawing.Size(200, 38);
            this.ready_rent_objects_button.TabIndex = 32;
            this.ready_rent_objects_button.Text = "Rent object status";
            this.ready_rent_objects_button.UseVisualStyleBackColor = false;
            this.ready_rent_objects_button.Click += new System.EventHandler(this.ready_rent_objects_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(833, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 24);
            this.label3.TabIndex = 34;
            this.label3.Text = "Today\'s departures";
            // 
            // departureTable
            // 
            this.departureTable.AllowUserToAddRows = false;
            this.departureTable.AllowUserToDeleteRows = false;
            this.departureTable.AllowUserToResizeColumns = false;
            this.departureTable.AllowUserToResizeRows = false;
            this.departureTable.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.departureTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.departureTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.departureTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.departureTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.departureTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.departureTable.DefaultCellStyle = dataGridViewCellStyle6;
            this.departureTable.EnableHeadersVisualStyles = false;
            this.departureTable.GridColor = System.Drawing.SystemColors.ControlLight;
            this.departureTable.Location = new System.Drawing.Point(837, 323);
            this.departureTable.Name = "departureTable";
            this.departureTable.ReadOnly = true;
            this.departureTable.RowHeadersVisible = false;
            this.departureTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.departureTable.Size = new System.Drawing.Size(325, 180);
            this.departureTable.TabIndex = 35;
            this.departureTable.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.departureTable_CellContentDoubleClick);
            // 
            // editRoBtn
            // 
            this.editRoBtn.BackColor = System.Drawing.SystemColors.Window;
            this.editRoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editRoBtn.Location = new System.Drawing.Point(12, 323);
            this.editRoBtn.Name = "editRoBtn";
            this.editRoBtn.Size = new System.Drawing.Size(201, 38);
            this.editRoBtn.TabIndex = 36;
            this.editRoBtn.Text = "Edit rent objects";
            this.editRoBtn.UseVisualStyleBackColor = false;
            this.editRoBtn.Click += new System.EventHandler(this.editRoBtn_Click);
            // 
            // arrival_button
            // 
            this.arrival_button.BackColor = System.Drawing.SystemColors.Window;
            this.arrival_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrival_button.Location = new System.Drawing.Point(244, 12);
            this.arrival_button.Name = "arrival_button";
            this.arrival_button.Size = new System.Drawing.Size(114, 38);
            this.arrival_button.TabIndex = 37;
            this.arrival_button.Text = "Arrival list";
            this.arrival_button.UseVisualStyleBackColor = false;
            this.arrival_button.Click += new System.EventHandler(this.arrival_button_Click);
            // 
            // depatures
            // 
            this.depatures.BackColor = System.Drawing.SystemColors.Window;
            this.depatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depatures.Location = new System.Drawing.Point(381, 12);
            this.depatures.Name = "depatures";
            this.depatures.Size = new System.Drawing.Size(114, 38);
            this.depatures.TabIndex = 38;
            this.depatures.Text = "Depature list";
            this.depatures.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1178, 522);
            this.Controls.Add(this.depatures);
            this.Controls.Add(this.arrival_button);
            this.Controls.Add(this.editRoBtn);
            this.Controls.Add(this.departureTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ready_rent_objects_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.arrivalsTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.useTable);
            this.Controls.Add(this.checkinnButton);
            this.Controls.Add(this.manageBookingsButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arctic Seasport booking admin";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.useTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button manageBookingsButton;
        private System.Windows.Forms.Button checkinnButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView useTable;
        private System.Windows.Forms.DataGridView arrivalsTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ready_rent_objects_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView departureTable;
        private System.Windows.Forms.Button editRoBtn;
        private System.Windows.Forms.Button arrival_button;
        private System.Windows.Forms.Button depatures;
    }
}

