using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Interfaces
{
    public interface ICommentRepository
    {
        Task CreateAsync(CommentModel model);
        Task<IEnumerable<CommentModel>> GetCommentsByArticleIdSkipAsync(int Id,int size,int page=1);
    }
}
