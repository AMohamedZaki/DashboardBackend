namespace Dashboard.Helper.Dtos.Account
{

    public class AccountFilterDto : PaginationFilter
    {
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Tel2 { get; set; }
        public string Tel3 { get; set; }
    }
}
