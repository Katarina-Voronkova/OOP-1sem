using System;

namespace LR4
{
    //Удаление гласных из строки
    public static class StatisticOperation
    {
        public static string VowelDel(this string str)
        {
            string vowels = "АаЕеЁёИиОоУуЭэыЮюЯя";
            foreach (char e in vowels)
            {
                str = str.Replace(e, '\0');//замена e на "нулевой символ"
            }
            return str;
        }
        //Удаление первых пяти элементов
        public static string FiveClear(this string str)
        {
            str = str.Remove(0, 5);
            return str;
        }
    
        public static string Sum(this string first, string second)//складываем строки
        {

            first = String.Concat(first, second);
            return first;
        }
        public static int LengthDiff(this string first, string second)//разница длин строк
        {
            int diff = Math.Abs(first.Length - second.Length);
            return diff;
        }
        public static int CountOfSymbols(this string str)//подсчет количества элементов
        {
            return str.Length;
        }
        public static void Vivod(this Array arr)
        {
            foreach (int e in arr._array)
            {
                Console.Write(" " + e + " ");
            }
            Console.WriteLine();
        }

        public static void Vivod( this int[] arr)
        {
            foreach (int e in arr)
            {
                Console.Write(" " + e + " ");
            }
            Console.WriteLine();
        }
    }

}