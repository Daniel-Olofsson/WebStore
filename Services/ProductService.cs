using WebStore.Models;

namespace WebStore.Services;

public class ProductService
{
    private readonly List<ProductEntity> _products;

    public ProductService()
    {
        _products = new List<ProductEntity>();
    }

    public IEnumerable<ProductEntity> GetAllProducts()
    {
        return _products;
    }

    public ProductEntity GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id)!;
    }
}
