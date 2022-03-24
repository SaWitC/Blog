using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Blog.ViewModels;

namespace Blog.Data.Repository
{
    public class ArticleRepository : IArticle
    {
        private readonly AplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ArticleRepository(AplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task AddNewArticle(ArticleModel model)
        {
            _context.Blogs.Add(model);
            await _context.SaveChangesAsync();
        }

        public IQueryable<ArticleModel> GetAllBlogs()///
        {
            return _context.Blogs.AsNoTracking().Include(o => o.HelloImage);
        }
        public IQueryable<ArticleModel> GetArticleByAvtor(string UserName)///
        {
            return _context.Blogs.Include(o => o.HelloImage).AsNoTracking().Where(o => o.Avtor.UserName == UserName);
        }
        public ArticleModel GetBlogById(int? id)
        {
            return _context.Blogs.Include(o => o.HelloImage).AsNoTracking().FirstOrDefault(o=>o.Id==id);
        }

        public async Task<ArticleModel> GetBlogByIdAsync(int? id)
        {
            return await _context.Blogs.Include(o => o.HelloImage).AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task SaveDataAsync()=> await _context.SaveChangesAsync();

        public void UpdateModel(ArticleModel model)=> _context.Update(model);

        public void Remove(ArticleModel model)=> _context.Remove(model);

        public IQueryable<indexArticleViewModel> GetAllBlogMinVersion()
        {
          var x=
             _context.Blogs.Include(o => o.HelloImage).AsNoTracking().Select(x => new { x.Id, x.HelloImage, x.Avtor, x.ShortDesk, x.ReleseDate, x.Title, x.Tags, x.ImageURL, x.IsFavorit, x.Category, x.CategoryId, x.AvtorName,x.BlogName }).ToList();
            IQueryable<indexArticleViewModel> articlesList = _context.Blogs.Include(o => o.HelloImage).AsNoTracking().Select(x => new indexArticleViewModel { Id = x.Id, CategoryId =x.CategoryId, HelloImage = x.HelloImage, Avtor = x.Avtor, ShortDesk = x.ShortDesk, ReleseDate = x.ReleseDate, Title = x.Title, Tags = x.Tags, ImageURL = x.ImageURL, IsFavorit = x.IsFavorit, Category = x.Category, AvtorName = x.AvtorName,BlogName= x.BlogName });

            return articlesList;
        }

        public IQueryable<indexArticleViewModel> GetBlogByAvtorMinVersion(string UserName)
        {
            var x =
          _context.Blogs.Include(o => o.HelloImage).AsNoTracking().Select(x => new {x.Id, x.HelloImage, x.Avtor, x.ShortDesk, x.ReleseDate, x.Title, x.Tags, x.ImageURL, x.IsFavorit, x.Category, x.CategoryId, x.AvtorName, x.BlogName }).ToList();
            IQueryable<indexArticleViewModel> articlesList = _context.Blogs.Include(o => o.HelloImage).AsNoTracking().Select(x => new indexArticleViewModel { CategoryId = x.CategoryId ,Id = x.Id, HelloImage = x.HelloImage, Avtor = x.Avtor, ShortDesk = x.ShortDesk, ReleseDate = x.ReleseDate, Title = x.Title, Tags = x.Tags, ImageURL = x.ImageURL, IsFavorit = x.IsFavorit, Category = x.Category, AvtorName = x.AvtorName, BlogName = x.BlogName }).Where(x => x.AvtorName == UserName);

            return articlesList;
        }
    }
}
