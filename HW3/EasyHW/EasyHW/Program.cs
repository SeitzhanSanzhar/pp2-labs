using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHW
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Sony\Desktop\in.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

            int n = int.Parse(sr.ReadLine());
            int[] arr = sr.ReadLine().Split(' ').Take(n).Select(int.Parse).ToArray();

            
            int maxi = arr[0], mini = arr[0], mprime = arr[0];
            for(int i = 0;i < n;i ++)
            {
                if (arr[i] < mini) mini = arr[i];
                if (arr[i] > maxi) maxi = arr[i];
                bool ok = false;
                for(int j = 2;j * j <= i;j ++)
                {
                    if (arr[i] % j == 0)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false && mprime > arr[i] && arr[i] != 1) mprime = arr[i]; 
            }

            fs.Close();
            sr.Close();

            FileStream fs1 = new FileStream(@"C:\Users\Sony\Desktop\out.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs1);

            sw.WriteLine(maxi + " " + mini + " " + mprime);

            fs.Close();
            sw.Close();
            Console.ReadKey();
        }
    }
}
