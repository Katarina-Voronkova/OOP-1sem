using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR8
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionType<int> set1 = new CollectionType<int>() { 5, 7, 21, 55 };
            set1.Add(18);
            set1.Add(32);
            set1.Add(28);
            set1.Delete(28);
            set1.Print();
            set1.Write();

            CollectionType<double> set2 = new CollectionType<double>() { 1.3, 31.11, 87.9, 49.55 };
            set2.Add(8);
            set2.Add(77.1);
            set2.Add(19.37);
            set2.Delete(8);
            set2.Print();
            set2.Write();

            CollectionType<Parametr> set3 = new CollectionType<Parametr>();
            Parametr A1 = new Parametr(1, "Петя");
            Parametr A2 = new Parametr(2, "не Петя");
            set3.Add(A1);
            set3.Add(A2);
            set3.Print();

            set1.Read();
        }
    }
    class Parametr
    {
        public int Nomer;
        public string Name;
        public Parametr(int nomer, string name)
        {
            this.Nomer = nomer;
            this.Name = name;
        }
        public void YaEstb()
        {
            Console.WriteLine("Этот класс используется как параметр обобщения");
        }
    }
    interface Imy_interface<T> 
    {
        void Add(T item);
        void Delete(T item);
        void Print();
    }
    //interface Imy_interface<T> where T : Parametr
    //{
    //    void Add(T item);
    //    void Remove(T item);
    //    void Print();
    //}
    
    public class CollectionType<T> : IEnumerable, Imy_interface<T>
    {
        private List<T> items = new List<T>();

        public int Count => items.Count;

        //конструкторы
        public CollectionType() { }

        public CollectionType(T item)
        {
            items.Add(item);
        }
        //методы
        public void Delete(T item)
        {
            items.Remove(item);
        }
        public void Sort()
        {
            items.Sort();
        }
        public void Print()
        {
            foreach (var i in items)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine("\n");
        }

        public void Read()
        {
            string path = "C:\\Users\\Катя\\source\\repos\\LR8\\INFO.txt";

            using StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)//ReadLine(): считывает одну строку в файле
            {
                Console.WriteLine(line);
            }
            //считываем построчно через цикл while:
            //while ((line = sr.ReadLine()) != null) - сначала присваиваем переменной line результат функции sr.ReadLine(),
            //а затем проверяем, не равна ли она null.
            //Когда объект sr дойдет до конца файла и больше строк не останется, то метод sr.ReadLine() будет возвращать null
        }
        public void Write()
        {
            string Message = "";
            foreach (T a in items)
                Message += a + " ";

            Message += "\n-----------------------------------------------------\n";
            File.AppendAllText("C:\\Users\\Катя\\source\\repos\\LR8\\INFO.txt", Message);
        }

        public static CollectionType<T> operator +(CollectionType<T> set, T item)
        {
            var result = new CollectionType<T>();

            var count1 = 0;
            foreach (T item1 in set)
            {
                if (item1.Equals(item))
                {
                    count1++;
                }
                result.Add(item1);
            }
            if (count1 != 1)
            {
                result.Add(item);
            }
            return result;

        }

        public void Add(T item)
        {
            foreach (var i in items)
            {
                if (i.Equals(item))//если такой уже есть
                {
                    return;
                }
            }
            items.Add(item);
        }

        public static CollectionType<T> operator -(CollectionType<T> set, T item)
        {
            var result = new CollectionType<T>();
            foreach (T item2 in set)
            {
                if (item2.Equals(item))
                {
                    continue;
                }
                else
                {
                    result.Add(item2);
                }
            }
            return result;

        }


        public static CollectionType<T> operator %(CollectionType<T> set1, CollectionType<T> set2)
        {
            var result = new CollectionType<T>();
            CollectionType<T> big;
            CollectionType<T> small;
            if (set2.Count >= set1.Count)
            {
                big = set2;
                small = set1;
            }
            else
            {
                big = set1;
                small = set2;
            }
            foreach (var item1 in big.items)
            {
                foreach (var item2 in small.items)
                {
                    if (item1.Equals(item2))
                    {
                        result.Add(item1);
                        break;
                    }
                }
            }
            return result;
        }
        public static bool operator <(CollectionType<T> set1, CollectionType<T> set2)
        {
            return true;
        }
        public static bool operator >(CollectionType<T> set1, CollectionType<T> set2)
        {
            foreach (var item1 in set1)
            {
                var equals = false;
                foreach (var item2 in set2)
                {
                    if (item1.Equals(item2))
                    {
                        equals = true;
                        break;
                    }
                }
                if (!equals)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator ==(CollectionType<T> set1, CollectionType<T> set2)
        {

            var equality = set1.Count;
            var eq = 0;
            foreach (var item1 in set2)
            {


                foreach (var item2 in set1)
                {
                    if (item1.Equals(item2))
                    {
                        eq++;
                        break;
                    }
                }

            }
            if (equality == eq)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(CollectionType<T> set1, CollectionType<T> set2)
        {
            if (set2.Count > set1.Count || set2.Count < set1.Count)
                return true;
            var equality = set1.Count;
            var eq = 0;
            foreach (var item1 in set2)
            {
                foreach (var item2 in set1)
                {
                    if (item1.Equals(item2))
                    {
                        eq++;
                        break;
                    }
                }

            }
            if (equality == eq)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            // Используем перечислитель списка элементов данных множества.
            return items.GetEnumerator();
        }


    }

}
