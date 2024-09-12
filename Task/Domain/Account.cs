using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain;

public class Account:BaseEntity
{
    [Required] [StringLength(50)] 
    public string Name { get; set; } = string.Empty;

    public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    public ICollection<Incident> Incidents { get; set; } = new List<Incident>();
}