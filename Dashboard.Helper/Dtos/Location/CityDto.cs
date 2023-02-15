namespace Dashboard.Helper.Dtos.Location
{
    public class CityDto: LocationBaseDto<int>
    {
        public decimal? Lat { get; set; }
        public decimal? Long { get; set; }
        public string RegionName { get; set; }
    }
}
