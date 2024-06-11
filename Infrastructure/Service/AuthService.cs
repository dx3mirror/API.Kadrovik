using Domain.Entity;
using Infrastructure.Repository.Interface;
using Infrastructure.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAutorizationUser _autorizationUser;
        private readonly ILogger<AuthService> _logger;
        private readonly IFailedLoginAttempt _failedLoginAttempt;

        public AuthService(IAutorizationUser autorizationUser, ILogger<AuthService> logger, IFailedLoginAttempt failedLoginAttempt)
        {
            _autorizationUser = autorizationUser;
            _logger = logger;
            _failedLoginAttempt = failedLoginAttempt;
        }

        public async Task<UserAutorization?> LoginAsync(string username, string password)
        {

            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    throw new ArgumentException("Username and password cannot be empty");
                }
                using var cancellationTokenSource = new CancellationTokenSource();
                UserAutorization? user = await _autorizationUser.FindUsersAsync(username, password, cancellationTokenSource.Token);
                if (user != null)
                {
                    _failedLoginAttempt.ResetFailedLoginAttempts(username);
                    return user;
                }
                else
                {
                    _failedLoginAttempt.IncrementFailedLoginAttempts(username);
                    return null;
                }
                
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error during user login: {ex.Message}");
                return null;
            }
        }
    }
}
