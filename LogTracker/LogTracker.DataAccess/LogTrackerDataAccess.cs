using System.Linq;
using LogTracker.DataAccess.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace LogTracker.DataAccess
{
    public class LogTrackerDataAccess
    {
        private readonly NHibernateHelper _helper;

        public LogTrackerDataAccess(ISessionFactory sessionFactory)
        {
            _helper = new NHibernateHelper(sessionFactory);
        }

        public int CreateUser(User user)
        {
            return _helper.Execute(
                session =>
                {
                    session.Save(user);
                    return user.Id;
                });
        }

        public User GetUser(string loginName)
        {
            return _helper.Execute(
                session =>
                    session.CreateCriteria<User>()
                        .Add(Restrictions.Eq("LoginName", loginName))
                        .List<User>()
                        .FirstOrDefault()
                );
        }
    }
}
