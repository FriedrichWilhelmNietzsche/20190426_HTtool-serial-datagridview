using System;
using System.Collections; //使用队列需要
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; //串口调试用
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets; //网络调试用
using System.Threading; //线程


namespace HTtool
{
    public partial class Form5 : Form
    {
        #region 全局参数
        private SerialPort sp = new SerialPort(); //声明一个串口类
        private StringBuilder Rev_builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。
        private StringBuilder Send_builder = new StringBuilder();
        private long received_count = 0;//接收计数  
        private long send_count = 0;//发送计数

        //串口发送接收多线程使用
        private Queue<string> SerialSendQueue; // 串口发送命令队列
        private List<byte> SerialRevList;      // 串口接收数据集合
        private ManualResetEvent SerialSendWaiter;// 串口发送线程启动信号
        private ManualResetEvent SerialRevWaiter; // 串口接收数据处理线程启动信号

        //DataTable
        private DataTable dt = new DataTable();

        #endregion

        #region 窗口登录
        public Form5()
        {
            InitializeComponent();//窗口初始化
            CheckForIllegalCrossThreadCalls = false; //屏蔽多线程调用同一控件时出现的异常
        }
        #endregion

        #region 窗口登录初始化
        private void Form5_Load(object sender, EventArgs e)
        {
            //this.MaximumSize = this.Size;
            //this.MinimumSize = this.Size;
            //this.MinimizeBox = false;//是否显示最小化按钮
            this.MaximizeBox = false;//禁止最大化

            this.Width = 600;

            //初始化下拉串口名称列表框
            string[] ports = SerialPort.GetPortNames();//检索当前的计算机的有效端口
            Array.Sort(ports);//数组排序
            //Array.Reverse(ports);//方法，反转，要降序则添加这一局
            cbPortName.Items.AddRange(ports);//将数组添加到combox列表
            cbPortName.SelectedIndex = cbPortName.Items.Count > 0 ? 0 : -1;

            //列出常用波特率,根据需求添加
            cbBaudRate.Items.Add("1200");
            cbBaudRate.Items.Add("2400");
            cbBaudRate.Items.Add("4800");
            cbBaudRate.Items.Add("9600");
            cbBaudRate.Items.Add("19200");
            cbBaudRate.Items.Add("38400");
            cbBaudRate.Items.Add("57600");
            cbBaudRate.Items.Add("115200");
            cbBaudRate.Items.Add("230400");
            cbBaudRate.SelectedIndex = 7;//默认使用115200
            //列出停止位
            cbStop.Items.Add("0");
            cbStop.Items.Add("1");
            cbStop.Items.Add("1.5");
            cbStop.Items.Add("2");
            cbStop.SelectedIndex = 1;//默认使用1个停止位
            //列出数据位
            cbDataBits.Items.Add("8");
            cbDataBits.Items.Add("7");
            cbDataBits.Items.Add("6");
            cbDataBits.Items.Add("5");
            cbDataBits.SelectedIndex = 0;//默认使用8数据位
            //列出奇偶校验位
            cbParity.Items.Add("无");
            cbParity.Items.Add("奇校验");
            cbParity.Items.Add("偶校验");
            cbParity.SelectedIndex = 0;//默认使用8数据位

            rbRcvStr.Checked = true;//默认字符串显示
            rbSendStr.Checked = true;//默认字符串发送
            btnOpenCom.Text = "打开串口";
            labelSendCount.Text = "发送字节数:0"; //发送计数初始
            labelRcvCount.Text = "发送字节数:0"; //接收计数初始
            tbxSendTime.Text = "1000"; //默认定时时间1000ms
            tbxRcvData.ReadOnly = true; //设置接收文本框只读
            //pictureBox1.BackColor= System.Drawing.Color.Red;
            pictureBox1.BackgroundImage = Properties.Resources.红点; //未打开：红点  打开：绿点
            btnSend.Enabled = false; //发送按钮跟随串口打开状态
            cbTimeSend.Enabled = false; //未打开串口，禁止定时发送

            //tabControl1.Parent = null;//隐藏tabControl1

            //串口收发多线程
            this.SerialSendQueue = new Queue<string>();//创建串口发送队列
            this.SerialRevList = new List<byte>();//创建串口接受数据list
            this.SerialSendWaiter = new ManualResetEvent(false);
            this.SerialRevWaiter = new ManualResetEvent(false);
            ThreadPool.SetMaxThreads(1000, 1000);
            //串口命令发送线程，使用线程池开销较小
            ThreadPool.QueueUserWorkItem(new WaitCallback(SerialSend));
            //串口数据处理线程
            ThreadPool.QueueUserWorkItem(new WaitCallback(SerialRev));
            //测试用
            this.SerialSendQueue.Clear(); //发送命令队列清空
            this.SerialSendWaiter.Set();  //启动串口发送线程
            this.SerialRevWaiter.Set();   //启动串口接收线程

            //数据记录
            InitDatable();
        }
        #endregion

