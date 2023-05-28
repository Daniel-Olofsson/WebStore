using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.ViewModels;

public class UserEditVM
{
    public UserEditVM()
    {
        Email = null!;
        PhoneNumber = null!;
        StreetName = null!;
    }

    public string UserId { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }
    public string StreetName { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }

    public static implicit operator UserEditVM(IdentityUser user)
    {
        return new UserEditVM
        {
            UserId = user.Id,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };
    }
    public static implicit operator UserEntity(UserEditVM userEditVM)
    {
        return new UserEntity
        {
            UserId = userEditVM.UserId,
            StreetName = userEditVM.StreetName,
            PostalCode = userEditVM.PostalCode,
            City = userEditVM.City,
        };
    }
}

