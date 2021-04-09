using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_Factories_Iterators
{
    // constructs an object for writing to a text file (list of strings)
    public class FileWriter
    { // holds the handle to the "singleton" FileWriter object:

        private TextFile f;           // handle to the file to write to; is null when no file exists
        private CloseOp closefile;    // cleanup method that is called when writing done

        public FileWriter(TextFile f, CloseOp c)
        {
            closefile = c;
            this.f = f;
            this.f.reset();
        }

        // writes a line  s  to the file
        public void write(string s)
        {
            if (f != null) { f.write(s); }
        }

        // closes the file
        public void close()
        {
            if (f != null) { closefile(); }
            f = null;  // disconnect from file 
        }

    }
}
