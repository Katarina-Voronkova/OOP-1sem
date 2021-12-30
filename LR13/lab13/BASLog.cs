using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab13
{
    static class BASLog
    {
        static string logPath = @"D:\info\BASlogfile.txt";

        public static void Writer(string buff)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(buff);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Actwrite(string action)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logPath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"action: {action};\t date: {DateTime.Now}");
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static string Read()
        {
            var Reader = new StreamReader(logPath);
            string line = Reader.ReadToEnd();

            return line;
        }

        public static List<string> Find(DateTime date)
        {
            string data = Read();
            List<string> result = new List<string>();

            foreach (var field in data.Split('\n').Where(val => val != ""))
            {
                var splitArr = field.Split(' ');
                string dateStr = splitArr[splitArr.Length - 1];
                var fielddate = DateTime.Parse(dateStr);
                if (fielddate < date)
                {
                    result.Add(field);
                }
            }

            return result;
        }

    }
}
