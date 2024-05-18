using Hotel.Api.Models.Enums;

namespace Hotel.ModelsRequest.Worker
{
    public class CreateWorkerRequest
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
        public PostsApi Posts { get; set; }
    }
}
