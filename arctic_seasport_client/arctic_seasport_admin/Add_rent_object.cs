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
    public partial class Add_rent_object : Form
    {
        private string name;

        public Add_rent_object(string edit_name = null)
        {
            name = edit_name;
            InitializeComponent();
        }

        private void Add_rent_object_Load(object sender, EventArgs e)
        {
            typeBox.DataSource = Database.get_DataSet("select roID, Description from rent_object_types;").Tables[0];
            typeBox.DisplayMember = "Description";
            typeBox.ValueMember = "roID";

            if (name != null)
            {
                nameBox.Text = name;
                typeBox.SelectedValue = Database.get_Value(string.Format("select roID from rent_objects where Name = \'{0}\';", name));
            }
                
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                MessageBox.Show("Rent object must have a name.");
                return;
            }

            if (name == null)
            {
                Database.set(string.Format("insert into rent_objects values(\'{0}\', {1}, 0, \'Ready\');", nameBox.Text, typeBox.SelectedValue));
            }
            else
            {
                Database.set(string.Format("update rent_objects set Name = \'{0}\', roID = {1} where Name = \'{2}\';", nameBox.Text, typeBox.SelectedValue, name));
            }

            this.Close();
        }
    }
}
