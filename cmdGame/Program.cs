using cmdGame;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cmdGame
{
    public class Diver
    {
        public static int FrameIntervalMS = 30;
        private static bool isNeedStop;

        public static void Start(Action<char> onGetInput,Func<double,double,bool> onUpdate)
        {
            var thread = new Thread(() =>
            {
                while (true)
                {
                    var info = Console.ReadKey();
                    var inputCh = info.KeyChar;
                    onGetInput(inputCh);
                }
            });
            thread.Start();
            RepeatInvoke((timeSinceStart, dt) =>
            {
                isNeedStop = onUpdate(timeSinceStart, dt);
            }, FrameIntervalMS);
        }

        static void RepeatInvoke(Action<double, double> func, int callIntervalMS)
        {
            var initTime = DateTime.Now;
            var lastTimestamp = DateTime.Now;
            while (true)
            {
                try
                {
                    Thread.Sleep(Math.Max(1, callIntervalMS));
                    var totalElipse = DateTime.Now - initTime;
                    var totalSec = totalElipse.TotalSeconds;
                    var elipse = DateTime.Now - lastTimestamp;
                    var dtSec = elipse.TotalSeconds;
                    lastTimestamp = DateTime.Now;
                    func(totalSec, dtSec);
                    if (isNeedStop) return;
                }
                catch(ThreadAbortException e)
                {
                    return;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }


    
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Awake();

            Diver.FrameIntervalMS = 100;
            Diver.Start(game.OnGetInput, game.OnUpdate);
            Console.ReadLine();
        }
    }
}




//创建另一个进程等待控制台输入
/*
char ch = ' ';
var thread = new Thread(() =>
{
    while (true)
    {
        var info = Console.ReadKey();
        ch = info.KeyChar;
    }
});
thread.Start();//new一个线程，之后start
while (true)
{
    Thread.Sleep(300);
    game.Update();
    if (ch != ' ')
    {
        Console.WriteLine("------------" + ch);
    }
    ch = ' ';
}
while (true)
{
    Thread.Sleep(300);//进程暂停1000ms
    game.Update();
}
*/