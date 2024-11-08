using CqrsMediatr.Models;
using CqrsMediatr.Queries;
using MediatR;

namespace CqrsMediatr.Handlers;

// <in, response>
public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    // Needs access to Data Layer
    private readonly FakeDataStore _store;

    public GetProductsHandler(FakeDataStore store) => _store = store;

    // Handle is the endpoint itself
    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken) => await _store.GetAllProducts();
}