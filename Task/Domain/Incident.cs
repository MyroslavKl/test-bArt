using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain;

public class Incident
{
    [Key]
    public string IncidentName { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;
    
    public ICollection<Account> Accounts { get; set; } = new List<Account>();

    public Incident()
    {
        IncidentName = Guid.NewGuid().ToString();
    }
}