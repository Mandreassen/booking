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
    public partial class Manage_bookings : Form
    {
        enum STATE {
            UPCOMING,
            PREVIOUS,
            ALL            
        };

        STATE State;

        /* INIT */
        public Manage_bookings()
        {
            State = STATE.UPCOMING;            
            InitializeComponent();
        }


        /* Select query based on selected State. */
        private string select_StateQuery()
        {
            switch (State)
            {
                case STATE.UPCOMING:
                    return string.Format("select bid as 'Booking', Name, Country, min(Date) as 'Arrival Date' from booking_lines natural join bookings natural join customers where name like \'%{0}%\' group by bid having bid in (select bid from booking_lines where Date >= \'{1}\') order by min(Date);", searchBox.Text, System.DateTime.Now.ToString("yyyy-MM-dd"));
                case STATE.PREVIOUS:
                    return string.Format("select bid as 'Booking', Name, Country, min(Date) as 'Arrival Date' from booking_lines natural join bookings natural join customers where name like \'%{0}%\' group by bid having bid in (select bid from booking_lines where Date < \'{1}\') order by min(Date);", searchBox.Text, System.DateTime.Now.ToString("yyyy-MM-dd")); 
                case STATE.ALL:
                    return string.Format("select bid as 'Booking', Name, Country, min(Date) as 'Arrival Date' from booking_lines natural join bookings natural join customers where name like \'%{0}%\' group by bid order by min(Date);", searchBox.Text); 
                default:
                    return "";
            }
        }


        /* Fill Bookings table. */
        private void fill_Table()
        {
            bookingsView.DataSource = Database.get_DataSet( select_StateQuery() ).Tables[0];
            bookingsView.AutoResizeColumns();        
            bookingsView.ClearSelection();
        }


        /* Fill Bokking Line table. */
        private void fill_BookingLinesTable(string bid)
        {
            var query = string.Format("select Description, Date, Price from booking_lines natural join rent_object_types where bid = {0};", bid);
            detailsView.DataSource = Database.get_DataSet(query).Tables[0];
            detailsView.AutoResizeColumns();
            detailsView.ClearSelection();
        }


        /* Select Upcoming. */
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                State = STATE.UPCOMING;
                fill_Table();
            }
        }


        /* Select Previous. */
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                State = STATE.PREVIOUS;
                fill_Table();
            }                
        }


        /* Select All. */
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                State = STATE.ALL;
                fill_Table();
            }                
        }


        /* Get Booking ID selected in Bookings table. */
        private string get_SelectedBid()
        {
            if (bookingsView.SelectedCells.Count > 0)
            {
                int selectedrowindex = bookingsView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = bookingsView.Rows[selectedrowindex];

                return selectedRow.Cells["Booking"].Value.ToString();
            }

            return null; // Error
        }


        private void fill_sumBox(string bid)
        {
            var sum = Database.get_Value(string.Format("select sum(Price) from booking_lines natural join rent_object_types where bid = {0};", bid));
            sumBox.Text = string.Format("{0},- ", sum);
        }


        /* Booking selected
         * Update Booking Lines and Notes box  */
        private void bookingView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string bid = get_SelectedBid();
            if (bid == null)
                return; // Error

            fill_BookingLinesTable(bid);
            fill_sumBox(bid);
            var query = string.Format("select Notes from bookings where bid = {0};", bid);
            noteBox.Text = Database.get_Value(query);
        }


        /* Delete Booking */
        private void button2_Click(object sender, EventArgs e)
        {
            // Check selection
            if (bookingsView.SelectedCells.Count < 1)
            {
                MessageBox.Show("No valid selection.");
                return;
            }

            // Get selected row
            DataGridViewRow selectedRow = bookingsView.Rows[bookingsView.SelectedCells[0].RowIndex];

            // Get selected Booking ID
            string bid = selectedRow.Cells["Booking"].Value.ToString();

            // Ask user if data should be deleted
            DialogResult dialogResult = MessageBox.Show(string.Format("Are you sure you want to delete booking {0} ?", bid), "Delete?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            // Delete data
            Database.set(string.Format("delete from booking_lines where bid = {0};", bid));
            Database.set(string.Format("delete from bookings where bid = {0};", bid));

            // Udate table
            fill_Table();
        }


        /* Edit Booking */
        private void button1_Click(object sender, EventArgs e)
        {
            string bid = get_SelectedBid();
            if (bid == null)
                return; // Error

            new_booking form = new new_booking(System.Int32.Parse(bid));
            form.ShowDialog();
            fill_Table();
        }


        /* View booking */
        private void button3_Click(object sender, EventArgs e)
        {
            var bid = get_SelectedBid();
            if (bid == null)
            {
                MessageBox.Show("No item selected");
                return;
            }

            Report.new_Booking(System.Int32.Parse(bid));
        }


        /* Update result */
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            fill_Table();
        }


        /* Clear search box */
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
        }
    }
}
