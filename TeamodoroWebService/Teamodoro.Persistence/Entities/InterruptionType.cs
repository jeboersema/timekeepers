using MongoDB.Bson;

namespace Teamodoro.Persistence.Entities
{
    public class InterruptionType : MongoEntity
    {
        public string TeamId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
