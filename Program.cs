namespace ToDoList;

class Program
{
    private const string FilePath = "/home/toni/RiderProjects/ToDoList/tasks.txt";
    private static List<string> _tasks = new List<string>();
    static void Main()
    {
        bool active = true;
        LoadTasks();

        while (active)
        {
            Console.WriteLine("--TO-DO LIST--");
            ShowTasks();

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1 - Add Task");
            Console.WriteLine("2 - Mark Task as Done");
            Console.WriteLine("3 - Delete Task");
            Console.WriteLine("4 - Save Tasks and exit");

            Console.Write("\nChoose: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2" :
                    MarkTaskAsDone();
                    break;
                case "3":
                    DeleteTask();
                    break;
                case "4":
                    SaveTasks();
                    Console.WriteLine("All tasks have been successfully saved. \nSee you later!");
                    active = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void LoadTasks()
    {
        if (File.Exists(FilePath))
        {
            _tasks = new List<string>(File.ReadAllLines(FilePath));
        }
    }

    static void SaveTasks()
    {
        File.WriteAllLines(FilePath, _tasks);
    }

    static void ShowTasks()
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("No tasks found");
        }

        for (int i = 0; i < _tasks.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_tasks[i]}");
        }
    }

    static void AddTask()
    {
        Console.Write("Add new task: ");
        string? newTask = Console.ReadLine();
        _tasks.Add("[ ]" + newTask);
    }

    static void MarkTaskAsDone()
    {
        Console.Write("Enter the task number to mark the task as done: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) &&  taskNumber >= 1 && taskNumber <= _tasks.Count)
        {
            _tasks[taskNumber - 1] = $"[ ] {_tasks[taskNumber - 1]}";
        }
        else
        {
            Console.WriteLine("invalid task number!");
            Console.ReadKey();
        }
    }
    
    static void DeleteTask()
    {
        Console.Write("Enter the task number to delete the task: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) &&  taskNumber >= 1 && taskNumber <= _tasks.Count)
        {
            _tasks[taskNumber - 1] = $"[ ] {_tasks[taskNumber - 1]}";
        }
        else
        {
            Console.WriteLine("invalid task number!");
            Console.ReadKey();
        }
    }
}
