using Hotel.Common.Entity.EntityInterface;
using Hotel.Common.Entity.InterfaceDB;
using Hotel.Repositories.Contracts.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Hotel.Repositories
{
    public abstract class BaseWriteRepository<T>: IRepositoryWrite<T> where T : class, IEntity
    {
        /// <inheritdoc cref="IDbWriterContext"/>
        private readonly IDbWriteContext writerContext;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="BaseWriteRepository{T}"/>
    /// </summary>
    protected BaseWriteRepository(IDbWriteContext writerContext)
    {
        this.writerContext = writerContext;
    }

    /// <inheritdoc cref="IRepositoryWriter{T}"/>
    public virtual void Add([NotNull] T entity)
    {
        if (entity is IEntityWithId entityWithId &&
            entityWithId.Id == Guid.Empty)
        {
            entityWithId.Id = Guid.NewGuid();
        }
        AuditForCreate(entity);
        AuditForUpdate(entity);
        writerContext.Writer.Add(entity);
    }

    /// <inheritdoc cref="IRepositoryWriter{T}"/>
    public void Update([NotNull] T entity)
    {
        AuditForUpdate(entity);
        writerContext.Writer.Update(entity);
    }

    /// <inheritdoc cref="IRepositoryWriter{T}"/>
    public void Delete([NotNull] T entity)
    {
        AuditForUpdate(entity);
        AuditForDelete(entity);
        if (entity is IEntityAuditDeleted)
        {
            writerContext.Writer.Update(entity);
        }
        else
        {
            writerContext.Writer.Delete(entity);
        }
    }

    private void AuditForCreate([NotNull] T entity)
    {
        if (entity is IEntityAuditCreated auditCreated)
        {
            auditCreated.CreatedAt = writerContext.DateTimeProvider.UtcNow;
            auditCreated.CreatedBy = writerContext.UserName;
        }
    }

    private void AuditForUpdate([NotNull] T entity)
    {
        if (entity is IEntityAuditUpdated auditUpdate)
        {
            auditUpdate.UpdatedAt = writerContext.DateTimeProvider.UtcNow;
            auditUpdate.UpdatedBy = writerContext.UserName;
        }
    }

    private void AuditForDelete([NotNull] T entity)
    {
        if (entity is IEntityAuditDeleted auditDeleted)
        {
            auditDeleted.DeletedAt = writerContext.DateTimeProvider.UtcNow;
        }
    }
}
}
