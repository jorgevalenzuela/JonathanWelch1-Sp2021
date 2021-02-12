using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02WithDel
{
    public class Helper
    {
        
        Remove Finsihed;

        public Helper(Remove temp)
        {
            Finsihed = temp;
        }


        public void doWork()
        {
            Console.WriteLine("Doing the work");
        }

        public void finished()
        {
            Console.WriteLine("Am Finished");
            Finsihed(this);
        }

        public void finalize()
        {
            Console.WriteLine("Help was done, and we done here get out");
        }
    }
}
