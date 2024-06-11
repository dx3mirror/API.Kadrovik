using Infrastructure.Entity;
using MediatR;
public class UpdateSotrudnikCommand : IRequest<Unit>
{
    public Sotrudnik Sotrudnik { get; }

    public UpdateSotrudnikCommand(Sotrudnik sotrudnik)
    {
        Sotrudnik = sotrudnik;
    }
}
