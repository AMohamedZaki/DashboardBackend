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
    public class RegionRepository : RepositoryBaseGeneric<Region>, IRegionRepository
    {
        public RegionRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<RegionDto>> GetRegionsAysnc(RegionDto RegionFilterDto)
        {
            var governorates = GetQuerable();
            if (RegionFilterDto != null && !string.IsNullOrEmpty(RegionFilterDto.Name_ar))
            {
                governorates = governorates.Where(gov => gov.Name_ar.ToLower().Contains(RegionFilterDto.Name_ar.ToLower()));
            }

            if (RegionFilterDto != null && !string.IsNullOrEmpty(RegionFilterDto.Name_en))
            {
                governorates = governorates.Where(gov => gov.Name_en.ToLower().Contains(RegionFilterDto.Name_en.ToLower()));
            }

            IQueryable<RegionDto> regionsAysnc = governorates.Select(region => new RegionDto
            {
                Name_en = region.Name_en,
                Name_ar = region.Name_ar,
                Id = region.Id
            });

            return new PagedList<RegionDto>(regionsAysnc, RegionFilterDto.PageIndex, RegionFilterDto.PageSize);
        }
    }
}
