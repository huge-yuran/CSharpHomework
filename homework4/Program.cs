using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4_1
{
    //声明参数类型
    public class ALARMEventArgs : EventArgs
    {
        public int hour { set; get; }
        public int minute { set; get; }
        public int second { set; get; }
    }

    //声明委托类型
    public delegate void ALARMHandler(object sender, ALARMEventArgs args);

    //定义事件源
    public class Alarm
    {
        //声明事件
        public event ALARMHandler OnClock;

        public void SetATime()
        {
            Console.WriteLine("请输入响铃时间，如：2019-03-20 11:00:00");
            try
            {
                string setTime = Console.ReadLine();
                ringTime = Convert.ToDateTime(setTime);
                Console.WriteLine("闹钟已设置为： " + setTime);
                while (true)
                {
                    nowTime = new System.DateTime();
                    nowTime = System.DateTime.Now;
                    if (DateTime.Compare(nowTime, ringTime) >= 0)
                    {
                        ALARMEventArgs args = new ALARMEventArgs()
                        {
                            hour = nowTime.Hour,
                            minute = nowTime.Minute,
                            second = nowTime.Second
                        };
                        OnClock(this, args);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private System.DateTime nowTime;
        private System.DateTime ringTime;

    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            Alarm clock = new Alarm();
            clock.OnClock += new ALARMHandler(Ring);
            clock.SetATime();
            Console.ReadKey();
        }

        static void Ring(object sender, ALARMEventArgs args)
        {
            Console.WriteLine($"时间到了！");
        }
    }
}
