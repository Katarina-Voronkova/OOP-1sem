using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace laba16
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //1
            var stopCheck = TimeCheck();
            Task task1 = Task.Run(VectorMultiply);
            Console.WriteLine($"Current task id: {Task.CurrentId}");
            if (task1.IsCompleted)
                Console.WriteLine("Task was completed");
            else
                Console.WriteLine("Task still in process");
            Console.WriteLine($"Task status {task1.Status}");
            task1.Wait();
            stopCheck();


            Console.WriteLine("--------------Task2---------------");


            //2
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            Task task2 = new Task(delegate
            {
                for (int i = 0; i < 9; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine($"Task2 was canceled");
                        return;
                    }
                    VectorMultiply();
                    Thread.Sleep(1000);
                }
            });
            task2.Start();
            Console.WriteLine("Write q to close task2: ");

            var keyTask2 = Console.ReadKey();
            if (keyTask2.KeyChar == 'q')
                tokenSource.Cancel();
            task2.Wait();


            Console.WriteLine("----------------Task3-------------");


            //3 & 4
            var tasks1 = new Task<int>[]
            {
                new Task<int>(() => 1),
                new Task<int>(() => 2),
                new Task<int>(() => 3)
            };
            foreach (var task in tasks1)
            {
                task.Start();
            }
            Task.WaitAll(tasks1);

            var taskFour = new Task<int>(delegate
            {
                int res = 0;
                for (int i = 0; i < 2500; i++)
                {
                    res += i * (int)Math.PI * (int)Math.Pow(Math.E, 12);
                }
                return res;
            });
            taskFour.Start();
            var taskContinue = taskFour.ContinueWith(res => ValAnalyzer(res.Result));
            taskContinue.Wait();

            Console.WriteLine("Get results by GetAwaiter(), GetResult() methods " + taskFour.GetAwaiter().GetResult());


            Console.WriteLine("---------------Task5--------------");


            //5
            var bigArr = new long[1300];
            var rnd = new Random();
            Parallel.For(1, bigArr.Length, (val) =>
            {
                bigArr[val] = rnd.Next(500000000) * 12;
            });

            Parallel.ForEach(new int[] { 1, 234, 324, 12, 94, 34302 }, ValAnalyzer);


            Console.WriteLine("---------------Task6--------------");


            //6
            Parallel.Invoke(VectorMultiply, delegate
            {
                Console.WriteLine($"Task {Task.CurrentId} in process");
                Thread.Sleep(3330);
            });


            Console.WriteLine("---------------Task7--------------");


            BlockingCollection<string> market = new BlockingCollection<string>();
            market.Add("asdcs");
            market.Add("dlkvs0dsv");
            market.Add("ewre32r");

            for (int i = 0; i < market.Count; i++)
            {
                Console.WriteLine(market.Take());
            }


            Console.WriteLine("----------------Task8-------------");


            //8
            var taskForWait = new Task<int>(() =>
            {
                int factorial = 1;
                for (int i = 2; i < 30; i++)
                {
                    factorial += factorial * i;
                }

                return factorial;
            });
            taskForWait.Start();
            TaskWaiter(taskForWait);

            Console.ReadKey();
        }

        public static async void TaskWaiter(Task<int> tsk)
        {
            var stopChecker = TimeCheck();
            Console.WriteLine("Task waiter start");
            var result = await tsk;
            Console.WriteLine($"Task waiter end with result {result}");
            stopChecker();
        }

        public delegate void StopTimeCheck();
        public static StopTimeCheck TimeCheck()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            return () =>
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}.{1:00}.{2:00}",
                    ts.Seconds, ts.Milliseconds, ts.Milliseconds / 1000,
                    ts.Milliseconds);
                Console.WriteLine("RunTime " + elapsedTime);
            };
        }

        public static void ValAnalyzer(int val)
        {
            Console.WriteLine(val);
        }

        public static void VectorMultiply()
        {
            new List<int>(100000).Select((el) => el * 32).ToList();
        }
    }
}