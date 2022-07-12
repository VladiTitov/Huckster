namespace Common.Models
{
    public class BaseAdModel : BaseEntity
    {
        public string UrlId { get; set; }
        public string Link { get; set; }
        public string Label { get; set; }
        public string Cost { get; set; }
    }
}
