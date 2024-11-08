using CqrsMediatr.Notifications;
using MediatR;

namespace CqrsMediatr.Handlers;

// Handlers are listeners to the notification
public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
{
    private readonly FakeDataStore _store;

    public CacheInvalidationHandler(FakeDataStore store) => _store = store;
    
    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await _store.EventOccurred(notification.Product, "Cache Invalidated");
        await Task.CompletedTask;
    }
}