using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace TaskAppBackend.Models
{
    public class TaskCreateModel
    {
        [Required]
        [MaxLength(50)]
        public string TaskName { get; set; }

        [MaxLength(200)]
        public string TaskDescription { get; set; }
        public DateTime? TaskDateTime { get; set; }
        public int TaskPriority { get; set; }
    }
}

