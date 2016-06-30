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
    public partial class Transfers_view : Form
    {
        public Transfers_view()
        {
            InitializeComponent();
        }

        
        private void Transfers_view_Load(object sender, EventArgs e)
        {
            newButton.Visible = false;
            deleteButton.Visible = false;
            fill_Overview();
        }

        private void fill_Overview()
        {
            var data = Database.get_DataSet(string.Format(@"
                select bookings.bid AS 'BID', name AS 'Name', arrivalTime AS 'To', arrivalFlight AS 'Flight', departureTime AS 'Return', departureFlight AS 'Flight '
                from customers 
                natural join bookings
                natural join booking_lines
                left outer join transfers on transfers.bid = bookings.bid
                where endDate >= '{0}'
                and company = '{1}'
                group by bid;
                ", DateTime.Now.ToString("yyyy-MM-dd"), Properties.Settings.Default.company)
            );

            dataView.DataSource = data.Tables[0];
            dataView.AutoResizeColumns();
            dataView.ClearSelection();
            dataView.Show();

        }

        /* Get Booking ID selected in Bookings table. */
        private string get_SelectedBid()
        {
            if (dataView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataView.Rows[selectedrowindex];

                return selectedRow.Cells["BID"].Value.ToString();
            }

            return null; // Error
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            string bid = get_SelectedBid();
            if (bid == null)
            {
                MessageBox.Show("No booking selected");
                return;
            }

            var form = new Transfer(bid);
            form.ShowDialog();

            fill_Overview();
        }

        private void dataView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataView.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataView.Rows[selectedrowindex];

                if (selectedRow.Cells["To"].Value.ToString() == "" && selectedRow.Cells["Return"].Value.ToString() == "")
                {
                    newButton.Text = "New";
                    deleteButton.Visible = false;
                }
                else
                {
                    newButton.Text = "Edit";
                    deleteButton.Visible = true;
                }

                newButton.Visible = true;
                
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Ask user if data should be deleted
            DialogResult dialogResult = MessageBox.Show("Delete transfer?", "Delete?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            Database.set(string.Format("delete from transfers where bid = {0};", get_SelectedBid()));
            fill_Overview();
        }
    }
}
