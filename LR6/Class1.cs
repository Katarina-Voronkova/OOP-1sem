using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR6
{
    public partial class Laboratory
    {
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
}
