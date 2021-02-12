/*
* Project 1, AUTHOR: Jonathan Welch
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm501
{
    public class Alarm
    {
        /// <summary>
        /// private Vars for getters and setters
        /// </summary>
        private DateTime _date;
        private bool isChecked;
        private bool _isStopped = false;

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
        /// getter and setter
        /// </summary>
        public bool IsStopped
        { get { return _isStopped; } set { _isStopped = value; } }


    }
}
