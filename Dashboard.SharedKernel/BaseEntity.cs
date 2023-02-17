using System;

namespace Dashboard.SharedKernel;

// This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
public abstract class BaseEntity<T>
{
    public T Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
}
