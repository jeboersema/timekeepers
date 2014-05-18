using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Teamodoro.Persistence.Entities;

namespace Teamodoro.Persistence.Services
{
    public class UserService : EntityService<User>
    {
        public UserService(string connectionString, string databaseName)
            : base(connectionString, databaseName)
        {
        }

        public override void Update(User entity)
        {
            var updateResult = MongoConnectionHandler.MongoCollection.Update(
                Query<User>.EQ(u => u.Id, entity.Id),
                Update<User>.Set(u => u.AuthenticationType, entity.AuthenticationType)
                    .Set(u => u.Email, entity.Email)
                    .Set(u => u.FullName, entity.FullName)
                    .Set(u => u.SecurityKey, entity.SecurityKey)
                    .Set(u => u.TeamIds, entity.TeamIds)
                    .Set(u => u.Username, entity.Username),
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
