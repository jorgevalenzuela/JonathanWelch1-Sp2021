using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesignPatterns_RemoteProxies
{
    // simplistic form for testing use of bank accounts:
    public partial class ATMForm : Form
    {
        // Widgets in the Form:
        //   TextBox textBox1;  // the text box for typing numbers
        //   Button accessButton, getBalanceButton, withdrawButton, logoutButton

        private ATMControl c;  // handle to the controller for this form

        public ATMForm(ATMControl c)
        {
            this.c = c;
            InitializeComponent();
        }

        // handlers for the four buttons:
        private void accessButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = c.handleLogin(textBox1.Text);
        }

        private void getBalanceButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "balance: " + c.handleBalanceRequest();
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "withdrawn: " + c.handleWithdraw(textBox1.Text);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = c.handleLogout();
        }


    }
}
