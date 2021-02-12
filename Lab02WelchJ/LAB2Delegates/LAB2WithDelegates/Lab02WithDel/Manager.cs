using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02WithDel
{
    public class Manager
    {
        private List<Helper> helper = new List<Helper>();

        public void Remove(Helper h)
        {
            Console.WriteLine("Remove helper from the helper list");
            helper.Remove(h);
            h.finalize();
        }

        public Helper RequestHelp()
        {
            Helper temp = new Helper(Remove);
            Console.WriteLine("Client requested Help");
            Console.WriteLine("Created Helper");
            Console.WriteLine("Added Helper to Helper list");
            helper.Add(temp);
            return temp;
        }
    }
}
