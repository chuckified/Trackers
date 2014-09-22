using FluentNHibernate.Mapping;
using LogTracker.DataAccess.Domain;

namespace LogTracker.DataAccess.Mappings
{
    internal class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.LoginName);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            HasMany(x => x.Logs)
                .Not.LazyLoad()
                .Inverse()
                .Cascade.All();
        }
    }
}
