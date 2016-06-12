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
    public partial class Ready_rent_objects : Form
    {
        public Ready_rent_objects()
        {
            InitializeComponent();
        }

        private void Ready_rent_objects_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            fill_Ready_table();
            fill_Not_ready_table();
        }

        /* Get selected rent object from table */
        private string get_SelectedObject(DataGridView table)
        {
            if (table.SelectedCells.Count > 0)
            {
                int selectedrowindex = table.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = table.Rows[selectedrowindex];

                return selectedRow.Cells["Name"].Value.ToString();
            }

            return null; // Error
        }

        private void update(DataGridView table, string status)
        {
            var selected = get_SelectedObject(table);
            if (selected == null)
            {
                MessageBox.Show("No item selected.");
                return;
            }

            Database.set(string.Format("update rent_objects set status = \'{0}\' where name = \'{1}\';", status, selected));

            refresh();
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            update(readyTable, "Not ready");
            
        }

        private void notReadyButton_Click(object sender, EventArgs e)
        {
            update(notReadyTable, "Ready");
        }

        /* Fill ready table  */
        private void fill_Ready_table()
        {
            var query = "select Name, Description from rent_objects natural join rent_object_types where status = \'Ready\';";
            readyTable.DataSource = Database.get_DataSet(query).Tables[0];
            readyTable.AutoResizeColumns();
        }

        /* Fill not ready table  */
        private void fill_Not_ready_table()
        {
            var query = "select Name, Description from rent_objects natural join rent_object_types where status = \'Not ready\';";
            notReadyTable.DataSource = Database.get_DataSet(query).Tables[0];
            notReadyTable.AutoResizeColumns();
        }
    }
}
