using MediatR;
using Infrastructure.Entity;

public class GetSotrudniksByMaritalStatusQuery : IRequest<IEnumerable<Sotrudnik>>
{
    public string MaritalStatus { get; }

    public GetSotrudniksByMaritalStatusQuery(string maritalStatus)
    {
        MaritalStatus = maritalStatus;
    }
}
