namespace Dashboard.Helper.Dtos.City
{

    public class DistrictFilterDto : PaginationFilter
    {
        public string Name { get; set; }

        public int? CityId { get; set; }
    }
}
