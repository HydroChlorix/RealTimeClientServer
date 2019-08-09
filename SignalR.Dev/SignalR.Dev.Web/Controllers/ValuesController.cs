using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Dev.Web.Hubs;

namespace SignalR.Dev.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {      
        private readonly IClientRepository _repository;
        public ValuesController(IClientRepository repository)
        {
            _repository = repository;
        }

        //private readonly IHubContext<NotificationHub> _hubContext;
        //public ValuesController(IHubContext<NotificationHub> hubContext, IClientRepository repository)
        //{
        //    _hubContext = hubContext;
        //    _repository = repository;
        //}

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //_hubContext.Clients.All.SendAsync("Notify", $"Home page loaded at: {DateTime.Now}");

            //return new string[] { DateTime.Now.ToString() };

            return _repository.GetAll()
                                .Select(x => x.ConnectionId)
                                .Concat(new string[] { DateTime.Now.ToString() })
                                .ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
