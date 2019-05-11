using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Entityclasses
{
    static class Spel
    {
        static private int id;
        static public int Id { get { return id; } set { id = value; } }

        static private int start_datetime;
        static public int Start_datetime { get { return start_datetime; } set { start_datetime = value; } }
    }
}
