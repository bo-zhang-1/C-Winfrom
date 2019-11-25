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
    public partial class InvokeThreadSafeForm : Form
    {
        private delegate void SafeCallDelegate(string text);

        private Button button1;
        private TextBox textBox1;
        private Thread thread2 = null;

        //[STAThread]
        //private static void Main()
        //{
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.EnableVisualStyles();
        //    Application.Run(new InvokeThreadSafeForm());
        //}

        public InvokeThreadSafeForm()
        {
            button1 = new Button
            {
                Location = new Point(15, 55),
                Size = new Size(240, 20),
                Text = "Set text safely"
            };
            button1.Click += new EventHandler(Button1_Click);
            textBox1 = new TextBox
            {
                Location = new Point(15, 15),
                Size = new Size(240, 20)
            };
            Controls.Add(button1);
            Controls.Add(textBox1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            thread2 = new Thread(new ThreadStart(SetText));
            thread2.Start();
            Thread.Sleep(1000);
        }

        private void WriteTextSafe(string text)
        {
            if (textBox1.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                textBox1.Invoke(d, new object[] { text });
            }
            else
            {
                textBox1.Text = text;
                MessageBox.Show("test1");
            }
        }

        private void SetText()
        {
            WriteTextSafe("This text was set safely.");
        }
    }
}