using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dashboard.SharedKernel;

namespace Dashboard.Core.Entities
{
    public class District : BaseEntity<int>
    {
        public string? Name { get; set; }
        public bool Active { get; set; }
        public int Delivery { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; } = 0;
        public virtual City? City { get; set; }
        public virtual ICollection<Account>? Account { get; set; }

        public void SetId(int maxId)
        {
            Id = maxId + 1;
        }
    }
}
