using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repository
{
    public class CommentRepository:ICommentRepository
    {
        private readonly AplicationDbContext _context;

        public CommentRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(CommentModel model)
        {
            await _context.Comments.AddAsync(model);
        }
        public async Task<IEnumerable<CommentModel>> GetCommentsByArticleIdSkipAsync(int Id, int size, int page = 1)
        {
            return await _context.Comments.Where(o => o.ArticleId == Id).Skip(size*page).Take(size).AsNoTracking().ToListAsync();
        }
    }
}
