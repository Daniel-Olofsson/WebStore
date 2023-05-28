using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models;


public class UserEntity
{
    //a asp user needs to be created first
    public UserEntity()
    {
        UserId = null!;
        FirstName = null!;
        LastName = null!;
        User = null!;
    }
    [Key, ForeignKey(nameof(User))]
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? StreetName { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public IdentityUser User { get; set; }
    
}
