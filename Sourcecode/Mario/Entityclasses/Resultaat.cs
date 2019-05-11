using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Entityclasses
{
    static class Resultaat
    {
        static private int id;
        static public int Id { get { return id; } set { id = value; } }

        static private int punten;
        static public int Punten { get { return punten; } set { punten = value; } }

        static private int munten;
        static public int Munten { get { return munten; } set { munten = value; } }

        static private int tijd;
        static public int Tijd { get { return tijd; } set { tijd = value; } }

        static private int is_voltooid;
        static public int Is_voltooid { get { return is_voltooid; } set { is_voltooid = value; } }
    }
}
