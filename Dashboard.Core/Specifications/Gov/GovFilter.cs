using Dashboard.Core.Specifications;

namespace Dashboard.Core.Specifications;

    public class GovFilter : BaseFilter
    {
    public int? Id { get; set; }
    public string? Name { get; set; }
    public bool? Active { get; set; }
    public string? OrderBy { get; set; }
}

