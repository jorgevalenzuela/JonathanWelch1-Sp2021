using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_Composites
{
    // models a link (shortcut) to an Entry not in the present folder/level
    public class Shortcut : Entry
    {
        public readonly Entry Link;

        public Shortcut(string name, Entry link)
        {
            base.name = name;
            this.Link = link;
        }
    }
}
