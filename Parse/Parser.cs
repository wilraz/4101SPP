// Parser -- the parser for the Scheme printer and interpreter
//
// Defines
//
//   class Parser;
//
// Parses the language
//
//   exp  ->  ( rest
//         |  #f
//         |  #t
//         |  ' exp
//         |  integer_constant
//         |  string_constant
//         |  identifier
//    rest -> )
//         |  exp+ [. exp] )
//
// and builds a parse tree.  Lists of the form (rest) are further
// `parsed' into regular lists and special forms in the constructor
// for the parse tree node class Cons.  See Cons.parseList() for
// more information.
//
// The parser is implemented as an LL(0) recursive descent parser.
// I.e., parseExp() expects that the first token of an exp has not
// been read yet.  If parseRest() reads the first token of an exp
// before calling parseExp(), that token must be put back so that
// it can be reread by parseExp() or an alternative version of
// parseExp() must be called.
//
// If EOF is reached (i.e., if the scanner returns a NULL) token,
// the parser returns a NULL tree.  In case of a parse error, the
// parser discards the offending token (which probably was a DOT
// or an RPAREN) and attempts to continue parsing with the next token.

using System;
using Tokens;
using Tree;

namespace Parse
{
    public class Parser {
	
        private Scanner scanner;
        public Node car, cdr;
        public int parenCount = 0, indent = 0, leoDecaprio = 0;   //leoDecaprio = tempParenCt

        public Parser(Scanner s) { scanner = s; }
  
        public Node parseExp()  
        {
            //get tokens from Scanner.cs
            Token t = scanner.getNextToken();

            if (t == null)                                 
            {
                return null;
            }

            if (t.getType() == TokenType.LPAREN)
            {
                cdr = parseRest();                              // parseRest
                parenCount++;
            }
            else if (t.getType() == TokenType.INT)
            {
                IntLit car = new IntLit(t.getIntVal());
            }
            else if (t.getType() == TokenType.STRING)
            {
                StringLit car = new StringLit(t.getStringVal());
            }
            else if (t.getType() == TokenType.TRUE)
            {
                BoolLit car = new BoolLit(true);
            }
            else if (t.getType() == TokenType.FALSE)
            {
                BoolLit car = new BoolLit(false);
            }
            else if (t.getType() == TokenType.IDENT)
            {
                if (t.getName() == "define")
                {
                    indent += 4;
                    leoDecaprio = parenCount;
                    Define car = new Define();
                }
                else if (t.getName() == "cond")
                {
                    indent += 4;
                    leoDecaprio = parenCount;
                    Cond car = new Cond();
                }
                else if (t.getName() == "if")
                {
                    indent += 4;
                    leoDecaprio = parenCount;
                    If car = new If();
                }
                else if (t.getName() == "lambda")
                {
                    indent += 4;
                    leoDecaprio = parenCount;
                    Lambda car = new Lambda();
                }
                else if (t.getName() == "let")
                {
                    indent += 4;
                    leoDecaprio = parenCount;
                    Let car = new Let();
                }
                else if (t.getName() == "set")
                {
                    indent += 4;
                    leoDecaprio = parenCount;
                    Set car = new Set();
                }
                else
                {
                    Ident car = new Ident(t.getName());
                }
            }
            else if (t.getType() == TokenType.QUOTE)      
            {
                Quote car = new Quote(scanner);
            }
            else
            {
                Nil car = new Nil();
            }

            ////special cases here

            ////String str = new string(' ', n);           //handle indents in print function
            ////Console.Write(str);

            // TODO: write code for parsing an exp
            //if (token == LPAREN)
            //  need a nested call to rest
            //else if (token == TRUE)
            //else if (token == FALSE)
            //else if (token == QUOTE)
            //  need a recursive call to exp
            //else if (token == INT)
            //else if (token == STRING)
            //else if (token == IDENT)
            //else {give error message}

            return null;
        }
  
        protected Node parseRest()
        {
            // TODO: write code for parsing a rest
            //if (token == RPAREN) end;
            //else if ( something )
            //   make A PAIR of calls to exp  -> exp-op-exp -> include the DOT token  
            Token t = scanner.getNextToken();

            if (t == null)
            {
                return null;
            }

            if (t.getType() == TokenType.RPAREN)
            {
                cdr = new Nil();
                parenCount--;

                if (parenCount < 0)  {              //check for matching parens
                    Console.Error.WriteLine("ERROR: Unmatched Parenthesese");
                }
                return cdr;                                  
            }
            else
            {
                car = parseExp();
                while (t.getType() == TokenType.DOT) {  //check for a dot 
                    car = parseExp();
                    }
                cdr = parseRest();
                Cons c = new Cons(car, cdr);
                return c;
            } 
            //return null;                           //unreachable code
        }
    }
}

