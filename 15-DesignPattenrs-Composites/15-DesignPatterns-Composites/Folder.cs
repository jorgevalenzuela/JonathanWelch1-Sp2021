using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_Composites
{
    // models a folder as a directory of Entries, indexed by their names:
    public class Folder : Entry
    {
        private Dictionary<string, Entry> directory;

        public Folder(string name)
        {
            base.name = name;  // save name in class Entry part of this object
            directory = new Dictionary<string, Entry>();  // initially, folder is empty
        }

        // returns the Entry with  name.  If name is bogus, returns null.
        public Entry find(string name)
        {
            Entry ans = null;
            if (directory.ContainsKey(name)) { ans = directory[name]; }
            return ans;
        }

        // adds a new Entry, e, to this folder
        public void add(Entry e)
        {
            if (!directory.ContainsKey(e.Name))
            {
                directory[e.Name] = e;
            }
        }

        // returns a list of all the Entry objects saved in this folder
        public List<Entry> getListing()
        {
            List<Entry> ans = new List<Entry>();
            foreach (var pair in directory) { ans.Add(pair.Value); }
            return ans;
        }


        // searches  path,  starting from this Folder, to find the Entry at the end of  path.
        // Param:  path - a string of form "Name1/Name2/.../Namem", e.g.,  "F/a.txt"
        // Returns: the Entry named by the path.  If path is invalid, returns  null
        // Example: say that  root  is the handle to the "Root" folder, which holds subfolder "F"
        //    which itself holds a file, "a.txt".   Then,   root.search("F/a.txt")   returns
        //    the handle to the TextFile object named "a.txt".
        public Entry search(string path)
        {
            string[] names = path.Split('/');  // splits the names in path into an array, e.g.,
            // for path == "F/a.txt",  names  is  ["F", "a.txt"];

            // TODO: complete this method so it searches for the Entry at the end of the sequence of names

            Entry current = this;

            foreach(var name in names)
            {
                while(current is Shortcut)
                {
                    current = ((Shortcut)current).Link;
                }
                if(current is Folder)
                {
                    var e = ((Folder)current).find(name);
                    current = e;
                }
            }

            return current;  // REMOVE ME

        }
    }
}
