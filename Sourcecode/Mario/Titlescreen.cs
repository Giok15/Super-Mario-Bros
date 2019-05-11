using Mario.DatabaseClasses;
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

namespace Mario
{
    public partial class Titlescreen : Form
    {
        int counter = 0;
        string line;
        string fileAccounts = @"C:\Users\giova\AppData\Local\Packages\1acf27e1-4e83-48c7-a911-98e113841a2a_0f40devkehxf4\LocalState\file.txt";

        public Titlescreen()
        {
                InitializeComponent();

                gbInloggen.Visible = false;
                gbRegistreren.Visible = true;
                gbRegistreren.Location = new Point(8, 1);

                getAccounts();

                btnGespeeld.Enabled = false;
                btnSpeel.Enabled = false;

                Sounds.PlayThemesong();
        }

        private void getAccounts()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(fileAccounts);
            while ((line = file.ReadLine()) != null)
            {
                cmbProfielen.Items.Add(line.Split(',')[1]);
            }

            file.Close();
        }

        private void btnSpeel_Click(object sender, EventArgs e)
        {
            World world = new World();
            world.Show();
            this.Hide();
        }

        private void pbUitloggen_Click(object sender, EventArgs e)
        {
            gbRegistreren.Visible = true;
            cmbProfielen.SelectedItem = null;

            btnGespeeld.Enabled = false;
            btnSpeel.Enabled = false;
        }

        private void pbInloggen_Click(object sender, EventArgs e)
        {
            try
            {
                ProfielDb.CheckResultaat(cmbProfielen.SelectedItem.ToString());

                ProfielDb.GetAccount(cmbProfielen.SelectedItem.ToString());

                ProfielDb.GetResultaten(cmbProfielen.SelectedItem.ToString());

                setInlogGegevens();
                gbInloggen.Visible = true;
                gbInloggen.Location = new Point(8, 1);
                gbRegistreren.Visible = false;

                btnGespeeld.Enabled = true;
                btnSpeel.Enabled = true;
            }
            catch { MessageBox.Show("U moet met iemand inloggen.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void setInlogGegevens()
        {
            switch (Profiel.Avatar)
            {
                case 1:
                    pbImg.Image = Properties.Resources.Avatar1;
                    break;
                case 2:
                    pbImg.Image = Properties.Resources.Avatar2;
                    break;
                case 3:
                    pbImg.Image = Properties.Resources.Avatar3;
                    break;
                case 4:
                    pbImg.Image = Properties.Resources.Avatar4;
                    break;
                case 5:
                    pbImg.Image = Properties.Resources.Avatar5;
                    break;
            }

            lbNaam.Text = Profiel.Naam;
            lblLevens.Text = Algemene_resultaat.Levens.ToString();
            lblMunten.Text = Algemene_resultaat.Munten.ToString();
            lblSave.Text = Algemene_resultaat.Save_level;
        }

        private void btnGespeeld_Click(object sender, EventArgs e)
        {
            AccountResultaten resultaten = new AccountResultaten();
            resultaten.Show();
            this.Hide();
        }

        private void Titlescreen_Load(object sender, EventArgs e)
        {
            if (!DatabaseCon.GetAndCheckConnectieString())
            {    
                Sounds.GameOver(false);
                MessageBox.Show("De database kan niet geconnect worden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
