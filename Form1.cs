using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat_OOP
{
    public partial class frmIgra : Form
    {
        public frmIgra()
        {
            InitializeComponent();
            
        }
        
        
        static int[] nizx = new int[10];
        static int[] nizy = new int[10];
        int broj_zastavica = 10;
        int vreme = 0;

        private void btnStart_Click(object sender, EventArgs e)
        {
            igra_gotova = false;
            pbxTabela.Refresh();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matrica[i, j].otvoreno = false;
                    matrica[i, j].mina = false;
                    matrica[i, j].zastava = false;
                }
            }
            Upisi_minice(matrica, broj_mina);
            vreme = 0;
            timer1.Start();

            broj_zastavica = 10;


        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int sirina = pbxTabela.Width = 360;
            int visina = pbxTabela.Height = 360;
            for (int i = 0; i <= visina; i += visina / 9)
            {
                e.Graphics.DrawLine(olovka, 0, i, sirina, i);
            }
            for (int j = 0; j <= sirina; j += sirina /9)
            {
                e.Graphics.DrawLine(olovka, j, 0, j, visina);
            }
        }

        
        
        private void pbxTabela_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = pbxTabela.CreateGraphics();
            
            
            else if (e.Button == MouseButtons.Right )
            {
                int m = e.X / (pbxTabela.Width / 9);
                int n = e.Y / (pbxTabela.Height / 9);

                if (matrica[m, n].zastava == false && !matrica[m, n].otvoreno && broj_zastavica > 0)
                {
                    g.DrawString("⚑", fontic, cetka, m * (pbxTabela.Width / 9), n * (pbxTabela.Height / 9));
                    broj_zastavica--;
                    matrica[m, n].zastava = true;
                }
                else if (matrica[m, n].zastava == true && !matrica[m, n].otvoreno)
                {
                    cetka.Color = pbxTabela.BackColor;
                    g.FillRectangle(cetka, m * (pbxTabela.Width / 9) + 1, n * (pbxTabela.Height / 9) + 1, 35, 35);
                    cetka.Color = Color.Black;
                    broj_zastavica++;
                    matrica[m, n].zastava = false;
                }

                tbxBrojZastavica.Text = broj_zastavica.ToString();
                tbxBrojZastavica.Refresh();

            }
            
        }

        //-----------------------------------algoritam-------------------------------------//
        

        private void frmIgra_Load(object sender, EventArgs e)
        {
            tbxBrojZastavica.Text = 10.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {         
            vreme++;
            tbxTajmer.Text = vreme.ToString();
        }
    }
    
}
