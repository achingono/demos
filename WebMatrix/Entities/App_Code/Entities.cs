using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;

/// <summary>
/// Summary description for ClassName
/// </summary>
public class Entities: DbContext
{
    public DbSet<Group> Groups { get; set; }
    public DbSet<Person> People { get; set; }
}
