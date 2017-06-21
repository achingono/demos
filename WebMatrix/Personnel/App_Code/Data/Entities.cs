using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;

namespace ProSoft.Personnel.Data
{
    /// <summary>
    /// Summary description for ClassName
    /// </summary>
    public class Entities : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
    
}