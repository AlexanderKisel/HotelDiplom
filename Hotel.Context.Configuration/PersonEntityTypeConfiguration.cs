using Hotel.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Context.Configuration
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.FIO).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Login).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();

            builder
                .HasMany(x => x.Bookings)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);

            builder.HasIndex(x => x.Email)
                .IsUnique()
                .HasFilter($"{nameof(Person.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Person)}_{nameof(Person.Email)}");

            builder.HasIndex(x => x.Phone)
                .IsUnique()
                .HasFilter($"{nameof(Person.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Person)}_{nameof(Person.Phone)}");

            builder.HasIndex(x => x.Login)
                .IsUnique()
                .HasFilter($"{nameof(Person.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Person)}_{nameof(Person.Login)}");
        }
    }
}
