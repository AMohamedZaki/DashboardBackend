namespace Dashboard.Helper.Dtos.City
{

    public class CityFilterDto: PaginationFilter
    {
        public string Name { get; set; }

        public int? GovId { get; set; }
    }
}
