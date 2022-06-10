namespace EventBus.RabbitMq.Exceptions
{
    internal class ServerIsNotAvailable : Exception
    {
        private static readonly string message = "Server is not available:";
        public ServerIsNotAvailable(string serverIp) : base($"{message} {serverIp}") 
        { 

        }
    }
}