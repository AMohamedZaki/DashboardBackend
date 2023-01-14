using Ardalis.Specification;
using System;
using Dashboard.Core.Entities;

namespace Dashboard.Core.Specifications
{
    public sealed class CitiesByFilterSpec : Specification<City>
    {
        public CitiesByFilterSpec(CityFilter filter)
        {
            if (!filter.IsTrackingEnabled)
            {
                Query
                  .AsNoTracking();
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                Query
                  .Search(b => b.Name, $"% {filter.Name} %");
            }

            if (filter.IsPagingEnabled)
            {
                Query
                  .Skip(PaginationHelper.CalculateSkip(filter))
                  .Take(PaginationHelper.CalculateTake(filter));
            }

            if (string.IsNullOrEmpty(filter.OrderBy))
            {
                return;
            }

            if (string.Equals(filter.OrderBy!, nameof(City.Name), StringComparison.CurrentCultureIgnoreCase))
                Query.OrderBy(b => b.Name);
            if (string.Equals(filter.OrderBy!, nameof(City.Id), StringComparison.CurrentCultureIgnoreCase))
                Query.OrderBy(b => b.Id);
        }
    }
}
