using Stack;
using Queue;
using System;
//using System.Collections.Generic;


namespace OP3
{
    class Program
    {
        static Queue<string> ToPostFix(string[] args, Stack<string> Operators, Queue<string> Numbers)
        {
            for(int i = 0; i < args.Length; i++)
            {
                if(args[i] == "(" || args[i] ==")" || args[i] == "*" 
                    || args[i] =="/" || args[i] == "+" || args[i] == "-")
                {
                    if(i == 0)
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
                        }
                    }

                }
                else
                {
                    Numbers.Enqueue(args[i]);
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
            return (Numbers);
        }
        static void Main(string[] args)
        {
            Stack<string> Operators = new Stack<string>(args.Length);
            Queue<string> Numbers = new Queue<string>(args.Length);
            ToPostFix(args, Operators, Numbers);
        }
    }
}
