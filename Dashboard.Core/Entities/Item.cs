using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.SharedKernel;

namespace Dashboard.Core.Entities
{
    public class Item : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? DescArabic { get; set; }
        public string? DescEnglish { get; set; }
        public int Price { get; set; }
        public string MainCategory { get; set; }
        public int status { get; set; }
        public int Type { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; } = 0;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
