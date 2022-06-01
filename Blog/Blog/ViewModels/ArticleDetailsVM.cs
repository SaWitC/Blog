using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.ViewModels
{
    public class ArticleDetailsVM
    {
        public ArticleModel Article { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }
    }
}
