using System.ComponentModel.DataAnnotations;

namespace Domain.Base;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}