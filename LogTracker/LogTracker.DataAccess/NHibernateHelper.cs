using System;
using NHibernate;

namespace LogTracker.DataAccess
{
    public class NHibernateHelper : INHibernateHelper
    {
        private readonly ISessionFactory _sessionFactory;

        public NHibernateHelper(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void Execute(Action<ISession> action)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    action(session);
                    transaction.Commit();
                }
            }
        }

        public T Execute<T>(Func<ISession, T> action)
        {
            T result;

            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = action(session);
                    transaction.Commit();
                }
            }

            return result;
        }
    }
}