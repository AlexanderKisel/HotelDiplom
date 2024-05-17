namespace Hotel.Common.Entity.InterfaceDB
{
    /// <summary>
    /// Определяет контекст репозитория записи сущностей
    /// </summary>
    public interface IDbWriteContext
    {
        /// <inheritdoc cref="IDbWrite"/>
        IDbWrite Writer { get; }

        ///<inheritdoc cref="IUnitOfWork"/>
        IUnitOfWork UnitOfWork { get; }

        /// <inheritdoc cref="IDateTimeProvider"/>
        IDateTimeProvider DateTimeProvider { get; }


        /// <summary>
        /// Имя пользователя
        /// </summary>
        /// <remarks> IIdentity?
        string UserName {  get; }
    }
}
