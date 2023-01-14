namespace Dashboard.Helper.Dtos
{
    public class CityDto
    {
        public int Id { get; set; } = 0;
        public int GovId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public bool Active { get; set; }
        public int BranId { get; set; } = 0;
    }
}
