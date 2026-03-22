using System;
using System.Collections.Generic;
using System.IO;

class TodoApp
{
    static List<string> tasks = new List<string>();
    static string filePath = "tasks.txt";

    static void Main()
    {
        LoadTasks();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== TO-DO LIST ===");
            Console.WriteLine("1. View Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewTasks();
                    break;

                case "2":
                    AddTask();
                    break;

                case "3":
                    DeleteTask();
                    break;

                case "4":
                    SaveTasks();
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    Pause();
                    break;
            }
        }
    }

    static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            tasks = new List<string>(File.ReadAllLines(filePath));
        }
    }

    static void SaveTasks()
    {
        File.WriteAllLines(filePath, tasks);
    }

    static void ViewTasks()
    {
        Console.WriteLine("\n--- Your Tasks ---");

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks yet!");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        Pause();
    }

    static void AddTask()
    {
        Console.Write("\nEnter new task: ");
        string task = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(task))
        {
            tasks.Add(task);
            Console.WriteLine("Task added!");
        }
        else
        {
            Console.WriteLine("Task cannot be empty!");
        }

        Pause();
    }

    static void DeleteTask()
    {
        ViewTasks();

        Console.Write("\nEnter task number to delete: ");
        int index;

        if (int.TryParse(Console.ReadLine(), out index))
        {
            if (index > 0 && index <= tasks.Count)
            {
                tasks.RemoveAt(index - 1);
                Console.WriteLine("Task deleted!");
            }
            else
            {
                Console.WriteLine("Invalid task number!");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number!");
        }

        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}