using System.Collections;
using System.Collections.Generic;

namespace LogTracker.DataAccess.Domain
{
    public class User
    {
        private IList<Log> _logs;

        public virtual int Id { get; set; }
        public virtual string LoginName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public User()
        {
            _logs = new List<Log>();
        }
        public virtual IList<Log> Logs
        {
            get { return _logs; }
        }

        public virtual void AddLog(Log log)
        {
            log.User = this;
            Logs.Add(log);
        }
    }
}
