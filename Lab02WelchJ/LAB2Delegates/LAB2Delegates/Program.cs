using System;

namespace LAB2Delegates
{
    class Program
    {

        static void Main(string[] args)
        {
            Manager m = new Manager();

            Client1 client = new Client1(m);

            client.work();
        }

    }
}
