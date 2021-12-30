namespace lab4
{
    public partial class Array
    {
        public Owner user { get; set; } = new Owner("Anton", "Google");
        private int[] _array;
        private int length;

        public class Owner
        {
            private readonly int ID;
            private string Name;
            private string Corporation;

            public Owner(string n = "unknown", string c = "unknown")
            {
                Name = n;
                Corporation = c;
                ID = GetRandom();
                //ID = this.GetHashCode();
            }
        }
        public Array(int a = 777, int b = 666, int c = 555)
        {
            _array = new int[3] { a, b, c };
            length = _array.Length;

        }
        public int[] push(int count)
        {
            _array[length + 1] = count;
            length++;
            return _array;
        }
        public static Array operator -(Array obj, Array inc) //разность со скалярным значением
        {
            var tmp = obj;
            int size = tmp.length < inc.length ? tmp.length : inc.length;
            for (int i = 0; i < size; i++)
            {
                tmp._array[i] -= inc._array[i];
            }
            return tmp;
        }
        public static bool operator <(Array obj, int inc)//сравнение
        {
            var tmp = obj;
            return true;
        }
        public static bool operator >(Array obj, int inc) //входит ли в массив элемент
        {
            var tmp = obj._array;
            foreach (int e in tmp)
            {
                if (e == inc)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Array obj, Array inc) // проверка на неравенство массивов
        {
            var tmp = obj;
            int size = tmp.length < inc.length ? tmp.length : inc.length;
            for (int i = 0; i < size; i++)
            {
                if (tmp._array[i] != inc._array[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator ==(Array obj, Array inc) //хз
        {
            var tmp = obj;
            return false;


        }
        public static Array operator +(Array obj, Array inc) //обьединение массивов
        {
            var tmp = obj;
            int size = tmp.length < inc.length ? tmp.length : inc.length;
            for (int i = 0; i < size; i++)
            {
                tmp._array[i] += inc._array[i];
            }
            return tmp;
        }
    }
}