using Stack;
using Queue;
using System;
using System.Collections;


namespace OP3
{

    class Program
    {
        static string[] SplitLine(string[] args)
        {
            int n = 0;
            for (int i = 0; i < args[0].Length; i++)
            {

                if (IsInt(Convert.ToString(args[0][i])) && args[0][i] != ' ')
                {
                    n++;
                    while (IsInt(Convert.ToString(args[0][i])))
                    {
                        if (i == args[0].Length - 1)
                            goto A;
                        
                        i++;
                    }
                }
                if (args[0][i] != ' ' || args[0][i] == '+' || args[0][i] == '-' || args[0][i] == '*' || args[0][i] == '/' || args[0][i] == '^' || args[0][i] == '(' || args[0][i] == ')')
                    n++;
                A:;

            }
            string[] s = new string[n];
            int a = 0;
            for(int i = 0; i < args[0].Length; i++)
            {
                if(IsInt(Convert.ToString(args[0][i])) && args[0][i] != ' ')
                {
                    
                    while(IsInt(Convert.ToString(args[0][i])))
                    {
                        if (i == args[0].Length - 1)
                        {
                            s[a] += args[0][i].ToString();
                            goto B;
                        }
                            
                        s[a] += args[0][i].ToString();
                        i++;
                    }
                    a++;
                    
                }
                if (args[0][i] != ' ' || args[0][i] == '+' || args[0][i] == '-' || args[0][i] == '*' || args[0][i] == '/' || args[0][i] == '^' || args[0][i] == '(' || args[0][i] == ')')
                {
                    s[a] = Convert.ToString(args[0][i]);
                    a++;
                }
            }
            B:;
           
            return s;
        }
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
                        if(s == "-")
                            Numbers.Push(Numbers.Pop() * -1);
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
                        else if (s.Equals("^"))
                        {
                            result = exponentValues(Convert.ToDouble(value1), Convert.ToDouble(value2));
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
        static double exponentValues(double a, double b)
        {
            double product = Math.Pow(b, a);
            return product;
        }
        static void Main(string[] args)
        {
            string[] s = SplitLine(args);
            Stack<string> Operators = new Stack<string>(s.Length);
            Queue<string> Numbers = new Queue<string>(s.Length);
            ToPostFix(s, Operators, Numbers);
            HashTable(Numbers);
        }
    }

}
