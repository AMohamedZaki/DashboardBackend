using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Core.Entities
{
    public class District : Loction
    {
        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City City { get; set; }
    }
}
