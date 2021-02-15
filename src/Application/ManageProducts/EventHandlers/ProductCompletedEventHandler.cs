using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Domain.Events;

namespace ToDoApp.Application.ManageProducts.EventHandlers
{
    public class ProductCompletedEventHandler : INotificationHandler<DomainEventNotification<ProductCompletedEvent>>
    {
        private readonly ILogger<ProductCompletedEventHandler> _logger;

        public ProductCompletedEventHandler(ILogger<ProductCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<ProductCompletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Product Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
