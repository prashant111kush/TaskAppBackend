using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAppBackend.Converters;
using TaskAppBackend.Models;
using TaskCore.Services;

namespace TaskAppBackend.Services
{
    public class TaskSevice
    {
        private readonly ITaskRepositoryService _taskRepositoryService;
        public TaskSevice(ITaskRepositoryService taskRepositoryService)
        {
            _taskRepositoryService = taskRepositoryService;
        }

        internal IEnumerable<TaskViewModel> GetAllTasks()
        {
            var coreTaskList = _taskRepositoryService.GetAllTasks();
            var taskModelList = coreTaskList.Select(ConvertCoreTaskToTaskModel.ConvertToTaskModel);
            return taskModelList;
        }

        public  TaskViewModel CreateTask(string taskName, string taskDescription, DateTime? taskDateTime, int taskPriority )
        {
            DateTime coreTaskDateTime;
            if (taskDateTime == null)
            {
                coreTaskDateTime = DateTime.UtcNow;
            }
            else
            {
                coreTaskDateTime = taskDateTime.Value;
            }

            var coreTask = _taskRepositoryService.SaveTask(taskName, taskDescription, coreTaskDateTime, taskPriority);
            var taskModel = ConvertCoreTaskToTaskModel.ConvertToTaskModel(coreTask);
            return taskModel;
        }

        public TaskViewModel GetTask(Guid taskId)
        {
            var coreTask = _taskRepositoryService.GetTask(taskId);
            var taskModel = ConvertCoreTaskToTaskModel.ConvertToTaskModel(coreTask);
            return taskModel;
        }
    }
}
