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
    public partial class AccountResultaten : Form
    {
        List<DataGridViewRow> listDr = new List<DataGridViewRow>();
        public AccountResultaten()
        {
            InitializeComponent();
            DataTable dt = SpelDb.GetSpelResultaten(Profiel.Naam);

            dgSpellen.DataSource = dt;
            dgSpellen.Columns[4].Visible = false;

            lblAantalSpellen.Text = "Aantal gespeelde spellen: " + SpelDb.CountSpelResultaten(Profiel.Naam);
        }

        private void AccountResultaten_Load(object sender, EventArgs e)
        {
            VeranderDatagridviewKleur();
        }

        private void dgSpellen_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VeranderDatagridviewKleur();
        }

        private void VeranderDatagridviewKleur()
        {
            foreach (DataGridViewRow row in dgSpellen.Rows)
            {
                if (Convert.ToInt32(row.Cells[4].Value) == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
        }

        private void GetLabelGegevens()
        {
            foreach (DataGridViewRow dr in dgSpellen.Rows)
            {
                listDr.Add(dr);
            }

            if (listDr.Contains(dgSpellen.SelectedRows[0]))
            {
                int index = listDr.IndexOf(dgSpellen.SelectedRows[0]);

                lblWereld.Text = listDr[index].Cells[1].Value.ToString();
            }
        }

        private void dgSpellen_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                GetLabelGegevens();
            }
            catch { }
        }

        private void AccountResultaten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Titlescreen titlescreen = new Titlescreen();
                titlescreen.Show();
                this.Close();
            }
        }

        private void dgSpellen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Titlescreen titlescreen = new Titlescreen();
                titlescreen.Show();
                this.Hide();
            }
        }
    }
}
