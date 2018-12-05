using System;
using System.Collections.Generic;
using TaskCore.Entities;
using TaskCore.Services;

namespace TaskCore
{
    public class TaskSevice : ITaskService
    {
        private readonly ITaskRepositoryService _taskRepositoryService;
        public TaskSevice(ITaskRepositoryService taskRepositoryService)
        {
            _taskRepositoryService = taskRepositoryService;
        }

        public IEnumerable<CoreTask> GetAllTasks()
        {
            var coreTaskList = _taskRepositoryService.GetAllTasks();
            return coreTaskList;
        }

        public  CoreTask CreateTask(string taskName, string taskDescription, DateTime taskDateTime, int taskPriority )
        {
            var coreTask = _taskRepositoryService.SaveTask(taskName, taskDescription, taskDateTime, taskPriority);
            return coreTask;
        }

        public CoreTask GetTask(Guid taskId)
        {
            var coreTask = _taskRepositoryService.GetTask(taskId);
            return coreTask;
        }

        public CoreTask UpdateTask(Guid taskId, string taskName, string taskDescription, DateTime taskDateTime, int taskPriority)
        {
            var updatedCoreTask = _taskRepositoryService.UpdateTask(taskId, taskName, taskDescription, taskDateTime, taskPriority);
            return updatedCoreTask;

        }

        public void DeleteTask(Guid taskId)
        {
            _taskRepositoryService.DeleteTask(taskId);
        }
    }
}
