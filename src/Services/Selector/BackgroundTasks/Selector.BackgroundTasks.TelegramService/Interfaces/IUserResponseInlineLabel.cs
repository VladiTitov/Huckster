namespace Selector.BackgroundTasks.TelegramService.Interfaces
{
    public interface IUserResponseInlineLabel : IUserResponseLabel
    {
        public string LabelKey { get; set; }  
    }
}