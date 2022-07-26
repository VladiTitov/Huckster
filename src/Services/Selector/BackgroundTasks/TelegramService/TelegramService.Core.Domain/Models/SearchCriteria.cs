namespace TelegramService.Core.Domain.Models
{
    public class SearchCriteria : BaseEntity
    {
        public string Label { get; set; }
        public double MinCost { get; set; }
        public double MaxCost { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        public override string ToString()
            => $"Что ищем: {Label}\n" +
            $"Минимальная цена: {MinCost}\n" +
            $"Максимальная цена: {MaxCost}";
    }
}
