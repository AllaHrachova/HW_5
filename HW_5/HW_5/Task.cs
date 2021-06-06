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
        List<Task> highPriorityTasks = new List<Task>();
        List<Task> mediumPriorityTasks = new List<Task>();
        List<Task> lowPriorityTasks = new List<Task>();

        public void AddTask()
        {
            int anotherTask = 1;
            do
            {
                Task task = new Task();
                Console.WriteLine("Введите имя задачи");
                task.Name = (Console.ReadLine());
                SetPriority();
                task.Priority = Priority;
                SetComplexity();
                task.Complexity = Complexity;
                Console.WriteLine("Еще есть задачи? 1 - да/0 - нет");
                InputHelper anotherTaskNeeded = new InputHelper();
                anotherTask = anotherTaskNeeded.Input;

                while ((anotherTask != 1) && (anotherTask != 0))
                {
                    Console.WriteLine("Еще есть задачи? 1 - да/0 - нет");
                    anotherTask = Convert.ToInt32(Console.ReadLine());
                }
                tasks.Add(task);
            }
            while (anotherTask == 1);
        }

        public int CountTotalTime()
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
                        highPriorityTasks.Add(task);
                        break;
                    case 2:
                        mediumPriorityTasks.Add(task);
                        break;
                    case 3:
                        lowPriorityTasks.Add(task);
                        break;
                }
            }
        }

        public void ShowPriorityList()
        {
            SeparateTasksByPriority();
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
                    foreach (Task task in highPriorityTasks)
                    {
                        Console.WriteLine(task.Name);
                    }
                    break;
                case "Medium":
                    Console.WriteLine("Задачи с приоритетом Medium:");
                    foreach (Task task in mediumPriorityTasks)
                    {
                        Console.WriteLine(task.Name);
                    }
                    break;
                case "Low":
                    Console.WriteLine("Задачи с приоритетом Low:");
                    foreach (Task task in lowPriorityTasks)
                    {
                        Console.WriteLine(task.Name);
                    }
                    break;
            }
        }

        public void DefineTasksForNDays()
        {
            Console.WriteLine("Введите количество дней, за которое нужно вывести список задач по приоритету");
            InputHelper setHoursNumber = new InputHelper();
            int hoursNumber = setHoursNumber.Input * 8;
            Console.WriteLine("За " + setHoursNumber.Input + " дней с учетом приоритета можно выполнить следующие задачи:");

            foreach (Task task in highPriorityTasks)
            {
                if (hoursNumber >= task.Complexity)
                {
                    Console.WriteLine(task.Name);
                    hoursNumber -= task.Complexity;
                }
            }

            foreach (Task task in mediumPriorityTasks)
            {
                if (hoursNumber >= task.Complexity)
                {
                    Console.WriteLine(task.Name);
                    hoursNumber -= task.Complexity;
                }
            }

            foreach (Task task in lowPriorityTasks)
            {
                if (hoursNumber >= task.Complexity)
                {
                    Console.WriteLine(task.Name);
                    hoursNumber -= task.Complexity;
                }
            }
        }

        void SetPriority()
        {
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
                    Priority = (int)PriorityLevels.High;
                    break;
                case "Medium":
                    Priority = (int)PriorityLevels.Medium;
                    break;
                case "Low":
                    Priority = (int)PriorityLevels.Low;
                    break;
            }
        }

        void SetComplexity()
        {
            int minComplexity = 1;
            int maxComplexity = 3;
            Console.WriteLine("Введите сложность этой задачи: 1 - сложная, 2 - средняя, 3 - легкая");
            InputHelper GetTaskComplexity = new InputHelper(maxComplexity, minComplexity);
            int inputComplexity = GetTaskComplexity.Input;

            switch (inputComplexity)
            {
                case 1:
                    Complexity = (int)ComplexityLevels.Difficult;
                    break;
                case 2:
                    Complexity = (int)ComplexityLevels.Medium;
                    break;
                case 3:
                    Complexity = (int)ComplexityLevels.Easy;
                    break;
            }
        }
    }
}