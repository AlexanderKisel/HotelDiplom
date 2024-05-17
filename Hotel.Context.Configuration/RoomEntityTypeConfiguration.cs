using Hotel.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Context.Configuration
{
    public class RoomEntityTypeConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.NumberOfSeats).IsRequired();
            builder.Property(x => x.NumberOfRooms).IsRequired();
            builder.Property(x => x.TypeRooms).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder
                .HasMany(x => x.Bookings)
                .WithOne(x => x.Room)
                .HasForeignKey(x => x.RoomId);

            builder.HasIndex(x => x.Number)
                .IsUnique()
                .HasFilter($"{nameof(Room.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Room)}_{nameof(Room.Number)}");
        }
    }
}
