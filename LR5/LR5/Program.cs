using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5
{
    class Product
    {
        public void Buy(Technic technic)
        {
            technic.Buy();
        }

    }
    abstract class Technic
    {
        public abstract void Number();
        public virtual void Buy()
        {
            Console.WriteLine("Совершена покупка");
        }
    }
    class Computer : Technic
    {
        private string str1 = "1 покупка";
        public override void Buy()
        {
            base.Buy();//из первоначального будет выведено совершена покупка
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
            return "Использован метод ToString()";
        }
    }
    
    class Tablet : Technic, ISale, IPodarok
    {
        private string str2 = "2 покупка";
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
            return "Использован метод ToString()";
        }
    }
    class Scaner : Technic
    {
        private string str3 = "3 покупка";
        private int count = 3;
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
            return "Использован метод ToString()";
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
    sealed class Printer : Technic
    {
        private string str4 = "4 покупка";
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
            return "Использован метод ToString()";
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
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();

            Computer computer = new Computer();
            product.Buy(computer);
            computer.MouseAndClava();
            Console.WriteLine();

            Tablet tablet = new Tablet();
            product.Buy(tablet);
            tablet.Sensor();
            ((ISale)tablet).podarok();
            ((IPodarok)tablet).podarok();
            Console.WriteLine();

            Scaner scaner = new Scaner();
            product.Buy(new Scaner());
            scaner.YaCopy();
            Console.WriteLine();

            Printer printer = new Printer();
            product.Buy(new Printer());
            printer.YaPrint();
            printer.Number();
            Console.WriteLine(printer.ToString());
            Console.WriteLine();

            Console.WriteLine(tablet is Technic);//проверили допустимость преобразования
            Console.WriteLine(tablet.GetType());

            object obj = new Computer();
            Computer cmp = obj as Computer;
            if (cmp == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            //else 
            //{
            //    Console.WriteLine((obj as Computer).GetType());
            //}
            Console.WriteLine(obj.GetType().Name);
            Console.WriteLine();

            Technic[] arrobject = { new Tablet(), new Computer(), new Scaner() };
            Print print = new Print();
            print.IAmPrinting(arrobject[0]);
            print.IAmPrinting(arrobject[1]);
            print.IAmPrinting(arrobject[2]);
        }
    }

}