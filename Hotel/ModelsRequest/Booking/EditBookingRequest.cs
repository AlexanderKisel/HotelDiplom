namespace Hotel.ModelsRequest.Booking
{
    public class EditBookingRequest : CreateBookingRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
