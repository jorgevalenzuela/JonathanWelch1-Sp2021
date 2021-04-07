using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_RemoteProxies_RemoteDatabase
{   // models a customer's bank account
    public class Account : IAcct
    {
        private string acctid;  // the account's id, e.g., "333"
        private int balance;    // how much money in the account

        public Account(string id, int bal)
        { acctid = id; balance = bal; }

        // returns this account's balance
        public int getBalance() { return balance; }

        public void resetBalance(int newbalance) { balance = newbalance; }

        // removes  amount  from the balance and returns true if successful
        public bool withdraw(int amount)
        {
            bool result = false;
            if (amount <= balance)
            {
                balance = balance - amount;
                result = true;
            }
            return result;
        }

        // adds  amount  to the balance and returns true if successful
        public bool deposit(int amount)
        {
            bool result = false;
            if (amount > 0)
            {
                balance = balance + amount;
                result = true;
            }
            return result;
        }

    }

}
