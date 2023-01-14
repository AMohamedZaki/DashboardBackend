namespace Dashboard.Helper.Dtos.Contact
{
    public class ContactDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Mob { get; set; } = string.Empty;
        public string? Mob2 { get; set; } = string.Empty;
        public string? Mob3 { get; set; } = string.Empty;
        public string? Exten { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public int AccId { get; set; } = 0;
    }
}
