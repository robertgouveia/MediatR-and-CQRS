using CqrsMediatr.Notifications;
using MediatR;

namespace CqrsMediatr.Handlers;

// Equivalent to the IRequestHandler - expects the notification
// Handlers are listeners to the notification
public class EmailHandler : INotificationHandler<ProductAddedNotification>
{
    private readonly FakeDataStore _store;
    
    public EmailHandler(FakeDataStore store) => _store = store;
    
    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await _store.EventOccurred(notification.Product, "Email Sent");
        await Task.CompletedTask;
    }
}