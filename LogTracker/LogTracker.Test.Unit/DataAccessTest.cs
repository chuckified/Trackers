using LogTracker.DataAccess;
using LogTracker.DataAccess.Domain;
using NUnit.Framework;

namespace LogTracker.Test.Unit
{
    [TestFixture]
    class DataAccessTest
    {
        [Test]
        [Explicit]
        public void ShouldGenerateDataBase()
        {
            var session = NHibernateSessionFactory.CreateSessionFactory("LogTracker-DB");
            var sut = new LogTrackerDataAccess(session);

            var user = new User {FirstName = "Dennis", LastName = "Liu", LoginName = "Dliu"};

            sut.CreateUser(user);
        }
    }
}
