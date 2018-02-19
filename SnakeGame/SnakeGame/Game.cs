using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
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
    }
}
