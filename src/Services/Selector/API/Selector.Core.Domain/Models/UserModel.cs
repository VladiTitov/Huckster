namespace Selector.Core.Domain.Models
{
    public class UserModel : BaseEntity
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public IEnumerable<SearchCriteriaModel> SearchModels { get; set; }
    }
}