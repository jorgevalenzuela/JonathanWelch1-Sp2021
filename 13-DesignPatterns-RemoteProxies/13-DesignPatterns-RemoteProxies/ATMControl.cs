using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns_RemoteProxies_RemoteDatabase;

namespace DesignPatterns_RemoteProxies
{

    // Controls an ATM.  The ATMControl thinks it is talking to a real database and a real bank account.

    // IMPORTANT: the controller remembers the state of the transaction via the value of field  acct:
    //    when  acct != null,  then there is a transaction in progress with an opened account.

    public class ATMControl
    {

        private IDB database;      // handle to the accounts database
        private IAcct acct;        // handle to the account that is currently opened:
        //    acct == null iff no-active-transaction
        //    acct != null iff transaction-in-progress
        private string accountId;  // string ID of the account, if any, that is opened for transactions

        public ATMControl(IDB db)
        {
            database = db;
            acct = null;       // no account opened just yet
        }

        // opens acct#  accountID  for access; returns outcome as a string to display
        public string handleLogin(string accountId)
        {
            string ans = accountId + " error";
            if (acct == null)
            {  // no account open at this moment?
                acct = database.login(accountId);
                if (acct != null)
                {  // did  accountID  open ok ?
                    this.accountId = accountId;
                    ans = accountId + " opened OK";
                }
            }
            return ans;
        }

        // returns a string that states the balance of the opened  acct
        public string handleBalanceRequest()
        {
            string ans = "error";
            if (acct != null)
            {
                ans = (acct.getBalance()).ToString();
            }
            return ans;
        }

        // withdraws  amount  from the opened  acct;  
        // returns a string that states the amount withdrawn (or "error")
        public string handleWithdraw(string amount)
        {
            string ans = "error";
            int money;  // see the lines below:
            if (acct != null
                  && int.TryParse(amount, out money))
            { // is string  amount  a valid int?
                // if true, then  money  is the int
                bool ok = acct.withdraw(money);
                if (ok) { ans = amount; }
            }
            return ans;
        }

        // terminates the use of the opened  acct;  returns string that states outcome
        public string handleLogout()
        {
            string ans = "error";
            if (acct != null)
            {
                database.logout(accountId);
                acct = null; accountId = null;
                ans = "logged out";
            }
            return ans;
        }
    }

}
