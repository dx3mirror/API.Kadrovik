using Infrastructure.Entity;
using MediatR;

public class GetSotrudnikByIdQuery : IRequest<Sotrudnik>
{
    public int Id { get; }

    public GetSotrudnikByIdQuery(int id)
    {
        Id = id;
    }
}