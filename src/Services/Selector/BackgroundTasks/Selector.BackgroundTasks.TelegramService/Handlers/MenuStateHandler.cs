namespace Selector.BackgroundTasks.TelegramService.Handlers
{
    internal class MenuStateHandler : IMenuStateHandler
    {
        private readonly IUserResponseService _userResponseService;

        public MenuStateHandler(IUserResponseService userResponseService)
        {
            _userResponseService = userResponseService;
        }

        public async Task<IEnumerable<IUserResponseModel>> HandleAsync(
            MenuState state,
            Message message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            switch (state)
            {
                case MenuState.Start:
                    return await _userResponseService
                        .GetResponseForStartStateAsync(
                            chat: message.Chat,
                            state: (int)state,
                            cancellationToken: cancellationToken);
                case MenuState.ListFilters:
                    return await _userResponseService
                        .GetResponseForListFiltersStateAsync(
                            chat: message.Chat,
                            state: (int)state,
                            cancellationToken: cancellationToken);
                case MenuState.AddFilter:
                    return await _userResponseService
                        .GetResponseForAddFiltetStateAsync(
                            chat: message.Chat,
                            state: (int)state,
                            cancellationToken: cancellationToken);
                default:
                    return await _userResponseService
                        .GetDefaultResponseAsync();
            }
        }
    }
}
