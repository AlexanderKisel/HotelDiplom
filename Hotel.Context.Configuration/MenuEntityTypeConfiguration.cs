using Hotel.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Context.Configuration
{
    public class MenuEntityTypeConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.TypeEat).IsRequired();


            builder.HasIndex(x => x.Name)
                .IsUnique()
                .HasFilter($"{nameof(Menu.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Menu)}_{nameof(Menu.Name)}");
        }
    }
}
