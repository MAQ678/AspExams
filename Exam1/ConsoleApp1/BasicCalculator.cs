using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BasicCalculator : IBasicCalculator
    {
        public long Add(long a, long b)
        {
            return a + b;
        }

        public double Divide(long a, long b)
        {
            return a / (double)b;
        }

        public long Multiply(long a, long b)
        {
            return a * b;
        }

        public long Subtract(long a, long b)
        {
            return a - b;
        }
    }
}
