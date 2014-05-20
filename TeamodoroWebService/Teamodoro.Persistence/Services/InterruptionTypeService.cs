using System;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Teamodoro.Persistence.Entities;

namespace Teamodoro.Persistence.Services
{
    public class InterruptionTypeService : EntityService<InterruptionType>
    {
        public InterruptionTypeService(string connectionString, string databaseName)
            : base(connectionString, databaseName)
        {
        }

        public override void Update(InterruptionType entity)
        {
            var updateResult = MongoConnectionHandler.MongoCollection.Update(
                Query<InterruptionType>.EQ(i => i.Id, entity.Id),
                Update<InterruptionType>.Set(i => i.Category, entity.Category)
                    .Set(i => i.Name, entity.Name)
                    .Set(i => i.TeamId, entity.TeamId),
                    new MongoUpdateOptions
                    {
                        WriteConcern = WriteConcern.Acknowledged
                    });
            if (updateResult.DocumentsAffected == 0)
            {
                //oops
                throw new Exception(string.Format("Unable to update {0} due to the following problem: {1}", GetType().Name, updateResult.ErrorMessage));
            }
        }
    }
}
