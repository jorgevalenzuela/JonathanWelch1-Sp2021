using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
namespace Alarm501
{
    public class AlarmController
    {
        /// <summary>
        /// Timer
        /// </summary>
        System.Timers.Timer timer;

        /// <summary>
        /// list of type alarms that is used to store the alarm
        /// </summary>
        List<Alarm> listOfAlarms = new List<Alarm>();

        Form1 f;
        Observer O;

        public AlarmController(Form1 f2, Observer Otemp)
        {
            O = Otemp;
            f = f2;
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += CheckAlarms;
            timer.SynchronizingObject = f;
            timer.AutoReset = true;
            timer.Start();
        }


        /// <summary>
        /// logic for the snooze button
        /// </summary>
        /// <param name="a">Current Time</param>
        /// <param name="b">List of the alarms</param>
        /// <param name="index">Index of the Alarms</param>
        public void SnoozeEvent( int index)
        {
            DateTime currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            listOfAlarms[index].getTime = currentTime.AddSeconds(listOfAlarms[index].SnoozeTime);
        }

        /// <summary>
        /// writes the list of alarms to the 
        /// </summary>
        /// <param name="b"></param>
        public void WriteFileToComputer()
        {
            using (StreamWriter sw = new StreamWriter("ListOfAlarms.txt"))
            {
                foreach (Alarm a in listOfAlarms)
                {
                    sw.WriteLine(a.getTime.ToString() + " " + a.checkBox);
                }
            }
        }

        /// <summary>
        /// Reads from the alarms
        /// </summary>
        public void ReadFromFile()
        {
            if (File.Exists("ListOfAlarms.txt"))
            {
                DateTime currentTIme = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                StreamReader sr = new StreamReader("ListOfAlarms.txt");
                while (!sr.EndOfStream)
                {
                    string[] alarmDetails = sr.ReadLine().Split(' ');
                    DateTime current = Convert.ToDateTime(Convert.ToString(alarmDetails[0]) + " " + Convert.ToString(alarmDetails[1]) + " " + Convert.ToString(alarmDetails[2]));
                    Alarm a = new Alarm();
                    if (alarmDetails[3] == "True")
                    {
                        a.checkBox = true;
                    }
                    a.checkBox = false;
                    a.getTime = current;
                    listOfAlarms.Add(a);
                }
                sr.Close();
                O(listOfAlarms);
            }
        }


        /// <summary>
        /// yanked this from the demo video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckAlarms(object sender, ElapsedEventArgs e)
        {
            int i;
            DateTime current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            foreach (Alarm a in listOfAlarms)
            {
                if ((a.checkBox == true) && TimeSpan.Compare(a.getTime.TimeOfDay, current.TimeOfDay) == 0 )
                {
                   f.AlarmGoingOff(listOfAlarms.IndexOf(a), a.AlarmSound);
                }
            }
        }

        /// <summary>
        /// Performs the adding for alarms
        /// </summary>
        public void AddAlarm()
        {
            Alarm a = new Alarm();
            a.getTime = DateTime.Now;
            a.checkBox = false;
            Form2 temp = new Form2(listOfAlarms, a, a.getTime, a.checkBox);
            DialogResult showScreen = temp.ShowDialog();
            O(listOfAlarms);
        }

        /// <summary>
        /// Edit Alarm event handler
        /// </summary>
        /// <param name="a">Alarm being done</param>
        public void EditAlarm(int i)
        {
            int index = i;
            Alarm list1 = listOfAlarms[i];
            DateTime list2 = listOfAlarms[index].getTime;
            bool list3 = listOfAlarms[index].checkBox;
            Form2 f2 = new Form2(listOfAlarms, list1, list2, list3);
            DialogResult showScreen = f2.ShowDialog();
            O(listOfAlarms);
        }


    }
}
