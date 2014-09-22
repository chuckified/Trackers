using FluentNHibernate.Mapping;
using LogTracker.DataAccess.Domain;

namespace LogTracker.DataAccess.Mappings
{
    internal class LogTypeMap : ClassMap<LogType>
    {
        public LogTypeMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.Logs)
                .Not.LazyLoad()
                .Cascade.All();
        }
    }
}
