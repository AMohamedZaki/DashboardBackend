//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Dashboard.Core.Entities;
//using Dashboard.Helper;
//using Dashboard.Helper.Dtos.City;
//using Dashboard.Infrastructure.Data;
//using Dashboard.Infrastructure.Repository.Interfaces;

//namespace Dashboard.Infrastructure.Repository
//{
//    public class GovernorateRepository : RepositoryBaseGeneric<Governorate>, IGovernorateRepository
//    {
//        public GovernorateRepository(AppDbContext context) : base(context)
//        {

//        }

//         public async Task<List<Governorate>> GetGovernoratesAysnc(GovernorateFilterDto GovernorateFilterDto)
//        {
//            var governorates = GetQuerable();
//            if (GovernorateFilterDto != null && !string.IsNullOrEmpty(GovernorateFilterDto.Name))
//            {
//                governorates = governorates.Where(gov => gov.Name.ToLower().Contains(GovernorateFilterDto.Name.ToLower()));
//            }

//            return new PagedList<Governorate>(governorates,GovernorateFilterDto.PageIndex,GovernorateFilterDto.PageSize);
//        }
//    }
//}
