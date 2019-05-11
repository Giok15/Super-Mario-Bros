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
    class SpelDb
    {
        static SqlCommand cmd;

        //maakt voor de eerste keer een algemeen_resultaat aan voor een profiel
        public static void AanmakenSpel(DateTime dateTime)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Spel VALUES(@start_datetime, @fk_profiel_naam, @fk_resultaat_id, @fk_level_id)";
            cmd.Parameters.AddWithValue("@start_datetime", dateTime);
            cmd.Parameters.AddWithValue("@fk_profiel_naam", Profiel.Naam);
            cmd.Parameters.AddWithValue("@fk_resultaat_id", 0);
            cmd.Parameters.AddWithValue("@fk_level_id", Level.Id);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        public static void WijzigenSpel(int resultaat_id, int spel_id)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "UPDATE dbo.Spel SET Fk_resultaat_id = @Fk_resultaat_id WHERE id = " + spel_id;
            cmd.Parameters.AddWithValue("@Fk_resultaat_id", resultaat_id);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();    
        }

        public static DataTable GetSpelResultaten(string naam)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "SELECT s.start_datetime as Datum, l.naam as Wereld, r.munten As Munten, r.tijd as Tijd, r.is_voltooid" +
                               " FROM dbo.Spel s" +
                               " JOIN dbo.Resultaat r ON r.id = s.Fk_resultaat_id" +
                               " JOIN dbo.Level l ON l.id = s.Fk_level_id" +
                               " WHERE s.Fk_profiel_naam = '" + naam + "'" +
                               " ORDER BY s.start_datetime ASC";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();

            return dt;
        }

        public static int CountSpelResultaten(string naam)
        {
            int aantalSpellen = 0;
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "SELECT count(id) as count FROM dbo.Spel WHERE Fk_profiel_naam = '" + naam + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                aantalSpellen = Convert.ToInt32(dr["count"]);
            }
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();

            return aantalSpellen;
        }

        public static int GetSpelId()
        {
            int id = 0;
            DatabaseCon.CONN.Open();
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT TOP 1 * FROM dbo.Spel ORDER BY ID DESC";
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
