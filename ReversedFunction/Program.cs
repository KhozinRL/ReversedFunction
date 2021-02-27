using System;


namespace ReversedFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            double power = -4;
            Double epsilon = Math.Pow(10, power);
            ReversedFunction.AccuracyUpdated += printResolution;

            //Делегат
            Func<double, double> sinDelegate = Math.Sin;
            double sinResult = ReversedFunction.reversedFunction((0.1, 1.3), sinDelegate, 0.5, epsilon);
            Console.WriteLine("При x = {0:f5} функция sin(x) = 0.5 \n", sinResult);

            //Анонимный метод
            Func<double, double> secondDelegate = delegate (double x) { return x * x + Math.Sin(x - 2); };
            double secondResult = ReversedFunction.reversedFunction((2.5, 3.5), secondDelegate, 8, epsilon);
            Console.WriteLine("При x = {0:f5} функция x*x + sin(x-2) = 8 \n", secondResult);

            //Лямбда
            double expResult = ReversedFunction.reversedFunction((-3, 0), x => Math.Exp(-x), 9, epsilon);
            Console.WriteLine("При x = {0:f5} функция exp(-x) = 9 \n", expResult);
        }

        static void printResolution(double resolution) {
            Console.WriteLine("Текущее разрешение: {0:f6}", resolution);
        }
 
    }
}
