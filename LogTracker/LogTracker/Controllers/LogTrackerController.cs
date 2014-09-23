using System.Collections.Generic;
using System.Web.Http;
using LogTracker.DataAccess;
using LogTracker.DataAccess.Domain;
using NHibernate;

namespace LogTracker.Controllers
{
    public class LogTrackerController : ApiController
    {
        private static readonly ISessionFactory Session = NHibernateSessionFactory.CreateSessionFactory("LogTracker-DB");
        private readonly LogTrackerDataAccess _logTrackerDataAccess = new LogTrackerDataAccess(Session);

        // GET api/logtracker
        public IEnumerable<string> Get()
        {
            var user = _logTrackerDataAccess.GetUser("Dliu");
            return new[] { user.LastName, user.FirstName };
        }

        // GET api/logtracker/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/logtracker
        public void Post([FromBody]string value)
        {
            var user = new User { FirstName = "Test1", LastName = "Liu", LoginName = "Dliu" };
            _logTrackerDataAccess.CreateUser(user);
        }

        // PUT api/logtracker/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/logtracker/5
        public void Delete(int id)
        {
        }
    }
}
