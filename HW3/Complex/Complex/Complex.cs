using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        public int a, b;
        public Complex(int a,int b)
        {
            this.a = a;
            this.b = b;
        }
        public Complex()
        {
            a = 0;
            b = 0;
        }
        public static Complex operator + (Complex c1,Complex c2)
        {
            Complex res = new Complex();
            int curAD = c1.b, curBD = c2.b;
            int curAU = c1.a, curBU = c2.a;
            int lca = curAD / Calc(curAD, curBD) * curBD;
            int toMultA = lca / curAD,toMultB = lca / curBD;
            curAU *= toMultA;
            curBU *= toMultB;
            int finalAU = curAU + curBU;
            int finalAD = lca;
            int curGcd = Calc(finalAU, finalAD);
            res.a = finalAU / curGcd;
            res.b = finalAD / curGcd;
            return res;

        }
        public static int Calc(int a,int b)
        {
            if (b == 0) return a;
            else return Calc(b, a % b);
        }
        public override string ToString()
        {
            return a + " " + b;
        }
    }
}
