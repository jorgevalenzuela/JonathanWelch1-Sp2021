# Exercise: Design Patterns: Remote Proxies

## Tasks

The VS solution contains a program which is similar as depicted to the first
class diagram in [Design Patterns: Remote Proxies]
(with two interfaces, `IDB` and `IAcct`, inserted, like in the second class
diagram).

Run it --- it's slow!

Improve it by constructing a remote proxy for Account, so that your system looks
like the one in the third class diagram:

* read method `Main` in class `Program` first.

* now, study methods `loginRemote` and `logoutRemote` in class `AccountDB`

* alter class `RProxy` ONLY: 
 
  a. in `public class RProxy: IDB, IAcct {`, remove `IAcct` so `RProxy` no longer
     implements `IAcct`.

  b. change method `login` to call `remoteDatabase.loginRemote` (instead of
     `rpcToDatabase`) and to construct and return `new Account(id, ...)`, 
     the new proxy when the supplied `id` is associated with an account.
     (Hint: study the header lines to method `rpcToDatabase` at the end of class
     `RProxy`).

  c. change method `logout` to call `remoteDatabase.logoutRemote`

**You will only need to change about 4-5 lines of code.**      


## Submission

To submit, copy the folder containing this file to your local GitHub repository
for the course, and then commit and push your modified solutions to GitHub
(see the [course note on Git/GitHub](http://softwarearch.santoslab.org/01-tooling/index.html#git-github)).
