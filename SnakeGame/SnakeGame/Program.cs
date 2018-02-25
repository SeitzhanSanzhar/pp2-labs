using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    [Serializable]
    class Program
    {
        static List<Player> rating = new List<Player>();
        static int pos = 0;

        static void Main(string[] args)
        {

            rating = GetRating();

            MainMenu();

            DataSave data = DataGet();

            Game.Set(data);

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

        public static void MainMenu()
        {
            string[] menu = { "rating", "game" };
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < menu.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = (pos == i) ? ConsoleColor.DarkCyan : ConsoleColor.Black;
                    Console.WriteLine(menu[i]);
                }

                ConsoleKeyInfo btn = Console.ReadKey();
                if (btn.Key == ConsoleKey.UpArrow) pos = ((pos == 0) ? pos = 1 : pos - 1);
                if (btn.Key == ConsoleKey.DownArrow) pos = (pos + 1) % 2;
                if (btn.Key == ConsoleKey.Enter)
                {
                    if (pos == 1) break;
                    ShowRating();
                    while (Console.ReadKey().Key != ConsoleKey.Escape) ;
                }
            }
        }
        
        public static void ShowRating()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Name" + rating.Count);
            Console.SetCursorPosition(30, 0);
            Console.WriteLine("Score");

            for (int i = rating.Count - 1; i >= 0; --i)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(rating[i].name);
                Console.SetCursorPosition(30, rating.Count - i);
                Console.WriteLine(rating[i].score);
            }


        }
        

        static void SaveRating(List<Player> rate)
        {
            FileStream fs = new FileStream(@"data.ser", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs, rate);
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        static List<Player> GetRating()
        {
            FileStream fs = new FileStream(@"data.ser", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();

            List < Player > res = new List<Player>();
            try
            {
                res = (List<Player>)bf.Deserialize(fs);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            return res;
        }

        public static void Move()
        {
            Game.Draw();
            bool drawed1 = false, drawed2 = false, drawed3 = false;
            while(!Game.Gameover)
            {
                if (Game.Gameover == true) break;

                Game.snake.DrawSnake();
                DrawScore();
                SaveGame(new DataSave());

                if (Game.snake.dir == 4) Game.snake.Move(0, -1,Game.wall);
                if (Game.snake.dir == 2) Game.snake.Move(0, 1, Game.wall);
                if (Game.snake.dir == 3) Game.snake.Move(-1, 0,Game.wall);
                if (Game.snake.dir == 1) Game.snake.Move(1, 0, Game.wall);

                if(Game.score == 3 && !drawed1)
                {
                    Console.Clear();
                    Game.wall.DrawMap();
                    Game.snake.DrawSnake();
                    Game.food.DrawFood();
                    DrawScore();
                    drawed1 = true;
                }

                if(Game.score == 6 && !drawed2) {
                    Console.Clear();
                    Game.wall.DrawMap();
                    Game.snake.DrawSnake();
                    Game.food.DrawFood();
                    DrawScore();
                    drawed2 = true;
                }

                if (Game.score == 9 && !drawed3)
                {
                    Console.Clear();
                    Game.wall.DrawMap();
                    Game.snake.DrawSnake();
                    Game.food.DrawFood();
                    DrawScore();
                    drawed3 = true;
                }

                Thread.Sleep(100);
            }
            GameEnd();
        }
        static void SaveGame(DataSave x)
        {
            FileStream fs = new FileStream(@"dataGame.ser", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, x);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        public static void DrawScore()
        {
            Console.SetCursorPosition(25, 25);
            Console.WriteLine("Level:" + Game.level);
            Console.SetCursorPosition(26, 26);    
            Console.WriteLine("Score: " + Game.score);
        }
        public static void GameEnd()
        {
            Console.Clear();
            Console.WriteLine("Game over, enter user name:");
            SaveGame(new DataSave());
            string name = Console.ReadLine();

            if (name.Length > 0)
                rating.Add(new Player(name, Game.score));
   
            rating.Sort((x, y) => x.score.CompareTo(y.score));
            SaveRating(rating);
            ShowRating();
            Console.ReadKey();
        }
        static DataSave DataGet()
        {
            FileStream fs = new FileStream(@"dataGame.ser", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            DataSave res = new DataSave();
            try
            {
                res = (DataSave)bf.Deserialize(fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            return res;
        }
    }
}
