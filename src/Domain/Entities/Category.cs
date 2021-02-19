using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { set; get; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
