namespace arctic_seasport_admin
{
    partial class Transfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transfer));
            this.arrivalTime = new System.Windows.Forms.DateTimePicker();
            this.departureTime = new System.Windows.Forms.DateTimePicker();
            this.arrivalDate = new System.Windows.Forms.DateTimePicker();
            this.departureDate = new System.Windows.Forms.DateTimePicker();
            this.arrivalLabel = new System.Windows.Forms.Label();
            this.departureLabel = new System.Windows.Forms.Label();
            this.arrivalFlight = new System.Windows.Forms.TextBox();
            this.departureFlight = new System.Windows.Forms.TextBox();
            this.Header = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.both = new System.Windows.Forms.RadioButton();
            this.arrivalOnly = new System.Windows.Forms.RadioButton();
            this.departureOnly = new System.Windows.Forms.RadioButton();
            this.personsBox = new System.Windows.Forms.TextBox();
            this.personsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // arrivalTime
            // 
            this.arrivalTime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.arrivalTime.Location = new System.Drawing.Point(218, 116);
            this.arrivalTime.Name = "arrivalTime";
            this.arrivalTime.ShowUpDown = true;
            this.arrivalTime.Size = new System.Drawing.Size(77, 24);
            this.arrivalTime.TabIndex = 0;
            // 
            // departureTime
            // 
            this.departureTime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.departureTime.Location = new System.Drawing.Point(218, 189);
            this.departureTime.Name = "departureTime";
            this.departureTime.ShowUpDown = true;
            this.departureTime.Size = new System.Drawing.Size(77, 24);
            this.departureTime.TabIndex = 1;
            // 
            // arrivalDate
            // 
            this.arrivalDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalDate.Location = new System.Drawing.Point(12, 116);
            this.arrivalDate.Name = "arrivalDate";
            this.arrivalDate.Size = new System.Drawing.Size(200, 24);
            this.arrivalDate.TabIndex = 2;
            this.arrivalDate.ValueChanged += new System.EventHandler(this.arrivalDate_ValueChanged);
            // 
            // departureDate
            // 
            this.departureDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureDate.Location = new System.Drawing.Point(12, 189);
            this.departureDate.Name = "departureDate";
            this.departureDate.Size = new System.Drawing.Size(200, 24);
            this.departureDate.TabIndex = 3;
            // 
            // arrivalLabel
            // 
            this.arrivalLabel.AutoSize = true;
            this.arrivalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalLabel.Location = new System.Drawing.Point(12, 93);
            this.arrivalLabel.Name = "arrivalLabel";
            this.arrivalLabel.Size = new System.Drawing.Size(52, 20);
            this.arrivalLabel.TabIndex = 4;
            this.arrivalLabel.Text = "Arrival";
            // 
            // departureLabel
            // 
            this.departureLabel.AutoSize = true;
            this.departureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureLabel.Location = new System.Drawing.Point(8, 166);
            this.departureLabel.Name = "departureLabel";
            this.departureLabel.Size = new System.Drawing.Size(81, 20);
            this.departureLabel.TabIndex = 5;
            this.departureLabel.Text = "Departure";
            // 
            // arrivalFlight
            // 
            this.arrivalFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalFlight.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.arrivalFlight.Location = new System.Drawing.Point(315, 116);
            this.arrivalFlight.Name = "arrivalFlight";
            this.arrivalFlight.Size = new System.Drawing.Size(116, 24);
            this.arrivalFlight.TabIndex = 6;
            this.arrivalFlight.Text = "Arrival flight";
            this.arrivalFlight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.arrivalFlight.Enter += new System.EventHandler(this.arrivalFlight_Enter);
            this.arrivalFlight.Leave += new System.EventHandler(this.arrivalFlight_Leave);
            // 
            // departureFlight
            // 
            this.departureFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureFlight.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.departureFlight.Location = new System.Drawing.Point(315, 189);
            this.departureFlight.Name = "departureFlight";
            this.departureFlight.Size = new System.Drawing.Size(116, 24);
            this.departureFlight.TabIndex = 7;
            this.departureFlight.Text = "Departure flight";
            this.departureFlight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.departureFlight.Enter += new System.EventHandler(this.departureFlight_Enter);
            this.departureFlight.Leave += new System.EventHandler(this.departureFlight_Leave);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.Location = new System.Drawing.Point(12, 9);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(205, 25);
            this.Header.TabIndex = 8;
            this.Header.Text = "Transfer for booking";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.Window;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(176, 233);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(93, 33);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // both
            // 
            this.both.AutoSize = true;
            this.both.Checked = true;
            this.both.Location = new System.Drawing.Point(17, 55);
            this.both.Name = "both";
            this.both.Size = new System.Drawing.Size(47, 17);
            this.both.TabIndex = 10;
            this.both.TabStop = true;
            this.both.Text = "Both";
            this.both.UseVisualStyleBackColor = true;
            this.both.CheckedChanged += new System.EventHandler(this.both_CheckedChanged);
            // 
            // arrivalOnly
            // 
            this.arrivalOnly.AutoSize = true;
            this.arrivalOnly.Location = new System.Drawing.Point(70, 55);
            this.arrivalOnly.Name = "arrivalOnly";
            this.arrivalOnly.Size = new System.Drawing.Size(54, 17);
            this.arrivalOnly.TabIndex = 11;
            this.arrivalOnly.Text = "Arrival";
            this.arrivalOnly.UseVisualStyleBackColor = true;
            this.arrivalOnly.CheckedChanged += new System.EventHandler(this.arrivalOnly_CheckedChanged);
            // 
            // departureOnly
            // 
            this.departureOnly.AutoSize = true;
            this.departureOnly.Location = new System.Drawing.Point(130, 55);
            this.departureOnly.Name = "departureOnly";
            this.departureOnly.Size = new System.Drawing.Size(72, 17);
            this.departureOnly.TabIndex = 12;
            this.departureOnly.Text = "Departure";
            this.departureOnly.UseVisualStyleBackColor = true;
            this.departureOnly.CheckedChanged += new System.EventHandler(this.departureOnly_CheckedChanged);
            // 
            // personsBox
            // 
            this.personsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personsBox.Location = new System.Drawing.Point(385, 55);
            this.personsBox.Name = "personsBox";
            this.personsBox.Size = new System.Drawing.Size(46, 24);
            this.personsBox.TabIndex = 13;
            this.personsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // personsLabel
            // 
            this.personsLabel.AutoSize = true;
            this.personsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personsLabel.Location = new System.Drawing.Point(311, 57);
            this.personsLabel.Name = "personsLabel";
            this.personsLabel.Size = new System.Drawing.Size(67, 20);
            this.personsLabel.TabIndex = 14;
            this.personsLabel.Text = "Persons";
            // 
            // Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(443, 283);
            this.Controls.Add(this.personsLabel);
            this.Controls.Add(this.personsBox);
            this.Controls.Add(this.departureOnly);
            this.Controls.Add(this.arrivalOnly);
            this.Controls.Add(this.both);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.departureFlight);
            this.Controls.Add(this.arrivalFlight);
            this.Controls.Add(this.departureLabel);
            this.Controls.Add(this.arrivalLabel);
            this.Controls.Add(this.departureDate);
            this.Controls.Add(this.arrivalDate);
            this.Controls.Add(this.departureTime);
            this.Controls.Add(this.arrivalTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Transfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker arrivalTime;
        private System.Windows.Forms.DateTimePicker departureTime;
        private System.Windows.Forms.DateTimePicker arrivalDate;
        private System.Windows.Forms.DateTimePicker departureDate;
        private System.Windows.Forms.Label arrivalLabel;
        private System.Windows.Forms.Label departureLabel;
        private System.Windows.Forms.TextBox arrivalFlight;
        private System.Windows.Forms.TextBox departureFlight;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.RadioButton both;
        private System.Windows.Forms.RadioButton arrivalOnly;
        private System.Windows.Forms.RadioButton departureOnly;
        private System.Windows.Forms.TextBox personsBox;
        private System.Windows.Forms.Label personsLabel;
    }
}