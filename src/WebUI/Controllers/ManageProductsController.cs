using CleanArchitecture.Application.Categories.Queries.GetProducts;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.ManageProducts.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApp.Application.Products.Commands.CreateProduct;
using ToDoApp.Application.Products.Commands.DeleteProduct;
using ToDoApp.Application.Products.Commands.UpdateProduct;

namespace CleanArchitecture.WebUI.Controllers
{
    [Authorize]
    public class ManageProductsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ProductDto>>> GetProductsWithPagination([FromQuery] GetProductsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }
    }
}
