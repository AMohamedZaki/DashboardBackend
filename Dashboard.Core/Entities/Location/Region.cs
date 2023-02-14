
using System.Collections.Generic;

namespace Dashboard.Core.Entities
{
    public class Region : Loction<int>
    {
        public string Code { get; set; }
        public int CapitalCityId { get; set; }

        public ICollection<City> Cities { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
