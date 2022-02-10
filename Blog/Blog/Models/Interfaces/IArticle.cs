using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Interfaces
{
    public interface IArticle
    {
        public IEnumerable<ArticleModel> GetAllBlogs { get; }

        ArticleModel GetBlogById(int? id);
    }
}
