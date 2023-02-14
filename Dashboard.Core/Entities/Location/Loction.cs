using System.ComponentModel.DataAnnotations;

namespace Dashboard.Core.Entities
{
    public abstract class Loction<T>
    {
        [Key]
        public T Id { get; set; }
        public string Name_ar { get; set; }
        public string Name_en { get; set; }
    }
}