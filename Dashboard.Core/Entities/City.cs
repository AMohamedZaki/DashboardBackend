
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dashboard.SharedKernel;

namespace Dashboard.Core.Entities
{
    public class City : BaseEntity<int>
    {
        public string? Name { get; set; }
        public bool Active { get; set; }
        [ForeignKey("Gov")]
        public int? GovId { get; set; } = 0;
        public virtual Governorate? Gov { get; set; }
       
        // many to many with branches
        public virtual ICollection<CityBranch> CityBranches { get; set; }

        public virtual ICollection<District>? District { get; set; }
        public virtual ICollection<Account>? Account { get; set; }

        public void SetId(int maxId)
        {
            Id = maxId + 1;
        }
    }
}
