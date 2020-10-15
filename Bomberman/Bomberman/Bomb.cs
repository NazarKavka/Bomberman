using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bomberman
{
    public class Bomb
    { 
        Timer timer;
        int secCount = 4;
        PictureBox[,] mapPic;
        public Point bombPlace { get; private set; }
        deExplode explode;
        public Bomb(PictureBox[,] _mapPic, Point _bombPlace, deExplode _explode)
        {
            mapPic = _mapPic;
            bombPlace = _bombPlace;
            explode = _explode;
            CreateTimer();
            timer.Enabled = true;
        }
        private void CreateTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (secCount <= 0)
            {
                timer.Enabled = false;
                explode(this);
                return;
            }
            WriteTimer(--secCount);
        }
        private void WriteTimer(int nom)
        {
            mapPic[bombPlace.X, bombPlace.Y].Image = Properties.Resources.bomb;
            mapPic[bombPlace.X, bombPlace.Y].Refresh();
            using (Graphics gr = mapPic[bombPlace.X, bombPlace.Y].CreateGraphics())
            {
                PointF point = new PointF(mapPic[bombPlace.X, bombPlace.Y].Size.Width/3, mapPic[bombPlace.X, bombPlace.Y].Size.Height / 3 + 1);
                gr.DrawString(nom.ToString(), new Font("Arial", 10), Brushes.Red, point);
            }
        }
        public void Reaction()
        {
            secCount = 0;
        }

    }
}
