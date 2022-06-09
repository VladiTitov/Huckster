namespace Selector.BackgroundTasks.TelegramService.Interfaces.Models
{
    public interface IUserResponseModel
    {
        public string Message { get; set; }
        public IReplyMarkup? ReplyMarkup { get; set; }
    }
}
