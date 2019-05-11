using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario
{
    public class Enemy
    {
        /// <summary>
        ///  boolean om te kijken welke afbeelding er moet doorgaan om te bewegen
        ///    - in goombas geval loopt hij de heletijd links naar rechts (voet links voet rechts omhoog)
        ///    - in koopas geval loopt hij gewoon of links of rechts(zeikant van goomba links of rechts)
        /// </summary>
        bool blImgLoop;

        /// <summary>
        ///  boolean om te kijken of de enemy naar links of rechts moet lopen
        /// </summary>
        bool blLopenLinks = false;


        public bool blDood = false;
        public bool blVerdwijn = false;

        public bool BlLopenLinks{ get { return blLopenLinks; } set { blLopenLinks = value; } }

        Image image;
        public Image Image { get { return image; } }

        string naam;
        public string Naam { get { return naam; } }

        int x;
        int y;

        public Enemy()
        {
            naam = "Koopa";
            x = 0;
            y = 0;
        }

        public Enemy(string naam, int x, int y)
        {
            this.naam = naam;
            this.x = x;
            this.y = y;
        }

        public int lopen()
        {
            if (blLopenLinks)
            {
                x = x - 3;
            }
            else
            {
                x = x + 3;
            }

            return x;
        }

        public void dood()
        {
            if (naam == "Goomba")
            {
                image = Properties.Resources.goomba_dood;
                blDood = true;
            }
            else if (naam == "Koopa")
            {
                image = Properties.Resources.schild_midden;
                naam = "Schild";
            }
            else if (naam == "Schild")
            {
                image = Properties.Resources.schild_midden;
                blDood = true;
            }
        }

        public void veranderImage()
        {
            if (blImgLoop && naam == "Goomba") //voetje links
            {
                image = Properties.Resources.goomba_links_loop;
                blImgLoop = false;
            }
            else if(!blImgLoop && naam == "Goomba") //voetje rechts
            {
                image = Properties.Resources.goomba_rechts_loop;
                blImgLoop = true;
            }

            else if (BlLopenLinks && naam == "Koopa") //links lopen
            {
                if (blImgLoop) //lopen mond open of links staan
                {
                    image = Properties.Resources.koopa_links;
                    blImgLoop = false;
                }
                else
                {
                    image = Properties.Resources.koopa_links_loop;
                    blImgLoop = true;
                }
            }
            else if (!BlLopenLinks && naam == "Koopa")
            {
                if (blImgLoop) //lopen mond open of rechts staan
                {
                    image = Properties.Resources.koopa_rechts;
                    blImgLoop = false;
                }
                else
                {
                    image = Properties.Resources.koopa_rechts_loop;
                    blImgLoop = true;
                }
            }

            if (blImgLoop && naam == "Schild") //voetje links
            {
                image = Properties.Resources.schild_links;
                blImgLoop = false;
            }
            else if (!blImgLoop && naam == "Schild") //voetje rechts
            {
                image = Properties.Resources.schild_rechts;
                blImgLoop = true;
            }
        }

        public override string ToString()
        {
            return naam.ToString();
        }
    }
}
