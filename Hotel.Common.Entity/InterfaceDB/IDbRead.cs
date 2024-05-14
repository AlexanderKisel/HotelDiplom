using Hotel.Common.Entity.EntityInterface;

namespace Hotel.Common.Entity.InterfaceDB
{
    /// <summary>
    /// Интерфейс получения
    /// </summary>
    public interface IDbRead
    {
        /// <summary>
        /// Предоставляет функциональные возможности для выполнения запросов
        /// </summary>
        IQueryable<TEntity> Read<TEntity>() where TEntity : class, IEntity;
    }
}
