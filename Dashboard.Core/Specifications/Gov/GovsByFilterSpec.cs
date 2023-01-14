using System;
using Dashboard.Core.Entities;
using Ardalis.Specification;

namespace Dashboard.Core.Specifications
{
    public class GovsByFilterSpec : Specification<Governorate>
    {
        public GovsByFilterSpec(GovFilter filter)
        {
            if (!filter.IsTrackingEnabled)
            {
                Query
                  .AsNoTracking();
            }

            if (filter.LoadChildren)
            {

            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                Query
                 .Where(b => b.Name.ToLower() == filter.Name.ToLower());
            }

            if (filter.Active != null)
            {
                Query
                  .Where(b => b.Active == filter.Active);
            }

            if (filter.IsPagingEnabled)
            {
                Query
                  .Skip(PaginationHelper.CalculateSkip(filter))
                  .Take(PaginationHelper.CalculateTake(filter));
            }

            if (filter.OrderBy == null)
            {
                return;
            }

            if (string.Equals(filter.OrderBy!, nameof(Governorate.Name), StringComparison.CurrentCultureIgnoreCase))
                Query.OrderBy(b => b.Name);
        }
    }
}
