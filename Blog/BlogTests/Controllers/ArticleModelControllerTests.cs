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
using Microsoft.AspNetCore.Hosting;

namespace Blog.Controllers.Tests
{
    //[TestClass()]
    public class ArticleModelControllerTests
    {
        [Fact]
        public void IndexReturnsAViewResaultAlistOfArticle()
        {
            //arrange
            var mockArticle = new Mock<IArticle>();
            var mockCategory = new Mock<Icategory>();
            var mockImage = new Mock<IImageModel>();
            //IWebHostEnvironment webHostEnvironment = new Mock();

            IQueryable<ArticleModel> ArticleQueryable = ReturnTestData.ReturnTestData_ArticleModels().AsQueryable();
            mockArticle.Setup(o => o.GetAllBlogs()).Returns(ArticleQueryable);
            mockCategory.Setup(o => o.AllCategories).Returns(ReturnTestData.ReturnTestData_Categories);
          

            //var Controller = new ArticleModelController(webHostEnvironment,mockArticle.Object);

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