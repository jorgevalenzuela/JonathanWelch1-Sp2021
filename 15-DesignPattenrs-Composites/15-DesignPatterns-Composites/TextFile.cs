using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_Composites
{
    // models a text file as a long string, where lines are separated by  \r\n
    public class TextFile : Entry
    {
        private string lines;

        public TextFile(string name)
        {
            base.name = name;  // stores the name in the class Entry part of this object
            lines = "";  // file is empty at the start
        }

        //methods to add a line and to return all the lines of the file:
        public void addLine(string s) { lines = lines + s + "\r\n"; }
        public string Lines { get { return lines; } }
    }
}
