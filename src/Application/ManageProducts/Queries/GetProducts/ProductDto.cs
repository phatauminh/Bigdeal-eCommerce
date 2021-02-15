using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchitecture.Application.ManageProducts.Queries.GetProducts
{
    public class ProductDto
    {
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public List<ProductTranslation> ProductTranslations { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
