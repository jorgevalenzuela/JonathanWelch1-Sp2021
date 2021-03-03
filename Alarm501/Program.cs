using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm501
{
    public  delegate void inputHandler(int index);


    public delegate void Observer(List<Alarm> list);



    static class Program
    {

        


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            

            /*********************************************************/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /********************************************************/


            Form1 f = new Form1();
            AlarmController ac = new AlarmController(f, f.DisplayAlarms);
            f.SetAlarmController(ac);
            Application.Run(f);
      



        }
    }
}
