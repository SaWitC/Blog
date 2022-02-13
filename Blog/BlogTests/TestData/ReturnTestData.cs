using AutoFixture;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogTests.TestData
{
    public static class  ReturnTestData
    {
        public static List<ArticleModel> ReturnTestData_ArticleModels()
        {
            return new List<ArticleModel>
            {
                new Fixture().Create<ArticleModel>(),
                new Fixture().Create<ArticleModel>(),
                new Fixture().Create<ArticleModel>(),
            };
        }
    }
}
