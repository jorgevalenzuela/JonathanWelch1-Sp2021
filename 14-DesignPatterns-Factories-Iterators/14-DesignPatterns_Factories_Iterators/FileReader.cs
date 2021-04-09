using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_Factories_Iterators
{
    // Iterator object generated to help read a file
    public class FileReader
    {
        private TextFile f;         // handle to the file to be read.  Is null if no file to read
        private int count;          // how many lines in file have been read
        private CloseOp closefile;  // handle to call cleanup method when finished reading

        public FileReader(TextFile f, CloseOp c)
        {
            this.f = f; count = 0; closefile = c;
        }

        // checks and returns if the file has more lines to read
        public bool more()
        {
            bool ans = false;
            if (f != null)
            {
                ans = (f.readAt(count) == null);
            }
            return ans;
        }

        // reads and returns next line of the file; if file all read, returns null
        public string read()
        {
            string line = null;
            if (f != null)
            {
                line = f.readAt(count);
                count = count + 1;
            }
            return line;
        }

        // closes file once reading finished
        public void close()
        {
            if (f != null) { closefile(); }
            f = null;  // disconnect from the file
        }
    }
}
