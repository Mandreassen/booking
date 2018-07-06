using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace arctic_seasport_admin
{
    static class Database
    {
        public const int DEFAULT_CUSTOMER = 1;
        public const int BUFFER_SIZE = 45;
            
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


        /* Run mysqldump and backup database */
        static public void backup_Database(string path)
        {
            Process p = new Process();
            string output;

            if (!File.Exists(Properties.Settings.Default.BacupAppLoc))
            {
                MessageBox.Show("Backup application not installed. Please install MariaDB 10.1");
                return;
            }

            string command = string.Format("-e --user={0} --password={1} --host={2} --protocol=tcp --port={3} --default-character-set=utf8 --single-transaction=TRUE {4}",
                Properties.Settings.Default.UserID,
                Properties.Settings.Default.Password,
                Properties.Settings.Default.Server,
                Properties.Settings.Default.Port,
                Properties.Settings.Default.Database);

            // Config process
            p.StartInfo.FileName = Properties.Settings.Default.BacupAppLoc;
            p.StartInfo.Arguments = command;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;

            try
            {
                p.Start();
                output = p.StandardOutput.ReadToEnd();
                File.WriteAllText(path, output);
                MessageBox.Show("Backup complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            p.WaitForExit();
        }
    }
}
