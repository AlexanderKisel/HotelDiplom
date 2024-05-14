using Hotel.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Context.Contracts
{
    /// <summary>
    /// Работа с сущностями
    /// </summary>
    public interface IHotelContext
    {
        /// <summary>
        /// Список <inheritdoc cref="Menu"/>
        /// </summary>
        DbSet<Menu> Menus { get; }

        /// <summary>
        /// Список <inheritdoc cref="Person"/>
        /// </summary>
        DbSet<Person> Persons { get; }

        /// <summary>
        /// Список <inheritdoc cref="Worker"/>
        /// </summary>
        DbSet<Worker> Workers { get; }

        /// <summary>
        /// Список <inheritdoc cref="Room"/>
        /// </summary>
        DbSet<Room> Rooms { get; }

        /// <summary>
        /// Список <inheritdoc cref="Booking"/>
        /// </summary>
        DbSet<Booking> Bookings { get; }
    }
}
