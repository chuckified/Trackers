using FluentNHibernate.Mapping;
using LogTracker.DataAccess.Domain;

namespace LogTracker.DataAccess.Mappings
{
    internal class LogMap : ClassMap<Log>
    {
        public LogMap()
        {
            Id(x => x.Id);
            Map(x => x.Duration);
            Map(x => x.StartTime);
            Map(x => x.EndTime);
            References(x => x.User)
                .Not.LazyLoad()
                .Cascade.None();
            References(x => x.LogType)
                .Not.LazyLoad()
                .Cascade.None();
        }
    }
}
