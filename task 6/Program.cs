using System;
using System.Threading.Tasks;

namespace TaskManagerApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var taskManager = new TaskManager();

            while (true)
            {
                Console.WriteLine("""
                1. Add Task
                2. View Tasks
                3. View Tasks by Category
                4. Update Task Status
                5. Exit
                Select an option: 
                """);

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Name: ");
                            string? name = Console.ReadLine();
                            Console.Write("Description: ");
                            string? description = Console.ReadLine();
                            Console.Write("Category (0 - Personal, 1 - Work, 2 - Errands, 3 - Resting): ");
                            if (Enum.TryParse(Console.ReadLine(), out TaskCategory category))
                            {
                                var task = new TaskItem
                                {
                                    Name = name,
                                    Description = description,
                                    Category = category,
                                    IsCompleted = false
                                };
                                taskManager.AddTask(task);
                                await taskManager.SaveTasksAsync();
                                Console.WriteLine("Task added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid category.");
                            }
                            break;

                        case 2:
                            taskManager.ViewTasks();
                            break;

                        case 3:
                            Console.Write("Category (0 - Personal, 1 - Work, 2 - Errands, 3 - Other): ");
                            if (Enum.TryParse(Console.ReadLine(), out TaskCategory selectedCategory))
                            {
                                taskManager.ViewTasksByCategory(selectedCategory);
                            }
                            else
                            {
                                Console.WriteLine("Invalid category.");
                            }
                            break;

                        case 4:
                            Console.Write("Task Name: ");
                            string taskNameToUpdate = Console.ReadLine()!;
                            Console.Write("Is Completed (true/false): ");
                            if (bool.TryParse(Console.ReadLine(), out bool isCompleted))
                            {
                                if (taskManager.UpdateTaskStatus(taskNameToUpdate, isCompleted))
                                {
                                    await taskManager.SaveTasksAsync();
                                    Console.WriteLine("Task status updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Task not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for task status.");
                            }
                            break;

                        case 5:
                            return;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}
