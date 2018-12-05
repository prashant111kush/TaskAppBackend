using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entities;

namespace TaskCore.Services
{
    public interface ITaskService
    {
        IEnumerable<CoreTask> GetAllTasks();
        CoreTask CreateTask(string taskName, string taskDescription, DateTime taskDateTime, int taskPriority);
        CoreTask GetTask(Guid taskId);
        CoreTask UpdateTask(Guid taskId, string taskName, string taskDescription, DateTime taskDateTime, int taskPriority);
        void DeleteTask(Guid taskId);

    }
}
