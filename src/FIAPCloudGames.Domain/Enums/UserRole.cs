using System.ComponentModel.DataAnnotations;

public enum UserRole
{
    [Display(Name = "admin")]
    Admin = 1,

    [Display(Name = "user")]
    User = 2
}
