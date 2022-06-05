namespace Selector.BackgroundTasks.TelegramService.Handlers
{
    internal class MessageTelegramHandler : IMessageTelegramHandler
    {
        private readonly ILogger<MessageTelegramHandler> _logger;
        private readonly IMenuStateHandler _menuStateHandler;
        private readonly IUserService _userService;

        public MessageTelegramHandler(
            ILogger<MessageTelegramHandler> logger,
            IMenuStateHandler menuStateHandler,
            IUserService userService)
        {
            _logger = logger;
            _menuStateHandler = menuStateHandler;
            _userService = userService;
        }

        public async Task Handle(
            ITelegramBotClient botClient,
            Message message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var userResponseModelList = await MessageStateAsync(
                message: message,
                cancellationToken: cancellationToken);

            foreach (var userResponseModel in userResponseModelList)
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: userResponseModel.Message,
                    replyMarkup: userResponseModel.ReplyMarkup,
                    cancellationToken: cancellationToken);
        }

        private async Task<IEnumerable<IUserResponseModel>> MessageStateAsync(
            Message message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var messageText = message?.Text;

            switch (messageText)
            {
                case "/start":
                    return await _menuStateHandler
                        .HandleAsync(
                            MenuState.Start, 
                            message,
                            cancellationToken);
                case "/filters":
                    return await _menuStateHandler
                        .HandleAsync(
                            MenuState.ListFilters,
                            message,
                            cancellationToken);
                case "Показать фильтры":
                    return await _menuStateHandler
                        .HandleAsync(
                            MenuState.ListFilters,
                            message,
                            cancellationToken);
                case "Добавить фильтр":
                    return await _menuStateHandler
                        .HandleAsync(
                            MenuState.AddFilter,
                            message,
                            cancellationToken);
                default:
                    return await MessageTextHandlerAsync(
                        message,
                        cancellationToken);
            }
        }

        private async Task<IReadOnlyList<IUserResponseModel>> MessageTextHandlerAsync(
            Message message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var messageText = message?.Text;
            var data = messageText.Split('-');
            if (!data.Length.Equals(3))
                return new List<IUserResponseModel>
                {
                    new UserResponseModel
                    {
                        Message = MessageLabelsConstants.DefaultLabel,
                        ReplyMarkup = null
                    }
                };

            var searchCriteria = new SearchCriteriaModel
            {
                Label = data[0],
                MinCost = data[1].ConvertToDouble(),
                MaxCost = data[2].ConvertToDouble()
            };

            await _userService.AddSearchCriteriaAsync(
                chat: message.Chat, 
                model: searchCriteria, 
                cancellationToken: cancellationToken);

            return new List<IUserResponseModel>
            {
                new UserResponseModel
                {
                    Message = $"Добавлен новый фильтр для поиска: {searchCriteria.Label}, цена с {searchCriteria.MinCost} по {searchCriteria.MaxCost}",
                    ReplyMarkup = null
                }
            };
        }
    }
}
