using Infrastructure.Entity;
using Infrastructure.Repository;
using MediatR;

namespace Infrastructure.CQRSService.SotrudnikHandle
{
    public class GetSotrudniksByEnglishKnowledgeQueryHandler : IRequestHandler<GetSotrudniksByEnglishKnowledgeQuery, IEnumerable<Infrastructure.Entity.Sotrudnik>>
    {
        private readonly SotrudnikRepository _repository;

        public GetSotrudniksByEnglishKnowledgeQueryHandler(SotrudnikRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Infrastructure.Entity.Sotrudnik>> Handle(GetSotrudniksByEnglishKnowledgeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByEnglishKnowledgeAsync(request.EnglishLevel);
        }
    }
}
