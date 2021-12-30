using System;
namespace LR4
{
    public partial class Array
    {
        public Owner user { get; set; } = new Owner("Антон", "Ноготочки_от_Антона");
        public int[] _array;
        private int length;

        public class Owner
        {
            private readonly int ID;
            private string Name;
            private string Corporation;

            public Owner(string n = "---", string c = "---")
            {
                Name = n;
                Corporation = c;
                ID = this.GetHashCode();
            }
        }
        public Array(int a = 777, int b = 666, int c = 555)
        {
            _array = new int[] { a, b, c };
            length = _array.Length;
        }
        public Array(int a = 777, int b = 666, int c = 555, int d = 444)
        {
           _array = new int[4] { a, b, c, d};
           length = _array.Length;
        }


        public static Array operator -(Array obj, int a) //разность со скалярным значением
        {
            var new_arr = obj;
            for (int i = 0; i < obj.length; i++)
            {
                new_arr._array[i] -= a;
            }
            return new_arr;
        }
        
        public static bool operator >(Array obj, int a) //проверка на вхождение элемента
        {
            var new_arr = obj._array;

            foreach (int e in new_arr)
            {
                if (e == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator <(Array obj, int a)//переопределяем, т.к. > < парные
        {
            return true;
        }

        public static string operator !=(Array obj1, Array obj2) // проверка на неравенство массивов
        {
            if (obj1.length != obj2.length)
            {
                return "массивы НЕ равны";
            }
            else
            {
                for (int i = 0; i < obj1.length; i++)
                {
                    if (obj1._array[i] != obj2._array[i])
                    {
                        return "массивы НЕ равны";
                    }
                }
                return "массивы равны";
            }
        }
        public static string operator ==(Array obj1, Array obj2) //переопределяем, т.к. != и ==  парные
        {
            return "";
        }

        public static int[] operator +(Array obj1, Array obj2) //объединение массивов
        {
            int size = obj1.length + obj2.length;
            int[] new_arr = new int[size];
            obj1._array.CopyTo(new_arr, 0);
            obj2._array.CopyTo(new_arr,obj1.length);

            return new_arr;
        }

    }
}