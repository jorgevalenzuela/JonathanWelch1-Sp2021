using System;

namespace Lab02WithDel
{
    public delegate void Remove(Helper h);
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
