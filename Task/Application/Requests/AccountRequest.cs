using System.ComponentModel.DataAnnotations;

namespace Application.Requests;

public class AccountRequest
{
    public string AccountName { get; set; } = string.Empty;

    public string ContactFirstName { get; set; } = string.Empty;

    public string ContactLastName { get; set; } = string.Empty;

    [EmailAddress] 
    public string ContactEmail { get; set; } = string.Empty;

    public string IncidentName { get; set; } = string.Empty;
}