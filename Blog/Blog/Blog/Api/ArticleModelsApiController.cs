using Blog.Models.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Blog.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleModelsApiController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IArticle _article;
        private readonly Icategory _category;
        private readonly IImageModel _image;
        private readonly IUser _userManager;
        public ArticleModelsApiController(IWebHostEnvironment webHostEnvironment,IArticle article,Icategory category,IImageModel imageModel,IUser user)
        {
            _hostEnvironment = webHostEnvironment;
            _article = article;
            _category = category;
            _image = imageModel;
            _userManager = user;   
        }
        //GET: api/<ArticleModelsApiController>
        [HttpGet]
        public IQueryable<indexArticleViewModel> Get()
        {
            var x = _article.GetAllBlogMinVersion();

            return _article.GetAllBlogMinVersion();
        }

        // GET api/<ArticleModelsApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var x= _article.GetBlogById(id);
            if (x != null)
            {
                return JsonSerializer.Serialize(x);
            }
            else
                return "dataNotFound";
        }

        // POST api/<ArticleModelsApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArticleModelsApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticleModelsApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
