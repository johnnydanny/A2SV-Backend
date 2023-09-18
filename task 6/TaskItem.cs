using System;

namespace TaskManagerApp
{
    enum TaskCategory
    {
        Personal,
        Work,
        Errands,
        Resting
    }

    class TaskItem
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TaskCategory Category { get; set; }
        public bool IsCompleted { get; set; }
    }
}
