namespace SignalR.Dev.Web
{
    public interface IClient
    {
        string ConnectionId { get; set; }
    }
    public class Client : IClient
    {
        public string ConnectionId { get; set; }
    }
}