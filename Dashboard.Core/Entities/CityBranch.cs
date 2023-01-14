namespace Dashboard.Core.Entities
{
    public class CityBranch
    {
        public int CityId { get; set; }
        public City City { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
