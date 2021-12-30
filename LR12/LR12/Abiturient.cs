using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR12
{
    public class Abiturient
    {
        // поля класса
        public readonly Guid id; //поле только для чтения
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public string adress;
        public string phone;
        public int[] rating = new int[3];
        //для статического конструктора
        public static int bonus = 100;
        //для закрытого конструктора
        public double privateee;
        //поле константа
        public const double E = 2.777;
        //статическое поле  хранящее количество созданных объектов
        public static int counter;

        //СВОЙСТВА. get/set
        private string name;
        public string Name
        {
            get
            {
                return name; //возвращаем значение name
            }
            set
            {
                name = value; //устанавливаем значение 
            }
        }
        private int kurs;
        // свойство только для чтения
        string s = "2";
        public string Kurs
        {
            get
            {
                return s;
            }
        }

        // МЕТОДЫ max min averagescore
        public void AverageScore(out int average)
        {
            average = (rating[0] + rating[1] + rating[2]) / 3;
            Console.WriteLine(average);
        }

        public void Min()
        {
            int min = rating[0];
            for (int i = 1; i < 3; i++)
            {
                if (rating[i] < min)
                {
                    min = rating[i];
                }
            }
            Console.WriteLine(min);

        }

        public void Max()
        {
            int max = rating[0];
            for (int i = 1; i < 3; i++)
            {
                if (rating[i] > max)
                {
                    max = rating[i];
                }
            }
            Console.WriteLine(max);
        }

        //конструктор с параметрами
        public Abiturient(string last, string first, string middle, string adr, string tel, Guid idd, int a, int b, int c)
        {
            LastName = last;
            FirstName = first;
            MiddleName = middle;
            adress = adr;
            phone = tel;
            id = idd;
            rating[0] = a;
            rating[1] = b;
            rating[2] = c;
            counter++;
        }
        //конструктор без параметров
        public Abiturient()
        {
            LastName = "Voronkova";
            FirstName = "svetkaa";
            MiddleName = "koketkaa";
            adress = "gde-to blizko";
            phone = "999999999";
            rating[0] = 10;
            rating[1] = 10;
            rating[2] = 10;
            id = Guid.NewGuid();
            counter++;
        }

        public void Write()
        {
            Console.WriteLine("Фамилия: {0}\nИмя: {1}\nОтчество:{2}\nАдрес:{3}\nТелефон:{4}\nОценка1:{5}\nОценка2:{6}\nОценка3:{7}\nID:{8}\n", LastName, FirstName, MiddleName, adress, phone, rating[0], rating[1], rating[2], id);
        }

        private Abiturient(double priv)
        {
            privateee = Math.E;
        }
        // для поля только для чтения
        public Abiturient(Guid _id)
        {
            id = _id;
            counter++;
        }
        //статический конструктор
        static Abiturient()
        {
            Console.WriteLine("Стааатический конструктор");
        }
        public void CounterWrite()
        {
            Console.WriteLine("Количество экземпляров: " + counter);
        }
        public override string ToString()
        {
            return base.ToString() + " " + LastName + " " + FirstName + " " + MiddleName + " " + adress;
        }
        public override int GetHashCode()
        {
            int hash;
            hash = string.IsNullOrEmpty(MiddleName) ? 0 : MiddleName.GetHashCode();
            hash = (hash * 129);
            return hash;

        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Abiturient stud = (Abiturient)obj;
            return (this.LastName == stud.LastName && this.phone == stud.phone);
        }

    }
}
