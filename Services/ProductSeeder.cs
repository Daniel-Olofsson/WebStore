using WebStore.Models;

namespace WebStore.Services;

public class ProductSeeder
{
    private readonly ProductService _productService;

    public ProductSeeder(ProductService productService)
    {
        _productService = productService;
    }

    public void SeedProducts()
    {
        List<ProductEntity> products = new List<ProductEntity>
        {
            new ProductEntity
            {
                Title = "Computer",
                Genre = "Electronics",
                Price = 10000,
                CollectionStatus = "TopCollection",
                ImageUrl = "https://images.pexels.com/photos/2148216/pexels-photo-2148216.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                
                // Add other properties as needed
            },
            new ProductEntity
            {
                Title = "Coffee",
                Genre = "Pantry",
                Price = 100,
                CollectionStatus = "TopCollection",
                ImageUrl = "https://images.pexels.com/photos/4829080/pexels-photo-4829080.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                
                // Add other properties as needed
            },
            new ProductEntity
            {
                Title = "Flashlight",
                Genre = "Electronics",
                Price = 100,
                CollectionStatus = "TopCollection",
                ImageUrl = "https://images.pexels.com/photos/985117/pexels-photo-985117.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                
                // Add other properties as needed
            },
            new ProductEntity
            {
                Title = "Painting",
                Genre = "Art",
                Price = 100000,
                CollectionStatus = "TopCollection",
                ImageUrl = "https://images.pexels.com/photos/2086361/pexels-photo-2086361.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                
                // Add other properties as needed
            },
            new ProductEntity
            {
                Title = "Cat Food",
                Genre = "Animal Food",
                Price = 115,
                CollectionStatus = "TopCollection",
                ImageUrl = "https://images.pexels.com/photos/2148216/pexels-photo-2148216.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                
                // Add other properties as needed
            },
            new ProductEntity
            {
                Title = "Dog Food",
                Genre = "Animal Food",
                Price = 115,
                CollectionStatus = "UpToSale",
                ImageUrl = "https://images.pexels.com/photos/6568942/pexels-photo-6568942.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                
                // Add other properties as needed
            },
            new ProductEntity
            {
                Title = "Pasta",
                Genre = "Food",
                Price = 90,
                CollectionStatus = "UpToSale",
                ImageUrl = "https://images.pexels.com/photos/6103027/pexels-photo-6103027.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                
                // Add other properties as needed
            },
            new ProductEntity
            {
                Title = "Coca cola",
                Genre = "",
                Price = 15,
                CollectionStatus = "UpToSale",
                ImageUrl = "https://images.pexels.com/photos/1904262/pexels-photo-1904262.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                
                // Add other properties as needed
            },
            new ProductEntity
            {
                Title = "Fanta",
                Genre = "Drinks",
                Price = 15,
                CollectionStatus = "UpToSale",
                ImageUrl = "https://images.pexels.com/photos/1904262/pexels-photo-1904262.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                
                // Add other properties as needed
            },
            new ProductEntity
            {
                Title = "Sprite",
                Genre = "Drinks",
                Price = 15,
                CollectionStatus = "TopSelling",
                ImageUrl = "https://images.pexels.com/photos/4161715/pexels-photo-4161715.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                
                // Add other properties as needed
            },
            new ProductEntity
            {
                Title = "Wine",
                Genre = "Drinks",
                Price = 25,
                CollectionStatus = "TopSelling",
                ImageUrl = "https://images.pexels.com/photos/774455/pexels-photo-774455.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                
                // Add other properties as needed
            },
            new ProductEntity
            {
                Title = "Beer",
                Genre = "Drinks",
                Price = 25,
                CollectionStatus = "TopSelling",
                ImageUrl = "https://images.pexels.com/photos/1089932/pexels-photo-1089932.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                
                // Add other properties as needed
            },
            // Add more products here
        };

        _productService.SeedProducts(products);
    }
}
