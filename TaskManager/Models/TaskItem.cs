using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; } // Id of the task, by default the PK in the DB

        [Required]
        [StringLength(100)] // Limiting the title length to 100 characters
        public required string Title { get; set; } // Title or name of the task

        [StringLength(500)] // Limiting the description length to 500 characters
        public string? Description { get; set; } // Description of the task

        public bool IsCompleted { get; set; } // Whether the task is completed or not

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp for when the task was created

        public DateTime? DueDate { get; set; } // Optional due date for the task
    }
}