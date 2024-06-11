using Infrastructure.Entity;
using MediatR;

public class AddSotrudnikCommand : IRequest<Unit>
{
    public Sotrudnik Sotrudnik { get; }

    public AddSotrudnikCommand(Sotrudnik sotrudnik)
    {
        Sotrudnik = sotrudnik;
    }
}