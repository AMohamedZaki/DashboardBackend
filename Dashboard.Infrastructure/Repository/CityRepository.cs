using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper;
using Dashboard.Helper.Dtos.City;
using Dashboard.Infrastructure.Data;
using Dashboard.Infrastructure.Repository.Interfaces;

namespace Dashboard.Infrastructure.Repository
{
    public class CityRepository: RepositoryBaseGeneric<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<City>> GetCitiesAysnc(CityFilterDto cityFilterDto)
        {
            var cities = GetQuerable();
            if (cityFilterDto != null && !string.IsNullOrEmpty(cityFilterDto.Name))
            {
                cities =cities.Where(city => city.Name.ToLower().Contains(cityFilterDto.Name.ToLower()));
            }

            if (cityFilterDto != null && cityFilterDto.GovId != null)
            {
                cities = cities.Where(city => city.GovId == cityFilterDto.GovId);
            }

            return new PagedList<City>(cities, cityFilterDto.PageIndex, cityFilterDto.PageSize);
        }
    }
}
