using System;
using System.Diagnostics;
using System.Threading;

namespace lab15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Information.ProcInfo();
            Information.ThreadInfo();
            Information.DomainInfo();
            Console.ReadKey();
            Information.Multiproc();
            Console.ReadKey();
            Information.OnTimer();

            Console.WriteLine(" Enter another n:");
            int n = Convert.ToInt32(Console.ReadLine());
            var tr1 = new Thread(Information.PrintEvenNumber);
            var tr2 = new Thread(Information.PrintOddNumber);
            Console.WriteLine("\neven-odd-even-odd");
            tr1.Priority--;
            tr1.Start(n);
            Thread.Sleep(50);
            tr2.Start(n);
            Thread.Sleep(n * 56);
            var tr3 = new Thread(Information.PrintEvenNumberLocked);
            var tr4 = new Thread(Information.PrintOddNumberLocked);
            Console.WriteLine("even first, then odd");
            tr3.Start(n);
            tr4.Start(n);

        }
    }
}
