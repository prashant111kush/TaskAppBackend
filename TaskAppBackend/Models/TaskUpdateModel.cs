using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAppBackend.Models
{
    public class TaskUpdateModel
    {
        [Required(ErrorMessage = "The name should not be more than 50 characters and less than 5 characters.")]
        [MaxLength(50)]
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
