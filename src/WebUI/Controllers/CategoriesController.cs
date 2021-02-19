using CleanArchitecture.Application.Categories.Commands.CreateCategory;
using CleanArchitecture.Application.Categories.Commands.DeleteCategory;
using CleanArchitecture.Application.Categories.Commands.Queries.GetProducts;
using CleanArchitecture.Application.Categories.Commands.UpdateCategory;
using CleanArchitecture.Application.Categories.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ProductsVm>> Get()
        {
            return await Mediator.Send(new GetProductsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCategoryCommand command)
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
            await Mediator.Send(new DeleteCategoryCommand { Id = id });

            return NoContent();
        }
    }
}
