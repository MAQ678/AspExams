using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ScientificCalculator : BasicCalculator, IScientificCalculator
    {
        public long Power(long a, long b)
        {
            return (long)Math.Pow(a, b);
        }

        public double SquareRoot(long a)
        {
            return Math.Sqrt(a);
        }
    }
}
