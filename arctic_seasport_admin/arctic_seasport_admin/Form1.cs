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
            button3.Visible = false;

            var pos = this.PointToScreen(alertCount.Location);
            pos = alertButton.PointToClient(pos);
            alertCount.Parent = alertButton;
            alertCount.Location = pos;
            alertCount.BackColor = Color.Transparent;

            remove_ButtonBorder(upcomingButton);
            remove_ButtonBorder(button3);
            remove_ButtonBorder(button1);
            remove_ButtonBorder(checkinnButton);
            remove_ButtonBorder(manageBookingsButton);
            remove_ButtonBorder(ready_rent_objects_button);
            remove_ButtonBorder(arrival_button);
            remove_ButtonBorder(editRoBtn);
            remove_ButtonBorder(depatures);
            remove_ButtonBorder(transferButton);
            remove_ButtonBorder(hotelStatisticsButton);
            remove_ButtonBorder(alertButton);
            update_Tables();

            Timer timer = new Timer();
            timer.Interval = (12000 * 1000); // 20min
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            update_Tables();
        }

        private void remove_ButtonBorder(Button button)
        {
            button.TabStop = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
        }

        /* Update */
        private void update_Tables()
        {
            Cursor.Current = Cursors.WaitCursor;
            var adapter = new Database_adapter();
            fill_ArrivalsTable(adapter);
            fill_DepartureTable(adapter);
            fill_CheckinnTable(adapter);
            check_Alert(adapter);
            adapter.close();
            Cursor.Current = Cursors.Default;
            
        }

        private void check_Alert(Database_adapter adapter)
        {
            string data = adapter.get_Value("select count(aid) from alerts;");
            alertCount.Text = data;

            int num = Int32.Parse(data);

            if (num > 0)
            {
                alertCount.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                alertCount.ForeColor = System.Drawing.Color.Black;
            }
        }

        /* Fill arrivals table whith todays arrivals */
        private void fill_ArrivalsTable(Database_adapter adapter)
        {
            var data = adapter.get_DataSet(string.Format(@"
                select blid, description AS 'Object', name AS 'Customer', count(beid) AS 'Days', country AS 'Country' , DATE_FORMAT(arrivalTime, '%k:%i') AS 'Transfer'
                from customers
                natural join bookings            
                natural join booking_lines
                natural join booking_entries
                natural join rent_object_types 
                left outer join transfers on bookings.bid = transfers.bid                             
                where startDate = '{0}'
                and blid not in (select currentUser from rent_objects)
                group by blid;
                ", DateTime.Now.ToString("yyyy-MM-dd")));

            arrivalsTable.DataSource = data.Tables[0];
            arrivalsTable.Columns[0].Visible = false;
            arrivalsTable.AutoResizeColumns();
            arrivalsTable.ClearSelection();
        }

        /* Fill departure table with todays departures */
        private void fill_DepartureTable(Database_adapter adapter)
        {
            var data = adapter.get_DataSet(string.Format(@"
                select rent_objects.name AS 'Object', description AS 'Type', customers.Name as 'Customer', DATE_FORMAT(departureTime, '%k:%i') AS 'Transfer'
                from rent_object_types
                natural join rent_objects
                join (booking_lines 
                    natural join bookings
                    natural join customers)
                on rent_objects.currentUser = booking_lines.blid
                left outer join transfers on bookings.bid = transfers.bid 
                where currentUser != 0
                and endDate = '{0}'                
            ;", DateTime.Now.ToString("yyyy-MM-dd")));

            departureTable.DataSource = data.Tables[0];
            departureTable.AutoResizeColumns();
            departureTable.ClearSelection();
        }

        /* Fill Checked in table */
        private void fill_CheckinnTable(Database_adapter adapter)
        {
            var checkedIn = adapter.get_DataSet(string.Format(@"
                select bid AS 'ID', customers.Name as 'User', DATE_FORMAT(startDate, '%d. %m') AS 'From', DATE_FORMAT(endDate, '%d. %m') AS 'To', description AS 'Type', rent_objects.name AS 'Object', country AS 'Country' 
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


        /* Get number of days to show in arrival and deapature reports */
        private int get_number_of_days()
        {
            var selector = new Number_of_days_selector();
            selector.ShowDialog();

            return selector.count;
        }


        /* Show arrival list */
        private void arrival_button_Click(object sender, EventArgs e)
        {
            var numberOfDays = get_number_of_days();
            if (numberOfDays == -1)
                return;

            var report = Report.arrivals(numberOfDays);
            var viewer = new ReportViewer(report, 900);
            viewer.ShowDialog();
        }

        /* Show departure list */
        private void depatures_Click(object sender, EventArgs e)
        {
            var numberOfDays = get_number_of_days();
            if (numberOfDays == -1)
                return;

            var report = Report.departures(numberOfDays);
            var viewer = new ReportViewer(report, 900);
            viewer.ShowDialog();
        }

        /* Show booking confermation on selected customer in checked in table */
        private void useTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = useTable.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = useTable.Rows[selectedrowindex];

            string bid = selectedRow.Cells[0].Value.ToString();

            var report = Report.booking_Confirmation(Int32.Parse(bid));
            var viewer = new ReportViewer(report);
            viewer.ShowDialog();
        }

        /* Fast check in */
        private void arrivalsTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = arrivalsTable.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = arrivalsTable.Rows[selectedrowindex];

            string blid = selectedRow.Cells[0].Value.ToString();

            var form = new Fast_check_in(blid);

            form.ShowDialog();

            update_Tables();
        }

        /* Fast check out */
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

        private void transferButton_Click(object sender, EventArgs e)
        {
            var report = Report.transfers();
            var view = new ReportViewer(report);
            view.ShowDialog();
        }

        private void hotelStatisticsButton_Click(object sender, EventArgs e)
        {
            var form = new Hotel_statistics();
            form.ShowDialog();
        }

        private void alertButton_Click(object sender, EventArgs e)
        {
            var form = new Alerts();
            form.ShowDialog();
            update_Tables();
        }

        private void upcomingButton_Click(object sender, EventArgs e)
        {
            var report = Report.upcoming_Bookings();
            var view = new ReportViewer(report, 1366);
            view.ShowDialog();            
        }
    }
}
