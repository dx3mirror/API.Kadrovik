﻿using Infrastructure.Repository.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repository
{
    public class FailedLoginAttempt : IFailedLoginAttempt
    {
        private readonly IMemoryCache _memoryCache;
        public FailedLoginAttempt(IMemoryCache memoryCache)
        {
           _memoryCache = memoryCache;
        }
        public int GetFailedLoginAttempts(string username)
        {
            if (_memoryCache.TryGetValue(username, out int attempts))
            {
                return attempts;
            }

            return 0;
        }

        public void IncrementFailedLoginAttempts(string username)
        {
            int attempts = GetFailedLoginAttempts(username) + 1;
            _memoryCache.Set(username, attempts, TimeSpan.FromMinutes(30));
        }

        public void ResetFailedLoginAttempts(string username)
        {
            _memoryCache.Remove(username);
        }

        public bool IsAccountLocked(string username)
        {
            return GetFailedLoginAttempts(username) >= 3;
        }
    }
}
