namespace DesignPatterns_RemoteProxies
{
    partial class ATMForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.accessButton = new System.Windows.Forms.Button();
            this.getBalanceButton = new System.Windows.Forms.Button();
            this.withdrawButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 22);
            this.textBox1.TabIndex = 0;
            // 
            // accessButton
            // 
            this.accessButton.Location = new System.Drawing.Point(105, 70);
            this.accessButton.Name = "accessButton";
            this.accessButton.Size = new System.Drawing.Size(75, 23);
            this.accessButton.TabIndex = 1;
            this.accessButton.Text = "access";
            this.accessButton.UseVisualStyleBackColor = true;
            this.accessButton.Click += new System.EventHandler(this.accessButton_Click);
            // 
            // getBalanceButton
            // 
            this.getBalanceButton.Location = new System.Drawing.Point(105, 112);
            this.getBalanceButton.Name = "getBalanceButton";
            this.getBalanceButton.Size = new System.Drawing.Size(75, 23);
            this.getBalanceButton.TabIndex = 2;
            this.getBalanceButton.Text = "balance";
            this.getBalanceButton.UseVisualStyleBackColor = true;
            this.getBalanceButton.Click += new System.EventHandler(this.getBalanceButton_Click);
            // 
            // withdrawButton
            // 
            this.withdrawButton.Location = new System.Drawing.Point(105, 152);
            this.withdrawButton.Name = "withdrawButton";
            this.withdrawButton.Size = new System.Drawing.Size(75, 23);
            this.withdrawButton.TabIndex = 3;
            this.withdrawButton.Text = "withdraw";
            this.withdrawButton.UseVisualStyleBackColor = true;
            this.withdrawButton.Click += new System.EventHandler(this.withdrawButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(105, 193);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 4;
            this.logoutButton.Text = "logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // ATMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.withdrawButton);
            this.Controls.Add(this.getBalanceButton);
            this.Controls.Add(this.accessButton);
            this.Controls.Add(this.textBox1);
            this.Name = "ATMForm";
            this.Text = "ATM Demo Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button accessButton;
        private System.Windows.Forms.Button getBalanceButton;
        private System.Windows.Forms.Button withdrawButton;
        private System.Windows.Forms.Button logoutButton;
    }
}

