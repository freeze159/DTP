using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormProJect
{
    public class Time
    {
        int second;
        int minute;
        int hour;
        int sumSecond;
        int getMoney;
        static System.Windows.Forms.Timer timer;
        public Time()
        { }
        public Time(int moneySum, int moneyPerHour)
        {
            sumSecond = (moneySum * 3600) / moneyPerHour;
            hour = sumSecond / 3600;
            minute = (sumSecond % 3600) / 60;
            second = minute % 60;
            getMoney = moneySum;
        }
        public int Second
        {
            set { second = value; }
            get { return second; }
        }
        public int SumSecond
        {
            set { sumSecond = value; }
            get { return sumSecond; }
        }
        public int Minute
        {
            set { minute = value; }
            get { return minute; }
        }
        public int Hour
        {
            set { hour = value; }
            get { return hour; }
        }

        public int GetMoney
        {
            get
            {
                return getMoney;
            }

            set
            {
                getMoney = value;
            }
        }

        public void timer_Tick(object sender, EventArgs e)
        {

            if (Hour > 0)
            {
                if (Minute > 0)
                {
                    if (Second > 0)
                        Second--;
                    else
                    {
                        Second = 59;
                        Minute--;
                    }
                }
                else
                {
                    Second = 59;
                    Minute = 59;
                    Hour--;
                }
            }
            else
            {
                if (Minute == 0 && Second == 0)
                {
                    timer.Stop();
                }
            }
            
        }
        
    }
}
