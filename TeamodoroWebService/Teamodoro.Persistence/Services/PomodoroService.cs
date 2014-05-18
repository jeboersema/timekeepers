using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            }
        }
    }
}
