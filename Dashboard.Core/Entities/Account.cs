using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dashboard.SharedKernel;

namespace Dashboard.Core.Entities
{
    public class Account : BaseEntity<int>
    {
        public string Name { get; set; }
        public string AccountType { get; set; }
        public string? Tel { get; set; }
        public string? Tel2 { get; set; }
        public string? Tel3 { get; set; }
        public string? Exten { get; set; }
       
        [ForeignKey("Governorate")]
        public int? GovernorateId { get; set; }
        public virtual Governorate Governorate { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        
        [ForeignKey("District")]
        public int? DistrictId { get; set; }
        public virtual District District { get; set; }

        public string? MainStreet { get; set; }
        public string? Address { get; set; }
        public string? BuildNo { get; set; }
        public string? Flat { get; set; }
        public string? Floor { get; set; }
        public string? LandMark { get; set; }
        public string? Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<Contact>? Contact { get; set; }
    }
}
