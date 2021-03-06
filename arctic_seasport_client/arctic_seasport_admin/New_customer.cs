﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;

namespace arctic_seasport_admin
{
    public partial class New_customer : Form
    {
        private int bid;
        public int cid;
        private new_booking prevForm;


        /* INIT */
        public New_customer(int set_bid, int set_cid, new_booking booker)
        {
            bid = set_bid;
            cid = set_cid;
            prevForm = booker;
            InitializeComponent();
        }


        private void New_customer_Load(object sender, EventArgs e)
        {
            fill_info();
        }


        private void fill_info()
        {
            if (cid != Database.DEFAULT_CUSTOMER)
            {
                Cursor.Current = Cursors.WaitCursor;
                var adapter = new Database_adapter();
                fill_Name_Box(adapter);
                fill_EmailBox(adapter);
                fill_PhoneBox(adapter);
                fill_AddressBox(adapter);
                fill_postnrBox(adapter);
                fill_postLocationBox(adapter);
                fill_NoteBox(adapter);
                fill_BookerBox(adapter);
                fill_PersonsBox(adapter);
                adapter.close();
                Cursor.Current = Cursors.Default;
            }
        }


        private void fill_Name_Box(Database_adapter adapter)
        {
            var query = string.Format("select Name from customers natural join bookings where bid = {0};", bid);
            string data = adapter.get_Value(query);
            if (data != null)
            {
                nameBox.Text = data;
            }
        }


        private void fill_EmailBox(Database_adapter adapter)
        {
            var query = string.Format("select Email from customers natural join bookings where bid = {0};", bid);
            string data = adapter.get_Value(query);
            if (data != null)
            {
                emailBox.Text = data;
            }
        }


        private void fill_PhoneBox(Database_adapter adapter)
        {
            var query = string.Format("select Phone from customers natural join bookings where bid = {0};", bid);
            string data = adapter.get_Value(query);
            if (data != null)
            {
                phoneBox.Text = data;
            }
        }

        private void fill_AddressBox(Database_adapter adapter)
        {
            var query = string.Format("select address from customers natural join bookings where bid = {0};", bid);
            string data = adapter.get_Value(query);
            if (data != null)
            {
                addressBox.Text = data;
            }
        }


        private void fill_postnrBox(Database_adapter adapter)
        {
            var query = string.Format("select postnr from customers natural join bookings where bid = {0};", bid);
            string data = adapter.get_Value(query);
            if (data != null)
            {
                postNrBox.Text = data;
            }
        }

        private void fill_postLocationBox(Database_adapter adapter)
        {
            var query = string.Format("select postlocation from customers natural join bookings where bid = {0};", bid);
            string data = adapter.get_Value(query);
            if (data != null)
            {
                postLocation.Text = data;
            }
        }

        private void fill_NoteBox(Database_adapter adapter)
        {
            var query = string.Format("select Notes from bookings where bid = {0};", bid);
            string data = adapter.get_Value(query);
            if (data != null)
            {
                noteBox.Text = data;
            }
        }

        private void fill_BookerBox(Database_adapter adapter)
        {
            var query = string.Format("select booker from bookings where bid = {0};", bid);
            string data = adapter.get_Value(query);
            if (data != null)
            {
                bookerBox.Text = data;
            }
        }

        private void fill_PersonsBox(Database_adapter adapter)
        {
            var query = string.Format("select persons from bookings where bid = {0};", bid);
            string data = adapter.get_Value(query);
            if (data != null && data != "")
            {
                nCustomers.Value = Int32.Parse(data);
            }
        }


        /* Insert new customer */
        private bool insert_New_Customer()
        {
            var query = string.Format("insert into customers values(NULL, \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\', NULL);select last_insert_id();", nameBox.Text, emailBox.Text, phoneBox.Text, addressBox.Text, postNrBox.Text, postLocation.Text, Properties.Settings.Default.country);
            string new_cid = Database.get_Value(query);
            if (new_cid == null)
                return false;

            query = string.Format("update bookings set cid = {0}, Notes = \'{1}\', persons = {2}, booker = \'{3}\' where bid = {4};", new_cid, noteBox.Text, nCustomers.Value, bookerBox.Text, bid);
            bool status = Database.set(query);

            return status;
        }


