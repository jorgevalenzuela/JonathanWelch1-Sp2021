using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_RemoteProxies_RemoteDatabase
{   // interface for a bank account
    public interface IAcct
    {
        // return the account's balance
        int getBalance();

        // withdraw  amount  from the account and return if successful
        bool withdraw(int amount);
    }

}
