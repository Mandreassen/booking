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
    public partial class Add_rent_object_type : Form
    {
        private string roID;

        public Add_rent_object_type(string edit_roID = null)
        {
            roID = edit_roID;
            InitializeComponent();
        }

        private void Add_rent_object_type_Load(object sender, EventArgs e)
        {
            if (roID != null)
                load_Existing();
        }

        private void load_Existing()
        {
            descriptionBox.Text = Database.get_Value(string.Format("select description from rent_object_types where roID = {0}", roID));
            priceBox.Text = Database.get_Value(string.Format("select Price from rent_object_types where roID = {0}", roID));
        }

        // Read and format price
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

        // Read and format description
        private string get_Description()
        {
            var description = descriptionBox.Text;
            if (description.Length == 0)
            {
                MessageBox.Show("New rent object must have a description.");
                return null;
            }

            return description;
        }

        // Save rent object type
        private void saveButton_Click(object sender, EventArgs e)
        {
            var description = get_Description();
            if (description == null)
                return;

            var price = get_Price();
            if (price == null)
                return;

            string query;

            // Add new
            if (roID == null)
                query = string.Format("insert into rent_object_types values(NULL, \'{0}', \'{1}\', 'false');", description, price);

            // Update existing
            else
                query = string.Format("update rent_object_types set Description = \'{0}\', Price = {1} where roID = {2};", description, price, roID);

            Database.set(query);

            this.Close();
        }
    }
}
