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
                select bookingDate, name, email, address, postnr, postlocation, phone, country, company, notes, persons, booker
                from bookings
                natural join customers
                where bid = {0};
            ", bid)).Tables[0].Rows[0];

            string bDate     = data[0].ToString();
            string name      = data[1].ToString();
            string email     = data[2].ToString();
            string address   = data[3].ToString();
            string postnr    = data[4].ToString();
            string pLocation = data[5].ToString();
            string tlf       = data[6].ToString();
            string country   = data[7].ToString();
            string company   = data[8].ToString();
            string note      = data[9].ToString().Replace("\n", "<br>");
            string persons   = data[10].ToString();
            string booker    = data[11].ToString();

            string price = adapter.get_Value(string.Format("select sum(price) from booking_lines natural join booking_entries natural join rent_object_types where bid = {0};", bid));
            var transfer = adapter.get_DataSet(string.Format(@"
                select arrivalTime, arrivalFlight, departureTime, departureFlight, personsTransfer
                from transfers
                where bid = {0}
                ;", bid));

            DataSet details = adapter.get_DataSet(string.Format(@"
                select description, startDate, endDate, count(beid) 
                from booking_lines 
                natural join booking_entries 
                natural join rent_object_types 
                where bid = {0} 
                group by blid;", bid)
            );

            // BEGIN REPORT
            var report = @"
                <!DOCTYPE html>
                <html>
                <body>              
            ";

            if (company == "Kingfisher")
            {
                report += @"                
                    <style>
                    .logo {
                        float: left;
                        position: absolute;
                    }

                    .kingfisher {
                        text-align: right;
                    </style>             

                    <div class=""logo""> <img src=""http://www.arctic-seasport.no/img/logo_300.jpg"" alt=""Logo""> </div>
                    <div class=""kingfisher""> <img src=""http://www.kingfisher-angelreisen.de/fileadmin/templates_kingfisher-angelreisen.de/global_gfx/logo-kingfisher.png"" alt=""kingfisher"" height=""73""> </div>
                ";
            }
            else if (company == "Arctic-Adventure")
            {
                report += @"                
                    <style>
                    .logo {
                        float: left;
                        position: absolute;
                    }

                    .kingfisher {
                        text-align: right;
                    </style>             

                    <div class=""logo""> <img src=""http://www.arctic-seasport.no/img/logo_300.jpg"" alt=""Logo""> </div>
                    <div class=""kingfisher""> <img src=""http://www.arcticadventure.se/AA_logga_webb_wp.png"" alt=""kingfisher"" height=""73""> </div>
                ";
            }
            else if (company == "Angelreisen_Hamburg")
            {
                report += @"                
                    <style>
                    .logo {
                        float: left;
                        position: absolute;
                    }

                    .kingfisher {
                        text-align: right;
                    </style>             

                    <div class=""logo""> <img src=""http://www.arctic-seasport.no/img/logo_300.jpg"" alt=""Logo""> </div>
                    <div class=""kingfisher""> <img src=""https://www.angelreisen.de/fileadmin/ang/template/img/logo.png"" alt=""kingfisher"" height=""73""> </div>
                ";
            }
            else if (company == "Angelreisen_K-N")
            {
                report += @"                
                    <style>
                    .logo {
                        float: left;
                        position: absolute;
                    }

                    .kingfisher {
                        text-align: right;
                    </style>             

                    <div class=""logo""> <img src=""http://www.arctic-seasport.no/img/logo_300.jpg"" alt=""Logo""> </div>
                    <div class=""kingfisher""> <img src=""http://www.arctic-seasport.no/img/angelreisen_k-n.jpg"" alt=""kingfisher"" height=""73""> </div>
                ";
            }
            else
            {
                report += @"
                    <img src=""http://www.arctic-seasport.no/img/logo_300.jpg"" alt=""Logo"">                    
                ";
            }

  
            report += string.Format(@"
                <br>
                <font size=""6"" face=""calibri""> 
                    <b>Booking confirmation</b> 
                </font>

                <br>

                    <font size=""3.5"" face=""calibri"">
                    <table cellspacing=""0"">
                        <tr>
                            <td> Booking date: </td>  <td> &nbsp; {0} </td> <td> &nbsp; Booking reference: </td> <td> &nbsp; {1} </td>
                        </tr>

                        <tr>
                            <td> Booker: </td> <td> &nbsp; {2} </td> <td> &nbsp; Number of guests: </td> <td> &nbsp; {3} </td>
                        </tr>
                        <tr>
                            <td> &nbsp; </td> <td> &nbsp; </td>
                        </tr>

                        ", DateTime.Parse(bDate).ToString("dd.MM.yyy"), bid.ToString(), booker, persons);

            if (name != "")
            {
                report += string.Format(@"
                    <tr>
                        <td> Booking name: </td>  <td> &nbsp; {0} </td>
                    </tr>        
                ", name);
            }

            if (email != "")
            {
                report += string.Format(@"
                    <tr>
                        <td> E-mail: </td>  <td> &nbsp; {0} </td>
                    </tr>        
                ", email);
            }

            if (tlf != "")
            {
                report += string.Format(@"
                    <tr>
                        <td> Phone: </td>  <td> &nbsp; {0} </td>
                    </tr>        
                ", tlf);
            }

            if (address != "")
            {
                report += string.Format(@"
                    <tr>
                        <td> Address: </td>  <td> &nbsp; {0} </td>
                    </tr>        
                ", address);
            }

            if (postnr != "" && pLocation != "")
            {
                report += string.Format(@"
                    <tr>
                        <td> Zip: </td>  <td> &nbsp; {0} </td>
                    </tr>        
                ", postnr + " " + pLocation);
            }

            if (country != "")
            {
                report += string.Format(@"
                    <tr>
                        <td> Country: </td>  <td> &nbsp; {0} </td>
                    </tr>        
                ", country);
            }

            report += @"
                </table>
                </font>
                <br>                    
                <font size=""4"" face=""calibri"">
                        <b>Details</b>
                    </font>"
                ;

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
                        border-bottom: 1px solid #444092;
                    }

                    </style>

                    <font face=""calibri"">
                    <table>
                      <tr>
                        <th>Object</th>
                        <th>From</th>
                        <th>To</th>
                        <th>Days</th>
                      </tr>                    
            ";

            DataTable table = details.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                report += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3} </td> </tr>", row[0], ((DateTime) row[1]).ToString("dd.MM.yyyy"), ((DateTime)row[2]).ToString("dd.MM.yyyy"), row[3]);              
            }

            report += "</table> </font>";

            // Price
            if (display_price)
            {
                report += string.Format(@"
                    <br>
                    <font size=""3"" face=""calibri"">                  
                        <div align=""left""> SUM: NOK {0},- </div>
                    </font>  
                ", price);
            }

            
            // Transfer
            if (transfer.Tables[0].Rows.Count > 0)
            {
                report += string.Format(@"
                    <br>
                    <br>

                    <font size=""4"" face=""calibri"">
                        <b>Transfer</b>
                    </font>

                    <font face=""calibri"">
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

                report += "</table> </font>";
            }


            // Notes
            if (note != "")
            {
                report += string.Format(@"
                    <br>
                    <br>                      

                    <font size=""4"" face=""calibri"">
                        <b>Notes</b>
                    </font>

                    <hr color=""#444092"" size=""1px"">                     

                    <font size=""3"" face=""calibri"">
                        {0}
                    </font>
                ", note);
            }


            // Footer
            //<hr color=""#eff181"" size=""1px"">
            //<hr color = ""#444092"" size=""1px"">
            report += @"            
                <br>
                <br>
                <br>
                <br>


                
                
                <center>
                    <font size=""3"" face=""calibri"" color=""#444092"">
                        <b>Check inn: 14:00 - 23:00 <br>
                        Check out: before 12:00 <br></b>
                        <br>
                    </font>
                        
                        <font size=""3"" face=""calibri"">
                        Please contact us in advance if your arrival is later than 23:00.                    
                        Bed sheets and towels can be rented at Arctic Seasport.
                        For more information please visit <b>www.arctic-seasport.no</b>.

                        
        
                        


                        <hr color=""#444092"" size=""1px"">
                        <br>
                    

                        Nord-Norsk sjøsportsenter AS, Naurstad 8050 Tverlandet, Norway <br>
                        Phone: <b>+47 916 05 007</b> &nbsp; E-mail: <b>info@arctic-seasport.no</b>
                        


                    </font>
                </center>

                </body>
                </html>";
            // END REPORT


            adapter.close();
            Cursor.Current = Cursors.Default;

            return report;
       }


        
        static public string arrivals(int numberOfDays)
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
                <div class=""arrival""> <img src=""http://www.arctic-seasport.no/img/arrival.jpg"" alt=""arrival"" height=""60"" width=""81""> </div>
                <br>

                <font size=""6"" face=""calibri""> <b>Arrivals</b> </font>

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

            DateTime date = DateTime.Now;
            for (int i = 0; i < numberOfDays; i++)
            {
                var nextDay = string.Format(@"
                    <br>
                    <br>

                    <font size='4' face=""calibri""> <b>{0}</b> </font>

                    <font size=""3"" face=""calibri"">
                    <table id='t01'>
                      <tr>
                        <th>BID</th>
                        <th>Description</th>
                        <th>Name</th>
                        <th>Ppl.</th>
                        <th>Country</th> 
                        <th>Notes</th> 
                        <th>Transfer</th>                     
                      </tr>
                ", first_To_Upper(date.AddDays(i).ToString("dddd dd.MM.yyy")));

                var lines = adapter.get_DataSet(string.Format(@"
                    select startDate, bookings.bid, description, name, persons, country, notes, DATE_FORMAT(arrivalTime, '%k:%i')
                    from customers
                    natural join bookings
                    natural join booking_lines
                    natural join booking_entries
                    natural join rent_object_types
                    left outer join transfers on transfers.bid = bookings.bid
                    group by blid
                    having startDate = '{0}'
                    order by bid
                    ;", date.AddDays(i).ToString("yyyy-MM-dd")));

                DataTable table = lines.Tables[0];
                if (table.Rows.Count == 0)
                    continue;

                foreach (DataRow row in table.Rows)
                {
                    nextDay += string.Format(@"<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3} </td> <td> {4} </td> <td> {5} </td> <td> {6} </td> </tr>
                                                ", row[1], row[2], row[3], row[4], row[5], row[6].ToString().Replace("\n", "<br>"), (row[7].ToString() == "") ?  "-" : row[7]);
                }

                report += nextDay;
                report += "</table> </font>";
            }

            report += @"
                </body>
                </html>
            ";

            adapter.close();
            Cursor.Current = Cursors.Default;

            return report;
        }

        
        static string first_To_Upper(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }


        static public string departures(int numberOfDays)
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
                <div class=""arrival""> <img src=""http://www.arctic-seasport.no/img/departure.jpg"" alt=""arrival"" height=""60"" width=""85""> </div>
                <br>

                <font size=""6"" face=""calibri""> <b>Departures</b> </font>

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

            DateTime date = DateTime.Now;
            for (int i = 0; i < numberOfDays; i++)
            {
                var nextDay = string.Format(@"
                    <br>
                    <br>

                    <font size='4' face=""calibri""> <b>{0}</b> </font>

                    <font size='3' face=""calibri"">
                    <table id='t01'>
                      <tr>
                        <th>BID</th>
                        <th>Object</th>
                        <th>Description</th>
                        <th>Name</th>
                        <th>Ppl.</th>
                        <th>Country</th> 
                        <th>Notes</th>  
                        <th>Transfer</th>                     
                      </tr>
                ", first_To_Upper(date.AddDays(i).ToString("dddd dd.MM.yyy")));

                var lines = adapter.get_DataSet(string.Format(@"
                    select blid, endDate, bookings.bid, description, name, persons, country, notes, DATE_FORMAT(departureTime, '%k:%i')
                    from customers
                    natural join bookings
                    natural join booking_lines
                    natural join booking_entries
                    natural join rent_object_types
                    left outer join transfers on transfers.bid = bookings.bid
                    group by blid
                    having endDate = '{0}'
                    order by bid
                    ;", date.AddDays(i).ToString("yyyy-MM-dd")));

                DataTable table = lines.Tables[0];
                if (table.Rows.Count == 0)
                    continue;

                foreach (DataRow row in table.Rows)
                {
                    string ro = adapter.get_Value(string.Format("select name from rent_objects where currentUser = {0};", row[0]));
                    if (ro == null || ro == "")
                        ro = "-";
                    nextDay += string.Format(@"<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3} </td> <td> {4} </td> <td> {5} </td> <td> {6} </td> <td> {7} </td> </tr>
                                                ", row[2], ro, row[3], row[4], row[5], row[6], row[7].ToString().Replace("\n", "<br>"), (row[8].ToString() == "") ? "-" : row[8]);
                }

                report += nextDay;
                report += "</table> </font>";
            }

            report += @"
                </body>
                </html>
            ";

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

                <font size=""6"" face=""calibri""> <b>Transfers</b> </font>

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

                <font size=""3"" face=""calibri"">
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

            report += "</table> </font>";            

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
            var total = adapter.get_Value(string.Format(@"
                select count(DISTINCT bid) 
                from bookings
                natural join booking_lines
                natural join booking_entries                
                where date >= '{0}';
            ", DateTime.Now.ToString("yyyy-MM-dd")));

            var report = @"
                <!DOCTYPE html>
                <html>
                <body>

                <img src=""http://www.arctic-seasport.no/img/logo_300.jpg"" alt=""Logo"">
                <br>
            ";

            report += string.Format(@"
                <font size=""4"" face=""calibri""> <b>Bookings total: {0}</b> </font>
            ", total);

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
                
                <font size=""3"" face=""calibri"">
                <table id='t01'>
                    <tr>
                    <th>BID</th>
                    <th>Name</th>
                    <th>Persons</th>  
                    <th>From</th>
                    <th>To</th>
                    <th>Type</th>
                    <th>Agent</th>
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
                group by blid
                order by startDate, bookings.bid;
                ", DateTime.Now.ToString("yyyy-MM-dd"))
            );

            DataTable table = lines.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                report += string.Format(@"<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> <td> {3} </td> <td> {4} </td> <td> {5} </td> <td> {6} </td> <td> {7} </td> <td> {8} </td> <td> {9} </td> </tr>
                                            ", row[0], row[1], row[2], DateTime.Parse(row[3].ToString()).ToString("dd.MM.yyyy"), DateTime.Parse(row[4].ToString()).ToString("dd.MM.yyyy"), row[5], row[6], (row[7].ToString() != "") ? DateTime.Parse(row[7].ToString()).ToString("HH:mm") : "-", (row[8].ToString() != "") ? DateTime.Parse(row[8].ToString()).ToString("HH:mm") : "-", row[9].ToString().Replace("\n", "<br>"));
            }

            report += "</table> </font>";

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
