using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main1(string[] args)
        {
            // Creates and initializes a new Queue.
            Queue myQ = new Queue();
            myQ.Enqueue("The");
            myQ.Enqueue("quick");
            myQ.Enqueue("brown");
            myQ.Enqueue("fox");

            // Creates a synchronized wrapper around the Queue.
            Queue mySyncdQ = Queue.Synchronized(myQ);

            // Displays the sychronization status of both Queues.
            Console.WriteLine("myQ is {0}.", myQ.IsSynchronized ? "synchronized" : "not synchronized");
            Console.WriteLine("mySyncdQ is {0}.", mySyncdQ.IsSynchronized ? "synchronized" : "not synchronized");
            Console.WriteLine("mySyncdQ is {0}.", mySyncdQ.Dequeue());
            Console.WriteLine("mySyncdQ is {0}.", mySyncdQ.Dequeue());
            Console.WriteLine("mySyncdQ is {0}.", mySyncdQ.Dequeue());
            Console.WriteLine("mySyncdQ is {0}.", mySyncdQ.Dequeue());
            Console.ReadKey();
        }

        //  private static ConcurrentQueue<string> myr = new ConcurrentQueue<string>();
        private static Queue myr1 = new Queue();

        private static Queue myr = Queue.Synchronized(myr1);

        private static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(WriteTextUnsafe2));

            Thread thread2 = new Thread(new ThreadStart(WriteTextUnsafe));
            thread2.Start();
            thread1.Start();
            Thread thread3 = new Thread(new ThreadStart(WriteTextUnsafe3));
            thread3.Start();
            Console.WriteLine("还有多少个元素：" + myr.Count);
            //Console.WriteLine("开始毫秒值：" + DateTime.Now.Millisecond);
            //for (int i = 0; i < 1000; i++)
            //{
            //    myr.Enqueue(i.ToString());
            //}

            //for (int i = 0; i < 1000; i++)
            //{
            //    myr.TryDequeue(out tempStr);
            //}
            //Console.WriteLine("结束时间：" + DateTime.Now.Millisecond);
            Console.ReadKey();
        }

        private static string tempStr;

        private static void WriteTextUnsafe()
        {
            for (int i = 0; i < 100; i++)
            {
                //  myr.Enqueue(i);
                myr.Enqueue(i.ToString());
            }
            // Console.WriteLine("放入完毕" + myr.Count);
            Console.WriteLine("还有多少个元素：" + myr.Count);
            Console.WriteLine("放入完毕" + myr.Count);
        }

        private static void WriteTextUnsafe2()
        {
            for (int i = 200; i < 300; i++)
            {
                if (myr.Count > 0)
                {
                    tempStr = myr.Dequeue().ToString();
                    //  myr.TryDequeue(out tempStr);
                    Console.WriteLine("取到的值：" + tempStr + "剩余长度：" + myr.Count);
                    myr.Enqueue(i.ToString());
                }
            }
        }

        private static void WriteTextUnsafe3()
        {
            for (int i = 0; i < 100; i++)
            {
                if (myr.Count > 0)
                {
                    //  myr.TryDequeue(out tempStr);
                    tempStr = myr.Dequeue().ToString();
                    Console.WriteLine("取到的值test：" + tempStr + "剩余长度：" + myr.Count);
                }
            }
        }
    }
}