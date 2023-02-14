using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Core.Entities
{
    public class City: Loction<int>
    {
        public decimal? Lat { get; set; }
        public decimal? Long { get; set; }

        [ForeignKey("Region")]
        public int? RegionId { get; set; }
        public Region Region { get; set; }
    }
}
