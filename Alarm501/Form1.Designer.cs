namespace Alarm501
{
    partial class Form1
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
            this.Edit = new System.Windows.Forms.Button();
            this.Add_Click = new System.Windows.Forms.Button();
            this.snooze_Click = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.labelText = new System.Windows.Forms.Label();
            this.uxListBox = new System.Windows.Forms.ListBox();
            this.TestLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Edit
            // 
            this.Edit.AccessibleName = "edit_Click";
            this.Edit.Location = new System.Drawing.Point(63, 52);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(90, 50);
            this.Edit.TabIndex = 1;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Add_Click
            // 
            this.Add_Click.AccessibleName = "add_Click";
            this.Add_Click.Location = new System.Drawing.Point(195, 52);
            this.Add_Click.Name = "Add_Click";
            this.Add_Click.Size = new System.Drawing.Size(90, 50);
            this.Add_Click.TabIndex = 2;
            this.Add_Click.Text = "+";
            this.Add_Click.UseVisualStyleBackColor = true;
            this.Add_Click.Click += new System.EventHandler(this.Add_Click_Click);
            // 
            // snooze_Click
            // 
            this.snooze_Click.AccessibleName = "snooze_Click";
            this.snooze_Click.Location = new System.Drawing.Point(63, 369);
            this.snooze_Click.Name = "snooze_Click";
            this.snooze_Click.Size = new System.Drawing.Size(90, 50);
            this.snooze_Click.TabIndex = 4;
            this.snooze_Click.Text = "Snooze";
            this.snooze_Click.UseVisualStyleBackColor = true;
            this.snooze_Click.Click += new System.EventHandler(this.snooze_Click_Click);
            // 
            // stop
            // 
            this.stop.AccessibleName = "stop_Click";
            this.stop.Location = new System.Drawing.Point(195, 369);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(90, 50);
            this.stop.TabIndex = 5;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(150, 333);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(0, 13);
            this.labelText.TabIndex = 6;
            // 
            // uxListBox
            // 
            this.uxListBox.FormattingEnabled = true;
            this.uxListBox.Location = new System.Drawing.Point(63, 156);
            this.uxListBox.Name = "uxListBox";
            this.uxListBox.Size = new System.Drawing.Size(222, 121);
            this.uxListBox.TabIndex = 7;
            // 
            // TestLabel
            // 
            this.TestLabel.AutoSize = true;
            this.TestLabel.Location = new System.Drawing.Point(169, 113);
            this.TestLabel.Name = "TestLabel";
            this.TestLabel.Size = new System.Drawing.Size(0, 13);
            this.TestLabel.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 450);
            this.Controls.Add(this.TestLabel);
            this.Controls.Add(this.uxListBox);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.snooze_Click);
            this.Controls.Add(this.Add_Click);
            this.Controls.Add(this.Edit);
            this.Name = "Form1";
            this.Text = "Alarm501";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosedEvent);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Add_Click;
        private System.Windows.Forms.Button snooze_Click;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.ListBox uxListBox;
        private System.Windows.Forms.Label TestLabel;
    }
}

