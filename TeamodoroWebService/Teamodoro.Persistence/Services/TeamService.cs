using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Teamodoro.Persistence.Entities;

namespace Teamodoro.Persistence.Services
{
    public class TeamService : EntityService<Team>
    {
        public TeamService(string connectionString, string databaseName)
            : base(connectionString, databaseName)
        {
        }

        public override void Update(Team entity)
        {
            var updateResult = MongoConnectionHandler.MongoCollection.Update(
                Query<Team>.EQ(t => t.Id, entity.Id),
                Update<Team>.Set(t => t.Company, entity.Company)
                    .Set(t => t.IsPublic, entity.IsPublic)
                    .Set(t => t.LongBreakLength, entity.LongBreakLength)
                    .Set(t => t.Name, entity.Name)
                    .Set(t => t.PomodoroLength, entity.PomodoroLength)
                    .Set(t => t.PomodorosBetweenLongBreaks, entity.PomodorosBetweenLongBreaks)
                    .Set(t => t.ShortBreakLength, entity.ShortBreakLength)
                    .Set(t => t.TeamOwnerId, entity.TeamOwnerId),
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
