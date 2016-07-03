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
        }

        private void Hotel_statistics_Load(object sender, EventArgs e)
        {
            fill_All();
        }

        private void fill_All()
        {
            var adapter = new Database_adapter();
            fill_Table(adapter);
            fill_TotalAccommodation(adapter);
            fill_TotalGuests(adapter);
            adapter.close();
        }


        private void fill_TotalAccommodation(Database_adapter adapter)
        {
            var num = adapter.get_Value(string.Format(@"
                select sum(roID)
                from rent_object_types
                natural join booking_entries
                natural join booking_lines
                natural join bookings
                natural join customers
                where accommodation = 'true'
                and MONTH(date) = '{0}'
                and YEAR(date) = '{1}'
                and name != 'BLOKKERING'
                ", dateTimePicker1.Value.ToString("MM"), dateTimePicker1.Value.ToString("yyyy"))
            );

            numAccom.Text = num;
        }

        private void fill_TotalGuests(Database_adapter adapter)
        {
            var num = adapter.get_Value(string.Format(@"
                select sum(persons)
                from booking_entries
                natural join booking_lines
                natural join bookings
                natural join customers
                where MONTH(date) = '{0}'
                and YEAR(date) = '{1}'
                ", dateTimePicker1.Value.ToString("MM"), dateTimePicker1.Value.ToString("yyyy"))
            );

            totalGuests.Text = num;
        }

        private void fill_Table(Database_adapter adapter)
        {
            var data = adapter.get_DataSet(string.Format(@"
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
            fill_All();
        }
    }
}
