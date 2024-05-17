using Hotel.Context.Contracts.Enums;

namespace Hotel.Services.Contracts.ModelsRequest
{
    /// <summary>
    /// Модель меню
    /// </summary>
    public class MenuRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Цена
        /// </summary>
        public string Price { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Вид блюда
        /// </summary>
        public TypeEat TypeEat { get; set; }
    }
}
