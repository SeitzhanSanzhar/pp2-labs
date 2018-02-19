using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 20);

            Thread t = new Thread(Move);
            t.Start();

            while(!Game.Gameover)
            {
                if (Game.Gameover == true) break;
                ConsoleKeyInfo btn = Console.ReadKey();
                if (btn.Key == ConsoleKey.RightArrow && Game.snake.dir != 3) Game.snake.dir = 1;
                if (btn.Key == ConsoleKey.DownArrow && Game.snake.dir != 4) Game.snake.dir = 2;
                if (btn.Key == ConsoleKey.LeftArrow && Game.snake.dir != 1) Game.snake.dir = 3;
                if (btn.Key == ConsoleKey.UpArrow && Game.snake.dir != 2) Game.snake.dir = 4;
            }
        }
        public static void Move()
        {
            while(!Game.Gameover)
            {
                if (Game.Gameover == true) break;
                Game.Draw();
                DrawScore();
                if (Game.snake.dir == 4) Game.snake.Move(0, -1,Game.wall);
                if (Game.snake.dir == 2) Game.snake.Move(0, 1, Game.wall);
                if (Game.snake.dir == 3) Game.snake.Move(-1, 0,Game.wall);
                if (Game.snake.dir == 1) Game.snake.Move(1, 0, Game.wall);
                Thread.Sleep(200);
            }
            GameEnd();
        }
        public static void DrawScore()
        {
            Console.SetCursorPosition(25, 25);
            Console.WriteLine("Score: " + Game.score);
        }
        public static void GameEnd()
        {
            Console.Clear();
            Console.WriteLine("Game over, enter user name:");
            string name = Console.ReadLine();
            FileStream fs = new FileStream(@"C:\Users\Sony\Desktop\res.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(name);
            sw.Close();
            fs.Close();
        }
    }
}
