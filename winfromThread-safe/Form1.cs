using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winfromThread_safe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 线程不安全

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread2 = new Thread(new ThreadStart(WriteTextUnsafe));
            thread2.Start();
        }

        private void WriteTextUnsafe()
        {
            textBox1.Text = "This text was set unsafely." + DateTime.Now;

            ////“System.InvalidOperationException”类型的未经处理的异常在 System.Windows.Forms.dll 中发生
            // 其他信息: 线程间操作无效: 从不是创建控件“textBox1”的线程访问它。
        }

        #endregion 线程不安全
    }
}