using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface IAuthService
    {
        Task<UserAutorization?> LoginAsync(string username, string password);
    }
}
