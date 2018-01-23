using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Take(4).Select(int.Parse).ToArray();
            Complex a = new Complex(arr[0], arr[1]),b = new Complex(arr[2],arr[3]);
            Console.WriteLine(a + b);
            Console.ReadKey();
        }
    }
}
