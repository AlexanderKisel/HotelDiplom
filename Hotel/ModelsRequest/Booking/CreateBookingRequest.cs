namespace Hotel.ModelsRequest.Booking
{
    public class CreateBookingRequest
    {
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
