using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace LR10
{
    public interface IEnumerable<T>
    {
        IEnumerator GetEnumerator();
    }
    class Program
    {
        static void Main(string[] args)
        {
            //--------первое задание------- Еще не все методы использованы!!
            Collection<Student> list1 = new Collection<Student>();
            Student student1 = new Student("Женя", "Новик", 2, 8);
            list1.Add(student1);
            list1.Print();
            list1.Search("Новик");

            //--------второе задание--------
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(8);
            queue.Enqueue(17);
            queue.Enqueue(351);
            queue.Enqueue(90);
            queue.Enqueue(57);
            Console.Write("Очередь: ");
            foreach (int j in queue)
            {
                Console.Write($"{j} ");
            }
            Console.WriteLine();
            Console.Write("Количество элементов удаления: ");
            int elementdelete = int.Parse(Console.ReadLine());
            int count = queue.Count();//получили сколько элементов в очереди
            for (int i = 0; i < count; i++)
            {
                if (elementdelete != 0)
                {
                    queue.Dequeue();//удаляю один элемент
                }
                else
                {
                    break;
                }
                elementdelete--;
            }
            Console.Write("Очередь после удаления элементов: ");
            foreach (int j in queue)
            {
                Console.Write($"{j} ");
            }
            Console.WriteLine();

            //добавление в очередь введенное значение(как варик для  задания 2с)
            for (int k = 0; k < 3; k++)
            {
                Console.Write("Элемент для добавления: ");
                int elementsadd = int.Parse(Console.ReadLine());
                queue.Enqueue(elementsadd);
            }
            Console.Write("Очередь после очередного добавления элементов: ");
            foreach (int j in queue)
            {
                Console.Write($"{j} ");
            }
            Console.WriteLine();

            //------------вторая коллекция Stack ------------------
            Stack<int> stack = new Stack<int>();
            stack.Push(8);
            stack.Push(17);
            stack.Push(351);
            stack.Push(90);
            stack.Push(57);
            Console.Write("Стек: ");
            foreach (int s in stack)
            {
                Console.Write($"{s} ");
            }
            Console.WriteLine();

            Console.Write("Значение, которое нужно найти - ");
            int elementsearch = int.Parse(Console.ReadLine());
            int countstack = 0;
            foreach (int elem in stack)
            {
                countstack++;
                if (elem == elementsearch)
                {
                    Console.WriteLine($"Элемент: {elem} // Номер элемента: {countstack}");
                }
            }

            //-------------третье задание-----------------
            //наблюдаемая коллекция
            ObservableCollection<Student> observablecollection = new ObservableCollection<Student>();
            observablecollection.CollectionChanged += Student_CollectionChanged; //подписка на событие
            observablecollection.Add(student1);
            observablecollection.Remove(student1);
        }
        private static void Student_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) //обработчик
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Добавлен новый объект");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Удален объект");
                    break;
            }
        }
    }
}
