using AutoFixture;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogTests.TestData
{
    public static class  ReturnTestData
    {
        public static IQueryable<indexArticleViewModel> ReturnTestData_ArticleModels()
        {
            return new List<indexArticleViewModel>
            {
                new Fixture().Create<indexArticleViewModel>(),
                new Fixture().Create<indexArticleViewModel>(),
                new Fixture().Create<indexArticleViewModel>(),
            }.AsQueryable();
        }

        public static List<Category> ReturnTestData_Categories()
        {
            return new List<Category>
            {
                new Fixture().Create<Category>(),
                new Fixture().Create<Category>(),
                new Fixture().Create<Category>(),
            };
        }

        public static List<ImageModel> ReturnTestData_Images()
        {
            return new List<ImageModel>
            {
                new Fixture().Create<ImageModel>(),
                new Fixture().Create<ImageModel>(),
                new Fixture().Create<ImageModel>(),
            };
        }

        public static Mock<UserManager<User>> MockUserManager<User>(List<User> ls) where User : class
        {
            var store = new Mock<IUserStore<User>>();
            var mgr = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<User>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<User>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<User, string>((x, y) => ls.Add(x));
            mgr.Setup(x => x.UpdateAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);

            return mgr;
        }

        //private List<User> _users = new List<User>
        //{
        //    new User("User1", "user1@bv.com") { Id = 1 },
        //    new User("User2", "user2@bv.com") { Id = 2 }
        //};
    }
}
