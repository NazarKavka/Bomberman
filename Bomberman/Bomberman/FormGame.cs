using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    public delegate void deClear();
    public partial class FormGame : Form
    {
        MainBoard board;
        int level = 1;
        public FormGame()
        {
            InitializeComponent();
            NewGame();
        }
        private void NewGame()
        {
            board = new MainBoard(panelGame, StartClear, labelScore);
            ChangeLevel(level);
            timerGameOver.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void проГруToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(@"Гра Бомбермен, виконав Кавка Назарій
Управління: керування персонажем - стрілки, поставити бомбку - пробіл
Складність противників міняється в реальному часі
1. Простий - противник вибирає точку і біжить до неї
2. Середній - противник вибирає точно і біжить до неї, якщо бачить вогонь то втікає
3. Важкий - противник бігає від точки до точки, якщо можливо, то біжить до гравця, уникає бомбу");
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            if(timerGameOver.Enabled)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left: board.MovePlayer(Arrows.left); break;
                    case Keys.Right: board.MovePlayer(Arrows.right); break;
                    case Keys.Down: board.MovePlayer(Arrows.down); break;
                    case Keys.Up: board.MovePlayer(Arrows.up); break;
                    case Keys.Space: board.PutBomb(); break;
                }
            }
           
        }

        private void timerFireClear_Tick(object sender, EventArgs e)
        {
            board.ClearFire();
            timerFireClear.Enabled = false;

        }
        private void StartClear()
        {
            timerFireClear.Enabled = true;
        }

        private void timerGameOver_Tick(object sender, EventArgs e)
        {
            if(board.GameOver())
            {
                timerGameOver.Enabled = false;
                DialogResult dr = MessageBox.Show("Хочете почати заново?","Кінець гри!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == System.Windows.Forms.DialogResult.Yes)
                {
                    NewGame();
                }


            }
        }

        private void новаГраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ChangeLevel(int _level)
        {
            level = _level;
            board.SetMobLevel(level);
        }

        private void середнійToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLevel(2);
        }

        private void важкийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLevel(3);
        }

        private void простийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLevel(1);
        }
    }
}
