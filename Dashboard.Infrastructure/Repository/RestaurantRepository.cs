using AutoMapper;
using Dashboard.Core.Entities;
using Dashboard.Helper.Dtos;
using Dashboard.Infrastructure.Data;
using Dashboard.Infrastructure.Repository.Interfaces;
using System;

namespace Dashboard.Infrastructure.Repository
{
    public class RestaurantRepository : RepositoryBaseGeneric<Restaurant>, IRestaurantRepository
    {
        private IMapper _mapper;

        public RestaurantRepository(IMapper mapper, AppDbContext context) : base(context)
        {
            _mapper = mapper;
        }

        public Restaurant Restaurant (RestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            restaurant.CreatedAt = DateTime.Now; 
            Add(restaurant);
            return restaurant;
        }



    }
}
