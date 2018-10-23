namespace Fourex_Kiosk_Analytics
{
    partial class OnOffLine
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
            this.button_Save = new System.Windows.Forms.Button();
            this.checkBox_OnOffLine = new System.Windows.Forms.CheckBox();
            this.textBox_KioskName = new System.Windows.Forms.TextBox();
            this.textBox_DateTime = new System.Windows.Forms.TextBox();
            this.textBox_Reason = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_NewReason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(284, 136);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 0;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // checkBox_OnOffLine
            // 
            this.checkBox_OnOffLine.AutoSize = true;
            this.checkBox_OnOffLine.Location = new System.Drawing.Point(92, 101);
            this.checkBox_OnOffLine.Name = "checkBox_OnOffLine";
            this.checkBox_OnOffLine.Size = new System.Drawing.Size(151, 17);
            this.checkBox_OnOffLine.TabIndex = 1;
            this.checkBox_OnOffLine.Text = "Maintenance Mode Status";
            this.checkBox_OnOffLine.UseVisualStyleBackColor = true;
            // 
            // textBox_KioskName
            // 
            this.textBox_KioskName.Enabled = false;
            this.textBox_KioskName.Location = new System.Drawing.Point(92, 23);
            this.textBox_KioskName.Name = "textBox_KioskName";
            this.textBox_KioskName.Size = new System.Drawing.Size(113, 20);
            this.textBox_KioskName.TabIndex = 2;
            // 
            // textBox_DateTime
            // 
            this.textBox_DateTime.Enabled = false;
            this.textBox_DateTime.Location = new System.Drawing.Point(284, 23);
            this.textBox_DateTime.Name = "textBox_DateTime";
            this.textBox_DateTime.Size = new System.Drawing.Size(113, 20);
            this.textBox_DateTime.TabIndex = 3;
            // 
            // textBox_Reason
            // 
            this.textBox_Reason.Enabled = false;
            this.textBox_Reason.Location = new System.Drawing.Point(92, 49);
            this.textBox_Reason.Name = "textBox_Reason";
            this.textBox_Reason.Size = new System.Drawing.Size(305, 20);
            this.textBox_Reason.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kiosk Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Last Active";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Last Reason";
            // 
            // textBox_NewReason
            // 
            this.textBox_NewReason.Location = new System.Drawing.Point(92, 75);
            this.textBox_NewReason.Name = "textBox_NewReason";
            this.textBox_NewReason.Size = new System.Drawing.Size(305, 20);
            this.textBox_NewReason.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "New Reason";
            // 
            // OnOffLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 183);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_NewReason);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Reason);
            this.Controls.Add(this.textBox_DateTime);
            this.Controls.Add(this.textBox_KioskName);
            this.Controls.Add(this.checkBox_OnOffLine);
            this.Controls.Add(this.button_Save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OnOffLine";
            this.Text = "Maintenance Mode ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.CheckBox checkBox_OnOffLine;
        private System.Windows.Forms.TextBox textBox_KioskName;
        private System.Windows.Forms.TextBox textBox_DateTime;
        private System.Windows.Forms.TextBox textBox_Reason;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_NewReason;
        private System.Windows.Forms.Label label4;
    }
}