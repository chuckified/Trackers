using System.Collections;
using System.Collections.Generic;

namespace LogTracker.DataAccess.Domain
{
    public class LogType
    {
        private IList<Log> _logs;

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Log> Logs { get; set; }

        public LogType()
        {
            _logs = new List<Log>();
        }
    }
}
