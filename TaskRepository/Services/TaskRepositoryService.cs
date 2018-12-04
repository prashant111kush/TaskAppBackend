using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entities;
using TaskCore.Services;

namespace TaskRepository.Services
{
    public class TaskRepositoryService : ITaskRepositoryService
    {
        private readonly TaskDataStore _dataStore = TaskDataStore.GetTaskDataStore;
        public List<CoreTask> GetAllTasks()
        {
            return _dataStore.TaskList;
        }

        public CoreTask SaveTask(string taskName, string taskDescription, DateTime taskDateTime, int taskPriority)
        {
            var coreTask = new CoreTask(taskId: Guid.NewGuid(), taskDateTime: taskDateTime, taskDescription: taskDescription, taskPriority: taskPriority, taskName: taskName);
            _dataStore.AddTask(coreTask);
            return coreTask;
        }

        public CoreTask GetTask(Guid taskId)
        {
           var coreTask =  _dataStore.GetTask(taskId);
            return coreTask;
        }
    }
}
