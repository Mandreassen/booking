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
    public partial class manage_rent_objects : Form
    {
        public manage_rent_objects()
        {
            InitializeComponent();
        }

        private void manage_rent_objects_Load(object sender, EventArgs e)
        {
            fill_Table();
            fill_Box();
        }


        /* Fill Active rent objects table */
        private void fill_Table()
        {
            objectsView.DataSource = Database.get_DataSet("select Name, Description from rent_objects natural join rent_object_types;").Tables[0];

            objectsView.AutoResizeColumns();
            objectsView.ClearSelection();
            objectsView.Show();
        }


        /* Fill rent object type comboBox */
        private void fill_Box()
        {
            comboBox1.DataSource = Database.get_DataSet("select roID, Description from rent_object_types;").Tables[0];

            comboBox1.DisplayMember = "Description";
            comboBox1.ValueMember = "roID";
        }
        

        /* Add button click */
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (name.Length == 0)
            {
                MessageBox.Show("New rent object must have a description.");
                return;
            }

            string roID = comboBox1.SelectedValue.ToString();

            Database.set("insert into rent_objects values(\"" + name + "\", " + roID + ");");            

            fill_Table();                    
        }


        /* New rent object type button click */
        private void button2_Click(object sender, EventArgs e)
        {
            manage_rent_object_types form = new manage_rent_object_types();
            form.ShowDialog(this);
            fill_Box();
        }
    }
}
