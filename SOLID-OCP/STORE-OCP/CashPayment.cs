using System;
using System.Collections.Generic;
using System.Text;

namespace STORE_OCP
{
    class CashPayment : IPaymentMethod
    {
        public bool processPayment(double amount)
        {
            Console.WriteLine("Processing payment with cash in cashpayment (interface)");
            return true;
        }

        public static bool processPaymentD(double amount)
        {
            Console.WriteLine("Processing payment with cash in cashpayment (delegate)");

            return true;
        }
    }
}
