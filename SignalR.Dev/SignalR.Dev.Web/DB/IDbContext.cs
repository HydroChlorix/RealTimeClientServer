using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Dev.Web.DB
{
    public interface IDbContext { }
    public interface IDbContext<T> : IDbContext { }

}
