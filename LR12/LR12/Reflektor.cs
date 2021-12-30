using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LR12
{
    public static class Reflector
    {
        public static string Path = @"C:\Users\Катя\source\repos\LR12\12laba.txt";

        //1a
        public static void AssemblyName(Type type)
        {
            string Info1a = "Имя сборки: ";
            string NameType = type.Assembly.FullName;
            File.AppendAllText(Path, Info1a + NameType + "\n");
        }
        //1b
        public static void PublicConstructors(Type type)
        {
            string Info1b = "Есть ли публичные конструкторы: ";
            var ConstructorInfo = type.GetConstructors();
            if (ConstructorInfo.Length > 0)
                Info1b += "да\n";
            else
                Info1b += "нет\n";
            Info1b += "\n";
            File.AppendAllText(Path, Info1b);
        }
        //1c
        public static List<string> PublicMethods(Type type)
        {
            string Info1c = "Публичные методы: \n";
            List<string> PublicMethodsList = new List<string>();
            var AllMethods = type.GetMethods();
            foreach (var item in AllMethods)
            {
                PublicMethodsList.Add(item.Name);
                Info1c += item.Name + "\n";
            }
            if (PublicMethodsList.Count == 0)
                File.AppendAllText(Path, "Публичные методы: нет\n");
            else
                File.AppendAllText(Path, Info1c + "\n\n");
            return PublicMethodsList;
        }
        //1d
        public static List<string> FieldsandPropertiesInfo(Type type)
        {
            string Info1d = "Поля:\n";
            List<string> FieldsAndProperties = new List<string>();
            var FieldsArr = type.GetFields();
            foreach (FieldInfo item in FieldsArr)
            {
                FieldsAndProperties.Add(item.Name);
                Info1d += item.Name + '\n';

            }
            if (Info1d == "Поля:\n")
                Info1d = "Поля: нет\n";

            var Properties = type.GetProperties();

            Info1d += "Свойства: \n";
            var InfoFields = Info1d;
            foreach (var item in Properties)
            {
                FieldsAndProperties.Add(item.Name);
                Info1d += item.Name + '\n';
            }

            if (Info1d == InfoFields)
                Info1d = InfoFields.Remove(InfoFields.LastIndexOf('\n')) + " нет\n";
            File.AppendAllText(Path, Info1d);
            return FieldsAndProperties;
        }
        //1e
        public static List<string> Interfaces(Type type)
        {
            string Info1e = "Реализованные интерфейсы:\n";
            List<string> InterfacesList = new List<string>();

            var Interfaces = type.GetInterfaces();
            foreach (var item in Interfaces)
            {
                InterfacesList.Add(item.Name);
                Info1e += item.Name + '\n';
            }
            if (InterfacesList.Count == 0)
                File.AppendAllText(Path, "Реализованные интерфейсы: нет\n");
            else
                File.AppendAllText(Path, Info1e + "\n\n");
            return InterfacesList;
        }
        //1f
        public static void MethodsByParameterType(Type type, Type Parameter)
        {
            string Info1f = "Методы с типом параметра " + Parameter.Name + ":\n";
            string InfoStart = Info1f;

            var AllMethods = type.GetMethods();
            foreach (var item in AllMethods)
            {
                var ItemParameters = item.GetParameters();
                foreach (var itemparam in ItemParameters)
                {
                    if (itemparam.ParameterType == Parameter)
                    {
                        Info1f += item.Name + '\n';
                        break;
                    }
                }
            }
            if (InfoStart != Info1f)
                File.AppendAllText(Path, Info1f);
            else
                File.AppendAllText(Path, "Методы с типом параметра " + Parameter.Name + ": нет" + "\n");
        }
        public static object Invoke(object obj, string MethodName, params object[] Parameters)
        {
            Type type = obj.GetType();
            var Method = type.GetMethod(MethodName);
            var Result = Method.Invoke(obj, Parameters);
            return Result;
        }
        public static object Create<T>(params object[] param)
        {
            Type type = typeof(T);
            var constructors = type.GetConstructors();
            object Result = null;
            if (param == null)
            {
                foreach (var item in constructors)
                {
                    if ((item.GetParameters()).Length == 0)
                    {
                        Result = item.Invoke(null);
                        break;
                    }
                }
            }
            else
            {
                foreach (var items in constructors)
                {
                    if ((items.GetParameters()).Length == param.Length)
                    {
                        Result = items.Invoke(param);
                        break;
                    }
                }
            }
            return Result;
        }
    }
}
