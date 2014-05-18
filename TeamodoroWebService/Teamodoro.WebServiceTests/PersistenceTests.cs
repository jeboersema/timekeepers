using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Teamodoro.Persistence.Entities;
using Teamodoro.Persistence.Services;

namespace Teamodoro.WebServiceTests
{
    public class PersistenceTests
    {
        private UserService userDbService;
        private const string connectionString = "mongodb://localhost";
        private const string database = "testDb";

        [SetUp]
        public void UserTestPreparation()
        {
            userDbService = new UserService(connectionString,database);
        }

        [Test]
        public void CanCreateUser()
        {
            userDbService.Create();
        }

        
    }
}
