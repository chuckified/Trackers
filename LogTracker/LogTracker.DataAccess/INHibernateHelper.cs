using System;
using NHibernate;

namespace LogTracker.DataAccess
{
    public interface INHibernateHelper
    {
        void Execute(Action<ISession> action);
        T Execute<T>(Func<ISession, T> action);
    }
}