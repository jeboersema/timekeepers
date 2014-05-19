using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Teamodoro.Persistence.Entities;
using System.Linq;

namespace Teamodoro.Persistence.Services
{
    public abstract class EntityService<T> : IEntityService<T> where T : IMongoEntity
    {
        protected readonly MongoConnectionHandler<T> MongoConnectionHandler;

        public virtual void Create(T entity)
        {
            //// Save the entity with safe mode (WriteConcern.Acknowledged)
            var result = this.MongoConnectionHandler.MongoCollection.Save(
                entity,
                new MongoInsertOptions
                {
                    WriteConcern = WriteConcern.Acknowledged
                });

            if (!result.Ok)
            {
                //// Something went wrong
            }
        }

        public virtual void Delete(string id)
        {
            var result = this.MongoConnectionHandler.MongoCollection.Remove(
                Query<T>.EQ(e => e.Id,
                new ObjectId(id)),
                RemoveFlags.None,
                WriteConcern.Acknowledged);

            if (!result.Ok)
            {
                //// Something went wrong
            }
        }

        public virtual long Count()
        {
            return MongoConnectionHandler.MongoCollection.Count();
        }

        protected EntityService()
        {
            const string connectionString = "mongodb://localhost";
            const string databaseName = "teamodoro";
            MongoConnectionHandler = new MongoConnectionHandler<T>(connectionString, databaseName);
        }

        protected EntityService(string connectionString, string databaseName)
        {
            MongoConnectionHandler = new MongoConnectionHandler<T>(connectionString, databaseName);
        }

        public virtual T GetById(string id)
        {
            var entityQuery = Query<T>.EQ(e => e.Id, new ObjectId(id));
            return this.MongoConnectionHandler.MongoCollection.FindOne(entityQuery);
        }

        public List<T> GetAll()
        {
            return MongoConnectionHandler.MongoCollection.FindAll().ToList();
        }

        public abstract void Update(T entity);
    }
}
