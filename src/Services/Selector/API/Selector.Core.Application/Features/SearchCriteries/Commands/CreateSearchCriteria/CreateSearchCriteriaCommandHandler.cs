namespace Selector.Core.Application.Features.SearchCriteries.Commands.CreateSearchCriteria
{
    public class CreateSearchCriteriaCommandHandler
         : IRequestHandler<CreateSearchCriteriaCommand, Guid>
    {
        private readonly ISearchCriteriaRepositoryAsync _searchCriteriaRepository;
        private readonly IUserRepositoryAsync _userRepository;

        public CreateSearchCriteriaCommandHandler(
            ISearchCriteriaRepositoryAsync searchCriteriaRepository,
            IUserRepositoryAsync userRepository) 
        {
            _searchCriteriaRepository = searchCriteriaRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(
            CreateSearchCriteriaCommand request, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var user = new UserModel
            {
                UserId = 1,
                FirstName = "firstName",
                LastName = "lastName",
                Username = "username"
            };

            await _userRepository.AddAsync(user, cancellationToken);

            var entity = new SearchCriteriaModel
            {
                Label = request.Label,
                MinCost = request.MinCost,
                MaxCost = request.MaxCost,
                User = user
            };

            await _searchCriteriaRepository.AddAsync(entity, cancellationToken);

            return entity.Id;
        }
    }
}
