using Ardalis.Specification;
using Dashboard.Core.Entities;

namespace Dashboard.Core.Specifications
{
    public sealed class GovByFilterSpec : Specification<Governorate>, ISingleResultSpecification
    {
        public GovByFilterSpec(GovFilter filter)
        {
            if (!filter.IsTrackingEnabled)
            {
                Query
                  .AsNoTracking();
            }

            if (filter.LoadChildren)
            {
            }

            if (filter.Id != null)
            {
                Query
                  .Where(b => b.Id == filter.Id);
            }

        }
    }
}
