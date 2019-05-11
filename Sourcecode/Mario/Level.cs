using Mario.Database;
using Mario.Entityclasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Mario.WereldDelen
{
    public partial class Wereld : Form
    {
        int intTijd;
        DateTime start_date;

        EnemyController cntEnemy = new EnemyController();
        CharacterController cntCharacter = new CharacterController();

        Character character;
        public Enemy[] enemys = new Enemy[5];
        public PictureBox[] pbEnemys = new PictureBox[5];

        string keypress;
        string keypressJump;
        bool blSpring;
        int count;

        int springHoogte;

        int wereldVerder = 300;

        public Wereld()
        {
            InitializeComponent();

            Sounds.StopThemesong();

            //create de character en enemys van de wereld
            character = new Character("Mario", pbCharacter.Location.X, pbCharacter.Location.Y);

            pbEnemys[0] = pbGoomba1;
            pbEnemys[1] = pbKoopa1;
            pbEnemys[2] = pbGoomba2;
            pbEnemys[3] = pbGoomba3;
            pbEnemys[4] = pbKoopa3;

            Enemy enemy1 = new Enemy("Goomba", pbEnemys[0].Location.X, pbEnemys[0].Location.Y);
            Enemy enemy2 = new Enemy("Koopa", pbEnemys[1].Location.X, pbEnemys[1].Location.Y);
            Enemy enemy3 = new Enemy("Goomba", pbEnemys[2].Location.X, pbEnemys[2].Location.Y);
            Enemy enemy4 = new Enemy("Goomba", pbEnemys[3].Location.X, pbEnemys[3].Location.Y);
            Enemy enemy5 = new Enemy("Koopa", pbEnemys[4].Location.X, pbEnemys[4].Location.Y);

            enemys[0] = enemy1;
            enemys[1] = enemy2;
            enemys[2] = enemy3;
            enemys[3] = enemy4;
            enemys[4] = enemy5;


            // zet de resulaten goed en gebruik de lvl gegevens die eerder zijn opgehaald.
            Resultaat.Munten = 0;
            Resultaat.Tijd = Level.Aantal_tijd;

            //het spel begint dus maak een spel aan
            start_date = DateTime.Now;
            SpelDb.AanmakenSpel(start_date);

            //gegevens mogen in de labels en de tijd mag aangezet worden
            getGegevens();
            intTijd = Level.Aantal_tijd;
            LvlTijd.Start();

            //de verschillende timers voor de gebruikers en enemys mogen gestart worden

            Enemy_interactie.Start();
            Zwaartekracht.Start();
            WereldDoorgaan.Start();
            CheckCharacterDied.Start();

        }

        private void LvlTijd_Tick(object sender, EventArgs e)
        {
            intTijd--;
            lblTijd.Text = intTijd.ToString();

            if (intTijd == 0)
            {
                character.BlDood = true;
            }
            else if (intTijd == 10)
            {
                Sounds.TimeWarning();
            }

            if (pbCharacter.Location.Y > 350)
            {
                character.BlDood = true;
            }

            lblLocatie.Text = character.ToString();
        }

        private void getGegevens()
        {
            lblNaam.Text = Level.Naam;
            lblLevens.Text = Algemene_resultaat.Levens.ToString();
            lblTijd.Text = Resultaat.Tijd.ToString();
            lblCoins.Text = Resultaat.Munten.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cntEnemy.Enemy_interaction(pnlMain, this, character, cntCharacter);
        }


        private void deel_trap_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Character_interactie.Start();
                    keypress = "Links";
                    keypressJump = "Links";
                    break;

                case Keys.Right:
                    Character_interactie.Start();
                    keypress = "Rechts";
                    keypressJump = "Rechts";
                    break;

                case Keys.Up:

                    if (cntCharacter.Get_zwaartekracht(pbCharacter, pnlMain, character))
                    {
                        Sounds.playJump();

                        if (!blSpring)
                        {
                            cntCharacter.GetSpringHoogte(pbCharacter, pnlMain, character);

                            Character_interactie.Start();
                        }
                    }
                    break;
            }
        }

        private void deel_trap_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    keypressJump = "";
                    break;

                case Keys.Right:
                    keypressJump = "";
                    break;

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            cntCharacter.Character_interactie(pnlMain, character, keypressJump, keypress, Character_interactie, Zwaartekracht, vlag, pbCharacter);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            cntCharacter.Character_zwaartekracht(pbCharacter, pnlMain, character);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (pbCharacter.Location.X > pnlMain.Location.X + wereldVerder && pbCharacter.Location.X < 1800)
            {
                wereldVerder += 200;
                pnlMain.Location = new Point(pnlMain.Location.X - 100, pnlMain.Location.Y);
            }
            else if (pbCharacter.Location.X < pnlMain.Location.X + (wereldVerder - 100) && wereldVerder > 300)
            {
                wereldVerder -= 200;
                pnlMain.Location = new Point(pnlMain.Location.X + 100, pnlMain.Location.Y);
            }
        }

        private void vlag_Tick(object sender, EventArgs e)
        {
            Enemy_interactie.Stop();
            Character_interactie.Stop();
            LvlTijd.Stop();
            Zwaartekracht.Stop();

            pbVlag.Location = new Point(pbVlag.Location.X, pbVlag.Location.Y + 1);

            if (pbVlag.Location.Y == 265)
            {
                if (Level.Save_mogelijkheid)
                {
                    Algemene_resultaat.Save_level = "1." + Level.Id;
                }

                ResultaatDb.AanmakenResultaat(Convert.ToInt32(lblCoins.Text), Convert.ToInt32(lblTijd.Text), 1);
                SpelDb.WijzigenSpel(ResultaatDb.GetResultaatId(), SpelDb.GetSpelId());
                vlag.Stop();
                Sounds.Clear();

                World world = new World();
                world.Show();
                this.Close();
            }
        }

        private void CheckCharacterDied_Tick(object sender, EventArgs e)
        {
            if (character.BlDood || pbCharacter.Location.Y > 330)
            {
                Character_interactie.Stop();
                Enemy_interactie.Stop();
                Zwaartekracht.Stop();
                WereldDoorgaan.Stop();
                LvlTijd.Stop();

                ResultaatDb.AanmakenResultaat(Convert.ToInt32(lblCoins.Text), Convert.ToInt32(lblTijd.Text), 0);
                SpelDb.WijzigenSpel(ResultaatDb.GetResultaatId(), SpelDb.GetSpelId());

                Algemene_resultaat.Levens--;

                Sounds.MarioDie();

                World world = new World();
                world.Show();
                this.Close();
            }
        }
    }
}
