using System.ComponentModel.DataAnnotations;

namespace WebStore.Models;

public class ContactEntity
{
    public ContactEntity() 
    {
        Name = null!;
        Email = null!;
        Subject = null!;
        Message = null!;
    }
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}
