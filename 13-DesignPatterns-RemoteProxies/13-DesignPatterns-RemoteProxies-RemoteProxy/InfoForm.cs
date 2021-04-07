using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesignPatterns_RemoteProxies_RemoteProxy
{
    public partial class InfoForm : Form
    {   // coordinates for upper left corner of the visible passive form:
        static int xPosition = 0;
        static int yPosition = 0;

        public InfoForm()
        {
            InitializeComponent();
            // set location of where to display the new passive form:
            this.Location = new Point(xPosition, yPosition);
            // update position coordinates for the next time a passive form is created:
            xPosition = xPosition + this.Width;
            yPosition = yPosition + 50;
        }

        // adds a new line of text, s,  to the output:
        public void WriteLine(string s)
        {
            label1.Text = "Remote proc call.  Slow.  Please Wait";
            label2.Text = s;
            Refresh();
        }
    }
}
