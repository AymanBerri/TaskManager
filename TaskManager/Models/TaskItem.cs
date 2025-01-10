using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set;} // Id of the task, by default the PK in the DB

        [Required]
        public String Title { get; set; } //name or description of the task.

        public bool IsCompleted { get; set; }
    }
}