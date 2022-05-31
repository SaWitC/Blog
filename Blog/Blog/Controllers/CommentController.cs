using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Repository;
using Blog.Hubs;
using Blog.Models;
using Blog.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Blog.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _comment;
        private readonly ArticleRepository _item;
        private readonly UserManager<User> _userManager;
        private readonly IHubContext<CommentHub> _hubContext;
        public CommentController(ICommentRepository comment, UserManager<User> userManager, ArticleRepository item, IHubContext<CommentHub> hub)
        {
            _item = item;
            _comment = comment;
            _userManager = userManager;
            _hubContext = hub;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateComent(string message, int itemId)
        {
            if (message != null && itemId > 0)
            {
                if (message.Length >= 20 && message.Length <= 500)
                {
                    CommentModel commentModel = new CommentModel
                    {
                        ArticleId = itemId,
                        Message = message,
                        UserName = User.Identity.Name
                    };
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    commentModel.UserId = user.Id;

                    await _hubContext.Clients.All.SendAsync("comment" + itemId.ToString(), message);
                    return Ok();
                }
                else return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

