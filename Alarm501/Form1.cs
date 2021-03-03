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
        /// index used to help the edit function
        /// </summary>
        int index;

        /// <summary>
        /// AlarmController Instant
        /// </summary>
        AlarmController AlarmC;


        /// <summary>
        /// delegates
        /// </summary>
        inputHandler snooze;
        inputHandler edit;

        /// <summary>
        /// sets the controller
        /// </summary>
        /// <param name="ac"></param>
        public void SetAlarmController(AlarmController ac)
        {
            AlarmC = ac;  
            AlarmC.ReadFromFile();

            snooze = AlarmC.SnoozeEvent;
            edit = AlarmC.EditAlarm;
        }

        public Form1()
        {
            InitializeComponent();  
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
            edit(index);
            snooze_Click.Enabled = true;
            stop.Enabled = true;
        }

        /// <summary>
        /// Event Handler that handles when the Add Button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click_Click(object sender, EventArgs e)
        {
            AlarmC.AddAlarm();
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
        }


        /// <summary>
        /// Handles when the zoom button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void snooze_Click_Click(object sender, EventArgs e)
        {
           
            labelText.Text = "Waiting for Alarm";
            Edit.Enabled = true;
            stop.Enabled = false;
            Add_Click.Enabled = true;
            snooze_Click.Enabled = false;
            snooze(index);
        }

        /// <summary>
        /// method performs actions when the alarm goes off
        /// </summary>
        public void AlarmGoingOff(int i, string temp )
        {
            Edit.Enabled = false;
            stop.Enabled = true;
            Add_Click.Enabled = false;
            snooze_Click.Enabled = true;
            index = i;
            labelText.Text = "Your Alarm is going off with sound " + temp;
        }

        /// <summary>
        /// creates a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formClosedEvent(object sender, FormClosedEventArgs e)
        {
            AlarmC.WriteFileToComputer();
        }


    }
}
