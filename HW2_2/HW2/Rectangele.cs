using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Rectangele
    {
        public int w, h;
        public Rectangele(int _h, int _w)
        {
            h = _h;
            w = _w;
        }


        public int CalcArea()
        {
            return h * w;
        }
        public int calcPerim()
        {
            return 2 * (h + w);
        }
    }
}
