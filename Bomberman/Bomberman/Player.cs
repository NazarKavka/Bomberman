using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bomberman
{
    enum Arrows
    {
        left,
        right,
        up,
        down
    }
    class Player
    {
        PictureBox player;
        //PictureBox[,] mapPic;
        //Sost[,] map;
        int step;
        MovingClass moving;
        public List<Bomb> bombs { get; private set; }
        int bombCount;
        public int lenFire { get; private set; }
        Label score;
        public Player(PictureBox _player, PictureBox[,] _mapPic, Sost[,] _map, Label lbScrore)
        {
            player = _player;
            //mapPic = _mapPic;
            //map = _map;
            step = 5;
            score = lbScrore;
            bombs = new List<Bomb>();
            bombCount = 3;
            moving = new MovingClass(_player, _mapPic, _map);
            lenFire = 3;
            ChangeScore();
        }
        public void MovePlayer(Arrows arrow)
        {
            switch (arrow)
            {
                case Arrows.left:
                    player.Image = Properties.Resources.pLeft;
                    moving.Move(-step, 0); break;
                case Arrows.right:
                    player.Image = Properties.Resources.pRight;
                    moving.Move(step, 0); break;
                case Arrows.down:
                    player.Image = Properties.Resources.pDown;
                    moving.Move(0, step); break;
                case Arrows.up:
                    player.Image = Properties.Resources.pUp;
                    moving.Move(0, -step);  break;
                default: break;
            }
        }
        public Point MyNowPoint()
        {
            return moving.MyNowPoint();
        }
        public bool PutBomb(PictureBox[,] mapPic, deExplode explode)
        {
            if (bombs.Count >= bombCount) return false;
            Bomb bomb = new Bomb(mapPic, MyNowPoint(), explode);
            bombs.Add(bomb);
            return true;
        }

        public void RemoveBomb(Bomb bomb)
        {
            bombs.Remove(bomb);
        }
        public void ChangeScore()
        {
            if (score == null) return;
            score.Text = "Швидкість:" + step + " К-сть бомб:" + bombCount + " Сила бомб" + lenFire;
        }

    }
}
