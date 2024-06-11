using Infrastructure.Entity;
using Infrastructure.Repository;
using MediatR;


namespace Infrastructure.CQRSService.SotrudnikHandle
{
    public class GetSotrudnikByIdQueryHandler : IRequestHandler<GetSotrudnikByIdQuery, Infrastructure.Entity.Sotrudnik>
    {
        private readonly SotrudnikRepository _repository;

        public GetSotrudnikByIdQueryHandler(SotrudnikRepository repository)
        {
            _repository = repository;
        }

        public async Task<Infrastructure.Entity.Sotrudnik> Handle(GetSotrudnikByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
