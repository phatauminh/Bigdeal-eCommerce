using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace ToDoApp.Domain.Events
{
    public class ProductCreatedEvent : DomainEvent
    {
        public ProductCreatedEvent(Product item)
        {
            Item = item;
        }

        public Product Item { get; }
    }
}
