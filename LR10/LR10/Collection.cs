using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR10
{
    public class Collection<T> : IEnumerable<T> where T : Student
    {
        public List<T> listcollection = new List<T>();
        public void Add(T item)
        {
            listcollection.Add(item);
        }
        public void Remove(T item)
        {
            listcollection.Remove(item);
        }
        public void Print()
        {
            foreach (var item in listcollection)
                item.ShowInfo();
        }
        public void Search(string searchname)
        {
            foreach (var item in listcollection)
            {
                if (item.Surname == searchname)
                    Console.WriteLine($"Совпадения:Имя - {item.Name}// Фамилия - {item.Surname}// Курс - {item.Kurs}// Группа - {item.Group}// ");
            }

        }
        public IEnumerator GetEnumerator()
        {
            return listcollection.GetEnumerator();
        }
    }
}
