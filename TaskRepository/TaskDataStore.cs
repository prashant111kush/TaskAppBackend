using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskCore.Entities;

namespace TaskRepository
{
    internal sealed class TaskDataStore
    {
        private static TaskDataStore taskDataStore = null;
        private static readonly  object padlock = new object();

        private TaskDataStore()
        {
            
        }

        internal List<CoreTask> TaskList { get; set; } = new List<CoreTask>() ;

        public static TaskDataStore GetTaskDataStore
        {
            get
            {
                lock (padlock)
                {

                    if (taskDataStore == null)
                    {
                        taskDataStore = new TaskDataStore();
                        taskDataStore.TaskList.Add(new CoreTask(

                            Guid.NewGuid(), "Task 1", "Sample Task 1",
                            new DateTime(2018, 12, 12, 21, 21, 21, DateTimeKind.Local), 1
                        ));

                        taskDataStore.TaskList.Add(new CoreTask(

                            Guid.NewGuid(), "Task 2", "Sample Task 2",
                            new DateTime(2018, 12, 12, 23, 21, 21, DateTimeKind.Local), 2
                        ));
                    }
                    return taskDataStore;
                }
            }
        }

        internal void AddTask(CoreTask coreTask)
        {
            taskDataStore.TaskList.Add(coreTask);
        }

        internal CoreTask GetTask(Guid taskId)
        {
           var coreTask =  taskDataStore.TaskList.SingleOrDefault(t => t.TaskId == taskId);
            return coreTask;
        }

        internal CoreTask UpdateTask(CoreTask coreTask)
        {
            taskDataStore.TaskList.RemoveAll(t => t.TaskId == coreTask.TaskId);
            taskDataStore.AddTask(coreTask);
            var updatedTask = GetTask(coreTask.TaskId);
            return updatedTask;
        }

        internal void DeleteTask(Guid taskId)
        {
            taskDataStore.TaskList.RemoveAll(t => t.TaskId == taskId);
        }
    }
}
