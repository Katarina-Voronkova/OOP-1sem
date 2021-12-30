using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR11
{
    class Abiturient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int[] rating = new int[3];

        public Abiturient(string firstname, string lastname, int a, int b, int c)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.rating[0] = a;
            this.rating[1] = b;
            this.rating[2] = c;
        }
    }
}
