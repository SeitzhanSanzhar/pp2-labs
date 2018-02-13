using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    class Program
    {
        public static StreamWriter StreamWriter { get; private set; }

        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Sony\Desktop\in.txt", FileMode.Open, FileAccess.Read);
            StreamReader st = new StreamReader(fs);

            string s = st.ReadLine();
            int n = int.Parse(s);
   
            fs.Close();
            st.Close();

            FileStream fs1 = new FileStream(@"C:\Users\Sony\Desktop\in.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);

            for (int i = 1;i * i <= n;i ++)
            {
                if(n % i == 0)
                {
                    sw.WriteLine(i);
                    sw.WriteLine(n / i);
                }
            }
            fs1.Close();
            sw.Close();

       }
    }
}
