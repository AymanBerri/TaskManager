using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace TaskManager.Models
{
    public class TaskContext : DbContext
    {

        public DbSet<TaskItem> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options)
            :base(options)
            {

            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().Property(t => t.Status)
                .HasConversion<string>(); // Converts the enum to a string for storage
        }


    }
}