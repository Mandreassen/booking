using System;
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

        private void button2_Click(object sender, EventArgs e)
        {
            manage_rent_objects form = new manage_rent_objects();
            form.ShowDialog(this);
            update_Tables();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new_booking form = new new_booking(-1);
            form.ShowDialog(this);
            update_Tables();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            appsettings form = new appsettings();
            form.ShowDialog();
        }

        private void manageBookingsButton_Click(object sender, EventArgs e)
        {
            Manage_bookings form = new Manage_bookings();
            form.ShowDialog(this);
            update_Tables();
        }



        private void checkinnButton_Click(object sender, EventArgs e)
        {
            Check_inn form = new Check_inn();
            form.ShowDialog();
            update_Tables();
        }

        private void update_Tables()
        {
            fill_ArrivalsTable();
            fill_DepartureTable();
            fill_CheckinnTable();
        }

        private void fill_CheckinnTable_old()
        {
            var query = "select rent_objects.Name as 'Object', Description as 'Type', customers.Name as 'User' from rent_object_types natural join rent_objects join customers on rent_objects.currentUser = customers.cid order by cid;";
            useTable.DataSource = Database.get_DataSet(query).Tables[0];
            useTable.AutoResizeColumns();
            useTable.ClearSelection();
        }


        private void fill_CheckinnTable()
        {
            /*var Data = Database.get_DataSet(string.Format(@"
                select rent_objects.name AS 'Object', description AS 'Type', customer.name AS 'Name', country AS 'Country', endDate AS 'Departure'
                from customers
                natural join bookings
                natural join booking_lines
                natural join booking_entries
                natural join rent_object_types
                natural join rent_objects

            "));*/
        }

        private void fill_ArrivalsTable()
        {
            var data = Database.get_DataSet(string.Format(@"
                select description AS 'Object', name AS 'Name', country AS 'Country' 
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


        private void fill_DepartureTable()
        {
            var data = Database.get_DataSet(string.Format(@"
                select description AS 'Object', name AS 'Name', country AS 'Country' 
                from customers
                natural join bookings
                natural join booking_lines
                natural join booking_entries
                natural join rent_object_types
                where endDate = '{0}'
                and blid in (select currentUser from rent_objects)
                group by blid;
                ", DateTime.Now.ToString("yyyy-MM-dd")));

            departureTable.DataSource = data.Tables[0];
            departureTable.AutoResizeColumns();
            departureTable.ClearSelection();
        }

        private void ready_rent_objects_button_Click(object sender, EventArgs e)
        {
            Ready_rent_objects form = new Ready_rent_objects();
            form.ShowDialog();            
        }

        private void editRoBtn_Click(object sender, EventArgs e)
        {
            Edit_rent_objects form = new Edit_rent_objects();
            form.ShowDialog();
        }

        private void arrival_button_Click(object sender, EventArgs e)
        {
            Report.arrivals();
        }
    }
}
