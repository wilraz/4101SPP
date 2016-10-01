// Scanner -- The lexical analyzer for the Scheme printer and interpreter

using System;
using System.IO;
using Tokens;

namespace Parse
{
    public class Scanner
    {
        private TextReader In;

        // maximum length of strings and identifier
        private const int BUFSIZE = 1000;
        private char[] buf = new char[BUFSIZE];

        public Scanner(TextReader i) { In = i; }
  
        // TODO: Add any other methods you need

        public Token getNextToken()
        {
            int ch;

            try
            {
                // It would be more efficient if we'd maintain our own
                // input buffer and read characters out of that
                // buffer, but reading individual characters from the
                // input stream is easier.
                ch = In.Read();

                // TODO: skip white space and comments

                if (ch == -1)
                    return null;

                // Whitespace characters
                else if (ch == ' ' || ch == '\n' || ch == '\r' || ch == '\f' || ch == '\t')
                    return getNextToken();

                // Comments
                else if (ch == ';' )
                {
                    while (ch != '\n')
                        ch = In.Read();
                    return getNextToken();
                }

                // Identifiers
                else if (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z' || ch == '+' || ch == '-'
                         // or ch is some other valid first character
                         // for an identifier
                         )
                {
                   {
                        int i = 0;
                        while (ch != ' ' && ch != '\n' && ch != '\f' && ch != '\r' && ch != '\t')
                        {
                            char c = (char)ch;
                            c = Convert.ToChar(ch);
                            buf[i] = c;
                            i++;
                            ch = In.Read();
                        }
                        return new IdentToken(new String(buf, 0, i));
                    }

                }

                // Special characters
                else if (ch == '\'')
                    return new Token(TokenType.QUOTE);
                else if (ch == '(')
                    return new Token(TokenType.LPAREN);
                else if (ch == ')')
                    return new Token(TokenType.RPAREN);
                else if (ch == '.')
                    // We ignore the special identifier `...'.
                    // Dot is handled in Identifiers due to '...' identifier; this line never reached
                    return new Token(TokenType.DOT);

                // Boolean constants
                else if (ch == '#')
                {
                    ch = In.Read();

                    if (ch == 't')
                        return new Token(TokenType.TRUE);
                    else if (ch == 'f')
                        return new Token(TokenType.FALSE);
                    else if (ch == -1)
                    {
                        Console.Error.WriteLine("Unexpected EOF following #");
                        return null;
                    }
                    else
                    {
                        Console.Error.WriteLine("Illegal character '" +
                                                (char)ch + "' following #");
                        return getNextToken();
                    }
                }

                // String constants
                else if (ch == '"')
                {
                    ch = In.Read();
                    int i = 0;
                    while (ch != '"')
                    {
                        char c = (char)ch;
                        c = Convert.ToChar(ch);
                        buf[i] = c;
                        i++;
                        ch = In.Read();
                    }    
                    return new StringToken(new String(buf, 0, i));
                }

                // Integer constants
                else if (ch >= '0' && ch <= '9')
                {
                    int i = ch - '0';
                    return new IntToken(i);
                }

                

                // Illegal character
                else
                {
                    Console.Error.WriteLine("Illegal input character '"
                                            + (char)ch + '\'');
                    return getNextToken();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("IOException: " + e.Message);
                return null;
            }
        }
    }

}

