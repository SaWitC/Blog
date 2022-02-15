using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Interfaces
{
    public interface Icategory
    {
        public IEnumerable<Category> AllCategories { get;}

        public Task<Category> GetCategoryByIdAsync(int? id);

        public void AddCategory(Category category);

        public Task SaveDataAsync();
    }
}
