using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login200Lab03pt2
{
    public delegate void IN(State temp, String arg);

    public delegate void Observe(State temp);

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CredentialsM model = new CredentialsM("Alice", "WonderLand");
            Controller c = new Controller(model);
            LoginForm view = new LoginForm(c.handleEvents);
            c.register(view.DisplayState);
            Application.Run(view);
        }
    }
}
