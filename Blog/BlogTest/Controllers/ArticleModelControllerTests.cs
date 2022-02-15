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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Blog.ViewModels;

namespace Blog.Controllers.Tests
{
    //[TestClass()]
    public class ArticleModelControllerTests
    {
        [Fact]
        public async Task IndexReturnsAViewResultAlistOfArticle()
        {
            //arrange
            var mockUser = new Mock<IUser>();
            var mockArticle = new Mock<IArticle>();
            var mockCategory = new Mock<Icategory>();
            var mockImage = new Mock<IImageModel>();
            var webHostEnvironment = new Mock<IWebHostEnvironment>();

            mockArticle.Setup(o => o.GetAllBlogs()).Returns(ReturnTestData.ReturnTestData_ArticleModels);
            mockCategory.Setup(o => o.AllCategories).Returns(ReturnTestData.ReturnTestData_Categories);

            var x = new ViewModels.PageViewModel(1,1,10);
            var indexViewModel = new ViewModels.IndexViewModel {ArticleModels=ReturnTestData.ReturnTestData_ArticleModels(),PageViewModel= x };

            var Controller = new ArticleModelController(mockUser.Object,webHostEnvironment.Object,mockArticle.Object,mockCategory.Object,mockImage.Object);

            //act

            var result=Controller.Index(1);

            //arssert

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
            //var model = Assert.IsAssignableFrom<PageViewModel>(viewResult.ViewData.Model);
            //var model = viewResult.Result;
           // Assert.Equal(indexViewModel.ArticleModels.Count().ToString(), model.ToString());
            //Assert.Equal(1, 1);
        }
        [Fact]
        public void SmallWidthReturnsAViewResult()
        {
            //arrange
            var mockUser = new Mock<IUser>();
            var mockArticle = new Mock<IArticle>();
            var mockCategory = new Mock<Icategory>();
            var mockImage = new Mock<IImageModel>();
            var webHostEnvironment = new Mock<IWebHostEnvironment>();

            mockArticle.Setup(o => o.GetAllBlogs()).Returns(ReturnTestData.ReturnTestData_ArticleModels);
            mockCategory.Setup(o => o.AllCategories).Returns(ReturnTestData.ReturnTestData_Categories);

            var Controller = new ArticleModelController(mockUser.Object, webHostEnvironment.Object, mockArticle.Object, mockCategory.Object, mockImage.Object);

            //act

            var result = Controller.SmallWidth();

            //arssert

            var viewResult = Assert.IsType<ViewResult>(result);

        }

        //[Fact]
        //public void DetailsTest()
        //{
        //    Assert
        //}
    }
}