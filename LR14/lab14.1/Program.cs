using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab14._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle ball = new Circle(25);
            Circle sun = new Circle(143320);
            Circle eye = new Circle(5);
            ball.ShowInfo();
            var jball = Serializator.ToJson(ball);
            Console.WriteLine($"Serialized to Json:\n{jball}");
            Circle newball = Serializator.FromJson(jball);

            Serializator.ToSoap(eye);
            Serializator.fromSoap();

            Serializator.toBinary(sun);
            Serializator.FromBinary();

            Serializator.ToXml(newball);
            XDocument xdoc = XDocument.Load(@"D:\info\Circles.xml");
            XElement root = xdoc.Element("Circle");
            root.Add(new XAttribute("name", "New Ball"));
            xdoc.Save(@"D:\info\Circles.xml");
            Serializator.FromXml(); 
        }
    }
}
