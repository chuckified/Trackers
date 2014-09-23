using LogTracker.DataAccess;
using LogTracker.DataAccess.Domain;
using NHibernate;
using NUnit.Framework;

namespace LogTracker.Test.Unit
{
    [TestFixture]
    [Explicit]
    internal class DataAccessTest
    {
        private ISessionFactory _session;
        private LogTrackerDataAccess _sut;

        [SetUp]
        public void TestSetup()
        {
            _session = NHibernateSessionFactory.CreateSessionFactory("LogTracker-DB");
            _sut = new LogTrackerDataAccess(_session);
        }

        [Test]
        public void ShouldGenerateDataBase()
        {
            var user = new User {FirstName = "Dennis", LastName = "Liu", LoginName = "Dliu"};

            _sut.CreateUser(user);
        }

        [Test]
        public void ShouldGetUserWhenPassLoginName()
        {
            var user = _sut.GetUser("Dliu");

            Assert.That(user.LastName, Is.EqualTo("Liu"));
        }
    }
}