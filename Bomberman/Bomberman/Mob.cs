using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    class Mob
    {
        /// <summary>
        /// Рівні інтлекту ворогів
        ///     1. вибирає точку і біжить до неї
        ///     2. вибирає точно і біжить до неї, якщо бачить вогонь то втікає
        ///     3. бігає від точки до точки, якщо можливо, то біжить до гравця, уникає бомбу
        /// </summary>
        int level = 1;
        public PictureBox mob { get; private set; }
        Timer timer;
        Point destinatePlace;
        Point mobPlace;
        MovingClass moving;
        int step = 3;
        Sost[,] map;
        int[,] fmap;
        int paths;
        Point[] path;
        int pathStep;
        static Random rand = new Random();
        Player player;
        public Mob(PictureBox picMob, PictureBox[,] _mapPic, Sost[,] _map, Player _player)
        {
            mob = picMob;
            map = _map;
            player = _player;
            fmap = new int[map.GetLength(0), map.GetLength(1)];
            path = new Point[map.GetLength(0) * map.GetLength(1)];
            moving = new MovingClass(picMob, _mapPic, _map);
            mobPlace = moving.MyNowPoint();
            destinatePlace = mobPlace;
            CreateTimer();
            timer.Enabled = true;

        }
        private void CreateTimer()
        {
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += timer_Tick;

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (mobPlace == destinatePlace)
                GetNewPlace();
            if (path[0].X == 0 && path[0].Y == 0)
                if (!FindPath()) return;
            if (pathStep > paths) return;
            if (path[pathStep] == mobPlace)
                pathStep++;
            else
                MoveMob(path[pathStep]);
            //MoveMob(destinatePlace);
            //mob.Location = new Point(mob.Location.X, mob.Location.Y - 3);
        }
        private void MoveMob(Point newPlace)
        {
            int sx = 0; int sy = 0;
            if (mobPlace.X < newPlace.X)
                sx = newPlace.X - mobPlace.X > step ? step : newPlace.X - mobPlace.X;
            else
                sx = mobPlace.X - newPlace.X < step ? newPlace.X - mobPlace.X : -step;

            if (mobPlace.Y < newPlace.Y)
                sy = newPlace.Y - mobPlace.Y > step ? step : newPlace.Y - mobPlace.Y;
            else
                sy = mobPlace.Y - newPlace.Y < step ? newPlace.Y - mobPlace.Y : -step;
            moving.Move(sx, sy);
            mobPlace = moving.MyNowPoint();
            if(level >= 2 && (map[newPlace.X, newPlace.Y] == Sost.bomb || map[newPlace.X, newPlace.Y] == Sost.fire))
            {
                GetNewPlace();
            }
        }
        private bool FindPath()
        {

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    fmap[x, y] = 0;
                }
            }
            bool added;
            bool found = false;
            fmap[mobPlace.X, mobPlace.Y] = 1;
            int nr = 1;
            do
            {
                added = false;
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    for (int y = 0; y < map.GetLength(1); y++)
                    {
                        if (fmap[x, y] == nr)
                        {
                            MarkPath(x + 1, y, nr + 1);
                            MarkPath(x - 1, y, nr + 1);
                            MarkPath(x, y - 1, nr + 1);
                            MarkPath(x, y + 1, nr + 1);
                            added = true;
                        }
                    }
                }
                if(fmap[destinatePlace.X, destinatePlace.Y] > 0)
                {
                    found = true;
                    break;
                }
                nr++;

            } while (added);

            if (!found)
                return false;

            int sx = destinatePlace.X;
            int sy = destinatePlace.Y;
            paths = nr;
            while(nr>=0)
            {
                path[nr].X = sx;
                path[nr].Y = sy;
                if (IsPath(sx + 1, sy, nr)) sx++;
                else if (IsPath(sx - 1, sy, nr)) sx--;
                else if (IsPath(sx, sy + 1, nr)) sy++;
                else if (IsPath(sx, sy - 1, nr)) sy--;
                nr--;
            }
            pathStep = 0;

            return true;
        }
        private void MarkPath(int x, int y, int n)
        {
            if (x < 0 || x >= map.GetLength(0)) return;
            if (y < 0 || y >= map.GetLength(1)) return;
            if (fmap[x, y] > 0) return;
            if (map[x, y] != Sost.empty) return; //перевіряє чи клітинка пуста
            fmap[x, y] = n;
            
            
        }
        private bool IsPath(int x, int y, int n)
        {
            if (x < 0 || x > map.GetLength(0)) return false;
            if (y < 0 || y > map.GetLength(1)) return false;

            return fmap[x,y] == n;
        }
        private void GetNewPlace()
        {
            if(level>=3)
            {
                destinatePlace = player.MyNowPoint();
                if (FindPath()) return;
            }
            int loop = 0;
            do
            {
                destinatePlace.X = rand.Next(1, map.GetLength(0) - 1);
                destinatePlace.Y = rand.Next(1, map.GetLength(1) - 1);
            } while (!FindPath() && loop++ < 100);
            if (loop >= 100)
                destinatePlace = mobPlace;
        }
        public Point MyNowPoint()
        {
            return moving.MyNowPoint();
        }
        public void SetLevel(int _level)
        {
            level = _level;
        }
    }
}
