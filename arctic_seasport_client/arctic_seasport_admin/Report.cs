using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace arctic_seasport_admin
{
    static class Report
    {
        static public string booking_Confirmation(int bid, bool display_price = true)
        {
            Cursor.Current = Cursors.WaitCursor;
            var adapter = new Database_adapter();

            var data = adapter.get_DataSet(string.Format(@"
                select bookingDate, name, email, address, postnr, postlocation, phone, country, company, notes, persons
                from bookings
                natural join customers
                where bid = {0};
            ", bid)).Tables[0].Rows[0];

            string bDate = data[0].ToString();
            string name = data[1].ToString();
            string email = data[2].ToString();
            string address = data[3].ToString();
            string postnr = data[4].ToString();
            string pLocation = data[5].ToString();
            string tlf = data[6].ToString();
            string country = data[7].ToString();
            string company = data[8].ToString();
            string note = data[9].ToString().Replace("\n", "<br>");
            string persons = data[10].ToString();

            var transfer = adapter.get_DataSet(string.Format(@"
                select arrivalTime, arrivalFlight, departureTime, departureFlight, personsTransfer
                from transfers
                where bid = {0}
                ;", bid));


            DataSet details = adapter.get_DataSet(string.Format("select description, startDate, endDate from booking_lines natural join booking_entries natural join rent_object_types where bid = {0} group by blid;", bid));

            // BEGIN REPORT
            var report = @"
                <!DOCTYPE html>
                <html>
                <body> 

                <style>
                .logo {
                    float: left;
                    position: absolute;
                }

                .kingfisher {
                    text-align: right;
                </style>             
                <div class=""logo""> <img src=""http://www.arctic-seasport.no/img/logo_300.jpg"" alt=""Logo""> </div>
            ";

            report += string.Format(@"
                <div class=""kingfisher""> <img src=""{0}"" alt=""kingfisher"" height=""73""> </div>
            ", Properties.Settings.Default.logo_src);

            report += @"
                <br>
                
                <font size=""6""> Booking </font>    

                <br>
                <br
                <br>           
            ";

            report += string.Format(@"
                <font size=""4"">
                    Date: {0} <br>
                    Booking reference: {1} <br>
                    Persons: {2} <br>
                    <br>
                    {3} 
                    {4} 
                    {5}
                    {6}
                    {7}
                    {8}
                </font>            

                <br>
            
                <font size=""5"">
                    Details
                </font>
               
                ", DateTime.Parse(bDate).ToString("dd.MM.yyy"),
                                  bid.ToString(), persons, (name != "") ? name + "<br>" : "",
                                  (email != "") ? email + "<br>" : "",
                                  (tlf != "") ? tlf + "<br>" : "",
                                  (address != "") ? address + "<br>" : "",
                                  (postnr != "" && pLocation != "") ? postnr + " " + pLocation + "<br>" : "",
                                  (country != "") ? country + "<br>" : "");

            // Booking lines
            report += @"
                    <style>
                    table {
                        width:100%;
                    }
                    table, th, td {
                        border-collapse: collapse;
                    }

                    th, td {
                        padding: 5px;
                        text-align: left;
                    }

                    table th {
                        border-bottom: 1px solid black;
                    }

                    </style>


                    <table>
                      <tr>
                        <th>Object</th>
                        <th>From</th>
                        <th>To</th>
                      </tr>                    
            ";

            DataTable table = details.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                report += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> </tr>", row[0], ((DateTime)row[1]).ToString("dd.MM.yyyy"), ((DateTime)row[2]).ToString("dd.MM.yyyy"));
            }

            report += "</table>";

            // Price
            /*if (display_price)
            {
                report += string.Format(@"
                    <br>
                    <font size=""4"">                  
                        <div align=""left""> SUM: NOK {0},- </div>
                    </font>  
                ", price);
            }*/


            // Transfer
            if (transfer.Tables[0].Rows.Count > 0)
            {
                report += string.Format(@"
                    <br>
                    <br>

                    <font size=""5"">
                        Transfer
                    </font>

                    <table id='t01'>
                        <tr>
                        <th>Arrival</th>
                        <th>Flight</th>
                        <th>Departure</th>
                        <th>Flight</th> 
                        <th>Persons</th>                     
                        </tr>
                ");

                table = transfer.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    report += string.Format(@"<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3} </td> <td> {4} </td> </tr>
                                            ", (row[0].ToString() != "") ? DateTime.Parse(row[0].ToString()).ToString("dd.MM.yyyy HH:mm") : "", row[1], (row[2].ToString() != "") ? DateTime.Parse(row[2].ToString()).ToString("dd.MM.yyyy HH:mm") : "", row[3], row[4]);
                }

                report += "</table>";
            }


            // Notes
            if (note != "")
            {
                report += string.Format(@"
                    <br>
                    <br>                      

                    <font size=""5"">
                        Notes
                    </font>

                    <hr>                      

                    <font size=""4"">
                        {0}
                    </font>
                ", note);
            }


            // Footer
            report += @"            
                <br>
                <br>
                <br>       
                <br>
                <br>
                <br>                

                <font size=""4"">
                    Arctic Seasport AS <br>
                    Naurstad <br>
                    8050 Tverlandet<br>
                    info@arctic-seasport.no <br>
                    +47 97666598
                </font>

                </body>
                </html>";
            // END REPORT


            adapter.close();
            Cursor.Current = Cursors.Default;

            return report;
        }


        static public string transfers()
        {
            Cursor.Current = Cursors.WaitCursor;
            var adapter = new Database_adapter();

            var report = @"
                <!DOCTYPE html>
                <html>
                <body>

                <style>
                .arrival {
                    text-align: center;

                }
                .logo {
                    float: left;
                    position: absolute;
                }
                
                </style>

                <div class=""logo""> <img src=""http://www.arctic-seasport.no/img/logo_300.jpg"" alt=""Logo""> </div>
                <div class=""arrival""> <img src=""http://www.arctic-seasport.no/img/transfer.jpg"" alt=""arrival"" height=""60"" width=""101""> </div>
                <br>

                <font size=""6""> Transfers </font>

                    <style>
                    table {
                        width:100%;
                    }
                    table, th, td {
                        border-collapse: collapse;
                    }

                    th, td {
                        padding: 5px;
                        text-align: left;
                    }

                    table th {
                        border-bottom: 1px solid black;
                    }
                    </style>
            ";

            report += string.Format(@"
                <br>
                <br>

                <table id='t01'>
                    <tr>
                    <th>BID</th>
                    <th>Name</th>
                    <th>Arrival</th>
                    <th>Flight</th>
                    <th>Departure</th>
                    <th>Flight</th> 
                    <th>Persons</th>                     
                    </tr>
            ");

            var lines = adapter.get_DataSet(string.Format(@"
                Select bid, name, arrivalTime, arrivalFlight, departureTime, departureFlight, personsTransfer
                from transfers
                natural join bookings
                natural join customers
                where arrivalTime >= '{0}'
                or departureTime >= '{0}'
                order by arrivalTime
                ;", DateTime.Now.ToString("yyyy-MM-dd")));

            DataTable table = lines.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                report += string.Format(@"<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3} </td> <td> {4} </td> <td> {5} </td> <td> {6} </td> </tr>
                                            ", row[0], row[1], (row[2].ToString() != "") ? DateTime.Parse(row[2].ToString()).ToString("dd.MM.yyyy HH:mm") : "", row[3], (row[4].ToString() != "") ? DateTime.Parse(row[4].ToString()).ToString("dd.MM.yyyy HH:mm") : "", row[5], row[6]);
            }

            report += "</table>";            

            report += @"
                </body>
                </html>
            ";

            adapter.close();
            Cursor.Current = Cursors.Default;

            return report;
        }


        static public string upcoming_Bookings()
        {
            Cursor.Current = Cursors.WaitCursor;
            var adapter = new Database_adapter();

            var report = @"
                <!DOCTYPE html>
                <html>
                <body>

                <style>
                .logo {
                    float: left;
                    position: absolute;
                }

                .kingfisher {
                    text-align: right;
                </style>             
    
                <div class=""logo""> <img src=""http://www.arctic-seasport.no/img/logo_300.jpg"" alt=""Logo""> </div>
            ";

            report += string.Format(@"
                <div class=""kingfisher""> <img src=""{0}"" alt=""kingfisher"" height=""73""> </div>
            ", Properties.Settings.Default.logo_src);               
 
             report += @"
                <style>
                table {
                    width:100%;
                }
                table, th, td {
                    border-collapse: collapse;
                }

                th, td {
                    padding: 5px;
                    text-align: left;
                }

                table th {
                    border-bottom: 1px solid black;
                }
                </style>
            ";

            report += string.Format(@"

                <table id='t01'>
                    <tr>
                    <th>BID</th>
                    <th>Name</th>
                    <th>Persons</th>  
                    <th>From</th>
                    <th>To</th>
                    <th>Type</th>
                    <th>Transfer A.</th>
                    <th>Transfer D.</th> 
                    <th>Notes</th>                                       
                    </tr>
            ");

            var lines = adapter.get_DataSet(string.Format(@"
                select bookings.bid, name, persons, startDate, endDate, description, company, arrivalTime, departureTime, notes
                from customers
                natural join bookings
                natural join booking_lines
                natural join booking_entries
                natural join rent_object_types
                left outer join transfers on transfers.bid = bookings.bid
                where date >= '{0}'
                and company = '{1}'
                group by blid
                order by startDate, bookings.bid;
                ", DateTime.Now.ToString("yyyy-MM-dd"), Properties.Settings.Default.company)
            );

            DataTable table = lines.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                report += string.Format(@"<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3} </td> <td> {4} </td> <td> {5} </td> <td> {6} </td> <td> {7} </td> <td> {8} </td> </tr>
                                            ", row[0], row[1], row[2], DateTime.Parse(row[3].ToString()).ToString("dd.MM.yyyy"), DateTime.Parse(row[4].ToString()).ToString("dd.MM.yyyy"), row[5], (row[7].ToString() != "") ? DateTime.Parse(row[7].ToString()).ToString("HH:mm") : "-", (row[8].ToString() != "") ? DateTime.Parse(row[8].ToString()).ToString("HH:mm") : "-", row[9].ToString().Replace("\n", "<br>"));
            }

            report += "</table>";

            report += @"
                </body>
                </html>
            ";

            adapter.close();
            Cursor.Current = Cursors.Default;

            return report;
        }

    }
}
