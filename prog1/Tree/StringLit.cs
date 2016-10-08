// StringLit -- Parse tree node class for representing string literals

using System;

namespace Tree
{
    public class StringLit : Node
    {
        private string stringVal;
        private bool isRealStr = false;
         public StringLit(string s)
        {
            stringVal = s;
            isRealStr = true;
        }

        // To save any Special case as a String node
        public StringLit(Begin s)
        {
            stringVal = "(";
        }
        public StringLit(Cond s)
        {
            stringVal = "cond";
        }
        public StringLit(Define s)
        {
            stringVal = "define";
        }
        public StringLit(If s)
        {
            stringVal = "if";
        }
        public StringLit(Lambda s)
        {
            stringVal = "lambda";
        }
        public StringLit(Let s)
        {
            stringVal = "let";
        }
        public StringLit(Quote s)
        {
            stringVal = s.getString();
        }
        public StringLit(Regular s)
        {
            stringVal = " ";    //potentially s.getString();, but we never use Regular
        }
        public StringLit(Set s)
        {
            stringVal = ")";
        }


        //check node type
        public override bool isString()
        {
            return true;
        }
        public override void print(int n)
        {
            // There got to be a more efficient way to print n spaces.
            if (isRealStr == true)
            {
                Console.Write("\"" + stringVal + "\"");
            }
            else
            {
                Console.Write(stringVal);
            }
        }
    }
}

