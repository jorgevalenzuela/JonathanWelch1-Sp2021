using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace DesignPatterns_Factories_Iterators
{
    static class Program
    {
        /// <summary>
        /// Constructs a controller buffer that is shared by a reader thread and a writer thread.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TextFile sharedfile = new TextFile();
            FileController fc = new FileController(sharedfile);
            // start threads for readers and writers:
            new Thread(R).Start(fc);
            new Thread(R).Start(fc);
            new Thread(W).Start(fc);
        }

        // reader thread:
        static void R(Object ob)  // you can pass an object to a new thread
        { Application.Run(new RThread((FileController)ob)); }

        // writer thread:
        static void W(Object ob)  // you can pass an object to a new thread
        { Application.Run(new WThread((FileController)ob)); }
    }
}
