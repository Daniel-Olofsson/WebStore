using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace WebStore.Models.ViewModels;

public class AdminRegisterViewModel
{
    public AdminRegisterViewModel() 
    {
        Email = null!;
        Password = null!;
        ConfirmPassword = null!;
        Email = null!;
        FirstName = null!;
        LastName = null!;
    }
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}

