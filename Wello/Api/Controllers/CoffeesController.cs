using System;
using Microsoft.AspNetCore.Mvc;
using Wello.Api.Resources;
using Wello.Data.Interfaces;
using Wello.Data.Models;

namespace Wello.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeesController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepository;

        public CoffeesController(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CoffeeResource coffeeResource)
        {
            var coffeeModel = new CoffeeModel
            {
                AmountOfCream = coffeeResource.AmountOfCream,
                AmountOfSugar = coffeeResource.AmountOfCream,
                OrderId = coffeeResource.OrderId,
                Size = coffeeResource.Size
            };

            coffeeModel = _coffeeRepository.Create(coffeeModel);

            coffeeResource.Id = coffeeModel.Id;

            return Ok(coffeeResource);
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var coffeeModel = _coffeeRepository.Find(id);

                return Ok(new CoffeeResource
                {
                    Id = coffeeModel.Id,
                    OrderId = coffeeModel.OrderId,
                    AmountOfCream = coffeeModel.AmountOfCream,
                    AmountOfSugar = coffeeModel.AmountOfSugar,
                    Size = coffeeModel.Size
                });
            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] CoffeeResource coffeeResource)
        {
            try
            {
                var coffeeModel = new CoffeeModel
                {
                    Id = coffeeResource.Id,
                    AmountOfCream = coffeeResource.AmountOfCream,
                    AmountOfSugar = coffeeResource.AmountOfSugar,
                    OrderId = coffeeResource.OrderId,
                    Size = coffeeResource.Size
                };

                _coffeeRepository.Update(coffeeModel);

                return Ok();
            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _coffeeRepository.Delete(id);
            return Ok();
        }
    }
}