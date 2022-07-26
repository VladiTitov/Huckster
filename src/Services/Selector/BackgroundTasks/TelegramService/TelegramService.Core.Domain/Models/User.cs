namespace TelegramService.Core.Domain.Models
{
    public class User : BaseEntity
    {
        public long UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }

        [JsonIgnore]
        public IEnumerable<SearchCriteria> SearchCriterias { get; set; }
    }
}