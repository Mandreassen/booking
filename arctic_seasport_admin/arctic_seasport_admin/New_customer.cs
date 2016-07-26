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
using System.Net.Mail;

namespace arctic_seasport_admin
{
    public partial class New_customer : Form
    {
        private int bid;
        public int cid;
        private new_booking prevForm;
        List<string> countries;


        /* INIT */
        public New_customer(int set_bid, int set_cid, new_booking booker)
        {
            bid = set_bid;
            cid = set_cid;
            prevForm = booker;
            countries = new List<string>() { "Abkhasia", "Afghanistan", "Albania", "Algerie", "Andorra", "Angola", "Antigua og Barbuda", "Argentina", "Armenia", "Aserbajdsjan", "Australia", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belgia", "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia-Hercegovina", "Botswana", "Brasil", "Brunei", "Bulgaria", "Burkina", "Burundi", "Canada", "Chile", "Colombia", "Costa Rica", "Cuba", "Danmark", "Færøyene", "Grønland", "De forente arabiske emirater", "Kongo", "Den dominikanske republikk", "Den sentralafrikanske republikk", "Djibouti", "Dominica", "Ecuador", "Egypt", "Ekvatorial-Guinea", "Elfenbenskysten", "El Salvador", "Eritrea", "Estland", "Etiopia", "Fiji", "Filippinene", "Finland", "Frankrike", "Gabon", "Gambia", "Georgia", "Ghana", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Hellas", "Honduras", "Hviterussland", "India", "Indonesia", "Irak", "Iran", "Irland", "Island", "Israel", "Italia", "Jamaica", "Japan", "Jemen", "Jordan", "Kambodsja", "Kamerun", "Kapp Verde", "Kasakhstan", "Kenya", "Kina", "Kirgisistan", "Kiribati", "Komorene", "Kosovo", "Kroatia", "Kuwait", "Kypros", "Laos", "Latvia", "Lesotho", "Libanon", "Liberia", "Libya", "Liechtenstein", "Litauen", "Luxembourg", "Madagaskar", "Makedonia", "Malawi", "Malaysia", "Maldivene", "Mali", "Malta", "Marokko", "Marshalløyene", "Mauritania", "Mauritius", "Mexico", "Mikronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Mosambik", "Myanmar", "Namibia", "Nauru", "Nederland", "Nepal", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Nord-Korea", "Kypros", "Norge", "Oman", "Pakistan", "Palau", "Panama", "Papua Ny-Guinea", "Ny-Guinea", "Paraguay", "Peru", "Polen", "Portugal", "Qatar", "Romania", "Russland", "Rwanda", "Saint Kitts og Nevis", "Saint Lucia", "Saint Vincent", "Salomonøyene", "Samoa", "San Marino", "Saudi-Arabia", "Senegal", "Serbia", "Seychellene", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Somalia", "Spania", "Sri Lanka", "Storbritannia", "Sudan", "Surinam", "Sveits", "Sverige", "Swaziland", "Syria", "Sør-Afrika", "Sør-Korea", "Sør-Ossetia", "Sør-Sudan", "Tadsjikistan", "Taiwan", "Tanzania", "Thailand", "Togo", "Tonga", "Transnistria", "Trinidad og Tobago", "Tsjad", "Tsjekkia", "Tunisia", "Turkmenistan", "Tuvalu", "Tyrkia", "Tyskland", "Uganda", "USA", "Ukraina", "Ungarn", "Uruguay", "Usbekistan", "Vanuatu", "Vatikanstaten", "Venezuela", "Vietnam", "Zambia", "Zimbabwe" };

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
                fill_CountryBox(adapter);
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

        private void fill_CountryBox(Database_adapter adapter)
        {
            var query = string.Format("select Country from customers natural join bookings where bid = {0};", bid);
            string data = adapter.get_Value(query);
            if (data != null)
            {
                countryBox.Text = data;
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
            var query = string.Format("insert into customers values(NULL, \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\', NULL);select last_insert_id();", nameBox.Text, emailBox.Text, phoneBox.Text, addressBox.Text, postNrBox.Text, postLocation.Text, countryBox.Text);
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
            var query = string.Format("update customers set name = \'{0}\', email = \'{1}\', phone = \'{2}\', postnr = \'{3}\', postlocation = \'{4}\', country = \'{5}\' where cid = {6};", nameBox.Text, emailBox.Text, phoneBox.Text, postNrBox.Text, postLocation.Text, countryBox.Text, cid);
            bool success = Database.set(query);
            if (!success)
                return false;

            // Update notes
            query = string.Format("update bookings set Notes = \'{0}\', persons = {1}, booker = \'{2}\' where bid = {3};", noteBox.Text, nCustomers.Value, bookerBox.Text, bid);
            success = Database.set(query);

            return success;
        }


        private void mailer(string report, string recirver)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("mail.arctic-seasport.no");

                mail.From = new MailAddress("info@arctic-seasport.no");
                //mail.To.Add("post@mandreassen.no");
                mail.To.Add(recirver);
                mail.Subject = "Booking confirmation";
                
                mail.IsBodyHtml = true;
                mail.Body = report;

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("info@arctic-seasport.no", "123qwe!");
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Mail Sendt");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.ToString());
            }
        }

        private string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                return "";
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        private bool sanetyCheck()
        {
            if (nameBox.Text == "")
            {
                MessageBox.Show("Customer is missing");
                return false;
            }

            countryBox.Text = FirstCharToUpper(countryBox.Text);

            if (!countries.Contains(countryBox.Text))
            {
                MessageBox.Show("Invalid country");
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

            if (countryBox.Text.Length >= Database.BUFFER_SIZE)
            {
                MessageBox.Show("Country name to long.");
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

            if (emailBox.Text == "")
            {
                var dialogResult = MessageBox.Show("Email is missing. Continue?", "Missing email", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return false;
            }
            
            return true;
        }


        /* Save button clicked */
        private void button1_Click(object sender, EventArgs e)
        {
            if (!sanetyCheck())
                return;

            Cursor.Current = Cursors.WaitCursor;
            bool success;
            if (cid == Database.DEFAULT_CUSTOMER)
                success = insert_New_Customer();
            else
                success = update_Customer();
            Cursor.Current = Cursors.Default;
            if (success)
            {
                var report = Report.booking_Confirmation(bid, false);
                var viewer = new ReportViewer(report);                

                if (emailBox.Text != "")
                {                    
                    var dialogResult = MessageBox.Show(string.Format("Send booking confirmation to {0}?", emailBox.Text), "Mail confermation?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        mailer(report, emailBox.Text);
                    }
                }

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
