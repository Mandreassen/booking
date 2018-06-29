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
            remove_ButtonBorder(monthDown);
            remove_ButtonBorder(monthUp);
            remove_ButtonBorder(yearDown);
            remove_ButtonBorder(yearUp);
            fill_All();
        }

        private void fill_All()
        {
            var adapter = new Database_adapter();

            fill_TotalAccommodation(adapter);
            calculate(adapter);
            fill_Arriving(adapter);
            fill_ArrivingNorway(adapter);

            adapter.close();
        }

        private void remove_ButtonBorder(Button button)
        {
            button.TabStop = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
        }

        private void fill_TotalAccommodation(Database_adapter adapter)
        {
            var num = adapter.get_Value(string.Format(@"
                select count(roID)
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


        private void fill_ArrivingNorway(Database_adapter adapter)
        {
            var data = adapter.get_DataSet(string.Format(@"
                select persons, startDate
                from customers
                natural join bookings
                natural join booking_lines
                where country = 'norge'
                group by bid 
                having MONTH(startDate) = '{0}'
                and YEAR(startDate) = '{1}';
            ", dateTimePicker1.Value.ToString("MM"), dateTimePicker1.Value.ToString("yyyy")));

            int total = 0;

            foreach (DataRow row in data.Tables[0].Rows)
            {
                total += int.Parse(row["persons"].ToString());
            }

            arrivingNorway.Text = total.ToString();
        }


        private void fill_Arriving(Database_adapter adapter)
        {
            var data = adapter.get_DataSet(string.Format(@"
                select persons, startDate
                from customers
                natural join bookings
                natural join booking_lines
                where country != 'norge'
                group by bid 
                having MONTH(startDate) = '{0}'
                and YEAR(startDate) = '{1}';
            ", dateTimePicker1.Value.ToString("MM"), dateTimePicker1.Value.ToString("yyyy")));

            int total = 0;

            foreach (DataRow row in data.Tables[0].Rows)
            {
                total += int.Parse(row["persons"].ToString());
            }

            arrivingBox.Text = total.ToString();
        }


        private void calculate(Database_adapter adapter)
        {
            var data = adapter.get_DataSet(string.Format(@"
                select beid, date, bid, persons, country 
                from customers 
                natural join bookings 
                natural join booking_lines 
                natural join booking_entries
                natural join rent_object_types
                where MONTH(date) = '{0}'
                and YEAR(date) = '{1}'
                and accommodation = 'true'
                and name != 'BLOKKERING';
            ", dateTimePicker1.Value.ToString("MM"), dateTimePicker1.Value.ToString("yyyy")));

            List<DataRow> duplicates = new List<DataRow>();

            // Find all duplicates in data set
            foreach (DataRow rowA in data.Tables[0].Rows)
            {
                foreach (DataRow rowB in data.Tables[0].Rows)
                {
                    if (duplicates.Contains(rowA))
                    {
                        continue;
                    }

                    if (rowA == rowB)
                    {
                        continue;                        
                    }

                    if (rowA["bid"].ToString() == rowB["bid"].ToString() && rowA["date"].ToString() == rowB["date"].ToString())
                    {
                        if (!duplicates.Contains(rowB))
                        {
                            duplicates.Add(rowB);
                        }                        
                    }
                }
            }

            var countries = new Dictionary<string, int>();
            
            int guests = 0;

            // Count all guests and skip duplicates
            foreach (DataRow row in data.Tables[0].Rows)
            {
                if (duplicates.Contains(row))
                {
                    continue;
                }

                guests += int.Parse(row["persons"].ToString());

                if (!countries.ContainsKey(row["country"].ToString()))
                {
                    countries.Add(row["country"].ToString(), 0);
                }

                countries[row["country"].ToString()] += int.Parse(row["persons"].ToString());

            }

            totalGuests.Text = guests.ToString();

            // Sort data
            var ds = countries.ToList();
            ds.Sort((x, y) => y.Value.CompareTo(x.Value));

            dataView.DataSource = ds.ToArray();
            dataView.AutoResizeColumns();
            dataView.ClearSelection();
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {      
            fill_All();            
        }

        private void monthUp_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(1);

        }

        private void monthDown_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(-1);
        }

        private void yearUp_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddYears(1);
        }

        private void yearDown_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddYears(-1);
        }
    }
}
