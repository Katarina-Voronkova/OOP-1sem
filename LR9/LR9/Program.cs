using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR9
{
    class Program
    {
        public delegate int Sum(int x, int y);
        static void Main(string[] args)
        {
            #region prosto tak
            int Summa(int a, int b)
            {
                return a + b;
            }
            Sum delegatesum = Summa;
            Sum wqe = new Sum(Summa);
            delegatesum += Summa;
            int result = delegatesum(4, 5);

            #endregion
            Game[] Games = new Game[5];
            Games[0] = new Game("game1", 15);
            Games[1] = new Game("game2", 13);
            Games[2] = new Game("game3", 8);
            Games[3] = new Game("game4", 18);
            Games[4] = new Game("game5", 3);

            Games[0].Atack += (namegame, action) => Console.WriteLine($"В игре {namegame} произошла атака на {action} очков"); //подписка на событие
            Games[0].Treat += (namegame, recovery) => Console.WriteLine($"В игре {namegame} произошло лечение на {recovery} очков");


            Random rand_ = new Random();
            Games[0].atack(Games[0].Name_Game, rand_.Next(0, 20));
            Games[0].atack(Games[0].Name_Game, rand_.Next(0, 20));
            Games[0].treat(Games[0].Name_Game, rand_.Next(0, 20));
            Console.WriteLine("Сведения после окончания " + Games[0].Name_Game + " " + "HP - " + Games[0].HP);


            Games[1].atack(Games[1].Name_Game, rand_.Next(0, 20));
            Games[1].treat(Games[1].Name_Game, rand_.Next(0, 20));
            Games[1].treat(Games[1].Name_Game, rand_.Next(0, 20));
            Console.WriteLine("Сведения после окончания " + Games[1].Name_Game + " " + "HP - " + Games[1].HP);


            //--------------------------------------------------------------
            string strochka = "rdfaasdv  QAZ!";
            StringDeformate str = new StringDeformate();

            Func<string, string> delegat_stroka = str1 => str1.ToLower();// В нижний регистр
            strochka = delegat_stroka(strochka);
            Console.WriteLine(strochka);

            //
            delegat_stroka += str1 => str1.ToUpper();//Верхний регистр
            strochka = delegat_stroka(strochka);
            Console.WriteLine(strochka);
            //
            delegat_stroka += str.RemovePunctuationMarks;// убрать пунктуацию
            strochka = delegat_stroka(strochka);
            Console.WriteLine(strochka);
            //
            delegat_stroka += str.SpaceDelete;//Убрать лишний проблеы
            strochka = delegat_stroka(strochka);
            Console.WriteLine(strochka);
            //
            Func<string, char, string> NOTPARAMS = (str1, ch) => str1 += ch;
            strochka = NOTPARAMS(strochka, 'V');//Добавление символа
            Console.WriteLine(strochka);
        }

    }
}
