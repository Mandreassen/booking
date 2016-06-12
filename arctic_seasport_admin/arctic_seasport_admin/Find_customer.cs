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
    public partial class Find_customer : Form
    {
        private New_customer prevForm;


        /* INIT */
        public Find_customer(New_customer form)
        {
            prevForm = form;
            InitializeComponent();
        }

        
        /* Load table */
        private void Find_customer_Load(object sender, EventArgs e)
        {
            fill_Table();
        }


        /* Fill Bookings table. */
        private void fill_Table()
        {
            DataSet ds = Database.get_DataSet("select * from customers where Name like \'%" + searchBox.Text + "%\' and cid != 1;");

            customers.DataSource = ds.Tables[0];

            customers.AutoResizeColumns();
            customers.ClearSelection();
            customers.Show();
        }


        /* Update search */
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            fill_Table();
        }


        /* Get selected cid from table */
        private string get_SelectedCid()
        {
            if (customers.SelectedCells.Count > 0)
            {
                int selectedrowindex = customers.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = customers.Rows[selectedrowindex];

                return selectedRow.Cells["cid"].Value.ToString();
            }

            return "1"; // Error
        }


        /* Get selected cid and return */
        private void customers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            prevForm.cid = System.Int32.Parse(get_SelectedCid());
            this.Close();
        }


        /* Clear text in search box */
        private void cross_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
        }
    }
}
