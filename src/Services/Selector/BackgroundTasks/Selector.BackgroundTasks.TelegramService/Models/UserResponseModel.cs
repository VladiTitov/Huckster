namespace Selector.BackgroundTasks.TelegramService.Models
{
    public class UserResponseModel : IUserResponseModel
    {
        public string Message { get; set; }
        public IReplyMarkup? ReplyMarkup { get; set; }
    }
}
