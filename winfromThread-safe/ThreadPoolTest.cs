using System;
using System.Collections;
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
    public partial class ThreadPoolTest : Form
    {
        public ThreadPoolTest()
        {
            InitializeComponent();
        }

        [STAThread]
        private static void Main()
        {
            Console.WriteLine("开始毫秒值：" + DateTime.Now.Millisecond);
            //string wwewe = "";
            //for (int i = 0; i < 1000; i++)
            //{
            //    wwewe = i.ToString();
            //    wwewe = "";
            //}
            // 3毫秒

            Queue myr = new Queue();
            Queue my2 = Queue.Synchronized(myr);
            for (int i = 0; i < 1000; i++)
            {
                my2.Clear();
                my2.Enqueue(i);
            }

            //for (int i = 0; i < 1000; i++)
            //{
            //    myr.Dequeue();
            //}

            //Stack stack = new Stack();

            //for (int i = 0; i < 1000; i++)
            //{
            //    stack.Push(i);
            //}

            //for (int i = 0; i < 1000; i++)
            //{
            //    stack.Pop();
            //}

            //int mmm = 0;

            //for (int i = 0; i < 1000; i++)
            //{
            //    mmm = i;
            //    mmm = 0;
            //}

            Console.WriteLine("结束时间：" + DateTime.Now.Millisecond);
        }

        private void sgere(Queue myr)
        {
            myr.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadPool.SetMaxThreads(66, 66);
            ThreadPool.QueueUserWorkItem(new WaitCallback(SetTste));
        }

        private void SetTste(object o)
        {
            Console.WriteLine("测试你好");
            Console.WriteLine("测试你好2");
        }
    }
}