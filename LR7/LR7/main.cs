using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LR6
{
    class Program
    {
        static void Main(string[] args)
        {

            //исключение класс ComputerException
            try
            {
                Computer computer1 = new Computer("Apple", 1200, 21);
                //string Firm, int price, int srok
                
            }
            catch (ComputerException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}" + '\n');
            }


            //исключение класс TabletException
            try
            {
                Tablet tablet1 = new Tablet("Huawei", 5, 10);
            }
            catch (TabletException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}" + '\n');
            }


            //исключение класса ScanerException
            try
            {
                Scaner scaner1 = new Scaner("", 1100, 7);
            }
            catch (ScanerException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}" + '\n');
            }


            //стандартные исключения
            //недопустимое преобразование типов
            try
            {
                object obj = "No thanks";
                int num = (int)obj;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Возникло исключение InvalidCastException");
                Console.WriteLine($"Метод, где исключение: {e.TargetSite}");
                Console.WriteLine($"Строковое представление стека вызовов: {e.StackTrace}" + '\n');
            }


            //деление на ноль
            try
            {
                int x = 5;
                int y = x / 0;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Возникло исключение DivideByZeroException");
                Console.WriteLine($"Строковое представление стека вызовов: {e.StackTrace}" + '\n');
            }
            finally
            {
                Console.WriteLine("Сработал блок finally" + '\n' + '\n');
            }


            try
            {
                int[] myArr = new int[5] { 1, 2, 0, 10, 12 };

                Console.Write("Исходный массив: ");

                for (int j = 0; j <= myArr.Length; j++)
                    Console.Write(myArr[j] + "   ");

                int i = 120;
                Console.Write("\n Делим на число: ");
                for (int j = 0; j < myArr.Length; j++)
                    Console.Write(i / myArr[j]);
            }
            // Обрабатывает все исключения (универсальный обработчик)
            catch
            {
                Console.WriteLine('\n' + "Возникла непредвиденная ошибка" + '\n' + '\n');
            }


            //многоразовая обработка и проброс по стеку
            try
            {
                try
                {

                    int[] myArr = new int[3] { 10, 0, 12 };
                    Console.Write("Исходный массив: ");

                    for (int j = 0; j <= myArr.Length; j++)
                        Console.Write(myArr[j] + "   ");

                    int i = 120;
                    Console.Write("\nДелим на число: ");
                    for (int j = 0; j < (myArr.Length + 1); j++)
                        Console.Write(i / myArr[j]);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine('\n' + "выход за пределы массива");
                    throw;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            // макрос Assert
            int factorial(int k)
            {
                //условие должно быть обязательно верным, если это не так, то программа дальше не выполняется
                Debug.Assert(k >= 0);
                Debug.Assert(k <= 10);

                if (k < 2)
                {
                    return 1;
                }

                return factorial(k - 1) * k;
            }

            Console.WriteLine("Введите n");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(factorial(n));

        }
    }
}
