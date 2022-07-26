using Microsoft.Extensions.Logging;
using Local = TelegramService.Core.Domain.Models;

namespace TelegramService.Infrastructure.TelegramBot.Handlers
{
    internal class MessageTelegramHandler : IMessageTelegramHandler
    {
        private readonly ILogger<MessageTelegramHandler> _logger;
        private readonly IUserResponseService _userResponseService;
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly ISearchCriteriaRepositoryAsync _searchCriteriaRepositoryAsync;
        private readonly ITelegramBotServiceClientWrapper _telegramBotServiceClientWrapper;

        public MessageTelegramHandler(
            ILogger<MessageTelegramHandler> logger,
            IUserResponseService userResponseService,
            IUserRepositoryAsync userRepositoryAsync,
            ISearchCriteriaRepositoryAsync searchCriteriaRepositoryAsync,
            ITelegramBotServiceClientWrapper telegramBotServiceClientWrapper)
        {
            _logger = logger;
            _userResponseService = userResponseService;
            _userRepositoryAsync = userRepositoryAsync;
            _searchCriteriaRepositoryAsync = searchCriteriaRepositoryAsync;
            _telegramBotServiceClientWrapper = telegramBotServiceClientWrapper;
        }

        public async Task Handle( 
            Message message, 
            CancellationToken cancellationToken = default)
        {
            var userResponseModelList = await MessageStateAsync(
                message: message,
                cancellationToken: cancellationToken);

            foreach (var userResponseModel in userResponseModelList)
                await _telegramBotServiceClientWrapper.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: userResponseModel.Message,
                    replyMarkup: userResponseModel.ReplyMarkup,
                    cancellationToken: cancellationToken);
        }

        private async Task<IEnumerable<IUserResponseModel>> MessageStateAsync(
            Message message,
            CancellationToken cancellationToken = default)
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
            CancellationToken cancellationToken = default)
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
            CancellationToken cancellationToken = default)
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
            var user = await _userRepositoryAsync.GetByUserIdAsync(chat.Id, cancellationToken) ??
                await _userRepositoryAsync.AddAsync(
                    new Local.User
                    {
                        UserId = chat.Id,
                        Username = chat.Username,
                        FirstName = chat.FirstName,
                        LastName = chat.LastName
                    },
                    cancellationToken);

            searchCriteria.UserId = user.Id;

            await _searchCriteriaRepositoryAsync.AddAsync(
                entity: searchCriteria,
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
