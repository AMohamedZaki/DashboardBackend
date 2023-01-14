using Ardalis.Specification;
using Dashboard.Core.Entities;

namespace Dashboard.Core.Specifications
{
    public sealed class CityByFilterSpec : Specification<City>, ISingleResultSpecification
    {
        public CityByFilterSpec(CityFilter filter)
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
