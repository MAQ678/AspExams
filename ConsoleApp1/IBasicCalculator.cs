using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IBasicCalculator
    {
        long Add(long a, long b);
        long Subtract(long a, long b);
        long Multiply(long a, long b);
        double Divide(long a, long b);
    }
}
