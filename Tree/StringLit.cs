// StringLit -- Parse tree node class for representing string literals

using System;

namespace Tree
{
    public class StringLit : Node
    {
        private string stringVal;
        private int valType = 0;        // 1 = normal String, 2 = RPAREN, 0 = anything else
         public StringLit(string s)
        {
            stringVal = s;
            valType = 1;
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
            if (valType == 1)                  //For printing Strings
            {
                Console.Write("\"" + stringVal + "\"");
            }
            else if (valType == 2) {
                Console.Write(stringVal);
                String str = new string(' ', n);
            }
            else                                    //For printing Special cases
            {
                Console.Write(stringVal);
            }
        }
    }
}

