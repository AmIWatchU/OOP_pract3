using System;

namespace prak3_oop_console
{
    class Program
    {
        static double Function(double x)
        {
            return x * x;
        }
        static void Main(string[] args)
        {
            StartOfCalculations:
            //Введiть початок вiдрiзку iнтегрування a://
            Console.Write("Enter the beginning of the integration segment a: ");
            string sa = Console.ReadLine();
            double a = double.Parse(sa);
            //Введiть кiнець вiдрiзку iнтегрування b://
            Console.Write("Enter the end of the integration segment b: ");
            string sb = Console.ReadLine();
            double b = double.Parse(sb);
            //Введiть кiлькiсть дiлянок n://
            Console.Write("Enter the number of plots n: ");
            string sn = Console.ReadLine();
            double n = double.Parse(sn);
            double dx = (b - a) / n;
            double y1, y2;
            double x1, x2;
            double Intgrl = 0;
            for (int i = 0; i < n; i++)
            {
                x1 = a + i * dx;
                x2 = x1 + dx;
                y1 = Function(x1);
                y2 = Function(x2);
                Intgrl += (y1 + y2) / 2 * dx;
            }
            //Iнтеграл функцiї на вiдрiзку [{0}, {1}] становить {2:0.0000}//
            Console.WriteLine("The integral of the function on the segment [{0}, {1}] is {2: 0.0000}", a, b,Intgrl);
            //Повторити розрахунок (y - так)?//
            Console.Write("Repeat the calculation (y/n)?: ");
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            Console.WriteLine();
            if (pressedKey.Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                goto StartOfCalculations;
            }
            else if(pressedKey.Key == ConsoleKey.N)
            {
                Console.WriteLine("Goodbye");
                return;
            }
        }
    }
}
