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

namespace ThreadSafe
{
    public partial class delegateFrom : Form
    {
        private delegate void SafeCallMoteod();

        public delegateFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.InvokeRequired)
            {
                var d = new SafeCallMoteod(SetText);
                textBox1.Invoke(d, null);
            }
            else
            {
                SetText();
            }
            Thread myThread = new Thread(new ThreadStart(SetText));
            myThread.Start();
        }

        private void SetText()
        {
            textBox1.Text = "this is MyText!";
        }

        ///// <summary>
        ///// 应用程序的主入口点。
        ///// </summary>
        //[STAThread]
        //private static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new delegateFrom());
        //}
    }
}