namespace Selector.Core.Domain.Models
{
    public class SearchCriteriaModel : BaseEntity
    {
        public string Label { get; set; }
        public double MinCost { get; set; }
        public double MaxCost { get; set; }
        public long UserId { get; set; }
        public UserModel User { get; set; }
    }
}