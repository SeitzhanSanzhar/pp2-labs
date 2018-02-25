using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    [Serializable]
    class Food
    {
        public Point position = new Point();
        public char sign;
        public ConsoleColor color;

        public Food()
        {
            color = ConsoleColor.Blue;
            sign = '@';
            position.x = 3;
            position.y = 17;
        }

        public void SetRandomPosition(Snake snake, Wall wall)
        {
            int x = new Random().Next(3, 17);
            int y = new Random().Next(3, 17);
            
            while(true)
            {
                bool flag = false;
                for(int i = 0;i < wall.wall.Count;i ++)
                {
                    if(wall.wall[i].x == x && wall.wall[i].y == y)
                    {
                        flag = true;
                        break;
                    }
                }
                for(int i = 0;i < snake.body.Count;i ++)
                {
                    if(snake.body[i].x == x && snake.body[i].y == y)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                    break;

                x = new Random().Next(3, 17);
                y = new Random().Next(3, 17);
            }
            position = new Point(x, y);
        }


        public void DrawFood()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(sign);
        }
    }
}
