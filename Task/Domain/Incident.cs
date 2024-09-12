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

    [Required]
    public int AccountId { get; set; }
    [ForeignKey("AccountId")]
    public Account Account { get; set; } = null!;
    
    public Incident() {
        IncidentName = Guid.NewGuid().ToString();
    }
}