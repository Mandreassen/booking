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
    public partial class manage_rent_object_types : Form
    {
        public manage_rent_object_types()
        {
            InitializeComponent();
        }

        private void manage_rent_object_types_Load(object sender, EventArgs e)
        {
            fill_Table();
        }


        /* Fill Rent object types table */
        private void fill_Table()
        {
            DataSet ds = Database.get_DataSet("select Description, Price from rent_object_types;");
            if (ds == null)
                return;

            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.AutoResizeColumns();
            dataGridView1.ClearSelection();
            dataGridView1.Show();
        }


        private string get_Price()
        {
            var price = priceBox.Text;
            if (price == "")
            {
                MessageBox.Show("New rent object must have a price.");
                return null;
            }

            price = price.Replace(',', '.');

            if (!price.Contains("."))
                price = string.Format("{0}.00", price);

            return price;
        }

        private string get_Description()
        {
            var description = textBox1.Text;
            if (description.Length == 0)
            {
                MessageBox.Show("New rent object must have a description.");
                return null;
            }

            return description;
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            var description = get_Description();
            if (description == null)
                return;

            var price = get_Price();
            if (price == null)
                return;

            var query = string.Format("insert into rent_object_types values(NULL, \'{0}', \'{1}\');", description, price);
            //Database.set(query);
            MessageBox.Show(query);
            fill_Table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
