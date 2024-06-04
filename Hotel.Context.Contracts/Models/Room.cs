using Hotel.Context.Contracts.Enums;

namespace Hotel.Context.Contracts.Models
{
    /// <summary>
    /// Комнаты (Номера)
    /// </summary>
    public class Room : BaseAuditEntity
    {
        /// <summary>
        /// Номер комнаты(номера)
        /// </summary>
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// Кол-во мест
        /// </summary>
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// Кол-во комнат
        /// </summary>
        public int NumberOfRooms { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public string Price { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string Description {  get; set; } = string.Empty;

        /// <summary>
        /// Тип номера
        /// </summary>
        public TypeRooms TypeRoom { get; set; } = TypeRooms.None;


        /// <summary>
        /// Бронирование номеров
        /// </summary>
        public IEnumerable<Booking>? Bookings { get; set; }
    }
}
