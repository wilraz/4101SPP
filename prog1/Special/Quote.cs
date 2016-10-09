// Quote -- Parse tree node strategy for printing the special form quote

using System;
using Parse;
using Tokens;

namespace Tree
{
    public class Quote : Special
    {
        // TODO: Add any fields needed.
        private string str = "'", str2;            //altered String to string
        private Scanner scan;
        
        // TODO: Add an appropriate constructor.
	    public Quote(Scanner s) {
            scan = s;
            while (scan.getNextToken().getType() != TokenType.RPAREN) {
                str2 = scan.ToString();
                String.Concat(str, str2);
            }
        }
        public string getString()
        {
            return str;
        }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            Console.Write(str + ")");
        }
    }
}

