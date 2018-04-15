using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        GraphicsPath path;
        Graphics g;
        Pen pen;
        Bitmap map;
        Point prev;

        int cnt = 0;
        string state = "pen";
        int[,] used = new int[1001, 1001];

        Queue<Point> q = new Queue<Point>();

        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Red, 3);
            path = new GraphicsPath();
            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = map;
            g = Graphics.FromImage(map);
            g.Clear(Color.White);
        }

        public bool Can(int X,int Y,Color c)
        {
            if (X >= map.Width || X < 0 || Y < 0 || Y >= map.Height) return false;
            if (used[X, Y] == cnt) return false;
            if (map.GetPixel(X, Y) != c) return false;
            return true;
        }

        public void Fill(Point start)
        {
            Color btmStart = map.GetPixel(start.X, start.Y);
            if (btmStart.R == pen.Color.R && btmStart.G == pen.Color.G && btmStart.B == pen.Color.B) return;
            q.Enqueue(start);
            while(q.Count != 0)
            {
                Point v = q.Dequeue();
                int curX = v.X, curY = v.Y;
                for(int i = - 1;i <= 1;i ++)
                {
                    for(int j = -1;j <= 1;j ++)
                    {
                        int newX = curX + i, newY = curY + j;
                        if(Can(newX,newY,btmStart))
                        {
                            map.SetPixel(newX, newY, pen.Color);
                            used[newX, newY] = cnt;
                            q.Enqueue(new Point(newX,newY));
                        }
                    }
                }
            }
            ++cnt;
        }
        private void MouseDown(object sender, MouseEventArgs e)
        {
            prev = e.Location;
            if (state == "Fill")
            {
                Fill(e.Location);
                Refresh();
            }
        }
        public int Race(Point A,Point B)
        {
            if(A.X == B.X)
            {
                if (A.Y > B.Y) return -1;
                if (A.Y < B.Y) return 1;
                return 0;
            }
            else
            {
                if (A.X > B.X) return -1;
                if (A.X < B.X) return 1;
            }
            return 0;
        }
        private void MouseMove(object sender, MouseEventArgs e)
        {
            path.Reset();
            if(e.Button == MouseButtons.Left)
            {
                Point cur = e.Location;
                Point need = new Point(prev.X, cur.Y),need1 = new Point(cur.X,prev.Y);
                List<Point> sorted = new List<Point>();

                sorted.Add(cur);
                sorted.Add(prev);
                sorted.Add(need);
                sorted.Add(need1);

                sorted.Sort(Race);

                if(state == "Pen")
                {
                    g.DrawLine(pen, cur, prev);
                    prev = cur;
                }
                if(state == "Circle")
                {
                    int sz = Math.Min(Math.Abs(sorted[1].X - sorted[2].X), Math.Abs(sorted[1].Y - sorted[2].Y));
                    path.AddEllipse(new Rectangle(sorted[1], new Size(sz, sz)));
                }
                if(state == "Rectangle")
                {

                    path.AddRectangle(new Rectangle(prev,new Size(Math.Abs(cur.X - prev.X),Math.Abs(cur.Y - prev.Y))));
                }
                if (state == "Line")
                {
                    path.AddLine(prev, cur);
                }
                pictureBox1.Refresh();
            }
        }
        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (path != null)
                g.DrawPath(pen, path);

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(pen, path);
        }
        private void ChangeState(object sender, EventArgs e)
        {
            Button pressed = sender as Button;
            string txt = pressed.Text;
            switch (txt)
            {
                case "Rec":
                    state = "Rectangle";
                    break;
                case "Circl":
                    state = "Circle";
                    break;
                case "Line":
                    state = "Line";
                    break;
                case "Pen":
                    state = "Pen";
                    break;
                case "Fill":
                    state = "Fill";
                    break;
            }
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pen.Color = colorDialog1.Color;
        }

        private void SaveImage(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "jpeg files (*.jpeg)|*.jpeg|png files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 3;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.ShowDialog();
            if(saveFileDialog1.FileName != "" && saveFileDialog1.FileName != null)
                map.Save(saveFileDialog1.FileName);
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            map = (Bitmap)Image.FromFile(openFileDialog.FileName);
            g = Graphics.FromImage(map);
            pictureBox1.Image = map;
        }

        private void ClearPictureBox(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Image = map;
        }
    }
}
