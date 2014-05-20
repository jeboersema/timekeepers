using System;
using System.Collections.Generic;
using MongoDB.Bson;
using NUnit.Framework;
using Teamodoro.Persistence.Entities;
using Teamodoro.Persistence.Services;

namespace Teamodoro.WebServiceTests
{
    public class PersistenceTests
    {
        private UserService _userDbService;
        private const string ConnectionString = "mongodb://localhost";
        private const string Database = "testDb";

        [SetUp]
        public void UserTestPreparation()
        {
            _userDbService = new UserService(ConnectionString, Database);
        }

        [Test]
        public void CanCreateUser()
        {
            var user = new User
            {
                AuthenticationType = "basic",
                Email = "me@you.com",
                FullName = "Me You",
                Id = new ObjectId(Guid.NewGuid().ToString()),
                SecurityKey = "MyPassword",
                TeamIds = new List<ObjectId>(),
                Username = "Me"
            };
            
            _userDbService.Create(user);
            
        }

        
    }
}
