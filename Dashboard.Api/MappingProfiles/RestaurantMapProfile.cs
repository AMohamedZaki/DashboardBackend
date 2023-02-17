using AutoMapper;
using Dashboard.Core.Entities;
using Dashboard.Helper.Dtos;

namespace Dashboard.Api.MappingProfiles
{
    public class RestaurantMapProfile: Profile
    {
        public RestaurantMapProfile()
        {
            CreateMap<RestaurantDto, Restaurant>();
            CreateMap<Restaurant, RestaurantDto>();
        }
    }
}
