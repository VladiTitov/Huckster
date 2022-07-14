namespace Selector.BackgroundTasks.TelegramService.Handlers
{
    internal class MessageTelegramHandler : IMessageTelegramHandler
    {
        private readonly ILogger<MessageTelegramHandler> _logger;
        private readonly IPersistenceService _persistenceService;
        private readonly IUserResponseService _userResponseService;

        public MessageTelegramHandler(
            ILogger<MessageTelegramHandler> logger,
            IPersistenceService persistenceService,
            IUserResponseService userResponseService)
        {
            _logger = logger;
            _persistenceService = persistenceService;
            _userResponseService = userResponseService;
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
                    return _userResponseService.GetResponseForStartState();
                case "Показать фильтры":
                    return await _userResponseService
                        .GetResponseForListFiltersStateAsync(
                            chat: message.Chat,
                            cancellationToken: cancellationToken);
                case "Добавить фильтр":
                    return _userResponseService.GetResponseForAddFilterState();
                case null:
                    return await GetDefaultAnswer(cancellationToken);
                default:
                    return await MessageTextHandlerAsync(
                        message: message,
                        cancellationToken: cancellationToken);
            }
        }

        private async Task<IReadOnlyList<IUserResponseModel>> MessageTextHandlerAsync(
            Message message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var messageText = message?.Text;
            var data = messageText.Split('-');
            return data.Length.Equals(3)
                ? await GetAnswerAsync(
                    chat: message.Chat,
                    searchCriteria: new SearchCriteria
                        {
                            Label = data[0],
                            MinCost = data[1].ConvertToDouble(),
                            MaxCost = data[2].ConvertToDouble()
                        },
                    cancellationToken: cancellationToken)
                : await GetDefaultAnswer(cancellationToken);
        }

        private async Task<IReadOnlyList<IUserResponseModel>> GetDefaultAnswer(
            CancellationToken cancellationToken = default(CancellationToken))
            => await Task.Run(() => new List<IUserResponseModel>
                {
                    new UserResponseModel
                    {
                        Message = MessageLabelsConstants.DefaultLabel,
                        ReplyMarkup = null
                    }
                },
                cancellationToken: cancellationToken);

        private async Task<IReadOnlyList<IUserResponseModel>> GetAnswerAsync(
            Chat chat,
            SearchCriteria searchCriteria,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _persistenceService.AddSearchCriteriaAsync(
                chat: chat,
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
