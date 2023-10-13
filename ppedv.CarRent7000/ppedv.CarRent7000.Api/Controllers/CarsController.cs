using Microsoft.AspNetCore.Mvc;
using ppedv.CarRent7000.Model.Contracts;
using ppedv.CarRent7000.Model.DomainModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.CarRent7000.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IRepository repo;

        public CarsController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public IEnumerable<CarDTO> Get()
        {
            return repo.GetAll<Car>().Select(x => MapCarToCarDTO(x));
        }

        public static CarDTO MapCarToCarDTO(Car car)
        {
            if (car == null)
            {
                return null;
            }

            var carDTO = new CarDTO
            {
                CarId = car.Id,
                Manufacturer = car.Manufacturer,
                Model = car.Model,
                Color = car.Color
            };

            return carDTO;
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
