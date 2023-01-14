using System.Collections.Generic;
using Dashboard.SharedKernel;

namespace Dashboard.Core.Entities
{
    public class Branch : BaseEntity<int>
    {
        public string? Name { get; set; }
        public bool Active { get; set; }
        public string? Notes { get; set; }


        // many to many with Cities
        public virtual ICollection<CityBranch> CityBranches { get; set; }
    }
}
