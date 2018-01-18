namespace VoiceSystem.Data.Common
{
    using System.Linq;

    using VoiceSystem.Data.Common.Models;

    public interface IDbRepository<T>
        where T : class, IDeletableEntity, IAuditInfo
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();

        void Dispose();
    }
}
