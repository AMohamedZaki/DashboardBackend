using AutoMapper;
using Dashboard.Helper.Dtos;
using Dashboard.Core.Entities;

namespace Dashboard.Api.MappingProfiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            // Map Governorate
            CreateMap<Governorate, GovDto>();
            CreateMap<GovDto, Governorate>();
            
            // Map City
            CreateMap<City, CityDto>();
            CreateMap<CityDto, City>();
            

            // Map District
            CreateMap<District, DistrictDto>();
            CreateMap<DistrictDto, District>();

        }
    }
}
