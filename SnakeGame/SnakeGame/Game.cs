using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    [Serializable]
    class Game
    {
        static public Snake snake = new Snake();
        static public Wall wall = new Wall();

        static public int level = 1;
        static public bool Gameover = false;

        static public Food food = new Food();
        static public int score = 0;
        

        public static void Draw()
        {
            Console.Clear();
            wall.DrawMap();
            food.DrawFood();
            snake.DrawSnake();
        }

        public static void Set(DataSave x)
        {
            if (x.GameOver == false)
            {
                level = x.level;
                snake = x.snake;
                wall = x.wall;
                food = x.food;
                score = x.score;
                Gameover = x.GameOver;
            }
            else
            {
                snake = new Snake();
                wall = new Wall();
                food = new Food();
                score = 0;
                Gameover = false;
                level = 0;
            }
        }
    }
}
