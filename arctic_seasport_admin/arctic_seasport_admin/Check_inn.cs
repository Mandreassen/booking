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
    public partial class Check_inn : Form
    {
        bool allow_select = false;

        public Check_inn()
        {
            InitializeComponent();
        }

        private void Check_inn_Load(object sender, EventArgs e)
        {
            refresh();
            allow_select = true;
        }

        private void refresh()
        {
            allow_select = false;
            fill_Table();
            fill_CustomerBox();
            fill_roBox();
            allow_select = true;
        }


        /* Fill box with customers arriving at
        * current date having "unchecked" orders. */
        private void fill_CustomerBox()
        {
            var lines = Database.get_Dict(string.Format(@"
                select blid, concat(Name, ' - ', Description) AS 'Show'
                from rent_object_types 
                natural join booking_entries
                natural join booking_lines
                natural join bookings
                natural join customers
                where date = '{0}'
                and blid not in
                    (select currentUser from rent_objects)
                group by blid;
                ", DateTime.Now.ToString("yyyy-MM-dd")));

            if (lines.Count == 0)
            {
                customerComboBox.DataSource = null;
                customerComboBox.Items.Clear();
            }
            else
            {
                customerComboBox.DataSource = new BindingSource(lines, null);
                customerComboBox.DisplayMember = "Value";
                customerComboBox.ValueMember = "Key";
            }
        }


        private void fill_roBox()
        {
            if (customerComboBox.DataSource == null)
            {
                roComboBox.DataSource = null;
                roComboBox.Items.Clear();
                return; // Error
            }                

            var objects = Database.get_DataSet(string.Format(@"
                select name
                from rent_objects
                natural join rent_object_types
                natural join booking_entries
                where blid = {0}
                and status = 'Ready'
                and currentUser = 0
                group by name;
                ", customerComboBox.SelectedValue));

            roComboBox.DataSource = objects.Tables[0];

            roComboBox.DisplayMember = "Name";
            roComboBox.ValueMember = "Name";
        }


        /* Fill teble with "checked in" objects */
        private void fill_Table()
        {
            var checkedIn = Database.get_DataSet(string.Format(@"
                select cid AS 'CID', customers.Name as 'User', rent_objects.name AS 'Object', description AS 'Type'
                from rent_object_types
                natural join rent_objects
                join (booking_lines 
                    natural join bookings
                    natural join customers)
                on rent_objects.currentUser = booking_lines.blid
                where currentUser != 0
                ;"));

            useTable.DataSource = checkedIn.Tables[0];
            useTable.AutoResizeColumns();
            useTable.ClearSelection();
        }


        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allow_select) 
            {
                fill_roBox();
            }
        }


        /* Check in selected object */
        private void checkInnButton_Click(object sender, EventArgs e)
        {
            if (customerComboBox.DataSource == null)
            {
                MessageBox.Show("No more bookings to check in.");
                return;
            }

            var query = string.Format("update rent_objects set currentUser = {0} where Name = \'{1}\';", customerComboBox.SelectedValue, roComboBox.SelectedValue);
            Database.set(query);
            refresh();
        }


        /* Get selected rent object from table */
        private string get_SelectedItem(string item)
        {
            if (useTable.SelectedCells.Count > 0)
            {
                int selectedrowindex = useTable.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = useTable.Rows[selectedrowindex];

                return selectedRow.Cells[item].Value.ToString();
            }

            return null; // Error
        }


        /* Check out single object
         * The user is promted with a question asking
         * if the object should be marked as ready or not.
         * If a object is marked as Not ready, it will not
         * show as "checkable" until it is set as "Ready" */
        private void check_Out(string obj)
        {
            var status = "Ready";
            DialogResult dialogResult = MessageBox.Show(string.Format("Do you want to mark {0} as ready?", obj), obj, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                status = "Not ready";

            var query = string.Format("update rent_objects set currentUser = 0, status = '{0}' where name = '{1}';", status, obj);
            Database.set(query);
        }


        /* Check out selected object
         * If customer holds more than one object, the user will be
         * prompted with a question asking if he/she wants to check
         * out all objects held by the customer. */
        private void checkOutButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.No;
            var rent_object = get_SelectedItem("Object");
            if (rent_object == null)
            {
                MessageBox.Show("No object selected.");
                return;
            }

            var cid = get_SelectedItem("CID");
            int num = 0;
            foreach (DataGridViewRow row in useTable.Rows)
            {
                if (row.Cells[0].Value.ToString() == cid)
                    num++;
            }

            // Check whether customer holds more objects
            if (num > 1)
            {
                var name = get_SelectedItem("User");
                dialogResult = MessageBox.Show(string.Format("Do you want to check out all objects for {0}?", name), name, MessageBoxButtons.YesNo);
            }

            // Check out slected object       
            if (dialogResult == DialogResult.No)
            {
                check_Out(rent_object);
            }

            // Check out all objects held by customer
            else
            {
                foreach (DataGridViewRow row in useTable.Rows)
                {
                    if (row.Cells[0].Value.ToString() == cid)
                    {
                        check_Out(row.Cells[2].Value.ToString());
                    }
                }
            }

                refresh();
        }
    }
}
