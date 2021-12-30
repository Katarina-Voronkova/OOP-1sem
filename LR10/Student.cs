using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR10
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Kurs { get; set; }
        public int Group { get; set; }

        public Student(string name, string surname, int kurs, int group)
        {
            this.Name = name;
            this.Surname = surname;
            this.Kurs = kurs;
            this.Group = group;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Student:Имя - {Name}// Фамилия - {Surname}// Курс - {Kurs}// Группа - {Group}// ");
        }
    }
}
