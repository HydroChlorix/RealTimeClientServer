using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Dev.Web.Hubs
{
    public interface INotifyClient
    {
        Task Notify(string message);
    }
    
    public interface IChatHub
    {
        Task SendMessage(string message);
    }
    public class StronglyTypedChatHub : Hub<INotifyClient>, IChatHub
    {
        public IClientRepository Repository { get; }
        public StronglyTypedChatHub(IClientRepository repository)
        {
            Repository = repository;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            Repository.Add(new Client() { ConnectionId = Context.ConnectionId });
            await Clients.All.Notify($"{Context.ConnectionId} connected.");
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            Repository.Remove(new Client() { ConnectionId = Context.ConnectionId });
            await Clients.All.Notify($"{Context.ConnectionId} disconnected.");
        }
        public Task SendMessage(string message)
        {
            return Clients.All.Notify($"{message}");
        }
    }
}
