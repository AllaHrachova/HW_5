using System;
using System.Collections.Generic;

namespace HW_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Task Task1 = new Task();
            Task1.AddTask();
            Task1.TimeCount();
            Console.WriteLine("Для выполнения всех задач всего нужно " + Task1.TotalTime + " часов");
            Task1.SeparateTasksByPriority();
            Task1.PriorityList();
            Console.WriteLine(Task1.Name);
            Task1.TasksForNDays();
        }
    }
}
