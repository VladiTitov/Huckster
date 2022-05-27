namespace Selector.Core.Domain.Models
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
    }
}