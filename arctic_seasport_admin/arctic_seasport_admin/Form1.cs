﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arctic_seasport_admin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            update_Tables();
        }

        /* Update */
        private void update_Tables()
        {
            fill_ArrivalsTable();
            fill_DepartureTable();
            fill_CheckinnTable();
        }

        /* Fill arrivals table whith todays arrivals */
        private void fill_ArrivalsTable()
        {
            var data = Database.get_DataSet(string.Format(@"
                select blid, description AS 'Object', name AS 'Name', country AS 'Country' 
                from customers
                natural join bookings
                natural join booking_lines
                natural join booking_entries
                natural join rent_object_types
                where startDate = '{0}'
                and blid not in (select currentUser from rent_objects)
                group by blid;
                ", DateTime.Now.ToString("yyyy-MM-dd")));

            arrivalsTable.DataSource = data.Tables[0];
            arrivalsTable.AutoResizeColumns();
            arrivalsTable.ClearSelection();
        }

        /* Fill departure table with todays departures */
        private void fill_DepartureTable()
        {
            var data = Database.get_DataSet(string.Format(@"
                select rent_objects.name AS 'Object', description AS 'Type', customers.Name as 'User'
                from rent_object_types
                natural join rent_objects
                join (booking_lines 
                    natural join bookings
                    natural join customers)
                on rent_objects.currentUser = booking_lines.blid
                where currentUser != 0
                and endDate = '{0}'
                ;
            ", DateTime.Now.ToString("yyyy-MM-dd")));

            departureTable.DataSource = data.Tables[0];
            departureTable.AutoResizeColumns();
            departureTable.ClearSelection();
        }

        /* Fill Checked in table */
        private void fill_CheckinnTable()
        {
            var checkedIn = Database.get_DataSet(string.Format(@"
                select bid AS 'BID', customers.Name as 'User', country AS 'Country', endDate AS 'Departure', rent_objects.name AS 'Object', description AS 'Type'
                from rent_object_types
                natural join rent_objects
                join (booking_lines 
                    natural join bookings
                    natural join customers)
                on rent_objects.currentUser = booking_lines.blid
                where currentUser != 0
                ;"));

            useTable.DataSource = checkedIn.Tables[0];
            useTable.AutoResizeColumns();
            useTable.ClearSelection();
        }

        /* New booking */
        private void button1_Click(object sender, EventArgs e)
        {
            new_booking form = new new_booking(-1);
            form.ShowDialog(this);
            update_Tables();
        }

        /* Settings */
        private void button3_Click(object sender, EventArgs e)
        {
            appsettings form = new appsettings();
            form.ShowDialog();
        }

        /* Edit bookings */
        private void manageBookingsButton_Click(object sender, EventArgs e)
        {
            Manage_bookings form = new Manage_bookings();
            form.ShowDialog(this);
            update_Tables();
        }

        /* Check in/out */
        private void checkinnButton_Click(object sender, EventArgs e)
        {
            Check_inn form = new Check_inn();
            form.ShowDialog();
            update_Tables();
        }
        

        
        /* Rent object status (ready/not ready-rent_objects) */
        private void ready_rent_objects_button_Click(object sender, EventArgs e)
        {
            Ready_rent_objects form = new Ready_rent_objects();
            form.ShowDialog();            
        }

        /* Edit rent_objects */
        private void editRoBtn_Click(object sender, EventArgs e)
        {
            Edit_rent_objects form = new Edit_rent_objects();
            form.ShowDialog();
        }

        private void arrival_button_Click(object sender, EventArgs e)
        {
            Report.arrivals();
        }

        private void useTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = useTable.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = useTable.Rows[selectedrowindex];

            string bid = selectedRow.Cells[0].Value.ToString();

            Report.new_Booking(Int32.Parse(bid));
        }

        private void arrivalsTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = arrivalsTable.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = arrivalsTable.Rows[selectedrowindex];

            string blid = selectedRow.Cells[0].Value.ToString();

            var form = new Fast_check_in(blid);

            form.ShowDialog();

            update_Tables();
        }

        private void departureTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = departureTable.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = departureTable.Rows[selectedrowindex];

            string obj = selectedRow.Cells[0].Value.ToString();

            DialogResult dialogResult = MessageBox.Show(string.Format("Check out {0}?", obj), obj, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            var status = "Ready";
            dialogResult = MessageBox.Show(string.Format("Do you want to mark {0} as ready?", obj), obj, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                status = "Not ready";

            var query = string.Format("update rent_objects set currentUser = 0, status = '{0}' where name = '{1}';", status, obj);
            Database.set(query);

            update_Tables();
        }
    }
}
