using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper;
using Dashboard.Helper.Dtos.City;

namespace Dashboard.Infrastructure.Repository.Interfaces
{
    public interface IDistrictRepository : IRepository<District>
    {
        Task<List<District>> GetDistrictsAysnc(DistrictFilterDto districtFilterDto);
    }
}
