using System;
using System.Collections.Generic;
using System.Text;

namespace STORE_OCP
{
    interface IPaymentMethod
    {
        bool processPayment(double amount);
    }
}
