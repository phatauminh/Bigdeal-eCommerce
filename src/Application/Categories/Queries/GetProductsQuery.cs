using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Categories.Commands.Queries.GetProducts;
using CleanArchitecture.Application.Categories.Queries.GetProducts;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Categories.Queries
{
    public class GetProductsQuery : IRequest<ProductsVm>
    {
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsVm> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return new ProductsVm
            {
                Lists = await _context.Categories
                    .AsNoTracking()
                    .ProjectTo<ProductsInCategoryDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
