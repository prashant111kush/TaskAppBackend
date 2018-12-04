using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAppBackend.Models;
using TaskCore.Entities;

namespace TaskAppBackend.Converters
{
    public class ConvertCoreTaskToTaskModel
    {
        internal static TaskViewModel ConvertToTaskModel(CoreTask coreTask)
        {
            if (coreTask == null)
            {
                return null;
            }
            var taskModel = new TaskViewModel()
            {
                TaskId = coreTask.TaskId,
                TaskName = coreTask.TaskName,
                TaskDateTime = coreTask.TaskDateTime,
                TaskDescription = coreTask.TaskDescription,
                TaskPriority = coreTask.TaskPriority
            };
            return taskModel;
        }
    }
}
