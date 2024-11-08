using CqrsMediatr.Models;
using MediatR;

namespace CqrsMediatr.Commands;

public record AddProductCommand(Product Product) : IRequest<Product>;