namespace Selector.BackgroundTasks.SelectorService.Models
{
    internal class AdModel : BaseEntity
    {
        private string _urlId;
        public string UrlId
        {
            get => _urlId;
            set => _urlId = value == null ? "" : GetId(value);
        }

        public string Link { get; set; }
        public string Label { get; set; }

        private string _cost;
        public string Cost
        {
            get => _cost;
            set => _cost = value ?? "Договорная";
        }

        public override string ToString()
            => $"{UrlId} - {Label} - {Cost} - {Link}";

        private string GetId(string link)
            => new Regex(@"[0-9]+")
                .Match(link)
                .Value;

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
