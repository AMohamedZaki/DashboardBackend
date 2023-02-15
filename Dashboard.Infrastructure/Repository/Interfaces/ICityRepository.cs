using Dashboard.Core.Entities;
using Dashboard.Helper.Dtos.Location;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashboard.Infrastructure.Repository.Interfaces
{
    public interface ICityRepository: IRepository<City>
    {
        Task<List<City>> GetCitiesAysnc(CityDto cityFilterDto);
    }
}
