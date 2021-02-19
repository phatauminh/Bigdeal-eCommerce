using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Categories.Queries.GetProducts
{
    public class ProductsInCategoryDto : IMapFrom<Category>
    {
        public ProductsInCategoryDto()
        {
            Products = new List<ProductDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<ProductDto> Products { get; set; }
    }
}
