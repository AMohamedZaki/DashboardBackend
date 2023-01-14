using Dashboard.Helper.Dtos.Contact;

namespace Dashboard.Helper.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public string? Tel { get; set; } = string.Empty;
        public string? Tel2 { get; set; } = string.Empty;
        public string? Tel3 { get; set; } = string.Empty;
        public string? Exten { get; set; } = string.Empty;
        public int GovernorateId { get; set; } = 0;
        public int CityId { get; set; } = 0;
        public int DistrictId { get; set; } = 0;
        public string? MainStreet { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? BuildNo { get; set; } = string.Empty;
        public string? Flat { get; set; } = string.Empty;
        public string? Floor { get; set; } = string.Empty;
        public string? LandMark { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }

        public List<ContactDto> Contact { get; set; }
    }
}
