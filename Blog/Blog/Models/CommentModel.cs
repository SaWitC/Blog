using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Required")]
        //[MaxLength(500,ErrorMessage = "CommentMessageMaxLen500"),MinLength(20,ErrorMessage = "CommentMessageMinLenght20")]
        public string Message { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("ArticleId")]
        public ArticleModel Article { get; set; }
        public int ArticleId { get; set; }
    }
}
