using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.SharedKernel;

namespace Dashboard.Core.Entities
{
    public class OrderItem : BaseEntity<int>
    {
        public int ItemId { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public int Price { get; set; } = 0;
        public int Total { get; set; } = 0;
        public string? Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; } = 0;
    }
}
