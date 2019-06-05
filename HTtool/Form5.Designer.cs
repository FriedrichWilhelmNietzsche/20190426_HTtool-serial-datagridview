namespace HTtool
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelRcvCount = new System.Windows.Forms.Label();
            this.rbRcvStr = new System.Windows.Forms.RadioButton();
            this.rbRcvHex = new System.Windows.Forms.RadioButton();
            this.tbxRcvData = new System.Windows.Forms.TextBox();
            this.btnClearRcvCount = new System.Windows.Forms.Button();
            this.btnClearSend = new System.Windows.Forms.Button();
            this.btnClearSendCount = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelSendCount = new System.Windows.Forms.Label();
            this.rbSendStr = new System.Windows.Forms.RadioButton();
            this.rbSendHex = new System.Windows.Forms.RadioButton();
            this.tbxSendData = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timerSerial = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.otoolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.iODHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aWG监测仪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnHTProject = new System.Windows.Forms.ToolStripButton();
            this.tsbtnHelp = new System.Windows.Forms.ToolStripButton();
            this.tbxSendTime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.btnOpenCom = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbStop = new System.Windows.Forms.ComboBox();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClearRev = new System.Windows.Forms.Button();
            this.cbTimeSend = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSerial = new System.Windows.Forms.TabPage();
            this.gbxIODM = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PageIODM = new System.Windows.Forms.TabPage();
            this.cbIodmCmd = new System.Windows.Forms.ComboBox();
            this.btnTestRecord = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCleanRecord = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabControl2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageSerial.SuspendLayout();
            this.gbxIODM.SuspendLayout();
            this.PageIODM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl2.Controls.Add(this.PageIODM);
            this.tabControl2.ItemSize = new System.Drawing.Size(80, 18);
            this.tabControl2.Location = new System.Drawing.Point(588, 7);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(323, 560);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelRcvCount);
            this.groupBox3.Controls.Add(this.rbRcvStr);
            this.groupBox3.Controls.Add(this.rbRcvHex);
            this.groupBox3.Controls.Add(this.tbxRcvData);
            this.groupBox3.Location = new System.Drawing.Point(202, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(368, 342);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据接收区";
            // 
            // labelRcvCount
            // 
            this.labelRcvCount.AutoSize = true;
            this.labelRcvCount.Location = new System.Drawing.Point(227, 21);
            this.labelRcvCount.Name = "labelRcvCount";
            this.labelRcvCount.Size = new System.Drawing.Size(11, 12);
            this.labelRcvCount.TabIndex = 5;
            this.labelRcvCount.Text = "0";
            // 
            // rbRcvStr
            // 
            this.rbRcvStr.AutoSize = true;
            this.rbRcvStr.Location = new System.Drawing.Point(104, 19);
            this.rbRcvStr.Name = "rbRcvStr";
            this.rbRcvStr.Size = new System.Drawing.Size(83, 16);
            this.rbRcvStr.TabIndex = 3;
            this.rbRcvStr.TabStop = true;
            this.rbRcvStr.Text = "字符串显示";
            this.rbRcvStr.UseVisualStyleBackColor = true;
            // 
            // rbRcvHex
            // 
            this.rbRcvHex.AutoSize = true;
            this.rbRcvHex.Location = new System.Drawing.Point(36, 19);
            this.rbRcvHex.Name = "rbRcvHex";
            this.rbRcvHex.Size = new System.Drawing.Size(65, 16);
            this.rbRcvHex.TabIndex = 2;
            this.rbRcvHex.TabStop = true;
            this.rbRcvHex.Text = "Hex显示";
            this.rbRcvHex.UseVisualStyleBackColor = true;
            // 
            // tbxRcvData
            // 
            this.tbxRcvData.Location = new System.Drawing.Point(6, 36);
            this.tbxRcvData.Multiline = true;
            this.tbxRcvData.Name = "tbxRcvData";
            this.tbxRcvData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxRcvData.Size = new System.Drawing.Size(356, 300);
            this.tbxRcvData.TabIndex = 0;
            this.tbxRcvData.Text = "欢迎使用HTtool串口调试助手！";
            // 
            // btnClearRcvCount
            // 
            this.btnClearRcvCount.Location = new System.Drawing.Point(6, 94);
            this.btnClearRcvCount.Name = "btnClearRcvCount";
            this.btnClearRcvCount.Size = new System.Drawing.Size(87, 23);
            this.btnClearRcvCount.TabIndex = 6;
            this.btnClearRcvCount.Text = "接收计数清零";
            this.btnClearRcvCount.UseVisualStyleBackColor = true;
            this.btnClearRcvCount.Click += new System.EventHandler(this.btnClearRcvCount_Click);
            // 
            // btnClearSend
            // 
            this.btnClearSend.Location = new System.Drawing.Point(99, 123);
            this.btnClearSend.Name = "btnClearSend";
            this.btnClearSend.Size = new System.Drawing.Size(75, 23);
            this.btnClearSend.TabIndex = 8;
            this.btnClearSend.Text = "清空发送区";
            this.btnClearSend.UseVisualStyleBackColor = true;
            this.btnClearSend.Click += new System.EventHandler(this.btnClearSend_Click);
            // 
            // btnClearSendCount
            // 
            this.btnClearSendCount.Location = new System.Drawing.Point(8, 123);
            this.btnClearSendCount.Name = "btnClearSendCount";
            this.btnClearSendCount.Size = new System.Drawing.Size(85, 23);
            this.btnClearSendCount.TabIndex = 5;
            this.btnClearSendCount.Text = "发送计数清零";
            this.btnClearSendCount.UseVisualStyleBackColor = true;
            this.btnClearSendCount.Click += new System.EventHandler(this.btnClearSendCount_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(99, 173);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "手动发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(127, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "ms";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelSendCount);
            this.groupBox4.Controls.Add(this.rbSendStr);
            this.groupBox4.Controls.Add(this.rbSendHex);
            this.groupBox4.Controls.Add(this.tbxSendData);
            this.groupBox4.Location = new System.Drawing.Point(202, 345);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(365, 159);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "数据发送区";
            // 
            // labelSendCount
            // 
            this.labelSendCount.AutoSize = true;
            this.labelSendCount.Location = new System.Drawing.Point(224, 22);
            this.labelSendCount.Name = "labelSendCount";
            this.labelSendCount.Size = new System.Drawing.Size(11, 12);
            this.labelSendCount.TabIndex = 7;
            this.labelSendCount.Text = "0";
            // 
            // rbSendStr
            // 
            this.rbSendStr.AutoSize = true;
            this.rbSendStr.Location = new System.Drawing.Point(101, 20);
            this.rbSendStr.Name = "rbSendStr";
            this.rbSendStr.Size = new System.Drawing.Size(83, 16);
            this.rbSendStr.TabIndex = 4;
            this.rbSendStr.TabStop = true;
            this.rbSendStr.Text = "字符串发送";
            this.rbSendStr.UseVisualStyleBackColor = true;
            // 
            // rbSendHex
            // 
            this.rbSendHex.AutoSize = true;
            this.rbSendHex.Location = new System.Drawing.Point(33, 20);
            this.rbSendHex.Name = "rbSendHex";
            this.rbSendHex.Size = new System.Drawing.Size(65, 16);
            this.rbSendHex.TabIndex = 3;
            this.rbSendHex.TabStop = true;
            this.rbSendHex.Text = "Hex发送";
            this.rbSendHex.UseVisualStyleBackColor = true;
            // 
            // tbxSendData
            // 
            this.tbxSendData.Location = new System.Drawing.Point(3, 42);
            this.tbxSendData.Multiline = true;
            this.tbxSendData.Name = "tbxSendData";
            this.tbxSendData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxSendData.Size = new System.Drawing.Size(356, 111);
            this.tbxSendData.TabIndex = 0;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Sp_DataReceived);
            // 
            // timerSerial
            // 
            this.timerSerial.Tick += new System.EventHandler(this.timerSerial_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otoolStripDropDownButton1,
            this.tsbtnHTProject,
            this.tsbtnHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(924, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // otoolStripDropDownButton1
            // 
            this.otoolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.otoolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iODHToolStripMenuItem,
            this.aWG监测仪ToolStripMenuItem});
            this.otoolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("otoolStripDropDownButton1.Image")));
            this.otoolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.otoolStripDropDownButton1.Name = "otoolStripDropDownButton1";
            this.otoolStripDropDownButton1.Size = new System.Drawing.Size(57, 22);
            this.otoolStripDropDownButton1.Text = "待使用";
            // 
            // iODHToolStripMenuItem
            // 
            this.iODHToolStripMenuItem.Name = "iODHToolStripMenuItem";
            this.iODHToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iODHToolStripMenuItem.Text = "主界面";
            // 
            // aWG监测仪ToolStripMenuItem
            // 
            this.aWG监测仪ToolStripMenuItem.Name = "aWG监测仪ToolStripMenuItem";
            this.aWG监测仪ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aWG监测仪ToolStripMenuItem.Text = "AWG监测仪";
            // 
            // tsbtnHTProject
            // 
            this.tsbtnHTProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnHTProject.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnHTProject.Image")));
            this.tsbtnHTProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHTProject.Name = "tsbtnHTProject";
            this.tsbtnHTProject.Size = new System.Drawing.Size(60, 22);
            this.tsbtnHTProject.Text = "项目拓展";
            this.tsbtnHTProject.Click += new System.EventHandler(this.tsbtnHTProject_Click);
            // 
            // tsbtnHelp
            // 
            this.tsbtnHelp.AutoSize = false;
            this.tsbtnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnHelp.Image")));
            this.tsbtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHelp.Name = "tsbtnHelp";
            this.tsbtnHelp.Size = new System.Drawing.Size(60, 22);
            this.tsbtnHelp.Text = "帮助";
            this.tsbtnHelp.Click += new System.EventHandler(this.tsbtnHelp_Click);
            // 
            // tbxSendTime
            // 
            this.tbxSendTime.Location = new System.Drawing.Point(68, 42);
            this.tbxSendTime.Name = "tbxSendTime";
            this.tbxSendTime.Size = new System.Drawing.Size(53, 21);
            this.tbxSendTime.TabIndex = 2;
            this.tbxSendTime.Text = "1000";
            this.tbxSendTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSendTime_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbParity);
            this.groupBox1.Controls.Add(this.btnOpenCom);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.cbStop);
            this.groupBox1.Controls.Add(this.cbDataBits);
            this.groupBox1.Controls.Add(this.cbBaudRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbPortName);
            this.groupBox1.Location = new System.Drawing.Point(6, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "校验位";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(81, 152);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 9;
            this.btnCheck.Text = "串口检测";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "停止位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "数据位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "波特率";
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(6, 119);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(81, 20);
            this.cbParity.TabIndex = 5;
            this.cbParity.SelectedIndexChanged += new System.EventHandler(this.cbParity_SelectedIndexChanged);
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Location = new System.Drawing.Point(81, 181);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCom.TabIndex = 2;
            this.btnOpenCom.Text = "打开串口";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.btnOpenCom_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HTtool.Properties.Resources.红点;
            this.pictureBox1.Location = new System.Drawing.Point(8, 155);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 39);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // cbStop
            // 
            this.cbStop.FormattingEnabled = true;
            this.cbStop.Location = new System.Drawing.Point(6, 93);
            this.cbStop.Name = "cbStop";
            this.cbStop.Size = new System.Drawing.Size(81, 20);
            this.cbStop.TabIndex = 4;
            this.cbStop.SelectedIndexChanged += new System.EventHandler(this.cbStop_SelectedIndexChanged);
            // 
            // cbDataBits
            // 
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Location = new System.Drawing.Point(6, 67);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(81, 20);
            this.cbDataBits.TabIndex = 3;
            this.cbDataBits.SelectedIndexChanged += new System.EventHandler(this.cbDataBits_SelectedIndexChanged);
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Location = new System.Drawing.Point(6, 41);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(81, 20);
            this.cbBaudRate.TabIndex = 2;
            this.cbBaudRate.SelectedIndexChanged += new System.EventHandler(this.cbBaudRate_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "端口";
            // 
            // cbPortName
            // 
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(6, 15);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(81, 20);
            this.cbPortName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "时间间隔：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClearRcvCount);
            this.groupBox2.Controls.Add(this.btnClearSend);
            this.groupBox2.Controls.Add(this.btnClearSendCount);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbxSendTime);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnClearRev);
            this.groupBox2.Controls.Add(this.cbTimeSend);
            this.groupBox2.Location = new System.Drawing.Point(6, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 285);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作区";
            // 
            // btnClearRev
            // 
            this.btnClearRev.Location = new System.Drawing.Point(99, 94);
            this.btnClearRev.Name = "btnClearRev";
            this.btnClearRev.Size = new System.Drawing.Size(75, 23);
            this.btnClearRev.TabIndex = 4;
            this.btnClearRev.Text = "清空接收区";
            this.btnClearRev.UseVisualStyleBackColor = true;
            this.btnClearRev.Click += new System.EventHandler(this.btnClearRev_Click);
            // 
            // cbTimeSend
            // 
            this.cbTimeSend.AutoSize = true;
            this.cbTimeSend.Location = new System.Drawing.Point(6, 20);
            this.cbTimeSend.Name = "cbTimeSend";
            this.cbTimeSend.Size = new System.Drawing.Size(72, 16);
            this.cbTimeSend.TabIndex = 0;
            this.cbTimeSend.Text = "定时发送";
            this.cbTimeSend.UseVisualStyleBackColor = true;
            this.cbTimeSend.CheckedChanged += new System.EventHandler(this.cbTimeSend_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPageSerial);
            this.tabControl1.ItemSize = new System.Drawing.Size(80, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 543);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 14;
            // 
            // tabPageSerial
            // 
            this.tabPageSerial.Controls.Add(this.groupBox3);
            this.tabPageSerial.Controls.Add(this.groupBox4);
            this.tabPageSerial.Controls.Add(this.groupBox1);
            this.tabPageSerial.Controls.Add(this.groupBox2);
            this.tabPageSerial.Location = new System.Drawing.Point(4, 22);
            this.tabPageSerial.Name = "tabPageSerial";
            this.tabPageSerial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSerial.Size = new System.Drawing.Size(574, 517);
            this.tabPageSerial.TabIndex = 0;
            this.tabPageSerial.Text = "串口调试";
            this.tabPageSerial.UseVisualStyleBackColor = true;
            // 
            // gbxIODM
            // 
            this.gbxIODM.Controls.Add(this.btnExport);
            this.gbxIODM.Controls.Add(this.btnCleanRecord);
            this.gbxIODM.Controls.Add(this.dataGridView1);
            this.gbxIODM.Controls.Add(this.btnTestRecord);
            this.gbxIODM.Controls.Add(this.cbIodmCmd);
            this.gbxIODM.Controls.Add(this.label8);
            this.gbxIODM.Location = new System.Drawing.Point(-4, 0);
            this.gbxIODM.Name = "gbxIODM";
            this.gbxIODM.Size = new System.Drawing.Size(304, 534);
            this.gbxIODM.TabIndex = 11;
            this.gbxIODM.TabStop = false;
            this.gbxIODM.Text = "IODM";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "调试指令：";
            // 
            // PageIODM
            // 
            this.PageIODM.Controls.Add(this.gbxIODM);
            this.PageIODM.Location = new System.Drawing.Point(4, 22);
            this.PageIODM.Name = "PageIODM";
            this.PageIODM.Padding = new System.Windows.Forms.Padding(3);
            this.PageIODM.Size = new System.Drawing.Size(315, 534);
            this.PageIODM.TabIndex = 1;
            this.PageIODM.Text = "电子门禁测试";
            this.PageIODM.UseVisualStyleBackColor = true;
            // 
            // cbIodmCmd
            // 
            this.cbIodmCmd.FormattingEnabled = true;
            this.cbIodmCmd.Location = new System.Drawing.Point(81, 40);
            this.cbIodmCmd.Name = "cbIodmCmd";
            this.cbIodmCmd.Size = new System.Drawing.Size(206, 20);
            this.cbIodmCmd.TabIndex = 10;
            // 
            // btnTestRecord
            // 
            this.btnTestRecord.Location = new System.Drawing.Point(12, 89);
            this.btnTestRecord.Name = "btnTestRecord";
            this.btnTestRecord.Size = new System.Drawing.Size(99, 23);
            this.btnTestRecord.TabIndex = 11;
            this.btnTestRecord.Text = "测试记录添加";
            this.btnTestRecord.UseVisualStyleBackColor = true;
            this.btnTestRecord.Click += new System.EventHandler(this.btnTestRecord_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(275, 240);
            this.dataGridView1.TabIndex = 12;
            // 
            // btnCleanRecord
            // 
            this.btnCleanRecord.Location = new System.Drawing.Point(175, 89);
            this.btnCleanRecord.Name = "btnCleanRecord";
            this.btnCleanRecord.Size = new System.Drawing.Size(99, 23);
            this.btnCleanRecord.TabIndex = 13;
            this.btnCleanRecord.Text = "记录清空";
            this.btnCleanRecord.UseVisualStyleBackColor = true;
            this.btnCleanRecord.Click += new System.EventHandler(this.btnCleanRecord_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 386);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 23);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "测试记录导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 571);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5";
            this.Text = "HTtool";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.tabControl2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSerial.ResumeLayout(false);
            this.gbxIODM.ResumeLayout(false);
            this.gbxIODM.PerformLayout();
            this.PageIODM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelRcvCount;
        private System.Windows.Forms.RadioButton rbRcvStr;
        private System.Windows.Forms.RadioButton rbRcvHex;
        private System.Windows.Forms.TextBox tbxRcvData;
        private System.Windows.Forms.Button btnClearRcvCount;
        private System.Windows.Forms.Button btnClearSend;
        private System.Windows.Forms.Button btnClearSendCount;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelSendCount;
        private System.Windows.Forms.RadioButton rbSendStr;
        private System.Windows.Forms.RadioButton rbSendHex;
        private System.Windows.Forms.TextBox tbxSendData;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timerSerial;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton otoolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem iODHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aWG监测仪ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbtnHTProject;
        private System.Windows.Forms.ToolStripButton tsbtnHelp;
        private System.Windows.Forms.TextBox tbxSendTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Button btnOpenCom;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbStop;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClearRev;
        private System.Windows.Forms.CheckBox cbTimeSend;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSerial;
        private System.Windows.Forms.TabPage PageIODM;
        private System.Windows.Forms.GroupBox gbxIODM;
        private System.Windows.Forms.Button btnTestRecord;
        private System.Windows.Forms.ComboBox cbIodmCmd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCleanRecord;
        private System.Windows.Forms.Button btnExport;
    }
}