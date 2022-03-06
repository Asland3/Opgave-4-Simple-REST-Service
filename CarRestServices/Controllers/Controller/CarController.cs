using System;
using System.Collections.Generic;
using System.Linq;
using CarRESTServices.Managers;
using CarRESTServices.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRESTServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private CarManager _manager = new CarManager();
        // GET: api/Cars?modelFilter<value> 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get([FromQuery] string? modelFilter, [FromQuery] int? priceFilter, [FromQuery] string? licensePlateFilter)
        {

            IEnumerable<Car> cars = _manager.GetAll(modelFilter, priceFilter, licensePlateFilter);

            if (cars.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(cars);
            }

        }

        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Car car = _manager.GetByID(id);
            if (car == null) return NotFound("No such item, id: " + id);
            return Ok(car);
        }

        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public Car Post([FromBody] Car newCar)
        {
            return _manager.AddCar(newCar);
        }


        // DELETE api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public Car Delete(int id)
        {
            Car car = _manager.GetByID(id);
            return _manager.Delete(id);
        }
       


    }
}
