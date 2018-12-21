using System;

namespace TaskCore.Entities
{
    public class CoreTask
    {
        public Guid TaskId { get; }
        public string TaskName { get; }
        public string TaskDescription { get; }
        public DateTime TaskDateTime { get; }
        public int TaskPriority { get; }

        public CoreTask(Guid taskId, string taskName, string taskDescription, DateTime taskDateTime, int taskPriority)
        {
            if (taskId.Equals(Guid.Empty))
            {
                throw new ArgumentException("task Id cannot be empty.");
            }
            if (string.IsNullOrEmpty(taskName))
            {
                throw new ArgumentNullException(taskName, $"task name should not be null or empty.");
            }
            if (taskName?.Length > 40 || taskName?.Length < 5)
            {
                throw new ArgumentException("task name should be between 5 and 40 characters.");
            }
            if (taskDescription?.Length > 200)
            {
                throw new ArgumentException("task description should not be more than 200 characters.");
            }
            if (taskPriority < 1 || taskPriority > 5)
            {
                throw new ArgumentException("task priority should be between 1 and 5.");
            }
            TaskId = taskId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskDateTime = taskDateTime;
            TaskPriority = taskPriority;
        }
    }
}