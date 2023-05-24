using System.ComponentModel.DataAnnotations;

namespace WebStore.Models;

public class ProductEntity
{
    public ProductEntity() 
    {
        ImageUrl = null!;
    }
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
}
