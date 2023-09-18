    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

namespace TaskManagerApp
{
    class TaskManager
    {
        private readonly List<TaskItem> tasks = new List<TaskItem>();
        private readonly string taskFilePath = "tasks.csv";

        public TaskManager()
        {
            LoadTasksAsync().Wait();
        }

        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
        }

        public void ViewTasks()
        {
            Console.WriteLine("Tasks:");
          
            foreach (var task in tasks)
            {
                Console.WriteLine($"""
                    Name: {task.Name}
                    Description: {task.Description}
                    Category: {task.Category}
                    Completed: {task.IsCompleted}
                """);
                Console.WriteLine();
            }
        }

        public void ViewTasksByCategory(TaskCategory category)
        {
            var filteredTasks = tasks.Where(task => task.Category == category).ToList();
            if (filteredTasks.Count == 0)
            {
                Console.WriteLine($"No {category} tasks found.");
            }
            else
            {
                Console.WriteLine($"{category} Tasks:");
                foreach (var task in filteredTasks)
                {
                    Console.WriteLine($"""
                        Name: {task.Name}
                        Description: {task.Description}
                        Completed: {task.IsCompleted}
                """);
                    Console.WriteLine();
                }
            }
        }

        public async Task SaveTasksAsync()
        {
            using (StreamWriter writer = new StreamWriter(taskFilePath))
            {
                foreach (var task in tasks)
                {
                    await writer.WriteLineAsync($"{task.Name},{task.Description},{(int)task.Category},{task.IsCompleted}");
                }
            }
        }

        private async Task LoadTasksAsync()
        {
            if (File.Exists(taskFilePath))
            {
                using (StreamReader linestream = new StreamReader(taskFilePath))
                {
                    string? line;
                    while ((line = await linestream.ReadLineAsync()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 4)
                        {
                            var task = new TaskItem
                            {
                                Name = parts[0],
                                Description = parts[1],
                                Category = (TaskCategory)Enum.Parse(typeof(TaskCategory), parts[2]),
                                IsCompleted = bool.Parse(parts[3])
                            };
                            tasks.Add(task);
                        }
                    }
                }
            }
        }

        public bool UpdateTaskStatus(string taskName, bool isCompleted)
        {
            var task = tasks.FirstOrDefault(t => t.Name == taskName);
            if (task != null)
            {
                task.IsCompleted = isCompleted;
                return true;
            }
            return false;
        }
    }
}