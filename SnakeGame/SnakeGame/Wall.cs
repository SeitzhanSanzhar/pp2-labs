﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    [Serializable]
    class Wall
    {
        public  List<Point> wall;
        public char symbole;
        public ConsoleColor consoleColor;

        public Wall()
        {
            symbole = '#';
            consoleColor = ConsoleColor.Red;
            wall = new List<Point>();
            ShowMapLevel(1);
        }

        public void ShowMapLevel(int idLevel)
        {
            string fileName = @"C:\Users\Sony\Desktop\level" + idLevel + ".txt";

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            for(int row = 0;row < 20;row ++)
            {
                string cur = sr.ReadLine();
                for(int i = 0;i < cur.Length;i ++)
                {
                    if(cur[i] == '*')
                    {
                        wall.Add(new Point(i, row));
                    }
                }
            }
        }
        public void DrawMap()
        {
            if (Game.score == 3)
            {
                ShowMapLevel(1);
                Game.level = 2;
            }
            if (Game.score == 6)
            {
                ShowMapLevel(2);
                Game.level = 2;
            }
            if (Game.score == 9)
            {
                ShowMapLevel(3);
                Game.level = 3;
            }

            Console.ForegroundColor = consoleColor;

            for (int i = 0;i < wall.Count;i ++)
            {
                Console.SetCursorPosition(wall[i].x, wall[i].y);
                Console.Write(symbole);
            }
        }
    }
}