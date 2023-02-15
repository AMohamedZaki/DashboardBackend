namespace Dashboard.Helper.Dtos.Location
{
    public class CityDto: LocationBaseDto<int>
    {
        public decimal? Lat { get; set; }
        public decimal? Long { get; set; }
        public string RegionNameEn { get; set; }
        public int? RegionId { get; set; }
        public string RegionNameAr { get; set; }
    }
}
