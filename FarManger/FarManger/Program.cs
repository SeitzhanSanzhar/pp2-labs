using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManger
{
    class Program
    {
        public static void showDir(DirectoryInfo dir, int pos)
        {
            FileSystemInfo[] files = dir.GetFileSystemInfos();
            if (files.Length <= 20)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (i == pos)
                        Console.BackgroundColor = ConsoleColor.White;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    if (files[i].GetType() == typeof(DirectoryInfo))
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(files[i].Name);
                }
            } 
            else
            {
                for(int i = 0; i < 20;i ++)
                {
                    if (i == pos)
                        Console.BackgroundColor = ConsoleColor.White;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    if (files[i].GetType() == typeof(DirectoryInfo))
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(files[i].Name);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Sony\Desktop\");

            int pos = 0;

            while (true)
            {
                Console.Clear();
                showDir(dir, pos);
                ConsoleKeyInfo pressed = Console.ReadKey();
                
                switch (pressed.Key) {
                    case ConsoleKey.UpArrow:
                        pos--;
                        if (pos < 0) pos = dir.GetFileSystemInfos().Length - 1;
                    break;
                    case ConsoleKey.DownArrow:  
                        pos++;
                        if (pos >= dir.GetFileSystemInfos().Length - 1) pos = 0;
                    break;
                    case ConsoleKey.Enter:
                        FileSystemInfo cur = dir.GetFileSystemInfos()[pos];
                        if (cur.GetType() == typeof(DirectoryInfo))
                        {
                            pos = 0;
                            dir = new DirectoryInfo(cur.FullName);
                        }
                        else
                        {
                            Console.Clear();
                            FileStream fs = new FileStream(cur.FullName, FileMode.Open, FileAccess.ReadWrite);
                            StreamReader sr = new StreamReader(fs);
                            string[] arr = new string[100100];
                            int cnt = 0;
                            while(true)
                            {
                                string s = sr.ReadLine();
                                if(s == null || s.Length == 0)
                                {
                                    break;
                                }
                                Console.WriteLine(s);
                            }
                            while (true)
                            {
                                ConsoleKeyInfo curB = Console.ReadKey();
                                if (curB.Key == ConsoleKey.Escape) break;
                            }
                            fs.Close();
                            sr.Close();
                        }

                    break;
                    case ConsoleKey.Escape:
                        pos = 0;
                        dir = dir.Parent;
                    break;
                }
            }
        }
    }
}
