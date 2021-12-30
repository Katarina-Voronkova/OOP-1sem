using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR6
{

    struct Buyer
    {
        public string name;
        public string surname;

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}  Surname: {surname}");
        }
    }
    enum EControl
    {
        Computer,
        Tablet,
        Scaner,
        Printer,
    }


    class Product
    {
        public void Buy(Technic technic)
        {
            technic.Buy();
        }

    }
    public abstract class Technic
    {
        public int srok { get; set; }
        public int price { get; set; }
        public abstract void Number();
        public virtual void Buy()
        {
            Console.WriteLine("Совершена покупка");
        }
    }
    public class Computer : Technic
    {
        public string Firm;
        public Computer() { }
        public Computer(string Firm, int price, int srok)
        {
            this.Firm = Firm;
            this.price = price;
            this.srok = srok;
            if (srok > 20)
            {
                throw new ComputerException("Срок службы компьютера не может быть больше 20 лет");
            }
        }
        public string str1 = "первый";
        public override void Buy()
        {
            base.Buy();
            Console.WriteLine("Куплен компьютер");
        }
        public void MouseAndClava()
        {
            Console.WriteLine("У меня есть мышь и клавиатура");
        }

        public override void Number()
        {
            Console.WriteLine(str1);
        }
        public override string ToString()
        {
            return "комп";
        }
    }
    public class Tablet : Technic, ISale, IPodarok
    {
        public string str2 = "второй";
        public string Firm;
        public Tablet() { }
        public Tablet(string Firm, int srok, int price)
        {
            this.Firm = Firm;
            this.srok = srok;
            this.price = price;

            if (price < 100)
                throw new TabletException("Стоимость планшета не может быть меньше 100", price);
            else
                this.price = price;

        }
        public override void Buy()
        {
            base.Buy();
            Console.WriteLine("Куплен планшет");

        }
        public void Sensor()
        {
            Console.WriteLine("У меня сенсорный экран");
        }
        void ISale.podarok()
        {
            Console.WriteLine("podarok1");
        }
        void IPodarok.podarok()
        {
            Console.WriteLine("podarok2");
        }
        
        public override void Number()
        {
            Console.WriteLine(str2);
        }
        public override string ToString()
        {
            return "планшет";
        }
    }
    public class Scaner : Technic
    {
        public string Firm;
        public string str3 = "третий";
        public int count = 3;

        public Scaner() { }
        public Scaner(string Firm, int price, int srok)
        {

            this.srok = srok;
            this.price = price;
            if (this.Firm == null)
            {
                throw new ScanerException("Отсутствует имя фирмы");
            }
            else
                this.Firm = Firm;
        }

        public override void Buy()
        {
            base.Buy();
            Console.WriteLine("Куплен сканер");
        }

        public override void Number()
        {
            Console.WriteLine(str3);
        }

        public void YaCopy()
        {
            Console.WriteLine("Могу копировать");
        }
        public override string ToString()
        {
            return "сканер";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + count;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
    public sealed class Printer : Technic
    {

        public string str4 = "четвертый";
        public override void Buy()
        {
            base.Buy();
            Console.WriteLine("Куплен принтер");
        }

        public override void Number()
        {
            Console.WriteLine(str4);

        }

        public void YaPrint()
        {
            Console.WriteLine("Могу печатать");
        }
        public override string ToString()
        {
            return "принтер";
        }
    }
    interface ISale

    {
        void podarok();
    }
    interface IPodarok
    {
        void podarok();
    }

    class Print
    {
        public virtual void IAmPrinting(object someObj)
        {
            Console.WriteLine(someObj.GetType().Name);
        }
    }
    public class Laboratory
    {
        public List<object> Elements = new List<object>();
        public void Add(Computer Technic)
        {

            Technic.srok = 8;
            Technic.price = 1800;
            Elements.Add(Technic);
        }

        public void Add(Tablet Technic)
        {
            Technic.price = 1200;
            Technic.srok = 5;
            Elements.Add(Technic);
        }
        public void Add(Scaner Technic)
        {
            Technic.price = 1500;
            Technic.srok = 4;
            Elements.Add(Technic);
        }
        public void Add(Scaner Technic, int srok, int price)
        {
            Technic.price = price;
            Technic.srok = srok;
            Elements.Add(Technic);
        }
        public void Add(Printer Technic)
        {
            Technic.price = 950;
            Technic.srok = 2;
            Elements.Add(Technic);
        }

        public void Delete(int index)
        {
            Elements.Remove(index);
        }
        public void Print()
        {
            foreach (object obj in Elements)
                Console.WriteLine(obj);
        }
    }
    public class LaboratoryController
    {
        public void ServiceLife(Laboratory laboratory1)
        {
            Console.WriteLine("Введите срок службы: ");
            int service = Convert.ToInt32(Console.ReadLine());
            foreach (object obj in laboratory1.Elements)
            {

                if (((Technic)obj).srok > service)
                {
                    Console.WriteLine(obj.ToString());
                }
            }
        }
        public void PriceDecrease(Laboratory laboratory1)
        {
            var sorted = from element in laboratory1.Elements
                         orderby ((Technic)element).price
                         descending
                         select element;
            foreach (object obj in sorted)
            {
                Console.WriteLine(((Technic)obj).ToString());
            }
        }
        public void Counter(Laboratory laboratory1)
        {
            int count1 = 0, count2 = 0, count3 = 0, count4 = 0;
            foreach (var obj in laboratory1.Elements)
            {
                if (obj is Computer)
                {
                    count1++;
                }
                else if (obj is Tablet)
                {
                    count2++;
                }
                else if (obj is Scaner)
                {
                    count3++;
                }
                else if (obj is Printer)
                {
                    count4++;
                }
            }
            Console.WriteLine("Компьютеров - " + count1);
            Console.WriteLine("Планшетов - " + count2);
            Console.WriteLine("Сканеров - " + count3);
            Console.WriteLine("Принтеров - " + count4);
        }
    }
    //отсюдаааа
    public class ComputerException : Exception//Базовый тип для всех типов исключений
    {
        public ComputerException(string message) : base(message)
        {

        }
    }
    public class TabletException : ArgumentException//передается некорректное значение параметра для метода
    {

        public TabletException(string message, int price) : base(message)
        {
            Console.WriteLine("Некорректное значение: " + price);
        }
    }
    public class ScanerException : NullReferenceException//при попытке обращения к объекту, который равен null
    {
        public ScanerException(string message) : base(message)
        {

        }
    }
}

