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
    public partial class Edit_rent_objects : Form
    {
        public Edit_rent_objects()
        {
            InitializeComponent();
        }

        private void Edit_rent_objects_Load(object sender, EventArgs e)
        {
            fill_ObjectsTable();
            fill_TypeTable();
        }


        /* Fill Rent object types table */
        private void fill_TypeTable()
        {
            DataSet ds = Database.get_DataSet("select roID as \'ID\', Description, Price from rent_object_types;");
            if (ds == null)
                return;

           rentObjectTypesView.DataSource = ds.Tables[0];

            rentObjectTypesView.AutoResizeColumns();
            rentObjectTypesView.ClearSelection();
            rentObjectTypesView.Show();
        }

        /* Fill Active rent objects table */
        private void fill_ObjectsTable()
        {
            DataSet ds = Database.get_DataSet("select Name, Description from rent_objects natural join rent_object_types;");
            if (ds == null)
                return;

            rentObjectsView.DataSource = ds.Tables[0];

            rentObjectsView.AutoResizeColumns();
            rentObjectsView.ClearSelection();
            rentObjectsView.Show();
        }


        /* Get roID selected in type table. */
        private string get_SelectedRoID()
        {
            if (rentObjectTypesView.SelectedCells.Count > 0)
            {
                int selectedrowindex = rentObjectTypesView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = rentObjectTypesView.Rows[selectedrowindex];

                return selectedRow.Cells["ID"].Value.ToString();
            }

            return null; // Error
        }

        /* Get Name selected in objects table. */
        private string get_SelectedName()
        {
            if (rentObjectsView.SelectedCells.Count > 0)
            {
                int selectedrowindex = rentObjectsView.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = rentObjectsView.Rows[selectedrowindex];

                return selectedRow.Cells["Name"].Value.ToString();
            }

            return null; // Error
        }

        private void addTypeBtn_Click(object sender, EventArgs e)
        {
            Add_rent_object_type form = new Add_rent_object_type();
            form.ShowDialog();
            fill_TypeTable();
        }

        private void editTypeBtn_Click(object sender, EventArgs e)
        {
            var roID = get_SelectedRoID();
            if (roID == null)
            {
                MessageBox.Show("No rent object type selected.");
                return;
            }

            Add_rent_object_type form = new Add_rent_object_type(roID);
            form.ShowDialog();
            fill_TypeTable();
        }

        private void deleteTypeBtn_Click(object sender, EventArgs e)
        {
            var roID = get_SelectedRoID();
            if (roID == null)
            {
                MessageBox.Show("No rent object type selected.");
                return;
            }

            var description = Database.get_Value(string.Format("select description from rent_object_types where roID = {0};", roID));

            var count = Database.get_Value(string.Format("select count(Name) from rent_objects where roID = {0};", roID));
            if (Int32.Parse(count) > 0)
            {
                MessageBox.Show(string.Format("All {0} rent objects must be deleted before the {0}-type can be deleted.", description));
                return;
            }

            DialogResult dialogResult = MessageBox.Show(string.Format("Are you sure you want to delete {0}", description), "Delete?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            Database.set(string.Format("delete from rent_object_types where roID = {0};", roID));
            fill_TypeTable();
        }

        private void addObjectBtn_Click(object sender, EventArgs e)
        {
            Add_rent_object form = new Add_rent_object();
            form.ShowDialog();
            fill_ObjectsTable();
        }

        private void editObjectBtn_Click(object sender, EventArgs e)
        {
            var name = get_SelectedName();
            if (name == null)
            {
                MessageBox.Show("No rent object selected");
                return;
            }

            Add_rent_object form = new Add_rent_object(name);
            form.ShowDialog();
            fill_ObjectsTable();
        }

        private void deleteObjectBtn_Click(object sender, EventArgs e)
        {
            var name = get_SelectedName();
            if (name == null)
            {
                MessageBox.Show("No rent object selected");
                return;
            }

            var form = new ObjectDeleter(name);
            form.ShowDialog();

            fill_ObjectsTable();
        }
    }
}
