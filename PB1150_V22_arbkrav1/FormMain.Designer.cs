
namespace PB1150_V22_arbkrav1
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comPortSelect = new System.Windows.Forms.ComboBox();
            this.bitRateSelect = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.sendDataTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.receiveButton = new System.Windows.Forms.Button();
            this.receivedDataTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageConnection = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioDisplayScaled = new System.Windows.Forms.RadioButton();
            this.radioDisplayRaw = new System.Windows.Forms.RadioButton();
            this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
            this.labelLiveRecordedData = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.manualReadButton = new System.Windows.Forms.Button();
            this.autoReadButton = new System.Windows.Forms.Button();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.buttonSaveConfig = new System.Windows.Forms.Button();
            this.buttonLoadConfig = new System.Windows.Forms.Button();
            this.buttonWriteConfig = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAH = new System.Windows.Forms.TextBox();
            this.textBoxAL = new System.Windows.Forms.TextBox();
            this.textBoxURV = new System.Windows.Forms.TextBox();
            this.textBoxLRV = new System.Windows.Forms.TextBox();
            this.textBoxTagname = new System.Windows.Forms.TextBox();
            this.buttonReadConfig = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timerDataRead = new System.Windows.Forms.Timer(this.components);
            this.timerBlink = new System.Windows.Forms.Timer(this.components);
            this.labelCurrentValue = new System.Windows.Forms.Label();
            this.labelConfigStatus = new System.Windows.Forms.Label();
            this.buttonSaveCSV = new System.Windows.Forms.Button();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonLoadData = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageConnection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPageConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Com port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bit rate:";
            // 
            // comPortSelect
            // 
            this.comPortSelect.FormattingEnabled = true;
            this.comPortSelect.Location = new System.Drawing.Point(57, 0);
            this.comPortSelect.Margin = new System.Windows.Forms.Padding(2);
            this.comPortSelect.Name = "comPortSelect";
            this.comPortSelect.Size = new System.Drawing.Size(81, 21);
            this.comPortSelect.Sorted = true;
            this.comPortSelect.TabIndex = 2;
            // 
            // bitRateSelect
            // 
            this.bitRateSelect.FormattingEnabled = true;
            this.bitRateSelect.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.bitRateSelect.Location = new System.Drawing.Point(57, 20);
            this.bitRateSelect.Margin = new System.Windows.Forms.Padding(2);
            this.bitRateSelect.Name = "bitRateSelect";
            this.bitRateSelect.Size = new System.Drawing.Size(81, 21);
            this.bitRateSelect.TabIndex = 3;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(57, 41);
            this.connectButton.Margin = new System.Windows.Forms.Padding(2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(79, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(57, 67);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(2);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(79, 22);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // sendDataTextBox
            // 
            this.sendDataTextBox.Location = new System.Drawing.Point(219, 2);
            this.sendDataTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.sendDataTextBox.Name = "sendDataTextBox";
            this.sendDataTextBox.Size = new System.Drawing.Size(178, 20);
            this.sendDataTextBox.TabIndex = 6;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(160, 3);
            this.sendButton.Margin = new System.Windows.Forms.Padding(2);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(56, 23);
            this.sendButton.TabIndex = 7;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // receiveButton
            // 
            this.receiveButton.Location = new System.Drawing.Point(160, 30);
            this.receiveButton.Margin = new System.Windows.Forms.Padding(2);
            this.receiveButton.Name = "receiveButton";
            this.receiveButton.Size = new System.Drawing.Size(56, 23);
            this.receiveButton.TabIndex = 8;
            this.receiveButton.Text = "Receive";
            this.receiveButton.UseVisualStyleBackColor = true;
            this.receiveButton.Click += new System.EventHandler(this.receiveButton_Click);
            // 
            // receivedDataTextBox
            // 
            this.receivedDataTextBox.Location = new System.Drawing.Point(219, 21);
            this.receivedDataTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.receivedDataTextBox.Multiline = true;
            this.receivedDataTextBox.Name = "receivedDataTextBox";
            this.receivedDataTextBox.ReadOnly = true;
            this.receivedDataTextBox.Size = new System.Drawing.Size(178, 170);
            this.receivedDataTextBox.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.statusStrip1.Size = new System.Drawing.Size(620, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageConnection);
            this.tabControlMain.Controls.Add(this.tabPageConfig);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(620, 536);
            this.tabControlMain.TabIndex = 11;
            // 
            // tabPageConnection
            // 
            this.tabPageConnection.Controls.Add(this.buttonLoadData);
            this.tabPageConnection.Controls.Add(this.buttonSaveImage);
            this.tabPageConnection.Controls.Add(this.buttonSaveCSV);
            this.tabPageConnection.Controls.Add(this.labelCurrentValue);
            this.tabPageConnection.Controls.Add(this.groupBox1);
            this.tabPageConnection.Controls.Add(this.pictureBoxStatus);
            this.tabPageConnection.Controls.Add(this.labelLiveRecordedData);
            this.tabPageConnection.Controls.Add(this.chart1);
            this.tabPageConnection.Controls.Add(this.manualReadButton);
            this.tabPageConnection.Controls.Add(this.autoReadButton);
            this.tabPageConnection.Controls.Add(this.disconnectButton);
            this.tabPageConnection.Controls.Add(this.connectButton);
            this.tabPageConnection.Controls.Add(this.sendDataTextBox);
            this.tabPageConnection.Controls.Add(this.receivedDataTextBox);
            this.tabPageConnection.Controls.Add(this.bitRateSelect);
            this.tabPageConnection.Controls.Add(this.sendButton);
            this.tabPageConnection.Controls.Add(this.receiveButton);
            this.tabPageConnection.Controls.Add(this.label2);
            this.tabPageConnection.Controls.Add(this.label1);
            this.tabPageConnection.Controls.Add(this.comPortSelect);
            this.tabPageConnection.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnection.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageConnection.Name = "tabPageConnection";
            this.tabPageConnection.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageConnection.Size = new System.Drawing.Size(612, 510);
            this.tabPageConnection.TabIndex = 0;
            this.tabPageConnection.Text = "Connection";
            this.tabPageConnection.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioDisplayScaled);
            this.groupBox1.Controls.Add(this.radioDisplayRaw);
            this.groupBox1.Location = new System.Drawing.Point(403, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 67);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display instrument data";
            // 
            // radioDisplayScaled
            // 
            this.radioDisplayScaled.AutoSize = true;
            this.radioDisplayScaled.Checked = true;
            this.radioDisplayScaled.Location = new System.Drawing.Point(6, 19);
            this.radioDisplayScaled.Name = "radioDisplayScaled";
            this.radioDisplayScaled.Size = new System.Drawing.Size(92, 17);
            this.radioDisplayScaled.TabIndex = 15;
            this.radioDisplayScaled.TabStop = true;
            this.radioDisplayScaled.Text = "Scaled values";
            this.radioDisplayScaled.UseVisualStyleBackColor = true;
            this.radioDisplayScaled.CheckedChanged += new System.EventHandler(this.radioDisplay_CheckedChanged);
            // 
            // radioDisplayRaw
            // 
            this.radioDisplayRaw.AutoSize = true;
            this.radioDisplayRaw.Location = new System.Drawing.Point(6, 41);
            this.radioDisplayRaw.Name = "radioDisplayRaw";
            this.radioDisplayRaw.Size = new System.Drawing.Size(81, 17);
            this.radioDisplayRaw.TabIndex = 16;
            this.radioDisplayRaw.Text = "Raw values";
            this.radioDisplayRaw.UseVisualStyleBackColor = true;
            this.radioDisplayRaw.CheckedChanged += new System.EventHandler(this.radioDisplay_CheckedChanged);
            // 
            // pictureBoxStatus
            // 
            this.pictureBoxStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStatus.Image")));
            this.pictureBoxStatus.Location = new System.Drawing.Point(170, 58);
            this.pictureBoxStatus.Name = "pictureBoxStatus";
            this.pictureBoxStatus.Size = new System.Drawing.Size(46, 87);
            this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStatus.TabIndex = 14;
            this.pictureBoxStatus.TabStop = false;
            // 
            // labelLiveRecordedData
            // 
            this.labelLiveRecordedData.AutoSize = true;
            this.labelLiveRecordedData.Location = new System.Drawing.Point(2, 210);
            this.labelLiveRecordedData.Name = "labelLiveRecordedData";
            this.labelLiveRecordedData.Size = new System.Drawing.Size(68, 13);
            this.labelLiveRecordedData.TabIndex = 13;
            this.labelLiveRecordedData.Text = "RECORDED";
            this.labelLiveRecordedData.Visible = false;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(8, 226);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Vba";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(596, 279);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // manualReadButton
            // 
            this.manualReadButton.Location = new System.Drawing.Point(310, 197);
            this.manualReadButton.Name = "manualReadButton";
            this.manualReadButton.Size = new System.Drawing.Size(87, 23);
            this.manualReadButton.TabIndex = 11;
            this.manualReadButton.Text = "Manual Read";
            this.manualReadButton.UseVisualStyleBackColor = true;
            this.manualReadButton.Click += new System.EventHandler(this.manualReadButton_Click);
            // 
            // autoReadButton
            // 
            this.autoReadButton.Location = new System.Drawing.Point(219, 197);
            this.autoReadButton.Name = "autoReadButton";
            this.autoReadButton.Size = new System.Drawing.Size(85, 23);
            this.autoReadButton.TabIndex = 10;
            this.autoReadButton.Text = "AutoRead";
            this.autoReadButton.UseVisualStyleBackColor = true;
            this.autoReadButton.Click += new System.EventHandler(this.autoReadButton_Click);
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.labelConfigStatus);
            this.tabPageConfig.Controls.Add(this.buttonSaveConfig);
            this.tabPageConfig.Controls.Add(this.buttonLoadConfig);
            this.tabPageConfig.Controls.Add(this.buttonWriteConfig);
            this.tabPageConfig.Controls.Add(this.label7);
            this.tabPageConfig.Controls.Add(this.label6);
            this.tabPageConfig.Controls.Add(this.label5);
            this.tabPageConfig.Controls.Add(this.label4);
            this.tabPageConfig.Controls.Add(this.textBoxAH);
            this.tabPageConfig.Controls.Add(this.textBoxAL);
            this.tabPageConfig.Controls.Add(this.textBoxURV);
            this.tabPageConfig.Controls.Add(this.textBoxLRV);
            this.tabPageConfig.Controls.Add(this.textBoxTagname);
            this.tabPageConfig.Controls.Add(this.buttonReadConfig);
            this.tabPageConfig.Controls.Add(this.label3);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageConfig.Size = new System.Drawing.Size(612, 510);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // buttonSaveConfig
            // 
            this.buttonSaveConfig.Location = new System.Drawing.Point(170, 124);
            this.buttonSaveConfig.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveConfig.Name = "buttonSaveConfig";
            this.buttonSaveConfig.Size = new System.Drawing.Size(68, 22);
            this.buttonSaveConfig.TabIndex = 13;
            this.buttonSaveConfig.Text = "Save";
            this.buttonSaveConfig.UseVisualStyleBackColor = true;
            this.buttonSaveConfig.Click += new System.EventHandler(this.buttonSaveConfig_Click);
            // 
            // buttonLoadConfig
            // 
            this.buttonLoadConfig.Location = new System.Drawing.Point(102, 124);
            this.buttonLoadConfig.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadConfig.Name = "buttonLoadConfig";
            this.buttonLoadConfig.Size = new System.Drawing.Size(64, 22);
            this.buttonLoadConfig.TabIndex = 12;
            this.buttonLoadConfig.Text = "Load";
            this.buttonLoadConfig.UseVisualStyleBackColor = true;
            this.buttonLoadConfig.Click += new System.EventHandler(this.buttonLoadConfig_Click);
            // 
            // buttonWriteConfig
            // 
            this.buttonWriteConfig.Location = new System.Drawing.Point(170, 98);
            this.buttonWriteConfig.Margin = new System.Windows.Forms.Padding(2);
            this.buttonWriteConfig.Name = "buttonWriteConfig";
            this.buttonWriteConfig.Size = new System.Drawing.Size(68, 22);
            this.buttonWriteConfig.TabIndex = 11;
            this.buttonWriteConfig.Text = "Write";
            this.buttonWriteConfig.UseVisualStyleBackColor = true;
            this.buttonWriteConfig.Click += new System.EventHandler(this.buttonWriteConfig_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 80);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Alarm high";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Alarm low";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Upper range value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Lower range value";
            // 
            // textBoxAH
            // 
            this.textBoxAH.Location = new System.Drawing.Point(102, 79);
            this.textBoxAH.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAH.Name = "textBoxAH";
            this.textBoxAH.Size = new System.Drawing.Size(136, 20);
            this.textBoxAH.TabIndex = 6;
            // 
            // textBoxAL
            // 
            this.textBoxAL.Location = new System.Drawing.Point(102, 59);
            this.textBoxAL.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAL.Name = "textBoxAL";
            this.textBoxAL.Size = new System.Drawing.Size(136, 20);
            this.textBoxAL.TabIndex = 5;
            // 
            // textBoxURV
            // 
            this.textBoxURV.Location = new System.Drawing.Point(102, 40);
            this.textBoxURV.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxURV.Name = "textBoxURV";
            this.textBoxURV.Size = new System.Drawing.Size(136, 20);
            this.textBoxURV.TabIndex = 4;
            // 
            // textBoxLRV
            // 
            this.textBoxLRV.Location = new System.Drawing.Point(102, 21);
            this.textBoxLRV.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLRV.Name = "textBoxLRV";
            this.textBoxLRV.Size = new System.Drawing.Size(136, 20);
            this.textBoxLRV.TabIndex = 3;
            // 
            // textBoxTagname
            // 
            this.textBoxTagname.Location = new System.Drawing.Point(102, 2);
            this.textBoxTagname.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTagname.Name = "textBoxTagname";
            this.textBoxTagname.Size = new System.Drawing.Size(136, 20);
            this.textBoxTagname.TabIndex = 2;
            // 
            // buttonReadConfig
            // 
            this.buttonReadConfig.Location = new System.Drawing.Point(102, 98);
            this.buttonReadConfig.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReadConfig.Name = "buttonReadConfig";
            this.buttonReadConfig.Size = new System.Drawing.Size(64, 22);
            this.buttonReadConfig.TabIndex = 1;
            this.buttonReadConfig.Text = "Read";
            this.buttonReadConfig.UseVisualStyleBackColor = true;
            this.buttonReadConfig.Click += new System.EventHandler(this.buttonReadConfig_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tagname";
            // 
            // timerDataRead
            // 
            this.timerDataRead.Interval = 2500;
            this.timerDataRead.Tick += new System.EventHandler(this.timerDataRead_Tick);
            // 
            // timerBlink
            // 
            this.timerBlink.Interval = 500;
            this.timerBlink.Tick += new System.EventHandler(this.timerBlink_Tick);
            // 
            // labelCurrentValue
            // 
            this.labelCurrentValue.AutoSize = true;
            this.labelCurrentValue.Location = new System.Drawing.Point(76, 210);
            this.labelCurrentValue.Name = "labelCurrentValue";
            this.labelCurrentValue.Size = new System.Drawing.Size(35, 13);
            this.labelCurrentValue.TabIndex = 18;
            this.labelCurrentValue.Text = "####";
            this.labelCurrentValue.Visible = false;
            // 
            // labelConfigStatus
            // 
            this.labelConfigStatus.AutoSize = true;
            this.labelConfigStatus.Location = new System.Drawing.Point(5, 154);
            this.labelConfigStatus.Name = "labelConfigStatus";
            this.labelConfigStatus.Size = new System.Drawing.Size(217, 13);
            this.labelConfigStatus.TabIndex = 14;
            this.labelConfigStatus.Text = "Instrument configuration written successfully.";
            this.labelConfigStatus.Visible = false;
            // 
            // buttonSaveCSV
            // 
            this.buttonSaveCSV.Enabled = false;
            this.buttonSaveCSV.Location = new System.Drawing.Point(403, 80);
            this.buttonSaveCSV.Name = "buttonSaveCSV";
            this.buttonSaveCSV.Size = new System.Drawing.Size(201, 23);
            this.buttonSaveCSV.TabIndex = 19;
            this.buttonSaveCSV.Text = "Save data as CSV";
            this.buttonSaveCSV.UseVisualStyleBackColor = true;
            this.buttonSaveCSV.Click += new System.EventHandler(this.buttonSaveCSV_Click);
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Enabled = false;
            this.buttonSaveImage.Location = new System.Drawing.Point(402, 109);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(201, 23);
            this.buttonSaveImage.TabIndex = 20;
            this.buttonSaveImage.Text = "Save graph as image";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // buttonLoadData
            // 
            this.buttonLoadData.Location = new System.Drawing.Point(402, 138);
            this.buttonLoadData.Name = "buttonLoadData";
            this.buttonLoadData.Size = new System.Drawing.Size(201, 23);
            this.buttonLoadData.TabIndex = 21;
            this.buttonLoadData.Text = "Load data from CSV";
            this.buttonLoadData.UseVisualStyleBackColor = true;
            this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 558);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoftSensConf";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageConnection.ResumeLayout(false);
            this.tabPageConnection.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPageConfig.ResumeLayout(false);
            this.tabPageConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comPortSelect;
        private System.Windows.Forms.ComboBox bitRateSelect;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox sendDataTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button receiveButton;
        private System.Windows.Forms.TextBox receivedDataTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageConnection;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TextBox textBoxTagname;
        private System.Windows.Forms.Button buttonReadConfig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAH;
        private System.Windows.Forms.TextBox textBoxAL;
        private System.Windows.Forms.TextBox textBoxURV;
        private System.Windows.Forms.TextBox textBoxLRV;
        private System.Windows.Forms.Button buttonLoadConfig;
        private System.Windows.Forms.Button buttonWriteConfig;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button autoReadButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button manualReadButton;
        private System.Windows.Forms.Timer timerDataRead;
        private System.Windows.Forms.Button buttonSaveConfig;
        private System.Windows.Forms.Label labelLiveRecordedData;
        private System.Windows.Forms.Timer timerBlink;
        private System.Windows.Forms.PictureBox pictureBoxStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioDisplayScaled;
        private System.Windows.Forms.RadioButton radioDisplayRaw;
        private System.Windows.Forms.Label labelCurrentValue;
        private System.Windows.Forms.Label labelConfigStatus;
        private System.Windows.Forms.Button buttonSaveCSV;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonLoadData;
    }
}

