using System;
using System.Text;

namespace LR1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ТИПЫ
            byte byteNum = 255;
            sbyte sbyteNum = -128;
            short shortNum = -32768;
            ushort ushortNum = 65535;
            int intNum = -2147483648;
            uint uintNum = 4294967295;
            long longNum = -9223372036854775808;
            ulong ulongNum = 18446744073709551615;

            float floatNum = -35.78f;
            double doubleNum = 678.23;
            decimal decimalNum = 2786.1m;

            char charVar = '#';
            string stringVar = "Nice to meet you";

            bool boolVar = true;

            Console.WriteLine("-----Числовые (целочисленные) типы:");
            Console.WriteLine($" byte: {byteNum}\n sbyte: {sbyteNum}\n short: {shortNum}\n ushort: {ushortNum}\n" +
                              $" int: {intNum}\n uint: {uintNum}\n long: {longNum}\n ulong: {ulongNum}");
            Console.WriteLine("-----Числовые (сплавающей точкой):");
            Console.WriteLine($" float: {floatNum}\n double: {doubleNum}\n decimal: {decimalNum}");
            Console.WriteLine("-----Cимвольные:");
            Console.WriteLine($" char: {charVar}\n string: {stringVar}");
            Console.WriteLine($"-----Логический:\n bool: {boolVar}\n\n");

            //неявное преобразование
            shortNum = byteNum;
            floatNum = uintNum;
            intNum = charVar;

            Console.WriteLine($"-----Неявное преобразование:\n" +
                $" shortNum = byteNum; shortNum = {shortNum}\n" +
                $" floatNum = uintNum;  floatNum = {floatNum}\n" +
                $" intNum = charVar; intNum = {intNum}\n\n");

            //явное преобразование
            int x1 = 20, x2 = 45;
            byte sum = (byte)(x1 + x2);
 
            uint y1 = 45; long y2 = -2;
            double g = (double)(y1 * y2);

            char charVar2 = '(';
            intNum = Convert.ToInt32(charVar2);

            Console.WriteLine($" int x1 = 20, x2 = 45;  byte sum = (byte)(x1 + x2):   {sum}\n" +
                $" uint y1 = 45; long y2 = -2;  double g = (double)(y1 * y2):   {g}\n" +
                $" char charVar2 = '('; intNum = Convert.ToInt32(charVar2):   {intNum}\n\n");

            //класс Convert +ввод с клавиатуры
            string a, b;
            Console.WriteLine("Введите первое число");
            a = Console.ReadLine();
            Console.WriteLine("Введите второе число");
            b = Console.ReadLine();
            int a1 = Convert.ToInt32(a);
            int b1 = Convert.ToInt32(b);
            Console.WriteLine("Сумма: " + (a1 + b1));
            

            //упаковка
            int a2 = 5;
            object b2 = a2;
            int c2 = (int)b2; //распаковка
            decimal d2 = (decimal)(int)b2;//распаковка, а затем приведение типа
            Console.WriteLine($"-----Распаковка:\n {c2} --- {d2}\n\n");

            //неявно типизированной переменная
            var i = 5;
            var s = "dream";
            Console.WriteLine("-----Неявно типизированная переменная");
            Console.WriteLine(i + " - " + i.GetType());
            Console.WriteLine(s + " - " + s.GetType() + "\n\n");

            //Nullable переменная
            int? k = 10; // или Nullable<int> k

            if (k.HasValue)//возвращает false, если значение объекта равно null
            {
                Console.WriteLine(k.Value + "\n\n");
            }
            else
            {
                Console.WriteLine("No value\n\n");
            }

            //ошибка с var
            var p = 123;
            // p = 123.5f; // Невозможно так как предыдущая строка определила переменную p, как переменную типа int
            #endregion

            #region СТРОКИ
            Console.WriteLine("-----CТРОКИ\n\n");

            //сравнение
            string str1 = "word";
            string str2 = "words";
            Console.WriteLine(str1.CompareTo(str2));

            //копирование
            str1 = string.Copy(str2);
            Console.WriteLine(str1);//теперь words

            //сцепление
            string string1 = "I'm ",
                   string2 = "going ",
                   string3 = "home";
            Console.WriteLine(string.Concat(string1, string2, string3));

            //выделение подстроки из строки с 5го места
            string text = string.Concat(string1, string2, string3);
            Console.WriteLine(text.Substring(4));

            //разделение строки на слова
            string[] words = text.Split(' ');
            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
            //вставки подстроки в заданную позицию
            string text2 = text.Insert(0, "Katarina ");
            Console.WriteLine(text2);

            // удаление заданной подстроки
            Console.WriteLine(text2.Remove(9, 4) + "\n");

            // метод string.IsNullOrEmpty
            string emptyStr = null;
            if (string.IsNullOrEmpty(emptyStr))
            {
                Console.WriteLine("Эта строка пустая :)");
            }

            var newStr = new StringBuilder("каникулы нескоро.");
            newStr.Insert(0, "Очень НЕгрустно, что ");
            newStr.Append(" Можно идти плакать!");
            Console.WriteLine(newStr);
            newStr.Remove(6, 2);
            Console.WriteLine(newStr + "\n\n");
            #endregion

            #region МАССИВЫ
            Console.WriteLine("-----МАССИВЫ\n\n");
            //целый двумерный массив
            int[,] arr = { { 0, 1, 2 }, { 3, 4, 5 } };
            for (int e = 0; e < 2; e++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{arr[e, j]}  ");
                }
                Console.WriteLine();
            }

            //одномерный массив строк
            string[] str = { "Это", "одномерный", "массив", "строк" };
            Console.WriteLine("размер массива: " + str.Length);

            foreach (var item in str)//для каждого элемента в строке
            {
                Console.Write($"{item} ");
            }

            Console.Write("\nВведите позицию: ");
            string position = Console.ReadLine();

            if (int.TryParse(position, out int res))
            {
                if (res < str.Length)
                {
                    Console.Write("что вводим: ");
                    string vvod_str = Console.ReadLine();
                    str[res] = vvod_str;
                }
            }

            foreach (var item in str)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n\n");

            //ступечатый (не выровненный) массив  
            //чисел с 3 - мя строками, в каждой из которых 2, 3 и 4 столбцов
            int[][] stup_Arr = new int[3][];
            stup_Arr[0] = new int[2];
            stup_Arr[1] = new int[3];
            stup_Arr[2] = new int[4];

            for (int l = 0; l < stup_Arr.Length; l++)
            {
                for (int j = 0; j < stup_Arr[l].Length; j++)
                {
                    Console.Write("Введите значение для массива: ");
                    var vvod_num = Console.ReadLine();
                    if (int.TryParse(vvod_num, out res))
                    {
                        stup_Arr[l][j] = res;
                    }
                }
            }
            for (int l = 0; l < stup_Arr.Length; l++)
            {
                for (int j = 0; j < stup_Arr[l].Length; j++)
                {
                    Console.Write(stup_Arr[l][j] + " ");
                }
                Console.WriteLine("\n");
            }
            //неявно типизированные переменные для хранения массива и строки
            var arr2 = new int[2];
            var r = "hey";
            #endregion

            #region КОРТЕЖИ
            var t = (2, "Hello", '#', "information", 234);
            Console.WriteLine($"Кортеж: {t}");
            Console.WriteLine($"1, 3 и 4 элементы кортежа: {t.Item1}, {t.Item3}, {t.Item4}");
            //распаковка кортежа в переменные
            var info1 = t.Item1;
            var info2 = t.Item2;
            var info3 = t.Item3;
            var info4 = t.Item4;
            var info5 = t.Item5;
            (info1, info2, info3, info4, info5) = t;
            Console.WriteLine($"{info1} {info2} {info3} {info4} {info5}\n\n");

            // Сравнение кортежей 
            var cort1 = ("Katarina", 19, "Minsk");
            (string, int, string) cort2 = ("Katarina", 19, "Minsk");
            if (cort1  == cort2)
                Console.WriteLine("Сравниваемые кортежи равны\n\n");
            else
                Console.WriteLine("Сравниваемые кортежи НЕ равны\n\n");
            #endregion

            #region Локальная функция
            //<modifiers> <return-type> <method-name> <parameter-list>
            (int, int, int, char) foo(int[] array, string word)
            {
                int min = array[0];
                int max = array[0];
                int sum = 0;
                foreach (var item in array)
                {
                    sum += item;
                    if (item > max)
                    {
                        max = item;
                    }
                    if (item < min)
                    {
                        min = item;
                    }
                }
                return (max, min, sum, word[0]);
            }

            var resultFoo = foo(new int[4] { 1, 2, 3, 4 }, "bye");
            Console.WriteLine($"{resultFoo.Item1} {resultFoo.Item2} " +
                $"{resultFoo.Item3} {resultFoo.Item4}");
            #endregion

            #region Работа с checked/unchecked
            static int fun2()
            {
                checked//проверяется
                {
                    int a = int.MaxValue;
                    a++;
                    return a;
                }

            }
            static int fun3()
            {
                unchecked//не проверяется
                {
                    int b = int.MaxValue;
                    b++;
                    return b;
                }

            }
            Console.WriteLine(fun3());
            Console.WriteLine(fun2());
            #endregion
        }
    }
}
