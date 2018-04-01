using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public static List<Label> labels = new List<Label>();
        private static bool[,] used = new bool[1001, 1001];
        public static bool GameOver = false;
        public Form1()
        {
            InitializeComponent();
            int x = 10;
            InitStone(x);
            for (int i = 0; i < x; i++)
            {
                Controls.Add(labels[i]);
            }
        }

        public static void InitStone(int x)
        {
            //int borderY = 100,borderX = 100;
            Random rnd = new Random();
            for (int i = 1; i <= x; i++)
            {
                int newX = rnd.Next(5, 300), newY = rnd.Next(5, 120);
                while (used[newX, newY])
                {
                    newX = rnd.Next(5, 325);
                    newY = rnd.Next(5, 120);
                }
                used[newX, newY] = true;
                Label cur = new Label();
                cur.Text = "■";
                cur.Location = new Point(newX, newY);
                labels.Add(cur);
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (GameOver) return;
            char key = e.KeyChar;
            switch (key)
            {
                case 'a':
                    Player.Location = new Point(Player.Location.X - 5, Player.Location.Y);
                    break;
                case 'd':
                    Player.Location = new Point(Player.Location.X + 5, Player.Location.Y);
                    break;
            }
        }

        private void Timer(object sender, EventArgs e)
        {
            if (GameOver == true) return;
            for (int i = 0; i < labels.Count; ++i)
            {
                labels[i].Location = new Point(labels[i].Location.X, (labels[i].Location.Y + 5) % Height);
            }
            for (int i = 0; i < labels.Count; ++i)
            {
                int xCalc = Player.Location.X + Player.Width, yCalc = Player.Location.Y + Player.Height;
                int xLCalc = labels[i].Location.X + labels[i].Width, yLCalc = labels[i].Location.Y + labels[i].Height;
                if (touch(Player.Location.X, Player.Location.Y, xCalc, yCalc, labels[i].Location.X, labels[i].Location.Y, xLCalc, yLCalc))
                {
                    GameOver = true;
                    MessageBox.Show("Game over");
                    return;
                }
            }
        }
        public static bool touch(int x, int y, int xCalc, int yCalc, int X, int Y, int xLCalc, int yLCalc)
        {
            if (x <= X && X <= xCalc && y <= Y && Y <= yCalc) return true;
            if (x <= xLCalc && xLCalc <= xCalc && y <= Y && Y <= yCalc) return true;
            if (x <= X && X <= xCalc && y <= yLCalc && Y <= yCalc) return true;
            if (x <= xLCalc && xLCalc <= xCalc && y <= yLCalc && yLCalc <= yCalc) return true;
            return false;
        }

        private void Player_Click(object sender, EventArgs e)
        {

        }
    }
}

