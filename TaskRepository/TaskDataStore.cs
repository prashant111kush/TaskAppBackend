using System;
using System.Collections.Generic;
using System.Text;
using TaskCore.Entities;

namespace TaskRepository
{
    public class TaskDataStore
    {
        public List<CoreTask> TaskList { get; set; } = new List<CoreTask>() ;
        public TaskDataStore()
        {
            TaskList.Add(new CoreTask(

                Guid.NewGuid(), "Task 1", "Sample Task 1", new DateTime(2018, 12, 12, 21, 21, 21, DateTimeKind.Local), 1
            ));

            TaskList.Add(new CoreTask(

                Guid.NewGuid(), "Task 2", "Sample Task 2", new DateTime(2018, 12, 12, 23, 21, 21, DateTimeKind.Local), 2
            ));
        }
    }
}
