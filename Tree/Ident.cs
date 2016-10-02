// Ident -- Parse tree node class for representing identifiers

using System;

namespace Tree
{
    public class Ident : Node
    {
        private string name;
               
        public Ident(string n)
        {
            name = n;
        } 

        //check node type
        public override bool isSymbol()
        {
            return true;
        }

        public string getName()
        {
            return name;
        }

        public override void print(int n)
        {
            // There got to be a more efficient way to print n spaces.
            String str = new string(' ', n);
            Console.Write(str);

            Console.WriteLine(name);
        }
    }
}

