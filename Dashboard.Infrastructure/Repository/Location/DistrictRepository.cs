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
    public class DistrictRepository : RepositoryBaseGeneric<District>, IDistrictRepository
    {
        public DistrictRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<DistrictDto>> GetDistrictsAysnc(DistrictDto districtDto)
        {
            var districts = GetQuerable();
            if (districtDto != null && !string.IsNullOrEmpty(districtDto.Name_ar))
            {
                districts = districts.Where(city => city.Name_ar.ToLower().Contains(districtDto.Name_ar.ToLower()));
            }
            
            if (districtDto != null && !string.IsNullOrEmpty(districtDto.Name_en))
            {
                districts = districts.Where(city => city.Name_en.ToLower().Contains(districtDto.Name_en.ToLower()));
            }

            if (districtDto != null && districtDto.CityId != null)
            {
                districts = districts.Where(city => city.CityId == districtDto.CityId);
            }

            var districtsDto = districts.Select(district => new DistrictDto
            {
                Name_en = district.Name_en,
                Name_ar = district.Name_ar,
                Id = district.Id,
                CityId = district.City.Id,
                CityNameAr = district.City.Name_ar,
                CityNameEn = district.City.Name_en,
            });

            return new PagedList<DistrictDto>(districtsDto, districtDto.PageIndex, districtDto.PageSize);
        }
    }
}
