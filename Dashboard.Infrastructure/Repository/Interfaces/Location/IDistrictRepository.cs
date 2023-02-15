using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper.Dtos.Location;

namespace Dashboard.Infrastructure.Repository.Interfaces
{
    public interface IDistrictRepository : IRepository<District>
    {
        Task<List<DistrictDto>> GetDistrictsAysnc(DistrictDto districtDto);
    }
}
