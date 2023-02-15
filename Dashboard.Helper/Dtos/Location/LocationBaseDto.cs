namespace Dashboard.Helper.Dtos.Location
{
    public class LocationBaseDto<T>: PaginationFilter
    {
            public T Id { get; set; }
            public string Name_ar { get; set; }
            public string Name_en { get; set; }
    }
}
