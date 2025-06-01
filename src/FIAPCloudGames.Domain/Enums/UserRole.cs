using System.ComponentModel.DataAnnotations;

namespace FIAPCloudGames.Domain.Enums;

public enum UserRole
{
    [Display(Name = "admin")]
    Admin = 1,

    [Display(Name = "user")]
    User = 2
}
