using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogTracker.DataAccess.Domain
{
    public class Log
    {
        public virtual int Id { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual float Duration { get; set; }
        public virtual User User { get; set; }
        public virtual LogType LogType { get; set; }
    }
}
