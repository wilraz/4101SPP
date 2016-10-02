// BoolLit -- Parse tree node class for representing boolean literals

using System;

namespace Tree
{
    public class BoolLit : Node
    {
        private bool boolVal;
  
        public BoolLit(bool b)
        {
            boolVal = b;
        }

        //check node type
        public override bool isBool()
        {
            return true;
        }
        public override void print(int n)
        {
            // There got to be a more efficient way to print n spaces.
            String str = new string(' ', n);
            Console.Write(str);

            if (boolVal)
                Console.WriteLine("#t");
            else
                Console.WriteLine("#f");
        }
    }
}
