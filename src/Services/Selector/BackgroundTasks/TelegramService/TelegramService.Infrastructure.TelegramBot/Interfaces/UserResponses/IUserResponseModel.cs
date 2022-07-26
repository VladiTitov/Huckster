namespace TelegramService.Infrastructure.TelegramBot.Interfaces
{
    internal interface IUserResponseModel
    {
        public string Message { get; set; }
        public IReplyMarkup? ReplyMarkup { get; set; }
    }
}
