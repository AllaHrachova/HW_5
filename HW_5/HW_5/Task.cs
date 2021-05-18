using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_5
{
    class Task
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public int Complexity { get; set; }
        public int TotalTime { get; set; }
        List<Task> tasks = new List<Task>();
        List<Task> highprioritytasks = new List<Task>();
        List<Task> mediumprioritytasks = new List<Task>();
        List<Task> lowprioritytasks = new List<Task>();
        int anotherTask = 1;
        int hoursNumber;
        int minComplexity = 1;
        int maxComplexity = 3;
        public void AddTask()
        {
            do
            {
                Task task = new Task();
                Console.WriteLine("Введите имя задачи");
                task.Name = (Console.ReadLine());
                Console.WriteLine("Введите приоритет этой задачи: High - высокий, Medium - средний, Low - низкий");
                string inputPriority = Console.ReadLine();
                while ((inputPriority != "High") && (inputPriority != "Medium") && (inputPriority != "Low"))
                {
                    Console.WriteLine("Приоритет задачи должен быть следующим: High - высокий, Medium - средний, Low - низкий");
                    inputPriority = Console.ReadLine();
                }
                switch (inputPriority)
                {
                    case "High":
                        task.Priority = (int)PriorityLevels.High;
                        break;
                    case "Medium":
                        task.Priority = (int)PriorityLevels.Medium;
                        break;
                    case "Low":
                        task.Priority = (int)PriorityLevels.Low;
                        break;
                }
                Console.WriteLine("Введите сложность этой задачи: 1 - сложная, 2 - средняя, 3 - легкая");
                InputHelper GetTaskComplexity = new InputHelper(maxComplexity, minComplexity);
                int inputComplexity = GetTaskComplexity.Input;
                switch (inputComplexity)
                {
                    case 1:
                        task.Complexity = (int) ComplexityLevels.Difficult;
                        break;
                    case 2:
                        task.Complexity = (int)ComplexityLevels.Medium;
                        break;
                    case 3:
                        task.Complexity = (int)ComplexityLevels.Easy;
                        break;
                }
                Console.WriteLine("Еще есть задачи? 1 - да/0 - нет");
                InputHelper GetAnotherTask = new InputHelper();
                anotherTask = GetAnotherTask.Input;
                while ((anotherTask != 1) && (anotherTask != 0))
                {
                    Console.WriteLine("Еще есть задачи? 1 - да/0 - нет");
                    anotherTask = Convert.ToInt32(Console.ReadLine());
                }
                tasks.Add(task);
            }
            while (anotherTask == 1);
        }
        public int TimeCount()
        {
            TotalTime = 0;
            foreach (Task task in tasks)
            {
                TotalTime += task.Complexity;
            }
                return TotalTime;
        }
        public void SeparateTasksByPriority()
        {
            foreach (Task task in tasks)
            {
                switch (task.Priority)
                {
                    case 1:
                        highprioritytasks.Add(task);
                        break;
                    case 2:
                        mediumprioritytasks.Add(task);
                        break;
                    case 3:
                        lowprioritytasks.Add(task);
                        break;
                }
            }
        }
        public void PriorityList()
        {
            Console.WriteLine("Задачи с каким приоритетом показать (High, Medium, Low)?");
            string definedPriority = Console.ReadLine();
            while ((definedPriority != "High") && (definedPriority != "Medium") && (definedPriority != "Low"))
            {
                Console.WriteLine("Приоритет задачи должен быть следующим: High - высокий, Medium - средний, Low - низкий");
                definedPriority = Console.ReadLine();
            }
            switch (definedPriority)
            {
                case "High":
                    Console.WriteLine("Задачи с приоритетом High:");
                    foreach (Task task in highprioritytasks)
                    {
                        Console.WriteLine(task.Name);
                    }
                    break;
                case "Medium":
                    Console.WriteLine("Задачи с приоритетом Medium:");
                    foreach (Task task in mediumprioritytasks)
                    {
                        Console.WriteLine(task.Name);
                    }
                    break;
                case "Low":
                    Console.WriteLine("Задачи с приоритетом Low:");
                    foreach (Task task in lowprioritytasks)
                    {
                        Console.WriteLine(task.Name);
                    }
                    break;
            }
        }
        public void TasksForNDays()
        {
            Console.WriteLine("Введите количество дней, за которое нужно вывести список задач по приоритету");
            InputHelper SetHoursNumber = new InputHelper();
            hoursNumber = SetHoursNumber.Input * 8;
            Console.WriteLine("За " + SetHoursNumber.Input +" дней с учетом приоритета можно выполнить следующие задачи:");
            foreach (Task task in highprioritytasks)
            {
                if (hoursNumber >= task.Complexity)
                {
                    Console.WriteLine(task.Name);
                    hoursNumber -= task.Complexity;
                }
            }
            foreach (Task task in mediumprioritytasks)
            {
                if (hoursNumber >= task.Complexity)
                {
                    Console.WriteLine(task.Name);
                    hoursNumber -= task.Complexity;
                }
            }
            foreach (Task task in lowprioritytasks)
            {
                if (hoursNumber >= task.Complexity)
                {
                    Console.WriteLine(task.Name);
                    hoursNumber -= task.Complexity;
                }
            }
        }
    }    
}