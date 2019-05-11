using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    class Character
    {
        int x;
        int y;
        string naam;
        bool blImgLoop;
        string richting;
        bool blGesprongen;
        public bool blBlokkadeLinks;
        public bool blBlokkadeRechts;
        bool blDood;

        Image image;
        public Image Image { get { return image; } set { image = value; } }

        public bool BlGesprongen { get { return blGesprongen; } set { blGesprongen = value; } }
        public bool BlDood { get { return blDood; } set { blDood = value; } }

        public int X { get { return x; } }

        public int Y { get { return y; } set { y = value; } }

        public string Richting { get { return richting; }}

        public enum Grootte {
            klein,
            groot,
            superpower
        }

        public Grootte grootte;

        public Character()
        {
            naam = "Mario";
            x = 0;
            y = 0;
        }
        public Character(string naam, int x, int y)
        {
            this.naam = naam;
            this.x = x;
            this.y = y;
            grootte = Grootte.klein;
        }

        public void Geraakt(CharacterController cntCharacter)
        {
            if (grootte == Grootte.superpower)
            {
                grootte = Grootte.groot;
            }
            else if (grootte == Grootte.groot)
            {
                grootte = Grootte.klein;
            }
            else if (grootte == Grootte.klein)
            {
                blDood = true;
            }
        }

        public void Draaien(string keypress)
        {
            if (keypress == "Rechts")
            {
                if (grootte == Grootte.klein){image = Mario.Properties.Resources.mario_rechts;}
                if (grootte == Grootte.groot) { image = Mario.Properties.Resources.mario_groot_rechts; }
                if (grootte == Grootte.superpower) { image = Mario.Properties.Resources.mario_super_rechts; }

                richting = "Rechts";
                blImgLoop = false;
            }
            else
            {
                if (grootte == Grootte.klein) { image = Mario.Properties.Resources.mario_links; }
                if (grootte == Grootte.groot) { image = Mario.Properties.Resources.mario_groot_links; }
                if (grootte == Grootte.superpower) { image = Mario.Properties.Resources.mario_super_links; }

                richting = "Links";
                blImgLoop = false;
            }
        }

        public void Lopen(string keypress, Boolean Lucht = false)
        {
            if (Lucht)
            {
                if (keypress == "Rechts")
                {
                    if (grootte == Grootte.klein) { image = Mario.Properties.Resources.mario_omhoog_rechts; }
                    if (grootte == Grootte.groot) { image = Mario.Properties.Resources.mario_groot_omhoog_rechts; }
                    if (grootte == Grootte.superpower) { image = Mario.Properties.Resources.mario_super_omhoog_rechts; }

                    richting = "Rechts";
                    x += 2;
                }
                else if (keypress == "Links")
                {
                    if (grootte == Grootte.klein) { image = Mario.Properties.Resources.mario_omhoog_links; }
                    if (grootte == Grootte.groot) { image = Mario.Properties.Resources.mario_groot_omhoog_links; }
                    if (grootte == Grootte.superpower) { image = Mario.Properties.Resources.mario_super_omhoog_links; }

                    richting = "Links";
                    x -= 2;
                }
            }
            else
            {
                if (blImgLoop && richting == "Rechts" && !blBlokkadeRechts)
                {
                    if (grootte == Grootte.klein) { image = Mario.Properties.Resources.mario_rechts_loop; }
                    if (grootte == Grootte.groot) { image = Mario.Properties.Resources.mario_groot_rechts_loop; }
                    if (grootte == Grootte.superpower) { image = Mario.Properties.Resources.mario_super_rechts_loop; }

                    x += 4;
                    blImgLoop = false;
                }
                else if (!blImgLoop && richting == "Rechts" && !blBlokkadeRechts)
                {
                    if (grootte == Grootte.klein) { image = Mario.Properties.Resources.mario_rechts; }
                    if (grootte == Grootte.groot) { image = Mario.Properties.Resources.mario_groot_rechts; }
                    if (grootte == Grootte.superpower) { image = Mario.Properties.Resources.mario_super_rechts; }

                    x += 4;
                    blImgLoop = true;
                }
                else if (blImgLoop && richting == "Links" && !blBlokkadeLinks)
                {
                    if (grootte == Grootte.klein) { image = Mario.Properties.Resources.mario_links_loop; }
                    if (grootte == Grootte.groot) { image = Mario.Properties.Resources.mario_groot_links_loop; }
                    if (grootte == Grootte.superpower) { image = Mario.Properties.Resources.mario_super_links_loop; }

                    x -= 4;
                    blImgLoop = false;
                }
                else if (!blImgLoop && richting == "Links" && !blBlokkadeLinks)
                {
                    if (grootte == Grootte.klein) { image = Mario.Properties.Resources.mario_links; }
                    if (grootte == Grootte.groot) { image = Mario.Properties.Resources.mario_groot_links; }
                    if (grootte == Grootte.superpower) { image = Mario.Properties.Resources.mario_super_links; }

                    x -= 4;
                    blImgLoop = true;
                }
            }
        }
        public void Springen(int springHoogte)
        {
            if (richting == "Rechts")
            {
                if (grootte == Grootte.klein) { image = Mario.Properties.Resources.mario_omhoog_rechts; }
                if (grootte == Grootte.groot) { image = Mario.Properties.Resources.mario_groot_omhoog_rechts; }
                if (grootte == Grootte.superpower) { image = Mario.Properties.Resources.mario_super_omhoog_rechts; }
            }
            else
            {
                if (grootte == Grootte.klein) { image = Mario.Properties.Resources.mario_omhoog_links; }
                if (grootte == Grootte.groot) { image = Mario.Properties.Resources.mario_groot_omhoog_links; }
                if (grootte == Grootte.superpower) { image = Mario.Properties.Resources.mario_super_omhoog_links; }
            }


            if (springHoogte < y && !blGesprongen)
            {
                y -= 6;
            }
            else
            {
                blGesprongen = true;
            }
        }

        public override string ToString()
        {
            return "X: " + x.ToString() + " Y: " + y.ToString();
        }
    }
}
