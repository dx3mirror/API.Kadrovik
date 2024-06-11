using AutoMapper;
using Domain.Entity;
using Infrastructure.DatabaseConnection;
using Infrastructure.Entity;
using Infrastructure.Repository.Interface;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class AutorizationUsers : IAutorizationUser
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;
        Connect connect = new Connect();
        public AutorizationUsers(IMapper mapper, ILogger<AuthService> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<UserAutorization?> FindUsersAsync(string username, string password, CancellationToken cancellationToken)
        {
            if (connect.context == null)
            {
                throw new InvalidOperationException("Database context is not available.");
            }

            UsersSite? userSite = await connect.context.UsersSites.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == username && u.Password == password, cancellationToken);

            if (userSite != null)
            {
                _logger.LogInformation($"User '{username}' logged in successfully.");
                return _mapper.Map<UserAutorization>(userSite);
            }
            else
            {
                _logger.LogWarning($"Failed login attempt for user '{username}'.");
                return null;
            }
        }
    }
}
