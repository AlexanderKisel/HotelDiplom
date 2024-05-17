using Hotel.Context.Contracts.Models;

namespace Hotel.Services.Contracts.ModelsRequest
{
    /// <summary>
    /// Модель бронирования
    /// </summary>
    public class BookingRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <see cref="Room"/>
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// <see cref="Worker"/>
        /// </summary>
        public Guid WorkerId { get; set; }

        /// <summary>
        /// <see cref="Person"/>
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Дата бронирования
        /// </summary>
        public DateOnly DateReg { get; set; }

        /// <summary>
        /// Дата начала проживания(заезд)
        /// </summary>
        public DateOnly DateStart { get; set; }

        /// <summary>
        /// Дата окончания проживания(съезд)
        /// </summary>
        public DateOnly DateEnd { get; set; }
    }
}
