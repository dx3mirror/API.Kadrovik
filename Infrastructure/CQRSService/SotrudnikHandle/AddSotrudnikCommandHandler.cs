using MediatR;
using Infrastructure.Repository;

public class AddSotrudnikCommandHandler : IRequestHandler<AddSotrudnikCommand, Unit>
{
    private readonly SotrudnikRepository _repository;

    public AddSotrudnikCommandHandler(SotrudnikRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(AddSotrudnikCommand request, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(request.Sotrudnik);
        return Unit.Value;
    }
}


