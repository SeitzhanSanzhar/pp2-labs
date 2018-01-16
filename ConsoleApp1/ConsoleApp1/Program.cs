using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Sony\Desktop\in.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string curN = sr.ReadLine();
            int n = Convert.ToInt32(curN);
            int[] a = new int[n + 1];
            int maxi = -1;
            for(int i = 1;i <= n;i ++) {
                a[i] = Convert.ToInt32(sr.ReadLine());
                if (a[i] > maxi) maxi = a[i];
            }
            sr.Close();
            fs.Close();
            FileStream fs1 = new FileStream(@"C:\Users\Sony\Desktop\out.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(maxi);
            sw.Close();
            fs1.Close();
        }
    }
}
