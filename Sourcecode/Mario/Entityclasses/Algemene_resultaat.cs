using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Entityclasses
{
    public static class Algemene_resultaat
    {
        private static int id;
        public static int Id { get { return id; } set { id = value; } }

        private static int munten;
        public static int Munten { get { return munten; } set { munten = value; } }

        private static int levens;
        public static int Levens { get { return levens; } set { levens = value; } }

        private static string save_level;
        public static string Save_level { get { return save_level; } set { save_level = value; } }
    }
}
