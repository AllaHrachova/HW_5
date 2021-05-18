using System;
using System.Collections.Generic;
using System.Text;

namespace HW_5
{
    class InputHelper
    {
        public int input;
        public int max;
        public int min;
        public int Input
        {
            get
            {
                return input;
            }
            set
            {
                input = value;
            }
        }
        public int Max
        {
            get
            {
                return max;
            }
            set
            {
                max = value;
            }
        }
        public int Min
        {
            get
            {
                return min;
            }
            set
            {
                min = value;
            }
        }
        public InputHelper()
        {
            do
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод. Введите натуральное число");
                    input = -1;
                }
            }
            while (input < 0);
        }
        public InputHelper(int Max, int Min)
        {
        do
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if ((input > Max) || (input < Min))
                    {
                        Console.WriteLine("Введите число от " + Min + " до " + Max);
                    }
                    else
                    {
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод. Введите натуральное число");
                    input = 0;
                }
            }
            while ((input < Min) || (input > Max));
        }
    }
}