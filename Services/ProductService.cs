using Microsoft.EntityFrameworkCore;
using WebStore.Contexts;
using WebStore.Models;

namespace WebStore.Services;

public class ProductService
{
    private readonly List<ProductEntity> _products;
    private readonly IdentityContext _dbContext;

    public ProductService(IdentityContext dbContext)
    {
        _products = new List<ProductEntity>();
        _dbContext = dbContext;
    }
    public void SeedProducts(List<ProductEntity> products)
    {
        foreach (var product in products)
        {
            var existingProduct = _dbContext.ProductEntity.FirstOrDefault(p => p.Title == product.Title);

            if (existingProduct == null)
            {
                _dbContext.ProductEntity.Add(product);
            }
        }

        _dbContext.SaveChanges();
    }
    public IEnumerable<ProductEntity> GetAllProducts()
    {
        return _products;
    }

    public ProductEntity GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id)!;
    }
    public IEnumerable<ProductEntity> GetProductsByCollectionStatus(string collectionStatus)
    {
        return _dbContext.ProductEntity.Where(p => p.CollectionStatus == collectionStatus).ToList();
    }

}
