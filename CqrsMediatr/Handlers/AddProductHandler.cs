using CqrsMediatr.Commands;
using CqrsMediatr.Models;
using MediatR;

namespace CqrsMediatr.Handlers;

public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
{
    private readonly FakeDataStore _store;

    public AddProductHandler(FakeDataStore store) => _store = store;

    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        await _store.AddProduct(request.Product);
        return request.Product;
    }
}