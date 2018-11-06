using System;
using System.Collections.Generic;

namespace MathExpressions
{
    public class BasicCalculator
    {
        //Implement a basic calculator to evaluate a simple expression string.
        //The expression string may contain open(and closing parentheses ), the plus +or minus sign -, non - negative integers and empty spaces .
        //Input: "(1+(4+5+2)-3)+(6+8)"
        //Output: 23
        public static int CalculateAddAndSubExp(string s)
        {
            int result = 0;
            int num = 0;
            int sign = 1;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                // find the number by verifying the digit
                if (Char.IsDigit(s[i]))
                {
                    num = s[i] - '0';
                    while( i+1 < s.Length && Char.IsDigit(s[i+1]))
                    {
                        num = num * 10 + (s[i + 1] - '0');
                        i++;
                    }
                    result = result + ( num * sign); //make the number as +ve or -ve
                }
                else if (s[i] == '+')
                {
                    sign = 1;
                }
                else if (s[i] == '-')
                {
                    sign = -1;
                }
                else if (s[i] == '(') // When a start ( encountered, push the current result and the sign to stack
                {
                    stack.Push(result);
                    stack.Push(sign);
                    result = 0;
                    sign = 1;
                }
                else if (s[i] == ')') // When ) encountered, perform the operation on the current result with the value from stack
                {
                    result =  result * stack.Pop() + stack.Pop();
                }
            }
            return result;
        }

        public static int CalculateMuxAndDivExp(string s)
        {
            int sign = 1;
            int result = 0;
            int num = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]))
                {
                    num = s[i] - '0';
                    while (i + 1 < s.Length && Char.IsDigit(s[i + 1]))
                    {
                        num = num * 10 + (s[i + 1] - '0');                        
                        i++;
                    }
                    stack.Push(num * sign);
                }
                else if (s[i] == '+')
                {
                    sign = 1;                    
                }
                else if (s[i] == '-')
                {
                    sign = -1;
                }
                else if (s[i] == '*')
                {                    
                    int next = 0;
                    while (i + 1 < s.Length && (Char.IsDigit(s[i + 1]) || s[i+1].Equals(' ')))
                    {
                        if (Char.IsDigit(s[i + 1]))
                            next = next * 10 + (s[i + 1] - '0');
                        i++;
                    }
                    stack.Push(stack.Pop() * next);
                }
                else if (s[i] == '/')
                {                    
                    int next = 0;
                    while (i + 1 < s.Length && (Char.IsDigit(s[i + 1]) || s[i + 1].Equals(' ')))
                    {
                        if (Char.IsDigit(s[i + 1]))
                            next = next * 10 + (s[i + 1] - '0');
                        i++;
                    }
                    stack.Push(stack.Pop() / next);
                }                
            }
            while(stack.Count > 0)
            {
                result += stack.Pop();
            }
            return result;
        }

        public int CalculateMuxAndDiv2(string s)
        {
            char[] chars = s.ToCharArray();
            Stack<int> workingStack = new Stack<int>();
            char op = '+';
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == ' ')
                {
                    continue;
                }
                int num = 0;
                while ((i < chars.Length) && chars[i] >= '0' && chars[i] <= '9')
                {
                    num = num * 10 + (int)(chars[i] - '0');
                    i++;
                }

                if (op == '+')
                {
                    workingStack.Push(num);
                }
                if (op == '-')
                {
                    workingStack.Push(0 - num);
                }
                if (op == '*')
                {
                    workingStack.Push(workingStack.Pop() * num);
                }
                if (op == '/')
                {
                    workingStack.Push(workingStack.Pop() / num);
                }
                while ((i < chars.Length) && (chars[i] == ' '))
                {
                    i++;
                }
                if (i < chars.Length)
                {
                    op = chars[i];
                }
            }

            int finalValue = 0;
            while (workingStack.Count != 0)
            {
                finalValue += workingStack.Pop();
            }
            return finalValue;
        }

    }
}
