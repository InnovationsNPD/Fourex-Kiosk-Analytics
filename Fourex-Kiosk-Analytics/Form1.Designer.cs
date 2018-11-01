namespace Fourex_Kiosk_Analytics
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_TriggerMail = new System.Windows.Forms.Button();
            this.textBox_ProgressInfo = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox_KioskList = new System.Windows.Forms.ComboBox();
            this.checkBox_KioskFilter = new System.Windows.Forms.CheckBox();
            this.listView_Main = new System.Windows.Forms.ListView();
            this.textBox_ListView = new System.Windows.Forms.TextBox();
            this.groupBox_DateSelect = new System.Windows.Forms.GroupBox();
            this.button_MaunualAlrest = new System.Windows.Forms.Button();
            this.button_OnOffLine = new System.Windows.Forms.Button();
            this.dateTimePicker_TimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_TimeStart = new System.Windows.Forms.DateTimePicker();
            this.radioButton_DateAll = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_DateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_DateStart = new System.Windows.Forms.DateTimePicker();
            this.radioButton_Custom = new System.Windows.Forms.RadioButton();
            this.radioButton_FromYesterday = new System.Windows.Forms.RadioButton();
            this.radioButton_Date_Today = new System.Windows.Forms.RadioButton();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.checkBox_Notification = new System.Windows.Forms.CheckBox();
            this.checkBox_Remedy = new System.Windows.Forms.CheckBox();
            this.checkBox_CoinDispenser = new System.Windows.Forms.CheckBox();
            this.checkBox_NoteDispenser = new System.Windows.Forms.CheckBox();
            this.LoadAlertCounts = new System.Windows.Forms.Timer(this.components);
            this.MainHouseKeeping = new System.Windows.Forms.Timer(this.components);
            this.listView_AlertCounts = new System.Windows.Forms.ListView();
            this.groupBox_Alert = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_Failures_ND_USD = new System.Windows.Forms.CheckBox();
            this.checkBox_Failures_ND_EUR = new System.Windows.Forms.CheckBox();
            this.checkBox_Failures_ND_GBP = new System.Windows.Forms.CheckBox();
            this.checkBox_Failures_CD_USD = new System.Windows.Forms.CheckBox();
            this.checkBox_Failures_CD_EUR = new System.Windows.Forms.CheckBox();
            this.checkBox_Failures_CD_GBP2 = new System.Windows.Forms.CheckBox();
            this.checkBox_Failures_CD_GBP1 = new System.Windows.Forms.CheckBox();
            this.checkBox_Failures_BV = new System.Windows.Forms.CheckBox();
            this.checkBox_Alerts = new System.Windows.Forms.CheckBox();
            this.checkBox_MModeON = new System.Windows.Forms.CheckBox();
            this.checkBox_MMode = new System.Windows.Forms.CheckBox();
            this.listView_OffLineKiosks = new System.Windows.Forms.ListView();
            this.KioskName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OffLineHours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Reason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox_OffLineKiosk = new System.Windows.Forms.GroupBox();
            this.OffLineListViewUpdate = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.POPMail = new System.Windows.Forms.Timer(this.components);
            this.textBox_POPMail = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_InportREMNOT = new System.Windows.Forms.Button();
            this.textBox_ImportStatus = new System.Windows.Forms.TextBox();
            this.listView_Remedy = new System.Windows.Forms.ListView();
            this.button_UpdateRemNot = new System.Windows.Forms.Button();
            this.groupBox_Remedy = new System.Windows.Forms.GroupBox();
            this.groupBox_Notification = new System.Windows.Forms.GroupBox();
            this.listView_Notification = new System.Windows.Forms.ListView();
            this.timer_updateListView_Rem_Not = new System.Windows.Forms.Timer(this.components);
            this.listView_AlertsKeyIndicator = new System.Windows.Forms.ListView();
            this.contextMenuStrip_AlertManager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editAlertManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_AlertManager = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox_UPTime = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_UPTimeKioskSelect = new System.Windows.Forms.ComboBox();
            this.timer_UPTimeUpdate = new System.Windows.Forms.Timer(this.components);
            this.groupBox_KioskAVEUPTime = new System.Windows.Forms.GroupBox();
            this.listView_AVE_7_Day = new System.Windows.Forms.ListView();
            this.groupBox_DateSelect.SuspendLayout();
            this.groupBox_Alert.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox_OffLineKiosk.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_Remedy.SuspendLayout();
            this.groupBox_Notification.SuspendLayout();
            this.contextMenuStrip_AlertManager.SuspendLayout();
            this.groupBox_AlertManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox_UPTime.SuspendLayout();
            this.groupBox_KioskAVEUPTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_TriggerMail
            // 
            this.button_TriggerMail.Location = new System.Drawing.Point(818, 17);
            this.button_TriggerMail.Margin = new System.Windows.Forms.Padding(6);
            this.button_TriggerMail.Name = "button_TriggerMail";
            this.button_TriggerMail.Size = new System.Drawing.Size(150, 44);
            this.button_TriggerMail.TabIndex = 0;
            this.button_TriggerMail.Text = "Trigger Mail ";
            this.button_TriggerMail.UseVisualStyleBackColor = true;
            this.button_TriggerMail.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_ProgressInfo
            // 
            this.textBox_ProgressInfo.Location = new System.Drawing.Point(12, 69);
            this.textBox_ProgressInfo.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_ProgressInfo.Name = "textBox_ProgressInfo";
            this.textBox_ProgressInfo.Size = new System.Drawing.Size(1184, 31);
            this.textBox_ProgressInfo.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox_KioskList
            // 
            this.comboBox_KioskList.FormattingEnabled = true;
            this.comboBox_KioskList.Location = new System.Drawing.Point(24, 23);
            this.comboBox_KioskList.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox_KioskList.Name = "comboBox_KioskList";
            this.comboBox_KioskList.Size = new System.Drawing.Size(492, 33);
            this.comboBox_KioskList.TabIndex = 6;
            this.comboBox_KioskList.SelectedIndexChanged += new System.EventHandler(this.comboBox_KioskList_SelectedIndexChanged);
            // 
            // checkBox_KioskFilter
            // 
            this.checkBox_KioskFilter.AutoSize = true;
            this.checkBox_KioskFilter.Location = new System.Drawing.Point(652, 29);
            this.checkBox_KioskFilter.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox_KioskFilter.Name = "checkBox_KioskFilter";
            this.checkBox_KioskFilter.Size = new System.Drawing.Size(151, 29);
            this.checkBox_KioskFilter.TabIndex = 7;
            this.checkBox_KioskFilter.Text = "Filter Kiosk";
            this.checkBox_KioskFilter.UseVisualStyleBackColor = true;
            this.checkBox_KioskFilter.CheckedChanged += new System.EventHandler(this.checkBox_KioskFilter_CheckedChanged);
            // 
            // listView_Main
            // 
            this.listView_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_Main.Location = new System.Drawing.Point(24, 214);
            this.listView_Main.Margin = new System.Windows.Forms.Padding(6);
            this.listView_Main.Name = "listView_Main";
            this.listView_Main.Size = new System.Drawing.Size(2330, 981);
            this.listView_Main.TabIndex = 10;
            this.listView_Main.UseCompatibleStateImageBehavior = false;
            this.listView_Main.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // textBox_ListView
            // 
            this.textBox_ListView.Location = new System.Drawing.Point(24, 1869);
            this.textBox_ListView.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_ListView.Name = "textBox_ListView";
            this.textBox_ListView.Size = new System.Drawing.Size(3136, 31);
            this.textBox_ListView.TabIndex = 11;
            // 
            // groupBox_DateSelect
            // 
            this.groupBox_DateSelect.Controls.Add(this.button_MaunualAlrest);
            this.groupBox_DateSelect.Controls.Add(this.button_OnOffLine);
            this.groupBox_DateSelect.Controls.Add(this.dateTimePicker_TimeEnd);
            this.groupBox_DateSelect.Controls.Add(this.dateTimePicker_TimeStart);
            this.groupBox_DateSelect.Controls.Add(this.radioButton_DateAll);
            this.groupBox_DateSelect.Controls.Add(this.label2);
            this.groupBox_DateSelect.Controls.Add(this.label1);
            this.groupBox_DateSelect.Controls.Add(this.dateTimePicker_DateEnd);
            this.groupBox_DateSelect.Controls.Add(this.dateTimePicker_DateStart);
            this.groupBox_DateSelect.Controls.Add(this.radioButton_Custom);
            this.groupBox_DateSelect.Controls.Add(this.radioButton_FromYesterday);
            this.groupBox_DateSelect.Controls.Add(this.radioButton_Date_Today);
            this.groupBox_DateSelect.Location = new System.Drawing.Point(24, 60);
            this.groupBox_DateSelect.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_DateSelect.Name = "groupBox_DateSelect";
            this.groupBox_DateSelect.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_DateSelect.Size = new System.Drawing.Size(1500, 142);
            this.groupBox_DateSelect.TabIndex = 12;
            this.groupBox_DateSelect.TabStop = false;
            this.groupBox_DateSelect.Text = "Date Select";
            // 
            // button_MaunualAlrest
            // 
            this.button_MaunualAlrest.Location = new System.Drawing.Point(312, 83);
            this.button_MaunualAlrest.Margin = new System.Windows.Forms.Padding(6);
            this.button_MaunualAlrest.Name = "button_MaunualAlrest";
            this.button_MaunualAlrest.Size = new System.Drawing.Size(150, 44);
            this.button_MaunualAlrest.TabIndex = 29;
            this.button_MaunualAlrest.Text = "Creat Alert";
            this.button_MaunualAlrest.UseVisualStyleBackColor = true;
            this.button_MaunualAlrest.Click += new System.EventHandler(this.button_MaunualAlrest_Click);
            // 
            // button_OnOffLine
            // 
            this.button_OnOffLine.Location = new System.Drawing.Point(12, 81);
            this.button_OnOffLine.Margin = new System.Windows.Forms.Padding(6);
            this.button_OnOffLine.Name = "button_OnOffLine";
            this.button_OnOffLine.Size = new System.Drawing.Size(250, 44);
            this.button_OnOffLine.TabIndex = 28;
            this.button_OnOffLine.Text = "Maintenance Mode ";
            this.button_OnOffLine.UseVisualStyleBackColor = true;
            this.button_OnOffLine.Click += new System.EventHandler(this.button_OnOffLine_Click);
            // 
            // dateTimePicker_TimeEnd
            // 
            this.dateTimePicker_TimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_TimeEnd.Location = new System.Drawing.Point(1086, 73);
            this.dateTimePicker_TimeEnd.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePicker_TimeEnd.Name = "dateTimePicker_TimeEnd";
            this.dateTimePicker_TimeEnd.Size = new System.Drawing.Size(252, 31);
            this.dateTimePicker_TimeEnd.TabIndex = 19;
            // 
            // dateTimePicker_TimeStart
            // 
            this.dateTimePicker_TimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_TimeStart.Location = new System.Drawing.Point(696, 73);
            this.dateTimePicker_TimeStart.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePicker_TimeStart.Name = "dateTimePicker_TimeStart";
            this.dateTimePicker_TimeStart.Size = new System.Drawing.Size(252, 31);
            this.dateTimePicker_TimeStart.TabIndex = 14;
            // 
            // radioButton_DateAll
            // 
            this.radioButton_DateAll.AutoSize = true;
            this.radioButton_DateAll.Location = new System.Drawing.Point(474, 37);
            this.radioButton_DateAll.Margin = new System.Windows.Forms.Padding(6);
            this.radioButton_DateAll.Name = "radioButton_DateAll";
            this.radioButton_DateAll.Size = new System.Drawing.Size(67, 29);
            this.radioButton_DateAll.TabIndex = 18;
            this.radioButton_DateAll.TabStop = true;
            this.radioButton_DateAll.Text = "All";
            this.radioButton_DateAll.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(964, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Start Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(574, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Start Date";
            // 
            // dateTimePicker_DateEnd
            // 
            this.dateTimePicker_DateEnd.Location = new System.Drawing.Point(1086, 31);
            this.dateTimePicker_DateEnd.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePicker_DateEnd.Name = "dateTimePicker_DateEnd";
            this.dateTimePicker_DateEnd.Size = new System.Drawing.Size(252, 31);
            this.dateTimePicker_DateEnd.TabIndex = 15;
            // 
            // dateTimePicker_DateStart
            // 
            this.dateTimePicker_DateStart.Location = new System.Drawing.Point(696, 23);
            this.dateTimePicker_DateStart.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePicker_DateStart.Name = "dateTimePicker_DateStart";
            this.dateTimePicker_DateStart.Size = new System.Drawing.Size(252, 31);
            this.dateTimePicker_DateStart.TabIndex = 13;
            // 
            // radioButton_Custom
            // 
            this.radioButton_Custom.AutoSize = true;
            this.radioButton_Custom.Location = new System.Drawing.Point(342, 37);
            this.radioButton_Custom.Margin = new System.Windows.Forms.Padding(6);
            this.radioButton_Custom.Name = "radioButton_Custom";
            this.radioButton_Custom.Size = new System.Drawing.Size(116, 29);
            this.radioButton_Custom.TabIndex = 14;
            this.radioButton_Custom.TabStop = true;
            this.radioButton_Custom.Text = "Custom";
            this.radioButton_Custom.UseVisualStyleBackColor = true;
            // 
            // radioButton_FromYesterday
            // 
            this.radioButton_FromYesterday.AutoSize = true;
            this.radioButton_FromYesterday.Location = new System.Drawing.Point(134, 37);
            this.radioButton_FromYesterday.Margin = new System.Windows.Forms.Padding(6);
            this.radioButton_FromYesterday.Name = "radioButton_FromYesterday";
            this.radioButton_FromYesterday.Size = new System.Drawing.Size(196, 29);
            this.radioButton_FromYesterday.TabIndex = 13;
            this.radioButton_FromYesterday.TabStop = true;
            this.radioButton_FromYesterday.Text = "From Yesterday";
            this.radioButton_FromYesterday.UseVisualStyleBackColor = true;
            // 
            // radioButton_Date_Today
            // 
            this.radioButton_Date_Today.AutoSize = true;
            this.radioButton_Date_Today.Location = new System.Drawing.Point(12, 37);
            this.radioButton_Date_Today.Margin = new System.Windows.Forms.Padding(6);
            this.radioButton_Date_Today.Name = "radioButton_Date_Today";
            this.radioButton_Date_Today.Size = new System.Drawing.Size(103, 29);
            this.radioButton_Date_Today.TabIndex = 0;
            this.radioButton_Date_Today.TabStop = true;
            this.radioButton_Date_Today.Text = "Today";
            this.radioButton_Date_Today.UseVisualStyleBackColor = true;
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(524, 21);
            this.button_Refresh.Margin = new System.Windows.Forms.Padding(6);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(116, 44);
            this.button_Refresh.TabIndex = 13;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // checkBox_Notification
            // 
            this.checkBox_Notification.AutoSize = true;
            this.checkBox_Notification.Location = new System.Drawing.Point(28, 46);
            this.checkBox_Notification.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox_Notification.Name = "checkBox_Notification";
            this.checkBox_Notification.Size = new System.Drawing.Size(151, 29);
            this.checkBox_Notification.TabIndex = 20;
            this.checkBox_Notification.Text = "Notification";
            this.checkBox_Notification.UseVisualStyleBackColor = true;
            // 
            // checkBox_Remedy
            // 
            this.checkBox_Remedy.AutoSize = true;
            this.checkBox_Remedy.Location = new System.Drawing.Point(28, 90);
            this.checkBox_Remedy.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox_Remedy.Name = "checkBox_Remedy";
            this.checkBox_Remedy.Size = new System.Drawing.Size(123, 29);
            this.checkBox_Remedy.TabIndex = 21;
            this.checkBox_Remedy.Text = "Remedy";
            this.checkBox_Remedy.UseVisualStyleBackColor = true;
            // 
            // checkBox_CoinDispenser
            // 
            this.checkBox_CoinDispenser.AutoSize = true;
            this.checkBox_CoinDispenser.Location = new System.Drawing.Point(266, 46);
            this.checkBox_CoinDispenser.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox_CoinDispenser.Name = "checkBox_CoinDispenser";
            this.checkBox_CoinDispenser.Size = new System.Drawing.Size(191, 29);
            this.checkBox_CoinDispenser.TabIndex = 22;
            this.checkBox_CoinDispenser.Text = "Coin Dispenser";
            this.checkBox_CoinDispenser.UseVisualStyleBackColor = true;
            // 
            // checkBox_NoteDispenser
            // 
            this.checkBox_NoteDispenser.AutoSize = true;
            this.checkBox_NoteDispenser.Location = new System.Drawing.Point(265, 90);
            this.checkBox_NoteDispenser.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox_NoteDispenser.Name = "checkBox_NoteDispenser";
            this.checkBox_NoteDispenser.Size = new System.Drawing.Size(192, 29);
            this.checkBox_NoteDispenser.TabIndex = 23;
            this.checkBox_NoteDispenser.Text = "Note Dispenser";
            this.checkBox_NoteDispenser.UseVisualStyleBackColor = true;
            // 
            // LoadAlertCounts
            // 
            this.LoadAlertCounts.Enabled = true;
            this.LoadAlertCounts.Interval = 30000;
            this.LoadAlertCounts.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainHouseKeeping
            // 
            this.MainHouseKeeping.Enabled = true;
            this.MainHouseKeeping.Tick += new System.EventHandler(this.MainHouseKeeping_Tick);
            // 
            // listView_AlertCounts
            // 
            this.listView_AlertCounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_AlertCounts.Location = new System.Drawing.Point(8, 23);
            this.listView_AlertCounts.Margin = new System.Windows.Forms.Padding(6);
            this.listView_AlertCounts.Name = "listView_AlertCounts";
            this.listView_AlertCounts.Size = new System.Drawing.Size(486, 280);
            this.listView_AlertCounts.TabIndex = 24;
            this.listView_AlertCounts.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox_Alert
            // 
            this.groupBox_Alert.Controls.Add(this.listView_AlertCounts);
            this.groupBox_Alert.Location = new System.Drawing.Point(1038, 1210);
            this.groupBox_Alert.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_Alert.Name = "groupBox_Alert";
            this.groupBox_Alert.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_Alert.Size = new System.Drawing.Size(506, 313);
            this.groupBox_Alert.TabIndex = 25;
            this.groupBox_Alert.TabStop = false;
            this.groupBox_Alert.Text = "Alert Counts (Last 24 Hours)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.checkBox_Alerts);
            this.groupBox2.Controls.Add(this.checkBox_MModeON);
            this.groupBox2.Controls.Add(this.checkBox_MMode);
            this.groupBox2.Controls.Add(this.checkBox_Remedy);
            this.groupBox2.Controls.Add(this.checkBox_NoteDispenser);
            this.groupBox2.Controls.Add(this.checkBox_CoinDispenser);
            this.groupBox2.Controls.Add(this.checkBox_Notification);
            this.groupBox2.Location = new System.Drawing.Point(1536, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(818, 200);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filters";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_Failures_ND_USD);
            this.groupBox3.Controls.Add(this.checkBox_Failures_ND_EUR);
            this.groupBox3.Controls.Add(this.checkBox_Failures_ND_GBP);
            this.groupBox3.Controls.Add(this.checkBox_Failures_CD_USD);
            this.groupBox3.Controls.Add(this.checkBox_Failures_CD_EUR);
            this.groupBox3.Controls.Add(this.checkBox_Failures_CD_GBP2);
            this.groupBox3.Controls.Add(this.checkBox_Failures_CD_GBP1);
            this.groupBox3.Controls.Add(this.checkBox_Failures_BV);
            this.groupBox3.Location = new System.Drawing.Point(493, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 172);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Heart Beat Failures ";
            // 
            // checkBox_Failures_ND_USD
            // 
            this.checkBox_Failures_ND_USD.AutoSize = true;
            this.checkBox_Failures_ND_USD.Location = new System.Drawing.Point(168, 135);
            this.checkBox_Failures_ND_USD.Name = "checkBox_Failures_ND_USD";
            this.checkBox_Failures_ND_USD.Size = new System.Drawing.Size(124, 29);
            this.checkBox_Failures_ND_USD.TabIndex = 34;
            this.checkBox_Failures_ND_USD.Text = "ND USD";
            this.checkBox_Failures_ND_USD.UseVisualStyleBackColor = true;
            this.checkBox_Failures_ND_USD.CheckedChanged += new System.EventHandler(this.checkBox_Failures_ND_USD_CheckedChanged);
            // 
            // checkBox_Failures_ND_EUR
            // 
            this.checkBox_Failures_ND_EUR.AutoSize = true;
            this.checkBox_Failures_ND_EUR.Location = new System.Drawing.Point(168, 100);
            this.checkBox_Failures_ND_EUR.Name = "checkBox_Failures_ND_EUR";
            this.checkBox_Failures_ND_EUR.Size = new System.Drawing.Size(124, 29);
            this.checkBox_Failures_ND_EUR.TabIndex = 33;
            this.checkBox_Failures_ND_EUR.Text = "ND EUR";
            this.checkBox_Failures_ND_EUR.UseVisualStyleBackColor = true;
            this.checkBox_Failures_ND_EUR.CheckedChanged += new System.EventHandler(this.checkBox_Failures_ND_EUR_CheckedChanged);
            // 
            // checkBox_Failures_ND_GBP
            // 
            this.checkBox_Failures_ND_GBP.AutoSize = true;
            this.checkBox_Failures_ND_GBP.Location = new System.Drawing.Point(168, 65);
            this.checkBox_Failures_ND_GBP.Name = "checkBox_Failures_ND_GBP";
            this.checkBox_Failures_ND_GBP.Size = new System.Drawing.Size(124, 29);
            this.checkBox_Failures_ND_GBP.TabIndex = 32;
            this.checkBox_Failures_ND_GBP.Text = "ND GBP";
            this.checkBox_Failures_ND_GBP.UseVisualStyleBackColor = true;
            this.checkBox_Failures_ND_GBP.CheckedChanged += new System.EventHandler(this.checkBox_Failures_ND_GBP_CheckedChanged);
            // 
            // checkBox_Failures_CD_USD
            // 
            this.checkBox_Failures_CD_USD.AutoSize = true;
            this.checkBox_Failures_CD_USD.Location = new System.Drawing.Point(168, 30);
            this.checkBox_Failures_CD_USD.Name = "checkBox_Failures_CD_USD";
            this.checkBox_Failures_CD_USD.Size = new System.Drawing.Size(124, 29);
            this.checkBox_Failures_CD_USD.TabIndex = 31;
            this.checkBox_Failures_CD_USD.Text = "CD USD";
            this.checkBox_Failures_CD_USD.UseVisualStyleBackColor = true;
            this.checkBox_Failures_CD_USD.CheckedChanged += new System.EventHandler(this.checkBox_Failures_CD_USD_CheckedChanged);
            // 
            // checkBox_Failures_CD_EUR
            // 
            this.checkBox_Failures_CD_EUR.AutoSize = true;
            this.checkBox_Failures_CD_EUR.Location = new System.Drawing.Point(18, 132);
            this.checkBox_Failures_CD_EUR.Name = "checkBox_Failures_CD_EUR";
            this.checkBox_Failures_CD_EUR.Size = new System.Drawing.Size(124, 29);
            this.checkBox_Failures_CD_EUR.TabIndex = 30;
            this.checkBox_Failures_CD_EUR.Text = "CD EUR";
            this.checkBox_Failures_CD_EUR.UseVisualStyleBackColor = true;
            this.checkBox_Failures_CD_EUR.CheckedChanged += new System.EventHandler(this.checkBox_Failures_CD_EUR_CheckedChanged);
            // 
            // checkBox_Failures_CD_GBP2
            // 
            this.checkBox_Failures_CD_GBP2.AutoSize = true;
            this.checkBox_Failures_CD_GBP2.Location = new System.Drawing.Point(18, 98);
            this.checkBox_Failures_CD_GBP2.Name = "checkBox_Failures_CD_GBP2";
            this.checkBox_Failures_CD_GBP2.Size = new System.Drawing.Size(136, 29);
            this.checkBox_Failures_CD_GBP2.TabIndex = 29;
            this.checkBox_Failures_CD_GBP2.Text = "CD GBP2";
            this.checkBox_Failures_CD_GBP2.UseVisualStyleBackColor = true;
            this.checkBox_Failures_CD_GBP2.CheckedChanged += new System.EventHandler(this.checkBox_Failures_CD_GBP2_CheckedChanged);
            // 
            // checkBox_Failures_CD_GBP1
            // 
            this.checkBox_Failures_CD_GBP1.AutoSize = true;
            this.checkBox_Failures_CD_GBP1.Location = new System.Drawing.Point(18, 63);
            this.checkBox_Failures_CD_GBP1.Name = "checkBox_Failures_CD_GBP1";
            this.checkBox_Failures_CD_GBP1.Size = new System.Drawing.Size(136, 29);
            this.checkBox_Failures_CD_GBP1.TabIndex = 28;
            this.checkBox_Failures_CD_GBP1.Text = "CD GBP1";
            this.checkBox_Failures_CD_GBP1.UseVisualStyleBackColor = true;
            this.checkBox_Failures_CD_GBP1.CheckedChanged += new System.EventHandler(this.checkBox_Failures_CD_GBP1_CheckedChanged);
            // 
            // checkBox_Failures_BV
            // 
            this.checkBox_Failures_BV.AutoSize = true;
            this.checkBox_Failures_BV.Location = new System.Drawing.Point(18, 30);
            this.checkBox_Failures_BV.Name = "checkBox_Failures_BV";
            this.checkBox_Failures_BV.Size = new System.Drawing.Size(72, 29);
            this.checkBox_Failures_BV.TabIndex = 27;
            this.checkBox_Failures_BV.Text = "BV";
            this.checkBox_Failures_BV.UseVisualStyleBackColor = true;
            this.checkBox_Failures_BV.CheckedChanged += new System.EventHandler(this.checkBox_Failures_BV_CheckedChanged);
            // 
            // checkBox_Alerts
            // 
            this.checkBox_Alerts.AutoSize = true;
            this.checkBox_Alerts.Location = new System.Drawing.Point(28, 133);
            this.checkBox_Alerts.Name = "checkBox_Alerts";
            this.checkBox_Alerts.Size = new System.Drawing.Size(99, 29);
            this.checkBox_Alerts.TabIndex = 26;
            this.checkBox_Alerts.Text = "Alerts";
            this.checkBox_Alerts.UseVisualStyleBackColor = true;
            // 
            // checkBox_MModeON
            // 
            this.checkBox_MModeON.AutoSize = true;
            this.checkBox_MModeON.Location = new System.Drawing.Point(265, 131);
            this.checkBox_MModeON.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox_MModeON.Name = "checkBox_MModeON";
            this.checkBox_MModeON.Size = new System.Drawing.Size(159, 29);
            this.checkBox_MModeON.TabIndex = 25;
            this.checkBox_MModeON.Text = "M Mode ON";
            this.checkBox_MModeON.UseVisualStyleBackColor = true;
            // 
            // checkBox_MMode
            // 
            this.checkBox_MMode.AutoSize = true;
            this.checkBox_MMode.Location = new System.Drawing.Point(131, 131);
            this.checkBox_MMode.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox_MMode.Name = "checkBox_MMode";
            this.checkBox_MMode.Size = new System.Drawing.Size(122, 29);
            this.checkBox_MMode.TabIndex = 24;
            this.checkBox_MMode.Text = "M Mode";
            this.checkBox_MMode.UseVisualStyleBackColor = true;
            // 
            // listView_OffLineKiosks
            // 
            this.listView_OffLineKiosks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.KioskName,
            this.OffLineHours,
            this.Reason});
            this.listView_OffLineKiosks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_OffLineKiosks.Location = new System.Drawing.Point(12, 37);
            this.listView_OffLineKiosks.Margin = new System.Windows.Forms.Padding(6);
            this.listView_OffLineKiosks.Name = "listView_OffLineKiosks";
            this.listView_OffLineKiosks.Size = new System.Drawing.Size(974, 598);
            this.listView_OffLineKiosks.TabIndex = 27;
            this.listView_OffLineKiosks.UseCompatibleStateImageBehavior = false;
            // 
            // KioskName
            // 
            this.KioskName.Text = "Kiosk Name";
            this.KioskName.Width = 150;
            // 
            // OffLineHours
            // 
            this.OffLineHours.Text = "Hours";
            this.OffLineHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OffLineHours.Width = 50;
            // 
            // Reason
            // 
            this.Reason.Text = "Reason";
            this.Reason.Width = 500;
            // 
            // groupBox_OffLineKiosk
            // 
            this.groupBox_OffLineKiosk.Controls.Add(this.listView_OffLineKiosks);
            this.groupBox_OffLineKiosk.Location = new System.Drawing.Point(24, 1210);
            this.groupBox_OffLineKiosk.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_OffLineKiosk.Name = "groupBox_OffLineKiosk";
            this.groupBox_OffLineKiosk.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_OffLineKiosk.Size = new System.Drawing.Size(1002, 647);
            this.groupBox_OffLineKiosk.TabIndex = 29;
            this.groupBox_OffLineKiosk.TabStop = false;
            this.groupBox_OffLineKiosk.Text = "Off Line Kiosk";
            // 
            // OffLineListViewUpdate
            // 
            this.OffLineListViewUpdate.Enabled = true;
            this.OffLineListViewUpdate.Interval = 60000;
            this.OffLineListViewUpdate.Tick += new System.EventHandler(this.OffLineListViewUpdate_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(2736, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 37);
            this.label3.TabIndex = 25;
            this.label3.Text = "Key Indicators";
            // 
            // POPMail
            // 
            this.POPMail.Enabled = true;
            this.POPMail.Interval = 15000;
            this.POPMail.Tick += new System.EventHandler(this.POPMail_Tick);
            // 
            // textBox_POPMail
            // 
            this.textBox_POPMail.Location = new System.Drawing.Point(12, 33);
            this.textBox_POPMail.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_POPMail.Name = "textBox_POPMail";
            this.textBox_POPMail.Size = new System.Drawing.Size(1184, 31);
            this.textBox_POPMail.TabIndex = 30;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_POPMail);
            this.groupBox1.Controls.Add(this.textBox_ProgressInfo);
            this.groupBox1.Location = new System.Drawing.Point(2437, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(1212, 119);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mail Servers";
            // 
            // button_InportREMNOT
            // 
            this.button_InportREMNOT.Location = new System.Drawing.Point(1038, 17);
            this.button_InportREMNOT.Margin = new System.Windows.Forms.Padding(6);
            this.button_InportREMNOT.Name = "button_InportREMNOT";
            this.button_InportREMNOT.Size = new System.Drawing.Size(150, 44);
            this.button_InportREMNOT.TabIndex = 31;
            this.button_InportREMNOT.Text = "Import";
            this.button_InportREMNOT.UseVisualStyleBackColor = true;
            this.button_InportREMNOT.Click += new System.EventHandler(this.button_InportREMNOT_Click);
            // 
            // textBox_ImportStatus
            // 
            this.textBox_ImportStatus.Location = new System.Drawing.Point(1200, 21);
            this.textBox_ImportStatus.Margin = new System.Windows.Forms.Padding(6);
            this.textBox_ImportStatus.Name = "textBox_ImportStatus";
            this.textBox_ImportStatus.Size = new System.Drawing.Size(196, 31);
            this.textBox_ImportStatus.TabIndex = 32;
            // 
            // listView_Remedy
            // 
            this.listView_Remedy.Location = new System.Drawing.Point(12, 37);
            this.listView_Remedy.Margin = new System.Windows.Forms.Padding(6);
            this.listView_Remedy.Name = "listView_Remedy";
            this.listView_Remedy.Size = new System.Drawing.Size(778, 598);
            this.listView_Remedy.TabIndex = 33;
            this.listView_Remedy.UseCompatibleStateImageBehavior = false;
            // 
            // button_UpdateRemNot
            // 
            this.button_UpdateRemNot.Location = new System.Drawing.Point(1412, 17);
            this.button_UpdateRemNot.Margin = new System.Windows.Forms.Padding(6);
            this.button_UpdateRemNot.Name = "button_UpdateRemNot";
            this.button_UpdateRemNot.Size = new System.Drawing.Size(112, 44);
            this.button_UpdateRemNot.TabIndex = 35;
            this.button_UpdateRemNot.Text = "Update";
            this.button_UpdateRemNot.UseVisualStyleBackColor = true;
            this.button_UpdateRemNot.Click += new System.EventHandler(this.button_UpdateRemNot_Click);
            // 
            // groupBox_Remedy
            // 
            this.groupBox_Remedy.Controls.Add(this.listView_Remedy);
            this.groupBox_Remedy.Location = new System.Drawing.Point(2219, 1210);
            this.groupBox_Remedy.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_Remedy.Name = "groupBox_Remedy";
            this.groupBox_Remedy.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_Remedy.Size = new System.Drawing.Size(806, 647);
            this.groupBox_Remedy.TabIndex = 25;
            this.groupBox_Remedy.TabStop = false;
            this.groupBox_Remedy.Text = "Remedy  Last 7 Days";
            // 
            // groupBox_Notification
            // 
            this.groupBox_Notification.Controls.Add(this.listView_Notification);
            this.groupBox_Notification.Location = new System.Drawing.Point(3013, 1217);
            this.groupBox_Notification.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_Notification.Name = "groupBox_Notification";
            this.groupBox_Notification.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_Notification.Size = new System.Drawing.Size(806, 640);
            this.groupBox_Notification.TabIndex = 36;
            this.groupBox_Notification.TabStop = false;
            this.groupBox_Notification.Text = "Notifications  Last 7 Days";
            // 
            // listView_Notification
            // 
            this.listView_Notification.Location = new System.Drawing.Point(12, 37);
            this.listView_Notification.Margin = new System.Windows.Forms.Padding(6);
            this.listView_Notification.Name = "listView_Notification";
            this.listView_Notification.Size = new System.Drawing.Size(778, 589);
            this.listView_Notification.TabIndex = 33;
            this.listView_Notification.UseCompatibleStateImageBehavior = false;
            // 
            // timer_updateListView_Rem_Not
            // 
            this.timer_updateListView_Rem_Not.Enabled = true;
            this.timer_updateListView_Rem_Not.Interval = 60000;
            this.timer_updateListView_Rem_Not.Tick += new System.EventHandler(this.timer_updateListView_Rem_Not_Tick);
            // 
            // listView_AlertsKeyIndicator
            // 
            this.listView_AlertsKeyIndicator.ContextMenuStrip = this.contextMenuStrip_AlertManager;
            this.listView_AlertsKeyIndicator.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView_AlertsKeyIndicator.HoverSelection = true;
            this.listView_AlertsKeyIndicator.Location = new System.Drawing.Point(0, 27);
            this.listView_AlertsKeyIndicator.Margin = new System.Windows.Forms.Padding(6);
            this.listView_AlertsKeyIndicator.Name = "listView_AlertsKeyIndicator";
            this.listView_AlertsKeyIndicator.Size = new System.Drawing.Size(1435, 978);
            this.listView_AlertsKeyIndicator.TabIndex = 37;
            this.listView_AlertsKeyIndicator.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip_AlertManager
            // 
            this.contextMenuStrip_AlertManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAlertManagerToolStripMenuItem});
            this.contextMenuStrip_AlertManager.Name = "contextMenuStrip_AlertManager";
            this.contextMenuStrip_AlertManager.Size = new System.Drawing.Size(276, 40);
            this.contextMenuStrip_AlertManager.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_AlertManager_Opening);
            // 
            // editAlertManagerToolStripMenuItem
            // 
            this.editAlertManagerToolStripMenuItem.Name = "editAlertManagerToolStripMenuItem";
            this.editAlertManagerToolStripMenuItem.Size = new System.Drawing.Size(275, 36);
            this.editAlertManagerToolStripMenuItem.Text = "EditAlertManager";
            // 
            // groupBox_AlertManager
            // 
            this.groupBox_AlertManager.Controls.Add(this.listView_AlertsKeyIndicator);
            this.groupBox_AlertManager.Location = new System.Drawing.Point(2366, 187);
            this.groupBox_AlertManager.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_AlertManager.Name = "groupBox_AlertManager";
            this.groupBox_AlertManager.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_AlertManager.Size = new System.Drawing.Size(1453, 1018);
            this.groupBox_AlertManager.TabIndex = 38;
            this.groupBox_AlertManager.TabStop = false;
            this.groupBox_AlertManager.Text = "Alert Manager";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3658, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 35);
            this.button1.TabIndex = 39;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 69);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(645, 564);
            this.chart1.TabIndex = 40;
            this.chart1.Text = "chart1";
            // 
            // groupBox_UPTime
            // 
            this.groupBox_UPTime.Controls.Add(this.label4);
            this.groupBox_UPTime.Controls.Add(this.comboBox_UPTimeKioskSelect);
            this.groupBox_UPTime.Controls.Add(this.chart1);
            this.groupBox_UPTime.Location = new System.Drawing.Point(1553, 1210);
            this.groupBox_UPTime.Name = "groupBox_UPTime";
            this.groupBox_UPTime.Size = new System.Drawing.Size(657, 647);
            this.groupBox_UPTime.TabIndex = 41;
            this.groupBox_UPTime.TabStop = false;
            this.groupBox_UPTime.Text = "Minute By Minute Uptime for Estate. Last Update ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 25);
            this.label4.TabIndex = 42;
            this.label4.Text = "Select Kiosk";
            // 
            // comboBox_UPTimeKioskSelect
            // 
            this.comboBox_UPTimeKioskSelect.FormattingEnabled = true;
            this.comboBox_UPTimeKioskSelect.Location = new System.Drawing.Point(290, 25);
            this.comboBox_UPTimeKioskSelect.Name = "comboBox_UPTimeKioskSelect";
            this.comboBox_UPTimeKioskSelect.Size = new System.Drawing.Size(361, 33);
            this.comboBox_UPTimeKioskSelect.TabIndex = 41;
            this.comboBox_UPTimeKioskSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox_UPTimeKioskSelect_SelectedIndexChanged);
            // 
            // timer_UPTimeUpdate
            // 
            this.timer_UPTimeUpdate.Enabled = true;
            this.timer_UPTimeUpdate.Interval = 300000;
            this.timer_UPTimeUpdate.Tick += new System.EventHandler(this.timer_UPTimeUpdate_Tick);
            // 
            // groupBox_KioskAVEUPTime
            // 
            this.groupBox_KioskAVEUPTime.Controls.Add(this.listView_AVE_7_Day);
            this.groupBox_KioskAVEUPTime.Location = new System.Drawing.Point(1035, 1532);
            this.groupBox_KioskAVEUPTime.Name = "groupBox_KioskAVEUPTime";
            this.groupBox_KioskAVEUPTime.Size = new System.Drawing.Size(494, 325);
            this.groupBox_KioskAVEUPTime.TabIndex = 42;
            this.groupBox_KioskAVEUPTime.TabStop = false;
            this.groupBox_KioskAVEUPTime.Text = "Last 7 Days UpTime ";
            // 
            // listView_AVE_7_Day
            // 
            this.listView_AVE_7_Day.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_AVE_7_Day.Location = new System.Drawing.Point(9, 33);
            this.listView_AVE_7_Day.Margin = new System.Windows.Forms.Padding(6);
            this.listView_AVE_7_Day.Name = "listView_AVE_7_Day";
            this.listView_AVE_7_Day.Size = new System.Drawing.Size(486, 280);
            this.listView_AVE_7_Day.TabIndex = 25;
            this.listView_AVE_7_Day.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3828, 1915);
            this.Controls.Add(this.groupBox_KioskAVEUPTime);
            this.Controls.Add(this.groupBox_UPTime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox_AlertManager);
            this.Controls.Add(this.groupBox_Notification);
            this.Controls.Add(this.groupBox_Remedy);
            this.Controls.Add(this.button_UpdateRemNot);
            this.Controls.Add(this.textBox_ImportStatus);
            this.Controls.Add(this.button_InportREMNOT);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox_OffLineKiosk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_Alert);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.groupBox_DateSelect);
            this.Controls.Add(this.textBox_ListView);
            this.Controls.Add(this.listView_Main);
            this.Controls.Add(this.checkBox_KioskFilter);
            this.Controls.Add(this.comboBox_KioskList);
            this.Controls.Add(this.button_TriggerMail);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Error Detector Console Ver 1.42";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_DateSelect.ResumeLayout(false);
            this.groupBox_DateSelect.PerformLayout();
            this.groupBox_Alert.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox_OffLineKiosk.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_Remedy.ResumeLayout(false);
            this.groupBox_Notification.ResumeLayout(false);
            this.contextMenuStrip_AlertManager.ResumeLayout(false);
            this.groupBox_AlertManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox_UPTime.ResumeLayout(false);
            this.groupBox_UPTime.PerformLayout();
            this.groupBox_KioskAVEUPTime.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_TriggerMail;
        private System.Windows.Forms.TextBox textBox_ProgressInfo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBox_KioskList;
        private System.Windows.Forms.CheckBox checkBox_KioskFilter;
        private System.Windows.Forms.ListView listView_Main;
        private System.Windows.Forms.TextBox textBox_ListView;
        private System.Windows.Forms.GroupBox groupBox_DateSelect;
        private System.Windows.Forms.RadioButton radioButton_FromYesterday;
        private System.Windows.Forms.RadioButton radioButton_Date_Today;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DateStart;
        private System.Windows.Forms.RadioButton radioButton_Custom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DateEnd;
        private System.Windows.Forms.RadioButton radioButton_DateAll;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.DateTimePicker dateTimePicker_TimeStart;
        private System.Windows.Forms.DateTimePicker dateTimePicker_TimeEnd;
        private System.Windows.Forms.CheckBox checkBox_Notification;
        private System.Windows.Forms.CheckBox checkBox_Remedy;
        private System.Windows.Forms.CheckBox checkBox_CoinDispenser;
        private System.Windows.Forms.CheckBox checkBox_NoteDispenser;
        private System.Windows.Forms.Timer LoadAlertCounts;
        private System.Windows.Forms.Timer MainHouseKeeping;
        private System.Windows.Forms.ListView listView_AlertCounts;
        private System.Windows.Forms.GroupBox groupBox_Alert;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_MMode;
        private System.Windows.Forms.CheckBox checkBox_MModeON;
        private System.Windows.Forms.ListView listView_OffLineKiosks;
        private System.Windows.Forms.Button button_OnOffLine;
        private System.Windows.Forms.GroupBox groupBox_OffLineKiosk;
        private System.Windows.Forms.ColumnHeader KioskName;
        private System.Windows.Forms.ColumnHeader OffLineHours;
        private System.Windows.Forms.ColumnHeader Reason;
        private System.Windows.Forms.Timer OffLineListViewUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer POPMail;
        private System.Windows.Forms.TextBox textBox_POPMail;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_InportREMNOT;
        private System.Windows.Forms.TextBox textBox_ImportStatus;
        private System.Windows.Forms.ListView listView_Remedy;
        private System.Windows.Forms.Button button_UpdateRemNot;
        private System.Windows.Forms.GroupBox groupBox_Remedy;
        private System.Windows.Forms.GroupBox groupBox_Notification;
        private System.Windows.Forms.ListView listView_Notification;
        private System.Windows.Forms.Timer timer_updateListView_Rem_Not;
        private System.Windows.Forms.ListView listView_AlertsKeyIndicator;
        private System.Windows.Forms.GroupBox groupBox_AlertManager;
        private System.Windows.Forms.Button button_MaunualAlrest;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_AlertManager;
        private System.Windows.Forms.ToolStripMenuItem editAlertManagerToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_Alerts;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox_Failures_BV;
        private System.Windows.Forms.CheckBox checkBox_Failures_CD_EUR;
        private System.Windows.Forms.CheckBox checkBox_Failures_CD_GBP2;
        private System.Windows.Forms.CheckBox checkBox_Failures_CD_GBP1;
        private System.Windows.Forms.CheckBox checkBox_Failures_CD_USD;
        private System.Windows.Forms.CheckBox checkBox_Failures_ND_USD;
        private System.Windows.Forms.CheckBox checkBox_Failures_ND_EUR;
        private System.Windows.Forms.CheckBox checkBox_Failures_ND_GBP;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox_UPTime;
        private System.Windows.Forms.ComboBox comboBox_UPTimeKioskSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer_UPTimeUpdate;
        private System.Windows.Forms.GroupBox groupBox_KioskAVEUPTime;
        private System.Windows.Forms.ListView listView_AVE_7_Day;
    }
}

