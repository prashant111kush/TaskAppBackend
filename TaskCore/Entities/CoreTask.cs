using System;

namespace TaskCore.Entities
{
    public class CoreTask
    {
        public Guid TaskId { get; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDateTime { get; }
        public int TaskPriority { get; set; }

        public CoreTask(Guid taskId, string taskName, string taskDescription, DateTime taskDateTime, int taskPriority)
        {
            TaskId = taskId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskDateTime = taskDateTime;
            TaskPriority = taskPriority;
        }
    }
}