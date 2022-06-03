namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    public interface IUserResponseModel
    {
        public string Message { get; set; }
        public IReplyMarkup? ReplyMarkup { get; set; }
    }
}
