// Special -- Parse tree node strategy for printing special forms

using System;

namespace Tree
{
    // There are several different approaches for how to implement the Special
    // hierarchy.  We'll discuss some of them in class.  The easiest solution
    // is to not add any fields and to use empty constructors.

    abstract public class Special
    {                                                       //pretty printing (next line)
        public abstract void print(Node t, int n, bool p); //(root->each instance, indent #, type of entry)
    }
}

