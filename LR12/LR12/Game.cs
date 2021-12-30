using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR12
{
    public class Game
    {
        public string Name_Game;
        public int HP;
        public Game(string name, int hp)
        {
            Name_Game = name;
            HP = hp;
        }
        public delegate void Operation(string namegame, int param);
        public event Operation Atack;// Событие атака. При вызове 2 параметра string&int
        public event Operation Treat;//Событие лечить

        public void atack(string namegame, int action)
        {
            if (Atack == null) //если не определен обработчик
            {
                Console.WriteLine("Инфы об атаке нет");
                HP = HP - action;
            }
            else
            {
                Atack(namegame, action);
                HP = HP - action;
            }
        }
        public void treat(string namegame, int recovery)
        {
            if (Treat == null)
            {
                Console.WriteLine("Инфы о лечении нет");
                HP = HP + recovery;
            }
            else
            {
                Treat(namegame, recovery);
                HP = HP + recovery;
            }
        }

    }
}
