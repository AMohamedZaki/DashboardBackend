namespace Dashboard.Helper.Dtos.Contact
{

    public class ContactFilterDto : PaginationFilter
    {
        public string Name { get; set; }
        public string Mob { get; set; }
        public string Mob2 { get; set; }
        public string Mob3 { get; set; }
    }
}
