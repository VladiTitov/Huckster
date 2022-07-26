namespace TelegramService.Infrastructure.TelegramBot.Models
{
    internal class UserResponseModel : IUserResponseModel
    {
        public string Message { get; set; }
        public IReplyMarkup? ReplyMarkup { get; set; }
    }
}
