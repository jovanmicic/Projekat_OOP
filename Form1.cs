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
            for (int n = 0; n < matrica.GetLength(1); n++)
            {
                for (int m = 0; m < matrica.GetLength(0); m++)
                {
                    matrica[m, n] = new Polje();
                }
            }
        }
        Polje[,] matrica = new Polje[9, 9];
        bool igra_gotova = true;
        int broj_mina = 10;
        int broj_neotvorenih_polja = 9 * 9;//kada broj neotvorenih polja bude jednak broju mina, igra je gotova-pobeda
        Pen olovka = new Pen(Color.Black, 2);
        Font fontic = new Font("Arial", 30);
        SolidBrush cetka = new SolidBrush(Color.Black);

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

            tbxBrojZastavica.Text = broj_zastavica.ToString();
            tbxBrojZastavica.Refresh();

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
            for (int j = 0; j <= sirina; j += sirina / 9)
            {
                e.Graphics.DrawLine(olovka, j, 0, j, visina);
            }
        }



        private void pbxTabela_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = pbxTabela.CreateGraphics();
            
            tbxBrojZastavica.Text = broj_zastavica.ToString();
            tbxBrojZastavica.Refresh();
            int m = e.X / (pbxTabela.Width / 9);
            int n = e.Y / (pbxTabela.Height / 9);
            if (broj_neotvorenih_polja == broj_mina)
            {
                igra_gotova = true;
                timer1.Stop();
                vreme = 0;
                MessageBox.Show("KRAJ IGRE", "POBEDILI STE");
            }
            if (!matrica[m, n].zastava)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (broj_neotvorenih_polja == broj_mina)
                    {
                        igra_gotova = true;
                        timer1.Stop();
                        vreme = 0;
                        MessageBox.Show("KRAJ IGRE", "POBEDILI STE");
                    }
                    if (!matrica[m, n].mina && !matrica[m, n].otvoreno)
                    {
                        if (matrica[m, n].zastava == true)
                        {
                            broj_zastavica++;
                            matrica[m, n].zastava = false;
                            cetka.Color = pbxTabela.BackColor;
                            g.FillRectangle(cetka, m * (pbxTabela.Width / 9), n * (pbxTabela.Height / 9), 40, 40);
                            cetka.Color = Color.Black;
                        }
                        Otvori_Polje(matrica, m, n, g, fontic, cetka, broj_neotvorenih_polja);



                    }
                    else if (matrica[m, n].mina && !matrica[m, n].otvoreno)
                    {
                        igra_gotova = true;
                        for (int i = 0; i < 10; i++)
                        {
                            g.DrawString("☼", fontic, cetka, nizx[i] * (pbxTabela.Width / 9), nizy[i] * (pbxTabela.Height / 9));
                        }
                        timer1.Stop();
                        vreme = 0;
                        MessageBox.Show("KRAJ IGRE", "IZGUBILI STE");
                    }

                }

                else if (e.Button == MouseButtons.Right)
                {

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
            
        }

        //-----------------------------------algoritam-------------------------------------//
        static Polje[,] Upisi_minice(Polje[,] matrica, int broj_mina)
        {

            Random rand_generator = new Random();
            for (int i = 0; i < broj_mina; i++)
            {
                int mina_x = rand_generator.Next(0, 9);
                int mina_y = rand_generator.Next(0, 9);
                nizx[i] = mina_x;
                nizy[i] = mina_y;
                if (matrica[mina_x, mina_y].mina)
                {
                    i--;
                }
                else matrica[mina_x, mina_y].mina = true;
            }
            return matrica;
        }

        static int Izbroji_Susede(Polje[,] matrica, int m, int n, Graphics g, Font font, Brush cetka)
        {
            int susedi = 0;
            for (int i = m - 1; i < m + 2; i++)
            {
                for (int j = n - 1; j < n + 2; j++)
                {
                    if (Proveri_Dimenzije(i, j, matrica) && matrica[i, j].mina == true)
                    {
                        susedi++;
                    }
                }
            }

            return susedi;
        }

        //algoritam



        static void Otvori_Susede(Polje[,] matrica, int m, int n, Graphics g, Font font, Brush cetka, int br)
        {
            Otvori_Polje(matrica, m - 1, n - 1, g, font, cetka, br); Otvori_Polje(matrica, m - 1, n, g, font, cetka, br);
            Otvori_Polje(matrica, m - 1, n + 1, g, font, cetka, br); Otvori_Polje(matrica, m, n - 1, g, font, cetka, br);
            Otvori_Polje(matrica, m, n + 1, g, font, cetka, br); Otvori_Polje(matrica, m + 1, n - 1, g, font, cetka, br);
            Otvori_Polje(matrica, m + 1, n, g, font, cetka, br); Otvori_Polje(matrica, m + 1, n + 1, g, font, cetka, br);
        }

        static void Otvori_Polje(Polje[,] matrica, int m, int n, Graphics g, Font font, Brush cetka, int br)
        {

            g.DrawString(Izbroji_Susede(matrica, m, n, g, font, cetka).ToString(), font, cetka, m * 40, n * 40);
            br--;
            if (Proveri_Dimenzije(m, n, matrica) && matrica[m, n].otvoreno != true)
            {
                matrica[m, n].otvoreno = true;
                if (Izbroji_Susede(matrica, m, n, g, font, cetka) == 0)
                {
                    Otvori_Susede(matrica, m, n, g, font, cetka, br);
                }
            }
            else return;
        }

        static bool Proveri_Dimenzije(int m, int n, Polje[,] matrica)
        {
            return m >= 0 && m < matrica.GetLength(0) && n >= 0 && n < matrica.GetLength(1);
        }

        private void frmIgra_Load(object sender, EventArgs e)
        {
            tbxBrojZastavica.Text = 10.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            vreme++;
            tbxTajmer.Text = vreme.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
