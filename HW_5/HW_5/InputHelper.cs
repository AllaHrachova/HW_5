using System;
using System.Collections.Generic;
using System.Text;

namespace HW_5
{
    class InputHelper
    {
        int input;

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

        public InputHelper(int max, int min)
        {
            do
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if ((input > max) || (input < min))
                    {
                        Console.WriteLine("Введите число от " + min + " до " + max);
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
            while ((input < min) || (input > max));
        }
    }
}