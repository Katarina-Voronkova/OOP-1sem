using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace LR12
{
    class Program
    {
        static void Main(string[] args)
        {
            //1a
            Reflector.AssemblyName(typeof(Game));
            //1b
            Reflector.PublicConstructors(typeof(Abiturient));
            //1c
            Reflector.PublicMethods(typeof(Abiturient));
            //1d
            Reflector.FieldsandPropertiesInfo(typeof(Game));
            //1e
            Reflector.Interfaces(typeof(Abiturient));
            //1f
            Reflector.MethodsByParameterType(typeof(Abiturient), typeof(string));
            //1g
            Game game = new Game("game1", 555);
            game.Atack += (string namegame, int action) => Console.WriteLine($"В игре {namegame} произошла атака на {action} очков");
            object[] arr = { "game", 23 }; //массив параметров
            Reflector.Invoke(game, "atack", arr);
            //2
            object[] param = { "s", "k", "l", "city", "999", Guid.NewGuid(), 8, 7, 9 };
            var objconstruct = Reflector.Create<Abiturient>(param);
            Console.WriteLine(objconstruct);
        }


    }
}
