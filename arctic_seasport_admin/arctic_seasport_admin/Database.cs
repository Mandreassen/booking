using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace arctic_seasport_admin
{
    static class Database
    {
        public const int DEFAULT_CUSTOMER = 1;
            
        /* Gets single value from database.
         * Value is returned as a string.
         * Query must request a single value.
         * If error, null is returned */
        static public string get_Value(string query)
        {
            MySqlConnection conn = new MySqlConnection(Config.connString);
            MySqlCommand command = conn.CreateCommand();
            MySqlDataReader reader;
            command.CommandText = query;
            string retval;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null; // Error
            }

            try
            {
                reader = command.ExecuteReader();
                reader.Read();
                retval = reader[0].ToString();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                retval = null;
            }
            
            conn.Close();

            return retval; // Success
        }


        /* Put data into database
         * Returns:
         * - true if success
         * - false if error */
        static public bool set(string query)
        {
            MySqlConnection conn = new MySqlConnection(Config.connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false; // Error
            }

            MySqlTransaction trans = conn.BeginTransaction();

            try
            {                              
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                conn.Close();
                return false; // Error
            }

            conn.Close();

            return true; // Success
        }


        static public bool book_dates(List<DateTime> dates, string bid, string roID)
        {
            MySqlConnection conn = new MySqlConnection(Config.connString);
            MySqlCommand command = conn.CreateCommand();
            MySqlDataReader reader;
            string count, blid;
            //command.CommandText = query;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false; // Error
            }

            MySqlTransaction trans = conn.BeginTransaction();

            // Insert booking_line
            try
            {
                command.CommandText = string.Format("insert into booking_lines values (NULL, {0}, \'{1}\', \'{2}\');select last_insert_id();", bid, dates.First().ToString("yyyy-MM-dd"), dates.Last().AddDays(1).ToString("yyyy-MM-dd"));
                reader = command.ExecuteReader();
                reader.Read();
                blid = reader[0].ToString();
                reader.Close();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                conn.Close();
                return false; // Error
            }


            // insert booking_entries
            foreach (var date in dates)
            {               
                try
                {
                    // Set database
                    command.CommandText = string.Format("insert into booking_entries values (NULL, {0}, {1}, \'{2}\');", blid, roID, date.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();

                    // Get validation count
                    command.CommandText = string.Format("select count(roID) - (select count(roID) from booking_entries natural join rent_object_types where roID = {0} and Date = \'{1}\') from rent_objects natural join rent_object_types where roID = {0};", roID, date.ToString("yyyy-MM-dd"));
                    reader = command.ExecuteReader();
                    reader.Read();
                    count = reader[0].ToString();
                    reader.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message);
                    conn.Close();
                    return false; // Error
                }

                // Validate insert
                if (Int32.Parse(count) < 0)
                {
                    trans.Rollback();
                    conn.Close();
                    return false; // Error
                }

            }

            trans.Commit();

            conn.Close();

            return true; // Success
        }


        /* Generate DataSet from multi column select */
        static public DataSet get_DataSet(string query)
        {
            MySqlConnection conn = new MySqlConnection(Config.connString);
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null; // Error
            }

            try
            {
                da.Fill(ds, "data");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return null; // Error
            }            

            conn.Close();

            return ds; // Success
        }


        /* Generate list from single column select */
        static public List<string> get_List(string query)
        {
            List<string> list = new List<string>();

            MySqlConnection conn = new MySqlConnection(Config.connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = query;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; // Error
            }

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader[0].ToString());
            }

            conn.Close();

            list.Sort();

            return list; // Success
        }


        /* Generate dict from double column select */
        static public Dictionary<string, string> get_Dict(string query)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            MySqlConnection conn = new MySqlConnection(Config.connString);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = query;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; // Error
            }

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dict.Add(reader[0].ToString(), reader[1].ToString());
            }

            conn.Close();

            return dict; // Success
        }
    }
}
