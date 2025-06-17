namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScientificCalculator scientificCalculator = new ScientificCalculator();

            Console.WriteLine(scientificCalculator.Add(10, 5));
            Console.WriteLine(scientificCalculator.Subtract(7, 2));
            Console.WriteLine(scientificCalculator.Multiply(5, 6));
            Console.WriteLine(scientificCalculator.Divide(10, 3));
            Console.WriteLine(scientificCalculator.SquareRoot(4));
            Console.WriteLine(scientificCalculator.Power(2, 3));
        }
    }
}
