namespace Hotel.Services.Contracts.Exceptions
{
    /// <summary>
    /// Ошибка выполнения операции
    /// </summary>
    public class HotelInvalidOperationException : HotelException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="PortInvalidOperationException"/>
        /// с указанием сообщения об ошибке
        /// </summary>
        public HotelInvalidOperationException(string message)
            : base(message) { }
    }
}
