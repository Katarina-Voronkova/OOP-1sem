using System;

namespace LR4
{
    public partial class Array
    {
        class Date
        {
            private string time;
            public Date()
            {
                time = "20.10.2021г";
            }
            public void GetDate()
            {
                Console.WriteLine(time);
            }
        }
    }
}