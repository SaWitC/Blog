using Blog.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Mocks
{
    public class MockUser : IUser
    {
        public IEnumerable<User> AllUsers
        {
            get
            {
                return new List<User>
                {
                    new User{Email="rtypink@gmail.com",UserName="rtypink@gmail.com",PasswordHash="AQAAAAEAACcQAAAAEIFfas7l34ajYW3psE/SjxEw7UJ+ZkDW45WP+lGsFBEc+zlcGSZgUGS6Xp6Sua33jA==" }
                };
            }
        }
    }
}
