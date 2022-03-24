using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repository
{
    public class CategoryRepository : Icategory
    {
        private readonly AplicationDbContext _context;

        public CategoryRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> AllCategories => _context.categories;

        public async Task<Category> GetCategoryByIdAsync(int? id)
        {
            return await _context.categories.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);  
        }

        public void AddCategory(Category category)=> _context.Add(category);

        public Task SaveDataAsync() => _context.SaveChangesAsync();
    }
}
