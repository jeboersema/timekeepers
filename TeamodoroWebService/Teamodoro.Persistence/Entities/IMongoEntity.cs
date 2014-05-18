using MongoDB.Bson;

namespace Teamodoro.Persistence.Entities
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
