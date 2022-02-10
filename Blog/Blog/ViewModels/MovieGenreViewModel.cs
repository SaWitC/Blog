using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.ViewModels
{
    public class MovieGenreViewModel
    {
        public List<ArticleModel> Movies { get; set; }
        public SelectList Selects { get; set; }
        public string SelectedCategory { get; set; }
        public string SearchString { get; set; }
        public string Tags { get; set; }

    }
}
