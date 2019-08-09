using System.Collections.Generic;
using System.Linq;
using SignalR.Dev.Web.DB;

namespace SignalR.Dev.Web
{
    public class ClientRepository : IClientRepository
    {
        //protected readonly IDbContext<IClient> _context;

        protected List<IClient> Clients { get; set; }
        public ClientRepository()
        {
            Clients = new List<IClient>();
        }
        //public ClientRepository(IDbContext<IClient> context)
        //{
        //    _context = context;
        //}

        public void Add(IClient entity)
        {
            Clients.Add(entity);
        }

        public void Remove(IClient entity)
        {
            Clients.Remove(entity);
        }
        public ICollection<IClient> GetAll()
        {
            return Clients.ToList();
        }

    }
}
