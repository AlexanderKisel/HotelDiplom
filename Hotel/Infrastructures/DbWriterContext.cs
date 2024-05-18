using Hotel.Common.Entity.InterfaceDB;
using Hotel.Common;

namespace Hotel.Infrastructures
{
    /// <inheritdoc cref="IDbWriterContext"/>
    public class DbWriterContext : IDbWriteContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="DbWriterContext"/>
        /// </summary>
        /// <remarks>В реальном проекте надо добавлять IIdentity для доступа к
        /// информации об авторизации</remarks>
        public DbWriterContext(
            IDbWrite writer,
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvider)
        {
            Writer = writer;
            UnitOfWork = unitOfWork;
            DateTimeProvider = dateTimeProvider;
        }

        public IDbWrite Writer { get; }

        public IUnitOfWork UnitOfWork { get; }

        public IDateTimeProvider DateTimeProvider { get; }

        public string UserName { get; } = "Hotel.Api";
    }
}
