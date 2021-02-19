using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using ToDoApp.Domain.Events;

namespace CleanArchitecture.Domain.Entities
{
    public class Product : AuditableEntity, IHasDomainEvent
    {
        public int Id { set; get; }
        public decimal Price { set; get; }
        public int Stock { set; get; }
        public DateTime CreatedDate { set; get; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Cart> Carts { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}

