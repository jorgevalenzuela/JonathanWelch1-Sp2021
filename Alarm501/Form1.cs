/*
* Project 1, AUTHOR: Jonathan Welch
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Alarm501
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Timer
        /// </summary>
        System.Timers.Timer timer;

        /// <summary>
        /// list of type alarms that is used to store the alarm
        /// </summary>
        List<Alarm> listOfAlarms = new List<Alarm>();

        /// <summary>
        /// index used to help the edit function
        /// </summary>
        int index;


        public Form1()
        {
            InitializeComponent();


            //if there is an alarm in the text file
            if(File.Exists("ListOfAlarms.txt"))
            {
                DateTime currentTIme = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                StreamReader sr = new StreamReader("ListOfAlarms.txt");
                while(!sr.EndOfStream)
                {
                    string[] alarmDetails = sr.ReadLine().Split(' ');
                    DateTime temp = Convert.ToDateTime(Convert.ToString(alarmDetails[0]) + " " + Convert.ToString(alarmDetails[1]) + " " + Convert.ToString(alarmDetails[2]));
                    Alarm a = new Alarm();
                    if(alarmDetails[3] == "True")
                    {
                        a.checkBox = true;
                    }
                    a.checkBox = false;
                    a.getTime = temp;
                    listOfAlarms.Add(a);
                }
                sr.Close();
            }
            DisplayAlarms(listOfAlarms);
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += CheckAlarms;
            timer.SynchronizingObject = this;
            timer.AutoReset = true;
            timer.Start();
        }

        /// <summary>
        /// handles when to display the alarm
        /// </summary>
        /// <param name="list"></param>
        public void DisplayAlarms(List<Alarm> list)
        {
            BindingList<string> alarmList = new BindingList<string>();
            string tempString = "";
            foreach (Alarm a in list)
            {
                if (a.IsStopped == true)
                {
                    tempString = a.getTime.ToString("hh:mm tt ") + "stopped";
                    alarmList.Add(tempString);

                }
                else if (a.checkBox == true)
                {
                    tempString = a.getTime.ToString("hh:mm tt ") + "ON";
                    alarmList.Add(tempString);
                }
                else
                {
                    tempString = a.getTime.ToString("hh:mm tt ") + "OFF";
                    alarmList.Add(tempString);
                }
            }
            uxListBox.DataSource = alarmList;
        }


        /// <summary>
        /// handles when the edit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(listOfAlarms, listOfAlarms[uxListBox.SelectedIndex], listOfAlarms[uxListBox.SelectedIndex].getTime, listOfAlarms[uxListBox.SelectedIndex].checkBox);
            snooze_Click.Enabled = true;
            stop.Enabled = true;
            DialogResult showScreen = f.ShowDialog();
            DisplayAlarms(listOfAlarms);
        }

        /// <summary>
        /// Event Handler that handles when the Add Button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click_Click(object sender, EventArgs e)
        {

            Alarm a = new Alarm();
            a.getTime = DateTime.Now;
            a.checkBox = false;
            Form2 temp = new Form2(listOfAlarms, a, a.getTime, a.checkBox);
            DialogResult showScreen = temp.ShowDialog();
            DisplayAlarms(listOfAlarms);
        }

        /// <summary>
        /// yanked this from the demo video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckAlarms(object sender, ElapsedEventArgs e)
        {
            DateTime current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            foreach (Alarm a in listOfAlarms)
            {
                if ((a.checkBox == true) && TimeSpan.Compare(a.getTime.TimeOfDay, current.TimeOfDay) == 0)
                {
                    AlarmGoingOff(listOfAlarms.IndexOf(a));
                }
            }
        }

        /// <summary>
        /// method performs actions when the alarm goes off
        /// </summary>
        /// <param name="i">Index of the alarm that is going off</param>
        private void AlarmGoingOff(int i)
        {
            Edit.Enabled = false;
            stop.Enabled = true;
            Add_Click.Enabled = false;
            snooze_Click.Enabled = true;
            index = i;
            labelText.Text = "Your Alarm is going off";
        }

        /// <summary>
        /// handles when the stop button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stop_Click(object sender, EventArgs e)
        {

            labelText.Text = "Stop";
            Edit.Enabled = true;
            stop.Enabled = false;
            Add_Click.Enabled = true;
            snooze_Click.Enabled = false;
            DisplayAlarms(listOfAlarms);
        }


        /// <summary>
        /// Handles when the zoom button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void snooze_Click_Click(object sender, EventArgs e)
        {
            DateTime currentTIme = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            labelText.Text = "Waiting for Alarm";
            Edit.Enabled = true;
            stop.Enabled = false;
            Add_Click.Enabled = true;
            snooze_Click.Enabled = false;
            listOfAlarms[index].IsStopped = true;
            listOfAlarms[index].getTime = currentTIme.AddSeconds(3);
        }

        private void formClosedEvent(object sender, FormClosedEventArgs e)
        {
            using(StreamWriter sw = new StreamWriter("ListOfAlarms.txt"))
            {
                foreach(Alarm a in listOfAlarms)
                {
                    sw.WriteLine(a.getTime.ToString() + " " + a.checkBox);
                }
            }
        }
    }
}
