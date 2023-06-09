using Microsoft.AspNetCore.SignalR;

namespace NewChatApp.Hubs
{
    public class UserHub : Hub
    {
        public static int TotalViews { get; set; } = 0;
        public static int TotalUser { get; set; } = 0;

        public override Task OnConnectedAsync()
        {
            TotalUser++;
            Clients.All.SendAsync("updateTotalUser", TotalUser).GetAwaiter().GetResult();

            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            TotalUser--;
            Clients.All.SendAsync("updateTotalUser", TotalUser).GetAwaiter().GetResult();

            return base.OnDisconnectedAsync(exception);
        }

        public async Task NewWindowLoaded()
        {
            TotalViews++;
            //send update 
            await Clients.All.SendAsync("updateTotalViews",TotalViews);
        }
    }
}
