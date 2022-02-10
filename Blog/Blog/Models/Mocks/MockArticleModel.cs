using Blog.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Mocks
{
    public class MockArticleModel : IArticle
    {
        private readonly Icategory _category = new MockCategory();
        private readonly IUser _user = new MockUser();

        public IEnumerable<ArticleModel> GetAllBlogs
        {
            get
            {
                return new List<ArticleModel>
                {
                    new ArticleModel{Title="text",
                    ShortDesk ="Текст (от лат. textus — ткань; сплетение, сочетание) — зафиксированная на каком-либо материальном носителе человеческая мысль; в общем плане связная и полная последовательность символов.",
                    Description="Текст (от лат. textus — ткань; сплетение, сочетание) — зафиксированная на каком-либо материальном носителе человеческая мысль; в общем плане связная и полная последовательность символов."+
                    "Существуют две основные трактовки понятия «текст»: имманентная (расширенная, философски нагруженная) и репрезентативная (более частная). Имманентный подход подразумевает "+
                    "отношение к тексту как к автономной реальности, нацеленность на выявление его внутренней структуры. Репрезентативный — рассмотрение текста как особой"+
                    "формы представления информации о внешней тексту действительности.",
                    Category =_category.AllCategories.First(),
                    Tags="text,new,test",
                    ReleseDate =DateTime.Now,
                    BlogName ="Техт",
                    AvtorName = _user.AllUsers.First().UserName,
                    Avtor = _user.AllUsers.First(),
                    },
                };
            }
        }

        public ArticleModel GetBlogById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
