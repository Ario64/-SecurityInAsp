using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SecurityInAsp.Models;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    [DisplayName("Email")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "the {0} must be at least {1} characters")]
    [DataType(DataType.Password)]
    [DisplayName("Password")]
    public string Password { get; set; }

    [DisplayName("Remember Me?")]
    public bool RememberMe { get; set; }
}