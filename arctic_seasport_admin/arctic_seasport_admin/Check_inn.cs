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
            fill_typeBox();
            fill_roBox();
            allow_select = true;
        }


        /* Fill box with customers arriving at
         * current date having "unchecked" orders. */
        private void fill_CustomerBox()
        {
            customerComboBox.DataSource = null;
            customerComboBox.Items.Clear();

            var valid     = new Dictionary<string, string>();
            var checkedIn = Database.get_Dict("select currentUser, count(currentUser) from rent_objects group by currentUser;");
            var ordered   = Database.get_Dict(string.Format("select cid, count(cid) from bookings natural join booking_lines where date = \'{0}\' group by cid;", System.DateTime.Now.ToString("yyyy-MM-dd")));
     
            // Fint all ordered more than they have checkt in
            foreach (KeyValuePair<string, string> item in ordered)
            {
                if (checkedIn.ContainsKey(item.Key))
                {
                    if (Int32.Parse(item.Value) <= Int32.Parse(checkedIn[item.Key]))
                    {
                        continue; // Skip
                    }
                }

                valid.Add(item.Key, Database.get_Value(string.Format("select Name from customers where cid = {0}", item.Key)));
            }

            if (valid.Count() > 0)
            {
                customerComboBox.DataSource = new BindingSource(valid, null);
                customerComboBox.DisplayMember = "Value";
                customerComboBox.ValueMember = "Key";
            }
        }


        /* Fill box with rent object types
         * booked by customer.
         * Only not checked objects will show. */
        private void fill_typeBox()
        {
            typeComboBox.DataSource = null;
            typeComboBox.Items.Clear();

            if (customerComboBox.SelectedValue == null)
                return; // Error

            var valid = new Dictionary<string, string>();
            var checkedIn = Database.get_Dict(string.Format("select roID, count(currentUser) from rent_objects where currentUser = {0} group by roID;", customerComboBox.SelectedValue));
            var ordered = Database.get_Dict(string.Format("select roID, count(cid) from booking_lines natural join bookings where cid = {0} and Date = \'{1}\' group by roID;", customerComboBox.SelectedValue, System.DateTime.Now.ToString("yyyy-MM-dd")));

            // Fint all ordered more than they have checkt in
            foreach (KeyValuePair<string, string> item in ordered)
            {
                if (checkedIn.ContainsKey(item.Key))
                {
                    if (Int32.Parse(item.Value) <= Int32.Parse(checkedIn[item.Key]))
                    {
                        continue; // Skip
                    }
                }

                valid.Add(item.Key, Database.get_Value(string.Format("select Description from rent_object_types where roID = {0}", item.Key)));
            }

            if (valid.Count() > 0)
            {
                typeComboBox.DataSource = new BindingSource(valid, null);
                typeComboBox.DisplayMember = "Value";
                typeComboBox.ValueMember = "Key";
            }
        }


        /* Fill box with available and "Ready" rent objects */
        private void fill_roBox()
        {
            roComboBox.DataSource = null;
            roComboBox.Items.Clear();          

            if (typeComboBox.SelectedValue == null)
                return; // Error

            //var query = string.Format("select Name from rent_objects where roID = {0} and status = \'Ready\' and currentUser = 0;", typeComboBox.SelectedValue);
            var query = string.Format("select Name, concat(Name, ' - ', Description) as 'Show' from rent_objects natural join rent_object_types where status = \'Ready\' and currentUser = 0 order by (roID = {0}) DESC, roID;", typeComboBox.SelectedValue);
            roComboBox.DataSource = Database.get_DataSet(query).Tables[0];

            roComboBox.DisplayMember = "Show";
            roComboBox.ValueMember = "Name";
        }


        /* Fill teble with "checked in" objects */
        private void fill_Table()
        {
            var query = "select rent_objects.Name as 'Object', Description as 'Type', customers.Name as 'User' from rent_object_types natural join rent_objects join customers on rent_objects.currentUser = customers.cid;";
            useTable.DataSource = Database.get_DataSet(query).Tables[0];
            useTable.AutoResizeColumns();
            useTable.ClearSelection();
        }


        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allow_select) 
            {
                fill_typeBox();
                fill_roBox();
            }
        }


        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
        private string get_SelectedObject()
        {
            if (useTable.SelectedCells.Count > 0)
            {
                int selectedrowindex = useTable.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = useTable.Rows[selectedrowindex];

                return selectedRow.Cells["Object"].Value.ToString();
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

            var query = string.Format("update rent_objects set currentUser = 0, status = \'{0}\' where name = \'{1}\';", status, obj);
            Database.set(query);
        }


        /* Check out selected object
         * If customer holds more than one object, the user will be
         * prompted with a question asking if he/she wants to check
         * out all objects held by the customer. */
        private void checkOutButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.No;
            var selected = get_SelectedObject();
            if (selected == null)
            {
                MessageBox.Show("No object selected.");
                return;
            }

            var cid = Database.get_Value(string.Format("select currentUser from rent_objects where Name = \'{0}\';", selected));
            var num = Database.get_Value(string.Format("select count(roID) from rent_objects where currentUser = {0}", cid));

            // Check whether customer holds more objects
            if (Int32.Parse(num) > 1)
            {
                var name = Database.get_Value(string.Format("select Name from customers where cid = {0}", cid));
                dialogResult = MessageBox.Show(string.Format("Do you want to check out all objects for {0}?", name), name, MessageBoxButtons.YesNo);
            }
                
            // Check out slected object       
            if (dialogResult == DialogResult.No)
            {
                check_Out(selected);
            }

            // Check out all objects held by customer
            else
            {
                var all = Database.get_List(string.Format("select Name from rent_objects where currentUser = {0}", cid));
                foreach (string obj in all)
                {
                    check_Out(obj);
                }
            }            

            refresh();
        }
    }
}
