using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mis321_bonus_aevansmartinez.models;
using mis321_bonus_aevansmartinez.interfaces;
using mis321_bonus_aevansmartinez.database;

namespace mis321_bonus_aevansmartinez.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        // GET:  GET ALL CARS
        [HttpGet(Name="GetCars")]
        public List<Car> Get()
        {
            IGetAllCars myCar = new GetAllCars();
            return myCar.GetAllCars();
        }

        // GET: GET ONE CAR ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~DONE?
        [HttpGet("{id}", Name = "GetCar")]
        public Car Get(int id)
        {
            IGetCar myCar = new GetCar();
            return myCar.GetCar(id);
        }

        // POST: CREATE CAR ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~DONE?
        [HttpPost(Name = "CreateCar")]
        public int Post([FromBody] Car value)
        {
            ICreateCar newCar = new CreateCar();
            return newCar.CreateCar(value);
        }

        // PUT: DEL/PIN CAR
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car value){
            IDelHoldCar editCar = new DelHoldCar();
            editCar.DelHoldCar(value);
        }

        // DELETE: DONT HARD DELETE THINGS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~DONE?
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine(id);
        }
    }
}
