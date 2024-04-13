using Application.Orders.Commands.CreateOrder;
using Application.Orders.Commands.DeleteCommand;
using Application.Orders.Commands.UpdateOrder;
using Application.Orders.Queries.GetOrder;
using Application.Orders.Queries.GetOrderDetails;
using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProductDetails;
using Application.Products.Queries.GetProductList;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechWebApi.Models;

namespace TechWebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderListVm>> GetAll()
        {
            var query = new GetOrderListQuery
            {
                UserId = Guid.NewGuid()
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderDetailsVm>> Get(Guid id)
        {
            var query = new GetOrderDetailsQuery
            {
                Id = id,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderCommand createOrderDto)
        {            
            var proId = await Mediator.Send(createOrderDto);
            return Ok(proId);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommand updateOrderCommand)
        {
            await Mediator.Send(updateOrderCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteOrderCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
