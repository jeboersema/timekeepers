using Teamodoro.Persistence.Entities;

namespace Teamodoro.Persistence.Services
{
    public interface IEntityService<T> where T : IMongoEntity
    {
        void Create(T entity);

        void Delete(string id);

        T GetById(string id);

        void Update(T entity);
    }
}
