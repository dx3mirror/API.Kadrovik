using MediatR;

public class DeleteSotrudnikCommand : IRequest<Unit>
{
    public int Id { get; }

    public DeleteSotrudnikCommand(int id)
    {
        Id = id;
    }
}
