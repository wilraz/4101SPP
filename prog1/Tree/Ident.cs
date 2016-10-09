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

            Console.Write(name);
        }
    }
}

