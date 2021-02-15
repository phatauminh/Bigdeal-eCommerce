using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace ToDoApp.Domain.Events
{
    public class ProductCompletedEvent : DomainEvent
    {
        public ProductCompletedEvent(Product item)
        {
            Item = item;
        }

        public Product Item { get; }
    }
}
