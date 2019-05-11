using Mario.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Database
{
    class ResultaatDb
    {
        static SqlCommand cmd;
        public static void AanmakenResultaat(int munten, int tijd, int is_voltooid)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Resultaat VALUES(@munten, @tijd, @is_voltooid)";
            cmd.Parameters.AddWithValue("@munten", munten);
            cmd.Parameters.AddWithValue("@tijd", tijd);
            cmd.Parameters.AddWithValue("@is_voltooid", is_voltooid);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        public static int GetResultaatId()
        {
            int id = 0;
            DatabaseCon.CONN.Open();
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT TOP 1 * FROM dbo.Resultaat ORDER BY ID DESC";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id = (Convert.ToInt32(dr["id"]));
            }

            DatabaseCon.CONN.Close();
            return id;
        }
    }
}
