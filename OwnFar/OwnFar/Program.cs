using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnFar
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> sn = new Stack<string>();
            string root = "C:\";
            DirectoryInfo dirs = new DirectoryInfo(@"C:\");
            DirectoryInfo[] curDirs = dirs.GetDirectories();
            foreach(DirectoryInfo curDir in curDirs)
            {
                Console.WriteLine(curDir.Name);
                sn.Push(curDir.Name);
            }
        }
    }
}
