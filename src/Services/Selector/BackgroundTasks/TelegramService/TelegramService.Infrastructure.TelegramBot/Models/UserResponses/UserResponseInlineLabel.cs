namespace TelegramService.Infrastructure.TelegramBot.Models
{
    public class UserResponseInlineLabel :
        UserResponseLabel, IUserResponseInlineLabel
    {
        public string LabelKey { get; set; }
    }
}
