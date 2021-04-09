using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_Factories_Iterators
{

    // models a textfile (as a sequence of lines/strings)
    public class TextFile
    {
        private List<string> contents;  // the file

        public TextFile() { this.reset(); }

        // empties the file for writing:
        public void reset() { contents = new List<string>(); }

        // reads line  i  in the file.  Returns (line #i) if ok;
        // Returns  null  if  i  is out of bounds.
        public string readAt(int i)
        {
            string line = null;
            if (0 <= i && i < contents.Count)
            {
                line = contents.ElementAt(i);
            }
            return line;
        }

        // adds line  s  to the end of the file:
        public void write(string s) { contents.Add(s); }

        // factory method to manufacture a helper reader object,
        // where  c  is the method to call when reading is finished
        public FileReader makeReader(CloseOp c)
        {
            return new FileReader(this, c);
        }

        // factory method to manufacture a helper writer object,
        // where  c  is the method to call when writing is finished
        public FileWriter makeWriter(CloseOp c)
        {
            return new FileWriter(this, c);
        }

    }
}
