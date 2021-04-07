using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_RemoteProxies_RemoteDatabase
{   // interface for an accounts database
    public interface IDB
    {
        // login to account  id  and return the handle to it
        IAcct login(string id);

        // logout from account
        object logout(string id);
    }

}
