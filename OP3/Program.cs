using Stack;
using Queue;
using System;
using System.Collections;


namespace OP3
{

    class Program
    {
        static bool IsInt(string args)
        {
            int res;
            bool isInt = Int32.TryParse(args, out res);
            return isInt;
        }
        static void Output(Stack<double> Output)
        {
            while(Output.Count > 0)
            {
                Console.WriteLine(Output.Pop());
            }
        }
        static double HashTable(Queue<string> List)
        {
            Stack<double> Numbers = new Stack<double>(5);
            while(List.Count > 0)
            {
                string s = List.Dequeue();
                if (IsInt(s))
                {
                    Numbers.Push(Convert.ToDouble(s));
                }
                else
                {
                    if (Numbers.Count < 2)
                    {
                        Console.WriteLine("error");
                        return -1.0;
                    }
                    else
                    {
                        double value1, value2;
                        value1 = Numbers.Pop();
                        value2 = Numbers.Pop();
                        double result = 0.0;
                        if (s == "+")
                        {
                            result = addValues(value1, value2);   
                        }
                        else if (s == "-")
                        {
                            result = subtractValues(value1, value2);
                        }
                        else if (s == "*")
                        {
                            result = multiplyValues(value1, value2);
                        }
                        else if (s == "/")
                        {
                            result = divideValues(value1, value2);
                        }
                        Numbers.Push(result);
                    }
                }
            }
            if(Numbers.Count == 1)
            {
                double outcome = Numbers.Pop();
                Console.WriteLine(outcome);
                return outcome;
            }
            else
            {
                Console.WriteLine("error in calculation");
                return -1.0;
            }
        }
        static Queue<string> ToPostFix(string[] args, Stack<string> Operators, Queue<string> Numbers)
        {
            for(int i = 0; i < args.Length; i++)
            {
                if(IsInt(args[i]))
                {
                    Numbers.Enqueue(args[i]);
                }
                
                else if (operatorPrecedence(args[i]) != -1)
                { 
                    while(Operators.Count != 0 && operatorPrecedence(Operators.Peek()) >= operatorPrecedence(args[i]))
                    {
                        Numbers.Enqueue(Operators.Pop());
                    }
                    Operators.Push(args[i]);
                }
                else if(args[i] == "(")
                {
                     Operators.Push(args[i]);
                }
                else if(args[i] == ")")
                {
                    while(Operators.Peek() != "(")
                    {
                        Numbers.Enqueue(Operators.Pop());
                    }
                    Operators.Pop();
                }
            }
            while (Operators.Count > 0)
            {
                Numbers.Enqueue(Operators.Pop());
            }
            return (Numbers);
        }
        static int operatorPrecedence(string n)
        {
            int precedence = -1;
            char c = n[0];
            switch (c)
            {
                case '+':
                case '-':
                    precedence = 2;
                    break;
                case '*':
                case '/':
                    precedence = 3;
                    break;
                case '^':
                    precedence = 4;
                    break;

                default:
                    precedence = -1;
                    break;
            }
            return precedence;
        }
        static double subtractValues(double a, double b)
        {
            double difference = b - a;
            return difference;
        }

        static double addValues(double a, double b)
        {
            double sum = a + b;
            return sum;
        }

        static double divideValues(double a, double b)
        {
            double quotient = b / a;
            return quotient;
        }

        static double multiplyValues(double a, double b)
        {
            double product = a * b;
            return product;
        }
        static void Main(string[] args)
        {
            Stack<string> Operators = new Stack<string>(args.Length);
            Queue<string> Numbers = new Queue<string>(args.Length);
            ToPostFix(args, Operators, Numbers);
            HashTable(Numbers);
        }
    }

}
