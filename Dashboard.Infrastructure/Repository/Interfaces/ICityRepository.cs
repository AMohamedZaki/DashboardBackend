using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper;
using Dashboard.Helper.Dtos.City;

namespace Dashboard.Infrastructure.Repository.Interfaces
{
    public interface ICityRepository: IRepository<City>
    {
        Task<List<City>> GetCitiesAysnc(CityFilterDto cityFilterDto);
    }
}
