namespace TelegramService.Infrastructure.TelegramBot.Interfaces
{
    public interface IUserResponseInlineLabel : IUserResponseLabel
    {
        public string LabelKey { get; set; }
    }
}
