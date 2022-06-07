namespace Selector.BackgroundTasks.TelegramService.Handlers
{
    internal class UserResponseService : IUserResponseService
    {
        private readonly IPersistenceService _persistenceService;
        private readonly IKeyboardService _keyboardService;
        private readonly IInlineKeyboardService _inlineKeyboardService;

        public UserResponseService(
            IPersistenceService persistenceService,
            IKeyboardService keyboardService,
            IInlineKeyboardService inlineKeyboardService)
        {
            _persistenceService = persistenceService;
            _keyboardService = keyboardService;
            _inlineKeyboardService = inlineKeyboardService;
        }

        public IEnumerable<IUserResponseModel> GetDefaultResponse()
        {
            var responseModel = GetUserResponse();
            return new List<IUserResponseModel> { responseModel };
        }

        public IEnumerable<IUserResponseModel> GetResponseForStartState()
        {
            var labels = ButtonNamesConstants.StartStateButtons;
            var response = labels.Select(label => new UserResponseLabel { LabelName = label });

            var responseModel = GetUserResponse(
                message: MessageLabelsConstants.StartLabel,
                replyMarkup: _keyboardService
                    .GetReplyMarkup(response));

            return new List<IUserResponseModel>() { responseModel };
        }

        public IEnumerable<IUserResponseModel> GetResponseForAddFilterState()
        {
            var responseModel = GetUserResponse(
                message: MessageLabelsConstants.AddFilterLabel);

            return new List<IUserResponseModel>() { responseModel };
        }

        public async Task<IEnumerable<IUserResponseModel>> GetResponseForListFiltersStateAsync(
            Chat chat,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var filters = await _persistenceService.GetSearchCriteriaListAsync(
                        chat: chat,
                        cancellationToken: cancellationToken);

            if (filters.Count.Equals(0))
                return new List<IUserResponseModel>
                { 
                    GetUserResponse(MessageLabelsConstants.FiltersEmpty)
                };

            var buttonLabel = ButtonNamesConstants.DeleteInlineButton;
            var response = filters.Select(item => new UserResponseInlineLabel
            {
                LabelName = buttonLabel,
                LabelKey = item.Id.ToString()
            });

            return filters
                .Select(item =>
                    GetUserResponse(
                        message: item.ToString(),
                        replyMarkup: _inlineKeyboardService
                            .GetReplyMarkup(
                                labels: response)));
        }

        private IUserResponseModel GetUserResponse(
            string message = MessageLabelsConstants.DefaultLabel,
            IReplyMarkup? replyMarkup = null)
        {
            return new UserResponseModel
            {
                Message = message,
                ReplyMarkup = replyMarkup
            };
        }
    }
}
