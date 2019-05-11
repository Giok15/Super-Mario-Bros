using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mario.DatabaseClasses;
using System.Data;
using Mario.Entityclasses;

namespace Mario.Database
{
    public static class ProfielDb
    {
        static SqlCommand cmd;

        //maakt voor de eerste keer een algemeen_resultaat aan voor een profiel
        public static void AanmakenAlgemeenResultaat(string profiel_naam)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Algemeen_resultaat VALUES(@munten, @levens, @save_level, @fk_profiel_naam)";
            cmd.Parameters.AddWithValue("@munten", 0);
            cmd.Parameters.AddWithValue("@levens", 3);
            cmd.Parameters.AddWithValue("@save_level", "1.0");
            cmd.Parameters.AddWithValue("@fk_profiel_naam", profiel_naam);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        //profiel wijzigen na een leven eraf etc
        public static void WijzigenAlgemeenResultaat()
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "UPDATE dbo.Algemeen_resultaat SET munten = @munten, levens = @levens, save_level = @save_level WHERE Id = " + Algemene_resultaat.Id;
            cmd.Parameters.AddWithValue("@munten", Algemene_resultaat.Munten);
            cmd.Parameters.AddWithValue("@levens", Algemene_resultaat.Levens);
            cmd.Parameters.AddWithValue("@save_level", Algemene_resultaat.Save_level);
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        //checkt of er een algemeen_resultaat bestaat voor het desbetreffende profiel
        public static void CheckResultaat(string profiel_naam)
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT id FROM dbo.algemeen_resultaat where fk_profiel_naam ='" + profiel_naam + "'";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();

            if (table.Rows.Count == 0)
            {
                AanmakenAlgemeenResultaat(profiel_naam);
            }
        }

        //krijg een overzicht van alle profielen !!!!!!!!!! waarsch niet meer nodig
        public static DataTable Overzicht()
        {
            DatabaseCon.CONN.Open();
            DataTable table = new DataTable();
            cmd = DatabaseCon.CONN.CreateCommand();
            String selectCommand1 = "SELECT p.naam, p.avatar, a.munten, a.levens, a.save_level FROM dbo.Profiel p, dbo.algemeen_resultaat a WHERE p.naam = a.fk_profiel_naam";
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(selectCommand1, DatabaseCon.CONNSTRING);
            dataAdapter1.Fill(table);

            DatabaseCon.CONN.Close();
            return table;
        }

        //zet de resultaten van het profiel in de class
        public static void GetResultaten(string accountNaam)
        {
            DatabaseCon.CONN.Open();
            cmd = DatabaseCon.CONN.CreateCommand();
            cmd.CommandText = "SELECT id, munten, levens, save_level FROM dbo.algemeen_resultaat WHERE fk_profiel_naam ='" + accountNaam + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Algemene_resultaat.Id = Convert.ToInt32(dr["id"]);
                Algemene_resultaat.Levens = Convert.ToInt32(dr["levens"]);
                Algemene_resultaat.Munten = Convert.ToInt32(dr["munten"]);
                Algemene_resultaat.Save_level = (dr["save_level"].ToString());
            }
            cmd.ExecuteNonQuery();
            DatabaseCon.CONN.Close();
        }

        //zet de account gegevens in de class
        public static void GetAccount(string accountNaam)
        {
            string line = "";
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\giova\AppData\Local\Packages\1acf27e1-4e83-48c7-a911-98e113841a2a_0f40devkehxf4\LocalState\file.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Split(',')[1] == accountNaam)
                {
                    Profiel.Avatar = Convert.ToInt32(line.Split(',')[0]);
                    Profiel.Naam = line.Split(',')[1];

                    break;
                }
            }
        }
    }
}
