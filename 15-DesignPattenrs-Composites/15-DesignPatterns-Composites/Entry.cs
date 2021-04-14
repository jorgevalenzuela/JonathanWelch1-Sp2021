using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_Composites
{
    public abstract class Entry
    { // the base name of the composite type

        protected string name;    //  the entry's name; accessible to the subclass code

        // get and set the value of name:
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // returns a (long) string that lists names of all Entries within the current one.
        // Note that  "this"  refers to the current object being analyzed
        public override string ToString() { return this.ToString(""); }
        public string ToString(string indent)
        {
            string ans = "";
            if (this is TextFile)
            { // was  this  object constructed from class TextFile ?
                ans = indent + "Text file: " + this.name + "\r\n";
            }
            else if (this is Shortcut)
            {
                ans = indent + "Shortcut: " + this.name + "\r\n";
            }
            else if (this is Folder)
            {
                ans = indent + "Folder:  " + this.name + " containing:\r\n";
                List<Entry> contents = ((Folder)this).getListing(); // get all entries in folder
                foreach (Entry entry in contents)
                {
                    ans = ans + entry.ToString(indent + "   ");
                }
                ans = ans + indent + "End Folder " + this.name + "\r\n";
            }
            return ans;
        }

    }
}
