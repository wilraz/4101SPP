// StringLit -- Parse tree node class for representing string literals

using System;

namespace Tree
{
    public class StringLit : Node
    {
        private string stringVal;

         public StringLit(string s)
        {
            stringVal = s;
        }

        //check node type
        public override bool isString()
        {
            return true;
        }
        public override void print(int n)
        {
            // There got to be a more efficient way to print n spaces.
            String str = new string(' ', n);
            Console.Write(str);

            Console.WriteLine("\"" + stringVal + "\"");
        }
    }
}

