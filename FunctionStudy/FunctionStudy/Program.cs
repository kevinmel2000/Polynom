using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[] prefix = { -9, 2, 0 };

            double[] prefix = { 1, -2, 1, 0 };
            Polynom pol = new Polynom(prefix);
            Section section = new Section(-1, 1);

            Console.WriteLine("Cut points: ");
            foreach (Point point in pol.FindCutPoints(section))
            {
                Console.WriteLine($"({point.X}, {point.Y})");
            }

            Console.WriteLine("Extreme points: ");
            foreach (Point point in pol.FindExtPoints(section))
            {
                Console.WriteLine($"({point.X}, {point.Y})");
            }

            Console.ReadKey();
        }
    }
}
