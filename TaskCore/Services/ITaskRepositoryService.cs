using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entities;

namespace TaskCore.Services
{
    public interface ITaskRepositoryService
    {
        List<CoreTask> GetAllTasks();
    }
}
