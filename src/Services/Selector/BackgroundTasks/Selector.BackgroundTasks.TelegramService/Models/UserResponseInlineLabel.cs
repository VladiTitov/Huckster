namespace Selector.BackgroundTasks.TelegramService.Models
{
    public class UserResponseInlineLabel : 
        UserResponseLabel, IUserResponseInlineLabel
    {
        public string LabelKey { get; set; }
    }
}
