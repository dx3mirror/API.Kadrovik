using Domain.Entity;


namespace Infrastructure.Repository.Interface
{
    public interface IAutorizationUser
    {
        Task<UserAutorization?> FindUsersAsync(string username, string password, CancellationToken cancellationToken);
    }
}
