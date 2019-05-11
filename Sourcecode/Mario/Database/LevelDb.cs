using Mario.DatabaseClasses;
using Mario.Entityclasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Database
{
    class LevelDb
    {
        static SqlCommand cmd;

        public static void GetLevel(int id)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.Level WHERE id ='" + id.ToString() + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Level.Id = Convert.ToInt32(dr["id"]);
                Level.Naam = Convert.ToString(dr["naam"]);
                Level.Aantal_tijd = Convert.ToInt32(dr["aantal_tijd"]);

                if (Convert.ToInt32(dr["Save_mogelijkheid"]) == 1)
                {
                    Level.Save_mogelijkheid = true;
                }
                else
                {
                    Level.Save_mogelijkheid = false;
                }
            }
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }
    }
}
