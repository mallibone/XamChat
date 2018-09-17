using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamChat.Models;

namespace XamChat.Services
{
    public interface IUserService
    {
        Task<bool> Authenticate(string username, string password);
        User GetCurrentUser();
        bool IsAuthenticated { get; }
    }

    class DummyUserService : IUserService
    {
        private User _user;
        private bool _isAuthenticated;

        public Task<bool> Authenticate(string username, string password)
        {
            _user = new User {Username = username};
            _isAuthenticated = true;
            return Task.FromResult(true);
        }

        public User GetCurrentUser()
        {
            return _user;
        }

        public bool IsAuthenticated => _isAuthenticated;
    }
}
