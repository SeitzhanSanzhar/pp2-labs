using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n + 1];
            int cnt = 0;
            int[] ans = new int[n + 1];
            for(int i = 1;i <= n;i ++ )
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
                bool Find = false;
                for(int j = 2;j * j <= a[i];j ++)
                {
                    if(a[i] % j == 0)
                    {
                        Find = true;
                        break;
                    }
                }
                if (Find == false)
                {
                    ++cnt;
                    ans[cnt] = a[i];
                }
            }
            for(int i = 1;i <= cnt;i ++)
            {
                Console.WriteLine(ans[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
