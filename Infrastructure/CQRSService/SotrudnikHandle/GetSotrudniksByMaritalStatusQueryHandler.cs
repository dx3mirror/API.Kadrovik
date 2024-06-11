using Infrastructure.Entity;
using Infrastructure.Repository;
using MediatR;

public class GetSotrudniksByMaritalStatusQueryHandler : IRequestHandler<GetSotrudniksByMaritalStatusQuery, IEnumerable<Sotrudnik>>
{
    private readonly SotrudnikRepository _repository;

    public GetSotrudniksByMaritalStatusQueryHandler(SotrudnikRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Sotrudnik>> Handle(GetSotrudniksByMaritalStatusQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByMaritalStatusAsync(request.MaritalStatus);
    }
}