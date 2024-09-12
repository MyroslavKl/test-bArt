using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain;


public class Contact : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public int AccountId { get; set; }

    public Account Account { get; set; } = null!;
}