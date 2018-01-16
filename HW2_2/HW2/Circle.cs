using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Circle
    {
        public double r;
        public Circle(double r)
        {
            this.r = r;
        }
        public double CalcAre()
        {
            return Math.PI * r * r;
        }
    }
}
