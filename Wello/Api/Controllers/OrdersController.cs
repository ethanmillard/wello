using System;
using Microsoft.AspNetCore.Mvc;
using Wello.Api.Resources;
using Wello.Data.Interfaces;

namespace Wello.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public IActionResult Post()
        {
            var orderModel = _orderRepository.Create();

            return Ok(new OrderResource
            {
                Id = orderModel.Id
            });
        }

        [HttpPost]
        [Route(":id")]
        public IActionResult Get(int id)
        {
            try
            {
                var orderModel = _orderRepository.Find(id);

                return Ok(new OrderResource
                {
                    Id = orderModel.Id
                });
            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}