using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Snake
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor snakeColor;

        public Snake()
        {
            sign = 'O';
            snakeColor = ConsoleColor.Green;
            body = new List<Point>();
            body.Add(new Point(12, 10));
            body.Add(new Point(11, 10));
            body.Add(new Point(10, 10));
        }

        public void Move(int dx,int dy,Wall wall)
        {
            for(int i = body.Count - 1;i > 0;i --)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;

            for(int i = 0;i < body.Count;i ++)
            {
                for(int j = 0;j < wall.wall.Count;j ++)
                {
                    if(body[i].x == wall.wall[j].x && body[i].y == wall.wall[j].y)
                    {
                        Console.Clear();
                        while(true)
                        {
                            Console.WriteLine("GAME OVER");
                        }
                    }
                }
            }
        }
        public bool Eat(Food food)
        {
            if(body[0].x == food.position.x && body[0].y == food.position.y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));
                return true;
            }
            return false;
        }
        public void DrawSnake()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(body[0].x, body[0].y);
            Console.Write(sign);
            Console.ForegroundColor = snakeColor;

            for(int i = 1;i < body.Count();i ++)
            {
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(sign);
            }
        }
    }
}
