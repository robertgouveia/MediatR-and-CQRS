using CqrsMediatr.Models;

namespace CqrsMediatr;

public class FakeDataStore
{
    private static List<Product> _products;

    public FakeDataStore()
    {
        _products = 
        [
            new() { Id = 1, Name = "Test Product 1"},
            new() { Id = 2, Name = "Test Product 2"},
            new() { Id = 3, Name = "Test Product 3"},
        ];
    }

    public async Task AddProduct(Product entity)
    {
        _products.Add(entity);

        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);

    public async Task<Product> GetProductById(int id) => await Task.FromResult(_products.Single(p => p.Id == id));

    public async Task EventOccurred(Product product, string evt)
    {
        _products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
        await Task.CompletedTask;
    }
}