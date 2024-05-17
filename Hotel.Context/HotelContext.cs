using Hotel.Common.Entity.InterfaceDB;
using Hotel.Context.Configuration;
using Hotel.Context.Contracts;
using Hotel.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Context
{
    /// <summary>
    /// Контекст работы с БД
    /// </summary>
    /// <remarks>
    /// 1) dotnet tool install --global dotnet-ef
    /// 2) dotnet tool update --global dotnet-ef
    /// 3) dotnet ef migrations add [name] --project PortKisel.Context\PortKisel.Context.csproj
    /// 4) dotnet ef database update --project PortKisel.Context\PortKisel.Context.csproj
    /// 5) dotnet ef database update [targetMigrationName] --PortKisel.Context\PortKisel.Context.csproj
    /// </remarks>
    public class HotelContext : DbContext,
        IHotelContext,
        IDbRead,
        IDbWrite,
        IUnitOfWork
    {
        public  DbSet<Menu> Menus { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IContextConfigurationAnchor).Assembly);
        }
        IQueryable<TEntity> IDbRead.Read<TEntity>()
            => base.Set<TEntity>()
                .AsNoTracking()
                .AsQueryable();

        void IDbWrite.Add<TEntities>(TEntities entity)
            => base.Entry(entity).State = EntityState.Added;

        void IDbWrite.Update<TEntities>(TEntities entity)
              => base.Entry(entity).State = EntityState.Modified;

        void IDbWrite.Delete<TEntities>(TEntities entity)
              => base.Entry(entity).State = EntityState.Deleted;
        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            var count = await base.SaveChangesAsync(cancellationToken);
            SkipTracker();
            return count;
        }

        public void SkipTracker()
        {
            foreach (var entry in base.ChangeTracker.Entries().ToArray())
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
