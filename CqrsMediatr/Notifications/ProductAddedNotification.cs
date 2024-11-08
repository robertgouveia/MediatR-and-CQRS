using CqrsMediatr.Models;
using MediatR;

namespace CqrsMediatr.Notifications;

// Equivalent to IRequest but notifications
public record ProductAddedNotification(Product Product) : INotification;