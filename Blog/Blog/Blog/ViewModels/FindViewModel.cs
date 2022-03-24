using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class FindViewModel
    {

        public int? SelectedCategory { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FirstDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime SecondDate { get; set; }

        [StringLength(100,ErrorMessage ="Поисковой запрос может содержать максимум 100 символов")]
        public string SearshString { get; set; }
       
        [StringLength(100,ErrorMessage ="Поисковой запрос может содержать максимум 100 символов")]
        public string TagsString { get; set; }
        public List<indexArticleViewModel> ArticleModels { get; set; }



    }
}
