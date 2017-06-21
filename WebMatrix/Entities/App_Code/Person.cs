using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

/// <summary>
/// Summary description for ClassName
/// </summary>
public class Person
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Zip { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public virtual Group Group { get; set; }
}
