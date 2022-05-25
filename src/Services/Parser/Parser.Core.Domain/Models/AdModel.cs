namespace Parser.Core.Domain.Models
{
    public class AdModel : BaseEntity
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

        public string GetId(string link)
            => new Regex(@"[0-9]+")
                .Match(link)
                .Value;

        public bool IsNull()
            => UrlId == null || UrlId.Equals("") ||
               Label == null || Label.Equals("") ||
               Label == null || Link.Equals("");
    }
}
