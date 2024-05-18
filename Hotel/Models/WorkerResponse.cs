namespace Hotel.Api.Models
{
    public class WorkerResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }
        /// <summary>
        ///Электронная почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateOnly Birthday { get; set; }
        /// <summary>
        /// Паспорт
        /// </summary>
        public string Passport {  get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Post { get; set; } = string.Empty;
    }
}
