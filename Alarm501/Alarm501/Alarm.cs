using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm501
{
    public class Alarm
    {
        private DateTime _date;
        private bool isChecked;

        /// <summary>
        /// getter and setter
        /// </summary>
        public DateTime getTime
        { get { return _date; } set { _date = value; } }

        /// <summary>
        /// getter and setter
        /// </summary>
        public bool checkBox
        { get { return isChecked; } set { isChecked = value; } }

        /// <summary>
        /// determines if the alarm is on or off
        /// </summary>
        /// <returns>a bool</returns>
        public string onOff()
        {
            if(isChecked)
            {
                return "ON";
            }
            return "OFF";
        }

        private bool _isStopped = false;
        /// <summary>
        /// getter and setter
        /// </summary>
        public bool IsStopped
        {get{ return _isStopped; }set { _isStopped = value; } }


    }
}
