namespace Dashboard.Helper.Dtos.Location
{
    public class DistrictDto: LocationBaseDto<long>
    {
        public string CityNameEn { get; set; }
        public string CityNameAr { get; set; }
        public int CityId { get; set; }
    }
}
