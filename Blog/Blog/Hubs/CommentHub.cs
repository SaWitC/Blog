using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Blog.Hubs
{
    public class CommentHub:Hub
    {
        public async Task SendComment(string Message, int itemId)
        {
            await Clients.All.SendAsync(itemId.ToString(), Message);
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
