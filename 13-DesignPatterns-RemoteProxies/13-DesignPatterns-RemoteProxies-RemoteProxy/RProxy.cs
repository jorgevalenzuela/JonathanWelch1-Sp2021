using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DesignPatterns_RemoteProxies_RemoteDatabase;

namespace DesignPatterns_RemoteProxies_RemoteProxy
{

    // class RProxy impersonates the remote database and remote bank account:
    // (i) It holds the networking code that does remote procedure calls (RPCs) 
    //   to the remote database.
    // (ii) Because this demo system isn't finished,  RProxy also holds code for doing
    //   account-balance lookups and account withdrawals.  This will execute slowly.

    public class RProxy : IDB
    { // wow, this one class impersonates *both* the remote database
        //  *and* the account that the ATM is using!  We will fix this....

        private AccountDB remoteDatabase;  // handle to the bank's database that lives far away
        private Account remoteAccount;     // handle to the opened bank account that lives far away
        private string accountid;          // the id of the opened bank account

        public RProxy(AccountDB remote) { remoteDatabase = remote; }


        /// This part of RProxy impersonates the remote database:

        // login to bank account  #id:
        public IAcct login(string id)
        {
            remoteAccount = null;
            // call the remote database via RPC to login and receive in return 
            //   a handle to the remote bank acct:
            //  remoteAccount = (Account)(rpcToDatabase(remoteDatabase.login, id));
            int bal = (int)(rpcToDatabase(remoteDatabase.loginRemote, id));
            if (bal != -1)
            {
                accountid = id;
                remoteAccount = new Account(id,bal);  // This object here also impersonates the bank account,
                // so that it can execute the RPCs for account lookups.
            }
            return remoteAccount;
        }

        // logout from account #id:
        public object logout(string id)
        {
            if (accountid != null && accountid == id)
            {
                // rpcToDatabase(remoteDatabase.logout, accountid);
                rpcToDatabase(remoteDatabase.logoutRemote,id, remoteAccount.getBalance());
                remoteAccount = null;
            }
            return null;
        }

        /// This part of RProxy imitates the remote bank account.  
        /// It does the RPCs to the real account, which is located far away:

        // lookup balance of account:
        public int getBalance()
        {
            int answer = -1;
            if (remoteAccount != null)
            {
                answer = rpcToAccount(remoteAccount.getBalance);
            }
            return answer;
        }

        // attempt withdrawal of  amt  and return whether successful:
        public bool withdraw(int amt)
        {
            bool answer = false;
            if (remoteAccount != null)
            {
                answer = rpcToAccount(remoteAccount.withdraw, amt);
            }
            return answer;
        }


        /////////////////////////////////////////////////////////////////////////////////////////
        // The following methods are my "simulations" for the networking code needed for RPCs:
        //////////////////////////////////////////////////////////////////////////////////////  

        // code to simulate RPCs to the remote database:

        // The delegates define the forms of method that can be called remotely:
        private delegate object DBmethod1(string arg);
        private delegate void DBmethod2(string arg, int amt);

        // does an RPC for method  m  with argument  arg.  Returns an *object* as the answer.
        // The object can be cast to an int or a string or an Account, or whatever it is!
        private object rpcToDatabase(DBmethod1 m, string arg)
        {
            wait(10);
            return m(arg);
        }
        // does an RPC for method  m  with arguments  arg,amt.  No answer is returned.
        private void rpcToDatabase(DBmethod2 m, string arg, int amt)
        {
            wait(10);
            m(arg, amt);
        }

        //////////////////////////////////////////////////////////////////////////////
        // code to simulate RPCs to a remote bank account; similar to the code just above.
        private delegate bool Acctmethod1(int arg);
        private bool rpcToAccount(Acctmethod1 m, int arg)
        {
            wait(10);
            return m(arg);
        }
        delegate int Acctmethod2();
        private int rpcToAccount(Acctmethod2 m)
        {
            wait(10);
            return m();
        }

        private InfoForm f;      // passive form used to show you when an RPC occurs

        // stand-in method for the networking code that issues a remote proc call (RPC)
        private void wait(int howlong)
        {
            if (f == null) { f = new InfoForm(); }
            f.Show();
            for (int i = 0; i != howlong; i++)
            {
                f.WriteLine(i.ToString());
                Thread.Sleep(600);
            }
            f.Hide();
        }

    }
}
