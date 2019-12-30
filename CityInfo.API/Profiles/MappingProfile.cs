using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Get Mappings
            CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDto>();
            CreateMap<Entities.City, Models.CityDto>();
            CreateMap<Entities.PointOfInterest, Models.PointOfInterestDto>();

            //Create Mappings
            CreateMap<Models.PointofInterestForCreationDto, Entities.PointOfInterest>();

            //Update Mappings
            CreateMap<Models.PointOfInterestForUpdateDto, Entities.PointOfInterest>();

            //Patch Mapping
            CreateMap<Entities.PointOfInterest, Models.PointOfInterestForUpdateDto>();
        }
    }
}
