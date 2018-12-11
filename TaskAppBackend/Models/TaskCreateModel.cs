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
        [Required(ErrorMessage = "The name should not be more than 40 characters and less than 5 characters.")]
        [MaxLength(40)]
        [MinLength(5)]
        public string TaskName { get; set; }

        [MaxLength(200, ErrorMessage = "The description should not be more than 200 characters.")]
        public string TaskDescription { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "The value should be in date time format.")]
        public DateTime TaskDateTime { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "The priority should be set between 1 and 5.")]
        public int TaskPriority { get; set; }
    }
}