        /* Update existing customer */
        private bool update_Customer()
        {
            // Update customer
            var query = string.Format("update customers set name = \'{0}\', email = \'{1}\', phone = \'{2}\', postnr = \'{3}\', postlocation = \'{4}\', country = \'{5}\' where cid = {6};", nameBox.Text, emailBox.Text, phoneBox.Text, postNrBox.Text, postLocation.Text, Properties.Settings.Default.country, cid);
            bool success = Database.set(query);
            if (!success)
                return false;

            // Update notes
            query = string.Format("update bookings set Notes = \'{0}\', persons = {1}, booker = \'{2}\' where bid = {3};", noteBox.Text, nCustomers.Value, bookerBox.Text, bid);
            success = Database.set(query);

            return success;
        }


        private bool sanetyCheck()
        {
            if (nameBox.Text == "")
            {
                MessageBox.Show("Customer is missing");
                return false;
            }

            if (nCustomers.Value <= 0)
            {
                MessageBox.Show("Invalid value for number of persons");
                return false;
            }

            if (bookerBox.Text == "")
            {
                MessageBox.Show("Booker missing");
                return false;
            }

            if (nameBox.Text.Length >= Database.BUFFER_SIZE)
            {
                MessageBox.Show("Name to long.");
                return false;
            }

            if (emailBox.Text.Length >= Database.BUFFER_SIZE)
            {
                MessageBox.Show("Email to long.");
                return false;
            }

            if (phoneBox.Text.Length >= Database.BUFFER_SIZE)
            {
                MessageBox.Show("Phone number to long.");
                return false;
            }

            if (addressBox.Text.Length >= Database.BUFFER_SIZE)
            {
                MessageBox.Show("Address to long.");
                return false;
            }

            if (postNrBox.Text.Length >= Database.BUFFER_SIZE)
            {
                MessageBox.Show("Postnr to long.");
                return false;
            }

            if (postLocation.Text.Length >= Database.BUFFER_SIZE)
            {
                MessageBox.Show("Post location to long.");
                return false;
            }

            if (bookerBox.Text.Length >= Database.BUFFER_SIZE)
            {
                MessageBox.Show("Booker name to long.");
                return false;
            }

            if (noteBox.Text.Length >= 400)
            {
                MessageBox.Show("Notes to long.");
                return false;
            }

            /*if (emailBox.Text == "")
            {
                var dialogResult = MessageBox.Show("Email is missing. Continue?", "Missing email", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return false;
            }*/

            return true;
        }

        /* Save button clicked */
        private void button1_Click(object sender, EventArgs e)
        {
            if (!sanetyCheck())
            {
                return;
            }                

            if (cleaningCheckBox.Checked)
            {
                noteBox.Text += (noteBox.Text == "") ? "(End Cleaning)" : "\n(End Cleaning)";
            }

            Cursor.Current = Cursors.WaitCursor;
            bool success;
            if (cid == Database.DEFAULT_CUSTOMER)
                success = insert_New_Customer();
            else
                success = update_Customer();
            Cursor.Current = Cursors.Default;
            if (success)
            {
                Database.set(string.Format("insert into alerts values (NULL, {0}, 'booking', '{1}');", bid, DateTime.Now.ToString("yyyy-MM-dd")));

                var report = Report.booking_Confirmation(bid, false);
                var viewer = new ReportViewer(report);                

                viewer.ShowDialog();

                prevForm.set_Done();

                this.Close();
            }
        }

        /* Find existing customer */
        private void button2_Click(object sender, EventArgs e)
        {
            Find_customer form = new Find_customer(this);
            form.ShowDialog();
            var query = string.Format("update bookings set cid = {0} where bid = {1};", cid, bid);
            Database.set(query);
            fill_info();
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            var curserPos = nameBox.SelectionStart;
            nameBox.Text = toNameString(nameBox.Text);
            nameBox.SelectionStart = curserPos;
            nameBox.SelectionLength = 0;
        }

        private string toNameString(string s)
        {
            if (s == null || s.Length == 0)
                return "";

            string name = "";

            name += Char.ToUpper(s[0]); // First char to upper

            for (int i = 1; i < s.Length; i++)
            {
                name += s[i];
                if (s[i] == ' ')
                {
                    i++;
                    if (i < s.Length)
                    {
                        name += Char.ToUpper(s[i]); // First char in new word
                    }
                }
            }

            return name;
        }
    }
}
