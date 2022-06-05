using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Blog.Data.Repository
{
    public class ArticleRepository : IArticle
    {
        private readonly ILogger<ArticleRepository> _logger;
        private readonly AplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ArticleRepository(AplicationDbContext context, UserManager<User> userManager,ILogger<ArticleRepository> logger)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task AddNewArticle(ArticleModel model)
        {
            _context.Blogs.Add(model);
            await _context.SaveChangesAsync();
        }

        public IQueryable<ArticleModel> GetAllBlogs()
        {
            _logger.LogInformation("Trying get all articles");
            var result =_context.Blogs.Include(o => o.HelloImage);
            if (result==null)
            {
                _logger.LogWarning("request return zero elements");
            }
            return result;
        }
        public IQueryable<ArticleModel> GetArticleByAvtor(string UserName)
        {
            return _context.Blogs.Include(o => o.HelloImage).Where(o => o.Avtor.UserName == UserName);
        }
        public ArticleModel GetBlogById(int? id)
        {
            return _context.Blogs.Include(o => o.HelloImage).FirstOrDefault(o=>o.Id==id);
        }

        public async Task<ArticleModel> GetBlogByIdAsync(int? id)
        {
            return await _context.Blogs.Include(o => o.HelloImage).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task SaveDataAsync()=> await _context.SaveChangesAsync();

        public void UpdateModel(ArticleModel model)=> _context.Update(model);

        public void Remove(ArticleModel model)=> _context.Remove(model);

    }
}
