namespace Selector.BackgroundTasks.TelegramService.Handlers
{
    internal class UserResponseService : IUserResponseService
    {
        private readonly IUserService _userService;
        private readonly IKeyboardService _keyboardService;
        private readonly IInlineKeyboardService _inlineKeyboardService;

        public UserResponseService(
            IUserService userService,
            IKeyboardService keyboardService,
            IInlineKeyboardService inlineKeyboardService)
        {
            _userService = userService;
            _keyboardService = keyboardService;
            _inlineKeyboardService = inlineKeyboardService;
        }

        public async Task<IEnumerable<IUserResponseModel>> GetResponseForStartStateAsync(
            Chat chat,
            int state,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _userService.UpdateUserStateAsync(
                chat: chat,
                state: state,
                cancellationToken: cancellationToken);

            var responseModel = GetUserResponse(
                message: MessageLabelsConstants.StartLabel,
                replyMarkup: _keyboardService
                    .GetReplyMarkup(ButtonNamesConstants.StartStateButtons));

            return new List<IUserResponseModel>() { responseModel };
        }

        public async Task<IEnumerable<IUserResponseModel>> GetResponseForListFiltersStateAsync(
            Chat chat,
            int state,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _userService.UpdateUserStateAsync(
                chat: chat,
                state: state,
                cancellationToken: cancellationToken);

            var filters = await _userService.GetSearchCriteriaListAsync(
                        chat: chat,
                        cancellationToken: cancellationToken);

            return filters
                .Select(item =>
                    GetUserResponse(
                        message: item.ToString(),
                        replyMarkup: _inlineKeyboardService
                            .GetReplyMarkup(
                                labels: ButtonNamesConstants.ListFiltersButtons)));
        }

        public async Task<IEnumerable<IUserResponseModel>> GetResponseForAddFiltetStateAsync(
            Chat chat,
            int state,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _userService.UpdateUserStateAsync(
                chat: chat,
                state: state,
                cancellationToken: cancellationToken);

            var responseModel = GetUserResponse(
                message: MessageLabelsConstants.AddFilterLabel);

            return new List<IUserResponseModel>() { responseModel };
        }

        public async Task<IEnumerable<IUserResponseModel>> GetDefaultResponseAsync()
            => await Task.Run(() =>
            {
                var responseModel = GetUserResponse();
                return new List<IUserResponseModel> { responseModel };
            });

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
