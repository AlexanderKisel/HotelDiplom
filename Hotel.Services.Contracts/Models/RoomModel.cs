using Hotel.Context.Contracts.Enums;

namespace Hotel.Services.Contracts.Models
{
    /// <summary>
    /// Модель комнат(номеров)
    /// </summary>
    public class RoomModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

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
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Тип номера
        /// </summary>
        public TypeRooms TypeRooms { get; set; } = TypeRooms.None;
    }
}
