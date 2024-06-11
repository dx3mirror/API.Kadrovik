using Infrastructure.Repository;
using MediatR;

namespace Infrastructure.CQRSService.Sotrudnik
{
    public class UpdateSotrudnikCommandHandler : IRequestHandler<UpdateSotrudnikCommand, Unit>
    {
        private readonly SotrudnikRepository _repository;

        public UpdateSotrudnikCommandHandler(SotrudnikRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateSotrudnikCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(request.Sotrudnik);
            return Unit.Value;
        }
    }
}
