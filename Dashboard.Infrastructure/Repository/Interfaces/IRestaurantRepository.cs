using Dashboard.Core.Entities;
using Dashboard.Helper.Dtos;

namespace Dashboard.Infrastructure.Repository.Interfaces
{
    public interface IRestaurantRepository: IRepository<Restaurant>
    {
        Restaurant Restaurant(RestaurantDto restaurantDto);
    }
}
