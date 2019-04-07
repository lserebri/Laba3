using Stack;
using Queue;
using System;
//using System.Collections.Generic;


namespace OP3
{

    class Program
    {
        static bool IsInt(string args)
        {
            int res;
            bool isInt = Int32.TryParse(args, out res);
            Console.WriteLine(isInt);
            return isInt;
        }
        static Queue<string> ToPostFix(string[] args, Stack<string> Operators, Queue<string> Numbers)
        {
            for(int i = 0; i < args.Length; i++)
            {
                if(IsInt(args[i]) == true)
                {
                    Numbers.Enqueue(args[i]);
                }
                else
                {
                    if (Operators.IsEmpty() == true)
                    {
                        Operators.Push(args[i]);
                    }
                    else
                    {
                        if ((Operators.Peek() == "*" || Operators.Peek() == "/") && (args[i] == "+" || args[i] == "-"))
                        {
                            Numbers.Enqueue(Operators.Pop());
                            Operators.Push(args[i]);
                        }
                        else
                        {
                            Operators.Push(args[i]);
                            Console.WriteLine("a");
                        }
                    }
                }
            }
            while (Operators.Count > 0)
            {
                Numbers.Enqueue(Operators.Pop());
            }
            while (Numbers.Count > 0)
            {
                Console.WriteLine(Numbers.Dequeue());
            }
            /*while(Operators.Count > 0)
            {
                if(args[i] == "(" || args[i] == ")" || args[i] == "*" 
                    || args[i] =="/" || args[i] == "+" || args[i] == "-")
                {
                    if (i == 0)
                        Operators.Push(args[i]);
                    else
                    {
                        if ((Operators.Peek() == "*" || Operators.Peek() == "/") && (args[i] == "+" || args[i] == "-"))
                        {
                            Numbers.Enqueue(Operators.Pop());
                            Operators.Push(args[i]);
                        }
                        else
                        {
                            Operators.Push(args[i]);
                            Console.WriteLine("a");
                        }
                    }

                }
                else
                {
                    Numbers.Enqueue(args[i]);
                }
                i++;
            }

            while (Operators.Count > 0)
            {
                Numbers.Enqueue(Operators.Pop());
            }
            while (Numbers.Count > 0)
            {
                Console.WriteLine(Numbers.Dequeue());
            }*/

            return (Numbers);
        }
        static void Main(string[] args)
        {
           
            string[] array = {"10", "*", "9", "+", "5"};
            Stack<string> Operators = new Stack<string>(args.Length);
            Queue<string> Numbers = new Queue<string>(args.Length);
            ToPostFix(args, Operators, Numbers);
        }
    }

}
