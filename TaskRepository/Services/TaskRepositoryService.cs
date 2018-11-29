using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entities;
using TaskCore.Services;

namespace TaskRepository.Services
{
    public class TaskRepositoryService : ITaskRepositoryService
    {
        public List<CoreTask> GetAllTasks()
        {
            var datastore = new TaskDataStore();
            return datastore.TaskList;
        }
    }
}
