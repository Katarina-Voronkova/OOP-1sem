using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab15
{
    class Information
    {
        static string objlocker = "null";
        private static StreamWriter writer1 = new StreamWriter(@"D:\info\even-odd-even-odd.txt");
        private static StreamWriter writer2 = new StreamWriter(@"D:\info\even-odd.txt");
        public static void ProcInfo()
        {
            foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine($"Name: {process.ProcessName}\t ID: {process.Id}\t ");
            }

        }

        public static void ThreadInfo()
        {
            Process proc = Process.GetProcessesByName("devenv")[0];
            ProcessThreadCollection processThreads = proc.Threads;

            foreach (ProcessThread thread in processThreads)
            {
                Console.WriteLine($"Thread Id: {thread.Id}  Start Time: {thread.StartTime}");
            }
        }

        public static void DomainInfo()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine();

            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);
        }

        public static void Multiproc() 
        {
            Thread parallel = new Thread(new ThreadStart(FindPrimes));
            Console.WriteLine("async work example:)");
            parallel.Start();
                while (parallel.IsAlive)
            {
                Console.WriteLine("Multiproc still working...");
                Thread.Sleep(1000);
            }
        }

        public static void FindPrimes() 
        {
            Console.WriteLine("Enter n:");
            int n = Convert.ToInt32(Console.ReadLine());
            bool[] primes = new bool[n + 1];
            string logPath = @"D:\info\multiproc.txt";
            for (int i = 0; i < n; i++)
            {
                primes[i] = true;
            }
            for (int i = 2; i * i <= n; i++)
            {
                if (primes[i])
                {
                    for (int j = i * 2; j <= n; j += i)
                    {
                        primes[j] = false;
                    }
                }
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true, System.Text.Encoding.Default))
                {
                    for (int i = 2; i <= n; i++)
                    {
                        if (primes[i])
                        {
                            Console.Write(i + " ");
                            sw.Write($"{i}   ");
                            Thread.Sleep(100);
                        }
                    }
                    
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static void OnTimer()
        {
            int num = 0;
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);
            // создаем таймер
            Timer timer = new Timer(tm, num, 0, 2000);
            while (true)
            {
                num++;
                if (num == 10) break;
                Console.WriteLine("im watching at you -_-");
                Thread.Sleep(500);
            }
            return;
        }
        public static void Count(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");
            }
        }

        public static void PrintOddNumber(object n)
        {
            for (var i = 0; i < (int)n; i++)
            {
                if (i % 2 != 1) continue;
                Console.WriteLine(i + " - 2 thread");
                writer1.WriteLine(i);
                Thread.Sleep(100);
            }
            writer1.Close();
        }
        public static void PrintEvenNumber(object n)
        {
            for (var i = 0; i < (int)n; i++)
            {
                if (i % 2 != 0) continue;
                Console.WriteLine(i + " - 1 thread");
                writer1.WriteLine(i);
                Thread.Sleep(100);
            }
        }

        public static void PrintEvenNumberLocked(object n)
        {
            Monitor.Enter(objlocker);
            for (var i = 0; i < (int)n; i++)
            {
                if (i % 2 != 0) continue;
                Console.WriteLine(i + " - 1 thread");
                writer2.WriteLine(i);
                Thread.Sleep(100);
            }
            Monitor.Exit(objlocker);
        }
        public static void PrintOddNumberLocked(object n)
        {
            Monitor.Enter(objlocker);
            for (var i = 0; i < (int)n; i++)
            {
                if (i % 2 != 1) continue;
                Console.WriteLine(i + " - 2 thread");
                writer2.WriteLine(i);
                Thread.Sleep(100);
            }
            writer2.Close();
            Monitor.Exit(objlocker);
        }

    }
}
