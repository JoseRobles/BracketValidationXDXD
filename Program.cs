using System;
using System.Collections.Generic;

namespace BracketValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();
            strings.Add("(]Çççç}}");
            strings.Add("{/jkjsdkdjk}");
            strings.Add("{/jkj[{}]sdkdjk}");
            strings.Add("{/jk(j[{}]sdkdjk}");

            foreach (var item in strings)
            {
                var valido = Validate(item) ? "valido" : "no valido";
                Console.WriteLine($"La cadena {item} es {valido}");
            }
        } 

        static bool Validate (string cadena)
        {
            int counter = 0;
            Dictionary<char, char> brackets = new Dictionary<char, char>();
            brackets.Add('[', ']');
            brackets.Add('{', '}');
            brackets.Add('(', ')');

            Stack<char> stack = new Stack<char>();

            foreach(char item in cadena.ToCharArray())
            {
                if (counter == 0 && (brackets.ContainsKey(item) || brackets.ContainsValue(item)))
                {
                    stack.Push(item);
                }
                else
                {
                    if ((brackets.ContainsKey(item) || brackets.ContainsValue(item)))
                    {
                        //check for opening character
                        char bracketChar = brackets.GetValueOrDefault(stack.Peek());
                        if (bracketChar == item)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(item);
                        }
                    }
                }               
                counter++;
            }

            return stack.Count == 0 ? true : false;
        }

    }
}
