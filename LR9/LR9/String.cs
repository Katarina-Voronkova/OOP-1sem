using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR9
{

    class StringDeformate
    {
        public string RemovePunctuationMarks(string str)
        {
            string PunctuatinMarks = ",.;:-!";
            for (int i = 0; i < str.Length; i++)
            {
                foreach (char PunctuationMark in PunctuatinMarks)
                    if (str[i] == PunctuationMark)
                        str = str.Remove(i, 1);
            }
            return str;
        }
        public string SpaceDelete(string str)
        {
            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ' && str[i + 1] == ' ')
                    str = str.Remove(i + 1, 1);
            return str;
        }
    }


}
