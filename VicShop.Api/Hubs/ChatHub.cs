using Microsoft.AspNetCore.SignalR;
using VicShop.Api.Common;
using VicShop.Api.Models.SignalR;

namespace VicShop.Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;
        public ChatHub()
        {
            _botUser = "Mychat Bot";
        }
        public async Task SendMesssageToGroup(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Group);
            await Clients.Group(userConnection.Group).SendAsync(Constants.RECEIVE_MESSAGE, _botUser, $"{userConnection.Name} has join {userConnection.Group}");
        }
    }
}
