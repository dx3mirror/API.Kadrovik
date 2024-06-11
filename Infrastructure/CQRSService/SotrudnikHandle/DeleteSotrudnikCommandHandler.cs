using Infrastructure.Repository;
using MediatR;

public class DeleteSotrudnikCommandHandler : IRequestHandler<DeleteSotrudnikCommand, Unit>
{
    private readonly SotrudnikRepository _repository;

    public DeleteSotrudnikCommandHandler(SotrudnikRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteSotrudnikCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}