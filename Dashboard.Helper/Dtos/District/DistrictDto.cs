namespace Dashboard.Helper.Dtos
{
    public class DistrictDto
    {
        public int Id { get; set; } = 0;
        public int CityId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public bool Active { get; set; }
        public int Delivery { get; set; } = 0;
    }
}
