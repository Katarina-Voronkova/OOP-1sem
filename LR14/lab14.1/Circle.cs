using System;

namespace lab14._1
{
    [Serializable]
    public sealed class Circle : Figure, Geometry
    {
        public double area { get; set; }
        //[NonSerialized]
        public double perimeter;
        public double radius { get; set; }
        public string color { get; set; }

        public Circle() 
        {
            radius = 3;
            color = Color();
            perimeter = Perimeter();
            area = Area();
        }

        public Circle(double r)
        {
            radius = r;
            color = Color();
            perimeter = Perimeter();
            area = Area();
        }
        public double Perimeter()
        {
            double per = Math.PI * 2 * radius;
            return per;
        }
        public double Area()
        {
            double ar = Math.PI *Math.Pow(radius,2);
            return ar;
        }

        override public void ShowInfo()
        {
            if (this != null)
            {
                Console.WriteLine($"Circle \n1)Area: {area} \n2)Perimeter: {perimeter} \n3)Radius: {radius} \n4)Color: {color}");
            }
            else
            {
                Console.WriteLine("Incorrect data for Circle!");
            }
        }

        public override string ToString()
        {

            return "Circle override";
        }

    }
    
    public interface Geometry
    {
        double Perimeter();
        double Area();

    }
    [Serializable]
    public abstract class Figure
    {
        public abstract void ShowInfo();
        public virtual string Color()
        {
            int pos = rand.Next(0, 7);
            string c = coloration[pos];
            return c;
        }
        public override string ToString()
        {
            return "Figure override";
        }
        public static string[] coloration = { "cyan", "blue", "green", "yellow", "red", "orange", "purple" };
        public static Random rand = new Random();

    }
}


