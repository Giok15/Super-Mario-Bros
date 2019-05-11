using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mario.DatabaseClasses
{
    public static class DatabaseCon
    {
        public static SqlConnection CONN = new SqlConnection();

        static string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Database\\DBMario.mdf";
        public static string CONNSTRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + path.Substring(6) + "';Integrated Security=True";

        /// <summary>
        /// kijkt of de connstring connectie is
        /// </summary>
        /// <returns>boolean of de connectie goed is of niet</returns>
        public static Boolean GetAndCheckConnectieString()
        {
            try
            {
                CONN.ConnectionString = CONNSTRING;
                CONN.Open();
                CONN.Close();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Database Error");
                return false;
            }
        }
    }
}
