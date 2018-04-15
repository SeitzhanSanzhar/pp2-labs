using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    public partial class Form1 : Form
    {
        public static Label Player,bullet;

        public static int[] dy = new int[100];
        public static int[] dx = new int[100];
        public static bool gameOver = false;
        public static bool[] die = new bool[1001];

        public static int shipShift = 10,bulletX = 0,bulletY = 0,speed = 10;
        public static List<Label> labels = new List<Label>();

        public static int _width = 0, _height = 0;

        public Form1()
        {
            InitializeComponent();

            _width = Width;
            _height = Height;

            InitGame();

            foreach (Label cur in labels)
            {
                Controls.Add(cur);
            }

            Controls.Add(Player);
        }
        public static void InitGame()
        {
            InitShip();
            InitStones();
        }
        public static void InitStones()
        {
            int cntStone = 5;
            for(int i = 1;i <= cntStone;i ++)
            {
                Random random = new Random();

                int stoneX = random.Next(0, 20);
                int stoneY = random.Next(0, 200);

                if(stoneX % 2 == 0)
                {
                    dx[i - 1] = speed;
                } else
                {
                    dx[i - 1] = -speed;
                }
                if(stoneY % 2 == 0)
                {
                    dy[i - 1] = speed;
                } else
                {
                    dy[i - 1] = -speed;
                }

                Label cur = new Label();
                cur.Location = new Point(stoneX, stoneY);

                Image image = Image.FromFile(@"C:\Users\Sony\source\repos\AsteroidGame\AsteroidGame\assets\asteroid.jpg");
                
                cur.Size = new Size(image.Width, image.Height);
                cur.Image = image;
                labels.Add(cur);
            } 
        }
        public static void InitShip()
        {
            Player = new Label();
            Image image = Image.FromFile(@"C:\Users\Sony\source\repos\AsteroidGame\AsteroidGame\assets\spaceship.jpg");
            Player.Width = image.Width;
            Player.Height = image.Height;
            Player.Image = image;
            Player.BorderStyle = BorderStyle.None;
            Player.BackColor = Color.Black;
            Player.Location = new Point(100, 100);
        }
        public static bool touch(int x, int y, int xCalc, int yCalc, int X, int Y, int xLCalc, int yLCalc)
        {
            if (x <= X && X <= xCalc && y <= Y && Y <= yCalc) return true;
            if (x <= xLCalc && xLCalc <= xCalc && y <= Y && Y <= yCalc) return true;
            if (x <= X && X <= xCalc && y <= yLCalc && Y <= yCalc) return true;
            if (x <= xLCalc && xLCalc <= xCalc && y <= yLCalc && yLCalc <= yCalc) return true;
            return false;
        }
        private void MoveStone(object sender, EventArgs e)
        {
            if (gameOver) return;
            for(int i = 0;i < labels.Count;i ++)
            {
                int xCalc = Player.Location.X + Player.Width, yCalc = Player.Location.Y + Player.Height;
                int xLCalc = labels[i].Location.X + labels[i].Width, yLCalc = labels[i].Location.Y + labels[i].Height;
                if (!die[i] && touch(Player.Location.X, Player.Location.Y, xCalc, yCalc, labels[i].Location.X, labels[i].Location.Y, xLCalc, yLCalc))
                {
                    gameOver = true;
                    MessageBox.Show("Game over");
                    return;
                }
                int curX = labels[i].Location.X, curY = labels[i].Location.Y;
                if(curX > Width || curX < 0)
                {
                    dx[i] *= -1;
                }
                if(curY > Height || curY < 0)
                {
                    dy[i] *= -1;
                }
                labels[i].Location = new Point(curX + dx[i], curY + dy[i]);
            }
        }
        private void PlayerControl(object sender, KeyPressEventArgs e)
        {
            if (gameOver) return;
            char pressed = e.KeyChar;
            int newX = 0, newY = 0;
            switch (pressed)
            {
                case 'a':
                    newX = Player.Location.X;
                    newX -= shipShift;
                    if(newX < 0)
                    {
                        newX = Width - Player.Width;
                    }
                    Player.Location = new Point(newX, Player.Location.Y);
                    break;
                case 'd':
                    newX = Player.Location.X;
                    newX += shipShift;
                    newX %= Width;

                    Player.Location = new Point(newX, Player.Location.Y);
                    break;
                case 'w':
                    newY = Player.Location.Y;
                    newY -= shipShift;
                    if (newY < 0)
                    {
                        newY = Width - Player.Height;
                    }

                    Player.Location = new Point(Player.Location.X, newY);
                    break;
                case 's':
                    newY = Player.Location.Y;
                    newY += shipShift;
                    newY %= Height;

                    Player.Location = new Point(Player.Location.X, Player.Location.Y + shipShift);
                    break;
                case 'f':
                    if (!(timer1.Enabled))
                    {
                        InitBullet();
                        Controls.Add(bullet);
                        timer1.Enabled = true;
                    }
                    break;
            }
        }
        public static void InitBullet()
        {
            bullet = new Label();
            bulletX = Player.Location.X + 20;
            bulletY = Player.Location.Y - 20;
            bullet.Location = new Point(bulletX, bulletY);
            Image image = Image.FromFile(@"C:\Users\Sony\source\repos\AsteroidGame\AsteroidGame\assets\spaceship.jpg");
            bullet.Size = new Size(image.Width, image.Height);
            bullet.Image = image;
        }
        private void Shout(object sender, EventArgs e)
        {
            if(bullet.Location.Y < -(bullet.Height) - 10)
            {
                timer1.Enabled = false;
            } else
            {
                bullet.Location = new Point(bullet.Location.X, bullet.Location.Y - 10);
                for (int i = 0; i < labels.Count; i++)
                {
                    int xCalc = bullet.Location.X + bullet.Width, yCalc = bullet.Location.Y + bullet.Height;
                    int xLCalc = labels[i].Location.X + labels[i].Width, yLCalc = labels[i].Location.Y + labels[i].Height;
                    if (touch(bullet.Location.X, bullet.Location.Y, xCalc, yCalc, labels[i].Location.X, labels[i].Location.Y, xLCalc, yLCalc))
                    {
                        bullet.Size = new Size(0, 0);
                        labels[i].Size = new Size(0, 0);
                        die[i] = true;
                    }
                }
            }
        }
    }
}
