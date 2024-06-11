using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interface
{
    public interface IFailedLoginAttempt
    {
        int GetFailedLoginAttempts(string username);
        void IncrementFailedLoginAttempts(string username);
        void ResetFailedLoginAttempts(string username);
        bool IsAccountLocked(string username);
    }
}
