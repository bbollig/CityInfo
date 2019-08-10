using CityInfo.API.Services;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {

        private ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        //[HttpGet("api/cities")]<!--if decorating each operation with a fully qualified HTTP attribute, 
        //the route would look like this but we are using 'api/cities' as part of the route template for our controller, seen above at the controller level
        [HttpGet()]
        public IActionResult GetCities()
        {
            var cityEntities = _cityInfoRepository.GetCities();

            var results = new List<CityWithoutPointsOfInterestDto>();

            foreach (var cityEntity in cityEntities)
            {
                results.Add(new CityWithoutPointsOfInterestDto
                {
                    Id = cityEntity.Id,
                    Name = cityEntity.Name,
                    Description = cityEntity.Description
                });
            }
            return Ok(results);
        }

        //[HttpGet("api/cities/{id}")] <--This is what he fully qualified route would look like
        [HttpGet("{id}")]//<--To work with parameters with http attributes, we use the curly brackets
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);
            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var cityResult = new CityDto()
                {
                    Id = city.Id,
                    Name = city.Name,
                    Description = city.Description
                };

                foreach (var poi in city.PointsOfInterest)
                {
                    cityResult.PointsOfInterest.Add(
                        new PointOfInterestDto()
                        {
                            Id = poi.Id,
                            Name = poi.Name,
                            Description = poi.Description
                        });
                }
                return Ok(cityResult);
            }

            var cityWithoutPointsOfInterestResult = new CityWithoutPointsOfInterestDto()
            {
                Id = city.Id,
                Name = city.Name,
                Description = city.Description

            };
            return Ok(cityWithoutPointsOfInterestResult);
        }
    }
}