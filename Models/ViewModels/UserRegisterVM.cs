using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.ViewModels;

public class UserRegisterVM
{
    public UserRegisterVM() 
    {
        FirstName = null!;
        LastName = null!;
        Email = null!;
        Password = null!;
        ConfirmPassword = null!;
    }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
    public string? StreetName { get; set; }
    [DataType(DataType.PostalCode)]
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public static implicit operator IdentityUser(UserRegisterVM userRegisterVM)
    {
        return new IdentityUser
        {
            UserName = userRegisterVM.Email,
            Email = userRegisterVM.Email,
            PhoneNumber = userRegisterVM.PhoneNumber,
            
        };
    }
    public static implicit operator UserEntity(UserRegisterVM userRegisterVM)
    {
        return new UserEntity
        {
            //UserId = userId,
            FirstName = userRegisterVM.FirstName,
            LastName = userRegisterVM.LastName,
            StreetName = userRegisterVM.StreetName,
            PostalCode = userRegisterVM.PostalCode,
            City = userRegisterVM.City,
        };
    }
    
}
