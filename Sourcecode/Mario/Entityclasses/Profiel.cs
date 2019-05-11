using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Entityclasses
{
    public static class Profiel
    {
        private static string naam;
        public static string Naam { get { return naam; } set { naam = value; } }

        private static int avatar;
        public static int Avatar { get { return avatar; } set { avatar = value; } }
    }
}
