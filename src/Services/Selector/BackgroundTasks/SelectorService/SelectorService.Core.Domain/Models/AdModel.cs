namespace SelectorService.Core.Domain.Models
{
    public class AdModel : BaseAdModel
    {
        public override bool Equals(object? obj)
        {
            var searchCriteria = obj as SearchCriteria;

            var cost = Cost.ConvertToDouble();

            var priceInRange = searchCriteria.MinCost <= cost
                && cost <= searchCriteria.MaxCost;
            var nameIsEquals = Label.IsContainsKey(searchCriteria.Label);

            return priceInRange && nameIsEquals;
        }
    }
}
