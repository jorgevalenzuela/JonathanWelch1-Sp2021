using System;
using System.Collections.Generic;
using System.Text;

namespace STORE_OCP
{
    class VCPayment : IPaymentMethod
    {
        public bool processPayment(double amount)
        {
            Console.WriteLine("Processing payment with Cash in CashPayment");

            return true;
        }

    }
}
