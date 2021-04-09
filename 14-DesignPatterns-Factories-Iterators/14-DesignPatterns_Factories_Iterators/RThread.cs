using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesignPatterns_Factories_Iterators
{
    public partial class RThread : Form
    {
        private FileController b;
        private FileReader myReader;
        private bool reading;

        public RThread(FileController b)
        {
            this.b = b;
            reading = false;
            InitializeComponent();
        }

        private void RForm_Load(object sender, EventArgs e)
        {
            button1.Text = "Open";
            button2.Text = "Close";
            button2.Enabled = false;
        }

        // signals to open file to read lines from it
        private void button1_Click(object sender, EventArgs e)
        {
            if (!reading)
            {
                myReader = b.openRead();
                if (myReader != null)
                {
                    reading = true;
                    button1.Text = "Read";
                    label1.Text = "";
                    button2.Enabled = true;
                }
                else { label1.Text = "Open error. Try later"; }
            }
            else
            { // reading an opened file:
                string s = myReader.read();
                if (s == null) { s = "EOF"; }
                label1.Text = label1.Text + "\n" + s;
            }
        }

        // signals to close buffer
        private void button2_Click(object sender, EventArgs e)
        {
            if (reading)
            {
                myReader.close();
                reading = false;
                button1.Text = "Open";
                button2.Enabled = false;
            }
        }
    }
}
