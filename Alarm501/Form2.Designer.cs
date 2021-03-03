namespace Alarm501
{
    partial class Form2
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.setButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cancel = new System.Windows.Forms.Button();
            this.Sounds = new System.Windows.Forms.ComboBox();
            this.SnoozeTimeSet = new System.Windows.Forms.NumericUpDown();
            this.LabelSound = new System.Windows.Forms.Label();
            this.SnoozeTimeSound = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SnoozeTimeSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(82, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // setButton
            // 
            this.setButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.setButton.Location = new System.Drawing.Point(207, 183);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 23);
            this.setButton.TabIndex = 1;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(288, 34);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(40, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "On";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(82, 183);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Sounds
            // 
            this.Sounds.AllowDrop = true;
            this.Sounds.FormattingEnabled = true;
            this.Sounds.Location = new System.Drawing.Point(121, 81);
            this.Sounds.Name = "Sounds";
            this.Sounds.Size = new System.Drawing.Size(125, 21);
            this.Sounds.TabIndex = 4;
            // 
            // SnoozeTimeSet
            // 
            this.SnoozeTimeSet.Location = new System.Drawing.Point(121, 135);
            this.SnoozeTimeSet.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.SnoozeTimeSet.Name = "SnoozeTimeSet";
            this.SnoozeTimeSet.Size = new System.Drawing.Size(125, 20);
            this.SnoozeTimeSet.TabIndex = 5;
            // 
            // LabelSound
            // 
            this.LabelSound.AutoSize = true;
            this.LabelSound.Location = new System.Drawing.Point(36, 84);
            this.LabelSound.Name = "LabelSound";
            this.LabelSound.Size = new System.Drawing.Size(79, 13);
            this.LabelSound.TabIndex = 6;
            this.LabelSound.Text = "Sound of Alarm";
            // 
            // SnoozeTimeSound
            // 
            this.SnoozeTimeSound.AutoSize = true;
            this.SnoozeTimeSound.Location = new System.Drawing.Point(46, 137);
            this.SnoozeTimeSound.Name = "SnoozeTimeSound";
            this.SnoozeTimeSound.Size = new System.Drawing.Size(69, 13);
            this.SnoozeTimeSound.TabIndex = 7;
            this.SnoozeTimeSound.Text = "Snooze Time";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 275);
            this.Controls.Add(this.SnoozeTimeSound);
            this.Controls.Add(this.LabelSound);
            this.Controls.Add(this.SnoozeTimeSet);
            this.Controls.Add(this.Sounds);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Form2";
            this.Text = "Add/Edit Alarm";
            ((System.ComponentModel.ISupportInitialize)(this.SnoozeTimeSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox Sounds;
        private System.Windows.Forms.NumericUpDown SnoozeTimeSet;
        private System.Windows.Forms.Label LabelSound;
        private System.Windows.Forms.Label SnoozeTimeSound;
    }
}