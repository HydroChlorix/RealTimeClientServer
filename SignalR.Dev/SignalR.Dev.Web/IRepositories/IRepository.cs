using SignalR.Dev.Web.DB;
using SignalR.Dev.Web.Hubs;
using System.Collections.Generic;

namespace SignalR.Dev.Web
{
    public interface IRepository<T> 
    {
        void Add(T entity);
        //void Update(T entity);
        void Remove(T entity);
        ICollection<T> GetAll();
    }
    public interface IClientRepository : IRepository<IClient> { }
  
}
