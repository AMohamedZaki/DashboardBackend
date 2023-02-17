namespace Dashboard.Helper.Dtos
{
    public class RestaurantDto
    {
        public string Name { get; set; } = string.Empty;
        public string Days { get; set; } = string.Empty;
        public int? CityId { get; set; }
    }
}
