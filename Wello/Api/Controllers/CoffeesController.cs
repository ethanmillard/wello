using System;
using Microsoft.AspNetCore.Mvc;
using Wello.Api.Resources;
using Wello.Data.Interfaces;

namespace Wello.Api.Controllers
{
    /// <summary>
    /// A controller containing all the coffee endpoints.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CoffeesController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoffeesController"/> class.
        /// </summary>
        /// <param name="coffeeRepository"></param>
        public CoffeesController(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        /// <summary>
        /// Creates a new coffee.
        /// </summary>
        /// <param name="coffeeResource">The coffee to create.</param>
        /// <returns>The newly created coffee.</returns>
        [HttpPost]
        public IActionResult Post([FromBody] CoffeeResource coffeeResource)
        {
            var coffeeModel = _coffeeRepository.Create(coffeeResource.OrderId, coffeeResource.Size, coffeeResource.AmountOfCream, coffeeResource.AmountOfSugar);
            coffeeResource.Id = coffeeModel.Id;

            return Ok(coffeeResource);
        }

        /// <summary>
        /// Updates the coffee.
        /// </summary>
        /// <param name="coffeeId">The unique identifier of the coffee.</param>
        /// <param name="coffeeResource">The fields of the coffee to update.</param>
        /// <returns>THe updated coffee.</returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int coffeeId, [FromBody] CoffeeResource coffeeResource)
        {
            try
            {
                _coffeeRepository.Update(coffeeId, coffeeResource.AmountOfCream, coffeeResource.AmountOfSugar);
                return Ok();
            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Deletes the coffee.
        /// </summary>
        /// <param name="id">The unique identifier of the coffee.</param>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _coffeeRepository.Delete(id);
            return Ok();
        }
    }
}