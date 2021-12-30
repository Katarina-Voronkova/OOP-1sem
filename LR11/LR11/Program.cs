using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = {"December","January","February",
                               "March","April","May",
                               "June","July","August",
                               "September","October","November"};
            //первый запрос 
            Console.Write("Введите значение для первого запроса(длина элементов) - ");
            int n = int.Parse(Console.ReadLine());
            var linq1 = from item in months
                        where item.Length == n
                        select item;
            Console.Write("Первый запрос: \t");
            foreach (string i in linq1)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();

            //второй запрос. StartsWith - определяет совпадает ли начало данного экземпляра строки с указанной строкой 
            Console.Write("Второй  запрос: ");
            var linq2 = from item in months
                        where item.StartsWith("December") || item.StartsWith("January") || item.StartsWith("February")
                        || item.StartsWith("June") || item.StartsWith("July") || item.StartsWith("August")
                        select item;
            Console.Write("Второй  запрос: ");
            foreach (string i in linq2)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();

            //третий запрос
            Console.Write("Третий  запрос: ");
            var linq3 = months.OrderBy(item => item);
            foreach (string i in linq3)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();

            //четвертый запрос
            Console.Write("Четвертый  запрос: ");
            var linq4 = months.Where(item => item.Contains('u')).Where(item => item.Length >= 4).Select(item => item);
            foreach (string i in linq4)
            {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();


            //------------------------------------------------//
            Abiturient abiturient1 = new Abiturient("Vlad", "Aksennik", 3, 2, 1);
            Abiturient abiturient2 = new Abiturient("Nadia", "Bichun", 8, 9, 9);
            Abiturient abiturient3 = new Abiturient("Nastya", "Bogdan", 7, 8, 7);
            Abiturient abiturient4 = new Abiturient("Nikita", "Vrublevsky", 5, 5, 6);
            Abiturient abiturient5 = new Abiturient("Sasha", "Zharikhin", 7, 7, 6);
            Abiturient abiturient6 = new Abiturient("Vera", "Maksimova", 2, 2, 3);
            Abiturient abiturient7 = new Abiturient("Ira", "Molosh", 4, 4, 6);
            Abiturient abiturient8 = new Abiturient("Zhenya", "Novik", 10, 9, 8);
            Abiturient abiturient9 = new Abiturient("Sasha", "Zemlyansky", 10, 7, 6);
            Abiturient abiturient10 = new Abiturient("Vika", "Shelepen", 4, 8, 8);
            Console.WriteLine(abiturient10.rating[0]);
            List<Abiturient> list = new List<Abiturient>();
            list.Add(abiturient1);
            list.Add(abiturient2);
            list.Add(abiturient3);
            list.Add(abiturient4);
            list.Add(abiturient5);
            list.Add(abiturient6);
            list.Add(abiturient7);
            list.Add(abiturient8);
            list.Add(abiturient9);
            list.Add(abiturient10);

            //------список абитуриентов, имеющих неудовлетворительные оценки---------
            var linq5 = list.Where(item => (item.rating[0] <= 4) || (item.rating[1] <= 4) || (item.rating[2] <= 4));
            Console.WriteLine("Первый запрос с классом: ");
            foreach (var i in linq5)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName} ");
            }
            Console.WriteLine();

            //------список абитуриентов, у которых сумма баллов выше заданной------
            Console.Write("Введите сумму - ");
            int writesum = int.Parse(Console.ReadLine());
            var linq6 = list.Where(item => (item.rating[0] + item.rating[1] + item.rating[2]) > writesum);
            foreach (var i in linq6)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName} ");
            }
            Console.WriteLine();

            //-----количество абитуриентов с 10-ками по определенному  предмету-----
            Console.WriteLine("Третий запрос с классом: ");
            var linq7 = list.Where(item => item.rating[0] == 10);
            int count = 0;
            foreach (var i in linq7)
            {
                count++;
            }
            Console.WriteLine($"Кол-во абитуриентов с 10-ками - {count}");

            //тот же самое
            //var linq77 = from item in list
            //             where item.rating[0] == 10
            //             select item;

            //------массив абитуриентов упорядоченных по алфавиту-------
            Console.WriteLine("Четвертый запрос с классом: ");
            var linq8 = list.OrderBy(item => item.FirstName);
            foreach (var i in linq8)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName} {i.rating[0]} {i.rating[1]} {i.rating[2]} ");
            }

            int summa = list.Sum(nn => nn.rating[0] + nn.rating[1] + nn.rating[2]); //агрегация

            //свой запрос
            var mylinq = from j in list
                         where (j.LastName).Contains('e') //условие
                         where summa >= 25 //условие и summa  через агрегацию
                         orderby j.FirstName //упорядочивание
                         group j by j.rating[0]; //группировка
            Console.WriteLine("Свой запрос: ");
            foreach (IGrouping<int, Abiturient> g in mylinq)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine(t.LastName);
                Console.WriteLine();
            }
            //JOIN
            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" }
            };
            List<Player> players = new List<Player>()
            {
                new Player {Name="Месси", Team="Барселона"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Роббен", Team="Бавария"}
            };

            var result = from pl in players
                         join t in teams on pl.Team equals t.Name
                         select new { Name = pl.Name, Team = pl.Team, Country = t.Country };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
            }

        }
    }
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}

