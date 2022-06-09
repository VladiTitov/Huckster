namespace Selector.BackgroundTasks.TelegramService.Interfaces.Models
{
    public interface IUserResponseInlineLabel : IUserResponseLabel
    {
        public string LabelKey { get; set; }  
    }
}