        #region 串口调试部分
        #region 串口检测btnCheck_Click
        private void btnCheck_Click(object sender, EventArgs e) //检查哪些可用串口
        {
            bool comExist = false;//有可用串口标志位
            cbPortName.Items.Clear();//清除当前串口号中的所有串口名称
            for (int i = 0; i < 20; i++)//扫描可用串口，串口支持数量根据自己需求更改
            {
                try
                {
                    SerialPort sp = new SerialPort("COM" + (i + 1).ToString());
                    sp.Open();
                    sp.Close();
                    cbPortName.Items.Add("COM" + (i + 1).ToString());
                    comExist = true;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            if (comExist)
            {
                cbPortName.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("没有找到可以串口！", "错误提示");
            }
        }
        #endregion

        #region 检查串口参数是否非法CheckPortSetting
        private bool CheckPortSetting()//检查串口参数是否非法
        {
            if (cbPortName.Text.Trim() == "") return false;
            if (cbBaudRate.Text.Trim() == "") return false;
            if (cbStop.Text.Trim() == "") return false;
            if (cbDataBits.Text.Trim() == "") return false;
            if (cbParity.Text.Trim() == "") return false;
            return true;
        }
        #endregion

        #region 检查串口发送数据是否为空
        private bool CheckSendData()//检查串口发送是否为空
        {
            if (tbxSendData.Text.Trim() == "") return false;
            return true;
        }
        #endregion

        #region 设置串口的属性SetPortProperty
        private void SetPortProperty()//设置串口的属性
        {
            sp = new SerialPort
            {
                PortName = cbPortName.Text.Trim(), //设置串口名
                //BaudRate = Convert.ToInt32(cbBaudRate.Text.Trim()) //设置串口波特率
                BaudRate = int.Parse(cbBaudRate.Text.Trim())
            };
            float f = Convert.ToSingle(cbStop.Text.Trim());//设置停止位
            if (f == 0)
            {
                sp.StopBits = StopBits.None;
            }
            else if (f == 1.5)
            {
                sp.StopBits = StopBits.OnePointFive;
            }
            else if (f == 1)
            {
                sp.StopBits = StopBits.One;
            }
            else if (f == 2)
            {
                sp.StopBits = StopBits.Two;
            }
            else
            {
                sp.StopBits = StopBits.One;
            }
            sp.DataBits = Convert.ToInt16(cbDataBits.Text.Trim());//设置数据位

            string s = cbParity.Text.Trim();//设置奇偶校验位
            if (s.CompareTo("无") == 0)
            {
                sp.Parity = Parity.None;
            }
            else if (s.CompareTo("奇校验") == 0)
            {
                sp.Parity = Parity.Odd;
            }
            else if (s.CompareTo("偶校验") == 0)
            {
                sp.Parity = Parity.Even;
            }
            else
            {
                sp.Parity = Parity.None;
            }
            sp.ReadTimeout = -1; //设置超市读取时间
            //sp.NewLine = "/r/n"; //根据实际情况吧，当使用ReadLine()时需要定义一下
            //sp.RtsEnable = true; //启用RTS发送请求信号，根据实际情况吧

            //定义串口DataReceived事件，当串口接受到数据后触发事件
            sp.DataReceived += Sp_DataReceived; //添加事件注册
        }
        #endregion

        //#region 串口接受事件Sp_DataReceived
        //private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)//串口接受事件
        //{
        //    int n = sp.BytesToRead;//获取接收缓冲区中数据的字节数，先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
        //    byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据
        //    received_count += n;//增加接收计数
        //    sp.Read(buf, 0, n);//读取缓冲数据  
        //    Rev_builder.Clear();//清除字符串构造器的内容

        //    //System.Threading.Thread.Sleep(100);//延时100ms等待接受完数据
        //    //因为要访问ui资源，所以需要使用invoke方式同步ui，串口接收事件会自动创建线程，多线程访问控件需要使用invoke来委托
        //    this.Invoke((EventHandler)(delegate
        //    {
        //        if (rbRcvHex.Checked == false)//接受数据字符串显示
        //        {
        //            //tbxRcvData.Text += sp.ReadLine(); //一直读取到输入缓冲区中的 NewLine 值，使用这个需要注意换行符
        //            //直接按ASCII规则转换成字符串  
        //            Rev_builder.Append(Encoding.Default.GetString(buf));
        //        }
        //        else//接受数据Hex显示
        //        {
        //            //依次的拼接出16进制字符串  
        //            foreach (byte b in buf)
        //            {
        //                Rev_builder.Append(b.ToString("X2") + " ");
        //            }
        //        }
        //        this.tbxRcvData.AppendText(Rev_builder.ToString());//接受数据显示在文本框
        //        labelRcvCount.Text = "接收字节数:" + received_count.ToString();//修改接收计数
        //        sp.DiscardInBuffer();//丢弃接受缓冲区数据
        //    }));
        //}
        //#endregion

        #region 串口接受事件Sp_DataReceived
        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)//串口接受事件
        {
            try
            {
                if (this.sp.BytesToRead > 0)
                {
                    byte[] buffer = new byte[this.sp.BytesToRead];
                    this.sp.Read(buffer, 0, buffer.Length);
                    received_count += buffer.Length;//增加接收计数
                    Rev_builder.Clear();//清除字符串构造器的内容
                    //因为要访问ui资源，所以需要使用invoke方式同步ui，串口接收事件会自动创建线程，多线程访问控件需要使用invoke来委托
                    this.Invoke((EventHandler)(delegate
                    {
                        if (rbRcvHex.Checked == false)//接受数据字符串显示
                        {
                            //tbxRcvData.Text += sp.ReadLine(); //一直读取到输入缓冲区中的 NewLine 值，使用这个需要注意换行符
                            //直接按ASCII规则转换成字符串  
                            Rev_builder.Append(Encoding.Default.GetString(buffer));
                        }
                        else//接受数据Hex显示
                        {
                            //依次的拼接出16进制字符串  
                            foreach (byte b in buffer)
                            {
                                Rev_builder.Append(b.ToString("X2") + " ");
                            }
                        }
                        this.tbxRcvData.AppendText(Rev_builder.ToString());//接受数据显示在文本框
                        labelRcvCount.Text = "接收字节数:" + received_count.ToString();//修改接收计数
                        sp.DiscardInBuffer();//丢弃接受缓冲区数据
                    }));

                    Monitor.Enter(this.SerialRevList);   //数据保护
                    this.SerialRevList.AddRange(buffer); //交由接收处理线程处理
                    Monitor.Exit(this.SerialRevList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 串口发送数据线程函数
        /// <summary>
        /// 这个线程函数负责发送串口命令
        /// </summary>
        /// <param name="obj"></param>
        private void SerialSend(object obj)
        {
            while (true)
            {
                try
                {
                    this.SerialSendWaiter.WaitOne();
                    Monitor.Enter(this.SerialSendQueue); //队列排他锁，实现同步访问
                    string buf = null;
                    if (this.SerialSendQueue.Count > 0) //有命令
                    {
                        buf = this.SerialSendQueue.Dequeue(); //取出发送队列第一个命令
                    }
                    if (buf != null)
                    {
                        byte[] buffer = Encoding.Default.GetBytes(buf);
                        this.sp.DiscardInBuffer();
                        this.sp.Write(buffer, 0, buffer.Length);

                        tbxSendData.AppendText(buf + "\r\n");
                        send_count += buf.Length;
                        labelSendCount.Text = "发送字节数:" + send_count.ToString();//更新发送计数
                    }
                    Monitor.Exit(this.SerialSendQueue); //释放锁
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region 串口接受缓存数据处理线程函数
        /// <summary>
        /// 串口接受缓存数据处理线程函数
        /// </summary>
        /// <param name="obj"></param>
        private void SerialRev(object obj)
        {
            while (true)
            {
                try
                {
                    this.SerialRevWaiter.WaitOne();
                    Monitor.Enter(this.SerialRevList);

                    //AWGM.AWGHandle(SerialRevData);
                    //至少包含帧头（1字节）+长度（2字节）+数据 + 结束位（1字节）
                    if (this.SerialRevList.Count > 0) //接收缓存有数据
                    {
                        //AWG接收字符串协议处理方式
                        string str = Encoding.Default.GetString(SerialRevList.ToArray());
                        if (str.Substring(0, 1) == "*")  //起始位
                        {
                            int len = Convert.ToInt32(str.Substring(1, 2));
                            if (SerialRevList.Count < len + 4)//未接收完整
                            {
                                break;
                            }
                            else
                            {
                                if (str.Substring(len + 3, 1) == "^")//结束位
                                {
                                    //lineyValue1 = Convert.ToDouble(str.Substring(3, 5));
                                    //lineyValue2 = Convert.ToDouble(str.Substring(8, 5));

                                    //多线程访问控件使用invoke来委托
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tbxRcvData.AppendText(str);
                                        //tbxAWGMTem.Text = str.Substring(3, 5);
                                    }));
                                }

                            }
                            SerialRevList.RemoveRange(0, len + 4);//去掉处理一帧的数据
                        }
                        else
                        {
                            SerialRevList.RemoveAt(0);//帧头不正确时，记得清除
                        }

                        //IODH接收16进制处理方式

                    }
                    Monitor.Exit(this.SerialRevList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "串口接受线程处理错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Thread.Sleep(50);
            }
        }

        #endregion

        #region 点击发送串口数据btnSend_Click
        private void btnSend_Click(object sender, EventArgs e)//发送串口数据
        {
            //定义一个变量，记录发送了几个字节  
            int n = 0;
            //16进制发送  
            if (rbSendHex.Checked)
            {
                //MatchCollection:将正则表达式模式应用于输入字符串所找到的成功匹配的集合
                //用正则得到有效的十六进制数，该方法比去掉空格 空字符等好
                MatchCollection mc = Regex.Matches(tbxSendData.Text, @"(?i)[\da-f]{2}");
                List<byte> buf = new List<byte>();//填充到这个临时列表中，比用数组好很多  
                //依次添加到列表中  
                foreach (Match m in mc)
                {
                    buf.Add(byte.Parse(m.Value)); //将m.Value转换为byte添加到列表buf中
                }
                //转换列表为数组后发送  
                sp.Write(buf.ToArray(), 0, buf.Count);
                //记录发送的字节数  
                n = buf.Count;
            }
            else//字符串直接发送  
            {
                ////包含换行符  
                //if (checkBoxNewlineSend.Checked)
                //{
                //    sp.WriteLine(tbxSendData.Text);
                //    n = tbxSendData.Text.Length + 2;
                //}
                //else//不包含换行符  
                //{
                //    sp.Write(tbxSendData.Text);
                //    n = tbxSendData.Text.Length;
                //}

                sp.Write(tbxSendData.Text);
                n = tbxSendData.Text.Length;
            }
            send_count += n;//累加发送字节数  
            labelSendCount.Text = "发送字节数:" + send_count.ToString();//更新发送计数 
        }
        #endregion

        #region 串口开关btnOpenCom_Click
        private void btnOpenCom_Click(object sender, EventArgs e)//串口开关
        {
            if (sp.IsOpen == false)//串口未打开，按钮打开
            {
                if (!CheckPortSetting())//检查串口参数是否非法
                {
                    MessageBox.Show("串口未设置！", "错误提示");
                    return;
                }
                SetPortProperty();//设置串口参数
                try
                {
                    sp.Open();//打开串口
                    this.SerialSendQueue.Clear(); //发送命令队列清空
                    this.SerialSendWaiter.Set();  //启动串口发送线程
                    this.SerialRevWaiter.Set();   //启动串口接收线程
                }
                catch (Exception ex)//串口打开异常处理
                {
                    //捕获到异常信息，创建一个新的sp对象，之前的不能用了
                    sp = new SerialPort();
                    //MessageBox.Show("串口无效或已被占用！", "错误提示");
                    MessageBox.Show(ex.Message, "串口无效或已被占用！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else//关闭串口
            {
                try
                {
                    sp.Close();//关闭串口
                    //pictureBox1.BackColor = System.Drawing.Color.Red;
                    this.SerialSendQueue.Clear(); //发送命令队列清空
                    this.SerialRevList.Clear();   //接收数据清空
                    this.SerialSendWaiter.Reset();  //停止串口发送线程
                    this.SerialRevWaiter.Reset();   //停止串口接收线程
                }
                catch (Exception ex)//关闭串口异常
                {
                    MessageBox.Show(ex.Message, "串口关闭失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //设置按钮、图标的状态  
            btnOpenCom.Text = sp.IsOpen ? "关闭串口" : "打开串口";
            pictureBox1.BackgroundImage = sp.IsOpen ? Properties.Resources.蓝点 : Properties.Resources.红点;
            cbPortName.Enabled = !sp.IsOpen; //串口打开则串口号锁定
            btnSend.Enabled = sp.IsOpen; //串口未打开禁止发送
            cbTimeSend.Enabled = sp.IsOpen;//串口未打开禁止定时发送
        }
        #endregion

        #region 串口接受区数据清空
        private void btnClearRev_Click(object sender, EventArgs e)//接受数据清空
        {
            tbxRcvData.Text = "";
        }
        #endregion

        #region 串口发送区数据清空
        private void btnClearSend_Click(object sender, EventArgs e)//发送文本框清空
        {
            tbxSendData.Text = "";
        }
        #endregion

        #region 串口接受计数清零
        private void btnClearRcvCount_Click(object sender, EventArgs e)//接受计数清零
        {
            received_count = 0;
            labelRcvCount.Text = "接收字节数：0";
        }
        #endregion

        #region 串口发送计数清零
        private void btnClearSendCount_Click(object sender, EventArgs e)//发送计数清零
        {
            send_count = 0;
            labelSendCount.Text = "发送字节数：0";
        }
        #endregion

        #region 串口动态波特率选择
        private void cbBaudRate_SelectedIndexChanged(object sender, EventArgs e)//动态波特率选择
        {
            sp.BaudRate = int.Parse(cbBaudRate.Text.Trim());
        }
        #endregion

        #region 串口动态数据位选择
        private void cbDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            sp.DataBits = Int16.Parse(cbDataBits.Text.Trim());//设置数据位
        }
        #endregion

        #region 串口动态停止位选择
        private void cbStop_SelectedIndexChanged(object sender, EventArgs e)
        {
            float f = Convert.ToSingle(cbStop.Text.Trim());//设置停止位
            if (f == 0)
            {
                sp.StopBits = StopBits.None;
            }
            else if (f == 1.5)
            {
                sp.StopBits = StopBits.OnePointFive;
            }
            else if (f == 1)
            {
                sp.StopBits = StopBits.One;
            }
            else if (f == 2)
            {
                sp.StopBits = StopBits.Two;
            }
            else
            {
                sp.StopBits = StopBits.One;
            }
        }
        #endregion

        #region 串口动态校验位选择
        private void cbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = cbParity.Text.Trim();//设置奇偶校验位
            if (s.CompareTo("无") == 0)
            {
                sp.Parity = Parity.None;
            }
            else if (s.CompareTo("奇校验") == 0)
            {
                sp.Parity = Parity.Odd;
            }
            else if (s.CompareTo("偶校验") == 0)
            {
                sp.Parity = Parity.Even;
            }
            else
            {
                sp.Parity = Parity.None;
            }
        }
        #endregion

        #region 串口定时发送定时器事件
        private void timerSerial_Tick(object sender, EventArgs e)
        {
            try
            {
                timerSerial.Interval = int.Parse(tbxSendTime.Text);//根据定时文本设置定时时间
                btnSend.PerformClick();//生成btnSend按钮的 Click 事件
            }
            catch (Exception)
            {
                timerSerial.Enabled = false;
                MessageBox.Show("错误的定时输入！", "错误提示");
            }
        }
        #endregion

        #region 复选定时器开关
        private void cbTimeSend_CheckedChanged(object sender, EventArgs e)
        {
            timerSerial.Enabled = cbTimeSend.Checked;//选中则打开定时器
        }
        #endregion

        #region 串口定时发送时间输入限制
        private void tbxSendTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            //通过正则匹配输入，仅支持数字和退格
            string patten = "[0-9]|\b"; //“\b”：退格键
            Regex r = new Regex(patten);
            Match m = r.Match(e.KeyChar.ToString());

            if (m.Success)//
            {
                e.Handled = false;   //没操作“过”，系统会处理事件    
            }
            else
            {
                e.Handled = true;//cancel the KeyPress event
            }
        }
        #endregion
        #endregion

        #region 测试数据存储（DataGridView和DataTable的使用）

        #endregion

        #region 测试数据存储（DataGridView和DataTable的使用）
        /// <summary>
        /// 初始化DataTable，并将datatable绑定到DataGridView的数据源，新建列标题
        /// </summary>
        private void InitDatable()
        {
            //新建列  
            DataColumn col1 = new DataColumn("休眠", typeof(string));
            DataColumn col2 = new DataColumn("门磁A-12V", typeof(string));
            DataColumn col3 = new DataColumn("门磁A-5V", typeof(string));
            DataColumn col4 = new DataColumn("门A-LED", typeof(string));
            DataColumn col5 = new DataColumn("门磁B-12V", typeof(string));
            DataColumn col6 = new DataColumn("门磁B-5V", typeof(string));
            DataColumn col7 = new DataColumn("门B-LED", typeof(string));
            //添加列  
            dt.Columns.Add(col1);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);
            dt.Columns.Add(col4);
            dt.Columns.Add(col5);
            dt.Columns.Add(col6);
            dt.Columns.Add(col7);

            this.dataGridView1.DataSource = dt.DefaultView;
        }

        /// <summary>
        /// 按键触发记录测试数据，即添加行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestRecord_Click(object sender, EventArgs e)
        {
            //dt.Rows.Clear();//清空数据  
            DataRow dr = dt.NewRow();//新增行 
            dr[0] = "OK";
            dr[1] = "OK";
            dr[2] = "OK";
            dr[3] = "OK";
            dr[4] = "OK";
            dr[5] = "OK";
            dr[6] = "F";
            this.dt.Rows.Add(dr);//增加行
        }

        /// <summary>
        /// 清除表格记录内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCleanRecord_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();//清空数据
        }

        /// <summary>
        /// 测试记录导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            IODM_TEST.DataGridViewToExcel(dataGridView1);
        }
        #endregion

        #region 页面切换操作
        #region 打开项目拓展界面
        private void tsbtnHTProject_Click(object sender, EventArgs e)
        {
            this.Width = (this.Width == 940) && (tabControl2.SelectedTab == PageIODM) ? 600 : 940; //侧边显示AWG监测仪界面
            tabControl2.SelectedTab = PageIODM;
            //gbxAWGtester.BringToFront();//置顶
            //页面切换、页面关闭时需做的处理

        }
        #endregion
        #endregion

        #region 窗口关闭处理
        private void Form5_FormClosing(object sender, FormClosingEventArgs e)//关闭时事件
        {
            sp.Close();//串口关闭时关闭串口
        }



        #endregion

        #region 帮助按钮
        private void tsbtnHelp_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }


        #endregion

        
    }
}

