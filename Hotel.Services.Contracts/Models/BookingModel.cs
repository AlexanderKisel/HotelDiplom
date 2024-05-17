using Hotel.Context.Contracts.Models;

namespace Hotel.Services.Contracts.Models
{
    /// <summary>
    /// Модель бронирования
    /// </summary>
    public class BookingModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// <see cref="Room"/>
        /// </summary>
        public RoomModel? Room { get; set; }

        /// <summary>
        /// <see cref="Worker"/>
        /// </summary>
        public WorkerModel? Worker { get; set; }

        /// <summary>
        /// <see cref="Person"/>
        /// </summary>
        public PersonModel? Person { get; set; }

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
