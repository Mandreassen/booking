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
    public partial class Transfer : Form
    {
        private string bid;

        public Transfer(string booking_id)
        {
            bid = booking_id;
            InitializeComponent();
            arrivalTime.CustomFormat = "HH:mm";
            departureTime.CustomFormat = "HH:mm";
            Header.Text += " " + booking_id;

            personsBox.Text = Database.get_Value(string.Format("select persons from bookings where bid = {0};", booking_id));
        }

        private void arrivalFlight_Enter(object sender, EventArgs e)
        {
            if (arrivalFlight.Text == "Arrival flight")
            {
                arrivalFlight.Text = "";
                arrivalFlight.ForeColor = SystemColors.ControlText;
            }

        }

        private void arrivalFlight_Leave(object sender, EventArgs e)
        {
            if (arrivalFlight.Text == "")
            {
                arrivalFlight.Text = "Arrival flight";
                arrivalFlight.ForeColor = SystemColors.ControlDarkDark;
            }
        }



        private void departureFlight_Enter(object sender, EventArgs e)
        {
            if (departureFlight.Text == "Departure flight")
            {
                departureFlight.Text = "";
                departureFlight.ForeColor = SystemColors.ControlText;
            }

        }

        private void departureFlight_Leave(object sender, EventArgs e)
        {
            if (departureFlight.Text == "")
            {
                departureFlight.Text = "Departure flight";
                departureFlight.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string arrivaltime, departuretime, arrivalflight, departureflight;
            arrivaltime = departuretime = arrivalflight = departureflight = "NULL";

            if (arrivalOnly.Checked == true || both.Checked == true)
            {
                arrivaltime = string.Format("'{0}'", arrivalDate.Value.ToString("yyyy-MM-dd") + arrivalTime.Value.ToString(" HH:mm") + ":00");
                arrivalflight = string.Format("'{0}'", (arrivalFlight.Text != "Arrival flight") ? arrivalFlight.Text : "");
            }

            if (departureOnly.Checked == true || both.Checked == true)
            {
                departuretime = string.Format("'{0}'", departureDate.Value.ToString("yyyy-MM-dd") + departureTime.Value.ToString(" HH:mm") + ":00");
                departureflight = string.Format("'{0}'", (departureFlight.Text != "Departure flight") ? departureFlight.Text : "");
            }

            Database.set(string.Format(@"
                insert into transfers
                values(NULL, {0}, {1}, {2}, {3}, {4}, {5});
                ", bid, arrivaltime, arrivalflight, departuretime, departureflight, personsBox.Text)
            );

            this.Close();
        }

        private void arrivalOnly_CheckedChanged(object sender, EventArgs e)
        {
            arrivalLabel.Visible = true;
            arrivalDate.Visible = true;
            arrivalTime.Visible = true;
            arrivalFlight.Visible = true;

            departureLabel.Visible = false;
            departureDate.Visible = false;
            departureTime.Visible = false;
            departureFlight.Visible = false;
        }

        private void departureOnly_CheckedChanged(object sender, EventArgs e)
        {
            departureLabel.Visible = true;
            departureDate.Visible = true;
            departureTime.Visible = true;
            departureFlight.Visible = true;

            arrivalLabel.Visible = false;
            arrivalDate.Visible = false;
            arrivalTime.Visible = false;
            arrivalFlight.Visible = false;
        }

        private void both_CheckedChanged(object sender, EventArgs e)
        {
            arrivalLabel.Visible = true;
            arrivalDate.Visible = true;
            arrivalTime.Visible = true;
            arrivalFlight.Visible = true;

            departureLabel.Visible = true;
            departureDate.Visible = true;
            departureTime.Visible = true;
            departureFlight.Visible = true;
        }

        private void arrivalDate_ValueChanged(object sender, EventArgs e)
        {
            departureDate.Value = arrivalDate.Value.AddDays(1);
        }
    }
}
