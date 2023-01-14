using System.Collections.Generic;
using Dashboard.SharedKernel;

namespace Dashboard.Core.Entities
{
    public class Governorate : BaseEntity<int>
    {
        public string? Name { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<City>? City { get; set; }
        public virtual ICollection<Account>? Account { get; set; }
        public void SetId(int maxId)
        {
            Id = maxId + 1;
        }
    }
}
