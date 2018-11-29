using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Services;

namespace TaskCore
{
    public class TaskHandler
    {
        private readonly ITaskRepositoryService _taskRepositoryService;

        public TaskHandler( ITaskRepositoryService taskRepositoryService)
        {
            _taskRepositoryService = taskRepositoryService;
        }
    }
}
