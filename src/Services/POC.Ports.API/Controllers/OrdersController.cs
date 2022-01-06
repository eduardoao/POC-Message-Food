using Microsoft.AspNetCore.Mvc;
using System;
using POC.Modules.Application.Commands.PlaceOrder;
using POC.Modules.InputPorts.Order;

namespace POC.Ports.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {

        private readonly IPlaceOrderUseCase _placeOrderService;
        public OrdersController(IPlaceOrderUseCase placeOrderService)
        {
            _placeOrderService = placeOrderService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] OrderInput input)
        {
            // Todo Criar o retorno do banco de dados. 
            var order = _placeOrderService.Execute(input);            
            Console.WriteLine(order); 
            
            return Ok(new { Message = "API order result: " + order }); ;

        }
    }
}
