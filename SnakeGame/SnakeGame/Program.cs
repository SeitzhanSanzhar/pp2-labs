﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 20);

            Wall map = new Wall();
            Snake snake = new Snake();
            Food food = new Food();

            while(true)
            {
                Console.Clear();
                snake.DrawSnake();
                food.DrawFood();
                map.DrawMap();

                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Move(0, -1, map);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Move(0, 1, map);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Move(-1, 0, map);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Move(1, 0, map);
                        break;
                }

                if (snake.body[0].x > 69)
                    snake.body[0].x = 0;
                if (snake.body[0].x < 0)
                    snake.body[0].x = 69;

                if (snake.Eat(food))
                {
                    food.SetRandomPosition(snake,map);
                }
            }

        }
    }
}
