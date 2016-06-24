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
    public partial class Hotel_statistics : Form
    {
        public Hotel_statistics()
        {
            InitializeComponent();
            fill_Table();
        }

        private void fill_Table()
        {
            var data = Database.get_DataSet(string.Format(@"
                select country AS 'Nationality', sum(persons) AS 'Total' 
                from booking_entries
                natural join booking_lines
                natural join bookings
                natural join customers
                where MONTH(date) = '{0}'
                and YEAR(date) = '{1}'
                group by country;
                ", dateTimePicker1.Value.ToString("MM"), dateTimePicker1.Value.ToString("yyyy"))
            );

            dataView.DataSource = data.Tables[0];
            dataView.AutoResizeColumns();
            dataView.ClearSelection();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fill_Table();
        }
    }
}
