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
    public partial class WThread : Form
    {
        private FileController b;
        private FileWriter mywriter;
        private bool writing = false;

        public WThread(FileController b)
        {
            this.b = b;
            InitializeComponent();
        }

        // signals to open buffer and also to write lines into it
        private void button1_Click(object sender, EventArgs e)
        {
            if (!writing)
            {
                mywriter = b.openWrite();
                if (mywriter != null)
                {
                    writing = true;
                    button1.Text = "Write";
                    textBox1.Text = "";
                    button2.Enabled = true;
                }
                else { textBox1.Text = "Open Error"; }
            }
            else
            { // writing an opened file:
                mywriter.write(textBox1.Text);
                textBox1.Text = "";
            }
        }

        // signals to close file
        private void button2_Click(object sender, EventArgs e)
        {
            if (writing)
            {
                mywriter.close();
                writing = false;
                button1.Text = "Open";
                textBox1.Text = "";
                button2.Enabled = false;
            }
        }

        private void WForm_Load(object sender, EventArgs e)
        { button2.Enabled = false; }
    }
}
