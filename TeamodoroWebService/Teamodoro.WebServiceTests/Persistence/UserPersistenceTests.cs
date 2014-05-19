using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Teamodoro.Persistence.Entities;
using Teamodoro.Persistence.Services;

namespace Teamodoro.WebServiceTests.Persistence
{
    [TestFixture]
    public class UserPersistenceTests
    {
        private UserService userDbService;
        private const string connectionString = "mongodb://localhost";
        private const string database = "testDb";

        [SetUp]
        public void UserTestPreparation()
        {
            userDbService = new UserService(connectionString,database);
            Cleanup();
        }

        [Test]
        public void CanCreateUser()
        {
            var preCount = userDbService.Count();
            var testUser = new User()
                {
                    Email = "Bob@gmail.com",
                    FullName = "Bob Smith",
                    Username = "BobS"
                };
            userDbService.Create(testUser);
            Assert.AreEqual(userDbService.Count(),preCount + 1);
        }

        [Test]
        public void CanGetUserById()
        {
            var testUser = new User()
                {
                    Email = "findMe@where.com",
                    FullName = "Frank Nodoby",
                    Username = "Frank"
                };
            userDbService.Create(testUser);
            var id = testUser.GetIdAsString();
            var retrievedUser = userDbService.GetById(id);
            Assert.AreEqual(retrievedUser.Email,testUser.Email);
            Assert.AreEqual(retrievedUser.FullName, testUser.FullName);
            Assert.AreEqual(retrievedUser.Username, testUser.Username);
        }

        public void Cleanup()
        {
            var allUsers = userDbService.GetAll();
            foreach (var removeUser in allUsers)
            {
                userDbService.Delete(removeUser.GetIdAsString());
            }
        }
    }
}
