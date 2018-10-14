using System;

namespace MathExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Implement a basic calculator to evaluate a simple expression string.
            //The expression string may contain open(and closing parentheses ), the plus +or minus sign -, non - negative integers and empty spaces .
            //Input: "(1+(4+5+2)-3)+(6+8)"
            //Output: 23

            //var res = BasicCalculator.CalculateAddAndSubExp("2-1+1");
            //Console.WriteLine(res);
            //res = BasicCalculator.CalculateAddAndSubExp("(1+(4+5+2)-3)+(6+8)");
            //Console.WriteLine(res);
            //res = BasicCalculator.CalculateAddAndSubExp("1-(5)");
            //Console.WriteLine(res);

            int res = BasicCalculator.CalculateMuxAndDivExp("12-3*4");
            Console.WriteLine(res);

            Console.ReadLine();
        }
    }
}
