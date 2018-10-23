namespace Fourex_Kiosk_Analytics
{
    partial class ManualAlert
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_KioskName = new System.Windows.Forms.TextBox();
            this.textBox_Discription = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_StatusSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kiosk Name";
            // 
            // textBox_KioskName
            // 
            this.textBox_KioskName.Enabled = false;
            this.textBox_KioskName.Location = new System.Drawing.Point(164, 108);
            this.textBox_KioskName.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_KioskName.Name = "textBox_KioskName";
            this.textBox_KioskName.Size = new System.Drawing.Size(242, 31);
            this.textBox_KioskName.TabIndex = 1;
            // 
            // textBox_Discription
            // 
            this.textBox_Discription.Location = new System.Drawing.Point(164, 165);
            this.textBox_Discription.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_Discription.Name = "textBox_Discription";
            this.textBox_Discription.Size = new System.Drawing.Size(766, 31);
            this.textBox_Discription.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(780, 232);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create Alert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_StatusSelect
            // 
            this.comboBox_StatusSelect.FormattingEnabled = true;
            this.comboBox_StatusSelect.Location = new System.Drawing.Point(642, 110);
            this.comboBox_StatusSelect.Name = "comboBox_StatusSelect";
            this.comboBox_StatusSelect.Size = new System.Drawing.Size(288, 33);
            this.comboBox_StatusSelect.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Progress Selection";
            // 
            // ManualAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 350);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_StatusSelect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_Discription);
            this.Controls.Add(this.textBox_KioskName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.Name = "ManualAlert";
            this.Text = "Alert Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_KioskName;
        private System.Windows.Forms.TextBox textBox_Discription;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_StatusSelect;
        private System.Windows.Forms.Label label2;
    }
}