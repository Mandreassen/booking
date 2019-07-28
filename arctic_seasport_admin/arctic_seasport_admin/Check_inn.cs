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
        public Check_inn()
        {
            InitializeComponent();
        }

        private void Check_inn_Load(object sender, EventArgs e)
        {
            refreash_Content();
        }

        private void refreash_Content()
        {
            fill_Table();
            fill_CheckInnTable();       
        }


        /* Fill table with customers arriving at
        * current date having "unchecked" orders. */
        private void fill_CheckInnTable()
        {
            var data = Database.get_DataSet(string.Format(@"
                select blid, bid, Name, Description 
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

            checkInnTable.DataSource = data.Tables[0];
            checkInnTable.Columns[0].Visible = false;
            checkInnTable.AutoResizeColumns();
            checkInnTable.ClearSelection();
        }


        /* Fill table with "checked in" objects */
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
            useTable.AutoSize = true;
            this.CenterToScreen();
            
            useTable.ClearSelection();
        }


        /* Check in selected object */
        private void checkInnButton_Click(object sender, EventArgs e)
        {
            check_Inn();
        }


        /* Get selected rent object from table */
        private string get_SelectedItem(DataGridView table, string item)
        {
            if (table.SelectedCells.Count > 0)
            {
                int selectedrowindex = table.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = table.Rows[selectedrowindex];

                return selectedRow.Cells[item].Value.ToString();
            }

            return null; // Error
        }


        /* Check out single object
         * The user is promted with a question asking
         * if the object should be marked as ready or not.
         * If a object is marked as Not ready, it will not
         * show as "checkable" until it is set as "Ready" */
        private bool check_OutLine(string obj)
        {
            var status = "Ready";
            DialogResult dialogResult = MessageBox.Show(string.Format("Do you want to mark {0} as ready?", obj), obj, MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Cancel)
                return true;

            if (dialogResult == DialogResult.No)
                status = "Not ready";

            var query = string.Format("update rent_objects set currentUser = 0, status = '{0}' where name = '{1}';", status, obj);
            Database.set(query);

            return false;
        }

        
        /* Check out selected object
         * If customer holds more than one object, the user will be
         * prompted with a question asking if he/she wants to check
         * out all objects held by the customer. */
        private void check_Out()
        {
            DialogResult dialogResult = DialogResult.No;
            var rent_object = get_SelectedItem(useTable, "Object");
            if (rent_object == null)
            {
                MessageBox.Show("No object selected.");
                return;
            }

            var cid = get_SelectedItem(useTable, "CID");
            int num = 0;
            foreach (DataGridViewRow row in useTable.Rows)
            {
                if (row.Cells[0].Value.ToString() == cid)
                    num++;
            }

            // Check whether customer holds more objects
            if (num > 1)
            {
                var name = get_SelectedItem(useTable, "User");
                dialogResult = MessageBox.Show(string.Format("Do you want to check out all objects for {0}?", name), name, MessageBoxButtons.YesNo);
            }

            // Check out slected object       
            if (dialogResult == DialogResult.No)
            {
                check_OutLine(rent_object);
            }

            // Check out all objects held by customer
            else
            {
                foreach (DataGridViewRow row in useTable.Rows)
                {
                    if (row.Cells[0].Value.ToString() == cid)
                    {
                        bool cancel = check_OutLine(row.Cells[2].Value.ToString());
                        if (cancel)
                            break;
                    }
                }
            }

            refreash_Content();
        }

        private void check_Inn()
        {
            string blid = get_SelectedItem(checkInnTable, "blid");
            if (blid == null)
            {
                MessageBox.Show("No item selected");
                return;
            }

            var form = new Fast_check_in(blid);

            form.ShowDialog();

            refreash_Content();
        }
        

        private void checkOutButton_Click(object sender, EventArgs e)
        {
            check_Out();
        }

        private void useTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            check_Out();
        }

        private void checkInnTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            check_Inn();
        }
    }
}
