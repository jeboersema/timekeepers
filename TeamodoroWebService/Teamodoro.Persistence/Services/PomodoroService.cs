using System;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Teamodoro.Persistence.Entities;

namespace Teamodoro.Persistence.Services
{
    public class PomodoroService : EntityService<Pomodoro>
    {
        public PomodoroService(string connectionString, string databaseName)
            : base(connectionString, databaseName)
        {
        }

        public override void Update(Pomodoro entity)
        {
            var updateResult = MongoConnectionHandler.MongoCollection.Update(
                Query<Pomodoro>.EQ(p => p.Id, entity.Id),
                Update<Pomodoro>.Set(p => p.Description, entity.Description)
                    .Set(p => p.Interruptions, entity.Interruptions)
                    .Set(p => p.Started, entity.Started)
                    .Set(p => p.TeamId, entity.TeamId)
                    .Set(p => p.UserId, entity.UserId),
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
