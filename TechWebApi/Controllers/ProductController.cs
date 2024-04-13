using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Queries.GetProductDetails;
using Application.Products.Queries.GetProductList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechWebApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace TechWebApi.Controllers
{    
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductListVm>> GetAll()
        {
            var  query = new GetProductListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm); 
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetProductDetailsQuery>> Get(Guid id)
        {
            var query = new GetProductDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var proId = await  Mediator.Send(createProductCommand);
            return Ok(proId);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            await Mediator.Send(updateProductCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
