// Cons -- Parse tree node class for representing a Cons node

using System;
using Tokens;

namespace Tree
{
    public class Cons : Node
    {
        private Node car;
        private Node cdr;
        private Special form;
    
        public Cons(Node a, Node d)
        {
            car = a;
            cdr = d;
            parseList();
        }
        

        // parseList() `parses' special forms, constructs an appropriate
        // object of a subclass of Special, and stores a pointer to that
        // object in variable form.  It would be possible to fully parse
        // special forms at this point.  Since this causes complications
        // when using (incorrect) programs as data, it is easiest to let
        // parseList only look at the car for selecting the appropriate
        // object from the Special hierarchy and to leave the rest of
        // parsing up to the interpreter.

        void parseList()
        {
            // TODO: implement this function and any helper functions
            // you might need.
            if(car.isSymbol() == true)
            {
                
            }

        }
        public override Node getCar() {
            return car;
        }
        public override Node getCdr() {
            return cdr;
        }
        public override void setCar(Node a) {
            car = a;
        }
        public override void setCdr(Node d) {
            cdr = d;
        }
       
        public override bool isPair()
        {
            if (car != null && cdr != null)
                return true;
            else
                return false;
        }

        public override void print(int n)
        {
            form.print(this, n, false);
        }

        public override void print(int n, bool p)            //explained in notes
        {
            form.print(this, n, p);
        }
    }
}

