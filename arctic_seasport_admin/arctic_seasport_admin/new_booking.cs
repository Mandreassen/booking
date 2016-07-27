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
    public partial class new_booking : Form
    {
        private int bid;
        private DataTable booked;
        private bool done, edit;
        private string collumnFormat;


        /* INIT */
        public new_booking(int selected_bid)
        {
            InitializeComponent();
            edit = false;
            bid = selected_bid;
            if (bid > 0)
            {
                edit = true;
                button4.Text = "DELETE BOOKING";
                fill_BookingLineTable();
            }

            done = false;
            collumnFormat = "   ddd dd.MM";
            init_Booked();            
        }


        private void init_Booked()
        {
            booked = new DataTable();
            var column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Booked";
            booked.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "From";
            booked.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "To";
            booked.Columns.Add(column);
        }


        /* Used by dialog form to 
         * trigger this form to close
         * at given conditions*/
        public void set_Done()
        {
            done = true;
        }


        private void new_booking_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker2.Value.AddDays(1.0);
            fill_Overview();            
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //if (dateTimePicker1.Value.Date >= dateTimePicker2.Value.Date)
            //{
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
            //}

            fill_Overview();
        }



        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value.Date <= dateTimePicker1.Value.Date)
            {
                dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-1);
            }

            fill_Overview();
        }


        /* Create new Booking with default customer */
        private int create_Booking()
        {
            var query = string.Format("insert into bookings values (NULL, {0}, '{1}', NULL, NULL, NULL, '{2}');select last_insert_id();", Database.DEFAULT_CUSTOMER.ToString(), DateTime.Now.ToString("yyyy-MM-dd"), Properties.Settings.Default.company);
            string newBID = Database.get_Value(query);
            if (newBID == null)
                return -1;
            
            return System.Int32.Parse(newBID);
        }


        /* Get a list all dates selected */
        private List<DateTime> get_Dates()
        {
            List<DateTime> list = new List<DateTime>();

            DateTime selected = dateTimePicker1.Value;

            do
            {
                list.Add(selected);
                selected = selected.AddDays(1);
            } while (selected < dateTimePicker2.Value);
            
            return list;
        }


        private void fill_Overview()
        {
            Cursor.Current = Cursors.WaitCursor;
            Database_adapter db = new Database_adapter();
            dataGridView1.DataSource = null;
            var dates = get_Dates();
            var types = db.get_Dict("select Description, count(roID) from rent_objects natural join rent_object_types group by roID;");

            if (dates == null || types == null)
            {
                MessageBox.Show("Value error.");
                Cursor.Current = Cursors.Default;
                return;
            }

            DataTable table = new DataTable();

            foreach (var type in types)
            {
                var row = table.NewRow();
                table.Rows.Add(row);
            }

            foreach (var date in dates)
            {
                var column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = date.ToString(collumnFormat);
                table.Columns.Add(column);

                var booked = db.get_Dict(string.Format("select Description, count(roID) from booking_entries natural join rent_object_types where date = \'{0}\' group by Description;", date.ToString("yyyy-MM-dd")));

                var i = 0;
                foreach (KeyValuePair<string, string> entry in types)
                {
                    if (booked.ContainsKey(entry.Key))
                    {
                        var booked_count = booked[entry.Key];
                        table.Rows[i][date.ToString(collumnFormat)] = Int32.Parse(entry.Value) - Int32.Parse(booked_count);
                    }
                    else
                    {
                        table.Rows[i][date.ToString(collumnFormat)] = Int32.Parse(entry.Value);
                    }
                    i++;
                }
                
            }

            db.close();
            dataGridView1.DataSource = table;

            var all_types = types.GetEnumerator();            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                all_types.MoveNext();
                row.HeaderCell.Value = all_types.Current.Key;                
            }
            
            // Set not sortable
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }           

            dataGridView1.AutoResizeColumns();
            dataGridView1.RowHeadersWidth = 200;
            dataGridView1.ClearSelection();
            dataGridView1.Show();
            Cursor.Current = Cursors.Default;
        }


        /* Get selected Rent Object type from overview */
        private string get_Selected_Type()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                return selectedRow.HeaderCell.Value.ToString(); // Success
            }

            return null; // Error
        }


        /* Add Booking line into Database */
        private void add_BookingLine()
        {
            // Get type from Overview 
            string type = get_Selected_Type();
            if (type == null)
            {
                MessageBox.Show("No item selected...");
                return;
            }

            // Transelate type into Rent Object ID
            string roID = Database.get_Value("select roID from rent_object_types where Description = \"" + type + "\";");
            if (roID == null)
                return;

            if (bid < 0)
            {
                bid = create_Booking();
                if (bid < 0)
                {
                    MessageBox.Show("Could not create booking.");
                    return;
                }
            }

            // Get selected dates
            var dates = get_Dates();

            // Validate dates
            int idx = dataGridView1.SelectedCells[0].RowIndex;
            foreach (var date in dates)
            {
                var val = dataGridView1.Rows[idx].Cells[date.ToString(collumnFormat)].Value.ToString();
                if (UInt32.Parse(val) <= 0)
                {
                    MessageBox.Show(string.Format("{0} is not available in the selected period.", type));
                    return;
                }
            }
            
            var success = Database.book_dates(dates, bid.ToString(), roID);
            if (!success)
                MessageBox.Show("Database error, object not available.");

            // Refresh tables
            fill_BookingLineTable();
            fill_Overview();
        }


        private bool cancel()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel this booking?", "Cancel?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return false;

            Cursor.Current = Cursors.WaitCursor;

            var adapter = new Database_adapter();

            var blidList = adapter.get_List(string.Format("select blid from booking_lines where bid = {0};", bid));
            foreach (string blid in blidList)
            {
                adapter.set(string.Format("delete from booking_entries where blid = {0};", blid));

                // Check out
                var checkedObjects = adapter.get_List(string.Format("select name from rent_objects where currentUser = {0};", blid));
                foreach (string name in checkedObjects)
                {
                    adapter.set(string.Format("update rent_objects set currentUser = 0 where name = '{0}';", name));
                }
            }

            adapter.set(string.Format("delete from booking_lines where bid = {0};", bid));
            adapter.set(string.Format("delete from bookings where bid = {0};", bid));
            adapter.set(string.Format("delete from transfers where bid = {0};", bid));
            adapter.set(string.Format("delete from alerts where bid = {0};", bid));

            adapter.close();

            Cursor.Current = Cursors.Default;

            return true;
        }


        /* Cancel/Delete button click */
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /* Next button click */
        private void button3_Click(object sender, EventArgs e)
        {
            if (bid < 0)
            {
                MessageBox.Show("No reservations has been made...");
                return;
            }

            string data = Database.get_Value("select cid from bookings where bid=" + bid.ToString() + ";");
            if (data == null)
                return;

            int cid = System.Int32.Parse(data);
            if (cid < 1)
                return;

            New_customer form = new New_customer(bid, cid, this);

            form.ShowDialog(this);

            if (done)
                this.Close();
        }


        /* Add button click */
        private void button2_Click(object sender, EventArgs e)
        {
            add_BookingLine();
        }


        /* Double click in Booking overview */
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            add_BookingLine();
            Cursor.Current = Cursors.Default;
        }


        /* Get Booking Line ID selected in Booked table. */
        private string get_SelectedBlid()
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];

                return selectedRow.Cells["blid"].Value.ToString();
            }

            return null; // Error
        }


        /* Remove button clicked */
        private void removeButton_Click(object sender, EventArgs e)
        {
            string blid = get_SelectedBlid();
            if (blid != null)
            {
                Database.set("delete from booking_entries where blid = " + blid + ";");
                Database.set("delete from booking_lines where blid = " + blid + ";");
            }
            fill_BookingLineTable();
            fill_Overview();
        }

        private void new_booking_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bid > 0 && !edit && !done)
            {
                if (!cancel())
                {
                    e.Cancel = true;
                }                    
            }
        }


        /* Fill data in Booking Line Table */
        private void fill_BookingLineTable()
        {
            DataSet ds = Database.get_DataSet("select blid, description AS 'Description', startDate AS 'From', endDate AS 'To' from booking_lines natural join booking_entries natural join rent_object_types where bid = " + bid.ToString() + " group by blid;");

            dataGridView2.DataSource = ds.Tables[0];

            dataGridView2.Columns["blid"].Visible = false;
            dataGridView2.AutoResizeColumns();
            dataGridView2.ClearSelection();
            dataGridView2.Show();
        }
    }
}
