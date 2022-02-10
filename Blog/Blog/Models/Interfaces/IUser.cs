using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> AllUsers { get;} 
    }
}
