using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Teamodoro.Persistence.Entities
{
    [BsonIgnoreExtraElements]
    public class User : MongoEntity
    {
        public string Username { get; set; }
        public string SecurityKey { get; set; }
        public string AuthenticationType { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<string> TeamIds { get; set; }
    }
}
