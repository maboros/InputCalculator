using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOM_Seminarski_State
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to InputCalculator.");
            Console.WriteLine("It calculates equations based on the state of operators given beforehand, default is addition");
            Console.WriteLine("Here is an example:");
            InputCalculator calculator = new InputCalculator("+ 3 7 9 * 10,4 2 / 2 - 5 - -4,2 12");
            calculator.Calculate();
            Console.WriteLine("Do you wish to input your own equation:(y for yes)");
            while (Console.ReadLine().Equals("y"))
            {
                Console.WriteLine("Input your own equation, each number and operator separated by a space, use commas for decimal numbers:");
                string owninput = Console.ReadLine();
                calculator = new InputCalculator(owninput);
                calculator.Calculate();
                Console.WriteLine("Do you wish to input another equation:(y for yes)");
            }
            Console.WriteLine("Thank you for using InputCalculator.");
            Console.WriteLine("Press any key to terminate program.");
            Console.ReadLine();
        }
    }
}
