using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using DesignPatterns_RemoteProxies_RemoteDatabase;
using DesignPatterns_RemoteProxies_RemoteProxy;

namespace DesignPatterns_RemoteProxies
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Construct bank's database and initialize it with three accounts:
            AccountDB db = new AccountDB();
            db.makeNewAccount("777", 70);
            db.makeNewAccount("888", 80);
            db.makeNewAccount("999", 90);
            MessageBox.Show("Accounts 777, 888, and 999 created in remote database. Try using them!");
            // Pretend that   db  is a remote object, far away....

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Construct an ATM and attach it to a "proxy" (stand-in) for the remote database.
            // The proxy impersonates the remote database and holds the networking code 
            // that does remote proc calls (PRCs):
            //    new RProxy(db)  builds the proxy, which is connected to the remote  db:

            new Thread(makeATM).Start(new RProxy(db));  // see  makeATM  method just below

            new Thread(makeATM).Start(new RProxy(db));  // make another ATM with its own proxy
        }

        // code for making an ATM assembly in its own thread;  C# requires that the parameter is typed "Object":
        static void makeATM(Object connectionToDB)
        {
            // first, make the ATM's controller and connect it to the database assembly:
            ATMControl t = new ATMControl((IDB)connectionToDB);   // cast the arg to its correct type
            // next, connect the ATM's form to its controller and Run it:
            Application.Run(new ATMForm(t));
        }
    }
}
