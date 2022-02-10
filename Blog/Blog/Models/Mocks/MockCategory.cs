using Blog.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Mocks
{
    public class MockCategory : Icategory
    {
        public IEnumerable<Category> AllCategories {
            get
            {
                return new List<Category>
                {
                    new Category{Title="Искуство",Description= "Описание искуства или обзор"},
                    new Category{Title="Спорт",Description= "Описание спорта или новости спорта"},
                    new Category{Title="наука",Description= "Описание чего-то из сферы науки или обзор"}
                };
            }
            
        }
    }
}
