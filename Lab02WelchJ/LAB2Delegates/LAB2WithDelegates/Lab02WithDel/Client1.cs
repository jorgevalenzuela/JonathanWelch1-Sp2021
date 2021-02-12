using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02WithDel
{
    public class Client1
    {
        Manager m;

        public Client1(Manager temp)
        {
            m = temp;
        }


        public void work()
        {
            Console.WriteLine("I demand Request from helper");
            Helper h = m.RequestHelp();
            h.doWork();
            h.finished();
        }

    }
}
