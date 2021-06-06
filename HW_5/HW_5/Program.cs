using System;
using System.Collections.Generic;

namespace HW_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task();
            task1.AddTask();
            task1.CountTotalTime();
            Console.WriteLine("Для выполнения всех задач всего нужно " + task1.TotalTime + " часов");
            task1.ShowPriorityList();
            Console.WriteLine(task1.Name);
            task1.DefineTasksForNDays();
        }
    }
}
