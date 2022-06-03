namespace Selector.Core.Domain.Models
{
    public class SearchCriteriaModel : BaseEntity
    {
        public string Label { get; set; }
        public double MinCost { get; set; }
        public double MaxCost { get; set; }
        public Guid UserId { get; set; }
        public UserModel? User { get; set; }

        public override string ToString() 
            => $"Что ищем: {Label}.\n" +
            $"Минимальная цена: {MinCost}.\n" +
            $"Максимальная цена: {MaxCost}";
    }
}