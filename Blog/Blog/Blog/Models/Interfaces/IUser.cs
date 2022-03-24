using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> AllUsers { get;}
        Task<User> FindUserByIdAsync(string Id);
        Task<User> FindUserByNameAsync(string UserName);
        Task AddAsync(User user,string password);
        Task DeleteAsunc(User user);
        void Update(User user);
        Task SaveShangesAsync();


    }
}
