using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueWordUnscramble = true;

            do
            {
                Console.WriteLine("Please enter option: F for File, M for Manual");
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper())
                {
                    case "F":
                        Console.Write("Enter scrambled words file name: ");
                        ExecuteFileScenario();
                        break;
                    case "M":
                        Console.Write("Enter scrambled words manually: ");
                        ExecuteManualScenario();
                        break;
                    default:
                        Console.Write("Option was not recognized.");
                        break;
                }

                var continueDecision = string.Empty;

                do
                {

                    Console.WriteLine("Do you want to continue? (Y or N)");
                    continueDecision = Console.ReadLine() ?? string.Empty;

                } while (!continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) 
                && !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

                continueWordUnscramble = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueWordUnscramble);
        }

        private static void ExecuteManualScenario()
        {
            throw new NotImplementedException();
        }

        private static void ExecuteFileScenario()
        {
            throw new NotImplementedException();
        }
    }
}
