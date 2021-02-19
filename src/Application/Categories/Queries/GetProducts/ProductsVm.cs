using CleanArchitecture.Application.Categories.Queries.GetProducts;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Categories.Commands.Queries.GetProducts
{
    public class ProductsVm
    {
        public IList<ProductsInCategoryDto> Lists { get; set; }
    }
}
