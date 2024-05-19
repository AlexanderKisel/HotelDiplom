namespace Hotel.Api.Models
{
    /// <summary>
    /// Модель ответа сущности комнаты(номера)
    /// </summary>
    public class RoomResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Кол-во мест в номере
        /// </summary>
        public int NumberOfSeats { get; set; }
        /// <summary>
        /// Кол-во комнат в номере
        /// </summary>
        public int NumberOfRooms { get; set; }
        /// <summary>
        /// Цена за сутки
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Тип комнаты
        /// </summary>
        public string TypeRoom { get; set; } = string.Empty;
    }
}
