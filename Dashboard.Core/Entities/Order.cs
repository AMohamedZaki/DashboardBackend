using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dashboard.SharedKernel;

namespace Dashboard.Core.Entities
{
    public class Order : BaseEntity<int>
    {
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public DateTime ProcessDate { get; set; }
        public DateTime ReadyDate { get; set; }
        public DateTime OnDeliveryDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int Tax { get; set; } = 0;
        public int Delivery { get; set; } = 0;
        public int SubTotal { get; set; } = 0;
        public int Total { get; set; } = 0;
        public int BranId { get; set; } = 0;
        public int DriverId { get; set; } = 0;
        public int Type { get; set; } = 0;
        public string? Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        [ForeignKey("Contact")]
        public int ContactId { get; set; } = 0;

    }
}
