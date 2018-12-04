using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskCore.Entities;

namespace TaskAppBackend.Models
{
    public class TaskViewModel
    {
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDateTime { get; set; }
        public int TaskPriority { get; set; }
    }
}
