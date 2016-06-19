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
    public partial class Fast_check_in : Form
    {
        private string blid;

        public Fast_check_in(string booking_line)
        {
            blid = booking_line;
            InitializeComponent();
            fill_Box();
        }

        private void fill_Box()
        {
            var objects = Database.get_DataSet(string.Format(@"
                select name
                from rent_objects
                natural join rent_object_types
                natural join booking_entries
                where blid = {0}
                and status = 'Ready'
                and currentUser = 0
                group by name;
                ", blid));

            roComboBox.DataSource = objects.Tables[0];

            roComboBox.DisplayMember = "Name";
            roComboBox.ValueMember = "Name";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var query = string.Format("update rent_objects set currentUser = {0} where Name = '{1}';", blid, roComboBox.SelectedValue);
            Database.set(query);
            this.Close();
        }
    }
}
