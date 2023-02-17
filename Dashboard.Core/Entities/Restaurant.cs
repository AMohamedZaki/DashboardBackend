using Dashboard.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Core.Entities
{
    public class Restaurant : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;

        public string Days { get; set; } = string.Empty;

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City City { get; set; }
    }
}
