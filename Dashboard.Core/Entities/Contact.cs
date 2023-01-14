using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Dashboard.SharedKernel;

namespace Dashboard.Core.Entities
{
    public class Contact : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? Mob { get; set; }
        public string? Mob2 { get; set; }
        public string? Mob3 { get; set; }
        public string? Exten { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        
        
        [ForeignKey("Account")]
        public int AccId { get; set; } = 0;

        [JsonIgnore]
        [IgnoreDataMember]
        public Account Account { get; set; }
    }
}
