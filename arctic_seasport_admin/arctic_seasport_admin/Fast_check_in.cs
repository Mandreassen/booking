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
        private Database_adapter adapter;

        public Fast_check_in(string booking_line)
        {
            blid = booking_line;
            InitializeComponent();
            adapter = new Database_adapter();
            
        }

        private void Fast_check_in_Load(object sender, EventArgs e)
        {
            fill_Box();
            fill_Persosn();
        }

        private void fill_Persosn()
        {
            var num = adapter.get_Value(string.Format(@"
                select persons 
                from bookings
                where bid = (
                    select bid from booking_lines
                    where blid = {0}
                );
            ", blid));

            p_count.Value = Int32.Parse(num);
        }

        private void fill_Box()
        {
            var objects = adapter.get_DataSet(string.Format(@"
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
            adapter.set(string.Format("update rent_objects set currentUser = {0} where Name = '{1}';", blid, roComboBox.SelectedValue));
            adapter.set(string.Format("update bookings set persons = {0} where bid = (select bid from booking_lines where blid = {1});", p_count.Value, blid));
            this.Close();
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            string bid = adapter.get_Value(String.Format("select bid from booking_lines where blid = {0};", blid));
            var report = Report.booking_Confirmation(Int32.Parse(bid));
            var viewer = new ReportViewer(report);
            viewer.ShowDialog();
        }

        private void Fast_check_in_FormClosing(object sender, FormClosingEventArgs e)
        {
            adapter.close();
        }
    }
}
