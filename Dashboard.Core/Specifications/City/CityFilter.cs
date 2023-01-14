

namespace Dashboard.Core.Specifications
{
    public class CityFilter : BaseFilter
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public bool? Active { get; set; }
        public string? OrderBy { get; set; }
    }
}
