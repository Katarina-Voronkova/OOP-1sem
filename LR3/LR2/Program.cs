using System;

namespace LR2
{
//    Создать класс Airline: Cодержит : Пункт назначения,
//Номер рейса, Тип самолета, Время вылета, Дни недели.
//Создать массив объектов.Вывести:
//a) список рейсов для заданного пункта назначения;
//b) список рейсов для заданного дня недели

    public partial class Program
    {
        class Airline
        {
            private string punkt_kuda; 
            private int? number_reisa;
            private string tip_samoleta;
            private string departureTime;
            private string day;
            private readonly int? id;//ПОЛЕ ТОЛьКО ДЛЯ ЧТЕНИЯ
            private const string airlineName = "S7 Airlines";//поле-константа
            private static int count = 0;//для количества созданных объектов

            static Airline()
            {
                Console.WriteLine("Отработал статический конструктор");
            }

            #region св-ва
            public string Name//только для чтения
            {
                get
                {
                    return airlineName;
                }
            }
            public string type_of_place//только для записи
            {
                set
                {
                    type_of_place = value;
                }
            }
            #endregion

            private Airline()  //ЗАКРЫТЫЙ конструктор без параметров
            {
                punkt_kuda = "---";
                number_reisa = null;
                tip_samoleta = "---";
                departureTime = "---";
                day = "---";
                id = null;
            }
            public Airline(string city)  //c 1 параметром
            {
                punkt_kuda = city;
                number_reisa = null;
                tip_samoleta = "---";
                departureTime = "---";
                day = "---";
                id = null;
            }
            public Airline(string city, int number, string tip, string time, string d) // с 5 параметрами
            {
                punkt_kuda = city;     
                number_reisa = number;
                tip_samoleta = tip;
                departureTime = time;
                day = d;
                id = city.GetHashCode() + time.GetHashCode();//для поля только для чтения
                count++;
            }
            public Airline(string city, int number, string d = "рабочий")  //c параметром по умолчанию
            {
                punkt_kuda = city;
                number_reisa = number;
                tip_samoleta = "---";
                departureTime = "---";
                day = d;

            }

            public static void Info(Airline obj)
            {
                Console.WriteLine("\nИнформация:");
                Console.WriteLine($"\tпункт назначения: {obj.punkt_kuda}\n\tномер рейса: {obj.number_reisa}\n\tтип самолёта: {obj.tip_samoleta}");
                Console.WriteLine($"\tвремя вылета:{obj.departureTime}\n\tдень недели: {obj.day}\n\tID: {obj.id}\n");

            }

            public static void Change(ref Airline obj)
            {
                obj.punkt_kuda = "Disney";
            }

            static void Sum(int x, int y, out int a)
            {
                a = x + y;
            }
            //переопределить метод класса Object: Equals
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                if (obj.GetType() != this.GetType()) return false;
                Airline a = (Airline)obj;
                return (this.punkt_kuda == a.punkt_kuda);
            }

            public override int GetHashCode()//
            {
                return base.GetHashCode();
            }
            public static void DayCheck(object[] arr, string buff)
            {
                foreach (Airline e in arr)
                {
                    if (e.day == buff)
                        Console.WriteLine($"У нас есть рейс в {e.punkt_kuda} в {buff}");
                }
            }

            public static void PlaceCheck(object[] arr, string buff)
            {
                foreach (Airline e in arr)
                {
                    if (e.punkt_kuda == buff)
                        Console.WriteLine($"Перелет в {e.punkt_kuda} запланирован на {e.day}");
                }
            }
        }
        static void Main(string[] args)
        {
            Airline Prague = new Airline("Прага", 759211, "A310", "13:15", "пн");
            Airline Vilnius = new Airline("Вильнюс", 228322, "The Lastochka", "8:00", "вт");
            Airline Berlin = new Airline("Берлин", 683190, "A280", "19:40", "ср");
            Airline Beijing = new Airline("Пекин", 759211, "A310", "23:50", "чт");
            var Tokyo = new { punkt_kuda = "Токио", number_reisa = 915638, tip_samoleta = "А712", departureTime = "16:10", day = "пт" };
            object[] arr = { Prague, Vilnius, Berlin, Beijing};
            string buff;

            Console.WriteLine("Введите день недели:");
            buff = Console.ReadLine();
            Airline.DayCheck(arr, buff);

            Console.WriteLine("Куда вы хотите отправиться?");
            buff = Console.ReadLine();
            Airline.PlaceCheck(arr, buff);

            
            Airline.Info(Prague);
            Airline.Info(Vilnius);

            Program.Services();

            Airline.Change(ref Prague);
            Airline.Info(Prague);

            Console.WriteLine(Prague.Equals(Vilnius));

            Airline a1 = new Airline("Минск");
            Airline a2 = new Airline("Минск");
            Console.WriteLine(a1.Equals(a2));

            Console.WriteLine(a1.GetType());


        }
    }
}