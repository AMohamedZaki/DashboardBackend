using System.ComponentModel.DataAnnotations;

namespace Dashboard.Core.Entities
{
    public abstract class Loction
    {
        [Key]
        public int Id { get; set; }
        public string Name_ar { get; set; }
        public string Name_en { get; set; }
    }
}