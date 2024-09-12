using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain;

public class Account : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    public ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public string IncidentName { get; set; } = string.Empty;
    [ForeignKey("IncidentName")] 
    public Incident Incident { get; set; } = null!;
}