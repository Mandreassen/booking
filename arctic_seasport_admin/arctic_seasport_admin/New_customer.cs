using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
                fill_Name_Box();
                fill_EmailBox();
                fill_PhoneBox();
                fill_CountryBox();
                fill_NoteBox();
            }
        }


        private void fill_Name_Box()
        {
            var query = string.Format("select Name from customers natural join bookings where bid = {0};", bid);
            string data = Database.get_Value(query);
            if (data != null)
            {
                nameBox.Text = data;
            }
        }


        private void fill_EmailBox()
        {
            var query = string.Format("select Email from customers natural join bookings where bid = {0};", bid);
            string data = Database.get_Value(query);
            if (data != null)
            {
                emailBox.Text = data;
            }
        }


        private void fill_PhoneBox()
        {
            var query = string.Format("select Phone from customers natural join bookings where bid = {0};", bid);
            string data = Database.get_Value(query);
            if (data != null)
            {
                phoneBox.Text = data;
            }
        }


        private void fill_CountryBox()
        {
            var query = string.Format("select Country from customers natural join bookings where bid = {0};", bid);
            string data = Database.get_Value(query);
            if (data != null)
            {
                countryBox.Text = data;
            }
        }


        private void fill_NoteBox()
        {
            var query = string.Format("select Notes from bookings where bid = {0};", bid);
            string data = Database.get_Value(query);
            if (data != null)
            {
                noteBox.Text = data;
            }
        }


        /* Insert new customer */
        private bool insert_New_Customer()
        {
            var query = string.Format("insert into customers values(NULL, \'{0}\', \'{1}\', \'{2}\', \'{3}\');select last_insert_id();", nameBox.Text, emailBox.Text, phoneBox.Text, countryBox.Text);
            string new_cid = Database.get_Value(query);
            if (new_cid == null)
                return false;

            query = string.Format("update bookings set cid = {0}, Notes = \'{1}\' where bid = {2};", new_cid, noteBox.Text, bid);
            bool status = Database.set(query);

            return status;
        }


        /* Update existing customer */
        private bool update_Customer()
        {
            // Update customer
            var query = string.Format("update customers set Name = \'{0}\', Email = \'{1}\', Phone = \'{2}\', Country = \'{3}\' where cid = {4};", nameBox.Text, emailBox.Text, phoneBox.Text, countryBox.Text, cid);
            bool success = Database.set(query);
            if (!success)
                return false;

            // Update notes
            query = string.Format("update bookings set Notes = \'{0}\' where bid = {1};", noteBox.Text, bid);
            success = Database.set(query);

            return success;
        }


        /* Save button clicked */
        private void button1_Click(object sender, EventArgs e)
        {
            bool success;
            if (cid == Database.DEFAULT_CUSTOMER)
                success = insert_New_Customer();
            else
                success = update_Customer();

            if (success)
            {
                Report.new_Booking(bid);

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
    }
}
