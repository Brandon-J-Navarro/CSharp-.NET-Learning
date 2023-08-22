using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Progam
    {
        static void Main(string[] args)
        {
            try
            {
                InputConverter inputConvert = new InputConverter();
                CalculatorEngine calculatorEngine = new CalculatorEngine();

                Console.WriteLine("Enter your First Number:");
                double firstNumber = inputConvert.ConvertInputToNumeric(Console.ReadLine());

                Console.WriteLine("Enter your Numeric Operation (i.e '+', '-', '*', '/'):");
                string opertion = Console.ReadLine();

                Console.WriteLine("Enter you Second Number:");
                double secondNumber = inputConvert.ConvertInputToNumeric(Console.ReadLine());
            
                double result = calculatorEngine.Calculate(opertion,firstNumber,secondNumber);
                Console.WriteLine("The answer is: ");
                Console.WriteLine(result);

            }
            catch (Exception ex)
            {
                // TODO: Write to application logs
                Console.WriteLine(ex.Message);
            }

        }
    }
}