using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Interfaces
{
    public interface IArticle
    {
        IQueryable<ArticleModel> GetAllBlogs();
        ArticleModel GetBlogById(int? id);
        Task<ArticleModel> GetBlogByIdAsync(int? id);

        IQueryable<ArticleModel> GetArticleByAvtor(string UserName);

        Task AddNewArticle(ArticleModel model);

        void UpdateModel(ArticleModel model);

        Task SaveDataAsync();

        void Remove(ArticleModel model);
    }
}
