// Nil -- Parse tree node class for representing the empty list

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

        public override void print(int n, bool p) {
            // There got to be a more efficient way to print n spaces.
            String str = new string(' ', n);
            Console.Write(str);

            if (p)
                Console.WriteLine(")");
            else
                Console.WriteLine("()");
        }
    }
}
