using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper;
using Dashboard.Helper.Dtos.Location;
using Dashboard.Infrastructure.Data;
using Dashboard.Infrastructure.Repository.Interfaces;

namespace Dashboard.Infrastructure.Repository
{
    public class CityRepository: RepositoryBaseGeneric<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<City>> GetCitiesAysnc(CityDto cityFilterDto)
        {
            var cities = GetQuerable();
            if (cityFilterDto != null && !string.IsNullOrEmpty(cityFilterDto.Name_en))
            {
                cities = cities.Where(city => city.Name_en.ToLower().Contains(cityFilterDto.Name_en.ToLower()));
            }    
            
            if (cityFilterDto != null && !string.IsNullOrEmpty(cityFilterDto.Name_ar))
            {
                cities = cities.Where(city => city.Name_ar.ToLower().Contains(cityFilterDto.Name_ar.ToLower()));
            }

            if (cityFilterDto != null && cityFilterDto.RegionId != null)
            {
                cities = cities.Where(city => city.RegionId == cityFilterDto.RegionId);
            }

            return new PagedList<City>(cities, cityFilterDto.PageIndex, cityFilterDto.PageSize);
        }
    }
}
