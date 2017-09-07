using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class statusPrintBuffer
    {
        private string[] buffer = new string[1000];
        public string sumText;
        public string blankSpace;
        private int n;
        private int currentCount;
        public int firstDelayTime = 1500;
        public int count = 0;
        public int length = 200;
        public ToolStripStatusLabel obj;
        public System.Timers.Timer timer = new System.Timers.Timer();
        public System.Timers.Timer delayTimer = new System.Timers.Timer();
        public statusPrintBuffer()
        {
            timer.Interval = 70;
            timer.Enabled = true;
            timer.Stop();
            timer.Enabled = false;
            delayTimer.Elapsed += new ElapsedEventHandler(delayTimer_Elapsed);
            delayTimer.Interval = firstDelayTime;
            delayTimer.Enabled = false;

            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            count = 0;
            currentCount = 0;
        }
        void delayTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Enabled = true;
            delayTimer.Enabled = false;

        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            blankSpace = "";

            n++;

            sumText = "";

            for (int j = 0; j < n * n; j++)
            {
                blankSpace += " ";
            }
            for (int i = count; i > count - currentCount + 1; i--)
            {
                sumText += buffer[i] + "  ";
            }
            sumText += blankSpace + buffer[count - currentCount + 1];

            if (sumText.Length >= length)
            {
                currentCount--;
                sumText = sumText.Substring(0, length);
                n = 0;
                if (currentCount == 0)
                {
                    timer.Stop();
                    sumText = "";

                }

            }
            obj.Text = sumText;


        }
        public void add<T>(T str)
        {
            add(str.ToString());

        }
        public void add(string str)
        {
            count++;
            currentCount++;
            buffer[count] = str;
            if (currentCount == 1)
            {
                obj.Text = str;

                delayTimer.Enabled = true;

            }
            else
            {
                timer.Enabled = true;
            }



        }


    }
}
