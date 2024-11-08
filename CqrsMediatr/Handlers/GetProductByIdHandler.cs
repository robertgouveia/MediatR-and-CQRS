using CqrsMediatr.Models;
using CqrsMediatr.Queries;
using MediatR;

namespace CqrsMediatr.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly FakeDataStore _store;

    public GetProductByIdHandler(FakeDataStore store) => _store = store;

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _store.GetProductById(request.Id);
    }
}