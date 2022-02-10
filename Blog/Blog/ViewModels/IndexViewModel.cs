using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ArticleModel> ArticleModels { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
