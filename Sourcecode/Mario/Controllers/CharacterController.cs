using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario
{
    class CharacterController
    {
        int count;
        int springHoogte;
        bool blSpring;


        public void Character_interactie(Panel pnlMain, Character character, string keypressJump, string keypress, Timer character_interactie, Timer zwaartekracht, Timer vlag, PictureBox pbCharacter)
        {
            Character_Collision(pbCharacter, pnlMain, character, vlag, zwaartekracht, character_interactie);

            count++;

            if (blSpring)
            {
                if (keypressJump == "Links")
                {
                    character.Lopen(keypressJump, true);
                }
                else if (keypressJump == "Rechts")
                {
                    character.Lopen(keypressJump, true);
                }

                if (character.BlGesprongen)
                {
                    if (!zwaartekracht.Enabled)
                    {
                        zwaartekracht.Enabled = true;
                    }
                }
                else
                {
                    character.Springen(springHoogte);
                    zwaartekracht.Enabled = false;
                }

                if (Get_zwaartekracht(pbCharacter, pnlMain, character) && character.BlGesprongen)
                {
                    character_interactie.Stop();
                    blSpring = false;
                    character.BlGesprongen = false;

                    if (character.Richting == "Rechts")
                    {
                        if (Convert.ToInt32(character.grootte) == 0) { character.Image = Mario.Properties.Resources.mario_rechts; }
                        if (Convert.ToInt32(character.grootte) == 1) { character.Image = Mario.Properties.Resources.mario_groot_rechts; }
                        if (Convert.ToInt32(character.grootte) == 2) { character.Image = Mario.Properties.Resources.mario_super_rechts; }
                    }
                    else
                    {
                        if (Convert.ToInt32(character.grootte) == 0) { character.Image = Mario.Properties.Resources.mario_links; }
                        if (Convert.ToInt32(character.grootte) == 1) { character.Image = Mario.Properties.Resources.mario_groot_links; }
                        if (Convert.ToInt32(character.grootte) == 2) { character.Image = Mario.Properties.Resources.mario_super_links; }
                    }

                    if (keypressJump == "Links" || keypressJump == "Rechts")
                    {
                        character_interactie.Start();
                    }

                }

            }
            else
            {
                if (character.Richting == keypress)
                {
                    count++;
                    character.Lopen(keypress);

                    if (count > 3)
                    {
                        character_interactie.Stop();
                        count = 0;
                    }
                }
                else
                {
                    character.Draaien(keypress);
                    character_interactie.Stop();
                }
            }

            pbCharacter.Image = character.Image;
            pbCharacter.Location = new Point(character.X, character.Y);
        }

        private void Character_Collision(PictureBox pbCharacter, Panel panel, Character character, Timer Vlag, Timer zwaartekracht, Timer character_interactie)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is PictureBox)
                {
                    if (pbCharacter.Bounds.IntersectsWith(c.Bounds) && c.Tag.Equals("vlag"))
                    {
                        Vlag.Start();
                        zwaartekracht.Stop();
                        character_interactie.Stop();
                    }
                }
            }
        }

        public bool Get_zwaartekracht(PictureBox pbCharacter, Panel panel, Character character)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is PictureBox)
                {
                    if (pbCharacter.Bounds.IntersectsWith(c.Bounds) && c.Tag.Equals("blok"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Character_zwaartekracht(PictureBox pbCharacter, Panel panel, Character character)
        {
            if (!Get_zwaartekracht(pbCharacter, panel, character))
            {
                character.Y += 4;
                pbCharacter.Location = new Point(character.X, character.Y);
            }
        }

        public void GetSpringHoogte(PictureBox pbCharacter, Panel panel, Character character)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is PictureBox)
                {
                    if (pbCharacter.Bounds.IntersectsWith(c.Bounds) && c.Tag.Equals("blok"))
                    {
                        springHoogte = c.Location.Y - 70;
                        blSpring = true;
                    }
                }
            }
        }
    }
}
