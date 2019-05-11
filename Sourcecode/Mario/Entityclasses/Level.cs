using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Entityclasses
{
    static class Level
    {
        private static int id;
        public static int Id { get { return id; } set { id = value; } }

        private static string naam;
        public static string Naam { get { return naam; } set { naam = value; } }

        private static int aantal_tijd;
        public static int Aantal_tijd { get { return aantal_tijd; } set { aantal_tijd = value; } }

        private static bool save_mogelijkheid;
        public static bool Save_mogelijkheid { get { return save_mogelijkheid; } set { save_mogelijkheid = value; } }
    }
}
