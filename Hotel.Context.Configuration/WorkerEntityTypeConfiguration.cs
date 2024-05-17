using Hotel.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Context.Configuration
{
    public class WorkerEntityTypeConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Worker");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.FIO).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Login).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Posts).IsRequired();
            builder.Property(x => x.Passport).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();

            builder
                .HasMany(x => x.Bookings)
                .WithOne(x => x.Worker)
                .HasForeignKey(x => x.WorkerId);

            builder.HasIndex(x => x.Email)
                .IsUnique()
                .HasFilter($"{nameof(Worker.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Worker)}_{nameof(Worker.Email)}");

            builder.HasIndex(x => x.Phone)
                .IsUnique()
                .HasFilter($"{nameof(Worker.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Worker)}_{nameof(Worker.Phone)}");

            builder.HasIndex(x => x.Login)
                .IsUnique()
                .HasFilter($"{nameof(Worker.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Worker)}_{nameof(Worker.Login)}");

            builder.HasIndex(x => x.Password)
                .IsUnique()
                .HasFilter($"{nameof(Worker.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Worker)}_{nameof(Worker.Password)}");

            builder.HasIndex(x => x.Passport)
                .IsUnique()
                .HasFilter($"{nameof(Worker.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Worker)}_{nameof(Worker.Passport)}");
        }
    }
}
