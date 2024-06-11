using MediatR;
public class GetSotrudniksByEnglishKnowledgeQuery : IRequest<IEnumerable<Infrastructure.Entity.Sotrudnik>>
{
    public string EnglishLevel { get; }

    public GetSotrudniksByEnglishKnowledgeQuery(string englishLevel)
    {
        EnglishLevel = englishLevel;
    }
}