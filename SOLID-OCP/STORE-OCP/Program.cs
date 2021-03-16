using System;

namespace STORE_OCP
{
    
    public delegate bool PaymentOrder(double amount);
    class Program
    {
        

        static void Main(string[] args)
        {
            OrderOCP anOrder = new OrderOCP(1, "Headphones", 35.99);

            Console.WriteLine("*** O C P ***");
            Console.WriteLine();
            Console.WriteLine("  Select Methos of Payment");
            Console.WriteLine("  1- Cash");
            Console.WriteLine("  2- Credit Card");
            int op = Convert.ToInt32(Console.ReadLine());

 
            // 1- Get funds from payment method
            switch (op)
            {
                case 1:
                    anOrder.ProcessOrder(CashPayment.processPaymentD);
                    anOrder.ProcessOrder(new CashPayment().processPayment);
                    break;
                case 2:
                    anOrder.ProcessOrder(new VCPayment().processPayment);
                    break;
                default:
                    Console.WriteLine("Payment Method Not Accepted");
                    break;
            }
            // 2 - If enough funds, mark order as paid
            Console.ReadLine();
           
        } 



    }
}
