using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wello.Api.Resources;
using Wello.Data.Interfaces;
using Wello.Data.Models;

namespace Wello.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICoffeeRepository _coffeeRepository;

        public OrdersController(IOrderRepository orderRepository, ICoffeeRepository coffeeRepository)
        {
            _orderRepository = orderRepository;
            _coffeeRepository = coffeeRepository;
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
        [Route("{id}/submit")]
        public IActionResult SubmitOrder(int id)
        {
            var coffees = _coffeeRepository.GetByOrderId(id);
            if (!coffees.Any())
            {
                return BadRequest("There is no coffee added to the order. Please add coffee before attempting to purchase your order.");
            }

            var totalSmalls = coffees.Count(c => c.Size == "small");
            var totalMediums = coffees.Count(c => c.Size == "medium");
            var totalLarges = coffees.Count(c => c.Size == "large");

            var totalCream = coffees.Sum(c => c.AmountOfCream);
            var totalSugar = coffees.Sum(c => c.AmountOfSugar);

            var order = _orderRepository.Find(id);
            order.AmountDue = (totalSmalls * 1) + (totalMediums * 2) + (totalLarges * 3) + (totalCream * .25) + (totalSugar * .5);

            _orderRepository.Update(order);

            return Ok(CreateOrderResource(order));
        }

        [HttpPost]
        [Route("{id}/nickle")]
        public IActionResult AddNickle(int id)
        {
            return AddFunds(id, .05);
        }

        [HttpPost]
        [Route("{id}/dime")]
        public IActionResult AddDime(int id)
        {
            return AddFunds(id, .10);
        }

        [HttpPost]
        [Route("{id}/quarter")]
        public IActionResult AddQuarter(int id)
        {
            return AddFunds(id, .25);
        }

        [HttpPost]
        [Route("{id}/loonie")]
        public IActionResult AddLoonie(int id)
        {
            return AddFunds(id, 1);
        }

        [HttpPost]
        [Route("{id}/toonie")]
        public IActionResult AddToonie(int id)
        {
            return AddFunds(id, 2);
        }

        private IActionResult AddFunds(int id, double amount)
        {
            var order = _orderRepository.Find(id);
            order.AmountPaid += amount;

            _orderRepository.Update(order);

            return Ok(CreateOrderResource(order));
        }

        private static OrderResource CreateOrderResource(OrderModel order)
        {
            return new OrderResource
            {
                Id = order.Id,
                AmountDue = order.AmountDue,
                AmountPaid = order.AmountPaid
            };
        }
    }
}