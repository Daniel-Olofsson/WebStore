namespace WebStore.Models.ViewModels;

public class ContactVM
{
    public ContactVM() 
    {
        Name = null!;
        Email = null!;
        Subject = null!;
        Message = null!;
    }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}
