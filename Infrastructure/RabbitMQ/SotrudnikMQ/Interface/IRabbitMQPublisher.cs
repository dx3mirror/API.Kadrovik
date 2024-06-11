using Infrastructure.Entity;

public interface IRabbitMQPublisher
    {
        Task PublishAddSotrudnikAsync(Sotrudnik sotrudnik);
        Task PublishUpdateSotrudnikAsync(Sotrudnik sotrudnik);
        Task PublishDeleteSotrudnikAsync(int id);
    }

