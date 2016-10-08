// Nil -- Parse tree node class for representing the empty list

using Parse;
using System;

namespace Tree
{
    public class Nil : Node
    {
        public Nil() { }

        //check node type
        public override bool isNull()
        {
            return true;
        }
        public override void print(int n)
        {
            print(n, false);
        }

        public override void print(int n, bool p, Parser r) {
            // There got to be a more efficient way to print n spaces.
            

            if (p)
                Console.Write(")");
            //else
            //    Console.WriteLine("()");

            if (r.parenCount < r.leoDecaprio)       // Go back and pass parser to this thing
            {
                Console.WriteLine();

                String str = new string(' ', n);    // Indentation
                Console.Write(str);
            }

        }
    }
}
