using Hotel.Context.Contracts.Enums;

namespace Hotel.Context.Contracts.Models
{
    /// <summary>
    /// Персона(Клиент), человек совершающий бронь
    /// </summary>
    public class Person : BaseAuditEntity
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; } = string.Empty;

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; } = string.Empty; 

        /// <summary>
        /// Логин для авторизации
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTimeOffset Birthday { get; set; }

        /// <summary>
        /// Бронирование номеров
        /// </summary>
        public IEnumerable<Booking> Bookings { get; set; }
    }
}
