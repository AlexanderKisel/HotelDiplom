using Hotel.Api.Models.Enums;

namespace Hotel.ModelsRequest.Room
{
    public class CreateRoomRequest
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
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Тип номера
        /// </summary>
        public TypeRoomsApi TypeRooms { get; set; }
    }
}
