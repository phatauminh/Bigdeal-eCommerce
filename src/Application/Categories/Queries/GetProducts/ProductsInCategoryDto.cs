using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, ProductsInCategoryDto>()
                .ForMember(d =>d.Name  , opt => opt.MapFrom(s=> s.CategoryTranslations.Where(x=>x.CategoryId == s.Id).FirstOrDefault().Name));
        }
    }
}
