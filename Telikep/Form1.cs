using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telikep
{
    public partial class Form1 : Form
    {
        public class Hopelyhek
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Mennyivel_Valtozik_X { get; set; }
            public int Mennyivel_Valtozik_Y { get; set; }
        }


        private List<Hopelyhek> hopelyhek = new List<Hopelyhek>();
        private Image hopehelykepek = Image.FromFile(@"..\..\src\snowflakes.png");
        private int hopehelyszamokmaximuma = 40;
        private SoundPlayer zenelejátszó = new SoundPlayer(@"..\..\src\Michael_Bublé_It's_Beginning_To_Look_A_Lot_Like_Christmas.wav");
        public Form1()
        {
            InitializeComponent();
            timer.Start();
        }

        private void bearnose_btn_Click(object sender, EventArgs e)
        {
           
            zenelejátszó.Play();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Random vel = new Random();

            if (hopelyhek.Count < hopehelyszamokmaximuma)
            {
                Hopelyhek uj_hopehely = new Hopelyhek();
                uj_hopehely.X =  vel.Next(0, pictureBox1.Width);
                uj_hopehely.Y = -hopehelykepek.Height;
                uj_hopehely.Mennyivel_Valtozik_X = vel.Next(-5, 5);
                uj_hopehely.Mennyivel_Valtozik_Y = vel.Next(1, 10);
                hopelyhek.Add(uj_hopehely);
            }

            foreach (var item in hopelyhek)
            {
                item.X += item.Mennyivel_Valtozik_X;
                item.Y += item.Mennyivel_Valtozik_Y;

                if (item.X < -hopehelykepek.Width || item.X > pictureBox1.Width ||
                    item.Y > pictureBox1.Height)
                {
                    item.X = vel.Next(0, pictureBox1.Width);
                    item.Y = -hopehelykepek.Height;
                    item.Mennyivel_Valtozik_X = vel.Next(-5, 5);
                    item.Mennyivel_Valtozik_Y = vel.Next(1, 10);
                }
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in hopelyhek)
            {
                e.Graphics.DrawImage(hopehelykepek, item.X, item.Y);
            }
        }
    }
}
