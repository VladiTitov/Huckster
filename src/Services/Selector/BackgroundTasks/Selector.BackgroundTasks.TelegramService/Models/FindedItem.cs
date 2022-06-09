namespace Selector.BackgroundTasks.TelegramService.Models
{
    internal class FindedItem
    {
        public Guid UserId { get; set; }
        public string UrlId { get; set; }
        public string Link { get; set; }
        public string Label { get; set; }
        public string Cost { get; set; }
    }
}
