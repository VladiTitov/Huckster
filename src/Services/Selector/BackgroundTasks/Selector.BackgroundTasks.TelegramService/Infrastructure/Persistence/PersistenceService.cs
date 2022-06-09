namespace Selector.BackgroundTasks.TelegramService.Infrastructure.Persistence
{
    internal class PersistenceService : IPersistenceService
    {
        private readonly IUserService _userService;
        private readonly ISearchCriteriaService _searchCriteriaService;

        public PersistenceService(
            IUserService userService,
            ISearchCriteriaService searchCriteriaService)
        {
            _userService = userService;
            _searchCriteriaService = searchCriteriaService;
        }

        public async Task<UserModel?> GetUserModelById(
            Guid id,
            CancellationToken cancellationToken = default(CancellationToken)) 
        {
            return await _userService.GetModelByIdAsync(
                id: id,
                cancellationToken: cancellationToken);
        }

        public async Task UpdateSearchCriteriaAsync(
            Chat chat,
            SearchCriteriaModel searchCriteria,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _userService.CheckUserRegistrationAsync(
                chat: chat,
                cancellationToken: cancellationToken);

            await _searchCriteriaService.UpdateModelAsync(
                searchCriteria: searchCriteria,
                cancellationToken: cancellationToken);
        }

        public async Task DeleteSearchCriteriaAsync(
            Chat chat,
            Guid criteriaId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _userService.CheckUserRegistrationAsync(
                chat: chat,
                cancellationToken: cancellationToken);

            var model = await _searchCriteriaService.GetModelByIdAsync(
                id: criteriaId, 
                cancellationToken: cancellationToken);

            await _searchCriteriaService.DeleteModelAsync(
                searchCriteria: model, 
                cancellationToken: cancellationToken);
        }

        public async Task AddSearchCriteriaAsync(
            Chat chat,
            SearchCriteriaModel model,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _userService.CheckUserRegistrationAsync(
                chat: chat,
                cancellationToken: cancellationToken);

            var userId = await _userService.GetIdByUserIdAsync(
                userId: chat.Id, 
                cancellationToken: cancellationToken);

            model.UserId = userId;

            await _searchCriteriaService.AddModelAsync(
                model: model,
                cancellationToken: cancellationToken);
        }

        public async Task<IReadOnlyList<SearchCriteriaModel>> GetSearchCriteriaListAsync(
            Chat chat,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _userService.CheckUserRegistrationAsync(
               chat: chat,
               cancellationToken: cancellationToken);

            var userId = await _userService.GetIdByUserIdAsync(
                userId: chat.Id,
                cancellationToken: cancellationToken);

            return await _searchCriteriaService.GetModelListByFilterAsync(
                filter: i => i.UserId.Equals(userId), 
                cancellationToken: cancellationToken);
        }
    }

}
