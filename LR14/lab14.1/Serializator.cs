using System.Text.Json;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace lab14._1
{
    static class Serializator
    {
        #region JSON
        public static string ToJson(Circle obj)
        {
            var jstr = JsonConvert.SerializeObject(obj);
            return jstr;
        }

        public static Circle FromJson(string obj) 
        {
            return JsonConvert.DeserializeObject<Circle>(obj); ; 

        }
        #endregion  

        #region SOAP
        public static void ToSoap(Circle obj)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream(@"D:\info\Circles.soap", FileMode.Append))
            {
                formatter.Serialize(fs, obj);
                Console.WriteLine("Serialized to Soap");
            }
        }

        public static void fromSoap() 
        {
            using (FileStream fs = new FileStream(@"D:\info\Circles.soap", FileMode.OpenOrCreate))
            {
                SoapFormatter formatter = new SoapFormatter();
                Circle newCircles = (Circle)formatter.Deserialize(fs);

                Console.WriteLine($"Deserialized from Soap");
                newCircles.ShowInfo();
            }
        }
        #endregion

        #region XML
        public static void ToXml(Circle obj)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Circle));

            using (FileStream fs = new FileStream(@"D:\info\Circles.xml", FileMode.Append))
            {
                formatter.Serialize(fs, obj);

                Console.WriteLine("Serialized to xml");
            }
        }

        public static void FromXml()
        { 
            XmlSerializer formatter = new XmlSerializer(typeof(Circle));

            using (FileStream fs = new FileStream(@"D:\info\Circles.xml", FileMode.OpenOrCreate))
            { 
                Circle newCircles = (Circle)formatter.Deserialize(fs);
                Console.WriteLine("Deserialized from xml:");
                newCircles.ShowInfo();
                
            }
        }
        #endregion

        #region BINARY
        public static void toBinary(Circle obj) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"D:\info\Circles.dat", FileMode.Append))
            {
                formatter.Serialize(fs, obj);

                Console.WriteLine("Serialized to Binary");
            }
        }

        public static void FromBinary()
        { 
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"D:\info\Circles.dat", FileMode.OpenOrCreate))
            {
               Circle newcircles = (Circle)formatter.Deserialize(fs);
                Console.WriteLine("Deserialized from Binary:");
                newcircles.ShowInfo();
                
            }
            
            }
            #endregion
        }
}
