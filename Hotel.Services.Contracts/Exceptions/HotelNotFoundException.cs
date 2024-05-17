namespace Hotel.Services.Contracts.Exceptions
{
    /// <summary>
    /// Запрашиваемый ресурс не найден
    /// </summary>
    public class HotelNotFoundException : HotelException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="HotelNotFoundException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        public HotelNotFoundException(string message)
            : base(message) { }
    }
}
