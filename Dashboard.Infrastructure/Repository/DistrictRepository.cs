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
    public class DistrictRepository : RepositoryBaseGeneric<District>, IDistrictRepository
    {
        public DistrictRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<District>> GetDistrictsAysnc(DistrictFilterDto districtFilterDto)
        {
            var districts = GetQuerable();
            if (districtFilterDto != null && !string.IsNullOrEmpty(districtFilterDto.Name))
            {
                districts = districts.Where(city => city.Name.ToLower().Contains(districtFilterDto.Name.ToLower()));
            }

            if (districtFilterDto != null && districtFilterDto.CityId != null)
            {
                districts = districts.Where(city => city.CityId == districtFilterDto.CityId);
            }

            return new PagedList<District>(districts, districtFilterDto.PageIndex, districtFilterDto.PageSize);
        }
    }
}
