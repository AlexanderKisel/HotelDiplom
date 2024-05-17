namespace Hotel.Services.Contracts.Exceptions
{
    /// <summary>
    /// Базовый класс
    /// </summary>
    public abstract class HotelException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="HotelException"/> без параметров
        /// </summary>
        protected HotelException() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="HotelException"/> с указанием параметров
        /// </summary>
        protected HotelException(string message) : base(message) { }
    }
}
