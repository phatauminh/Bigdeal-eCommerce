using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Cart> Carts { get; set; }

        DbSet<CategoryTranslation> CategoryTranslations { get; set; }

        DbSet<ProductInCategory> ProductInCategories { get; set; }

        DbSet<Contact> Contacts { get; set; }

        DbSet<Language> Languages { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<OrderDetail> OrderDetails { get; set; }

        DbSet<ProductTranslation> ProductTranslations { get; set; }

        DbSet<Promotion> Promotions { get; set; }

        DbSet<Transaction> Transactions { get; set; }

        DbSet<ProductImage> ProductImages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
