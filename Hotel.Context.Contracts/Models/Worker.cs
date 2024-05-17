using Hotel.Context.Contracts.Enums;

namespace Hotel.Context.Contracts.Models
{
    /// <summary>
    /// Работники(Сотрудники отеля)
    /// </summary>
    public class Worker : BaseAuditEntity
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
        public DateOnly Birthday { get; set; }

        /// <summary>
        /// Данные паспорта (серия и номер)
        /// </summary>
        public string Passport { get; set; } = string.Empty;

        /// <summary>
        /// Должность
        /// </summary>
        public Posts Posts { get; set; } = Posts.None;


        /// <summary>
        /// Бронирование номеров
        /// </summary>
        public IEnumerable<Booking> Bookings { get; set; }
    }
}
