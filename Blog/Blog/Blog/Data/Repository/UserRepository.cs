using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Blog.Data.Repository
{
    public class UserRepository : IUser
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManger;
        public UserRepository(SignInManager<User> signInManager ,UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManger = userManager;
        }
        public IEnumerable<User> AllUsers => _userManger.Users;

        public async Task AddAsync(User user,string password)
        {
           await _userManger.CreateAsync(user,password);
        }

        public Task DeleteAsunc(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindUserByIdAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindUserByNameAsync(string UserName)
        {
            return await _userManger.FindByNameAsync(UserName);
        }

        public Task SaveShangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
