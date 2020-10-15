using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bomberman
{
    public delegate void deExplode(Bomb b);
    enum Sost
    {
        empty,
        wall,
        brick,
        bomb,
        fire,
        prize
    }
    class MainBoard
    {
        Panel panelGame;
        PictureBox[,] mapPic;
        Sost[,] map;
        int sizeX = 17;
        int sizeY = 11;
        static Random rand = new Random();
        Player player;
        List<Mob> mobs;
        deClear NeedClear;
        Label score;
        public MainBoard(Panel panel, deClear _clear, Label _score)
        {
            panelGame = panel;
            NeedClear = _clear;
            mobs = new List<Mob>();
            score = _score;
            int boxSize;
            if((panelGame.Width / sizeX)<(panelGame.Height /sizeY))
            {
                boxSize = panelGame.Width / sizeX;
            }
            else
            {
                boxSize = panelGame.Height / sizeY;
            }
            InitStartMap(boxSize);
            InitStartPlayer(boxSize);
            for (int i = 0; i < 4; i++)
            {
                InitMob(boxSize);
            }
            
        }

        private void InitStartMap(int boxSize)
        {
            mapPic = new PictureBox[sizeX, sizeY];
            map = new Sost[sizeX, sizeY];
            
            panelGame.Controls.Clear();
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if(x==0 || y==0 || x==sizeX-1 || y == sizeY-1)
                        CreatePlace(new Point(x, y), boxSize, Sost.wall);
                  
                    else if(x%2==0 && y%2==0)
                        CreatePlace(new Point(x, y), boxSize, Sost.wall);
                    
                    else if (rand.Next(3) == 0)
                        CreatePlace(new Point(x, y), boxSize, Sost.brick);
                    
                    else
                        CreatePlace(new Point(x, y), boxSize, Sost.empty);
                    //CreatePlace(new Point(x, y), boxSize, );
                }
            }
            ChangeSost(new Point(1, 1), Sost.empty);
            ChangeSost(new Point(1, 2), Sost.empty);
            ChangeSost(new Point(2, 1), Sost.empty);
        }
        private void CreatePlace(Point point, int boxSize, Sost sost)
        {
            PictureBox picture = new PictureBox();
            picture.Location = new Point(point.X * (boxSize-1), point.Y * (boxSize-1));
            picture.Size = new Size(boxSize, boxSize);
            //picture.BorderStyle = BorderStyle.FixedSingle;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            mapPic[point.X, point.Y] = picture;
            ChangeSost(point, sost);
            panelGame.Controls.Add(picture);

        }
        private void ChangeSost(Point point, Sost newSost)
        {
            switch (newSost)
            {
                case Sost.wall:
                    mapPic[point.X, point.Y].Image = Properties.Resources.wall;
                    break;
                case Sost.brick:
                    mapPic[point.X, point.Y].Image = Properties.Resources.brick;
                    break;
                case Sost.bomb:
                    mapPic[point.X, point.Y].Image = Properties.Resources.bomb;
                    break;
                case Sost.fire:
                    mapPic[point.X, point.Y].Image = Properties.Resources.fire;
                    break;
                default:
                    mapPic[point.X, point.Y].Image = Properties.Resources.ground;
                    break;
            }
            map[point.X, point.Y] = newSost;
        }
        private void InitStartPlayer(int boxSize)
        {
            int x = 1; int y = 1;
            PictureBox picture = new PictureBox();
            picture.Location = new Point(x * (boxSize - 1), y * (boxSize + 1));
            picture.Size = new Size(boxSize-12, boxSize-9);
            picture.Image = Properties.Resources.pDown;
            picture.BackgroundImage = Properties.Resources.ground;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            panelGame.Controls.Add(picture);
            picture.BringToFront();
            player = new Player(picture, mapPic, map, score);
        }
        private void InitMob(int boxSize)
        {
            int x = 15; int y = 9;
            FindEmptyPlace(out x, out y);
            PictureBox picture = new PictureBox();
            picture.Location = new Point(x * (boxSize-1), y * (boxSize));
            picture.Size = new Size(boxSize - 15, boxSize - 12);
            picture.Image = Properties.Resources.mob;
            picture.BackgroundImage = Properties.Resources.ground;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            panelGame.Controls.Add(picture);
            picture.BringToFront();
            mobs.Add(new Mob(picture, mapPic, map, player));
        }
        public void MovePlayer(Arrows arrow)
        {
            if (player == null) return;
            player.MovePlayer(arrow);
        }
        public void PutBomb()
        {
            Point playerPoint = player.MyNowPoint();
            if (map[playerPoint.X, playerPoint.Y] == Sost.bomb) return;
            if (player.PutBomb(mapPic, Explode))
                ChangeSost(player.MyNowPoint(), Sost.bomb);
            ChangeSost(playerPoint, Sost.bomb);
        }
        private void FindEmptyPlace(out int x, out int y)
        {
            int loop = 0;
            do
            {
                x = rand.Next(map.GetLength(0) / 2, map.GetLength(0));
                y = rand.Next(map.GetLength(1) / 2, map.GetLength(1));
            } while (map[x, y] != Sost.empty && loop++<100);
        }
        
        private void Explode(Bomb bomb)
        {
            ChangeSost(bomb.bombPlace, Sost.fire);
            Flame(bomb.bombPlace, Arrows.left);
            Flame(bomb.bombPlace, Arrows.right);
            Flame(bomb.bombPlace, Arrows.up);
            Flame(bomb.bombPlace, Arrows.down);
            player.RemoveBomb(bomb);
            Blaze();
            NeedClear();
        }
        private void Blaze()
        {
            List<Mob> delMobs = new List<Mob>();
            foreach(Mob mob in mobs)
            {
                Point mobPoint = mob.MyNowPoint();
                if (map[mobPoint.X, mobPoint.Y]==Sost.fire)
                {
                    delMobs.Add(mob);
                }
            }
            for (int i = 0; i < delMobs.Count; i++)
            {
                mobs.Remove(delMobs[i]);
                panelGame.Controls.Remove(delMobs[i].mob);
                delMobs[i] = null;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void Flame(Point bombPlace, Arrows arrow)
        {
            int sx = 0; int sy = 0;
            switch(arrow)
            {
                case Arrows.left:
                    sx = -1; break;
                case Arrows.right:
                   sx = 1; break;
                case Arrows.down:
                   sy = 1; break;
                case Arrows.up:
                   sy = -1; break;
                default: break;
            }
   
            bool isNotDone = true;
            int x = 0; int y = 0;

            do
            {
                x += sx; y += sy;
                if (Math.Abs(x) > player.lenFire || Math.Abs(y) > player.lenFire) break;
                if (isFire(bombPlace, x, y))
                    ChangeSost(new Point(bombPlace.X + x, bombPlace.Y + y), Sost.fire);
                else
                    isNotDone = false;

            } while (isNotDone);
        }
        private bool isFire(Point place, int sx, int sy)
        {
            switch (map[place.X + sx, place.Y + sy])
            {
                case Sost.empty: 
                    return true;
                case Sost.brick:
                    ChangeSost(new Point(place.X + sx, place.Y + sy), Sost.fire); 
                    return false;
                case Sost.wall:
                    return false;
                case Sost.bomb:
                    foreach(Bomb bomb in player.bombs)
                    {
                        if (bomb.bombPlace == new Point(place.X + sx, place.Y + sy))
                            bomb.Reaction();
                    }
                    return false;
                /*case Sost.fire:
                    break;
                case Sost.prize:
                    break;*/
                default: return true;
            }
            
        }
        public void ClearFire()
        {
            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if(map[x,y] == Sost.fire)
                    {
                        ChangeSost(new Point(x, y), Sost.empty);
                    }
                }
            
        }
        public bool GameOver()
        {
            Point myPoint = player.MyNowPoint();
            if (map[myPoint.X, myPoint.Y] == Sost.fire)
                return true;
            if (mobs.Count == 0)
                return true;
            foreach(Mob mob in mobs)
            {
                if(myPoint == mob.MyNowPoint())
                {
                    return true;
                }
            }
            return false;
        }
        public void SetMobLevel(int _level)
        {
            foreach(Mob mob in mobs)
            {
                mob.SetLevel(_level);
            }
        }
    }
}
