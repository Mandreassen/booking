﻿using System;
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

            string bDate   = adapter.get_Value(string.Format("select bookingDate from bookings where bid = {0}", bid));
            string name    = adapter.get_Value(string.Format("select name from bookings natural join customers where bid = {0};", bid));
            string email   = adapter.get_Value(string.Format("select email from bookings natural join customers where bid = {0};", bid));
            string tlf     = adapter.get_Value(string.Format("select phone from bookings natural join customers where bid = {0};", bid));
            string country = adapter.get_Value(string.Format("select country from bookings natural join customers where bid = {0};", bid));
            string note    = adapter.get_Value(string.Format("select notes from bookings where bid = {0};", bid)).Replace("\n", "<br>");
            string price   = adapter.get_Value(string.Format("select sum(price) from booking_lines natural join booking_entries natural join rent_object_types where bid = {0};", bid));
            string persons = adapter.get_Value(string.Format("select persons from bookings where bid = {0}", bid));

            DataSet details = adapter.get_DataSet(string.Format("select description, startDate, endDate from booking_lines natural join booking_entries natural join rent_object_types where bid = {0} group by blid;", bid));

            // BEGIN REPORT
            var report = string.Format(@"
                <!DOCTYPE html>
                <html>
                <body>              

                <img src=""http://www.arctic-seasport.no/img/logo_300.jpg"" alt=""Logo"">
                
                    <br>

                <font size=""6""> Booking confirmation </font>    

                <br>
                <br
                <br>           

                <font size=""4"">
                    Date: {0} <br>
                    Booking reference: {1} <br>
                    Persons: {2} <br>
                    <br>
                    {3} 
                    {4} 
                    {5}
                    {6}
                </font>            

                <br>
            
                <font size=""5"">
                    Details
                </font>
               
                ", DateTime.Parse(bDate).ToString("dd.MM.yyy"), bid.ToString(), persons, (name != "") ? name + "<br>" : "", (email != "") ? email + "<br>" : "", (tlf != "") ? tlf + "<br>" : "", (country != "") ? country + "<br>" : "");
            

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
                report += string.Format("<tr> <td> {0} </td> <td> {1} </td> <td> {2} </td> </tr>", row[0], ((DateTime) row[1]).ToString("dd.MM.yyyy"), ((DateTime)row[2]).ToString("dd.MM.yyyy"));              
            }

            report += "</table>";

            // Price
            if (display_price)
            {
                report += string.Format(@"
                    <br>
                    <font size=""4"">                  
                        <div align=""left""> SUM: NOK {0},- </div>
                    </font>  
                ", price);
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


        
        static public string arrivals()
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

                <font size=""6""> Arrivals </font>

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
            for (int i = 0; i < 4; i++)
            {
                var nextDay = string.Format(@"
                    <br>
                    <br>

                    <font size='4'> Date: {0} </font>

                    <table id='t01'>
                      <tr>
                        <th>BID</th>
                        <th>Description</th>
                        <th>Name</th>
                        <th>Phone</th>
                        <th>Country</th> 
                        <th>Notes</th> 
                        <th>Transfer</th>                     
                      </tr>
                ", date.AddDays(i).ToString("dd.MM.yyy"));

                var lines = adapter.get_DataSet(string.Format(@"
                    select startDate, bookings.bid, description, name, phone, country, notes, DATE_FORMAT(arrivalTime, '%k:%i')
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
                report += "</table>";
            }

            report += @"
                </body>
                </html>
            ";

            adapter.close();
            Cursor.Current = Cursors.Default;

            return report;
        }


        static public string departures()
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

                <font size=""6""> Departures </font>

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
            for (int i = 0; i < 4; i++)
            {
                var nextDay = string.Format(@"
                    <br>
                    <br>

                    <font size='4'> Date: {0} </font>

                    <table id='t01'>
                      <tr>
                        <th>BID</th>
                        <th>Object</th>
                        <th>Description</th>
                        <th>Name</th>
                        <th>Phone</th>
                        <th>Country</th> 
                        <th>Notes</th>  
                        <th>Transfer</th>                     
                      </tr>
                ", date.AddDays(i).ToString("dd.MM.yyy"));

                var lines = adapter.get_DataSet(string.Format(@"
                    select blid, endDate, bookings.bid, description, name, phone, country, notes, DATE_FORMAT(departureTime, '%k:%i')
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
                report += "</table>";
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

    }
}
