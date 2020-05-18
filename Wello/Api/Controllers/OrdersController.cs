using Microsoft.AspNetCore.Mvc;
using Wello.Api.Resources;
using Wello.Application;
using Wello.Data.Interfaces;
using Wello.Data.Models;

namespace Wello.Api.Controllers
{
    /// <summary>
    /// A controller containing all the order endpoints.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderService _orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersController"/> class.
        /// </summary>
        /// <param name="orderRepository">The <see cref="IOrderRepository"/>.</param>
        /// <param name="orderService">The <see cref="IOrderService"/>.</param>
        public OrdersController(IOrderRepository orderRepository, IOrderService orderService)
        {
            _orderRepository = orderRepository;
            _orderService = orderService;
        }

        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <returns>A newly created order.</returns>
        [HttpPost]
        public IActionResult Post()
        {
            var orderModel = _orderRepository.Create();

            return Ok(new OrderResource
            {
                Id = orderModel.Id
            });
        }

        /// <summary>
        /// Submits the order.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>The order that was submitted.</returns>
        [HttpPost]
        [Route("{id}/submit")]
        public IActionResult SubmitOrder(int id)
        {
            var orderTotal = _orderService.CalculateOrderTotal(id);

            var order = _orderRepository.Find(id);
            order.AmountDue = orderTotal;

            _orderRepository.Update(order.Id, order.AmountDue, order.AmountPaid);

            return Ok(CreateOrderResource(order));
        }

        /// <summary>
        /// Adds a nickle to the order.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>The order.</returns>
        [HttpPost]
        [Route("{id}/nickle")]
        public IActionResult AddNickle(int id)
        {
            return AddFunds(id, .05);
        }

        /// <summary>
        /// Adds a dime to the order.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>The order.</returns>
        [HttpPost]
        [Route("{id}/dime")]
        public IActionResult AddDime(int id)
        {
            return AddFunds(id, .10);
        }

        /// <summary>
        /// Adds a quarter to the order.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>The order.</returns>
        [HttpPost]
        [Route("{id}/quarter")]
        public IActionResult AddQuarter(int id)
        {
            return AddFunds(id, .25);
        }

        /// <summary>
        /// Adds a loonie to the order.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>The order.</returns>
        [HttpPost]
        [Route("{id}/loonie")]
        public IActionResult AddLoonie(int id)
        {
            return AddFunds(id, 1);
        }

        /// <summary>
        /// Adds a toonie to the order.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>The order.</returns>
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

            _orderRepository.Update(order.Id, order.AmountDue, order.AmountPaid);

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