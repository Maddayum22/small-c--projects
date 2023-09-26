using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InputConverter inputConverter = new InputConverter();
                CalculatorEngine calculatorEngine = new CalculatorEngine();

                Console.WriteLine("Enter first number:");
                double firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                Console.WriteLine("Enter second number:");
                double secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                Console.WriteLine("Enter operation type:");
                string operation = Console.ReadLine();

                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}