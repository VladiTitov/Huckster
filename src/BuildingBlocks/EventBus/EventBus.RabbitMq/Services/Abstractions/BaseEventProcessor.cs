namespace EventBus.RabbitMq.Services.Abstractions
{
    internal class BaseEventProcessor : IEventProcessor
    {
        public virtual Task ProcessEvent(string message)
        {
            Console.WriteLine(message);
            return Task.CompletedTask;
        }
    }
}