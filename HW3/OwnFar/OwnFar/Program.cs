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
        public static Stack< Tuple<string,int> > closed = new Stack<Tuple<string, int> >();
        public static void ShowInfo()
        {
            if (closed.Count() == 0) return;
            while(closed.Count() != 0)
            {
                Tuple<string, int> last = closed.Pop();
                
                int depth = last.Item2;
                string fullName = last.Item1;

                DirectoryInfo dir = new DirectoryInfo(fullName);
                FileSystemInfo[] infos = dir.GetFileSystemInfos();

                for (int j = 0; j < depth; j++) Console.Write(" ");
                foreach(FileSystemInfo cur in infos)
                {
                    Console.WriteLine(cur.Name);
                    if(cur.GetType() == typeof(DirectoryInfo))
                    {
                        Tuple<string, int> add = new Tuple<string, int>(cur.FullName, depth + 4);
                        closed.Push(add);
                        ShowInfo();
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Tuple<string,int> start = new Tuple<string, int>(@"C:\Users\Sony\Desktop\ACM", 0);
            closed.Push(start);
            ShowInfo();
            Console.ReadKey();
        }
    }
}
