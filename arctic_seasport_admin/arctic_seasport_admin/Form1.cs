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
            //Report.new_Booking(28);
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

        private void fill_CheckinnTable()
        {
            var query = "select rent_objects.Name as 'Object', Description as 'Type', customers.Name as 'User' from rent_object_types natural join rent_objects join customers on rent_objects.currentUser = customers.cid order by cid;";
            useTable.DataSource = Database.get_DataSet(query).Tables[0];
            useTable.AutoResizeColumns();
            useTable.ClearSelection();
        }

        private void fill_ArrivalsTable()
        {
            DataTable table = new DataTable();
            var column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            table.Columns.Add(column);


            var checkedIn = Database.get_Dict("select currentUser, count(currentUser) from rent_objects group by currentUser;");
            var ordered = Database.get_Dict(string.Format("select cid, count(cid) from bookings natural join booking_lines where date = \'{0}\' group by cid;", System.DateTime.Now.ToString("yyyy-MM-dd")));

            // Fint all ordered more than they have checkt in
            int i = 0;
            foreach (KeyValuePair<string, string> item in ordered)
            {
                if (checkedIn.ContainsKey(item.Key))
                {
                    if (Int32.Parse(item.Value) <= Int32.Parse(checkedIn[item.Key]))
                    {
                        continue; // Skip
                    }
                }

                var row = table.NewRow();
                table.Rows.Add(row);
                table.Rows[i][0] = Database.get_Value(string.Format("select concat(Name, '  ', country) from customers where cid = {0}", item.Key));
                i++;
            }

            arrivalsTable.DataSource = table;
            arrivalsTable.AutoResizeColumns();
            arrivalsTable.ClearSelection();


            /*
            var query = string.Format("select customers.Name, Country from customers natural join bookings natural join booking_lines natural join rent_object_types group by bid having min(booking_lines.Date) = \'{0}\';", System.DateTime.Now.ToString("yyyy-MM-dd"));
            arrivalsTable.DataSource = Database.get_DataSet(query).Tables[0];
            arrivalsTable.AutoResizeColumns();
            arrivalsTable.ClearSelection();
            */
        }


        private void fill_DepartureTable()
        {
            DateTime yesterday = System.DateTime.Now.AddDays(-1);

            var query = string.Format("select customers.Name, Country from customers natural join bookings natural join booking_lines natural join rent_object_types where customers.cid in (select currentUser from rent_objects) group by bid having max(booking_lines.Date) = \'{0}\';", yesterday.ToString("yyyy-MM-dd"));
            departureTable.DataSource = Database.get_DataSet(query).Tables[0];
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
    }
}
