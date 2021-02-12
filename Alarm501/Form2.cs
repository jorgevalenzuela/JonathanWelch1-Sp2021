/*
* Project 1, AUTHOR: Jonathan Welch
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Alarm501
{
    public partial class Form2 : Form
    {
        Alarm alarm;
        List<Alarm> alarmList;
        bool TrueOrFalse = false;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public Form2(List<Alarm> a, Alarm b, DateTime c, bool d)
        {
            InitializeComponent();
            alarmList = a;
            alarm = b;
            alarm.getTime = c;
            TrueOrFalse = d;
            if(c != DateTime.Now)
            {
                TrueOrFalse = true;
            }
        }

        /// <summary>
        /// Handles when the set button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void setButton_Click(object sender, EventArgs e)
        {
            alarm.getTime = dateTimePicker1.Value;
            if (TrueOrFalse == true)
            {
                alarmList.Remove(alarm);
                alarmList.Add(alarm);
            }
            else
            {
                alarmList.Add(alarm);
            }

        }
        /// <summary>
        /// Handles when the cancel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                alarm.checkBox = true;
            }
            else
            {
                alarm.checkBox = false;
            }
        }
    }
}
