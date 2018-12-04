using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entities;

namespace TaskCore.Services
{
    public interface ITaskRepositoryService
    {
        List<CoreTask> GetAllTasks();
        CoreTask SaveTask(string taskName, string taskDescription, DateTime taskDateTime, int taskPriority);
        CoreTask GetTask(Guid taskId);
    }
}
