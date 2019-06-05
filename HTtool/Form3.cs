using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTtool
{
    public partial class Form3 : Form
    {
        private int flag = 0;
        private string str = "";
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            str = textBox1.Text;
            if (flag == 1) str = str.ToLower();
            else if (flag == 2) str = str.ToUpper();
            //如果flag=0，则表示原样输出                        
            textBox2.Text = str;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            flag = 1; 		//1表示转换为小写字符
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            flag = 2; 		//2表示转换为大写字符
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int ascii = c;  //获取字符的ASCII码

            if ((ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122))
            { 	//c为字母时
                if (checkBox1.Checked) str += c.ToString(); //如果允许输入数字
            }
            else if (ascii >= 48 && ascii <= 57) 	//c为数字时 
            {
                if (checkBox2.Checked) str += c.ToString(); //如果允许输入数字
            }
            else  //c为其他可视符号
            {
                //如果允许输入其他可视符号
                if (checkBox3.Checked) str += c.ToString();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            textBox1.Text = str;
            textBox1.Focus();
            //将光标置于最后一个字符后面
            textBox1.Select(textBox1.Text.Length, 0);
        }

    }
}
