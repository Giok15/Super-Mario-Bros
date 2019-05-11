using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario
{
    class EnemyController
    {
        int sequence = 0;
        WereldDelen.Wereld wereld;

        public void Enemy_interaction(Panel pnlMain, Form form, Character character, CharacterController cntCharacter)
        {
            wereld = (WereldDelen.Wereld)form;

            Enemy_Collision(pnlMain, wereld.pbEnemys, wereld.enemys, character, cntCharacter);

            int i = 0;
            foreach (Enemy enemy in wereld.enemys)
            {

                if (!Enemy_zwaartekracht(wereld.pbEnemys[i], pnlMain))
                {
                    wereld.pbEnemys[i].Location = new Point(wereld.pbEnemys[i].Location.X, wereld.pbEnemys[i].Location.Y + 3);

                }
                else
                {
                    if (!enemy.blDood)
                    {
                        enemy.veranderImage();

                        wereld.pbEnemys[i].Image = enemy.Image;

                        int x = enemy.lopen();
                        wereld.pbEnemys[i].Location = new Point(x, wereld.pbEnemys[i].Location.Y);
                    }
                    else
                    {
                        if (!enemy.blVerdwijn)
                        {
                            wereld.pbEnemys[i].Image = enemy.Image;
                            enemy.blVerdwijn = true;
                        }
                        else
                        {
                            wereld.pbEnemys[i].Visible = false;

                            var numbersList = wereld.enemys.ToList();
                            numbersList.Remove(enemy);
                            wereld.enemys = numbersList.ToArray();

                            var numbersList2 = wereld.pbEnemys.ToList();
                            numbersList2.Remove(wereld.pbEnemys[i]);
                            wereld.pbEnemys = numbersList2.ToArray();

                            break;
                        }
                    }
                }
                i++;
            }
        }

        private void Enemy_Collision(Panel panel, PictureBox[] pbEnemys, Enemy[] enemys, Character character, CharacterController cntCharacter)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is PictureBox)
                {
                    sequence = 0;
                    foreach (PictureBox pbEnemy in pbEnemys)
                    {
                        if (pbEnemy.Bounds.IntersectsWith(c.Bounds) && c.Tag.Equals("blok"))
                        {
                            Enemy_direction(pbEnemy, c, enemys);
                        }

                        if (pbEnemy.Bounds.IntersectsWith(c.Bounds) && c.Tag.Equals("Player"))
                        {
                            Enemy_hit_player(pbEnemy, c, enemys, character, cntCharacter);
                        }
                        sequence++;
                    }
                }
            }
        }

        private void Enemy_direction(PictureBox pbEnemy, Control c, Enemy[] enemys)
        {
            int enemyY = pbEnemy.Location.Y;
            int blokY = c.Location.Y;

            if (enemyY == blokY || enemyY + 12 == blokY)
            {
                if (enemys[sequence].BlLopenLinks)
                {
                    enemys[sequence].BlLopenLinks = false;
                }
                else
                {
                    enemys[sequence].BlLopenLinks = true;
                }
            }
        }

        private bool Enemy_zwaartekracht(PictureBox pbEnemy, Panel panel)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is PictureBox)
                {
                    if (pbEnemy.Bounds.IntersectsWith(c.Bounds) && c.Tag.Equals("blok"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void Enemy_hit_player(PictureBox pbEnemy, Control c, Enemy[] enemys, Character character, CharacterController cntCharacter)
        {
            int enemyX = pbEnemy.Location.X;
            int characterX = c.Location.X;

            int characterY = c.Location.Y + c.Height;
            int enemyY = pbEnemy.Location.Y + pbEnemy.Height;

            if (characterX < enemyX)
            {
                if (characterY < enemyY - 2)
                {
                    enemys[sequence].dood();
                }
                else if(!enemys[sequence].blDood)
                {
                    character.Geraakt(cntCharacter);
                }
            }
            else if (characterX > enemyX)
            {
                int x = enemyX + pbEnemy.Width;
                if (characterX + 1 < x)
                {
                    enemys[sequence].dood();
                }
                else if(!enemys[sequence].blDood)
                {
                    character.Geraakt(cntCharacter);
                }
            }
            else
            {
                character.Geraakt(cntCharacter);
            }
        }
    }
}
