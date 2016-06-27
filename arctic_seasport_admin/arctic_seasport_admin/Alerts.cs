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
    public partial class Alerts : Form
    {
        public Alerts()
        {
            InitializeComponent();
        }

        private void Alerts_Load(object sender, EventArgs e)
        {
            fill_Table();
        }


        private void fill_Table()
        {
            DataSet ds = Database.get_DataSet(string.Format(@"
                select aid, bid AS 'BID', alertDescription AS 'Event', alertDate AS 'Alert date', company AS 'Company', booker AS 'Booker'
                from alerts
                natural join bookings;
            "));

            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns["aid"].Visible = false;
            dataGridView2.AutoResizeColumns();
            dataGridView2.ClearSelection();
            dataGridView2.Show();
        }

        /* Get Booking Line ID selected in Booked table. */
        private string get_SelectedBid()
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];

                return selectedRow.Cells["BID"].Value.ToString();
            }

            return null; // Error
        }

        /* Get Booking Line ID selected in Booked table. */
        private string get_SelectedAid()
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];

                return selectedRow.Cells["aid"].Value.ToString();
            }

            return null; // Error
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            var bid = get_SelectedBid();
            var report = Report.booking_Confirmation(Int32.Parse(bid));
            var viewer = new ReportViewer(report);
            viewer.ShowDialog();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            Database.set(string.Format(@"
                delete from alerts where aid = {0};
            ", get_SelectedAid()));

            fill_Table();
        }
    }
}
