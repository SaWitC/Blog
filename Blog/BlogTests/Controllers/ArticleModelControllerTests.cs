//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blog.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blog.Models.Interfaces;
using Blog.Models;
using AutoFixture;
using BlogTests.TestData;
using System.Linq;


namespace Blog.Controllers.Tests
{
    //[TestClass()]
    public class ArticleModelControllerTests
    {
        [Fact]
        public void IndexReturnsAViewResaultAlistOfArticle()
        {
            //arrange
            var mock = new Mock<IArticle>();
            IQueryable<ArticleModel> ArticleQueryable = ReturnTestData.ReturnTestData_ArticleModels().AsQueryable();
            mock.Setup(o => o.GetAllBlogs()).Returns(ArticleQueryable);
            //var Controller = new ArticleModelController(mock.Object);

            //act

            //arssert

            //Assert
        }

        //[Fact]
        //public void DetailsTest()
        //{
        //    Assert
        //}
    }
}