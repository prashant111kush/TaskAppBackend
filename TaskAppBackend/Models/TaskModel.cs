using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAppBackend.Models
{
    public class TaskModel
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDateTime { get; set; }
        public int TaskPriority { get; set; }
    }
}
