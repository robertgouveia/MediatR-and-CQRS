using CqrsMediatr.Handlers;
using CqrsMediatr.Models;
using MediatR;

namespace CqrsMediatr.Queries;

// Our request will return the type specified (generics)
public record GetProductsQuery : IRequest<IEnumerable<Product>>;