using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Teamodoro.Persistence.Entities
{
    public class MongoEntity : IMongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string GetIdAsString()
        {
            return Id.ToString();
        }
    }
}
