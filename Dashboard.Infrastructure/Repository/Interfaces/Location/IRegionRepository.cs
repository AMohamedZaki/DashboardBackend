using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper.Dtos.Location;

namespace Dashboard.Infrastructure.Repository.Interfaces
{
    public interface IRegionRepository : IRepository<Region>
    {
        Task<List<RegionDto>> GetRegionsAysnc(RegionDto RegionFilterDto);
    }
}
