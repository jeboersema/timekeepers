using MongoDB.Driver;
using Teamodoro.Persistence.Entities;

namespace Teamodoro.Persistence
{
    public class MongoConnectionHandler<T> where T : IMongoEntity
    {
        public MongoCollection<T> MongoCollection { get; private set; }

        public MongoConnectionHandler(string connectionString, string databaseName)
        {
            //// Get a thread-safe client object by using a connection string
            var mongoClient = new MongoClient(connectionString);

            //// Get a reference to a server object from the Mongo client object
            var mongoServer = mongoClient.GetServer();

            //// Get a reference to the database object 
            //// from the Mongo server object
            var db = mongoServer.GetDatabase(databaseName);

            //// Get a reference to the collection object from the Mongo database object
            //// The collection name is the type converted to lowercase + "s"
            MongoCollection = db.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }
    }
}
