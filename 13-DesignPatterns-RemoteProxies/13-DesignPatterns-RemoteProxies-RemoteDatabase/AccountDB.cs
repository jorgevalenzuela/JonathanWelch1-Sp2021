using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatterns_RemoteProxies_RemoteDatabase
{
    // models a simplistic "database" of bank accounts
    public class AccountDB : IDB
    {
        private Dictionary<string, Account> accounts;  // the collection of accounts
        private List<string> checkedOut;  // list of ids of accounts that are "checked out" (in use)

        public AccountDB()
        {
            accounts = new Dictionary<string, Account>();
            checkedOut = new List<string>();
        }

        // constructs a new account with  id  and  initialBalance, provided
        //  one does not already exist with the same  id
        public bool makeNewAccount(string id, int initBalance)
        {
            lock (this)
            {
                bool result = false;
                if (!accounts.ContainsKey(id))
                {
                    accounts[id] = new Account(id, initBalance);
                    result = true;
                }
                return result;
            }
        }

        // returns the handle to the account labelled by  id,  if account not in use
        // If  id  is nonexistant or in-use, returns  null
        public IAcct login(string id)
        {
            lock (this)
            {
                Account ans = null;
                if (accounts.ContainsKey(id) && !(checkedOut.Contains(id)))
                {
                    ans = accounts[id];
                    checkedOut.Add(id);
                }
                return (IAcct)ans;
            }
        }

        // logs out account  id:
        public object logout(string id)
        {
            lock (this)
            {
                if (accounts.ContainsKey(id))
                {
                    checkedOut.Remove(id);
                }
                return null;
            }
        }

        ////////// Methods written for remote login and logout:

        // activates a login from a remote site to account #id and returns only the account's balance
        // (and not the account itself).  If  id  is nonexistant/in use, returns  -1
        public object loginRemote(string id)
        {
            int ans = -1;
            IAcct a = this.login(id);
            if (a != null)
            {
                ans = a.getBalance();
            }
            return ans;
        }

        // activates a logout from a remote site for account #id and resets the account's balance
        // to  finalbalance.
        public void logoutRemote(string id, int finalbalance)
        {
            accounts[id].resetBalance(finalbalance);
            this.logout(id);
        }

    }
}
