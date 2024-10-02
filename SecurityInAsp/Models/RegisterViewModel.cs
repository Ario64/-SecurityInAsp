using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SecurityInAsp.Models;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    [DisplayName("Email")]
    public string Email { get; set; }

    [Required]
    [StringLength(100,ErrorMessage = "the {0} must be at least {1} characters")]
    [DataType(DataType.Password)]
    [DisplayName("Password")]
    public string Password { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "the {0} must be at least {1} characters")]
    [DataType(DataType.Password)]
    [DisplayName("ConfirmPassword")]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}