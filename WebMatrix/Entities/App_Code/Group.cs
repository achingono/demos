using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

/// <summary>
/// Summary description for Group
/// </summary>
public class Group
{
    [Key]
    public int Id {get; set;}

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public virtual List<Person> People { get; set; }
}