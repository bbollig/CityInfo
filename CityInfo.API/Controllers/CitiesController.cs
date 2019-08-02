using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        //[HttpGet("api/cities")]<!--if decorating each operation with a fully qualified HTTP attribute, 
        //the route would look like this but we are using 'api/cities' as part of the route template for our controller, seen above at the controller level
        [HttpGet()]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        //[HttpGet("api/cities/{id}")] <--This is what he fully qualified route would look like
        [HttpGet("{id}")]//<--To work with parameters with http attributes, we use the curly brackets
        public IActionResult GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}