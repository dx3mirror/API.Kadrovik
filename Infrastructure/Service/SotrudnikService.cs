using Infrastructure.Entity;
using Infrastructure.Service.Interface;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;


public class SotrudnikService : ISotrudnikService
{
    private readonly IMediator _mediator;
    private readonly IMemoryCache _cache;
    private readonly IRabbitMQPublisher _rabbitMQPublisher;
    private readonly ILogger _logger;

    public SotrudnikService(IMediator mediator, IMemoryCache cache, IRabbitMQPublisher rabbitMQPublisher, ILogger logger)
    {
        _mediator = mediator;
        _cache = cache;
        _rabbitMQPublisher = rabbitMQPublisher;
        _logger = logger;
    }
    public async Task AddSotrudnik(Sotrudnik sotrudnik)
    {
        try
        {
            await _rabbitMQPublisher.PublishAddSotrudnikAsync(sotrudnik);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при добавлении сотрудника в очередь");
            throw;
        }
    }

    public async Task UpdateSotrudnik(Sotrudnik sotrudnik)
    {
        try
        {
            await _rabbitMQPublisher.PublishUpdateSotrudnikAsync(sotrudnik);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при обновлении сотрудника в очереди");
            throw;
        }
    }

    public async Task DeleteSotrudnik(int id)
    {
        try
        {
            await _rabbitMQPublisher.PublishDeleteSotrudnikAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при удалении сотрудника из очереди RabbitMQ");
            throw;
        }
    }



    public async Task<IEnumerable<Sotrudnik>> GetSotrudniksByMaritalStatus(string maritalStatus)
    {
        var cacheKey = $"SotrudniksByMaritalStatus_{maritalStatus}";
        try
        {
            if (!_cache.TryGetValue(cacheKey, value: out IEnumerable<Sotrudnik> sotrudniks))
            {
                sotrudniks = await _mediator.Send(new GetSotrudniksByMaritalStatusQuery(maritalStatus));
                _cache.Set(cacheKey, sotrudniks, TimeSpan.FromMinutes(10)); 
            }
            return sotrudniks;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while getting sotrudniks by marital status.", ex);
        }
    }

    public async Task<IEnumerable<Sotrudnik>> GetSotrudniksByEnglishKnowledge(string englishLevel)
    {
        var cacheKey = $"SotrudniksByEnglishKnowledge_{englishLevel}";
        try
        {
            if (!_cache.TryGetValue(cacheKey, value: out IEnumerable<Sotrudnik> sotrudniks))
            {
                sotrudniks = await _mediator.Send(new GetSotrudniksByEnglishKnowledgeQuery(englishLevel));
                _cache.Set(cacheKey, sotrudniks, TimeSpan.FromMinutes(10));
            }
            return sotrudniks;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while getting sotrudniks by English knowledge.", ex);
        }
    }

    public async Task<Sotrudnik> GetSotrudnikById(int id)
    {
        var cacheKey = $"SotrudnikById_{id}";
        try
        {
            if (!_cache.TryGetValue(cacheKey, value: out Sotrudnik sotrudnik))
            {
                sotrudnik = await _mediator.Send(new GetSotrudnikByIdQuery(id));
                _cache.Set(cacheKey, sotrudnik, TimeSpan.FromMinutes(10));
            }
            return sotrudnik;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while getting sotrudnik by id.", ex);
        }
    }

}
