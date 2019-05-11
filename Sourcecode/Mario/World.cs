using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mario.Properties;
using Mario.Entityclasses;
using Mario.Database;

namespace Mario
{
    public partial class World : Form
    {
        ButtonLevel[] csButtonlevels = new ButtonLevel[6];
        PictureBox[] pbButtonlevels = new PictureBox[6];

        int save = Convert.ToInt32(Entityclasses.Algemene_resultaat.Save_level.Substring(2,1));

        public World()
        {
            InitializeComponent();

            if (Algemene_resultaat.Levens == 0)
            {
                Algemene_resultaat.Levens = 300;
            }

            ProfielDb.WijzigenAlgemeenResultaat();

            csButtonlevels[0] = new ButtonLevel(Resources.lvl1_bezet, Resources.lvl1_gehaald, Resources.lvl1_current);
            csButtonlevels[1] = new ButtonLevel(Resources.lvl2_bezet, Resources.lvl2_gehaald, Resources.lvl2_current);
            csButtonlevels[2] = new ButtonLevel(Resources.lvl3_bezet, Resources.lvl3_gehaald, Resources.lvl3_current);
            csButtonlevels[3] = new ButtonLevel(Resources.lvl4_bezet, Resources.lvl4_gehaald, Resources.lvl4_current);
            csButtonlevels[4] = new ButtonLevel(Resources.lvl5_bezet, Resources.lvl5_gehaald, Resources.lvl5_current);
            csButtonlevels[5] = new ButtonLevel(Resources.lvl6_bezet, Resources.lvl6_gehaald, Resources.lvl6_current);

            pbButtonlevels[0] = pbLvl1;
            pbButtonlevels[1] = pbLvl2;
            pbButtonlevels[2] = pbLvl3;
            pbButtonlevels[3] = pbLvl4;
            pbButtonlevels[4] = pbLvl5;
            pbButtonlevels[5] = pbLvl6;

            CreateButtonStatus();
            ChangeImagesStatus();
        }

        public void CreateButtonStatus()
        {
            for (int i = 0; i <= save - 1; i++)
            {
                csButtonlevels[i].LevelGehaald();
            }

            csButtonlevels[save].LevelBezig();
        }

        public void ChangeImagesStatus()
        {
            int i = 0;
            foreach (PictureBox pbButtonlevel in pbButtonlevels)
            {
                pbButtonlevel.Image = csButtonlevels[i].imgLevel;

                switch (csButtonlevels[i].status)
                {
                    case ButtonLevel.Status.bezig:

                        break;

                    case ButtonLevel.Status.bezet:
                        pbButtonlevel.Cursor = Cursors.No;
                        break;

                    case ButtonLevel.Status.behaald:

                        break;
                }
                i++;
            }
        }

        private void World_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Titlescreen titlescreen = new Titlescreen();
                titlescreen.Show();
                this.Close();
            }
        }

        private void btnLevels_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            int i = 0;
            foreach (PictureBox pbButtonlevel in pbButtonlevels)
            {
                if (pb.Tag == pbButtonlevel.Tag)
                {
                    if (csButtonlevels[i].status != ButtonLevel.Status.bezet)
                    {
                        LevelDb.GetLevel(Convert.ToInt32(pb.Tag));

                        WereldDelen.Wereld lf = new WereldDelen.Wereld();
                        lf.Show();
                        this.Hide();
                        break;
                    }
                }
                i++;
            }
        }
    }
}
