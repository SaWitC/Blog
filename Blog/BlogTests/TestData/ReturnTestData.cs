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
    }
}
