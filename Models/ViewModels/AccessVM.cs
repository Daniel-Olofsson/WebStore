using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.ViewModels;

public class AccessVM
{
    public AccessVM() 
    {
        Email = null!;
        Password = null!;
    }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }

}
