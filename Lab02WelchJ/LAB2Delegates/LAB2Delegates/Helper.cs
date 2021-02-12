using System;
using System.Collections.Generic;
using System.Text;

namespace LAB2Delegates
{
    public class Helper
    {
        Manager m;

        public Helper(Manager temp)
        {
            m = temp;
        }


        public void doWork()
        {
            Console.WriteLine("Doing the work");
        }

        public void finished()
        {
            Console.WriteLine("Am Finished");
            helper(m);
            
        }

        public void helper(Manager myMan)
        {
            myMan.Remove(this);
        }

        public void finalize()
        {
            Console.WriteLine("Help was done, and we done here get out");
        }
    }
}
